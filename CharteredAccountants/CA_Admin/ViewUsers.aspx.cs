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
    public partial class ViewUsers : System.Web.UI.Page
    {
        public int StartIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Convert.ToString(Session["loginAdmin"]);
            if (check != "admin")
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["StartIndex"] != null || Convert.ToInt16(Request.QueryString["StartIndex"]) != 0)
                {
                    StartIndex = Convert.ToInt32(Request.QueryString["StartIndex"]);
                    loadUserslist();
                }
                else
                {
                    loadUserslist();
                }
            }
        }

        public void loadUserslist()
        {
            List<UsersModel> list = Logic.LoadUsers();
            GridViewUser.DataSource = list;
            GridViewUser.DataBind();

            if (list.Count != 0)
            {
                int totalRecords = list.Count();
                int pageSize = 5;
                int totalPages = totalRecords / pageSize;
                if (totalRecords % 5 > 0)
                {
                    totalPages += 1;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < totalPages; i++)
                {
                    int pageNo = i + 1;

                    sb.Append("<a style=\"color: #FFFFFF\" href=\"ViewUsers.aspx?StartIndex=" + pageSize * i + "\">" + pageNo.ToString() + "</a>&nbsp;");
                    int GridPagingNumber = pageSize * i;
                    Session["GridPagingNumber"] = GridPagingNumber;
                }
                Literal.Text = "Page: " + sb.ToString();
                GridViewUser.DataSource = list.Skip(StartIndex).Take(5);
                GridViewUser.DataBind();
            }
            else
            {
                lblNoData.Text = "There are no Users.";
                Literal.Text = " ";
            }
        }

        protected void GridViewUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "enableUser")
            {
                Logic.EnableOrDisableUser(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "disableUser")
            {
                Logic.EnableOrDisableUser(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "deleteUser")
            {
                Logic.DeleteUser(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "yes_Admin")
            {
                Logic.ChangeAdminPower(Convert.ToInt32(e.CommandArgument));
            }
            if (e.CommandName == "no_Admin")
            {
                Logic.ChangeAdminPower(Convert.ToInt32(e.CommandArgument));
            }
            Response.Redirect("~/CA_Admin/ViewUsers.aspx");
        }
    }
}