using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Pages.Service;

namespace SevStudentsApp.Pages.Students_Courses
{
    public class IndexModel : PageModel
    {
        private readonly IStudent_CourseDAO student_CourseDAO = new Student_CourseDAOImpl();
        private readonly IStudent_CourseService? service;

        internal List<Student_Course> students_courses = new();

        public IndexModel()
        {
           
            service = new Student_CourseServiceImpl(student_CourseDAO);
        }

        public IActionResult OnGet()
        {
            students_courses = service!.GetAllStudentCourses();
            return Page();
        }
    }
}
