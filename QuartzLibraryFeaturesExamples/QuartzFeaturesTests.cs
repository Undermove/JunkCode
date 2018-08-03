using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Xunit;

namespace QuartzLibraryFeaturesExamples
{
    public class QuartzFeaturesTests
    {
        [Fact]
        public void CronScheduleFeatureTest()
        {
	        IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;

	        scheduler.Start();
	        TriggerObject triggerObject = new TriggerObject();

	        var id = Guid.NewGuid().ToString();

	        IJobDetail job = JobBuilder.Create<HelloJob>()
		        .WithIdentity(id, "group1")
		        .UsingJobData(new JobDataMap()
		        {
			        {"triggerObject", triggerObject },
		        })
				.Build();

			TimeSpan time = DateTime.Now.TimeOfDay.Add(TimeSpan.FromSeconds(3));

	        ITrigger trigger = TriggerBuilder.Create()
		        .WithIdentity(id, "group1")
		        .StartNow()
				.WithCronSchedule($"{time.Seconds} {time.Minutes} {time.Hours} * * ?")
				.Build();

			scheduler.ScheduleJob(job, trigger);

	        Thread.Sleep(TimeSpan.FromSeconds(10));

	        scheduler.Shutdown();

			Assert.True(triggerObject.IsTriggered);
		}
    }

	public class TriggerObject
	{
		public bool IsTriggered { get; set; }
	}

	public class HelloJob : IJob
	{
		public async Task Execute(IJobExecutionContext context)
		{
			JobDataMap data = context.JobDetail.JobDataMap;
			var triggerObject = (TriggerObject)data.Get("triggerObject");
			triggerObject.IsTriggered = true;
		}
	}
}
