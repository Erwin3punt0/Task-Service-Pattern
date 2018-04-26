using System.Threading;
using Tasks.Interfaces;

namespace Tasks
{
    public class CountMyBlessingsTask : ITask
    {
        private readonly ILogger _logger;

        public CountMyBlessingsTask(ILogger logger)
        {
            _logger = logger;
        }

        public bool DoWork()
        {
            _logger.Info("Count my blessings");

            const int blessing = 100;

            for (var i = 1; i <= blessing; i++)
            {
                _logger.Info($"Blessing {i}");
                Thread.Sleep(1000);
            }

            return true;
        }

        public string Description { get; } = "Count my blessings task";
    }
}
