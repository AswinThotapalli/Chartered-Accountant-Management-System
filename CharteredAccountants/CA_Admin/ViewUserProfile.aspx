<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ViewUserProfile.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ViewUserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="AdminBackAddEvent">
         <a href="ChangePassword.aspx"> <span class="TextButton">Change Password</span> </a>  &nbsp;&nbsp; <a href="EditUserProfile.aspx"><span class="TextButton">Edit Your Profile</span></a>

        <h2>Your Tasks History </h2>
        <div style="width:186px; margin-top:9px; margin-left: 12px;">
        <div style="float:left">
            <span style="font-size:15px; line-height: 27px;">Number Of Posts</span>
        </div>
        <div style="float:right">
            <asp:DropDownList ID="DropDownListPageSize" AutoPostBack="true" class=""  style="padding:2px; font-size:15px; width:65px; border: 2px solid #e5e5e5; box-shadow: rgba(0,0,0,0.2) 0px 0px 9px; -moz-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px; -webkit-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px;" runat="server">
                <asp:ListItem Selected="True" Text="15" Value="15"></asp:ListItem>
                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                <asp:ListItem Text="50" Value="50"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
        <br />
        <div class="Scroller" style="width:100%">

                <asp:Label ID="lblNoData" runat="server"></asp:Label>
                <asp:GridView ID="GridViewIssue" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" runat="server" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:TemplateField HeaderText="Name" >
                            <ItemTemplate>
                                <a style="color: black" href="ViewTask.aspx?IssueId=<%#Eval("Id")%>"><%#Eval("Name")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Assignee" HeaderText="Assignee" SortExpression="Assignee" />
                        <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />
                        <asp:BoundField DataField="StatusInline" HeaderText="Status" SortExpression="StatusInline" />
                        <asp:ImageField DataImageUrlField="ImageLink" HeaderText="Image"></asp:ImageField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a style="color: blue" href="AddTask.aspx?Id=<%#Eval("Id")%>">Edit</a> | 
                                <asp:LinkButton ForeColor="Blue" ID="LinkButton1" OnClientClick="return confirm('Are you sure you want to DELETE this Task?')" CommandName="deleteTask" CommandArgument='<%#Eval("Id")%>' runat="server"> Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#1488E0" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />

                </asp:GridView>
                <div style="background-color: #1488E0; color: #FFFFFF; font-size: 15px; margin-top: 6px; padding: 3px;">
                    <asp:Literal ID="LiteralIssue" runat="server"></asp:Literal>
                </div>
                <br />
            </div>
       
    </div>

</asp:Content>
