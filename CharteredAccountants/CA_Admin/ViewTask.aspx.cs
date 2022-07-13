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
    public partial class ViewIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            int Id = Convert.ToInt32(Request.QueryString["IssueId"]);
            TasksModel issueList = Logic.ListViewTasks(Id);

            if (issueList.Status == 1)
            {
                LabelStatusRemaining.Text = "Task is Remaining yet";
                LabelStatusFinished.Text = " ";
            }
            else
            {
                LabelStatusFinished.Text = "Task is Complete";
                LabelStatusRemaining.Text = " ";
            }

            if (!IsPostBack)
            {
                lblName.Text = issueList.Name;
                lblDiscription.Text = issueList.Discription;
                lblAssignee.Text = issueList.Assignee;
                lblPriority.Text = issueList.Priority;
                ImageIssue.ImageUrl = issueList.ImageLink;
                DropDownListStatus.SelectedValue = Convert.ToString(issueList.Status);
            }

            Logic obj = new Logic();
            string changedByName = obj.ReturnNamebyId(Id);
            if (changedByName == "")
                {
                    LabelChangeStatus.Text = "";
                }
                else
                {
                    LabelChangeStatus.Text = "Last Changed By: " + changedByName;
                }

            /////////////////////////////////////////////  
         
            List<TasksModel> list = Logic.ListTaskComments(Id);

            if (list.Count > 0)
            {
                this.Panel1.Controls.Clear();
                lblCommentTitle.Text = list.Count + " Comments : ";

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
                    labelStringSpace[i].Text = "&nbsp; &nbsp; &#10148; ";

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

        protected void LinkButton_ClickChangeStatus(object sender, EventArgs e)
        {
            int IssueId = Convert.ToInt32(Request.QueryString["IssueId"]); 
            int CurrentUserId = Convert.ToInt32(Session["CurrentUserId"]);
            int DDValue = Convert.ToInt32(DropDownListStatus.SelectedValue);

            Logic.UpdateIssueStatus(IssueId, CurrentUserId, DDValue);

            Logic obj = new Logic();
            string changedByName = obj.ReturnNamebyId(IssueId);
            if (changedByName == "")
            {
                LabelChangeStatus.Text = "";
            }
            else
            {
                LabelChangeStatus.Text = "Last Changed By: " + changedByName;
            }

            Page_Load(sender, e);
        }

        protected void LinkButton_ClickPostComment(object sender, EventArgs e)
        {
            int IssueId = Convert.ToInt32(Request.QueryString["IssueId"]);
            int CurrentUserId = Convert.ToInt32(Session["CurrentUserId"]);
            string n = TextBoxComment.InnerText;
            if (TextBoxComment.InnerText != "")
            {
                Logic.SaveTasksRemark(CurrentUserId, IssueId, TextBoxComment.InnerText);
                lblNoComment.Text = "";
                TextBoxComment.InnerText = "";
            }
            else
            {
                lblNoComment.Text = "Comment Field is Required";
            }
            Page_Load(sender, e);
        }
    }
}