using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMTI_TeacherCourseManagement.DAL;

namespace SMTI_TeacherCourseManagement.BLL
{
    public class User
    {
        private int userName;
        private string password;

        public User()
        {
            userName = 0;
            password = string.Empty;
        }

        public User(int id, string password)
        {
            this.userName = id;
            this.password = password;
        }


        public int UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        public static User SearchUser(int id, string password) => UserDB.SearchUser(id, password);
    }
}