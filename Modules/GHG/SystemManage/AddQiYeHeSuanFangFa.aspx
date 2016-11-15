<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddQiYeHeSuanFangFa.aspx.cs" Inherits="Modules_GHG_SystemManage_AddQiYeHeSuanFangFa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 60px">
    
        <asp:Label ID="Label1" runat="server" Text="行业名称：" ></asp:Label>
    
        <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 30px" 
            Width="142px">
        </asp:DropDownList>
    
    </div>

    <div style="margin-top:30px; height: 16px; width: 465px; margin-left: 60px;">
    <asp:Label ID="Label2" runat="server" Text="计算公式："></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 30px" 
            Height="18px"></asp:TextBox>
    </div>
    <div>
    <asp:Button ID="Button1" runat="server" Text="保存" Height="23px" 
            style="margin-left: 184px; margin-top: 37px" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
