namespace HangfireDemo.Jobs
{
    public interface IHangfireJobs
    {
        void ScheduleEmail(string userName);
        void ReccuringEmail(string userName);
        void SendEmailNow(string userName);
        void ContinuationEmail(string userName);
    }
}