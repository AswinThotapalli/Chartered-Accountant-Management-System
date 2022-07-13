<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="ViewEvent.aspx.cs" Inherits="CharteredAccountantsFYP.CA_Admin.ViewEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="AdminBackAddEvent" style="width:50%; margin-left:23%;">
        <h2 style="text-align:center; color:#1488e0">Event</h2>
        <div style="">
        <table style="width: 56% ; margin-left:20%;">
                <tr>
                <td>
                    <div>
                        <p></p>
                    </div>

                    <table>
                        <tr>
                            <td>
                                <p>Title</p>
                            </td>

                            <td>
                                <asp:Label ID="lblTitle" CssClass="FontSize" runat="server"></asp:Label>
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
                                <p>Event Date</p>
                            </td>

                            <td>
                                <asp:Label ID="lblEventDate" CssClass="FontSize" runat="server"></asp:Label>
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
                                <p>Posted by</p>
                            </td>

                            <td>
                                <asp:Label ID="lblPostedby" CssClass="FontSize" runat="server"></asp:Label>
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
                                <p>Event Image</p>
                            </td>

                            <td>
                                <asp:Image Width="200px" CssClass="FontSize" ID="ImageEvent" runat="server" />
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
                                <asp:Label ID="lblComment" ForeColor="Red" runat="server"></asp:Label>
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
   </div>

</asp:Content>
