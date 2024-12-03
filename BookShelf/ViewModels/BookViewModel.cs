using System.Collections.ObjectModel;
using System.ComponentModel;
using BookShelf.Models.Book;
using BookShelf.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookShelf.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books { get; set; } = new ObservableCollection<Book>();
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

        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        // Constructor to initialize sample data
        public BookViewModel()
        {
            NewBook = new Book(); // Holds data for the book being added
            FillBooks();
        }

        public BookViewModel(Book b)
        {
            CurrentBook = b;
        }

        // getting the books from the mysql db
        public async void FillBooks()
        {
            if (Books.Count > 0)
            {
                Books.Clear();
            }

            var books = await DataStore.GetAllBooks();
            foreach (var book in books)
            {
                // Clean the image URL for the book if necessary (removing 'File: ' prefix)
                if (!string.IsNullOrEmpty(book.CoverImageUrl) && book.CoverImageUrl.StartsWith("File: "))
                {
                    book.CoverImageUrl = book.CoverImageUrl.Substring(5);  // Remove 'File: ' prefix
                }

                // Add the cleaned book to the collection
                Books.Add(book);
            }
        }
        public async Task AddBook(Book book)
        {
            await DataStore.AddBook(book);
            Books.Add(book);
        }

        public async Task DeleteBook(Book book)
        {
            await DataStore.DeleteBook(book);
            Books.Remove(book);
        }

        public async Task UpdateBook(Book book)
        {
            await DataStore.UpdateBook(book);
            //Books.Remove(book);
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
