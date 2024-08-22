using GraphqlSubscriptionImplement_HangfireJob.Controllers;
using GraphqlSubscriptionImplement_HangfireJob.Data;
using GraphqlSubscriptionImplement_HangfireJob.Models;
using Hangfire;
using Hangfire.Server;
using MassTransit;
using MassTransit.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;


namespace GraphqlSubscriptionImplement_HangfireJob.Services
{
    public class AttendenceService:IAttendenceService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<IAttendenceService> _logger;
      //  private readonly PerformContext _performContext;

        public AttendenceService(ApplicationDbContext db,
            ILogger<IAttendenceService> logger)
        {
            _db = db;
            _logger = logger;
           // _performContext = performContext;
        }



        public void proceedAttendece()
        {

            var studentlist = _db.students.ToList();

            foreach (var item in studentlist)
            {
                var attendenceRecord = _db.attendences.Any(x => x.Student_Id == item.Id && x.Date == DateOnly.FromDateTime(DateTime.Now));
                if(attendenceRecord)
                {
                    _logger.LogInformation($"Attendance record already exists for student ID: {item.Id} ");
                  // var d= _performContext.WriteLine();
                }
                else
                {
                    var attendence = new Attendence()
                    {
                        Student_Id = item.Id,
                        TimeIn = null,
                        Timeout = null,
                        Status = AttendenceType.NotMarked,
                        Date = DateOnly.FromDateTime(DateTime.Now)
                    };
                    _db.attendences.Add(attendence);
                }
               
            }

        
            _db.SaveChanges();

        }

        public void CheckIn(int Id)
        {
            var attendence= _db.attendences.FirstOrDefault(x=>x.Id== Id);
            if(attendence==null)
            {
                throw new Exception($"No record found against{Id}");
            }
            var currentTime = DateTime.UtcNow;
            if(currentTime.Hour <= 12)
            {
                attendence.TimeIn = currentTime;
                attendence.Status = AttendenceType.Present;
            }
            else
            {
                attendence.TimeIn= currentTime;
                attendence.Status = AttendenceType.Absent;
            }
            _db.attendences.Update(attendence);
            _db.SaveChanges();
        }

        
        public void CheckOut(int Id)
        {
            var attendence = _db.attendences.FirstOrDefault(x => x.Id == Id);
            if(attendence==null)
            {
                throw new Exception($"No record found against{Id}");
            }
            var currentTime = DateTime.UtcNow;
            if (currentTime.Hour <= 12)
            {
                attendence.Status = AttendenceType.Present;
                attendence.Timeout = currentTime;
            }
            else
            {
                attendence.TimeIn = currentTime;
                attendence.Status = AttendenceType.Absent;
            }
            _db.attendences.Update(attendence);
            _db.SaveChanges();
        }

      
    }
}
