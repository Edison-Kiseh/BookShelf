using BookShelf.ViewModels;

namespace BookShelf
{
    public partial class MainPage : ContentPage
    {
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainViewModel();
        }

    }

}
