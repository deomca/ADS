using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using AdsCom;

namespace AdsWeb
{
    public partial class Login : System.Web.UI.Page
    {
        User u = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLoginId.Focus();
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            AdsCom.User.Authenticate(txtLoginId.Text, txtPassword.Text, u);

            if (u.Id > 0)
            {
                Session["USERNAME"] = u.RealName;
                Session["USER_ID"] = u.Id;
                Session["StatusId"] = u.STATUS_ID;

               
                Response.Redirect("ListQueue.aspx?UserId=" + Session["USER_ID"]);
            }
            else
            {
                lblMessage.Text = "LoginId or Password is Incorrect.Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

