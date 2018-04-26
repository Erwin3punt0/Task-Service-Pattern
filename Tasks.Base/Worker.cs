using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.Interfaces;
using Timer = System.Timers.Timer;

namespace Tasks.Base
{
    public abstract class Worker : IWorker
    {
        private readonly ILogger _logger;
        private Timer _timer;

        protected Worker(
            TimeSpan interval,
            ILogger logger)
        {
            _logger = logger;
            _timer = new Timer(interval.TotalMilliseconds);
            _timer.Elapsed += TimerElapsed;
            _timer.Enabled = true;
        }

        private void TimerElapsed(object sender, EventArgs e)
        {
            if (Busy)
            {
                _logger.Info($"Worker {Description} busy");
                return;
            }

            StartTasks();
        }

        private void StartTasks()
        {
            Busy = true;

            lock (LockObject)
            {
                try
                {
                    var tasks = GetTasks().ToList();
                    if (!tasks.Any())
                        return;

                    foreach (var task in tasks)
                    {
                        try
                        {
                            task.DoWork();
                        }
                        catch (Exception ex)
                        {
                            _logger.Error("Worker {Description} throwed an exception.", ex);
                        }
                    }
                }
                finally
                {
                    Busy = false;
                }
            }
        }

        public string Description => GetDescription();

        public virtual void Stop()
        {
            _timer = null;
        }

        public virtual void Run()
        {
            StartTasks();
        }

        protected abstract bool Busy { get; set; }
        protected abstract object LockObject { get; }
        protected abstract string GetDescription();
        protected abstract IEnumerable<ITask> GetTasks();
    }
}
