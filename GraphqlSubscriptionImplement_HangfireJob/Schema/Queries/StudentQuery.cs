using GraphqlSubscriptionImplement_HangfireJob.Models;
using GraphqlSubscriptionImplement_HangfireJob.Services;

namespace GraphqlSubscriptionImplement_HangfireJob.Schema.Queries
{
    public class StudentQuery
    {
        public async Task<IEnumerable<Student>> GetEmployees([Service] StudentService studentService)
        {
            return await studentService.GetAllStudents();
        }

        public async Task<Student> GetStudentById([Service] StudentService studentService, int id)
        {
            return await studentService.GetbyId(id);
        }
    }
}
