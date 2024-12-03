using BookShelf.Models.Book;
using BookShelf.ViewModels;

namespace BookShelf
{
    public partial class MainPage : ContentPage
    {
        BookViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new BookViewModel();
        }

        public async void OnFabClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddBookPage));
        }

        public async void OnBookImageTapped(object sender, EventArgs e)
        {
            // it checks if the BindingContext of the Image is a Book object. If it is, it assigns the Book to the variable book.
            if (sender is Image image && image.BindingContext is Book book)
            {
                await Navigation.PushAsync(new BookDetails(book));
            }
        }

    }

}
