using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMTI_TeacherCourseManagement.VALIDATION;
using System.Windows.Forms;
using SMTI_TeacherCourseManagement.BLL;

namespace SMTI_TeacherCourseManagement.GUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string type = radioBtnLoginAs.SelectedValue.ToString();
            string id = txtId.Text.Trim();
            string password = txtPassword.Text.Trim();

            switch (type)
            {
                case "Coordinator":
                    if (!Validator.IsValidId(id))
                    {
                        MessageBox.Show("Invalid coordinator ID! \nPlease enter another ID", "Invalid coordinator ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtId.Text = "";
                        txtId.Focus();
                        return;
                    }
                    int coordinatorId = Convert.ToInt32(id);
                    Employee coordinator = Employee.SearchCoordinator(coordinatorId);
                    User user = BLL.User.SearchUser(coordinatorId, password);

                    if (user == null || coordinator == null)
                    {
                        MessageBox.Show("Invalid credencials for coordinator!", "Invalid crendencials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtId.Text = "";
                        txtPassword.Text = "";
                        txtId.Focus();
                        return;
                    }

                    Session["id"] = coordinator.EmployeeNumber.ToString();
                    Session["fullname"] = coordinator.FName.ToString() + " " + coordinator.LName.ToString();

                    if (Page.IsValid)
                    {
                        Response.Redirect("CourseAssignments.aspx");
                    }

                    break;

                case "Teacher":
                    if (!Validator.IsValidId(id))
                    {
                        MessageBox.Show("Invalid teacher ID! \nPlease enter another ID", "Invalid teacher ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtId.Text = "";
                        txtId.Focus();
                        return;
                    }
                    int teacherId = Convert.ToInt32(id);
                    Employee teacher = Employee.SearchTeacher(teacherId);
                    User user_teacher = BLL.User.SearchUser(teacherId, password);

                    if (user_teacher == null || teacher == null)
                    {
                        MessageBox.Show("Invalid credencials for teacher!", "Invalid crendencials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtId.Text = "";
                        txtPassword.Text = "";
                        txtId.Focus();
                        return;
                    }

                    Session["id"] = teacher.EmployeeNumber.ToString();
                    Session["fullname"] = teacher.FName.ToString() + " " + teacher.LName.ToString();

                    if (Page.IsValid)
                    {
                        Response.Redirect("CourseList.aspx");
                    }

                    break;

                default:
                    break;
            }

        }
    }
}