using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        string connectionString = @"Data Source=127.0.0.1;Initial Catalog=test-mh;User ID=sa;Password=Ahal1234!;";
        string select_query = @"SELECT s.ID,  s.name as [Name] , cr.course_name as [Courese Name], cr.course_instructor as [Instructor], cr.credit as [Course Credit], s.about as [About Student] FROM student s JOIN course cr ON s.course_id = cr.ID;";
        //string insert_query = @"INSERT INTO student (ID, name, age, about, course_id) VALUES ('"+int.Parse(TextBox1.Text)+"', '"+TextBox2.Text+"', '"+TextBox3.Text+"', '"+TextBox4.Text+"', '"+int.Parse(DropDownList1.SelectedValue)+"');";
        //string update_query = @"";
        //string delete_query = @"";
        //string insert_course_query = @"INSERT INTO course (ID, course_name, course_instructor, credit) VALUES (, '"+int.Parse(TextBox2.Text)+"', '"+int.Parse(TextBox3.Text)+"','"+int.Parse(DropDownList1.SelectedValue)+"';";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //loadData();
                BindGrid();
                
            }
        }

        protected void BindGrid()
        {
            Class1 load = new Class1();
            DataTable dt = load.LoadData();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void InsertStudent(object sender, EventArgs e)
        {
            int id = int.Parse(Request.Form["id"]);
            string name = Request.Form["name"];
            int age = int.Parse(Request.Form["age"]);
            string about = Request.Form["about"];
            int course_id = int.Parse(Request.Form["crs_id"]);

            Class1  save = new Class1();
            save.SaveData(id,name,age,about,course_id);
            
        }

        protected void UpdateStudent(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(@"UPDATE student set name = '"+ TextBox2.Text +"', age = '" + TextBox3.Text + "', about = '" + TextBox4.Text + "', course_id = '" + int.Parse(DropDownList1.SelectedValue) + "' WHERE ID = '" + int.Parse(TextBox1.Text) + "';", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            BindGrid();
        }

        protected void DeleteStudent(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(@"Delete from student WHERE ID = '" + int.Parse(TextBox1.Text) + "';", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            BindGrid();
        }

        //protected void loadData()
        //{
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    SqlCommand cmd = new SqlCommand(select_query, conn);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    //conn.Open();
        //    adapter.Fill(dt);
        //    //conn.Close();
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //}
    }
}
