
namespace Tasks.Interfaces
{
    public interface IWorker
    {
        string Description { get; }
        void Stop();
        void Run();
    }
}
