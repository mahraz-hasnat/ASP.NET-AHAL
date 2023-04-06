using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspWebapp2
{
    public partial class _Default : Page
    {
        string connectionString = @"Data Source= 127.0.0.1; Initial Catalog= test-mh; User=sa; Password=Ahal1234!";
        string select_query = @"SELECT s.name as [Name] , cr.course_name as [Courese Name], cr.course_instructor as [Instructor], cr.credit as [Course Credit], s.about as [About Student] FROM student s JOIN course cr ON s.course_id = cr.ID;";
        string insert_query = @"INSERT INTO student (ID, name, age, about, course_id) VALUES (@ID, @Name, @Age, @About, @Course_id);";
        string update_query = @"";
        string delete_query = @"";
        string insert_course_query = @"INSERT INTO course (ID, course_name, course_instructor, credit) VALUES (@ID, @Course_name, @Instructor, @Credit);";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void show_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(select_query, connection);
            
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            connection.Close();
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int id = int.Parse(Request.Form["id"]);
                string name = Request.Form["name"];
                int age = int.Parse(Request.Form["age"]);
                string about = Request.Form["about"];
                int course_id = int.Parse(Request.Form["id0"]);

                SqlConnection connection = new SqlConnection(connectionString);
                
                SqlCommand command = new SqlCommand(insert_query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@About", about);
                command.Parameters.AddWithValue("@Course_id", course_id);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(update_query, connection);
            connection.Open();

            connection.Close();
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(delete_query, connection);
            connection.Open();
            connection.Close();
        }

        protected void insert_course_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int cid = int.Parse(Request.Form["cid"]);
                string cname = Request.Form["cname"];
                string instructor = Request.Form["instructor"];
                int credit = int.Parse(Request.Form["credit"]);

                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand(insert_course_query, connection);
                connection.Open();
                command.Parameters.AddWithValue("@ID", cid);
                command.Parameters.AddWithValue("@Course_name", cname);
                command.Parameters.AddWithValue("@Instructor", instructor);
                command.Parameters.AddWithValue("@Credit", credit);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
        } 
    }
}
