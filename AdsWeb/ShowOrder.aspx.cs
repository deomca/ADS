using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AdsCom;
using System.Text.RegularExpressions;

namespace AdsWeb
{
    public partial class ShowOrder : System.Web.UI.Page
    {
        User u = new User();
        SqlCommand com;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        Order o = new Order();
        int orderid;
        int i = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            grdAdditionalIns.RowDataBound += new GridViewRowEventHandler(grdAdditionalIns_RowDataBound);
            GridUserHistory.RowDataBound += new GridViewRowEventHandler(GridUserHistory_RowDataBound);
            if (Page.IsPostBack) return;
            PopulateUser();
            u = new User();
            u.Load(Convert.ToInt32(Session["USER_ID"]));
            if (u.STATUS_ID == 3)
            {
                spnRating.Visible = true;
                drpRating.Visible = true;
                btnSubmitAdmin.Visible = true;
            }
            else if (u.STATUS_ID == 2)
            {
                spnRating.Visible = true;
                drpRating.Visible = true;
                btnSubmitAdmin.Visible = false;
            }
            else
            {
                spnRating.Visible = false;
                drpRating.Visible = false;
                btnSubmitAdmin.Visible = false;
            }

            if (Request["AID"] != null)
            {

                o.Load(Convert.ToInt32(Request["Aid"]));
                orderid = o.ORDER_ID;
                lblOrderId.Text = o.ORDER_ID.ToString();
                txtEventId.Text = o.EVENT_ID.ToString();
                lblStudioId.Text = o.GRAPHER_ID;
                txtFolderName.Text = o.FOLDER_NAME;
                txtPages.Text = o.PAGES.ToString();
                drpBind.SelectedValue = o.ALBUM_TYPE.ToString();
                drpStyle.SelectedValue = o.ALBUM_STYLE.ToString();
                drpSize.SelectedValue = o.ALBUM_SIZE.ToString();
                drpUserId.SelectedValue = o.USER_ID.ToString();
                lblInstruction.Text = o.SPECIAL_INSTRUCTIONS;
                lblOriginalId.Text = o.ORIGINAL_ALBUM_ID.ToString();
                lblImageList.Text = o.IMAGE_LIST;
                txtAlbumId.Text = o.ALBUM_ID.ToString();
                rbPriortiy.SelectedValue = o.PRIORITY.ToString();
                txtAlbumName.Text = o.ALBUM_NAME;
                txtImages.Text = o.IMAGES.ToString();

                drpSubmitAs.SelectedValue = "1";

                drpRating.SelectedValue = "0";
                Change change = new Change();
                Change ch = change.LoadByOrderId(Convert.ToInt32(o.ORDER_ID));
                lblLastDesigner.Text = ch.Design_By_Name;
                lblLastQa.Text = ch.Qa_By_Name;

                IList<AdsCom.UserHistory> usrHis = AdsCom.UserHistory.LoadByOrderId(o.ORDER_ID);
                if (usrHis.Count > 0)
                {
                    User usr = new User();
                    UserHistory uh = new UserHistory();
                    //UserHistory u = uh.LoadByUserId(Convert.ToInt32(Request["UserId"]));
                    //UserHistory u = uh.LoadByUserId(Convert.ToInt32(Request["UserId"]));

                    //int str = uh.User_Id;
                    //usr.Load(str);
                    //string history = AdsCom.UserHistory.LoadByOrderId(o.ORDER_ID)[0].Comments.ToString();
                    int hisUserId = usrHis[0].User_Id;
                    usr.Load(hisUserId);
                    string strAction = string.Empty;
                    if (o.ACTION == 1)
                        strAction = "Completed";
                    else if (o.ACTION == 2)
                        strAction = "Hold";
                    else if (o.ACTION == 3)
                        strAction = "Return";
                    lblLastComment.Text = strAction + " (" + o.ALBUM_RATING + ") " + o.COMMENTS + "  ( By " + usr.RealName + ") ";
                }



                drpSubmitTo.SelectedValue = o.STATUS_ID.ToString();
                drpCurrentStatusId.SelectedValue = o.STATUS_ID.ToString();

                LoadAminInstruction();
                LoadUserHistory();
                hypGetHistory.Attributes.Add("OnClick", "popwinHistory('" + o.ORDER_ID + "');");
            }
        }

        void GridUserHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            AdsCom.UserHistory uh = e.Row.DataItem as AdsCom.UserHistory;
            Label lblBy = (Label)e.Row.FindControl("lblBy");
            User usr = new User();
            int str = uh.User_Id;
            usr.Load(str);
            lblBy.Text = usr.RealName;
            //lblUserBy.Text = ins.USER_ID.ToString();
            Label lblCommentDate = (Label)e.Row.FindControl("lblCommentDate");
            lblCommentDate.Text = uh.Allocated_Date.ToString("MM/dd/yyyy");  // oh.DATE.ToString(("MM/dd/yyyy")); 
            LinkButton hypGetHistory = (LinkButton)e.Row.FindControl("hypGetHistory");
            //hypGetHistory.CommandArgument = uh.Id;

        }
        private void LoadUserHistory()
        {
            int OrderId = o.ORDER_ID;
            GridUserHistory.DataSource = AdsCom.UserHistory.LoadByOrderId(OrderId);
            GridUserHistory.DataBind();

        }

        private void LoadAminInstruction()
        {
            //IList<AdsCom.Instructions> instructions = new List<AdsCom.Instructions>();

            int OrderId = o.ORDER_ID;
            grdAdditionalIns.DataSource = Instructions.LoadByOrderId(OrderId);
            grdAdditionalIns.DataBind();

        }

        void grdAdditionalIns_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            AdsCom.Instructions ins = e.Row.DataItem as AdsCom.Instructions;
            Label lblSeriolNo = (Label)e.Row.FindControl("lblSeriolNo");
            lblSeriolNo.Text = i.ToString();
            i++;
            Label lblUserBy = (Label)e.Row.FindControl("lblUserBy");
            User usr = new User();
            int str = ins.USER_ID;
            usr.Load(str);
            lblUserBy.Text = usr.RealName;
            //lblUserBy.Text = ins.USER_ID.ToString();
            Label lblAdditionalInsDate = (Label)e.Row.FindControl("lblAdditionalInsDate");
            lblAdditionalInsDate.Text = ins.Date.ToString("MM/dd/yyyy");  //oh.DATE.ToString(("MM/dd/yyyy"));      

        }

        void PopulateUser()
        {

            drpUserId.DataSource = AdsCom.User.FindAll();
            drpUserId.DataTextField = "REALNAME";
            drpUserId.DataValueField = "ID";
            drpUserId.DataBind();
            ListItem li = new ListItem();
            li.Text = "No One";
            li.Value = "0";
            drpUserId.Items.Insert(0, li);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            o = new Order();
            if (Request["AID"] != null)
                o.Load(Convert.ToInt32(Request["AID"]));
            // Session["ORDER_ID"] = o.ORDER_ID;
            o.ORDER_ID = Convert.ToInt16(lblOrderId.Text);
            o.EVENT_ID = Convert.ToInt16(txtEventId.Text);
            o.GRAPHER_ID = lblStudioId.Text;
            o.FOLDER_NAME = txtFolderName.Text;
            o.PAGES = Convert.ToInt16(txtPages.Text);
            o.ALBUM_TYPE = Convert.ToInt16(drpBind.SelectedValue);
            o.ALBUM_STYLE = Convert.ToInt16(drpStyle.SelectedValue);
            o.ALBUM_SIZE = Convert.ToInt16(drpSize.SelectedValue);
            o.USER_ID = Convert.ToInt16(drpUserId.SelectedValue);
            o.SPECIAL_INSTRUCTIONS = lblInstruction.Text;
            o.ORIGINAL_ALBUM_ID = Convert.ToInt16(lblOriginalId.Text);
            o.PRIORITY = Convert.ToInt16(rbPriortiy.SelectedValue);
            o.IMAGE_LIST = lblImageList.Text;
            o.ALBUM_ID = Convert.ToInt16(txtAlbumId.Text);
            o.ALBUM_NAME = txtAlbumName.Text;
            o.IMAGES = Convert.ToInt16(txtImages.Text);
            o.ACTION = Convert.ToInt16(drpSubmitAs.SelectedValue);
            // if (!String.IsNullOrEmpty(drpRating.SelectedValue))
            o.ALBUM_RATING = Convert.ToInt16(drpRating.SelectedValue);

            o.COMMENTS = txtQcComment.Text;
            if (!String.IsNullOrEmpty(txtInstructions.Text))
                o.INSTRUCTION_ID = Convert.ToInt16(lblNewInstruction.Text);
            o.STATUS_ID = Convert.ToInt16(drpSubmitTo.SelectedValue);
            o.USER_ID = 0;

            o.Save();

            Change ch = new Change();
            Change c = ch.LoadByOrderId(o.ORDER_ID);
            c.Order_Id = o.ORDER_ID;

            User usr = new User();
            int str = Convert.ToInt32(Session["USER_ID"]);
            usr.Load(str);

            if (c.Id != 0)
            {
                Change ch2 = new Change();
                ch2.Load(c.Id);
                if (o.STATUS_ID == 2)
                {
                    ch2.Design_By_Id = Convert.ToInt32(Session["USER_ID"]);
                    ch2.Design_By_Name = usr.RealName;
                }
                else if (o.STATUS_ID == 3)
                {
                    ch2.Qa_By_Id = Convert.ToInt32(Session["USER_ID"]);
                    ch2.Qa_By_Name = usr.RealName;
                }
                ch2.Save();
            }
            else
            {
                if (o.STATUS_ID == 2)
                {
                    c.Design_By_Id = Convert.ToInt32(Session["USER_ID"]);
                    c.Design_By_Name = usr.RealName;
                }
                else if (o.STATUS_ID == 3)
                {
                    c.Qa_By_Id = Convert.ToInt32(Session["USER_ID"]);
                    c.Qa_By_Name = usr.RealName;
                }
                c.Save();
            }


            AdsCom.OrderHistory oh = new AdsCom.OrderHistory();
            oh.ORDER_ID = o.ORDER_ID;
            oh.USER_ID = Convert.ToInt32(Session["USER_ID"]);
            oh.USERALLOCATED = Convert.ToInt16(drpUserId.SelectedValue);
            oh.ORDER_STATUS = Convert.ToInt16(drpSubmitTo.SelectedValue);
            oh.DATE = DateTime.Now;
            string strAction = string.Empty;
            if (o.ACTION == 1)
                strAction = "Completed";
            else if (o.ACTION == 2)
                strAction = "Hold";
            else if (o.ACTION == 3)
                strAction = "Return";
            oh.ADDITIONALINSTRUCTION = strAction + " (" + o.ALBUM_RATING + ") " + o.COMMENTS;

            oh.Save();
            //Regex rx = new Regex("<[^>]*>");
            //string str = rx.Replace(rbPriortiy.SelectedItem.Text, "");
            //o.PRIORITY = Convert.ToInt16(rbPriortiy.SelectedValue); 

            AdsCom.UserHistory uh = new AdsCom.UserHistory();
            int str1 = Convert.ToInt32(Session["USER_ID"]);
            uh.Load(str1);
            uh.Order_Id = o.ORDER_ID;
            uh.User_Id = Convert.ToInt32(Session["USER_ID"]);
            string strAction1 = string.Empty;
            if (o.ACTION == 1)
                strAction1 = "Completed";
            else if (o.ACTION == 2)
                strAction1 = "Hold";
            else if (o.ACTION == 3)
                strAction1 = "Return";

            uh.Comments = strAction1 + " (" + o.ALBUM_RATING + ") " + o.COMMENTS;
            uh.Status_Id = Convert.ToInt16(drpSubmitTo.SelectedValue);
            uh.Allocated_Date = DateTime.Now;
            uh.Submitted_Date = DateTime.Now;
            uh.Images = o.IMAGES;
            uh.Pages = o.PAGES;
            uh.Totaltime = DateTime.Now;
            uh.Save();
            Response.Redirect("ListQueue.aspx?UserId=" + Session["USER_ID"]);


        }
        protected void btnSubmitAdmin_Click(object sender, EventArgs e)
        {
            int insid = 0;
            if (!Page.IsValid) return;
            if (!String.IsNullOrEmpty(txtInstructions.Text))
            {
                o = new Order();
                Instructions ins = new Instructions();
                ins.ADDITIONALINSTRUCTION = txtInstructions.Text;
                ins.USER_ID = Convert.ToInt32(Session["USER_ID"]);
                if (Request["AID"] != null)
                    o.Load(Convert.ToInt32(Request["AID"]));
                ins.ORDER_ID = o.ORDER_ID;
                ins.Date = DateTime.Now;
                ins.Save();

                string str2 = "select max(INSTRUCTION_ID) from INSTRUCTIONS ";
                com = new SqlCommand(str2, con);
                SqlDataAdapter adp = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                con.Open();
                SqlDataReader reader = com.ExecuteReader(CommandBehavior.CloseConnection);


                if (reader.Read())
                    insid = Convert.ToInt32(reader[0]);
                con.Close();
            }

            if (Request["AID"] != null)
                o.Load(Convert.ToInt32(Request["AID"]));
            o.ORDER_ID = Convert.ToInt16(lblOrderId.Text);
            o.EVENT_ID = Convert.ToInt16(txtEventId.Text);
            o.GRAPHER_ID = lblStudioId.Text;
            o.FOLDER_NAME = txtFolderName.Text;
            o.PAGES = Convert.ToInt16(txtPages.Text);
            o.ALBUM_TYPE = Convert.ToInt16(drpBind.SelectedValue);
            o.ALBUM_STYLE = Convert.ToInt16(drpStyle.SelectedValue);
            o.ALBUM_SIZE = Convert.ToInt16(drpSize.SelectedValue);
            o.USER_ID = Convert.ToInt16(drpUserId.SelectedValue);
            o.SPECIAL_INSTRUCTIONS = lblInstruction.Text;
            o.ORIGINAL_ALBUM_ID = Convert.ToInt16(lblOriginalId.Text);
            o.IMAGE_LIST = lblImageList.Text;
            if (!String.IsNullOrEmpty(txtAlbumId.Text))
                o.ALBUM_ID = Convert.ToInt16(txtAlbumId.Text);
            else
                o.ALBUM_ID = 0;
            o.ALBUM_NAME = txtAlbumName.Text;
            if (!String.IsNullOrEmpty(txtImages.Text))
                o.IMAGES = Convert.ToInt32(txtImages.Text);
            else
                o.IMAGES = 0;

            o.ACTION = Convert.ToInt16(drpSubmitAs.SelectedValue);
            //if (!String.IsNullOrEmpty(drpRating.SelectedValue))

            o.ALBUM_RATING = Convert.ToInt16(drpRating.SelectedValue);

            AdsCom.UserHistory uh = new AdsCom.UserHistory();
            IList<AdsCom.UserHistory> userhis = new List<AdsCom.UserHistory>();
            userhis = AdsCom.UserHistory.LoadByOrderId(o.ORDER_ID);
            if (!String.IsNullOrEmpty(txtQcComment.Text))
                o.COMMENTS = txtQcComment.Text;


            o.PRIORITY = Convert.ToInt16(rbPriortiy.SelectedValue);
            o.STATUS_ID = Convert.ToInt16(drpCurrentStatusId.SelectedValue);
            if (!String.IsNullOrEmpty(txtInstructions.Text))
                o.INSTRUCTION_ID = insid;
            o.Save();

            AdsCom.Priority pr = new AdsCom.Priority();
            Regex rx = new Regex("<[^>]*>");
            string str = rx.Replace(rbPriortiy.SelectedItem.Text, "");
            if (o.PRIORITY > 1)
            {
                pr.Priority_Id = o.PRIORITY;
                pr.Priority_Name = str;
                pr.Save();
            }


            AdsCom.OrderHistory oh = new AdsCom.OrderHistory();
            oh.ORDER_ID = o.ORDER_ID;
            oh.USER_ID = Convert.ToInt32(Session["USER_ID"]);
            oh.USERALLOCATED = Convert.ToInt16(drpUserId.SelectedValue);
            oh.ORDER_STATUS = Convert.ToInt16(drpSubmitTo.SelectedValue);
            oh.DATE = DateTime.Now;
            string strAction = string.Empty;
            if (o.ACTION == 1)
                strAction = "Completed";
            else if (o.ACTION == 2)
                strAction = "Hold";
            else if (o.ACTION == 3)
                strAction = "Return";
            oh.ADDITIONALINSTRUCTION = o.COMMENTS;

            oh.Save();
            if (!String.IsNullOrEmpty(txtInstructions.Text))
            {
                oh.ORDER_ID = o.ORDER_ID;
                oh.USER_ID = o.USER_ID;
                oh.DATE = DateTime.Now;
                oh.ADDITIONALINSTRUCTION = txtInstructions.Text;
                oh.Save();
            }
            Response.Redirect("ShowOrder.aspx?AID=" + o.Id);
        }

    }
}