using Quartz;
using Quartz.Impl;

namespace AppInsightOwinDeepDive.Jobs
{
    public class JobScheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<SenderJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInMinutes(5)
                  )
                .StartNow()
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}