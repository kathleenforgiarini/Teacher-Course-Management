using SMTI_TeacherCourseManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SMTI_TeacherCourseManagement.DAL
{
    public class GroupDB
    {
        public static List<Group> GetGroupList()
        {
            List<Group> listG = new List<Group>();
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdList = new SqlCommand("SELECT * FROM Groups", conn);
            SqlDataReader reader = cmdList.ExecuteReader();
            Group group;
            while (reader.Read())
            {
                group = new Group();
                group.GroupNumber = Convert.ToInt32(reader["GroupNumber"].ToString());
                group.Description = reader["Description"].ToString();
                listG.Add(group);

            }
            conn.Close();
            return listG;
        }
    }
}