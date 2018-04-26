
namespace Tasks.Interfaces
{
    public interface ITask
    {
        bool DoWork();
        string Description { get; }
    }
}
