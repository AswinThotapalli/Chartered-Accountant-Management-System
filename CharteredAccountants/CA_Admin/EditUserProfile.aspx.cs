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
    public partial class EditUserProfile : System.Web.UI.Page
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
                int currentU_ID = Convert.ToInt32(Session["CurrentUserId"]);
                UsersModel UserList = Logic.ReturnUsersList(currentU_ID);

                TextBoxUsername.Text = UserList.Name;
                TextBoxEmail.Text = UserList.Email;
                Session["OldEmail"] = TextBoxEmail.Text;
                ImageCaption.ImageUrl = "~/Uploads/UserImages/" + UserList.ImageURL;
            }
        }

        protected void LoginButton_Click(object sender, ImageClickEventArgs e)
        {
            int currentUserID = Convert.ToInt32(Session["CurrentUserId"]);
            if (Logic.ValidateEmailExcludeCurrentID(TextBoxEmail.Text, currentUserID))
            {
                UsersModel model = Logic.ReturnUsersList(currentUserID);
                //UsersModel model = new UsersModel();
                //int Id = currentUserID;
                model.Name = TextBoxUsername.Text;
                model.Email = TextBoxEmail.Text;

                if (FileUpload1.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".png" && fileExtension != "")
                    {
                        lblMsg.Text = "";
                        lblUploadFileError.ForeColor = System.Drawing.Color.Red;
                        lblUploadFileError.Text = "Only files with .jpg and .png extension are allowed";
                        goto skip;
                    }
                    else
                    {
                        // Get the file size
                        int fileSize = FileUpload1.PostedFile.ContentLength;
                        // If file size is greater than 1 MB
                        if (fileSize > 1048576)
                        {
                            lblMsg.Text = "";
                            lblUploadFileError.ForeColor = System.Drawing.Color.Red;
                            lblUploadFileError.Text = "File size cannot be greater than 1 MB";
                            goto skip;
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
                Logic.UpdateUser(model);
                string oldEmail = Convert.ToString(Session["OldEmail"]);
                if (oldEmail != model.Email)
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (FileUpload1.HasFile)
                {
                    Response.Redirect("~/CA_Admin/EditUserProfile.aspx");
                }
                lblMsg.Text = "Successfully Updated";
                lblMsg.ForeColor = System.Drawing.Color.Green;

            skip: int x;
            }
            else
            {
                lblMsg.Text = "Email Already Exists";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}