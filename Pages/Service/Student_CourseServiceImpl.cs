using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Pages.Service
{
    public class Student_CourseServiceImpl : IStudent_CourseService
    {
        private readonly IStudent_CourseDAO dao;

        public Student_CourseServiceImpl(IStudent_CourseDAO dao)
        {
            this.dao = dao;
        }
        public void InsertStudent_Course(Student_CourseDTO? dto)
        {
            if (dto == null) return;
            try
            {
                Student_Course? student_course = Convert(dto);
                dao.Insert(student_course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Student_Course? DeleteStudent_Course(Student_CourseDTO? dto)
        {
            if (dto == null) return null;
            try
            {
                Student_Course? student_course = Convert(dto);
                return dao.Delete(student_course);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }
        private Student_Course? Convert(Student_CourseDTO dto)
        {
            if (dto == null) return null;

            return new Student_Course()
            {

                Student_id = dto.Student_id,
                Course_id = dto.Course_id,
            };
        }
        public List<Student_Course> GetAllStudentCourses()
        {
            try
            {
                return dao.GetAllStudentCourses();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student_Course>();
            }
        }
    }
}
