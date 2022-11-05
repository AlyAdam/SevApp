using SevStudentsApp.DAO.DBUtill;
using SevStudentsApp.Models;
using System.Data.SqlClient;

namespace SevStudentsApp.DAO
{
    public class Student_CourseDAOImpl : IStudent_CourseDAO
    {

        public void Insert(Student_Course? student_course)
        {
            if (student_course == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.getConnection();
                if (conn is not null)
                {
                    conn.Open();
                }
                else return;
                string sql = "INSERT INTO STUDENT_COURSE (STUDENT_ID, COURSE_ID) VALUES (@student_id, @course_id)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@student_id", student_course.Student_id);
                command.Parameters.AddWithValue("@course_id", student_course.Course_id);

                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                throw;
            }
        }
        public Student_Course? Delete(Student_Course? student_course)
        {
            if (student_course == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.getConnection();
                if (conn is not null)
                {
                    conn.Open();
                }
                else return null;
                string sql = "DELETE FROM STUDENT_COURSE WHERE (STUDENT_ID = @student_id AND COURSE_ID = @course_id)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@student_id", student_course.Student_id);
                command.Parameters.AddWithValue("@course_id", student_course.Course_id);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0 ? student_course : null;

                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                throw;
            }
        }
        public List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            try
            {
                using SqlConnection? conn = DBHelper.getConnection();
                if (conn is not null)
                {
                    conn.Open();
                }
                string sql = "SELECT * FROM COURSES";
                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        Teacher_id = reader.GetInt32(2),
                    };

                    courses.Add(course);
                }

                return courses;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
                throw;
            }
        }



        public List<Student_Course> GetAllStudentCourses()
        {
            List<Student_Course> student_courses = new List<Student_Course>();
            try
            {
                using SqlConnection? conn = DBHelper.getConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENT_COURSE";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student_Course student_Course = new Student_Course()
                    {
                        Student_id = reader.GetInt32(0),
                        Course_id = reader.GetInt32(1)
                    };

                    student_courses.Add(student_Course);
                }

                return student_courses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}







