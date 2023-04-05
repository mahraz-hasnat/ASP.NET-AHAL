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
        string select_query = "SELECT s.name as [Name] , cr.course_name as [Courese Name], cr.course_instructor as [Instructor], cr.credit as [Course Credit], s.about as [About Student]\r\nFROM student s\r\nJOIN course cr ON s.course_id = cr.ID;";
        string insert_query = "";
        string update_query = "";
        string delete_query = "";

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
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(insert_query, connection);
            connection.Open();
            connection.Close();

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
    }
}
