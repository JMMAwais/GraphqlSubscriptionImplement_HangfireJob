using GraphqlSubscriptionImplement_HangfireJob.Models;
using HotChocolate.Subscriptions;

namespace GraphqlSubscriptionImplement_HangfireJob.Schema.Subscriptions
{
    public class StudentSubscription
    {
        [Subscribe]
        public Student StudentAdded([EventMessage] Student student) => student;

    }
}
