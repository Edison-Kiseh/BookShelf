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
            await Shell.Current.GoToAsync(nameof(BookDetails));
        }

    }

}
