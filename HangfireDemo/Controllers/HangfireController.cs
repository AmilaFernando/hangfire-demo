using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using HangfireDemo.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        readonly IHangfireJobs _hangfireJobs;

        public HangfireController(IHangfireJobs jobs)
        {
            _hangfireJobs = jobs;
        }

        [HttpPost]
        [Route("Fire-and-forget-job")]
        public IActionResult FireAndForget(string userName)
        {
            var jobId = BackgroundJob.Enqueue(
                () => _hangfireJobs.SendEmailNow(userName));
            return Ok($"Job Id {jobId} Completed.");
        }

        [HttpPost]
        [Route("Delayed-job")]
        public IActionResult Delayed(string userName)
        {
            var jobId = BackgroundJob.Schedule(
                () => _hangfireJobs.ScheduleEmail(userName), TimeSpan.FromMinutes(2));
            return Ok($"Job Id {jobId} Completed.");
        }

        [HttpPost]
        [Route("Recurring-job")]
        public IActionResult Reccuring(string userName)
        {
            RecurringJob.AddOrUpdate(
                () => _hangfireJobs.ReccuringEmail(userName), Cron.Weekly);
            return Ok($"Weekly statement for {userName} is on the way");
        }

        [HttpPost]
        [Route("Continuation-job")]
        public IActionResult Continuation(string userName)
        {
            var jobId = BackgroundJob.Enqueue(() => _hangfireJobs.ContinuationEmail(userName));
            BackgroundJob.ContinueJobWith(
                jobId, 
                () => Console.WriteLine($"Transaction is successfully completed for {userName}"));
            return Ok($"Transaction is successfully completed");
        }
    }
}