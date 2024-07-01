using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TODOList
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UserData.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

        }

        protected void TODORegister(object sender, EventArgs e)
        {
            string name = Name.Text;
            string email = Email.Text;
            string pwd = Password.Text;
            string cpwd = CPassword.Text;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into userdata values('" + name + "','" + email + "','"+ pwd + "')";
            if (cpwd.Equals(pwd))
            {
                cmd.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
            } 
            else
            {
                Name.Text = "";
                Email.Text = "";
                Password.Text = "";
                CPassword.Text = "";
            }
        }
    }
}