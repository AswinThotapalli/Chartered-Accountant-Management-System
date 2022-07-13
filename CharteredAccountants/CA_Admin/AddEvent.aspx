<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AddEvent.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.AddEvent" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <link rel="StyleSheet" href="StyleAdmin.css" type="text/css" />
     <meta charset="utf-8" />


    <link href="../jquery/css/ui-darkness/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="../jquery/css/ui-darkness/jquery-ui-1.10.4.custom.min.css" rel="stylesheet" />

    <script src="../jquery/js/jquery-1.10.2.js"></script>
    <script src="../jquery/js/jquery-ui-1.10.4.custom.js"></script>
    <script src="../jquery/js/jquery-ui-1.10.4.custom.min.js"></script>

    <script>
        $(document).ready(function () {
            var textbox = '<%=TextBoxdatepickerEndDate.ClientID%>';
            $('#' + textbox).datepicker();
        });
    </script>

    <div class="AdminBackAddEvent">
 
        <table style="width: 90%; margin-left: 5%;">

            <tr>
                <td colspan="2">
                    <h2 style="color:#1488e0; ">Post an Event</h2>
                </td>
            </tr>

            <tr>
                <td style="width: 10%" >
                    <asp:Label ID="Label1" runat="server" ForeColor="#009933"></asp:Label>
                </td>
            </tr>

            <tr>

                <td style="width: 10%" >
                    <p>Title (*)</p>
                </td>

                <td >
                    <asp:TextBox ID="TextBoxTitle" MaxLength="30" required x-moz-errormessage="Title is required" CssClass="AllTextBox" Width="65%" placeholder="Event Name Here" runat="server"></asp:TextBox>
                     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBoxTitle" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Title is Required"></asp:RequiredFieldValidator>--%>
                </td>

            </tr>

             <tr>
                <td style="width: 10%">
                    <p>Discription</p>
                </td>

                <td>
                
                    <textarea id="TextBoxDiscription" rows="4" runat="server" class="AllTextBox" cols="50" placeholder="Event Discription Here" maxlength="500" style="width: 65%"></textarea>
                </td>
            </tr>

            <tr>
                <td style="width: 15%; line-height: 1px;">
                    <p><br />Event Date (*)</p>
                </td>

                <td>
                   <%-- <input type="text" id="datepicker" runat="server">--%>
                    <%--<input type="text" ID="datepicker" placeholder="Click Here & Pick" runat="server" class="AllTextBox"  >--%>
                    <asp:TextBox ID="TextBoxdatepickerEndDate" required x-moz-errormessage="Event Date is required" Width="30%" placeholder="Click Here & Pick" CssClass="AllTextBox"  runat="server"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxdatepickerEndDate" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage=" Event Date is Required"></asp:RequiredFieldValidator>--%>
                    <%--<asp:TextBox ID="datepicker" runat="server"></asp:TextBox>--%>
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
