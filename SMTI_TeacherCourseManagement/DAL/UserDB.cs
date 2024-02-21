using SMTI_TeacherCourseManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_TeacherCourseManagement.DAL
{
    public class UserDB
    {
        public static User SearchUser(int id, string pass)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            try
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;
                cmdSearch.CommandText = "SELECT * FROM Users " +
                                        "WHERE UserName = @UserName AND " +
                                        "Password = @Password";
                cmdSearch.Parameters.AddWithValue("@UserName", id);
                cmdSearch.Parameters.AddWithValue("@Password", pass);
                SqlDataReader reader = cmdSearch.ExecuteReader();
                User user = new User();
                if (reader.Read())
                {
                    user.UserName = Convert.ToInt32(reader["UserName"]);
                    user.Password = reader["UserName"].ToString();
                }
                else
                {
                    user = null;
                }

                return user;
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