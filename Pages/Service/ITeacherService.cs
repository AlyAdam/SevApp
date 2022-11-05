using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Pages.Service
{
    public interface ITeacherService
    {
        /// <summary>
        /// returns a list of teachers from the database
        /// </summary>
        /// <returns></returns>
        List<Teacher> GetAllTeachers();
        /// <summary>
        /// Inserts a teacher into the database
        /// </summary>
        /// <param name="dto"></param>
        void InsertTeacher(TeacherDTO? dto);
        /// <summary>
        /// Updates the FIRSTNAME and LASTNAME of a teacher
        /// </summary>
        /// <param name="dto"></param>
        void UpdateTeacher(TeacherDTO? dto);

        /// <summary>
        /// Deletes a Teacher from the database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Teacher? DeleteTeacher(TeacherDTO? dto);
        /// <summary>
        ///     Returns one teacher from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Teacher? GetTeacher(int id);

    }
}
