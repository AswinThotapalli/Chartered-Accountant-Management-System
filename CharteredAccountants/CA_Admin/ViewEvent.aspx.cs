using CharteredAccountantsFYP.Helpers;
using CharteredAccountantsFYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class ViewEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            int Id = Convert.ToInt32(Request.QueryString["EventId"]);
            EventsModel eventList = Logic.ListViewEvents(Id);

            lblTitle.Text = eventList.Title;
            lblDiscription.Text = eventList.Discription;
            lblEventDate.Text = Convert.ToString(eventList.EventDate);
            lblPostedby.Text = eventList.PosterName;
            ImageEvent.ImageUrl = eventList.ImageLink;

            ////////////////////////////////////

            List<EventsModel> list = Logic.ListEventsComments(Id);

            if (list.Count > 0)
            {
                this.Panel1.Controls.Clear();
                lblCommentTitle.Text = list.Count + " Comments: ";

                Label[] labelName = new Label[list.Count];
                Label[] labelComment = new Label[list.Count];
                Label[] labelString = new Label[list.Count];
                Label[] labelString2 = new Label[list.Count];
                Label[] labelStringLine = new Label[list.Count];
                Label[] labelStringSpace = new Label[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    labelName[i] = new Label();
                    labelName[i].Text = list[i].Name;
                    labelComment[i] = new Label();
                    labelComment[i].Text = list[i].Comment;
                    // Here you can modify the value of the label which is at labels[i]
                }

                for (int i = 0; i < list.Count; i++)
                {
                    labelString[i] = new Label();
                    labelString[i].Text = "<br/>";

                    labelString2[i] = new Label();
                    labelString2[i].Text = "<br/>";

                    labelStringSpace[i] = new Label();
                    labelStringSpace[i].Text = "&nbsp; &nbsp;";

                    labelStringLine[i] = new Label();
                    labelStringLine[i].Text = "<hr> <br/>";

                    labelName[i].Font.Bold = true;
                    this.Panel1.Controls.Add(labelName[i]);

                    this.Panel1.Controls.Add(labelString[i]);

                    this.Panel1.Controls.Add(labelStringSpace[i]);

                    this.Panel1.Controls.Add(labelComment[i]);
                    this.Panel1.Controls.Add(labelString2[i]);
                    this.Panel1.Controls.Add(labelStringLine[i]);
                }
            }
            else
            {
                lblCommentTitle.Text = "There are No Comments";
            }


        }

        protected void LinkButton_ClickPostComment(object sender, EventArgs e)
        {
            int IssueId = Convert.ToInt32(Request.QueryString["EventId"]);
            int CurrentUserId = Convert.ToInt32(Session["CurrentUserId"]);
            if (TextBoxComment.InnerText != "")
            {
                Logic.SaveEventsRemark(CurrentUserId, IssueId, TextBoxComment.InnerText);
                lblComment.Text = "";
                TextBoxComment.InnerText = "";
            }
            else
            {
                lblComment.Text = "Comment Field is Required";
            }
            
            Page_Load(sender, e);
        }

    }
}