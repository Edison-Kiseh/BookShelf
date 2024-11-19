using System.Collections.ObjectModel;
using System.ComponentModel;
using BookShelf.Classes.Book;

namespace BookShelf.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books { get; set; }

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

        // Constructor to initialize sample data
        public BookViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book
                {
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "The Great Gatsby",
                    Description = "A novel about the mysterious millionaire Jay Gatsby and his obsession with Daisy Buchanan, set in the Jazz Age.",
                    Author = "F. Scott Fitzgerald",
                    Genre = "Classic",
                    ISBN = "978-0743273565",
                    PublicationDate = new DateTime(1925, 4, 10)
                },
                new Book
                {
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "To Kill a Mockingbird",
                    Description = "A powerful tale of racial injustice and moral growth in the American South.",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    ISBN = "978-0061120084",
                    PublicationDate = new DateTime(1960, 7, 11)
                },
                new Book
                {
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "1984",
                    Description = "A dystopian novel about totalitarianism, surveillance, and the suppression of individuality.",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    ISBN = "978-0451524935",
                    PublicationDate = new DateTime(1949, 6, 8)
                },
                new Book
                {
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "Pride and Prejudice",
                    Description = "A classic romantic tale about Elizabeth Bennet and Mr. Darcy navigating love and societal expectations.",
                    Author = "Jane Austen",
                    Genre = "Romance",
                    ISBN = "978-1503290563",
                    PublicationDate = new DateTime(1813, 1, 28)
                },
                new Book
                {
                    CoverImageUrl = "novel_cover.jpeg",
                    Title = "The Catcher in the Rye",
                    Description = "A story of teenage alienation and rebellion told through the eyes of Holden Caulfield.",
                    Author = "J.D. Salinger",
                    Genre = "Fiction",
                    ISBN = "978-0316769488",
                    PublicationDate = new DateTime(1951, 7, 16)
                },
            };
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
