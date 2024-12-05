using BookShelf.Models.Books;
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
        string currentGenre = viewModel.CurrentBook.Genre;
        string imageUrl = string.Empty;

        string selectedGenre = GenreEntry.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(selectedGenre))
        {
            selectedGenre = currentGenre;
        }

        // Map the genre to the appropriate image
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
                Console.WriteLine($"Unknown genre selected: {selectedGenre}");
                break;
        }

        Console.WriteLine($"Selected Genre: {selectedGenre}, Image URL: {imageUrl}");

        var updatedBook = new Book
        {
            Id = viewModel.CurrentBook.Id,
            Title = !string.IsNullOrWhiteSpace(TitleEntry.Text) ? TitleEntry.Text : TitleEntry.Placeholder,
            Author = !string.IsNullOrWhiteSpace(AuthorEntry.Text) ? AuthorEntry.Text : AuthorEntry.Placeholder,
            Genre = !string.IsNullOrWhiteSpace(selectedGenre) ? selectedGenre : viewModel.CurrentBook.Genre,
            ISBN = !string.IsNullOrWhiteSpace(ISBNEntry.Text) ? ISBNEntry.Text : ISBNEntry.Placeholder,
            PublicationDate = PublicationDatePicker.Date, // This will always have a valid date
            Description = !string.IsNullOrWhiteSpace(DescriptionEditor.Text) ? DescriptionEditor.Text : DescriptionEditor.Placeholder,
            CoverImageUrl = imageUrl
        };

        await DisplayAlert("Book Updated Successfully!", $"Title: {updatedBook.Title}\nAuthor: {updatedBook.Author}\nGenre: {updatedBook.Genre}\nISBN: {updatedBook.ISBN}\nDate: {updatedBook.PublicationDate}\nDescription: {updatedBook.Description}\n{updatedBook.CoverImageUrl}", "OK");

        // adding the book
        await viewModel.UpdateBook(updatedBook);

        // Send a message to notify BookDetailsPage that the book has been updated
        MessagingCenter.Send(this, "BookUpdated", updatedBook);

        // After updating, return to the previous page (BookDetails)
        await Shell.Current.GoToAsync("//MainPage");
    }

    //private async void OnSelectImage(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
    //        {
    //            Title = "Select your photo"
    //        });

    //        if (photo != null)
    //        {
    //            var stream = await photo.OpenReadAsync();

    //            // Save the file to a writable directory
    //            string appFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    //            string fileName = Path.GetFileName(photo.FullPath);
    //            string fullPath = Path.Combine(appFolderPath, fileName);

    //            using (var fileStream = File.Create(fullPath))
    //            {
    //                await stream.CopyToAsync(fileStream);
    //            }

    //            // Update the ImageSource for the BookImage control with the cleaned image path
    //            BookImage.Source = ImageSource.FromFile(fullPath);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error selecting or saving the image: {ex.Message}");
    //    }
    //}

}