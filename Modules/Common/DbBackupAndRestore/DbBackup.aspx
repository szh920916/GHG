<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DbBackup.aspx.cs" Inherits="Modules_Common_DbBackup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据库备份</title>
</head>
<body style="font-size: small">
    <form id="form1" runat="server">
    <div style="width: 100%;" align="center">
        <div>
            <asp:Label ID="Label1" runat="server" Text="操作数据库：" Width="120px" Style="text-align: right"></asp:Label>
            <asp:DropDownList ID="DDLDataBase" runat="server" Width="300px">
            </asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="备份名称：" Width="120px" Style="text-align: right"></asp:Label>
            <asp:TextBox ID="txtFileName" runat="server" Width="300px"></asp:TextBox>
        </div>
        <div style="color:#FF0000;">
            提示：文件名称若为空，将以当前年月日为名称进行备份。
        </div>
        <div>
            <asp:Button ID="btnRestore" runat="server" Text="备份数据库" 
                onclick="btnBackup_Click" />
        </div>
    </div>
    </form>
</body>
</html>
