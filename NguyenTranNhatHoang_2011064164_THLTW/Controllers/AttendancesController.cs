using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using NguyenTranNhatHoang_2011064164_THLTW.DTOs;
using NguyenTranNhatHoang_2011064164_THLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenTranNhatHoang_2011064164_THLTW.Controllers
{
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext dbcontext;
        public AttendancesController()
        {
            dbcontext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if(dbcontext.Attendances.Any(a=>a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
            {
                return BadRequest("The Attendances already exists !");
            }
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = User.Identity.GetUserId()

            };
            dbcontext.Attendances.Add(attendance);
            dbcontext.SaveChanges();
            return Ok();
        }
    }
}
