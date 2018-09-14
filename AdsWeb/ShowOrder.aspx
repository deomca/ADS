<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="ShowOrder.aspx.cs" Inherits="AdsWeb.ShowOrder" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   
   <head>
        <%--<script type="text/javascript" language="javascript">
        function submitChoice(btnObj) {

            if (document.getElementById('<%= btnSubmit.ClientID%>') != null) {

                if (document.getElementById('<%= drpRating.ClientID%>').value == 0) {

                    var answer = confirm("Are you SURE you want to give this album a ZERO rating?\r\n\r\nPress 'OK' to Confirm ZERO rating.\r\nPress 'Cancel' to correct and submit again.")
                    if (answer) {

                    }
                    else {

                        return false;
                    }
                }

            }
        }

        function popwinHistory(OrderId)
         {
             wn = window.open("orderHistory.aspx?ORDERID=" + OrderId, "ADSOrderHistory", "width=600,height=600");
            wn.focus();
        }


            </script>--%>
    </head>
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td align="left" style="padding-left: 10px; padding-right: 10px;">
                <br>
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <asp:Label ID="lblAdsId" type="hidden" runat="server" />
                    <tbody>
                        <tr>
                            <td width="7" height="9">
                                <img width="7" height="9" src="images/ivoryFilledLeftCurve.jpg">
                            </td>
                            <td background="images/ivoryFilledTopBg.jpg">
                            </td>
                            <td width="8" height="9">
                                <img width="7" height="9" src="images/ivoryFilledRightCurve.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td background="images/ivoryFilledLeftBg.jpg">
                            </td>
                            <td valign="top" height="20" bgcolor="#feffdb" align="left">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td width="150" align="left">
                                                <span class="maroonHeader">Order ID :</span>
                                                <asp:Label ID="lblOrderId" runat="server" />
                                            </td>
                                            <td width="150" align="left">
                                                <span class="maroonHeader">Event ID: </span>
                                                <asp:TextBox ID="txtEventId" Width="80" runat="server"></asp:TextBox>
                                                <td width="150" align="left">
                                                    <span class="maroonHeader">Studio ID:</span>
                                                    <asp:Label ID="lblStudioId" runat="server" />
                                                </td>
                                                <td width="200" align="left">
                                                    <span class="maroonHeader">Status: </span>
                                                    <asp:DropDownList Width="100" ID="drpCurrentStatusId" runat="server">
                                                        <asp:ListItem Text="InDesign" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="InQa" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="FinalQa" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="InSubmission" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="OnHold" Value="5"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="200" align="left">
                                                    <span class="maroonHeader">Allocated to: </span>
                                                    <asp:DropDownList Width="100" ID="drpUserId" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td background="images/ivoryFilledRightBg.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td height="1" class="ivoryBGLine" colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td background="images/ivoryFilledLeftBg.jpg">
                            </td>
                            <td bgcolor="#feffdb" align="left">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                    <tbody>
                                        <tr>
                                            <td width="50%" valign="top">
                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="55">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Priority:
                                                            </td>
                                                            <td height="20">
                                                                <asp:RadioButtonList ID="rbPriortiy" runat="server" RepeatColumns="4">
                                                                    <asp:ListItem Value="1" Text="Regular"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Priority"><font color="red">Priority</font></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Priority - ProcessNow"><font color="red">Priority - ProcessNow</font></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="Priority - REDO"><font color="red">Priority - REDO</font></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Folder:
                                                            </td>
                                                            <td height="20">
                                                                <asp:TextBox ID="txtFolderName" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Pages:
                                                            </td>
                                                            <td height="20">
                                                                <asp:TextBox Width="40" ID="txtPages" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Bind:
                                                            </td>
                                                            <td height="20">
                                                                <asp:DropDownList Width="100" ID="drpBind" runat="server">
                                                                    <asp:ListItem Text="Flush Mount" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Matted" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Style:
                                                            </td>
                                                            <td height="20">
                                                                <asp:DropDownList Width="160" ID="drpStyle" runat="server">
                                                                    <asp:ListItem Text="Traditional" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Contemporary/Modern" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Photojournalistic" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="Trendy/Hip" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="FavsBeta" Value="5"></asp:ListItem>
                                                                    <asp:ListItem Text="Consumer - Trendy/Hip" Value="6"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Size:
                                                            </td>
                                                            <td height="20">
                                                                <asp:DropDownList Width="220" ID="drpSize" runat="server">
                                                                    <asp:ListItem Text="Square - 12x12, 10x10, 8x8, 5x5" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Vertical - 12x18, 10x15, 8x12, 6x9, 4x6" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Vertical - 11x14, 10x12.5, 8x10, 6x7.5, 4x5" Value="3"></asp:ListItem>
                                                                    <asp:ListItem Text="Horizontal - 11x14, 10x13, 8x10, 6x8, 4x5" Value="4"></asp:ListItem>
                                                                    <asp:ListItem Text="10x10 Leather Craftsmen 800 series" Value="5"></asp:ListItem>
                                                                    <asp:ListItem Text="10x10 Zookbinders Matted Album" Value="6"></asp:ListItem>
                                                                    <asp:ListItem Text="Vertical - 11x14, 10x12.5, 8x10, 6x8, 4x5" Value="7"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" colspan="2">
                                                                <br />
                                                                <span class="maroonHeader">Original Album Id:</span> <font color="red">
                                                                    <asp:Label ID="lblOriginalId" runat="server"></asp:Label></font>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" colspan="2">
                                                                <br />
                                                                <span class="maroonHeader">Image List:</span>
                                                                <br />
                                                                <br />
                                                                <asp:Label ID="lblImageList" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" colspan="2">
                                                                <br />
                                                                <span class="maroonHeader">Original Instructions:</span>
                                                                <br />
                                                                <br />
                                                                <asp:Label ID="lblInstruction" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" colspan="2">
                                                                <br>
                                                                <br>
                                                                <span class="maroonHeader">Add New Instruction:</span>
                                                                <asp:Label ID="lblNewInstruction" runat="server"></asp:Label>
                                                                <asp:TextBox ID="txtInstructions" runat="server" Columns="50" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td width="10">
                                            </td>
                                            <td width="1" class="ivoryBGLine">
                                            </td>
                                            <td width="10" valign="top">
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="100" class="maroonHeader">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Last Designer:
                                                            </td>
                                                            <td height="20">
                                                                <asp:Label ID="lblLastDesigner" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Last QA:
                                                            </td>
                                                            <td height="20">
                                                                <asp:Label ID="lblLastQa" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" class="maroonHeader">
                                                                Last Comment:
                                                            </td>
                                                            <td height="20">
                                                                <asp:Label ID="lblLastComment" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br>
                                                <asp:Panel ID="pnlSubmit" runat="server" class="blackBoldText" GroupingText="SUBMIT">
                                                    <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td height="25" class="maroonHeader">
                                                                    Album ID:
                                                                </td>
                                                                <td height="20">
                                                                    <asp:TextBox Width="80" ID="txtAlbumId" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="25" class="maroonHeader">
                                                                    Images:
                                                                </td>
                                                                <td height="20">
                                                                    <asp:TextBox ID="txtImages" Width="80" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="25" class="maroonHeader">
                                                                    Album Name:
                                                                </td>
                                                                <td height="20">
                                                                    <asp:TextBox ID="txtAlbumName" Width="150" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" class="maroonHeader">
                                                                    Submitting As:
                                                                </td>
                                                                <td height="20">
                                                                    <asp:DropDownList Width="90" ID="drpSubmitAs" runat="server">
                                                                        <asp:ListItem Text="Completed" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Hold" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="Return" Value="3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <span id="spnRating" runat="server" class="maroonHeader">Rating: </span>
                                                                    <asp:DropDownList Width="40" ID="drpRating" runat="server">
                                                                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" class="maroonHeader">
                                                                    Comments:
                                                                </td>
                                                                <td height="20">
                                                                    <asp:TextBox ID="txtQcComment" runat="server" Columns="50" Rows="5" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="100" height="25" class="maroonHeader">
                                                                    Submit to:
                                                                </td>
                                                                <td height="20">
                                                                    <asp:DropDownList Width="100" ID="drpSubmitTo" runat="server">
                                                                        <asp:ListItem Text="InDesign" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="InQa" Value="2"></asp:ListItem>
                                                                        <asp:ListItem Text="FinalQa" Value="3"></asp:ListItem>
                                                                        <asp:ListItem Text="InSubmission" Value="4"></asp:ListItem>
                                                                        <asp:ListItem Text="OnHold" Value="5"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Button ID="btnSubmit" Text="Submit" OnClientClick="return submitChoice();" runat="server"
                                                                        OnClick="btnSubmit_Click" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                                <br>
                                                <br>
                                                <asp:Button ID="btnSubmitAdmin" Text="Save Changes" runat="server" OnClick="btnSubmitAdmin_Click" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td background="images/ivoryFilledRightBg.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td height="1" class="ivoryBGLine" colspan="3">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left" style="padding-left: 10px; padding-right: 10px;">
                <br>
                <table width="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blueBgColor">
                                    <tbody>
                                        <tr>
                                            <td width="7" height="9">
                                                <img width="7" height="9" src="images/blueFilledLeftCurve.jpg">
                                            </td>
                                            <td background="images/blueFilledTopBg.jpg">
                                            </td>
                                            <td width="7" height="9">
                                                <img width="7" height="9" src="images/blueFilledRightCurve.jpg">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td background="images/blueFilledLeftBg.jpg">
                                            </td>
                                            <td valign="top" height="20" class="blueHeader">
                                                Additional Intructions:
                                            </td>
                                            <td background="images/blueFilledRightBg.jpg">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="1" class="blueBGLine" colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td background="images/blueFilledLeftBg.jpg">
                                            </td>
                                            <td valign="top">
                                                <asp:GridView ID="grdAdditionalIns" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                                    CellPadding="0" CellSpacing="0"  class="blueBgColor" PagerStyle-HorizontalAlign="Right"
                                                    runat="server">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" HeaderText="#">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSeriolNo" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUserBy" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAdditionalInsDate" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField ItemStyle-HorizontalAlign="Left" HeaderText="Instructions" DataField="ADDITIONALINSTRUCTION" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td background="images/blueFilledRightBg.jpg">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="7" height="9">
                                                <img width="7" height="9" src="images/blueFilledLeftBottomCurve.jpg">
                                            </td>
                                            <td background="images/blueFilledBotomBg.jpg">
                                            </td>
                                            <td width="7" height="9">
                                                <img width="7" height="9" src="images/blueFilledRightBottomCurve.jpg">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td width="20">
                                &nbsp;
                            </td>
                            <td width="500" valign="top">
                                <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blueBgColor">
                                    <tr>
                                        <td width="7" height="9">
                                            <img width="7" height="9" src="images/blueFilledLeftCurve.jpg">
                                        </td>
                                        <td background="images/blueFilledTopBg.jpg">
                                        </td>
                                        <td width="7" height="9">
                                            <img width="7" height="9" src="images/blueFilledRightCurve.jpg">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td background="images/blueFilledLeftBg.jpg">
                                        </td>
                                        <td align="right" valign="top" height="20" class="blueHeader">
                                            All Comments:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                                ID="hypGetHistory" Text="View Complete History" CommandName="View" runat="server"></asp:LinkButton>
                                        </td>
                                        <td align="right" background="images/blueFilledRightBg.jpg">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="1" class="blueBGLine" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td background="images/blueFilledLeftBg.jpg">
                                        </td>
                                        <td valign="top">
                                            <asp:GridView ID="GridUserHistory" Width="100%" AutoGenerateColumns="false" GridLines="None"
                                                CellPadding="0" CellSpacing="0" class="blueBgColor" PagerStyle-HorizontalAlign="Right"
                                                runat="server">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBy" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCommentDate" ItemStyle-HorizontalAlign="Left" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ItemStyle-HorizontalAlign="Left" HeaderText="Comments" DataField="COMMENTS" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td background="images/blueFilledRightBg.jpg">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="7" height="9">
                                            <img width="7" height="9" src="images/blueFilledLeftBottomCurve.jpg">
                                        </td>
                                        <td background="images/blueFilledBotomBg.jpg">
                                        </td>
                                        <td width="7" height="9">
                                            <img width="7" height="9" src="images/blueFilledRightBottomCurve.jpg">
                                        </td>
                                    </tr>
                                </table>
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
        <tr>
            <td height="1" bgcolor="#666666">
            </td>
        </tr>
    </table>
</asp:Content>
