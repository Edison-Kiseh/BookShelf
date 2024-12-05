namespace BookShelf;
using BookShelf.ViewModels;
using BookShelf.Models.Books;

public partial class BookDetails : ContentPage
{
    BookViewModel viewModel;
    private Book _book = new Book();
    public BookDetails(Book book)
	{
        InitializeComponent();
        _book = book;
        BindingContext = viewModel = new BookViewModel(book);

        // Subscribe to the book updated message
        MessagingCenter.Subscribe<EditBookPage, Book>(this, "BookUpdated", (sender, updatedBook) =>
        {
            // Update the book details here
            _book = updatedBook;
            BindingContext = _book; // Update the BindingContext to reflect changes
        });
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
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