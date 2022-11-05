using SevStudentsApp.Models;

namespace SevStudentsApp.DAO
{
    public interface IStudent_CourseDAO
    {
        void Insert(Student_Course? student_course);
        Student_Course? Delete(Student_Course? student_course);

        List<Student_Course> GetAllStudentCourses();

        List<Course> GetAll();

    }
}
