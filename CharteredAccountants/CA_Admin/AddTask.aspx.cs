using CharteredAccountantsFYP.Models;
using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class AddIssue : System.Web.UI.Page
    {
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
                Session["CheckEdit"] = "false";
                DropDownListImageAndName();
                ImageCaption.ImageUrl = "~/Uploads/IssueImages/NoImage.png";
                if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
                {
                    string IsUpdated = Convert.ToString(Session["IsUpdated"]);
                    if (IsUpdated == "Updated")
                    {
                        Label1.Text = "Task Successfully Updated!";
                        Session["IsUpdated"] = "NotUpdated";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                    int ID = Convert.ToInt32(Request.QueryString["Id"]);
                    TasksModel list = Logic.ListViewTasks(ID);
                    TextBoxName.Text = list.Name;
                    TextBoxDiscription.InnerText = list.Discription;
                    ImageCaption.ImageUrl = list.ImageLink;
                    DropDownListAssignee.SelectedValue = Convert.ToString (list.Email);
                    DropDownListPriority.SelectedValue = list.Priority;
                    Session["CheckEdit"] = "true";
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = " ";
            Label1.Text = " ";
            string name = TextBoxName.Text;

            int assigneeId = Logic.ReturnID_ByEmail(Convert.ToString(DropDownListAssignee.SelectedItem));

            int assignee = assigneeId;
            string proirity = Convert.ToString(DropDownListPriority.SelectedItem);
            string discription = TextBoxDiscription.InnerText;

            int postedby = Convert.ToInt16(Session["CurrentUserId"]);

            // Get the file extension
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

            if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".png" && fileExtension != "")
            {
                Label1.Text = " ";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Only files with .jpg and .png extension are allowed";
            }
            else
            {
                // Get the file size
                int fileSize = FileUpload1.PostedFile.ContentLength;
                // If file size is greater than 1 MB
                if (fileSize > 1048576)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "File size cannot be greater than 1 MB";
                    Label1.Text = " ";
                }
                else
                {
                    string IsNew = Convert.ToString(Session["CheckEdit"]);
                    if (IsNew == "true")
                    {//For Updation
                        String imgURL;
                        int taskID = Convert.ToInt32(Request.QueryString["Id"]);
                        lblMessage.Text = " ";

                        if (fileExtension == "")
                        {
                            imgURL = ImageCaption.ImageUrl;
                        }
                        else
                        {
                            long AddNumberToRemoveDuplication = Logic.ReturnLastIssueId();
                            System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);
                            System.Drawing.Image objImage = Logic.ScaleImage(bmpPostedImage, 100);
                            objImage.Save(Server.MapPath("~/Uploads/IssueImages/" + ++AddNumberToRemoveDuplication + FileUpload1.FileName));
                            imgURL = "~/Uploads/IssueImages/" + AddNumberToRemoveDuplication + FileUpload1.FileName;
                        }

                        Logic.UpdateTask(taskID, name, discription, imgURL, assignee, proirity, postedby);

                        Session["IsUpdated"] = "Updated";

                        //Label1.Text = "Task Successfully Updated!";

                        Response.Redirect("~/CA_Admin/AddTask.aspx?Id=" + taskID);
                    }
                    else
                    {//for Adding new post
                        String imgURL;
                        lblMessage.Text = " ";
                        if (fileExtension == "")
                        {
                            imgURL = "~/Uploads/IssueImages/NoImage.png";
                        }
                        else
                        {
                            long AddNumberToRemoveDuplication = Logic.ReturnLastIssueId();
                            System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);
                            System.Drawing.Image objImage = Logic.ScaleImage(bmpPostedImage, 100);
                            objImage.Save(Server.MapPath("~/Uploads/IssueImages/" + ++AddNumberToRemoveDuplication + FileUpload1.FileName));
                            //FileUpload1.SaveAs(Server.MapPath("~/Uploads/IssueImages/" + FileUpload1.FileName));
                            imgURL = "~/Uploads/IssueImages/" + AddNumberToRemoveDuplication + FileUpload1.FileName;
                        }
                        Logic.AddTask(name, discription, imgURL, assignee, proirity, postedby);
                        TextBoxName.Text = " ";
                        TextBoxDiscription.InnerText = " ";
                        Label1.Text = "Successfuly Created!";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
        }

        protected void DropDownListImageAndName()
        {
            DataContext db = new DataContext();
            var UserNamesDD = from u in db.TblUsers
                              where u.IsAdmin == false
                              && u.IsActive == true
                              && u.IsDeleted == false
                              //orderby u.Name
                              select new
                              {
                                  u.Name,
                                  u.Email,
                                  u.ImageURL_DDL
                              };
            DropDownListAssignee.DataSource = UserNamesDD;
            DropDownListAssignee.DataValueField = "ImageURL_DDL";
            DropDownListAssignee.DataTextField = "Email";
            DropDownListAssignee.DataBind();

            foreach (ListItem ListItem in DropDownListAssignee.Items)
            {
                ListItem.Attributes["title"] = "../Uploads/UserImages/UserDDLImages/" + ListItem.Value;
            }
            DropDownListAssignee.Items.Insert(0, new ListItem("Select", "0"));
        }

        //protected void DDL()
        //{
        //    DataContext db = new DataContext();
        //    var UserNamesDD = from u in db.TblUsers
        //                      where u.IsAdmin == false
        //                      orderby u.Name
        //                      select new
        //                      {
        //                          u.Id,
        //                          u.Email
        //                      };
        //    DropDownListAssignee.DataValueField = "Id";
        //    DropDownListAssignee.DataTextField = "Email";
        //    DropDownListAssignee.DataSource = UserNamesDD;
        //    DropDownListAssignee.DataBind();
        //    DropDownListAssignee.Items.Insert(0, new ListItem("Select", "0"));

        //}

    }
}