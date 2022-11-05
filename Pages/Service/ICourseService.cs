using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Pages.Service
{
    public interface ICourseService
    {
        /// <summary>
        /// 
        /// returns a list of courses from the database
        /// </summary>
        /// <returns></returns>
        List<Course> GetAllCourses();


        /// <summary>
        /// Inserts a course into the database
        /// </summary>
        /// <param name="dto"></param>
        void InsertCourse(CourseDTO? dto);


        /// <summary>
        /// Updates the description and the id of the teacher
        /// who has that course
        /// </summary>
        /// <param name="dto"></param>
        void UpdateCourse(CourseDTO? dto);

        /// <summary>
        /// Deletes a course from the database
        /// </summary>
        /// <param name="dto"></param>
        
        Course? DeleteCourse(CourseDTO? dto);
        /// <summary>
        ///     Returns one course from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Course? GetCourse(int id);

    }
}
