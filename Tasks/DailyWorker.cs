using System;
using System.Collections.Generic;
using Tasks.Base;
using Tasks.Interfaces;

namespace Tasks
{
    public class DailyWorker : Worker
    {
        private readonly CleaningTask _cleaningTask;
        private readonly MoreCleaningTask _moreCleaningTask;
        private readonly ILogger _logger;
        private static readonly object Lock = new object();
        private static bool _busy;

        public DailyWorker(
            CleaningTask cleaningTask,
            MoreCleaningTask moreCleaningTask,
            ILogger logger)
            : base(new TimeSpan(24, 0, 0), logger)
        {
            _cleaningTask = cleaningTask;
            _moreCleaningTask = moreCleaningTask;
            _logger = logger;
        }

        public bool IsBusy()
        {
            return Busy;
        }

        protected override bool Busy
        {
            get => _busy;
            set => _busy = value;
        }

        protected override object LockObject { get; } = Lock;

        protected override string GetDescription()
        {
            return "Daily worker";
        }

        protected override IEnumerable<ITask> GetTasks()
        {
            _logger.Info("Daily worker getting cleaning and morecleaning tasks");

            return new List<ITask>
            {
                _cleaningTask,
                _moreCleaningTask
            };
        }
    }
}
