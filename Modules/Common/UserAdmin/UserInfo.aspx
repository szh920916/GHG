<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="UserInfo" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
     <script language='javascript' src='../../../JavaScript/Default.js'></script>
     <script language="javascript" src="JavaScript/UserInfo.js" type="text/javascript"></script>
    <title>个人信息修改</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <table class="ydMenuCssParentTab" cellspacing="0" cellpadding="0" border="0" style="height: 25px;
        width: 100%; border-collapse: collapse;">
        <tr>
            <td colspan="2" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td class="ydMenuCssParentLefttd" style="white-space: nowrap;">
                个人信息 - 我的信息
            </td>
            <td align="right">
            </td>
        </tr>
    </table>
    <table border="0" width="100%">
        <tr>
            <td>
                <img src="../../../Themes/Blue/Images/normal/icon_news_floder_3.gif" border="0" align="absmiddle"/>
                我的信息修改
            </td>
        </tr>
    </table>
    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                <font color="red">*</font> 用户名：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtUserName" runat="server" TabIndex="1" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table id="table_returnrequest" style="border-left-width: 1px; border-left-color: #94bbd1;
        border-left-style: solid;" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                真实姓名：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtRealName" runat="server"  TabIndex="2"></asp:TextBox>
            </td>
        </tr>
       <%-- <tr>
            <td height="25" align="right" nowrap="nowrap"  style="width: 100px" class="td-title">
                工号：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="txtStudentID" runat="server"  TabIndex="3"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                部门：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="txtClass" runat="server" MaxLength="40"  TabIndex="4"></asp:Label>
            </td>
        </tr>--%>
        <%--<tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                性别：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:RadioButtonList ID="rblSex" runat="server" RepeatDirection="Horizontal" TabIndex="5">
                    <asp:ListItem Value="男">男</asp:ListItem>
                    <asp:ListItem Value="女">女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                出生日期：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:DropDownList ID="ddlBirthYear" runat="server" size="1" AutoPostBack="False" TabIndex="6">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                年
                <asp:DropDownList ID="ddlBirthMonth" runat="server" AutoPostBack="False"  TabIndex="7">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="1">01</asp:ListItem>
                    <asp:ListItem Value="2">02</asp:ListItem>
                    <asp:ListItem Value="3">03</asp:ListItem>
                    <asp:ListItem Value="4">04</asp:ListItem>
                    <asp:ListItem Value="5">05</asp:ListItem>
                    <asp:ListItem Value="6">06</asp:ListItem>
                    <asp:ListItem Value="7">07</asp:ListItem>
                    <asp:ListItem Value="8">08</asp:ListItem>
                    <asp:ListItem Value="9">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
                月
                <asp:DropDownList ID="ddlBirthDay" runat="server" AutoPostBack="False"  TabIndex="8">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="1">01</asp:ListItem>
                    <asp:ListItem Value="2">02</asp:ListItem>
                    <asp:ListItem Value="3">03</asp:ListItem>
                    <asp:ListItem Value="4">04</asp:ListItem>
                    <asp:ListItem Value="5">05</asp:ListItem>
                    <asp:ListItem Value="6">06</asp:ListItem>
                    <asp:ListItem Value="7">07</asp:ListItem>
                    <asp:ListItem Value="8">08</asp:ListItem>
                    <asp:ListItem Value="9">09</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                    <asp:ListItem Value="13">13</asp:ListItem>
                    <asp:ListItem Value="14">14</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="16">16</asp:ListItem>
                    <asp:ListItem Value="17">17</asp:ListItem>
                    <asp:ListItem Value="18">18</asp:ListItem>
                    <asp:ListItem Value="19">19</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="21">21</asp:ListItem>
                    <asp:ListItem Value="22">22</asp:ListItem>
                    <asp:ListItem Value="23">23</asp:ListItem>
                    <asp:ListItem Value="24">24</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                    <asp:ListItem Value="26">26</asp:ListItem>
                    <asp:ListItem Value="27">27</asp:ListItem>
                    <asp:ListItem Value="28">28</asp:ListItem>
                    <asp:ListItem Value="29">29</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="30">31</asp:ListItem>
                </asp:DropDownList>
                日
            </td>
        </tr>--%>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                移动电话：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtMobile" runat="server" MaxLength="40"  TabIndex="9"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                E-mail：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100"  TabIndex="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                QQ：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtQQ" runat="server" MaxLength="40"  TabIndex="11"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table class="ydMenuCss" align="center" width="100%">
        <tr>
            <td align="center">
                <asp:LinkButton ID="btnConfirm" runat="server" ToolTip="保存" OnClick="btnSubmit_Click" TabIndex="13"><span>保存</span></asp:LinkButton>
                 <asp:LinkButton ID="btnChangePwd" runat="server" ToolTip="密码修改" TabIndex="13" 
                    onclick="btnChangePwd_Click"><span>密码修改</span></asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
