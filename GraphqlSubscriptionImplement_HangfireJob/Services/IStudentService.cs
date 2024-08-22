using GraphqlSubscriptionImplement_HangfireJob.Models;

namespace GraphqlSubscriptionImplement_HangfireJob.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetbyId(int Id);
        Task<bool> AddStudent(Student student);
    }
}
