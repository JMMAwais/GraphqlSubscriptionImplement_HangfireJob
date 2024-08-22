using GraphqlSubscriptionImplement_HangfireJob.Data;
using GraphqlSubscriptionImplement_HangfireJob.Models;
using HotChocolate.Data.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Diagnostics;

namespace GraphqlSubscriptionImplement_HangfireJob.Services
{
    public class StudentService
    {
        private readonly ApplicationDbContext _db;
        public StudentService(ApplicationDbContext db) 
        {
            _db = db;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = await _db.students.ToListAsync();
            return students;    
        }

        public async Task<Student> GetbyId(int Id)
        {
            var student=await _db.students.FirstOrDefaultAsync(x=>x.Id==Id);
            return student;
        }

        public async Task<bool> AddStudent(Student student)
        {
            _db.students.Add(student);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Student> UpdateStudent(Student student,int Id)
        {
            var std =await _db.students.FirstOrDefaultAsync(x=>x.Id==Id);
            std.Id = student.Id;
            std.Name=student.Name;
            std.Age=student.Age;
            std.Standard=student.Standard;
            std.City=student.City;
            _db.students.Update(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public  async Task<bool> DeleteStudent(int Id)
        {
            var student=await _db.students.FirstOrDefaultAsync(x=> x.Id==Id);
            _db.students.Remove(student);
            await _db.SaveChangesAsync();
            return true;

        }
    }
}
