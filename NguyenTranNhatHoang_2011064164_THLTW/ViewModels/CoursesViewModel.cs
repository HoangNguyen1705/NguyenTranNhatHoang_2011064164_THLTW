using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NguyenTranNhatHoang_2011064164_THLTW.Models;

namespace NguyenTranNhatHoang_2011064164_THLTW.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}