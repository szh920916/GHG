<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyEdit.aspx.cs" Inherits="Company" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title lang="ach">企业基本信息填报</title>
    <script type="text/jscript" src="http://www.my97.net/dp/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .div
        {
            border-style: groove;
            border-width: thin;
            margin-top: 15px;
            margin-left: 10px;
            height: 25px;
            width: 150px;
        }
        
        .div1
        {
            width: 351px;
            float: left;
            height: 25px;
            border-bottom-style: groove;
            border-right-style: groove;
            border-top-style: groove;
            border-top-width: thin;
            border-right-width: thin;
            border-bottom-width: thin;
            margin-top: 15px;
        }
        
        .div2
        {
            width: 36px;
            float: left;
            height: 25px;
            border-bottom-style: groove;
            border-right-style: groove;
            border-top-style: groove;
            border-top-width: thin;
            border-right-width: thin;
            border-bottom-width: thin;
            margin-top: 15px;
            margin-left: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
        font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
        企业主体信息
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel1" Font-Bold="False" BackColor="white" runat="server" Height="520px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left;">
                    <span style="color: red">*</span>组织机构代码</div>
                <div class="div1">
                    <input id="txtQiYeZuZhiJiGouDaiMa" runat="server" type="text" readonly="readonly"
                        style="width: 350px; height: 19px;" />
                    <%--<asp:TextBox ID="txtQiYeZuZhiJiGouDaiMa" runat="server" Height="19px" Width="350px" ReadOnly="true"></asp:TextBox>--%>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>企业名称</div>
                <div class="div1">
                    <asp:TextBox ID="txtCompanyName" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    社会信用代码</div>
                <div class="div1">
                    <asp:TextBox ID="txtXinYongDaiMa" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>行业代码</div>
                <div class="div1">
                    <asp:DropDownList ID="drpHangYeBianHao" runat="server" Height="27px" Width="354px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>是否碳交易</div>
                <div class="div1">
                    <asp:DropDownList ID="drpIsTanJiaoYi" runat="server" Height="27px" Width="354px">
                        <asp:ListItem>--请选择--</asp:ListItem>
                        <asp:ListItem Value="是">是</asp:ListItem>
                        <asp:ListItem Value="否">否</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>组织机构图</div>
                <div class="div1">
                    <asp:FileUpload ID="FileUploadZuZhiJiGou" runat="server" />
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>主行业</div>
                <div class="div1">
                    <asp:DropDownList ID="drpMainHangYeBianHao" runat="server" Height="27px" Width="354px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    产值</div>
                <div class="div1">
                    <asp:TextBox ID="txtChanZhi" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    增加值</div>
                <div class="div1">
                    <asp:TextBox ID="txtZengJiaLiang" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    建筑面积</div>
                <div class="div1">
                    <asp:TextBox ID="txtJianZhuMianJi" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    是否有分厂</div>
                <div class="div1">
                    <asp:DropDownList ID="drpHasFenChang" runat="server" Height="27px" Width="354px"
                        AutoPostBack="True" OnSelectedIndexChanged="drpHasFenChang_SelectedIndexChanged">
                        <asp:ListItem>--请选择--</asp:ListItem>
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    工艺流程图</div>
                <div class="div1">
                    <asp:FileUpload ID="FileUploadGongYiLiuCheng1" runat="server" />
                </div>
            </div>
            <div class="div">
            </div>
        </asp:Panel>
    </div>
    <div class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
        font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
        单位注册信息
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel2" Font-Bold="False" BackColor="white" runat="server" Height="390px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>省</div>
                <div class="div1">
                    <asp:DropDownList ID="drpProvince" runat="server" Height="27px" Width="354px" AutoPostBack="True"
                        OnSelectedIndexChanged="drpProvince_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>市</div>
                <div class="div1">
                    <asp:DropDownList ID="drpCity" runat="server" Height="27px" Width="354px" AutoPostBack="True"
                        OnSelectedIndexChanged="drpCity_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>地区</div>
                <div class="div1">
                    <asp:DropDownList ID="drpRegion" runat="server" Height="27px" Width="354px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>详细地址</div>
                <div class="div1">
                    <asp:TextBox ID="txtXiangXiDiZhi" runat="server" Height="19px" Width="350px"></asp:TextBox>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>邮编</div>
                <div class="div1">
                    <asp:TextBox ID="txtEmail" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>企业成立时间</div>
                <div class="div1">
                    <input type="text" id="txtZhuCeShiJian" runat="server" onclick="WdatePicker()" style="width: 350px;
                        height: 19px;" />
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>登记注册类型</div>
                <div class="div1">
                    <asp:DropDownList ID="drpZhuCeLeiXing" runat="server" Height="27px" Width="354px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>隶属关系</div>
                <div class="div1">
                    <asp:DropDownList ID="drpLiShuGuanXi" runat="server" Height="27px" Width="354px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
        </asp:Panel>
    </div>
    <div class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
        font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
        联系人信息
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel3" Font-Bold="False" BackColor="white" runat="server" Height="370px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>法定代表人</div>
                <div class="div1">
                    <asp:TextBox ID="txtFaRen" runat="server" Height="19px" Width="320px"></asp:TextBox>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>代表人手机号码</div>
                <div class="div1">
                    <asp:TextBox ID="txtFaRenTel" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    代表人邮箱</div>
                <div class="div1">
                    <asp:TextBox ID="txtFaRenEmail" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>系统联系人</div>
                <div class="div1">
                    <asp:TextBox ID="txtLianXiRen" runat="server" Height="19px" Width="350px"></asp:TextBox>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    联系人固定电话</div>
                <div class="div1">
                    <input id="LianXiRenGuHua" type="text" runat="server" value="例如:XXXX-XXXXXXXX" onfocus="this.value=''"
                        onblur="if(this.value==''){this.value='例如:XXXX-XXXXXXXX'}" style="width: 350px;
                        height: 19px;" /></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人手机号码</div>
                <div class="div1">
                    <asp:TextBox ID="txtLianXiRenTel" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    联系人传真号码</div>
                <div class="div1">
                    <asp:TextBox ID="txtFax" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人邮箱</div>
                <div class="div1">
                    <asp:TextBox ID="txtLianXiRenEmail" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
        </asp:Panel>
    </div>
    <div style="width: 83px; margin-left: auto; margin-right: auto; margin-top: 20px">
        <asp:Button ID="btnSaveAbove" runat="server" Text="保存" BackColor="#3399FF" Font-Bold="True"
            Font-Names="幼圆" Font-Size="Large" Height="37px" Width="81px" OnClick="Button1_Click" />
    </div>
    <div id="sssss" class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
        font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
        <asp:Label ID="Label1" runat="server" Text="分厂基本信息"></asp:Label>
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel4" Font-Bold="False" BackColor="white" runat="server" Height="240px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left">
                    分厂名称</div>
                <div class="div1">
                    <asp:TextBox ID="txtFenChangName" runat="server" Height="19px" Width="350px"></asp:TextBox>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    所属行业名称</div>
                <div class="div1">
                    <asp:DropDownList ID="drpSuoShuHangYe" runat="server" Height="27px" Width="354px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    经营地址</div>
                <div class="div1">
                    <asp:TextBox ID="txtAddress" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    工艺流程图</div>
                <div class="div1">
                    <asp:FileUpload ID="FileUploadGongYiLiuCheng" runat="server" />
                </div>
            </div>
            <div class="div">
        <asp:Button ID="btnAdd" runat="server" Text="添加" Height="37px" Width="81px" Font-Names="幼圆"
            BackColor="#3399FF" Font-Bold="True" Font-Size="Large" OnClick="btnAdd_Click" />
    </div>
        </asp:Panel>
    </div>
    <%--<asp:Panel ID="Panel5" runat="server">
    </asp:Panel>
    <asp:HiddenField ID="HiddenField1" runat="server" />--%>
    <%--<div style="width: 83px; margin-left: 60px; margin-top: 20px">
        <asp:Button ID="btnAdd" runat="server" Text="添加" Height="37px" Width="81px" Font-Names="幼圆"
            BackColor="#3399FF" Font-Bold="True" Font-Size="Large" OnClick="btnAdd_Click" />
    </div>--%>
    <%--<div style="width: 83px; margin-left: auto; margin-right: auto; margin-top: 20px">
        <asp:Button ID="btnSaveAbove" runat="server" Text="保存" BackColor="#3399FF" Font-Bold="True"
            Font-Names="幼圆" Font-Size="Large" Height="37px" Width="81px" OnClick="Button1_Click" />
    </div>--%>
    </form>
</body>
</html>
