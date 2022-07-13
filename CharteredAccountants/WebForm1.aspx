<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CharteredAccountantsFYP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="DropdownlistImages/DropDownList.css" rel="stylesheet" />
    <script src="DropdownlistImages/jquery-1.6.1.min.js"></script>
    <script src="DropdownlistImages/jquery_dropdown.js"></script>

    <script type="text/javascript">
        $(document).ready(function (e) {
            try {
                $("#DropDownListAssignee").msDropDown();
            } catch (e) {
                alert(e.message);
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList ID="DropDownListAssignee" Height="50px" Width="170px" runat="server"></asp:DropDownList>
    </div>
    </form>
</body>
</html>
