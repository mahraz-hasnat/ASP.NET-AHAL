using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public class Class1
    {
        string _connectionString = @"Data Source=127.0.0.1;Initial Catalog=test-mh;User ID=sa;Password=Ahal1234!;";
        string _selectQuery = @"SELECT s.ID,  s.name as [Name] , cr.course_name as [Courese Name], cr.course_instructor as [Instructor], cr.credit as [Course Credit], s.about as [About Student] FROM student s JOIN course cr ON s.course_id = cr.ID;";
        string _saveData = @"INSERT INTO student (ID, name, age, about, course_id) VALUES (@ID, @Name, @Age, @About, @Course_id);";
        string _updateStudent = @"UPDATE students SET age = 20, grade = 'A' WHERE id = 123;";

        public void connect(string _query)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(_query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable LoadData()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(_selectQuery, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //conn.Open();
            adapter.Fill(dt);
            //conn.Close();
            return dt;
        }

        public void SaveData(int id, string name, int age, string about, int course_id)
        {
            connect(_saveData);
            
            
            LoadData();
        }

        public void UpdateStudent()
        { 
            connect(null);
        }
    }
}
