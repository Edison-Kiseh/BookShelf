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
        string imageUrl = "adventure.jpg";

        string selectedGenre = GenrePicker.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(selectedGenre))
        {
            selectedGenre = "Adventure";
        }
        else
        {
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
        }

        // Gather all data into a Book object
        var newBook = new Book
        {
            Title = TitleEntry.Text,
            Author = AuthorEntry.Text,
            Genre = selectedGenre,
            ISBN = ISBNEntry.Text,
            PublicationDate = PublicationDatePicker.Date,
            Description = DescriptionEditor.Text,
            CoverImageUrl = imageUrl
        };

        // Example: Send data to a service or print to console
        await DisplayAlert("Book Added Successfully!", $"Title: {newBook.Title}\nAuthor: {newBook.Author}\nGenre: {newBook.Genre}\nISBN: {newBook.ISBN}\nDate: {newBook.PublicationDate}\nDescription: {newBook.Description}", "OK");

        // adding the book
        await viewModel.AddBook(newBook);

        // Navigate back after adding the book (optional)
        await Navigation.PopAsync();
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
    //            string appFolderPath = FileSystem.AppDataDirectory;
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