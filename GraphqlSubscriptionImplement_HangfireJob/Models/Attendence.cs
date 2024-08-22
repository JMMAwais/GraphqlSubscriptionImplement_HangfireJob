using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GraphqlSubscriptionImplement_HangfireJob.Models
{
    public class Attendence
    {
        [Key]
        
        public int? Id { get; set; }

        public DateOnly? Date { get; set; }
        public DateTime? TimeIn { get; set; }

        public DateTime? Timeout { get; set; }

        public AttendenceType Status { get; set; }

        [ForeignKey("fk_studenID")]
        public int Student_Id { get; set; }

        public virtual Student? student { get; set; }


    }


    public enum AttendenceType
    {
        NotMarked,
        Present,
        Absent,
        OnLeave
    }

}
