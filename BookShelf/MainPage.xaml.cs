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

        public void OnFabClicked(object sender, EventArgs e)
        {
            DisplayAlert("FAB Clicked", "You clicked the Floating Action Button", "OK");
        }

    }

}
