namespace BookShelf;
using BookShelf.ViewModels;

public partial class BookDetails : ContentPage
{
    BookViewModel viewModel;
    public BookDetails()
	{
        InitializeComponent();
        BindingContext = viewModel = new BookViewModel();
    }
}