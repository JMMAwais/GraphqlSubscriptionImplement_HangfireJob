using GraphqlSubscriptionImplement_HangfireJob.Models;
using GraphqlSubscriptionImplement_HangfireJob.Services;
using Hangfire;
using Hangfire.Server;
using Hangfire.Storage;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphqlSubscriptionImplement_HangfireJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {
        private readonly IAttendenceService _studentService;
        PerformContext _context;
        //private readonly IRecurringJobManager _recurringJobManager;
        public AttendenceController(IAttendenceService studentService, PerformContext context)
        {
            _studentService = studentService;
            _context = context;
        }

        [HttpPost]
        public IActionResult BackgroundJob()
        {
          //  _studentService.proceedAttendece(_context);
            return Ok();
        }



         

          


    }
}
