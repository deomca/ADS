<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="AdsWeb.OrderHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Paragon IT Services ::: ADS:Beta</title>
    <link href="Styles/Text.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        function finish() {
            opener.document.location = opener.document.location;
            window.close();
        }
</script>

</head>
<body>
<form runat="server" id="form1">
    <table width="500" cellspacing="0" cellpadding="0" border="0" align="center">
        <tbody>
            <tr>
                <td>
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" bgcolor="#ffffff"
                        class="allSideBox">
                        <tbody>
                            <tr>
                                <td width="125">
                                    <img height="50" width="125" src="images/logo.jpg">
                                </td>
                                <td width="81" valign="bottom">
                                    <strong>ADS6.0</strong>
                                </td>
                                <td width="100%" valign="bottom" align="center">
                                    <span class="orderNumberRed">Order#:<asp:Label ID="lblOrderNo" runat="server"></asp:Label></span>
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
                        <table height="400" width="500px" cellspacing="0" cellpadding="0" border="0" class="allSideBox">
                            <tbody>
                                <tr>
                                    <td valign="top" align="left">
                                        <table width="100%" cellspacing="0" cellpadding="3" border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <strong>Order Comment(ADS4):</strong>
                                                        <hr>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="left">
                                                        <b>Order History:</b>
                                                        <table width="100%" cellspacing="0" cellpadding="2" border="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="GridOrderHistory" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                                                        CellPadding="0" CellSpacing="0" class="blueBgColor" PagerStyle-HorizontalAlign="Right"
                                                                        runat="server">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="By">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblBy" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="DateTime">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblOrderDate" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Allocation">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAllocation" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="OrderStatus">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblOrderStatus" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField ItemStyle-HorizontalAlign="Left" HeaderText="Quick Note" DataField="ADDITIONALINSTRUCTION" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <b>Current Time:</b><asp:Label ID="lblCurrentTime" runat="server"></asp:Label> <br>
                                                        <br>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <p align="center">
                                            <input type="submit" onclick="javascript:window.close();" value="CLOSE" name="Submit">
                                        </p>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
