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
	        TriggerObject triggerObject = new TriggerObject(){Id = 1};
	        TriggerObject triggerObject2 = new TriggerObject(){Id = 2};

	        var id = Guid.NewGuid().ToString();

			IJobDetail job = JobBuilder.Create<HelloJob>()
				.WithIdentity(id, "group1")
				.UsingJobData(new JobDataMap()
				{
					{"triggerObject", triggerObject },
				})
				.Build();
			IJobDetail job2 = JobBuilder.Create<HelloJob>()
		        .WithIdentity(id, "group1")
		        .UsingJobData(new JobDataMap()
		        {
			        {"triggerObject", triggerObject2 },
		        })
		        .Build();

			TimeSpan time = DateTime.Now.TimeOfDay.Add(TimeSpan.FromSeconds(3));

			ITrigger trigger = TriggerBuilder.Create()
				.WithIdentity(id, "group1")
				.StartNow()
				.WithCronSchedule($"{time.Seconds} {time.Minutes} {time.Hours} * * ?")
				.Build();

			scheduler.ScheduleJob(job, trigger);
			scheduler.DeleteJob(job.Key);
			scheduler.ScheduleJob(job2, trigger);

			Thread.Sleep(TimeSpan.FromSeconds(10));

	        scheduler.Shutdown();

			Assert.False(triggerObject.IsTriggered);
			Assert.True(triggerObject2.IsTriggered);
		}
    }

	public class TriggerObject
	{
		public int Id { get; set; }
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
