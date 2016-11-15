<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoGaoShenHe.aspx.cs" Inherits="Modules_GHG_SystemManage_BaoGaoShenHe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>报告审核</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="企业组织机构代码："></asp:Label>
    
        <asp:DropDownList ID="DropDownList1" runat="server" Width="116px" 
            AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="企业名称："></asp:Label>
    
        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
    
        <br />
        <br />
    
        <br />
    
    </div>
    <asp:Label ID="Label3" runat="server" Text="审核意见："></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="TextBox2" runat="server" Height="101px" TextMode="MultiLine" 
        Width="307px"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="通过" onclick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" style="margin-left: 76px" Text="不通过" 
        Width="53px" onclick="Button2_Click" />
    </form>
</body>
</html>
