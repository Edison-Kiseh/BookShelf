using BookShelf.Models.Book;
using BookShelf.ViewModels;

namespace BookShelf;

public partial class EditBookPage : ContentPage
{
    BookViewModel viewModel;
    public EditBookPage(Book book)
	{
        InitializeComponent();
        BindingContext = viewModel = new BookViewModel(book);
    }

    private async void OnUpdateButtonClicked(object sender, EventArgs e)
    {
        // Gather all data into a Book object
        var updatedBook = new Book
        {
            Id = viewModel.CurrentBook.Id,
            Title = !string.IsNullOrWhiteSpace(TitleEntry.Text) ? TitleEntry.Text : TitleEntry.Placeholder,
            Author = !string.IsNullOrWhiteSpace(AuthorEntry.Text) ? AuthorEntry.Text : AuthorEntry.Placeholder,
            Genre = !string.IsNullOrWhiteSpace(GenreEntry.Text) ? GenreEntry.Text : GenreEntry.Placeholder,
            ISBN = !string.IsNullOrWhiteSpace(ISBNEntry.Text) ? ISBNEntry.Text : ISBNEntry.Placeholder,
            PublicationDate = PublicationDatePicker.Date, // This will always have a valid date
            Description = !string.IsNullOrWhiteSpace(DescriptionEditor.Text) ? DescriptionEditor.Text : DescriptionEditor.Placeholder,
            CoverImageUrl = BookImage.Source?.ToString().Substring(5) // Ensure the image source is valid and removing the prefix 'File: ' from it
        };

        // Example: Send data to a service or print to console
        await DisplayAlert("Book Updated Successfully!", $"Title: {updatedBook.Title}\nAuthor: {updatedBook.Author}\nGenre: {updatedBook.Genre}\nISBN: {updatedBook.ISBN}\nDate: {updatedBook.PublicationDate}\nDescription: {updatedBook.Description}\n{updatedBook.CoverImageUrl}", "OK");

        // adding the book
        await viewModel.UpdateBook(updatedBook);

        // Navigate to the Edit page (AddBookPage) and pass the selected book
        await Navigation.PushAsync(new BookDetails(updatedBook));
    }

    private async void OnSelectImage(object sender, EventArgs e)
    {
        try
        {
            FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Select your photo"
            });

            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();

                // Save the file to a writable directory
                string appFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string fileName = Path.GetFileName(photo.FullPath);
                string fullPath = Path.Combine(appFolderPath, fileName);

                using (var fileStream = File.Create(fullPath))
                {
                    await stream.CopyToAsync(fileStream);
                }

                // Update the ImageSource for the BookImage control with the cleaned image path
                BookImage.Source = ImageSource.FromFile(fullPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error selecting or saving the image: {ex.Message}");
        }
    }

}