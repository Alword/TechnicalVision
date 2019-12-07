namespace TechnicalVision.WindowsForms.Abstractions
{
    public interface ICommand<in T>
    {
        void Execute(T parameter);
    }

    public interface ICommand
    {
        void Execute();
    }
}