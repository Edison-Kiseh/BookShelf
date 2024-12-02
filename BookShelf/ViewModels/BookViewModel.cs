using System.Collections.ObjectModel;
using System.ComponentModel;
using BookShelf.Models.Book;
using BookShelf.Services;

namespace BookShelf.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _books { get; set; }

        // Property for binding
        //public ObservableCollection<Book> Books
        //{
        //    get => _books;
        //    set
        //    {
        //        _books = value;
        //        OnPropertyChanged(nameof(Books));
        //    }
        //}

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public IDataStore DataStore => DependencyService.Get<IDataStore>();

        // Constructor to initialize sample data
        public BookViewModel()
        {
            FillBooks();
        }

        // getting the books from the mysql db
        public async void FillBooks()
        {
            Books.Clear();
            var books = await DataStore.GetAllBooks();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
