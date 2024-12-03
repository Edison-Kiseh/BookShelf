namespace BookShelf;
using BookShelf.ViewModels;
using BookShelf.Models.Book;

public partial class BookDetails : ContentPage
{
    BookViewModel viewModel;
    private Book _book = new Book();
    public BookDetails(Book book)
	{
        InitializeComponent();
        _book = book;
        BindingContext = viewModel = new BookViewModel(book);
    }

    private void OnStarClicked(object sender, EventArgs e)
    {
        // Navigate to the Edit Page with the selected book's data
        DisplayAlert("Favourite", "Book has been added to your favourites!", "Ok");
        //await Navigation.PushAsync(new EditBookPage(BindingContext));
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        // Navigate to the Edit Page with the selected book's data
        //DisplayAlert("Edit", "Edit book button clicked", "Cancel");
        // it checks if the BindingContext of the Image is a Book object. If it is, it assigns the Book to the variable book.
        // Get the BindingContext of the page, which should be the Book object

        // Navigate to the Edit page (AddBookPage) and pass the selected book
        await Navigation.PushAsync(new EditBookPage(_book));
    }

    private async void OnRemoveClicked(object sender, EventArgs e)
    {
        // Confirm before removing
        bool confirm = await DisplayAlert("Confirm", "Are you sure you want to remove this book?", "Yes", "No");
        if (confirm)
        {
            // deleting the book
            await viewModel.DeleteBook(_book);

            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
    }
}