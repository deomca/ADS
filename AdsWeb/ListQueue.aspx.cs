using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdsCom;

namespace AdsWeb
{
    public partial class ListQueue : System.Web.UI.Page
    {
        int i = 1;
        Order o = new Order();
        bool chkTake = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            grdAds.RowDataBound += new GridViewRowEventHandler(grdAds_RowDataBound);
            grdAds.RowCommand += new GridViewCommandEventHandler(grdAds_RowCommand);
            grdAds.PageIndexChanging += new GridViewPageEventHandler(grdAds_PageIndexChanging);

            if (Page.IsPostBack) return;

            if (Request["UserId"].ToString() == "0" && Request["StatusId"].ToString() == "1")
            {
                lblQueue.Text = "InDesign(UnAllocated)";
                LoadOrder();
            }
            else if (Request["UserId"].ToString() == "x" && Request["StatusId"].ToString() == "1")
            {
                lblQueue.Text = "InDesign(Allocated)";
                LoadAllocatedOrder();

            }

            if (Request["UserId"].ToString() == "0" && Request["StatusId"].ToString() == "2")
            {
                lblQueue.Text = "InQA(UnAllocated)";
                LoadOrder();

            }
            else if (Request["UserId"].ToString() == "x" && Request["StatusId"].ToString() == "2")
            {
                lblQueue.Text = "InQA(Allocated)";
                LoadAllocatedOrder();
            }


            if (Request["UserId"].ToString() == "0" && Request["StatusId"].ToString() == "3")
            {
                lblQueue.Text = "InFinalQA(UnAllocated)";
                LoadOrder();

            }
            else if (Request["UserId"].ToString() == "x" && Request["StatusId"].ToString() == "3")
            {
                lblQueue.Text = "InFinalQA(Allocated)";
                LoadAllocatedOrder();

            }

            if (Request["UserId"].ToString() == "0" && Request["StatusId"].ToString() == "4")
            {
                lblQueue.Text = "InSubmission(UnAllocated)";
                LoadOrder();

            }
            else if (Request["UserId"].ToString() == "x" && Request["StatusId"].ToString() == "4")
            {
                lblQueue.Text = "InSubmission(Allocated)";
                LoadAllocatedOrder();

            }

            if (Request["UserId"].ToString() == "0" && Request["StatusId"].ToString() == "5")
            {
                lblQueue.Text = "OnHold(UnAllocated)";
                LoadOrder();

            }
            else if (Request["UserId"].ToString() == "x" && Request["StatusId"].ToString() == "5")
            {
                lblQueue.Text = "OnHold(Allocated)";
                LoadAllocatedOrder();

            }


            if (Request["UserId"] != null && Request["StatusId"] == null)
            {
                LoadByUserId(Convert.ToInt32(Session["USER_ID"]));
                lblQueue.Text = "MyAds";
                tdView.Visible = false;
                grdAds.Columns[9].Visible = false;
            }

        }

        private void LoadAllocatedOrder()
        {
            IList<Order> orders1 = new List<Order>();
            orders1 = AdsCom.Order.LoadByStatusId(Convert.ToInt32(Request["StatusId"]));
            grdAds.DataSource = orders1;
            grdAds.DataBind();
            lblNoofOrders.Text = orders1.Count().ToString();
        }

        private void LoadOrder()
        {
            IList<Order> orders1 = new List<Order>();
            orders1 = Order.LoadByStatusIdandUserId(Request["StatusId"].ToString(), Request["UserId"].ToString());
            grdAds.DataSource = orders1;
            grdAds.DataBind();
            lblNoofOrders.Text = orders1.Count().ToString();
        }

        void grdAds_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Save")
            {
                o = new Order();
                o.Load(Convert.ToInt32(e.CommandArgument));
                o.STATUS_ID = Convert.ToInt32(Request["StatusId"]);
                o.USER_ID = Convert.ToInt32(Session["USER_ID"]);

                o.Save();

                AdsCom.OrderHistory oh = new AdsCom.OrderHistory();
                oh.ORDER_ID = o.ORDER_ID;
                oh.USER_ID = Convert.ToInt32(Session["USER_ID"]);
                oh.USERALLOCATED = Convert.ToInt32(Session["USER_ID"]);
                oh.ORDER_STATUS = o.STATUS_ID;
                oh.DATE = DateTime.Now;
                //string strAction = string.Empty;
                //if (o.ACTION == 1)
                //    strAction = "Completed";
                //else if (o.ACTION == 2)
                //    strAction = "Hold";
                //else if (o.ACTION == 3)
                //    strAction = "Return";
                // strAction + " (" + o.ALBUM_RATING + ") " +
                oh.ADDITIONALINSTRUCTION = o.COMMENTS;

                oh.Save();

                AdsCom.UserHistory uh = new AdsCom.UserHistory();
                uh.Order_Id = o.ORDER_ID;
                uh.User_Id = Convert.ToInt32(Session["USER_ID"]);
                uh.Allocated_Date = DateTime.Now;
                uh.Submitted_Date = DateTime.MaxValue;
                uh.Totaltime = DateTime.MaxValue;
                uh.Save();

                Response.Redirect("ListQueue.aspx?Userid=" + o.USER_ID);
            }
        }

        void grdAds_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAds.PageIndex = e.NewPageIndex;
            reload();
        }

        void grdAds_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            Order o = (Order)e.Row.DataItem;
            Status s = new Status();
            int sts = o.STATUS_ID;
            s.Load(sts);

            IList<Order> orders = new List<Order>();
            orders = o.LoadByUserId(Convert.ToInt32(Session["USER_ID"]));

            Label lblAllocated = (Label)e.Row.FindControl("lblAllocated");
            User u = new User();
            int usr = o.USER_ID;
            u.Load(usr);
            if (usr == 0)
                lblAllocated.Text = "No One";

            else
                lblAllocated.Text = u.RealName;


            if (chkTake == false && orders.Count == 0)
            {
                e.Row.Cells[9].Visible = true;
                chkTake = true;
            }
            else
            {
                e.Row.Cells[9].Visible = false;
                User u1 = new User();
                u1.Load(Convert.ToInt32(Session["USER_ID"]));
                if (u1.STATUS_ID != 3)
                {
                    e.Row.Cells[10].Visible = false;

                    if (Request["UserId"].ToString() == "0")
                        e.Row.Cells[10].Visible = false;
                    else if (Request["UserId"].ToString() == "x" && (u1.RealName != lblAllocated.Text))
                        e.Row.Cells[10].Visible = false;
                    else if (u1.RealName == lblAllocated.Text)
                        e.Row.Cells[10].Visible = true;
                    else
                        e.Row.Cells[10].Visible = true;
                }


            }

            Label lblSeriolNo = (Label)e.Row.FindControl("lblSeriolNo");
            lblSeriolNo.Text = i.ToString();
            i++;

            Label lblOrderDate = (Label)e.Row.FindControl("lblOrderDate");
            lblOrderDate.Text = o.ORDER_DATE.ToString(("MM/dd/yyyy"));

            Label lblPriority = (Label)e.Row.FindControl("lblPriority");
            Priority pr = new Priority();
            int pri = o.PRIORITY;
            pr.Load(pri);
            if (pr.Priority_Name == "Regular")
            {
                lblPriority.ForeColor = System.Drawing.Color.Black;
                lblPriority.Text = pr.Priority_Name;
            }
            else
                lblPriority.ForeColor = System.Drawing.Color.Red;
            lblPriority.Text = pr.Priority_Name;

            Label lblStatus = (Label)e.Row.FindControl("lblStatus");

            lblStatus.Text = s.ORDER_STATUS;



            Label lblLastDesigner = (Label)e.Row.FindControl("lblLastDesigner");
            Label lblLastQA = (Label)e.Row.FindControl("lblLastQa");
            Change change = new Change();
            Change ch = change.LoadByOrderId(Convert.ToInt32(o.ORDER_ID));
            lblLastDesigner.Text = ch.Design_By_Name;
            lblLastQA.Text = ch.Qa_By_Name;

            IList<AdsCom.UserHistory> usrHis = AdsCom.UserHistory.LoadByOrderId(o.ORDER_ID);
            if (usrHis.Count > 0)
            {
                User usrs = new User();
                UserHistory uh = new UserHistory();
                int hisUserId = AdsCom.UserHistory.LoadByOrderId(o.ORDER_ID)[0].User_Id;
                usrs.Load(hisUserId);
                string name = usrs.RealName;

                Label lblLastComment = (Label)e.Row.FindControl("lblLastComment");
                string strAction = string.Empty;
                if (o.ACTION == 1)
                    strAction = "Completed";
                else if (o.ACTION == 2)
                    strAction = "Hold";
                else if (o.ACTION == 3)
                    strAction = "Return";

                lblLastComment.Text = strAction + " (" + o.ALBUM_RATING + ") " + o.COMMENTS + "  ( By " + name + ") ";
            }
            LinkButton hypTake = (LinkButton)e.Row.FindControl("hypTake");
            hypTake.CommandArgument = o.Id.ToString();
            //hypTake. = "ListQueue.aspx?StatusId=" + o.Status + "&UserId=" + Session["USER_ID"] + "";

            HyperLink hypView = (HyperLink)e.Row.FindControl("hypView");
            hypView.NavigateUrl = "ShowOrder.aspx?AID=" + o.Id + "&UserId=" + Session["USER_ID"] + "";
        }

        void reload()
        {
            IList<Order> orders = new List<Order>();
            orders = AdsCom.Order.FindAll();
            grdAds.DataSource = orders;
            grdAds.DataBind();
            lblNoofOrders.Text = orders.Count().ToString();
        }

        void LoadByUserId(int UserId)
        {
            IList<Order> orders = new List<Order>();
            orders = o.LoadByUserId(UserId);
            if (orders.Count == 0)
            {
                o = new Order();
                if (Request["UserId"].ToString() != "0")
                {
                    User u2 = new User();
                    u2.Load(Convert.ToInt32(Session["USER_ID"]));
                    if (u2.STATUS_ID == 2)
                    {

                        IList<Order> orders1 = new List<Order>();
                        orders1 = AdsCom.Order.FindAll();

                        int defOrderId = 0;
                        for (int i = 0; i < orders1.Count; i++)
                        {
                            if (orders1[i].USER_ID == 0)
                            {
                                defOrderId = orders1[i].Id;
                                break;
                            }
                        }

                        o.Load(defOrderId);

                        if (o.STATUS_ID == 2)
                        {
                            // o.STATUS_ID = Convert.ToInt32(Request["StatusId"]);
                            o.USER_ID = Convert.ToInt32(Session["USER_ID"]);

                            o.Save();

                            AdsCom.OrderHistory oh1 = new AdsCom.OrderHistory();

                            oh1.ORDER_ID = o.ORDER_ID;
                            oh1.USER_ID = Convert.ToInt32(Session["USER_ID"]);
                            oh1.USERALLOCATED = Convert.ToInt32(Session["USER_ID"]);
                            oh1.ORDER_STATUS = o.STATUS_ID;
                            oh1.DATE = DateTime.Now;

                            oh1.ADDITIONALINSTRUCTION = o.COMMENTS;

                            oh1.Save();
                            Response.Redirect("ListQueue.aspx?UserId=" + o.USER_ID);
                        }
                    }
                }


            }
            grdAds.DataSource = orders;
            grdAds.DataBind();
            lblNoofOrders.Text = orders.Count().ToString();

        }

        protected void lnkAllocate_Click(object sender, EventArgs e)
        {
            //IList<Order> orders1 = new List<Order>();
            //orders1 = AdsCom.Order.LoadByStatusId(Convert.ToInt32(Request["StatusId"]));
            //grdAds.DataSource = orders1;
            //grdAds.DataBind();
            //lblNoofOrders.Text = orders1.Count().ToString();
            LoadAllocatedOrder();
            Response.Redirect("ListQueue.aspx?StatusId=" + Request["StatusId"] + "&UserId=x");

        }
        protected void lnkUnAllocate_Click(object sender, EventArgs e)
        {
            //IList<Order> orders1 = new List<Order>();
            //orders1 = AdsCom.Order.LoadByStatusId(Convert.ToInt32(Request["StatusId"]));
            //grdAds.DataSource = orders1;
            //grdAds.DataBind();
            //lblNoofOrders.Text = orders1.Count().ToString();
            LoadAllocatedOrder();
            Response.Redirect("ListQueue.aspx?StatusId=" + Request["StatusId"] + "&UserId=0");
        }

    }
}