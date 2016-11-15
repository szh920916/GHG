<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeChaBaoGaoShangChuan.aspx.cs" Inherits="Modules_GHG_DataCollection_TaoCi_HeChaBaoGaoShangChuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;&nbsp;
        <br />
     
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="企业机构代码："></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" Width="100px" 
            AutoPostBack="True" onselectedindexchanged="DropDownList3_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="企业名称："></asp:Label>    
        <asp:TextBox ID="TextBox2" runat="server" Width="100px"></asp:TextBox>
        <br />
        <br />
       
        <asp:Label ID="Label1" runat="server" Text="选择年份："></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" EnableViewState="False" 
        onselectedindexchanged="Page_Load">
    </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="备注："></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Height="85px" Width="236px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:FileUpload ID="FileUpload" runat="server" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="BtnUp" runat="server"  Text="上传" onclick="BtnUp_Click" />
        <br />
    </div>
    </form>
</body>
</html>
