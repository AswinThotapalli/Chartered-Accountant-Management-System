using CharteredAccountantsFYP.Helpers;
using CharteredAccountantsFYP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class ExpiredEvent : System.Web.UI.Page
    {
        public int IssueStartIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            string email = Convert.ToString(Session["CurrentUserEmail"]);

            int pageSize = Convert.ToInt32(DropDownListPageSize.SelectedValue);


            if (!IsPostBack)
            {
                if (Request.QueryString["IssueStartIndex"] != null || Convert.ToInt16(Request.QueryString["IssueStartIndex"]) != 0)
                {
                    IssueStartIndex = Convert.ToInt32(Request.QueryString["IssueStartIndex"]);
                    loadEventlist(pageSize);
                }
                else
                {
                    loadEventlist(pageSize);
                }

            }
            else
            {
                loadEventlist(pageSize);
            }
        }

        public void loadEventlist(int pageSizefromUI)
        {
            int UserId = Convert.ToInt32(Session["CurrentUserId"]);
            List<EventsModel> list = Logic.ListExpiredEvents();
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
                    sb.Append("<a style=\"color: #FFFFFF\" href=\"ExpiredEvents.aspx?IssueStartIndex=" + pageSize * i + "\">" + pageNo.ToString() + "</a>&nbsp;");
                    int GridPagingNumber = pageSize * i;
                    Session["GridPagingNumber"] = GridPagingNumber;
                }
                LiteralEvent.Text = "Page: " + sb.ToString();
                GridViewEvent.DataSource = list.Skip(IssueStartIndex).Take(pageSize);
                GridViewEvent.DataBind();
            }
            else
            {
                lblNoEvents.Text = "There are no events.";//There are no tasks assigned to you.
                LiteralEvent.Text = " ";
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

    }
}