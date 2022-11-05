using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Pages.Service;

namespace SevStudentsApp.Pages.Students_Courses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudent_CourseDAO student_CourseDAO = new Student_CourseDAOImpl();
        private readonly IStudent_CourseService? service;


        internal List<Course> courses = new List<Course>();
        internal List<Student> students = new List<Student>();

        public DeleteModel()
        {
            service = new Student_CourseServiceImpl(student_CourseDAO);
        }

        internal Student_CourseDTO student_CourseDTO = new();
        internal string? errorMessage = "";

       

        public void OnGet()
        {
            try
            {
                Student_Course? student_Course;
                int id = int.Parse(Request.Query["id"]);
                int id1 = int.Parse(Request.Query["id1"]);

                student_CourseDTO.Student_id = id;
                student_CourseDTO.Course_id = id1;

                student_Course = service!.DeleteStudent_Course(student_CourseDTO);
                Response.Redirect("/Students_Courses/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }


    }
}
