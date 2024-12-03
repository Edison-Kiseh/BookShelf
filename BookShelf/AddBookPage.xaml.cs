namespace BookShelf;

using BookShelf.Models.Book;
using BookShelf.ViewModels;

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
        // Gather all data into a Book object
        var newBook = new Book
        {
            Title = TitleEntry.Text,
            Author = AuthorEntry.Text,
            Genre = GenreEntry.Text,
            ISBN = ISBNEntry.Text,
            PublicationDate = PublicationDatePicker.Date,
            Description = DescriptionEditor.Text,
            CoverImageUrl = BookImage.Source?.ToString() // Ensure the image source is valid
        };

        // Example: Send data to a service or print to console
        await DisplayAlert("Book Added Successfully!", $"Title: {newBook.Title}\nAuthor: {newBook.Author}\nGenre: {newBook.Genre}\nISBN: {newBook.ISBN}\nDate: {newBook.PublicationDate}\nDescription: {newBook.Description}", "OK");

        // adding the book
        await viewModel.AddBook(newBook);

        // Navigate back after adding the book (optional)
        await Navigation.PopAsync();
        //DisplayAlert("Alert", "FAB button clicked", "Ok");
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