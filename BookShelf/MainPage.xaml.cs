using BookShelf.Models.Books;
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

            MessagingCenter.Subscribe<BookViewModel>(this, "BookAdded", (sender) =>
            {
                viewModel.LoadBooks();
            });

            MessagingCenter.Subscribe<BookViewModel>(this, "BookDeleted", (sender) =>
            {
                viewModel.LoadBooks();
            });

            MessagingCenter.Subscribe<BookViewModel>(this, "BookUpdated", (sender) =>
            {
                viewModel.LoadBooks();
            });
        }

        public async void OnFabClicked(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync(nameof(AddBookPage));
            await Navigation.PushAsync(new AddBookPage());
        }

        public async void OnBookImageTapped(object sender, EventArgs e)
        {
            // it checks if the BindingContext of the Image is a Book object. If it is, it assigns the Book to the variable book.
            if (sender is Image image && image.BindingContext is Book book)
            {
                await Navigation.PushAsync(new BookDetails(book));
            }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.SearchQuery = e.NewTextValue;
        }


    }

}
