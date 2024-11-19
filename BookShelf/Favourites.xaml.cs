namespace BookShelf;
using BookShelf.ViewModels;

public partial class Favourites : ContentPage
{
    BookViewModel viewModel;
    public Favourites()
	{
		InitializeComponent();
        BindingContext = viewModel = new BookViewModel();
    }
}