using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Pages.Service;

namespace SevStudentsApp.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public DeleteModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = "";

        public void OnGet()
        {
            StudentDTO studentDTO = new();
            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                studentDTO.Id = id;

                student = service.DeleteStudent(studentDTO);
                Response.Redirect("/Students/Index");
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return;
            }
        }
    }
}