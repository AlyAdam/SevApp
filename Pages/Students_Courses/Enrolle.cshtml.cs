using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Pages.Service;
using SevStudentsApp.Validate;

namespace SevStudentsApp.Pages.Students_Courses
{
    public class EnrolleModel : PageModel
    {
        private readonly IStudent_CourseDAO student_courseDAO = new Student_CourseDAOImpl();
        private readonly IStudent_CourseService student_courseService;

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService CourseService;

        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService studentService;

        internal List<Student> students = new();

        internal List<Course> courses = new();
        public EnrolleModel()
        {
            studentService = new StudentServiceImpl(studentDAO);
            student_courseService = new Student_CourseServiceImpl(student_courseDAO);
            CourseService = new CourseServiceImpl(courseDAO);
        }


        internal string? errorMessage = "";
        internal CourseDTO courseDto = new();
        internal StudentDTO studentDto = new();
        internal Student_CourseDTO studentCourseDTO = new();

        public IActionResult OnGet()
        {
            try
            {
                students = studentService!.GetAllStudents();
                courses = CourseService!.GetAllCourses();
                return Page();  

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return null;
            }

        }
        public void OnPost()
        {
            students = studentService!.GetAllStudents();
            courses = CourseService!.GetAllCourses();
            errorMessage = "";

            studentCourseDTO.Student_id = int.Parse(Request.Form["student_id"]);
            studentCourseDTO.Course_id = int.Parse(Request.Form["course_id"]);


            

            if (!errorMessage.Equals("")) return;
            try
            {

                student_courseService.InsertStudent_Course(studentCourseDTO); 
                Response.Redirect("/Students_Courses/Index");

            }
            catch (Exception e)
            {

                errorMessage = e.Message;
                return;
            }
        }
        private CourseDTO ConvertToDto(Course course)
        {
            {

                return new CourseDTO()
                {
                    Id = course.Id,
                    Description = course.Description,
                    Teacher_id = course.Teacher_id,
                };
            }
        }
    }
}
