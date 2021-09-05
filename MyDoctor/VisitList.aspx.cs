using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDoctor
{
    public partial class VisitList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"]==null)
            {
                Response.Redirect("~/Login");
            }
        }

        public String GetDoctor(int doctorId)
        {
            switch (doctorId)
            {
                case 1:
                    return "Jan Kowalski";
                case 2:
                    return "Janina Zientek";
                case 3:
                    return "Mirosław Baka";
                default:
                    return "---";
            }
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                int rowId = Convert.ToInt32(e.CommandArgument);
                String cs =
                ConfigurationManager.ConnectionStrings["edoctorConnectionString"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = "DELETE FROM visits WHERE id=" + rowId;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                    //odswieżam grid
                    //gridView.DataBind();
                    Response.Redirect("~/VisitList");

                }
            }
        }
    }
}