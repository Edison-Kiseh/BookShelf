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

    public async void OnBookImageTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BookDetails));
    }
}