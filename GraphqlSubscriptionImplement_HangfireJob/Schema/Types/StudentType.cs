using GraphqlSubscriptionImplement_HangfireJob.Models;

namespace GraphqlSubscriptionImplement_HangfireJob.Schema.Types
{
    public class StudentType:ObjectType<Student>
    {
        protected override void Configure(IObjectTypeDescriptor<Student> descriptor)
        {
            descriptor.Field(e => e.Id);
            descriptor.Field(e => e.Name);
            descriptor.Field(e => e.Age);
            descriptor.Field(e => e.Standard);
            descriptor.Field(e => e.City);
        }
    }
}
