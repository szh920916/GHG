<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeChaJiGouView.aspx.cs" Inherits="Modules_GHG_SystemManage_HeChaJiGouView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>企业名单查看</title>

    <script type = "text/javascript">
        var EmptyDataText = "无数据"
        function ShowEmptyDataHeader() {
            var Grid = document.getElementById("<%=GridView1.ClientID%>");
            var cell = Grid.getElementsByTagName("TD")[0];
            if (cell != null && cell.innerHTML == EmptyDataText) {
                document.getElementById("dvHeader").style.display = "block";
            }
        }
        window.onload = ShowEmptyDataHeader;
    </script> 
</head>
<body>
    <form id="form1" runat="server">
    <div id = "dvHeader"  style ="display:none">
     	<table cellspacing="0" rules="all" border="1" id="Table1" style="font-family:Arial;font-size:11pt;width:600px;border-collapse:collapse; ">
		<tr style="color:White;background-color:Green; ">
			<th scope="col" style="width:150px;">组织机构代码</th>
            <th scope="col" style="width:200px;">核查机构名称</th>
			<th scope="col" style ="width:150px">地市编号</th>
			<th scope="col" style="width:200px;">所属行业</th>
			
            <th scope="col" style ="width:200px">详细地址</th>
            <th scope="col" style ="width:150px">联系人</th>
            <th scope="col" style ="width:200px">联系电话</th>
            <th scope="col" style ="width:150px">邮编</th>
            
		</tr>
		</table>
    </div> 
    <div>
     <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns = "false" Font-Names = "Arial"  EmptyDataText = "暂无数据，请填报！"
        Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  
        HeaderStyle-BackColor = "green" HeaderStyle-ForeColor = "white" AllowPaging = "true"
         PagerStyle-HorizontalAlign ="Center" 
            onpageindexchanging="GridView1_PageIndexChanging" PageSize="5"  >
       <Columns>
        <asp:BoundField ItemStyle-Width = "350px" DataField = "HeChaJiGouDaiMa" HeaderText = "组织机构代码" />
        <asp:BoundField ItemStyle-Width = "300px" DataField = "HeChaJiGouMingCheng" HeaderText = "核查机构名称"/>
        <asp:BoundField ItemStyle-Width = "200px" DataField = "SuoShuDiShi" HeaderText = "所属地市"/>
        <asp:BoundField ItemStyle-Width = "200px" DataField = "HangYeMingCheng" HeaderText = "所属行业"/>
        <asp:BoundField ItemStyle-Width = "230px" DataField = "XiangXiDiZhi" HeaderText = "详细地址"/>
         <asp:BoundField ItemStyle-Width = "150px" DataField = "LianXiRen" HeaderText = "联系人"/>
        <asp:BoundField ItemStyle-Width = "200px" DataField = "LianXiTelNum" HeaderText = "联系电话"/>
         <asp:BoundField ItemStyle-Width = "150px" DataField = "Email" HeaderText = "邮编" />
       </Columns> 

    </asp:GridView>
    </div>
    </form>
</body>
</html>
