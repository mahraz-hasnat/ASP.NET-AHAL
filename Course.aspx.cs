
using AHS.Core.Framework;
using AHS.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using AHAL.StudentCourse.BO;

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
            //int crsID = int.Parse(text_crsID.Text);
            //string crsName = text_crsName.Text;
            //string crsInstructor = text_crsInstructor.Text;
            //int crsCredit = int.Parse(text_credit.Text);
            Course course = new Course();
            if(text_crsID.Text != "")
            {
                course.ID = int.Parse(text_crsID.Text);
                course = course.GetData();
            }
            if (course == null)
            {
                course = new Course();
            }

            course.course_instructor = text_crsInstructor.Text;
            course.course_name = text_crsName.Text;
            course.credit = int.Parse(text_credit.Text);
            course.Save();
            BindGrid();
        }

        protected void delete_course_Click(object sender, EventArgs e)
        {
            //int crsID = int.Parse(text_crsID.Text);
            Course course = new Course();
            course.ID = int.Parse(text_crsID.Text);
            course.Delete();
            BindGrid();
        }
    }
}
