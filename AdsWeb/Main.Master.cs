using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdsCom;

namespace AdsWeb
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           reload();          

           
        }


        void reload()
        {
            if (Session["USERNAME"] != null && Session["StatusId"] != null)
            {
                    Status sts = new Status();
                    User usr = new User();
                    usr.Load(Convert.ToInt32(Session["USER_ID"]));
                    sts.Load(usr.STATUS_ID);

                //    Label lblSession = (Label)Master.FindControl("lblsession");
                //    if (lblSession != null)
                //    {
                //        lblSession.Text = Session["USERNAME"].ToString() + "(" + sts.ORDER_STATUS + ")";
                //    }

                //}


                    lblsession.Text = Session["USERNAME"].ToString() + "(" + sts.ORDER_STATUS + ")";
                    lblsession.ForeColor = System.Drawing.Color.Maroon;


            }
            else
                Response.Redirect("Logout.aspx");

            IList<Order> orders = new List<Order>();
            orders = AdsCom.Order.FindAll();
           lblOrders.Text = orders.Count().ToString();
        }
        protected void lnkMyAds_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListQueue.aspx?UserId=" + Session["USER_ID"]);
        }
        protected void lnlBtnInQa_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListQueue.aspx?StatusId=2&UserId=0");
        }
        protected void lnkBtnInDesign_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListQueue.aspx?StatusId=1&UserId=0");
        }
        protected void lnlBtnFinalQa_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListQueue.aspx?StatusId=3&UserId=0");

        }
        protected void lnkBtnInSubmission_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListQueue.aspx?StatusId=4&UserId=0");
        }

        protected void lnkBtnONHold_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListQueue.aspx?StatusId=5&UserId=0");
        }
        protected void lnkChangePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
        protected void lnkActivityLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserHistory.aspx");
        }
        protected void btnSearch_Click1(object sender, ImageClickEventArgs e)
        {
            string id = txtId.Text.Trim();
            int OrderId = Convert.ToInt32(id);
            if (!string.IsNullOrEmpty(id))
            {
                Order o = new Order();
                IList<Order> order = new List<Order>();
                order = o.LoadByOrderId(OrderId);
                Response.Redirect("ListQueue.aspx?OrderId= " + o.ORDER_ID);
            }


        }
    }
}
