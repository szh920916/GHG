<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyInfo.aspx.cs" Inherits="Modules_Common_UserAdmin_CompanyInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业信息浏览</title>
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
            width: 354px;
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
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
        font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
        企业主体信息浏览
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel1" Font-Bold="False" BackColor="white" runat="server" Height="520px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left;">
                    组织机构代码</div>
                <div class="div1">
                    <asp:Label ID="lblQiYeZuZhiJiGouDaiMa" runat="server" Text="Label" style="width: 350px;
                        height: 19px;" ></asp:Label>
                    <%--<input id="txtQiYeZuZhiJiGouDaiMa"   runat="server" type="text" readonly="readonly" style="width: 350px;
                        height: 22px;" />--%>
                    <%--<asp:TextBox ID="txtQiYeZuZhiJiGouDaiMa" runat="server" Height="19px" Width="350px" ReadOnly="true"></asp:TextBox>--%>
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    企业名称</div>
                <div class="div1">
                    <asp:Label ID="lblCompanyName" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    社会信用代码</div>
                <div class="div1">
                     <asp:Label ID="lblXinYongDaiMa" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    行业代码</div>
                <div class="div1">
                   <asp:Label ID="lblHangYeBianHao" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    是否碳交易</div>
                <div class="div1">
                    <asp:Label ID="lblIsTanJiaoYi" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                   组织机构图</div>
                <div class="div1">
                   <asp:Label ID="lblZuZhiJiGouTu" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    主行业名称</div>
                <div class="div1">
                    <asp:Label ID="lblMainHangYeMingCheng" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    产值</div>
                <div class="div1">
                    <asp:Label ID="lblChanZhi" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    增加值</div>
                <div class="div1">
                    <asp:Label ID="lblZengJiaZhi" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    建筑面积</div>
                <div class="div1">
                    <asp:Label ID="lblJianZhuMianJi" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    是否有分厂</div>
                <div class="div1">
                    <asp:Label ID="lblHasFenChang" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    工艺流程图</div>
                <div class="div1">
                    <asp:Label ID="lblGongYiLiuChengTu1" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
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
        <asp:Panel ID="Panel2" Font-Bold="False" BackColor="white" runat="server" Height="280px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>所属地市</div>
                <div class="div1">
                    <asp:Label ID="lblSuoShuDiShi" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
           
            <div>
                <div class="div" style="float: left">
                     详细地址</div>
                <div class="div1">
                    <asp:Label ID="lblXiangXiDiZhi" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                     邮编</div>
                <div class="div1">
                   <asp:Label ID="lblYouBian" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                     企业成立时间</div>
                <div class="div1">
                    <asp:Label ID="lblChengLiShiJian" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                     登记注册类型</div>
                <div class="div1">
                    <asp:Label ID="lblZhuCeLeiXing" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                     隶属关系</div>
                <div class="div1">
                    <asp:Label ID="lblLiShuGuanXi" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
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
        <asp:Panel ID="Panel3" Font-Bold="False" BackColor="white" runat="server" Height="350px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left">
                     法定代表人</div>
                <div class="div1">
                    <asp:Label ID="lblFaRen" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                     法人代表手机号码</div>
                <div class="div1">
                    <asp:Label ID="lblFaRenTel" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    法人代表邮箱</div>
                <div class="div1">
                    <asp:Label ID="lblFaRenEmail" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    系统联系人</div>
                <div class="div1">
                    <asp:Label ID="lblXiTongLianXiRen" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    联系人固定电话</div>
                <div class="div1">
                    <asp:Label ID="lblGuHua" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人手机号码</div>
                <div class="div1">
                   <asp:Label ID="lblLianXiRenTel" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    联系人传真号码</div>
                <div class="div1">
                    <asp:Label ID="lblFax" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人邮箱</div>
                <div class="div1">
                    <asp:Label ID="lblLianXiRenEmail" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
        </asp:Panel>
    </div>
    <div class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
        font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
        经营地址情况
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel4" Font-Bold="False" BackColor="white" runat="server" Height="150px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left">
                    企业/分厂名称</div>
                <div class="div1">
                   <asp:Label ID="lblFenChangName" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    经营地址</div>
                <div class="div1">
                    <asp:Label ID="lblAdd" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    工艺流程图</div>
                <div class="div1">
                   <asp:Label ID="lblGongYiLiuCheng" runat="server" Text="Label" style="width: 350px;height: 19px;" ></asp:Label></div>
            </div>
            <div class="div">
            </div>
          
        </asp:Panel>
    </div>
    <div style="width: 83px; margin-left: auto; margin-right: auto; margin-top: 45px">
        <asp:Button ID="Button1" runat="server" Text="编辑" BackColor="#3399FF" Font-Bold="True"
            Font-Names="幼圆" Font-Size="Large" Height="37px" Width="81px" 
            onclick="Button1_Click"  />
    </div>
    </form>
</body>
</html>
