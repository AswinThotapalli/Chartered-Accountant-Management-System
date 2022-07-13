using CharteredAccountantsFYP.Models;
using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        public int EventStartIndex = 0;
        public int IssueStartIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }


            int pageSize = Convert.ToInt32(DropDownListPageSize.SelectedValue);


            if (!IsPostBack)
            {

                if (Request.QueryString["EventStartIndex"] != null || Convert.ToInt16(Request.QueryString["EventStartIndex"]) != 0)
                {
                    EventStartIndex = Convert.ToInt32(Request.QueryString["EventStartIndex"]);
                    loadEventlist(pageSize);
                }
                else
                {
                    loadEventlist(pageSize);
                }
                if (Request.QueryString["IssueStartIndex"] != null || Convert.ToInt16(Request.QueryString["IssueStartIndex"]) != 0)
                {
                    IssueStartIndex = Convert.ToInt32(Request.QueryString["IssueStartIndex"]);
                    loadTasklist(pageSize);
                }
                else
                {
                    loadTasklist(pageSize);
                }

            }
            else
            {
                loadEventlist(pageSize);
                loadTasklist(pageSize);
            }
       }  
        public void loadEventlist(int pageSizefromUI)
        {
            List<EventsModel> list = Logic.ListEvents();
            GridViewEvent.DataSource = list;
            GridViewEvent.DataBind();

            if (list.Count != 0)
            {
                int totalRecords = list.Count();
                int pageSize = pageSizefromUI;
                int totalPages = totalRecords / pageSize;
                if (totalRecords % pageSize > 0)
                {
                    totalPages += 1;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < totalPages; i++)
                {
                    int pageNo = i + 1;

                    sb.Append("<a style=\"color: #FFFFFF\" href=\"AdminHome.aspx?EventStartIndex=" + pageSize * i + "\">" + pageNo.ToString() + "</a>&nbsp;");
                    int GridPagingNumber = pageSize * i;
                    Session["GridPagingNumber"] = GridPagingNumber;
                }
                LiteralEvent.Text = "Page: " + sb.ToString();
                GridViewEvent.DataSource = list.Skip(EventStartIndex).Take(pageSize);
                GridViewEvent.DataBind();
            }
            else 
            {
                lblNoEvents.Text = "There are no events.";
                LiteralIssue.Text = " ";
            }
        }

        public void loadTasklist(int pageSizefromUI)
        {
            List<TasksModel> list = Logic.ListTasks();
            GridViewIssue.DataSource = list;
            GridViewIssue.DataBind();
            if (list.Count != 0)
            {
                int totalRecords = list.Count();
                int pageSize = pageSizefromUI;
                int totalPages = totalRecords / pageSize;
                if (totalRecords % pageSize > 0)
                {
                    totalPages += 1;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < totalPages; i++)
                {
                    int pageNo = i + 1;
                    sb.Append("<a style=\"color: #FFFFFF\" href=\"AdminHome.aspx?IssueStartIndex=" + pageSize * i + "\">" + pageNo.ToString() + "</a>&nbsp;");
                    int GridPagingNumber = pageSize * i;
                    Session["GridPagingNumber"] = GridPagingNumber;
                }
                LiteralIssue.Text = "Page: " + sb.ToString();
                GridViewIssue.DataSource = list.Skip(IssueStartIndex).Take(pageSize);
                GridViewIssue.DataBind();
            }
            else
            {
                lblNoData.Text = "There are no tasks.";//There are no tasks assigned to you.
                LiteralIssue.Text = " ";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteTask")
            {
                Logic.DeleteTask(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "deleteEvent")
            {
                Logic.DeleteEvent(Convert.ToInt32(e.CommandArgument));
            }
            Response.Redirect("~/CA_Admin/AdminHome.aspx");
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string quickSearch = TextBoxQuickSearch.Text;
            Response.Redirect("~/CA_Admin/SearchGrids.aspx?search=" + quickSearch);
        }
    }
}