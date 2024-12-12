namespace BookShelf;

using BookShelf.Models.Books;
using BookShelf.ViewModels;
using System.IO;

public partial class AddBookPage : ContentPage
{
	BookViewModel viewModel;
    public Book NewBook { get; set; }
    public AddBookPage()
	{
		InitializeComponent();
        BindingContext = viewModel = new BookViewModel();
        NewBook = new Book();
    }
    private async void OnAddButtonClicked(object sender, EventArgs e)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(TitleEntry.Text))
        {
            await DisplayAlert("Validation Error", "Title is required.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(AuthorEntry.Text))
        {
            await DisplayAlert("Validation Error", "Author is required.", "OK");
            return;
        }

        if (GenrePicker.SelectedItem == null)
        {
            await DisplayAlert("Validation Error", "Please select a genre.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(ISBNEntry.Text))
        {
            await DisplayAlert("Validation Error", "Please enter a valid ISBN.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(DescriptionEditor.Text))
        {
            await DisplayAlert("Validation Error", "Description is required.", "OK");
            return;
        }

        // Assign default image based on genre
        string imageUrl = "default.jpg";
        string selectedGenre = GenrePicker.SelectedItem.ToString();
        switch (selectedGenre)
        {
            case "Adventure":
                imageUrl = "adventure.jpg";
                break;
            case "Science Fiction":
                imageUrl = "scifi.jpg";
                break;
            case "Romance":
                imageUrl = "romance.jpg";
                break;
            case "Mystery":
                imageUrl = "mystery.jpg";
                break;
            case "Horror":
                imageUrl = "horror.jpg";
                break;
            default:
                Console.WriteLine("Unknown genre selected.");
                break;
        }

        // Gather all data into a Book object
        var newBook = new Book
        {
            Title = TitleEntry.Text,
            Author = AuthorEntry.Text,
            Genre = selectedGenre,
            ISBN = ISBNEntry.Text,
            Description = DescriptionEditor.Text,
            PublicationDate = PublicationDatePicker.Date,
            CoverImageUrl = imageUrl
        };

        // Example: Send data to a service or print to console
        await DisplayAlert("Book Added Successfully!", $"Title: {newBook.Title}\nAuthor: {newBook.Author}\nGenre: {newBook.Genre}\nISBN: {newBook.ISBN}\nDate: {newBook.PublicationDate.ToShortDateString()}\nDescription: {newBook.Description}", "OK");

        // Add the book using the ViewModel
        await viewModel.AddBook(newBook);

        // Navigate back after adding the book (optional)
        await Navigation.PopAsync();
    }
}