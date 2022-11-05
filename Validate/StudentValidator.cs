using SevStudentsApp.DTO;

namespace SevStudentsApp.Validate
{
    public class StudentValidator
    {
        private StudentValidator() { }

        public static string? Validate(StudentDTO? dto)
        {
            if ((dto!.Firstname!.Length < 2) || 
                (dto!.Lastname!.Length < 2))
            {
                return "Firstname or Lastname should not be less than 2 chars";
            }
            return "";
        }
    }
}
