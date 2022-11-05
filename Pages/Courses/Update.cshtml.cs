using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Pages.Service;
using SevStudentsApp.Validate;

namespace SevStudentsApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? Teacherservice;

        internal List<Teacher> teachers = new();
        public UpdateModel()
        {
            Teacherservice = new TeacherServiceImpl(teacherDAO);
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string? errorMessage = "";
        public IActionResult OnGet()
        {
            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                course = service.GetCourse(id);
                if (course != null)
                {
                    courseDto = ConvertToDto(course);
                }
                teachers = Teacherservice!.GetAllTeachers();
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
            errorMessage = "";

            courseDto.Id = int.Parse(Request.Form["id"]);
            courseDto.Description = Request.Form["description"];
            courseDto.Teacher_id = int.Parse(Request.Form["teacher_id"]);

            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;
            try
            {

                service.UpdateCourse(courseDto);
                Response.Redirect("/Courses/Index");
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
   