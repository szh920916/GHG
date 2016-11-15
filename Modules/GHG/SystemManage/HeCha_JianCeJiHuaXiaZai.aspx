<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeCha_JianCeJiHuaXiaZai.aspx.cs" Inherits="Modules_GHG_SystemManage_HeCha_JianCeJiHuaXiaZai" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <asp:Label ID="Label1" runat="server" Text="企业组织机构代码："></asp:Label>
    &nbsp;
    <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" 
        style="margin-left: 0px" Width="123px">
    </asp:DropDownList>
    <br />
    <br />
    报告年份：<asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="Page_Load">
    </asp:DropDownList>
    &nbsp;&nbsp;
  
    版本：<asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="57px" 
       >
       <asp:ListItem>初版</asp:ListItem>
        <asp:ListItem>终版</asp:ListItem>
        
    </asp:DropDownList>
    <br />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="下载" onclick="Button1_Click1" />
    </form>
</body>
</html>
