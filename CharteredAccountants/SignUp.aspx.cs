using CharteredAccountantsFYP.Models;
using CharteredAccountantsFYP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharteredAccountantsFYP
{
    public partial class WebFormSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SignUpButton_Click(object sender, ImageClickEventArgs e)
        {
            String emailCheck = TextBoxEmail.Text;
            if (Logic.ValidateEmail(emailCheck))
            {
                if (Request.QueryString["ID"] == null)
                {
                    UsersModel model = new UsersModel();
                    Label1.Text = " ";
                    lblEmailCheck.Text = " ";
                    model.Name = TextBoxUsername.Text;
                    model.Email = TextBoxEmail.Text;
                    model.Password = TextBoxPassword.Text;

                    if (FileUpload1.HasFile)
                    {
                        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                        if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".png" && fileExtension != "")
                        {
                            Label1.Text = " ";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Only files with .jpg and .png extension are allowed";
                        }
                        else
                        {
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

                                long lastUserID = Logic.ReturnLastUserId();
                                lastUserID++;

                                //if (fileSize <= 150385)
                                //{
                                //    FileUpload1.SaveAs(Server.MapPath("~/Uploads/UserImages/" + lastUserID + FileUpload1.FileName));
                                //}
                                //else
                                //{
                                    System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);
                                    System.Drawing.Image objImage = Logic.ScaleImage(bmpPostedImage, 160);
                                    objImage.Save(Server.MapPath("~/Uploads/UserImages/" + lastUserID + FileUpload1.FileName));
                                //}
                                
                                model.ImageURL = lastUserID + FileUpload1.FileName;

                                System.Drawing.Bitmap bmpPostedImageDDL = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);
                                System.Drawing.Image objImageDDL = Logic.ScaleImage(bmpPostedImageDDL, 32);
                                objImageDDL.Save(Server.MapPath("~/Uploads/UserImages/UserDDLImages/" + lastUserID + FileUpload1.FileName));

                                model.ImageURLDDL = lastUserID + FileUpload1.FileName;
                            }
                        }
                    }
                    else
                    {
                        model.ImageURL = "NoImage.jpg";
                        model.ImageURLDDL = "NoImageDDL.jpg";
                    }

                    Logic.SaveUser(model);


                    //int EmailID = Logic.ReturnID_ByEmail(TextBoxEmail.Text);
                    Session["loginUser"] = 2;
                    //Session["EditID"] = EmailID;// Send it to user "WebFormUserHome.aspx"
                    //Session["CurrentEmail"] = TextBoxEmail.Text;
                    //String NameOfPostingAdd = Logic.ReturnNameByEmail(TextBoxEmail.Text);
                    //Session["NameOfPostingAdd"] = NameOfPostingAdd;
                    lblAccountActivationError.Text = "Your account is lock, needs admin approval";

                }
          
            }
            else
            {
                lblEmailCheck.Text = "Email Already Exists";
                lblAccountActivationError.Text = "";
                Label1.Text = " ";
                lblEmailCheck.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}