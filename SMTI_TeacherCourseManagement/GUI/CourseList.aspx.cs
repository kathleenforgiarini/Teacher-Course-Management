using SMTI_TeacherCourseManagement.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SMTI_TeacherCourseManagement.GUI
{
    public partial class CourseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null || Session["id"].ToString() == "4444")
            {
                Response.Redirect("Login.aspx");
            }

            lblName.Text = "Welcome " + Session["fullname"].ToString();
            int teacherId = Convert.ToInt32(Session["id"].ToString());
            try
            {
                DataTable courses = Course.GetAllCoursesByTeacher(teacherId);
                gridViewAssignedCourses.DataSource = courses;
                gridViewAssignedCourses.DataBind();
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