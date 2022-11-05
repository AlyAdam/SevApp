using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Pages.Service
{
    public interface IStudent_CourseService
    {
        /// <summary>
        /// Inserts a student into a course
        /// </summary>
        /// <param name="dto"></param>
        void InsertStudent_Course(Student_CourseDTO? dto);

        /// <summary>
        /// deletes a student from a course
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>FIRSTNAME AND LASTNAME that got deleted from a course</returns>
        Student_Course? DeleteStudent_Course(Student_CourseDTO? dto);
            /// <summary>
            /// shows a list of all the courses and the students that are enrolled in them
            /// </summary>
            /// <returns></returns>
        List<Course> GetAllCourses();

        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<Student_Course> GetAllStudentCourses();

    }
}
