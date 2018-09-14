using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdsCom;

namespace AdsWeb
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridOrderHistory.RowDataBound += new GridViewRowEventHandler(GridOrderHistory_RowDataBound);
            if (Page.IsPostBack) return;
            lblCurrentTime.Text = DateTime.Now.ToString();
            //lblOrderNo.Text = Convert.ToInt32(Request["ORDERID"]);
            LoadOrderHistory();
        }

        void GridOrderHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            AdsCom.OrderHistory oh = e.Row.DataItem as AdsCom.OrderHistory;
            Label lblBy = (Label)e.Row.FindControl("lblBy");
            AdsCom.User usr = new AdsCom.User();
            int str = oh.USER_ID;
            usr.Load(str);
            lblBy.Text = usr.RealName;
            Label lblOrderDate = (Label)e.Row.FindControl("lblOrderDate");
            lblOrderDate.Text = oh.DATE.ToString("MM/dd/yyyy");  // oh.DATE.ToString(("MM/dd/yyyy")); 

            Label lblAllocation = (Label)e.Row.FindControl("lblAllocation");
            int str1 = oh.USERALLOCATED;
            usr.Load(str1);
            lblAllocation.Text = usr.RealName;
            Label lblOrderStatus = (Label)e.Row.FindControl("lblOrderStatus");
            AdsCom.Status sts = new AdsCom.Status();
            //int str3 = oh.ORDER_STATUS;
            sts.Load(oh.ORDER_ID);
            lblOrderStatus.Text = sts.ORDER_STATUS;
        }

        public void LoadOrderHistory()
        {
            int OrderId = Convert.ToInt32(Request["ORDERID"]);
            lblOrderNo.Text = OrderId.ToString();
            GridOrderHistory.DataSource = AdsCom.OrderHistory.LoadByOrderId(OrderId);
            GridOrderHistory.DataBind();

        }
    }
}