<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CharteredAccountantsFYP.WebFormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login First</title>
    <%--<link rel="shortcut icon" href="/images/smartphone.png"/>--%>
    <meta charset="utf-8" />
    <link href="StyleSheet.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, inital=scal=1.0" />
   
</head>
<body>
    <form id="form1" runat="server">
    <div id="LoginBack" style="margin-top:5%">
          
        <div style="text-align:center">
                <asp:Image ID="Image1" style="border-radius:1000px; height:73px; border: 1px solid #3cb9f8;margin-top: 13px;" ImageUrl="~/images/User.png" runat="server" />
            </div>

                <table style="width: 100%; margin-top:23px ; margin-left:50px " >

                    <tr>
                        <td colspan="2">
                            <span style="color: #474e69; font-size: 15px;"><span style="color:black; font-size:17px">Welcome! </span>Login To Continue</span>
                        </td>
                    </tr>

                    <tr>
                    
                        <%--<td style=""><p>Email</p></td>--%>
                        <td colspan="2">
                            <asp:TextBox CssClass="AllTextBox" required x-moz-errormessage="Email is required" style="height: 28px; padding: 4px; width: 72%;" MaxLength="50" ID="TextBoxUserEmail" placeholder="Email" runat="server"></asp:TextBox>
                            
                           <%-- <asp:RequiredFieldValidator ID="TextBoxEmailFieldValidator" runat="server" ControlToValidate="TextBoxUserEmail" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                        
                    <tr>
                        <%--<td style=""><p>Password</p></td>--%>
                        <td>
                            <asp:TextBox CssClass="AllTextBox" required x-moz-errormessage="Password is required" style="height: 28px; padding: 4px; width: 72%;" MaxLength="15" ID="TextBoxPassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPassword" ForeColor="Red" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2" style="color: #474e69; font-size: 15px">
                            <a href="SignUp.aspx"><b style="color:#1488e0" >Click Here</b></a> To Register
                        </td>
                    </tr>
                    
                    <tr>

                        <td colspan="2"  >
                           <asp:Label ID="LblMsg" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" ControlToValidate="TextBoxUserEmail" runat="server"  ErrorMessage="Email is Invalid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>

                       
                        <td colspan="2">
                            <%--<asp:Button ID="LoginButton" style="background-color:#4c9ed9 ;color:red; height:100px; border-bottom-left-radius: 1119px;border-bottom-right-radius: 1111px" OnClick="LoginButton_Click" runat="server" Text="Button"/>--%>
                          <asp:ImageButton CssClass="LoginBackButton" ID="LoginButton" ImageUrl="~/images/login.png" runat="server" style="" OnClick="LoginButton_Click"/>
                        </td>
                       
                    </tr>

                    

                  
                </table>
    </div>
    </form>
</body>
</html>
