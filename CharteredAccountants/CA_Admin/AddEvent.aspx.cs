using CharteredAccountantsFYP.Helpers;
using CharteredAccountantsFYP.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP.CA_Admin
{
    public partial class AddEvent : System.Web.UI.Page
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
                ImageCaption.ImageUrl = "~/Uploads/IssueImages/NoImage.png";
                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
                {
                    string IsUpdated = Convert.ToString(Session["IsUpdated"]);
                    if (IsUpdated == "Updated")
                    {
                        Label1.Text = "Event Successfully Updated!";
                        Session["IsUpdated"] = "NotUpdated";
                        Label1.ForeColor = System.Drawing.Color.Green;
                    }
                    int ID = Convert.ToInt32(Request.QueryString["Id"]);
                    EventsModel list = Logic.ListViewEvents(ID);
                    TextBoxTitle.Text = list.Title;
                    TextBoxDiscription.InnerText = list.Discription;
                    ImageCaption.ImageUrl = list.ImageLink;
                    TextBoxdatepickerEndDate.Text = Convert.ToString(list.EventDate.ToShortDateString());
                    Session["CheckEdit"] = "true";
                }
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //if (FileUpload1.HasFile)
            //{
                lblMessage.Text = " ";
                Label1.Text = " ";
                string Title = TextBoxTitle.Text;
                //String imageURL = TextBoxi.Text;
                string disc = TextBoxDiscription.InnerText;
                string EventDate = TextBoxdatepickerEndDate.Text;
                int postedbyId = Convert.ToInt16(Session["CurrentUserId"]);
                //string postedbyName = Convert.ToString(Session["CurrentUserId"]);
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
                            int eventID = Convert.ToInt32(Request.QueryString["Id"]);
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
                                objImage.Save(Server.MapPath("~/Uploads/EventImages/" + ++AddNumberToRemoveDuplication + FileUpload1.FileName));
                                //FileUpload1.SaveAs(Server.MapPath("~/Uploads/IssueImages/" + FileUpload1.FileName));
                                imgURL = "~/Uploads/EventImages/" + AddNumberToRemoveDuplication + FileUpload1.FileName;
                            }
                            Logic.UpdateEvent(eventID, Title, disc, imgURL, EventDate, postedbyId);
                            //Label1.Text = "Event Successfully Updated!";
                            Session["IsUpdated"] = "Updated";
                            Response.Redirect("~/CA_Admin/AddEvent.aspx?Id=" + eventID);
                        }
                        else
                        {//for Adding new post
                            String imgURL;
                            lblMessage.Text = " ";
                            if (fileExtension == "")
                            {
                                imgURL = "~/Uploads/EventImages/NoImage.png";
                            }
                            else
                            {
                                 int AddNumberToRemoveDuplication = Logic.ReturnLastEventId();
                                 System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);
                                 System.Drawing.Image objImage = Logic.ScaleImage(bmpPostedImage, 100);
                                 objImage.Save(Server.MapPath("~/Uploads/EventImages/" + ++AddNumberToRemoveDuplication + FileUpload1.FileName));
                                 imgURL = "~/Uploads/EventImages/" + AddNumberToRemoveDuplication + FileUpload1.FileName;
                             }
                            Logic.AddEvent(Title ,imgURL, disc, EventDate, postedbyId);
                            TextBoxTitle.Text = " ";
                            TextBoxDiscription.InnerText = " ";
                            TextBoxdatepickerEndDate.Text = " ";
                            Label1.Text = "Successfuly Posted!";
                            Label1.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
        }
        

            //}
            //else
            //{
            //    lblMessage.ForeColor = System.Drawing.Color.Red;
            //    lblMessage.Text = "Please select an Image";
            //}
        }
    }
