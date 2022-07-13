<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ClientSearchGrid.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ClientSearchGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="AdminBackAddEvent">
        <asp:GridView ID="GridViewIssue" AutoGenerateColumns="False" runat="server" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Assignee" HeaderText="Assignee" SortExpression="Assignee" />
                        <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />
                        <asp:BoundField DataField="StatusInline" HeaderText="Status" SortExpression="StatusInline" />
                        <asp:ImageField DataImageUrlField="ImageLink" HeaderText="Image"></asp:ImageField>
                    </Columns>

                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</asp:Content>
