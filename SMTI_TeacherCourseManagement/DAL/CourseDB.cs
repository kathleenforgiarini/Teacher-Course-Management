using SMTI_TeacherCourseManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_TeacherCourseManagement.DAL
{
    public class CourseDB
    {
        internal static DataTable GetAllCoursesByTeacher(int employee)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;
                cmdSelect.CommandText = "SELECT c.CourseNumber, c.CourseTitle, c.TotalHour, " +
                                        "CONVERT(varchar, ca.AssignedDate, 23) AS AssignedDate, " +
                                        "ca.GroupNumber FROM Courses c " +
                                       "JOIN CourseAssignments ca ON c.CourseNumber = ca.CourseNumber " +
                                       "WHERE ca.EmployeeNumber = @EmployeeNumber";

                cmdSelect.Parameters.AddWithValue("@EmployeeNumber", employee);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmdSelect))
                {
                    adapter.Fill(dt);
                }

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Course> GetCourseList()
        {
            List<Course> listC = new List<Course>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdList = new SqlCommand("SELECT * FROM Courses", conn);
            SqlDataReader reader = cmdList.ExecuteReader();
            Course course;
            while (reader.Read())
            {
                course = new Course();
                course.CourseNumber = reader["CourseNumber"].ToString();
                course.CourseTitle = reader["CourseTitle"].ToString();
                course.TotalHour = Convert.ToInt32(reader["TotalHour"].ToString());
                listC.Add(course);

            }
            conn.Close();
            return listC;
        }
    }
}