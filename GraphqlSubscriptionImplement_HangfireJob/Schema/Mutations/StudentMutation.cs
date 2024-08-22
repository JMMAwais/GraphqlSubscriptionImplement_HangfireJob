using GraphqlSubscriptionImplement_HangfireJob.Models;
using GraphqlSubscriptionImplement_HangfireJob.Schema.Subscriptions;
using GraphqlSubscriptionImplement_HangfireJob.Services;
using HotChocolate.Subscriptions;

namespace GraphqlSubscriptionImplement_HangfireJob.Schema.Mutations
{
    public class StudentMutation
    {
        public async Task<bool> AddStudent([Service] StudentService studentService, Student input, [Service] ITopicEventSender sender)
        {
            var Student = new Student { Name = input.Name, Age = input.Age, Standard = input.Standard, City = input.City};
            await studentService.AddStudent(Student);
            await sender.SendAsync(nameof(StudentSubscription.StudentAdded), Student);
            return true;
        }

        public bool CheckIn([Service] AttendenceService AttendenceService, int attendenceId)
        {
            AttendenceService.CheckIn(attendenceId);
            return true;
        }

        public bool CheckOut([Service] AttendenceService AttendenceService, int attendenceId)
        {
            AttendenceService.CheckOut(attendenceId);
            return true;
        }
    }
}
