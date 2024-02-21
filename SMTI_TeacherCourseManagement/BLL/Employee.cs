using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SMTI_TeacherCourseManagement.DAL;

namespace SMTI_TeacherCourseManagement.BLL
{
    public class Employee
    {
        private int employeeNumber;
        private string fName;
        private string lName;
        private string jobTitle;

        public Employee()
        {
            employeeNumber = 0;
            fName = string.Empty;
            lName = string.Empty;
            jobTitle = string.Empty;
        }

        public Employee(int id, string fName, string lName, string jobTitle)
        {
            this.employeeNumber = id;
            this.fName = fName;
            this.lName = lName;
            this.jobTitle = jobTitle;
        }


        public int EmployeeNumber { get => employeeNumber; set => employeeNumber = value; }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        public static Employee SearchTeacher(int id) => EmployeeDB.SearchTeacher(id);
        public static Employee SearchCoordinator(int id) => EmployeeDB.SearchCoordinator(id);

        public static List<Employee> GetTeacherList() => EmployeeDB.GetTeacherList();
    }
}