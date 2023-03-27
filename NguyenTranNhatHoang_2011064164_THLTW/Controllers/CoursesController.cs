using Microsoft.AspNet.Identity;
using NguyenTranNhatHoang_2011064164_THLTW.Models;
using NguyenTranNhatHoang_2011064164_THLTW.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenTranNhatHoang_2011064164_THLTW.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = dbContext.Categories.ToList(),
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = dbContext.Categories.ToList();
                return View("Create",viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Home");

        }
        [Authorize]
        public ActionResult Attending() 
        {
            var userId = User.Identity.GetUserId();
            var courses = dbContext.Attendances
                .Where(a=>a.AttendeeId == userId)
                .Select(a=>a.Course)
                .Include(l=>l.Lecturer)
                .Include(l=>l.Category)
                .ToList();

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = courses,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
    }
}