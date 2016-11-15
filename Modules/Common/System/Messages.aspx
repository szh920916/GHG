<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>提示信息</title>
<style type="text/css">
.style3 {
	font-size: 18px;
	font-weight: bold;
}
</style>
</head>
<body bgcolor="#EEEEEE" Scroll="no">
    
    <form id="form1" runat="server">
    <div>
    <table width="100%" height="100%"  border="0" cellpadding="0" cellspacing="0">
      <tr height="20%"><td>&nbsp;</td></tr>
	  <tr>
        <td align="center" valign="top">
		
	      <table width="200" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td height="48" valign="middle" background="../../../Themes/Blue/Images/MessageIcon/MessageHead.gif"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="7%" height="8"></td>
          <td width="93%" align="left"></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><span class="style3"><%=Mtitle%></span></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td background="../../../Themes/Blue/Images/MessageIcon/MessageBody.gif"><table width="100%" style="table-layout:fixed;"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="6%">&nbsp;</td>
            <td width="11%" height="120"><asp:Image ID="imgMassage" runat="server"/></td>
          <td width="77%" align="left"><table width="100%"  border="0" cellspacing="10" cellpadding="0">
                <tr>
                  <td style="word-break : break-all; "><%=Mbody%></td>
                </tr>
                      </table></td>
            <td width="6%">&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td align="left"><asp:Button runat="server" ID="btnConfirm" Text="确定" OnClick="btnConfirm_Click" width="100" height="30" />
            </td>
            <td> <asp:HiddenField ID="txtMbuttonUrl" runat="server" />&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td><img src="../../../Themes/Blue/Images/MessageIcon/MessageEnd.gif" width="459" height="29" /></td>
      </tr>
    </table>		</td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
