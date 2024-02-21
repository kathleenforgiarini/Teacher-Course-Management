using SMTI_TeacherCourseManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_TeacherCourseManagement.DAL
{
    public class EmployeeDB
    {
        public static Employee SearchTeacher(int id)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = "SELECT * FROM Employees " +
                                        "WHERE EmployeeNumber = @EmployeeNumber AND " +
                                        "JobTitle <> 'Program Coordinator'";
                cmdSearch.Parameters.AddWithValue("@EmployeeNumber", id);
                SqlDataReader reader = cmdSearch.ExecuteReader();
                Employee employee = new Employee();
                if (reader.Read())
                {
                    employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                    employee.FName = reader["FirstName"].ToString();
                    employee.LName = reader["LastName"].ToString();
                    employee.JobTitle = reader["JobTitle"].ToString();
                }
                else
                {
                    employee = null;
                }

                return employee;
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

        public static Employee SearchCoordinator(int id)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = "SELECT * FROM Employees " +
                                        "WHERE EmployeeNumber = @EmployeeNumber AND " +
                                        "JobTitle = 'Program Coordinator'";
                cmdSearch.Parameters.AddWithValue("@EmployeeNumber", id);
                SqlDataReader reader = cmdSearch.ExecuteReader();
                Employee employee = new Employee();
                if (reader.Read())
                {
                    employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                    employee.FName = reader["FirstName"].ToString();
                    employee.LName = reader["LastName"].ToString();
                    employee.JobTitle = reader["JobTitle"].ToString();
                }
                else
                {
                    employee = null;
                }

                return employee;
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

        public static List<Employee> GetTeacherList()
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdList = new SqlCommand("SELECT * FROM Employees WHERE JobTitle <> 'Program Coordinator'", conn);
            SqlDataReader reader = cmdList.ExecuteReader();
            Employee employee;
            while (reader.Read())
            {
                employee = new Employee();
                employee.EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]);
                employee.FName = reader["FirstName"].ToString();
                employee.LName = reader["LastName"].ToString();
                employee.JobTitle = reader["JobTitle"].ToString();
                listE.Add(employee);

            }
            conn.Close();
            return listE;
        }
    }
}