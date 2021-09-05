using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyDoctor
{
    public partial class RegisterVisit1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbVIP_CheckedChanged(object sender, EventArgs e)
        {
            tbVIPNumber.Visible = cbVIP.Checked;
            if (!cbVIP.Checked)
            {
                tbVIPNumber.Text = String.Empty;
            }
        }

        protected void Validate_PESEL(object source, ServerValidateEventArgs args)
        {
            //if (args.Value.Length == 11)
            //    args.IsValid = true;
            //else
            //    args.IsValid = false;

            args.IsValid = (args.Value.Length == 11);
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (args.Value.Length == 11);
        }
    }
}