using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using SMTI_TeacherCourseManagement.DAL;

namespace SMTI_TeacherCourseManagement.BLL
{
    public class Course
    {
        private string courseNumber;
        private string courseTitle;
        private int totalHour;

        public Course()
        {
            courseNumber = string.Empty;
            courseTitle = string.Empty;
            totalHour = 0;
        }

        public Course(string id, string title, int hour)
        {
            this.courseNumber = id;
            this.courseTitle = title;
            this.totalHour = hour;
        }


        public string CourseNumber { get => courseNumber; set => courseNumber = value; }
        public string CourseTitle { get => courseTitle; set => courseTitle = value; }
        public int TotalHour { get => totalHour; set => totalHour = value; }

        public static DataTable GetAllCoursesByTeacher(int employee) => CourseDB.GetAllCoursesByTeacher(employee);

        public static List<Course> GetCourseList() => CourseDB.GetCourseList();
    }
}