using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication2
{
    public partial class About : Page
    {
        string _selectCourse = @"SELECT * FROM course;";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BindGrid()
        {
            Class1 load = new Class1();
            DataTable dt = load.LoadData(_selectCourse);
            grid_course.DataSource = dt;
            grid_course.DataBind();
        }

        protected void show_course_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void insert_course_Click(object sender, EventArgs e)
        {
            int crsID = int.Parse(text_crsID.Text);
            string crsName = text_crsName.Text;
            string crsInstructor = text_crsInstructor.Text;
            int crsCredit = int.Parse(text_credit.Text);
            Class1 course = new Class1();
            course.InsertCourse(crsID, crsName, crsInstructor, crsCredit);
            BindGrid();
        }
    }
}
