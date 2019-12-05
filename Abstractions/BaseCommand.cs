namespace TechnicalVision.WindowsForms.Abstractions
{
    public abstract class BaseCommand
    {
        protected MainWindow MainWindow { get; set; }

        public BaseCommand(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }
    }
}
