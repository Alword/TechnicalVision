namespace TechnicalVision.WindowsForms.Abstractions
{
    public abstract class BaseCommand
    {
        public BaseCommand(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
        }

        protected MainWindow MainWindow { get; set; }
    }
}