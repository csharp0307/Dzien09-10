using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDoctor
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string HashPass(string password)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        String cs = 
            ConfigurationManager.ConnectionStrings["edoctorConnectionString"].ConnectionString;
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //sprawdzanie loginu/hasła
            String user = tbLogin.Text.Trim();
            String pass = tbPassword.Text.Trim();
            if (String.IsNullOrEmpty(user) || String.IsNullOrEmpty(pass))
            {
                lblResult.Text = "Podaj nazwę usera i hasło";
                return;
            }

            String hashPass = HashPass(pass);
            String sql = "SELECT * FROM users WHERE username=@user AND password=@pass  ";
            using (MySqlConnection conn = new MySqlConnection(cs))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = hashPass;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count==0)
                {
                    lblResult.Text = "Nieznany user/hasło";
                } else
                {
                    Session["auth_user"] = dt.Rows[0]["username"];
                    Response.Redirect("~/VisitList");
                }

            }
        }
    }
}