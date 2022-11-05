using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Pages.Service
{
    public interface IStudentService 
    {
        /// <summary>
        /// returns a list of students from the database
        /// </summary>
        /// <returns></returns>
        List<Student> GetAllStudents();


        /// <summary>
        /// Inserts a student into the database
        /// </summary>
        /// <param name="dto"></param>
        void InsertStudent(StudentDTO? dto);


        /// <summary>
        /// Updates the FIRSTNAME and LASTNAME of a student
        /// </summary>
        /// <param name="dto"></param>
        void UpdateStudent(StudentDTO? dto);

        /// <summary>
        /// Deletes a Student from the database
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>the ID,FIRSTNAME and LASTNAME of a student</returns>
        Student? DeleteStudent(StudentDTO? dto);
        /// <summary>
        ///     Returns one student from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student? GetStudent(int id);

    }
}
