using System;

namespace Tasks.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();

            var dailyWorker = new DailyWorker(
                new CleaningTask(logger), 
                new MoreCleaningTask(logger), 
                logger);

            var everyMinuteWorker = new EveryMinuteWorker(
                new PickMyNoseTask(logger),
                new CountMyBlessingsTask(logger),
                logger);

            logger.Info("Press key to stop tasks host");
            Console.ReadLine();
        }
    }
}
