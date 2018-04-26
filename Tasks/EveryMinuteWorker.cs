using System;
using System.Collections.Generic;
using Tasks.Base;
using Tasks.Interfaces;

namespace Tasks
{
    public class EveryMinuteWorker : Worker
    {
        private readonly PickMyNoseTask _pickMyNoseTask;
        private readonly CountMyBlessingsTask _countMyBlessingsTask;
        private readonly ILogger _logger;
        private static readonly object Lock = new object();
        private static bool _busy;

        public EveryMinuteWorker(
            PickMyNoseTask pickMyNoseTask,
            CountMyBlessingsTask countMyBlessingsTask,
            ILogger logger)
            : base(new TimeSpan(0, 1, 0), logger)
        {
            _pickMyNoseTask = pickMyNoseTask;
            _countMyBlessingsTask = countMyBlessingsTask;
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
            return "Every minute worker";
        }

        protected override IEnumerable<ITask> GetTasks()
        {
            _logger.Info("Every minute worker getting pickmynose and counting my blessings tasks");

            return new List<ITask>
            {
                _pickMyNoseTask,
                _countMyBlessingsTask
            };
        }
    }
}
