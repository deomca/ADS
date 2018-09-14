<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="AdsWeb.ChangePassword1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <head>
        <title></title>
        <script language="javascript" type="text/javascript">
        </script>
        <link href="Styles/Styles.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <table height="100%" width="100%" cellspacing="0" cellpadding="0" border="0" runat="server">
            <tr>
                <td align="left" style="padding-left: 10px; padding-right: 10px;">
                    <center>
                        <table width="300" id="tblPassword" runat="server" cellspacing="0" cellpadding="8"
                            border="0" class="imageIvoryBorder">
                            <tbody>
                                <tr>
                                    <td align="center" class="maroonHeader" colspan="2">
                                        Change Password
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1" valign="top" class="ivoryBGLine" colspan="2" />
                                </tr>
                                <tr>
                                    <td valign="middle" align="right">
                                        Current Password:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtCurrentPass" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" align="right">
                                        New Password:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNewPass" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </center>
                    <!-- Content Ends -->
                </td>
                <td>
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
