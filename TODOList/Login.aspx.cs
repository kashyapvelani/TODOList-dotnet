using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TODOList
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UserData.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            { con.Close(); }
            con.Open();
        }

        protected void TODOLogin(object sender, EventArgs e)
        {
            string email = Email.Text;
            string pwd = Password.Text;
            


            SqlCommand cmd = new SqlCommand("select * from userdata where email = @email and password = @pwd", con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pwd", pwd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "userdata");

            if (ds.Tables["userdata"].Rows.Count != 0)
            {
                Session["name"] = ds.Tables["userdata"].Rows[0]["name"].ToString();
                Session["email"] = Email.Text;
                Response.Redirect("TodoApp.aspx");
            }
            else {
                Email.Text = "";
                Password.Text = "";
            }



            }
        }
}