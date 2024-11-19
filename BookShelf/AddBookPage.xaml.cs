namespace BookShelf;
using BookShelf.ViewModels;

public partial class AddBookPage : ContentPage
{
	BookViewModel viewModel;
	public AddBookPage()
	{
		InitializeComponent();
        BindingContext = viewModel = new BookViewModel();
    }

	private void OnAddButtonClicked(object sender, EventArgs e)
	{
        DisplayAlert("FAB Clicked", "You clicked the add button", "OK");
    }

	private void OnGenreSelected(object sender, EventArgs e)
	{

	}
}