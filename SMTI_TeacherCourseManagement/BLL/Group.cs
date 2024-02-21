using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using SMTI_TeacherCourseManagement.DAL;

namespace SMTI_TeacherCourseManagement.BLL
{
    public class Group
    {
        private int groupNumber;
        private string description;

        public Group()
        {
            groupNumber = 0;
            description = string.Empty;
        }

        public Group(int id, string desc)
        {
            this.groupNumber = id;
            this.description = desc;
        }


        public int GroupNumber { get => groupNumber; set => groupNumber = value; }
        public string Description { get => description; set => description = value; }

        public static List<Group> GetGroupList() => GroupDB.GetGroupList();
    }
}