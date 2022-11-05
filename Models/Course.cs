namespace SevStudentsApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public int Teacher_id { get; set; }
    }
}
