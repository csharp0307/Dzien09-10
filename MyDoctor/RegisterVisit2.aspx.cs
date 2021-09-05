using MyDoctor.App_Code;
using System;
using System.Collections.Generic;
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
            String filename;
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
            }
        }
    }
}