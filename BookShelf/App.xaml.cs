using BookShelf.Services;

namespace BookShelf
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Registering IDataStore implementation
            DependencyService.Register<MysqlDataStore>(); // Registers MysqlDataStore as the implementation of IDataStore
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}