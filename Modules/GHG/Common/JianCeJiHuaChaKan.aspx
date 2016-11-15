<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JianCeJiHuaChaKan.aspx.cs" Inherits="Modules_GHG_DataCollection_TaoCi_JianCeJiHuaChaKan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>监测计划查看</title>



    <script type = "text/javascript">
        var EmptyDataText = "No Records Found"
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
			<th scope="col" style="width:150px;">企业名称</th>
			<th scope="col" style="width:200px;">文件位置</th>
			<th scope="col" style ="width:150px">提交时间</th>
            <th scope="col" style ="width:200px">备注</th>
           <%-- <th scope="col" style ="width:150px">企业组织机构代码</th>--%>
		</tr>
		</table>
    </div> 
    <div>
     <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns = "false" Font-Names = "Arial"  EmptyDataText = "No Records Found"
        Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" Width = "600px" 
        HeaderStyle-BackColor = "green" HeaderStyle-ForeColor = "white" AllowPaging = "true"
         PagerStyle-HorizontalAlign ="Center"  >
       <Columns>
        <asp:BoundField ItemStyle-Width = "150px" DataField = "企业名称" HeaderText = "企业名称" />
        <asp:BoundField ItemStyle-Width = "200px" DataField = "文件位置" HeaderText = "文件位置"/>
        <asp:BoundField ItemStyle-Width = "150px" DataField = "提交时间" HeaderText = "提交时间"/>
        <asp:BoundField ItemStyle-Width = "200px" DataField = "备注" HeaderText = "备注"/>
        <%--<asp:BoundField ItemStyle-Width = "150px" DataField = "企业组织机构代码" HeaderText = "企业组织机构代码"/>--%>
       </Columns> 
       <EmptyDataRowStyle Width = "450px" HorizontalAlign = "Center" BackColor = "#C2D69B"  />
    </asp:GridView>
    </div>
    </form>
</body>
</html>
