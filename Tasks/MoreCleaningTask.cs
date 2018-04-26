using Tasks.Interfaces;

namespace Tasks
{
    public class MoreCleaningTask : ITask
    {
        private readonly ILogger _logger;

        public MoreCleaningTask(ILogger logger)
        {
            _logger = logger;
        }

        public bool DoWork()
        {
            _logger.Info("Do some more cleaning");

            return true;
        }

        public string Description { get; } = "More cleaning task";
    }
}
