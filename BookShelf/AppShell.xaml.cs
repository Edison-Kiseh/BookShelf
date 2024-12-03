namespace BookShelf
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Registering routes
            Routing.RegisterRoute(nameof(AddBookPage), typeof(AddBookPage));
            Routing.RegisterRoute(nameof(BookDetails), typeof(BookDetails));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Favourites), typeof(Favourites));
            Routing.RegisterRoute(nameof(EditBookPage), typeof(EditBookPage));
        }
    }
}
