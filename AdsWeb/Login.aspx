<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AdsWeb.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <center>
        <form id="form1" runat="server">
        <div>
            <table height="400" width="600" cellspacing="0" cellpadding="0" border="0" >
                <tbody>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td width="11" background="images/pageLineBgLeft.jpg">
                            &nbsp;
                        </td>
                        <td width="600" valign="top" bgcolor="#ffffff">
                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                       <%-- <td width="200">
                                                            <img height="50" width="125" alt="" src="images/logo.jpg"><strong>ADS6.0</strong>
                                                        </td>--%>
                                                        <td valign="bottom">
                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td height="40" valign="middle" align="right" style="padding-right: 10px; padding-top: 10px;
                                                                            padding-bottom: 20px;">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td height="22" width="22">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="539">
                                                                                        </td>
                                                                                        <td width="204" align="center">
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="11" background="images/topShadedBg.gif">
                                        </td>
                                    </tr>
                                    <!-- Content Starts -->
                                    <tr>
                                        <td align="left" style="padding-left: 10px; padding-right: 10px;">
                                            <br>
                                            <form id="form2" >
                                            <table width="300" cellspacing="0" cellpadding="0" border="0" align="center" class="imageIvoryBorder">
                                                <tbody>
                                                    <tr>
                                                        <td height="18" valign="top" align="center" class="maroonHeader" colspan="2">
                                                            Login Here!
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="1" valign="top" class="ivoryBGLine" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="32" valign="center" align="right">
                                                            LoginId:
                                                        </td>
                                                        <td width="207" valign="center">
                                                            <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30" valign="center" align="right">
                                                            Password:
                                                        </td>
                                                        <td valign="center">
                                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="middle">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnLogin" runat="server" Text="L O G I N" OnClick="btnLogin_Click1" />
                                                            <br>
                                                            <br>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            </form>
                                            <!-- Content Ends -->
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
                                    <tr>
                                        <td height="1" bgcolor="#666666">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <br>
                                            &copy; 2007-2008 Paragon IT Services Pvt. Ltd., New Delhi - INDIA
                                            <br>
                                            <br>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td width="11" background="images/pageLineBgRight.jpg">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        </form>
    </center>
</body>
</html>
