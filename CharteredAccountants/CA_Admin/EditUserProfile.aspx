<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="EditUserProfile.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.EditUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="EditUserProfile" style="">
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <div class="TextButton" style="margin-top: -2%; width: 62px; font-size: 17px; margin-left: -13px;">
                        <a style="color: white" href="ViewUserProfile.aspx">< Back </a>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <p>Change Your Image</p>
                </td>
                <td>

                    <asp:Image ID="ImageCaption" Width="32%" CssClass="" Style="border: 2px solid #e5e5e5; color: #474e69; box-shadow: rgba(0,0,0,0.2) 0px 0px 9px; -moz-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px; -webkit-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px; border-radius: 1050px; margin-right: 3%; min-width: 90px; padding: 3px;"
                        runat="server" />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" Font-Names="Al Qalam Quran" ToolTip="Change Your Image" />
                    <br />
                    <asp:Label ID="lblUploadFileError" runat="server"></asp:Label>
                </td>
            </tr>


            <tr>
                <td>

                    <p>Full Name</p>
                </td>
                <td>
                    <asp:TextBox CssClass="AllTextBox" ID="TextBoxUsername" placeholder="Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="TextBoxEmailFieldValidator" runat="server" ControlToValidate="TextBoxUsername" ForeColor="Red" ErrorMessage="*Username Required" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>

            </tr>

            <tr>
                <td>
                    <p>Email</p>
                </td>
                <td>
                    <asp:TextBox CssClass="AllTextBox" ID="TextBoxEmail" placeholder="Email" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmail" ForeColor="Red" ErrorMessage="*Email Required" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="TextBoxEmail" runat="server" ErrorMessage="*Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:Label ID="lblEmailCheck" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:ImageButton CssClass="AllButtons" ID="LoginButton" ImageUrl="../images/Save.png" runat="server" OnClick="LoginButton_Click" />
                    <br />
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
            </tr>



        </table>
    </div>
</asp:Content>
