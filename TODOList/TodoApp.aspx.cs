using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System.Xml.Linq;
using System.Configuration;

namespace TODOList
{
    public partial class TodoApp : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UserData.mdf;Integrated Security=True");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            if (!IsPostBack)
            {
                if (Session["email"] != null)
                {
                    BindTasksToRepeater();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }

        protected void addTask(object sender, EventArgs e)
        {
            string task = InputTask.Text;
            InsertTaskIntoDatabase(task);
            BindTasksToRepeater(); // Rebind the repeater after insertion
            InputTask.Text = ""; // Clear the input field
        }

        private void InsertTaskIntoDatabase(string taskText)
        {
            string email = Session["email"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO usertasks (email, task) VALUES (@Email, @Task)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Task", taskText);

                cmd.ExecuteNonQuery();
            }
        }

        private DataTable GetTasksFromDatabase()
        {
            string email = Session["email"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT task FROM usertasks WHERE email = @Email";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable tasksTable = new DataTable();
                adapter.Fill(tasksTable);

                return tasksTable;
            }
        }

        private void BindTasksToRepeater()
        {
            DataTable tasksTable = GetTasksFromDatabase();
            TaskRepeater.DataSource = tasksTable;
            TaskRepeater.DataBind();
        }

        protected void deleteTask(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                string taskText = e.CommandArgument.ToString();
                DeleteTaskFromDatabase(taskText);
                BindTasksToRepeater(); 
            }
        }


        private void DeleteTaskFromDatabase(string taskText)
        {
            string email = Session["email"].ToString();
            string connectionString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM usertasks WHERE email = @Email AND task = @Task";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Task", taskText);

                cmd.ExecuteNonQuery();
            }
        }

    }
    
}