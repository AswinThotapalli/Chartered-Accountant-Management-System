<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ViewTask.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ViewIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

     <div class="AdminBackAddEvent" style="width:50%; margin-left:23%;">

         <h2 style="text-align:center; color:#1488e0">Task</h2>

        <div style="text-align:center;">
            <asp:Label ID="LabelStatusRemaining" runat="server"   ForeColor="Red"></asp:Label>
            <asp:Label ID="LabelStatusFinished" runat="server"  ForeColor="Green"></asp:Label>
        </div>

        <table style="width: 56% ; margin-left:20%;">
                <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <p>Name</p>
                            </td>

                            <td>
                                <asp:Label ID="lblName" CssClass="FontSize" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <p>Discription</p>
                            </td>

                            <td>
                                <asp:Label ID="lblDiscription" CssClass="FontSize" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <p>Assignee</p>
                            </td>

                            <td>
                                <asp:Label ID="lblAssignee" CssClass="FontSize" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <p>Priority</p>
                            </td>

                            <td>
                                <asp:Label ID="lblPriority" CssClass="FontSize" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <p>Issue Image</p>
                            </td>

                            <td>
                                <asp:Image Width="200px" CssClass="FontSize" ID="ImageIssue" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <p>Status</p>
                            </td>

                            <td>
                                <asp:DropDownList CssClass="AllTextBox" ID="DropDownListStatus" runat="server" Width="120px">
                                    <asp:ListItem Text="Remaining" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Finished" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                               <asp:LinkButton ID="LinkButton1" OnClick="LinkButton_ClickChangeStatus" ForeColor="Green" runat="server">Change</asp:LinkButton>
                                <br /> <asp:Label ID="LabelChangeStatus" runat="server" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>





            <tr>
                <td>
                    <table> 
                        <tr>
                            <td colspan="2">
                                <p>Comment</p>
                                <textarea id="TextBoxComment" rows="4" runat="server" class="AllTextBox" cols="70" placeholder="Your Comment Here" maxlength="500" style="width: 65%"></textarea>
                                <br />
                                <asp:Label ID="lblNoComment" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
             </tr>

            <tr>
                <td>
                    <table>
                        <tr> 
                            <td colspan="2">
                                <asp:LinkButton ID="LinkButton2" OnClick="LinkButton_ClickPostComment" ForeColor="Green" runat="server">Post Your Comment</asp:LinkButton>
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>


          <tr> 
                <td>
                    <br />
                    <asp:Label ID="lblCommentTitle" Font-Bold="true" Font-Size="Medium" runat="server"></asp:Label>
                    <br /> <br />
                </td>
            </tr> 
           <tr>     <td>
                    <asp:Panel ID="Panel1" runat="server">
                       
                    </asp:Panel>


                </td>
            </tr>

        </table>

   </div>

</asp:Content>
