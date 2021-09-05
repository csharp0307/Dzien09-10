using MyDoctor.App_Code;
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
    public partial class RegisterVisit2 : System.Web.UI.Page
    {
        VisitData data = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] == null)
            {
                Response.Redirect("~/Login");
            }

            try
            {
                data = (VisitData)Session["RegForm"];
                lblInfo.Text = $"{data.FirstName} {data.LastName}";
            } catch (Exception exc)
            {
                Response.Redirect("~/RegisterVisit1");
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            String filename = null;
            bool isOK = true;

            // obsługa uploadu pliku
            if (fuImage.HasFile)
            {
                if (fuImage.PostedFile.ContentType.Equals("image/png"))
                {
                    if (fuImage.PostedFile.ContentLength<500_000)
                    {
                        //właściwy upload
                        filename =  Guid.NewGuid().ToString("N") + "-" + fuImage.FileName;
                        fuImage.SaveAs(Server.MapPath("~/Uploads/") + filename);
                    }
                    else
                    {
                        lblResult.Text = "Za duży plik";
                        isOK = false;
                    }
                } else
                {
                    lblResult.Text = "Niewłaściwy typ pliku";
                    isOK = false;
                }
            }

            if (isOK)
            {
                // realizacja zapisu do bazy danych
                String cs =
                ConfigurationManager.ConnectionStrings["edoctorConnectionString"].ConnectionString;
                using (MySqlConnection conn = new MySqlConnection(cs))
                {
                    conn.Open();
                    String sql = @"
                        INSERT INTO visits
                        (fname, lname, email, pesel, doctor, visit_date,  descr, image, card)
                        VALUES
                        (@fname, @lname, @email, @pesel, @doctor, @visit_date, @descr, @image, @card)
                    ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@fname", data.FirstName);
                    cmd.Parameters.AddWithValue("@lname", data.LastName);
                    cmd.Parameters.AddWithValue("@email", data.Email);
                    cmd.Parameters.AddWithValue("@pesel", data.PESEL);
                    cmd.Parameters.AddWithValue("@doctor", data.DoctorId);
                    cmd.Parameters.AddWithValue("@visit_date", data.DateVisit);
                    cmd.Parameters.AddWithValue("@descr", tbDescr.Text);
                    cmd.Parameters.AddWithValue("@image", filename);
                    cmd.Parameters.AddWithValue("@card", data.CardNumber);

                    cmd.ExecuteNonQuery();

                    Session.Remove("RegForm");
                    Response.Redirect("~/VisitList");
                }
            }
        }
    }
}