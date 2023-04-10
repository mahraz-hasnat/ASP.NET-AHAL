using System.Data.SqlClient;
using System.Data;

namespace WebApplication2
{
    public class Class1
    {
        string _connectionString = @"Data Source=127.0.0.1;Initial Catalog=test-mh;User ID=sa;Password=Ahal1234!;";
        string _selectQuery = @"SELECT s.ID,  s.name as [Name] , cr.course_name as [Courese Name], cr.course_instructor as [Instructor], cr.credit as [Course Credit], s.about as [About Student] FROM student s JOIN course cr ON s.course_id = cr.ID;";
        string _saveData = @"INSERT INTO student (ID, name, age, about, course_id) VALUES (@ID, @Name, @Age, @About, @Course_id);";
        string _updateStudent = @"UPDATE student SET name=@Name, age=@Age, about=@About, course_id=@Course_id WHERE ID = @ID;";
        string _deleteStudent = @"DELETE FROM student WHERE ID = @ID;";

        public DataTable LoadData()
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(_selectQuery, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();           
            adapter.Fill(dt);
            return dt;
        }

        public void SaveData(int id, string name, int age, string about, int course_id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(_saveData, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@About", about);
            cmd.Parameters.AddWithValue("@Course_id", course_id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStudent(int id, string name, int age, string about, int course_id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(_updateStudent, con);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@About", about);
            cmd.Parameters.AddWithValue("@Course_id", course_id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteStudent(int id)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(_deleteStudent, con);
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

