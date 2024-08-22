using GraphqlSubscriptionImplement_HangfireJob.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace GraphqlSubscriptionImplement_HangfireJob.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }  
        public DbSet<Attendence> attendences { get; set; }  
    }
}
