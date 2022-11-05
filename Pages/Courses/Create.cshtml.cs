using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Pages.Service;
using SevStudentsApp.Validate;

namespace SevStudentsApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService service;

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();
        private readonly ITeacherService? Teacherservice;

        internal List<Teacher> teachers = new();

     

        public CreateModel()
        {
            Teacherservice = new TeacherServiceImpl(teacherDAO);
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDto = new();
        internal string? errorMessage = "";

        public IActionResult OnGet()
        {
            teachers = Teacherservice!.GetAllTeachers();
            return Page();
        }
        public void OnPost()
        {
            courseDto.Description = Request.Form["description"];
            courseDto.Teacher_id = int.Parse(Request.Form["teacher_id"]);

            errorMessage = CourseValidator.Validate(courseDto);

            if (!errorMessage.Equals("")) return;
            try
            {

                service.InsertCourse(courseDto);
                Response.Redirect("/Courses/Index");

            }
            catch (Exception e)
            {    
                errorMessage = e.Message;
                return;
            }
           
        }
    }
}
   
