using Tasks.Interfaces;

namespace Tasks
{
    public class PickMyNoseTask : ITask
    {
        private readonly ILogger _logger;

        public PickMyNoseTask(ILogger logger)
        {
            _logger = logger;
        }

        public bool DoWork()
        {
            _logger.Info("Pick my nose");

            return true;
        }

        public string Description { get; } = "Pick my nose task";
    }
}
