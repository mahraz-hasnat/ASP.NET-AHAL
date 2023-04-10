using System;
using System.Data;
using System.Web.UI;

namespace WebApplication2
{
    public partial class _Default : Page
    {       
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
            DataTable dt = load.LoadData();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void InsertStudent(object sender, EventArgs e)
        {
            int ID = int.Parse(id.Text);
            string Name = name.Text;
            int Age = int.Parse(age.Text);
            string About = about.Text;
            int Course_id = int.Parse(crs_list.SelectedValue);

            Class1  student = new Class1();
            student.SaveData(ID,Name,Age,About,Course_id);
            BindGrid();
        }

        protected void UpdateStudent(object sender, EventArgs e)
        {
            int ID = int.Parse(id.Text);
            string Name = name.Text;
            int Age = int.Parse(age.Text);
            string About = about.Text;
            int Course_id = int.Parse(crs_list.SelectedValue);

            Class1 student = new Class1();
            student.UpdateStudent(ID, Name, Age, About, Course_id);
            BindGrid();
        }

        protected void DeleteStudent(object sender, EventArgs e)
        {
            int ID = int.Parse(id.Text);
            Class1 student = new Class1();
            student.DeleteStudent(ID);   
            BindGrid();
        }
    }
}
