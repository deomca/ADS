using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdsCom;

namespace AdsWeb
{
    public partial class ChangePassword1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            User u = new User();
            if (Session["USER_ID"] != null)
                u.Load(Convert.ToInt32(Session["USER_ID"]));

            u.Password = txtNewPass.Text;

            u.Save();

            tblPassword.Visible = false;
            lblMessage.Text = "Successfully Saved";

        }
    }
}