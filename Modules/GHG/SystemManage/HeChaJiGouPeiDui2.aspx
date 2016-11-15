<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeChaJiGouPeiDui2.aspx.cs"
    Inherits="Modules_GHG_SystemManage_HeChaJiGouPeiDui" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="核查机构代码："></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Width="120px"
        onselectedindexchaged="Page_Load" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged1">
    </asp:DropDownList>
    &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="核查机构名称："></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="100px"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="企业机构代码："></asp:Label>
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="120px"
        OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="企业机构名称："></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="保存名单" />
    </p>
    </form>
</body>
</html>
