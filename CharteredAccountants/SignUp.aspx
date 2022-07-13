<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CharteredAccountantsFYP.WebFormSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>Sign Up Here</title>
   <%-- <link rel="shortcut icon" href="/images/smartphone.png"/>--%>
    <meta charset="utf-8" />
    <link href="StyleSheet.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, inital=scal=1.0" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="SignUpBack">

           <div style="text-align:center">
                <asp:Image ID="Image1" style="border-radius:1000px; height:73px; border: 1px solid #3cb9f8;margin-top: 1px;" ImageUrl="~/images/UsersAdd.png" runat="server" />
            </div>

    <table class="tblSignUpBack">

         <tr>
              <td colspan="2">
                            <span style="color:#1488e0;font-weight:bold; font-size:16px">Basic Information Required</span><br />
                  <asp:Label ID="lblAccountActivationError" ForeColor="Red" runat="server"></asp:Label>
              </td>
          </tr>

        <tr>
            <td colspan="2">
                <asp:TextBox CssClass="AllTextBox" style="height: 28px; padding: 4px; width: 57%;" ID="TextBoxUsername" placeholder="Name" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TextBoxEmailFieldValidator" runat="server" ControlToValidate="TextBoxUsername" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>            
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:TextBox CssClass="AllTextBox" ID="TextBoxEmail" style="height: 28px; padding: 4px; width: 57%;" placeholder="Email" runat="server" ></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmail" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:TextBox CssClass="AllTextBox" style="height: 28px; padding: 4px; width: 57%;" ID="TextBoxPassword" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPassword" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:TextBox CssClass="AllTextBox" style="height: 28px; padding: 4px; width: 57%;" ID="TextBoxReTypePassword" placeholder="ReType Password" runat="server" TextMode="Password"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxReTypePassword" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
            
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:FileUpload  ID="FileUpload1" CssClass="AllTextBox" runat="server" Width="36%" /><span style="color:#1488e0">Choose Image</span>
                
            </td>
        </tr>

         <tr>
            <td colspan="2">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="TextBoxEmail" runat="server"  ErrorMessage="Email is Invalid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator><br />
                <asp:CompareValidator ID="CompareValidator1" ControlToCompare="TextBoxPassword" Display="Dynamic" Type="String" Operator="Equal" ControlToValidate="TextBoxReTypePassword" runat="server" ForeColor="Red" ErrorMessage="Passwords Must Match"></asp:CompareValidator>
                
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:Label ID="Label1" runat="server" ForeColor="#009933"></asp:Label>
                <asp:Label ID="lblEmailCheck" runat="server"></asp:Label>
             </td>
        </tr>

        <tr>
            <td style="color: #474e69; font-size: 15px" class="" colspan="2">
             
            <a href="Login.aspx"><b style="color:#1488e0">Click Here</b></a> To Go Back
            
            </td>
        </tr>

        <tr>
            <td colspan="2">
                    <asp:ImageButton ID="ImageButton1" CssClass="SignUpBackButton" ImageUrl="../images/SignInSave.png" runat="server" OnClick="SignUpButton_Click" />
                    <br />
            </td>
        </tr>

    </table>
        </div>


    </form>
</body>
</html>

