using SMTI_TeacherCourseManagement.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SMTI_TeacherCourseManagement.GUI
{
    public partial class CourseAssignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null || Session["id"].ToString() != "4444")
            {
                Response.Redirect("Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                lblName.Text = "Welcome " + Session["fullname"].ToString();
                foreach (var t in Employee.GetTeacherList())
                {
                    DropDownListTeacher.Items.Add(t.EmployeeNumber + ", " + t.FName + " " + t.LName);

                }
                foreach (var c in Course.GetCourseList())
                {
                    DropDownListCourse.Items.Add(c.CourseNumber + ", " + c.CourseTitle + " - " + c.TotalHour);
                }
                foreach (var g in Group.GetGroupList())
                {
                    DropDownListGroup.Items.Add(g.GroupNumber + ", " + g.Description);
                }

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;
            txtAssignedDate.Text = selectedDate.ToShortDateString();
        }

        protected void btnListCourses_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedTeacher = DropDownListTeacher.SelectedValue.ToString().Trim();
                string[] fields = selectedTeacher.Split(',');
                int tId = Convert.ToInt32(fields[0]);
                GridView1.DataSource = Course.GetAllCoursesByTeacher(tId);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wront", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnAssignCourse_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedTeacher = DropDownListTeacher.SelectedValue.ToString().Trim();
                string[] fieldsTeacher = selectedTeacher.Split(',');
                int tId = Convert.ToInt32(fieldsTeacher[0]);
                string selectedCourse = DropDownListCourse.SelectedValue.ToString().Trim();
                string[] fieldsCourse = selectedCourse.Split(',');
                string courseId = fieldsCourse[0];
                string selectedGroup = DropDownListGroup.SelectedValue.ToString().Trim();
                string[] fieldsGroup = selectedGroup.Split(',');
                int groupId = Convert.ToInt32(fieldsGroup[0]);

                CourseAssignment courseAssignment = CourseAssignment.CheckCourseAssigned(tId, courseId);

                if (txtAssignedDate.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please select a date from the calendar", "Date is empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime assignedDate = DateTime.Parse(txtAssignedDate.Text);

                if (CourseAssignment.GetNumberOfCourses(tId) >= 3)
                {
                    MessageBox.Show("You can not assign more courses to this teacher.\nMaximum 3 courses.", "Maximum reached", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (courseAssignment != null)
                {
                    MessageBox.Show("This course is already assigned to this teacher.", "Course already assigned to this teacher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CourseAssignment courseAssign = new CourseAssignment(tId, courseId, assignedDate, groupId);
                CourseAssignment.AssignCourse(courseAssign);

                MessageBox.Show("Course Assigned!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridView1.DataSource = Course.GetAllCoursesByTeacher(tId);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wront", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Session["fullname"] = null;

            if (Page.IsValid)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}