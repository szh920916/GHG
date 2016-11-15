<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeChaBaoGaoJinDu.aspx.cs" Inherits="Modules_GHG_SystemManage_HeChaBaoGaoJinDu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="height: 59px; width: 611px; margin-left: 100px; margin-top: 43px">
    <form id="form1" runat="server">
    <div style="margin-top:30px; height: 23px; width: 532px;">
    
        <asp:Label ID="Label1" runat="server" Text="已上传" Font-Size="Larger"></asp:Label>
    
        <asp:Label ID="Label2" runat="server" Font-Size="Larger"></asp:Label>
    
        <asp:Label ID="Label3" runat="server" Text="份核查报告,未上传" Font-Size="Larger"></asp:Label>
    
        <asp:Label ID="Label4" runat="server" Font-Size="Larger"></asp:Label>
    
        <asp:Label ID="Label5" runat="server" Text="份！" Font-Size="Larger"></asp:Label>
    
    </div>
    <div style="margin-top:30px">
   
        <asp:Label ID="Label6" runat="server" Text="按地区查询：" Font-Size="Larger"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="26px" 
            style="margin-left: 75px" Width="148px" Font-Size="Larger">
        </asp:DropDownList>

         </div>

         <div style="margin-top:30px">
   
        <asp:Label ID="Label7" runat="server" Text="按年份查询：" Font-Size="Larger"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" Height="26px" 
            style="margin-left: 75px" Width="148px" Font-Size="Larger">
        </asp:DropDownList>

         </div>
         <div style="margin-top:30px">
   
        <asp:Label ID="Label8" runat="server" Text="按核查机构查询：" Font-Size="Larger"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" Height="26px" 
            style="margin-left: 37px" Width="148px" Font-Size="Larger">
        </asp:DropDownList>

         </div>
    </form>
</body>
</html>
