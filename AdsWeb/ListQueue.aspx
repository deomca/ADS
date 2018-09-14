<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListQueue.aspx.cs" Inherits="AdsWeb.ListQueue" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td align="left" style="padding-left: 10px; padding-right: 10px;">
                <br>
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/ivoryFilledLeftCurve.jpg">
                            </td>
                            <td style=" background-image:images/ivoryFilledTopBg.jpg">
                            </td>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/ivoryFilledRightCurve.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td style=" background-image:images/ivoryFilledLeftBg.jpg">
                            </td>
                            <td class="ivoryBGColor">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td width="50">
                                                <span class="maroonHeader">Queue:</span>
                                            </td>
                                            <td width="200" align="left" class="maroonHeader">
                                                <asp:Label ID="lblQueue" runat="server" />
                                            </td>
                                            <td width="50" align="left">
                                                &nbsp;
                                            </td>
                                            <td id="tdView" runat="server" width="300" align="left">
                                                <span class="maroonHeader">View:</span><asp:LinkButton class="maroonHeader" ID="lnkUnAllocate"
                                                    Text="UnAllocated" runat="server" OnClick="lnkUnAllocate_Click"></asp:LinkButton>
                                                |<asp:LinkButton class="maroonHeader" ID="lnkAllocate" Text="Allocated" runat="server"
                                                    OnClick="lnkAllocate_Click"></asp:LinkButton>
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                            <td align="left">
                                                &nbsp;
                                            </td>
                                            <td width="125" align="left" class="maroonHeader">
                                                Number of Orders:
                                            </td>
                                            <td width="40" align="left" class="maroonHeader">
                                                <asp:Label ID="lblNoofOrders" runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td background="images/ivoryFilledRightBg.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/ivoryFilledLeftBottomCurve.jpg">
                            </td>
                            <td style=" background-image:images/ivoryFilledBottomBg.jpg">
                            </td>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/ivoryFilledRightBottomCurve.jpg">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 10px; padding-right: 10px;">
                <br>
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/blueFilledLeftCurve.jpg">
                            </td>
                            <td style=" background-image:images/blueFilledTopBg.jpg">
                            </td>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/blueFilledRightCurve.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td style=" background-image:images/blueFilledLeftBg.jpg">
                            </td>
                            <td class="blueBgColor">
                                <br />
                                 <%--onselectedindexchanged="grdAds_SelectedIndexChanged"--%>
                                <asp:GridView ID="grdAds" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                    CellPadding="0" CellSpacing="0" HeaderStyle-BackColor="#BBCFDE" PagerStyle-HorizontalAlign="Right"
                                    EmptyDataRowStyle-ForeColor="Red" AllowPaging="true" PageSize="20" 
                                    runat="server">
                                    <EmptyDataTemplate>
                                        <div style="height: 200px; vertical-align: middle">
                                            <center>
                                                <span style="vertical-align: middle" class="maroonHeader">This Queue is Empty</span>
                                            </center>
                                        </div>
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left"  HeaderText="#">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSeriolNo" ItemStyle-HorizontalAlign="left" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField  ItemStyle-HorizontalAlign="left" HeaderText="Order ID"
                                            DataField="Order_Id" />
                                        <asp:TemplateField  ItemStyle-HorizontalAlign="left" HeaderText="Order Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrderDate" ItemStyle-HorizontalAlign="left" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-HorizontalAlign="left" HeaderText="Priority">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPriority" ItemStyle-HorizontalAlign="left" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-HorizontalAlign="left" HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" ItemStyle-HorizontalAlign="left" runat="server"></asp:Label>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-HorizontalAlign="left" HeaderText="Allocated">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAllocated" ItemStyle-HorizontalAlign="left" runat="server"></asp:Label>
                                            </ItemTemplate>
                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-HorizontalAlign="left" HeaderText="Last Designer">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLastDesigner" ItemStyle-HorizontalAlign="left" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  ItemStyle-HorizontalAlign="left" HeaderText="Last Qa">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLastQa" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField  ItemStyle-HorizontalAlign="left" HeaderText="Last Comment">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLastComment" ItemStyle-HorizontalAlign="left" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-VerticalAlign="top" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Right"
                                            HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="hypTake" Text="TAKE/" CommandName="Save" runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-VerticalAlign="top"  ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hypView" Text="VIEW DETAILS" runat="server"></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                            <td style=" background-image:images/blueFilledRightBg.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/blueFilledLeftBottomCurve.jpg">
                            </td>
                            <td style=" background-image:images/blueFilledBotomBg.jpg">
                            </td>
                            <td height="9" width="7">
                                <img height="9" width="7" src="images/blueFilledRightBottomCurve.jpg">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="1" bgcolor="#666666">
            </td>
        </tr>
    </table>
</asp:Content>
