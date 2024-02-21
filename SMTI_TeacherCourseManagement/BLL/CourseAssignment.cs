using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SMTI_TeacherCourseManagement.DAL;

namespace SMTI_TeacherCourseManagement.BLL
{
    public class CourseAssignment
    {
        private int employeeNumber;
        private string courseNumber;
        private DateTime assignedDate;
        private int groupNumber;
        public int EmployeeNumber { get => employeeNumber; set => employeeNumber = value; }
        public string CourseNumber { get => courseNumber; set => courseNumber = value; }
        public DateTime AssignedDate { get => assignedDate; set => assignedDate = value; }
        public int GroupNumber { get => groupNumber; set => groupNumber = value; }

        public CourseAssignment()
        {
            this.employeeNumber = 0;
            this.courseNumber = string.Empty;
            this.assignedDate = DateTime.Now;
            this.groupNumber = 0;
        }

        public CourseAssignment(int employeeNumber, string courseNumber, DateTime assignedDate, int groupNumber)
        {
            this.employeeNumber = employeeNumber;
            this.courseNumber = courseNumber;
            this.assignedDate = assignedDate;
            this.groupNumber = groupNumber;
        }

        public static void AssignCourse(CourseAssignment courseAssign) => CourseAssignmentDB.AssignCourse(courseAssign);

        public static int GetNumberOfCourses(int employeeNumber) => CourseAssignmentDB.GetNumberOfCourses(employeeNumber);

        public static CourseAssignment CheckCourseAssigned(int teacher, string course) => CourseAssignmentDB.CheckCourseAssigned(teacher, course);
    }
}