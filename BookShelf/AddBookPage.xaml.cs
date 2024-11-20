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

	private void OnSelectCoverImageClicked(object sender, EventArgs e)
	{

	}

    private async void OnSelectImage(object sender, EventArgs e)
    {
        FileResult photo = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select your photo"
        });

        if (photo != null)
        {
            var stream = await photo.OpenReadAsync();
            BookImage.Source = ImageSource.FromStream(() => stream);
        }
    }

    
}