<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="UserHistory.aspx.cs" Inherits="AdsWeb.UserHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td align="left" style="padding-left: 10px; padding-right: 10px;">
                <br />
                <table width="800" cellspacing="0" cellpadding="0" border="0" align="center">
                    <tbody>
                        <tr>
                            <td align="left">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0" bgcolor="#ffffff">
                                    <tbody>
                                        <tr>
                                            <td width="100%" valign="bottom">
                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="200">
                                                                <b>Activity Log :
                                                                    <asp:Label ID="lblActivityLog" runat="server"></asp:Label><br />
                                                                    <br />
                                                                    <span>User:
                                                                        <asp:Label ID="lblUser" runat="server" />
                                                                    </span></b>
                                                            </td>
                                                            <td align="right">
                                                                <span style="font-weight: bold;">Previous Logs: </span>
                                                                <asp:DropDownList ID="drpViewDate" runat="server">
                                                                </asp:DropDownList>
                                                                <asp:Button ID="btnView" Text="VIEW" runat="server" OnClick="btnView_Click" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div>
                                    <table height="400" width="800" cellspacing="0" cellpadding="0" border="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top" align="center">
                                                    <table width="100%" cellspacing="0" cellpadding="3" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" cellspacing="0" cellpadding="2" border="0" bgcolor="silver">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td width="50">
                                                                                    <b>#</b>
                                                                                </td>
                                                                                <td width="100">
                                                                                    <div align="left">
                                                                                        <b>OrderID</b>
                                                                                    </div>
                                                                                </td>
                                                                                <td width="100">
                                                                                    <div align="left">
                                                                                        <b>Allocated</b><strong> </strong>
                                                                                    </div>
                                                                                </td>
                                                                                <td width="100">
                                                                                    <div align="left">
                                                                                        <b>Submitted</b><strong> </strong>
                                                                                    </div>
                                                                                    <strong></strong>
                                                                                </td>
                                                                                <td width="100">
                                                                                    <div align="left">
                                                                                        <strong>Pages</strong></div>
                                                                                </td>
                                                                                <td width="100">
                                                                                    <div align="left">
                                                                                        <strong>Images</strong></div>
                                                                                </td>
                                                                                <td width="100">
                                                                                    <div align="left">
                                                                                        <strong>Time Taken</strong></div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="2" bgcolor="#ffffff" colspan="7">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td bgcolor="#99cc99" align="left" colspan="7">
                                                                                    <b>COMPLETED</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10" bgcolor="#ffffff" colspan="7">
                                                                                    <asp:GridView ID="grdCompleted" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                                                                        CellPadding="0" CellSpacing="0" PagerStyle-HorizontalAlign="Right" EmptyDataRowStyle-ForeColor="Red"
                                                                                        runat="server">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSeriolNo" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblOrderId" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblAllocated" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSubmitted" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPages" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblImages" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTimeTaken" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td bgcolor="#ffcccc" align="left" colspan="7">
                                                                                    <b>HOLD</b>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10" bgcolor="#ffffff" colspan="7">
                                                                                    <asp:GridView ID="GridView1" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                                                                        CellPadding="0" CellSpacing="0" PagerStyle-HorizontalAlign="Right" EmptyDataRowStyle-ForeColor="Red"
                                                                                        runat="server">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSeriolNo" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblOrderId" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblAllocated" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSubmitted" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPages" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblImages" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTimeTaken" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td bgcolor="#cc99ff" align="left" colspan="7">
                                                                                    <b>Sent as REDO</b> (For QA-&gt;Designer and FinalQA-&gt;QA)
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10" bgcolor="#ffffff" colspan="7">
                                                                                    <asp:GridView ID="GridView2" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                                                                        CellPadding="0" CellSpacing="0" PagerStyle-HorizontalAlign="Right" EmptyDataRowStyle-ForeColor="Red"
                                                                                        runat="server">
                                                                                        <Columns>
                                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSeriolNo" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblOrderId" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblAllocated" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblSubmitted" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPages" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblImages" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTimeTaken" ItemStyle-HorizontalAlign="Center" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <br>
                                                                    <br>
                                                                    <div align="left" style="color: black;">
                                                                        <hr>
                                                                        <b>Summary:</b>
                                                                        <table width="100%" cellspacing="0" cellpadding="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td height="30" bgcolor="#99cc99" align="right">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">Completed:</span>
                                                                                    </td>
                                                                                    <td height="30" width="30" bgcolor="#99cc99">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">
                                                                                            <asp:Label ID="lblCompleted" runat="server"></asp:Label></span>
                                                                                    </td>
                                                                                    <td height="30" width="10">
                                                                                        <span style="color: rgb(0, 0, 0);"></span>
                                                                                    </td>
                                                                                    <td height="30" bgcolor="#ffcccc" align="right">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">Sent as Hold:</span>
                                                                                    </td>
                                                                                    <td height="30" width="30" bgcolor="#ffcccc">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">
                                                                                            <asp:Label ID="lblHold" runat="server"></asp:Label></span>
                                                                                    </td>
                                                                                    <td height="30" width="10">
                                                                                        <span style="color: rgb(0, 0, 0);"></span>
                                                                                    </td>
                                                                                    <td height="30" bgcolor="#cc99ff" align="right">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">Returned to a queue below:</span>
                                                                                    </td>
                                                                                    <td height="30" width="30" bgcolor="#cc99ff">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">
                                                                                            <asp:Label ID="lblReturned" runat="server"></asp:Label></span>
                                                                                    </td>
                                                                                    <td height="30" width="10">
                                                                                        <span style="color: rgb(0, 0, 0);"></span>
                                                                                    </td>
                                                                                    <td height="30" bgcolor="#ff0000" align="right">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">REDO Received:</span>
                                                                                    </td>
                                                                                    <td height="30" width="30" bgcolor="#ff0000">
                                                                                        <span style="font-weight: bold; color: rgb(0, 0, 0);">
                                                                                            <asp:Label ID="lblRedo" runat="server"></asp:Label></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <hr>
                                                                    </div>
                                                                    <div align="left">
                                                                        <b>Current Time:</b><asp:Label ID="lblCurrentTime" runat="server"></asp:Label><br>
                                                                        <br>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
