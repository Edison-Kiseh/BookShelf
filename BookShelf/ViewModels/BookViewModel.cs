using System.Collections.ObjectModel;
using System.ComponentModel;
using BookShelf.Models.Books;
using BookShelf.Models.Category;
using BookShelf.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookShelf.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books { get; set; } = new ObservableCollection<Book>();
        private ObservableCollection<Category> _categories { get; set; } = new ObservableCollection<Category>();
        //public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public Book NewBook { get; set; }
        public Book CurrentBook { get; set; } = new Book();

        // Property for binding
        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    FilterBooks();
                }
            }
        }

        bool IsCategoriesEmpty = true;

        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        // Constructor to initialize sample data
        public BookViewModel()
        {
            NewBook = new Book(); // Holds data for the book being added
            LoadBooks();
        }

        public BookViewModel(Book b)
        {
            CurrentBook = b;
        }

        // getting the books from the mysql db
        public async void LoadBooks()
        {
            if (Books.Count > 0)
            {
                Books.Clear();
                IsCategoriesEmpty = false;
            }

            var books = await DataStore.GetAllBooks();

            // Dictionary to store books grouped by category name
            var categorizedBooks = new Dictionary<string, ObservableCollection<Book>>();

            foreach (var book in books)
            {
                // Clean the image URL for the book if necessary (removing 'File: ' prefix)
                if (!string.IsNullOrEmpty(book.CoverImageUrl) && book.CoverImageUrl.StartsWith("File: "))
                {
                    book.CoverImageUrl = book.CoverImageUrl.Substring(5);  // Remove 'File: ' prefix
                }

                // Group books by category
                if (!string.IsNullOrEmpty(book.Genre))
                {
                    if (!categorizedBooks.ContainsKey(book.Genre))
                    {
                        categorizedBooks[book.Genre] = new ObservableCollection<Book>();
                    }
                    categorizedBooks[book.Genre].Add(book);
                }

                // Add the cleaned book to the collection
                Books.Add(book);
            }

            // Convert the grouped data into Category objects
            Categories.Clear();
            foreach (var category in categorizedBooks)
            {
                Categories.Add(new Category
                {
                    Name = category.Key,
                    Books = category.Value
                });
            }
        }
        private void FilterBooks()
        {
            if (string.IsNullOrEmpty(SearchQuery))
            {
                // Reset to all books if search query is empty
                UpdateCategories(Books);
            }
            else
            {
                // Filter books by title or author
                var filteredBooks = Books.Where(book =>
                    book.Title.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

                UpdateCategories(new ObservableCollection<Book>(filteredBooks));
            }
        }

        private void UpdateCategories(ObservableCollection<Book> books)
        {
            // Group books by genre and update categories
            var groupedBooks = books
                .GroupBy(book => book.Genre)
                .Select(group => new Category
                {
                    Name = group.Key,
                    Books = new ObservableCollection<Book>(group)
                })
                .ToList();

            Categories = new ObservableCollection<Category>(groupedBooks);
        }

        public async Task AddBook(Book book)
        {
            await DataStore.AddBook(book);
            Books.Add(book);

            MessagingCenter.Send(this, "BookAdded");
        }

        public async Task DeleteBook(Book book)
        {
            await DataStore.DeleteBook(book);
            Books.Remove(book);

            MessagingCenter.Send(this, "BookDeleted");
        }

        public async Task UpdateBook(Book book)
        {
            await DataStore.UpdateBook(book);

            MessagingCenter.Send(this, "BookUpdated");
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
