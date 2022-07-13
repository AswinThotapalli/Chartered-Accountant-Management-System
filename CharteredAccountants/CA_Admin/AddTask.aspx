<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.AddIssue" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     
   
        <link rel="StyleSheet" href="StyleAdmin.css" type="text/css" />
     <meta charset="utf-8" />
     
    <link href="../DropdownlistImages/DropDownList.css" rel="stylesheet" />
    <script src="../DropdownlistImages/jquery-1.6.1.min.js"></script>
    <script src="../DropdownlistImages/jquery_dropdown.js"></script>
    
   
    <script type="text/javascript">
        $(document).ready(function (e) {
            try {
                $("#DropDownListAssignee").msDropDown();

            } catch (e) {
                alert(e.message);
            }
        });
    </script>


    <div class="AdminBackAddEvent" style="">

        <table style="width: 96%; margin-left: 5%;">
            <tr>
                <td colspan="2">
                    <h2 style="color:#1488e0; ">Create a Task</h2>
                </td>
            </tr>
            <tr>
                <td style="width: 10%" >
                    <asp:Label ID="Label1" runat="server" ForeColor="#009933"></asp:Label>
                </td>
            </tr>

            <tr>

                <td style="width: 10%" >
                    <p>Name (*)</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxName" MaxLength="30" CssClass="AllTextBox" Width="65%" placeholder="Task Name" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxName" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Name is Required"></asp:RequiredFieldValidator>
                </td>

            </tr>

             <tr>
                <td style="width: 10%">
                    <p>Discription</p>
                </td>

                <td>
                    <textarea id="TextBoxDiscription" rows="4" runat="server" class="AllTextBox" cols="50" placeholder="Discription of the Task" maxlength="500" style="width: 65%"></textarea>
                </td>
            </tr>

            
            <tr>
                <td style="width: 10%">
                    <p>Assignee (*)</p>    
                </td>

                <td>
                 
                   <asp:DropDownList ID="DropDownListAssignee" Width="25%" ClientIdMode="Static" runat="server"></asp:DropDownList>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" style="line-height: 39px;margin-left: 7px;" runat="server" ForeColor="Red" ControlToValidate="DropDownListAssignee"
                    ErrorMessage="Select Assignee" InitialValue="0"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td style="width: 10%">
                    <p>Priority</p>
                </td>

                <td>
                    <asp:DropDownList ID="DropDownListPriority" class="AllTextBox" style="font-size:16px; width:156px;"  runat="server">
                        <asp:ListItem Text="Major" Value="1" Selected="True" ></asp:ListItem>
                        <asp:ListItem Text="Normal" Value="2" ></asp:ListItem>
                        <asp:ListItem Text="Minor" Value="3" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 10%; margin-top:15px" >
                    
                    <p>Attach Image</p>
                </td>

                <td style="margin-top:15px">
                    <asp:FileUpload  ID="FileUpload1" CssClass="AllTextBox" runat="server" Width="30%" /><asp:Image ID="ImageCaption" CssClass="AllTextBox" style="float: right; padding: 3px; margin-right: 33%; max-height: 50px; width: 70px;" runat="server" /> 

                    <br />
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                     </td>
            </tr>

            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:ImageButton ID="ImageButton1" CssClass="AllButtons" ImageUrl="../images/Save.png" runat="server" OnClick="ImageButton1_Click" />
                    <br />
                </td>
            </tr>

        </table>

    </div>

</asp:Content>
