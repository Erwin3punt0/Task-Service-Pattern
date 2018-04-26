using Tasks.Interfaces;

namespace Tasks
{
    public class CleaningTask : ITask
    {
        private readonly ILogger _logger;

        public CleaningTask(ILogger logger)
        {
            _logger = logger;
        }

        public bool DoWork()
        {
            _logger.Info("Do some cleaning");

            return true;
        }

        public string Description { get; } = "Cleaning task";
    }
}
