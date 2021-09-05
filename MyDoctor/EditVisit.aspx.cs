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
    public partial class EditVisit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int recordId = Convert.ToInt32(Request.Params["id"]);
                tbHiddenId.Value = recordId.ToString();
            } catch (Exception exc)
            {
                Response.Redirect("~/VisitList");
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int status = Convert.ToInt32(ddlStatus.SelectedValue);
            if (status == 0)
            {
                lblResult.Text = "Wybierz odpowiedni status";
            }
            else
            {
                String sql = $"UPDATE visits SET status={status} WHERE id={Convert.ToInt32(tbHiddenId.Value)}";
                String cs =
                ConfigurationManager.ConnectionStrings["edoctorConnectionString"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/VisitList"); 
                }
            }
        }
    }
}