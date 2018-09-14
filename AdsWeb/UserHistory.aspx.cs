using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdsCom;

namespace AdsWeb
{
    public partial class UserHistory : System.Web.UI.Page
    {
        int i = 1;
        Order o = new Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            grdCompleted.RowDataBound += new GridViewRowEventHandler(grdCompleted_RowDataBound);
            lblActivityLog.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblUser.Text = Session["USERNAME"].ToString();
            lblCurrentTime.Text = DateTime.Now.ToString();
            if (Page.IsPostBack) return;


            DateTime dd = DateTime.Now.AddDays(-6);
            ListItem li;
            drpViewDate.Controls.Clear();
            for (int i = 0; i <= 6; i++)
            {
                li = new ListItem();
                li.Text = dd.AddDays(i).ToString("MM/dd/yyyy");//ToShortDateString();
                li.Value = i.ToString();
                drpViewDate.Items.Add(li);

            }
            drpViewDate.SelectedItem.Text = DateTime.Now.ToString("MM/dd/yyyy");
            Completed();
        }

        void grdCompleted_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            Order o = (Order)e.Row.DataItem;

            Label lblSeriolNo = (Label)e.Row.FindControl("lblSeriolNo");
            lblSeriolNo.Text = i.ToString();
            i++;

            Label lblOrderId = (Label)e.Row.FindControl("lblOrderId");
            lblOrderId.Text = o.ORDER_ID.ToString();

            Label lblAllocated = (Label)e.Row.FindControl("lblAllocated");
            lblAllocated.Text = o.STATUS_ID.ToString();

            //Label lblAllocated = (Label)e.Row.FindControl("lblAllocated");
            //lblAllocated.Text = o.USER_ID.ToString();

        }


        private void Completed()
        {
            IList<Order> orders1 = new List<Order>();
            DateTime dd1 = Convert.ToDateTime(drpViewDate.SelectedItem.Text);
            orders1 = o.LoadByOrderDate(dd1, (Convert.ToInt32(Session["User_Id"])));
            grdCompleted.DataSource = orders1;
            grdCompleted.DataBind();
            lblCompleted.Text = orders1.Count().ToString();
        }
        protected void btnView_Click(object sender, EventArgs e)
        {
            Completed();
        }
    }
}