using SevStudentsApp.DTO;

namespace SevStudentsApp.Validate
{
    public class CourseValidator
    {
        private CourseValidator() { }
        public static string? Validate(CourseDTO? dto)
        {
            if (dto!.Description!.Length < 2)
            {
                return "Description should not be less than 2 chars";
            }
            return "";
        }
         
    }
}
