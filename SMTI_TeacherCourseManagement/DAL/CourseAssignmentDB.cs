using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SMTI_TeacherCourseManagement.BLL;

namespace SMTI_TeacherCourseManagement.DAL
{
    public class CourseAssignmentDB
    {
        internal static void AssignCourse(CourseAssignment courseAssign)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;

                cmdInsert.CommandText = "INSERT INTO CourseAssignments " +
                                        "VALUES(@EmployeeNumber,@CourseNumber,@AssignedDate, @GroupNumber)";

                cmdInsert.Parameters.AddWithValue("@EmployeeNumber", courseAssign.EmployeeNumber);
                cmdInsert.Parameters.AddWithValue("@CourseNumber", courseAssign.CourseNumber);
                cmdInsert.Parameters.AddWithValue("@AssignedDate", courseAssign.AssignedDate);
                cmdInsert.Parameters.AddWithValue("@GroupNumber", courseAssign.GroupNumber);
                cmdInsert.ExecuteNonQuery();

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

        internal static CourseAssignment CheckCourseAssigned(int teacher, string course)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = "SELECT * FROM CourseAssignments " +
                                        "WHERE EmployeeNumber = @EmployeeNumber AND " +
                                        "CourseNumber = @CourseNumber";
                cmdSearch.Parameters.AddWithValue("@EmployeeNumber", teacher);
                cmdSearch.Parameters.AddWithValue("@CourseNumber", course);
                SqlDataReader reader = cmdSearch.ExecuteReader();
                CourseAssignment courseAssignment = new CourseAssignment();
                if (reader.Read())
                {
                    courseAssignment.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                    courseAssignment.CourseNumber = reader["CourseNumber"].ToString();
                    courseAssignment.AssignedDate = Convert.ToDateTime(reader["AssignedDate"]);
                    courseAssignment.GroupNumber = Convert.ToInt32(reader["GroupNumber"]);
                }
                else
                {
                    courseAssignment = null;
                }

                return courseAssignment;
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

        internal static int GetNumberOfCourses(int employeeId)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            int total = 0;
            try
            {
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;

                cmdSelect.CommandText = "SELECT COUNT(*) AS TotalAssignments FROM CourseAssignments WHERE EmployeeNumber = @EmployeeNumber";

                cmdSelect.Parameters.AddWithValue("@EmployeeNumber", employeeId);
                SqlDataReader reader = cmdSelect.ExecuteReader();
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader["TotalAssignments"]);
                }
                reader.Close();

                return total;

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
    }
}