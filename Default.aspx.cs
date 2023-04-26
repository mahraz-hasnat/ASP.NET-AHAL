using AHAL.StudentCourse.BO;
using System;
using System.Data;
using System.Web.UI;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        string _selectStudent = @"SELECT s.ID,  s.name as [Name] , cr.course_name as [Courese Name], cr.course_instructor as [Instructor], cr.credit as [Course Credit], s.about as [About Student] FROM student s JOIN course cr ON s.course_id = cr.ID;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                BindGrid();                
            }
        }

        protected void BindGrid()
        {
            Class1 load = new Class1();
            DataTable dt = load.LoadData(_selectStudent);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void InsertStudent(object sender, EventArgs e)
        {
            Student student = new Student();
            if (student == null)
            {
                student = new Student();
            }

            student.name = textName.Text;
            student.age = int.Parse(textAge.Text);
            student.about = textAbout.Text;
            student.course_id = int.Parse(crs_list.SelectedValue); //confusion on : student.cs -> course_id ,course
            student.Save();
            BindGrid();
        }

        protected void UpdateStudent(object sender, EventArgs e)
        {
            Student student = new Student();
            if (textID.Text != "")
            {
                student.ID = int.Parse(textID.Text);
                student = student.GetData();
            }

            if (student == null)
            {
                string message = "Enter an available student id to update";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + message + "');", true);
            }

            student.name = textName.Text;
            student.age = int.Parse(textAge.Text);
            student.about = textAbout.Text;
            student.course_id = int.Parse(crs_list.SelectedValue);
            student.Save();
            BindGrid();
        }

        protected void DeleteStudent(object sender, EventArgs e)
        {
            Student std = new Student(); 
            std.ID = int.Parse(textID.Text);
            std.Delete();
            BindGrid();
        }
    }
}

