<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.HomeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div style="width: 487px; margin-top:9px; margin-left: 12px;">
        

        <div class="TextBoxSearch" style="">
                <asp:TextBox ID="TextBoxQuickSearch" ForeColor="#1488e0" BorderWidth="2px"  Font-Italic="true" placeholder="Search Client" ToolTip="Search Client By Name, Email, CNIC, Incorporation No., RegistrationNo" CssClass="quickSearchTexBox AllTextBox" Height="14px" runat="server"></asp:TextBox>
             <asp:ImageButton ID="ImageButton2" style="width: 13%;height:13%;margin-top: -4px;" OnClick="ImageButton1_Click" ImageUrl="~/images/searchIcon.png" runat="server" />
        </div>

         <div style="float:none; width:200px ">

            <span style="font-size:15px; line-height: 27px;">Number Of Posts</span>

  
            <asp:DropDownList ID="DropDownListPageSize" AutoPostBack="true" class=""  style="padding:2px; font-size:15px; width:65px; border: 2px solid #e5e5e5; box-shadow: rgba(0,0,0,0.2) 0px 0px 9px; -moz-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px; -webkit-box-shadow: rgba(0,0,0,0.2) 0px 0px 8px;" runat="server">
                <asp:ListItem Selected="True" Text="15" Value="15"></asp:ListItem>
                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                <asp:ListItem Text="50" Value="50"></asp:ListItem>
            </asp:DropDownList>
   
        
        </div>

    </div>
     


    <aside class="IssueTrackingContent">
        <article>
            <div id="issueTrackingHeadBar">
                <p>
                    <b>Current Tasks</b>
                </p>
            </div>
            <div class="GridAdmin_User Scroller">

                <asp:Label ID="lblNoData" runat="server"></asp:Label>
                <asp:GridView ID="GridViewIssue" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView_RowDeleting" runat="server" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5">
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
        </article>
    </aside>

    <aside class="EventTrackingContent">
        <article>
            <div id="EventTrackingHeadBar">
                <p>
                    <b>Events</b>
                </p>
            </div>

            <div class="GridAdmin_User Scroller" >
                <asp:Label ID="lblNoEvents" runat="server"></asp:Label>
                <asp:GridView ID="GridViewEvent" AutoGenerateColumns="False" runat="server" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView_RowDeleting" Width="100%" BackColor="WhiteSmoke" BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="10" Font-Bold="True" Font-Underline="False" PageSize="5">

                    <Columns>

                        <asp:BoundField DataField="Id" Visible="false" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                        <%--<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"/>--%>
                        <asp:TemplateField HeaderText="Title">
                            <ItemTemplate>
                                <a style="color: black" href="ViewEvent.aspx?EventId=<%#Eval("Id")%>"><%#Eval("Title")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- <asp:BoundField DataField="Discription" HeaderText="Discription" SortExpression="Discription"/>--%>
                        <asp:BoundField DataField="ShortEventDate" HeaderText="Event Date" SortExpression="ShortEventDate" />
                        <asp:BoundField DataField="PosterName" HeaderText="Posted by" SortExpression="PosterName" />
                        <asp:ImageField DataImageUrlField="ImageLink" HeaderText="Image">
                            <%-- <ControlStyle Width="200px"></ControlStyle>--%>
                        </asp:ImageField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <a style="color: blue" href="AddEvent.aspx?ID=<%#Eval("Id")%>">Edit</a> | 
                                <asp:LinkButton ForeColor="Blue" ID="LinkButton1" OnClientClick="return confirm('Are you sure you want to DELETE this Event?')" CommandName="deleteEvent" CommandArgument='<%#Eval("Id")%>' runat="server"> Delete</asp:LinkButton>
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
                    <asp:Literal ID="LiteralEvent" runat="server"></asp:Literal>
                </div>
                <br />
            </div>
        </article>
    </aside>

</asp:Content>

