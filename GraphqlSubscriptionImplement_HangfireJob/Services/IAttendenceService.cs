using GraphqlSubscriptionImplement_HangfireJob.Models;
using Hangfire.Server;

namespace GraphqlSubscriptionImplement_HangfireJob.Services
{
    public interface IAttendenceService
    {
        void proceedAttendece();
        void CheckIn(int Id);
        void CheckOut(int Id);
    }
}
