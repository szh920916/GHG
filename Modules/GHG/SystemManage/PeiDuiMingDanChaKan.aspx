<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PeiDuiMingDanChaKan.aspx.cs" Inherits="Modules_GHG_SystemManage_PeiDuiMingDanChaKan" %>

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
			<th scope="col" style="width:150px;">企业组织机构代码</th>
            <th scope="col" style="width:200px;">企业名称</th>
			<th scope="col" style ="width:150px">核查机构代码</th>
			<th scope="col" style="width:200px;">核查机构名称</th>
			
            <th scope="col" style ="width:200px">年份</th>
           
		</tr>
		</table>
    </div> 
    <div>
     <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns = "false" Font-Names = "Arial"  EmptyDataText = "暂无数据，请填报！"
        Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" Width = "1020px" 
        HeaderStyle-BackColor = "green" HeaderStyle-ForeColor = "white" AllowPaging = "true"
         PagerStyle-HorizontalAlign ="Center" 
            onpageindexchanging="GridView1_PageIndexChanging" PageSize="5"  >
       <Columns>
        <asp:BoundField ItemStyle-Width = "220px" DataField = "企业组织机构代码" HeaderText = "企业组织机构代码" />
        <asp:BoundField ItemStyle-Width = "200px" DataField = "企业名称" HeaderText = "企业名称"/>
        <asp:BoundField ItemStyle-Width = "200px" DataField = "核查机构代码" HeaderText = "核查机构代码"/>
        <asp:BoundField ItemStyle-Width = "200px" DataField = "核查机构名称" HeaderText = "核查机构名称"/>
        <asp:BoundField ItemStyle-Width = "200px" DataField = "年份" HeaderText = "年份"/>
      
       </Columns> 

    </asp:GridView>
    </div>
    </form>
</body>
</html>
