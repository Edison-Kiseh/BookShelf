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

    private void OnStarClicked(object sender, EventArgs e)
    {
        // Navigate to the Edit Page with the selected book's data
        DisplayAlert("Favourite", "Book has been added to your favourites!", "Ok");
        //await Navigation.PushAsync(new EditBookPage(BindingContext));
    }

    private void OnEditClicked(object sender, EventArgs e)
    {
        // Navigate to the Edit Page with the selected book's data
        DisplayAlert("Edit", "Edit book button clicked", "Cancel");
        //await Navigation.PushAsync(new EditBookPage(BindingContext));
    }

    private async void OnRemoveClicked(object sender, EventArgs e)
    {
        // Confirm before removing
        bool confirm = await DisplayAlert("Confirm", "Are you sure you want to remove this book?", "Yes", "No");
        if (confirm)
        {
            // Logic to remove the book (e.g., notify ViewModel or update the database)
            //var viewModel = BindingContext as BookViewModel;
            //if (viewModel != null)
            //{
            //    viewModel.RemoveBook();
            //}

            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
    }
}