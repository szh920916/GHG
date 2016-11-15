<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeChaJiGouInfo.aspx.cs" Inherits="Modules_Common_UserAdmin_HeChaJiGouInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title lang="ach">核查机构基本信息</title>
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
        核查机构信息
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel1" Font-Bold="False" BackColor="white" runat="server" Height="350px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left;">
                    <span style="color: red">*</span>组织机构代码</div>
                <div class="div1">
                    <asp:Label ID="lblHeChaZuZhiJiGouDaiMa" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label>
                    
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>核查机构名称</div>
                <div class="div1">
                <asp:Label ID="lblHeChaJiGouName" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label>
                    </div>
            </div>
            <div class="div">
            </div>
            
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>所属行业名称</div>
                <div class="div1">
                <asp:Label ID="lblHangYeMingCheng" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label>
                    </div>
                    
            </div>
            <div class="div">
            </div>
            
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>所属地市</div>
                <div class="div1">
                
                       <asp:Label ID="lblSuoShuDiShi" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label>
            
            
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>详细地址</div>
                <div class="div1">
                    <asp:Label ID="lblXiangXiDiZhi" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人</div>
                <div class="div1">
                    <asp:Label ID="lblLianXiRen" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人手机号码</div>
                <div class="div1">
                    <asp:Label ID="lblLianXiRenTelNum" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人邮箱</div>
                <div class="div1">
                  <asp:Label ID="lblLianXiRenEmail" runat="server" Text="Label" style="width: 350px;height: 19px;"></asp:Label></div>
            </div>
            <div class="div">
            </div>
            
        </asp:Panel>
    </div>
     <div style="width: 83px; margin-left: auto; margin-right: auto; margin-top: 45px">
        <asp:Button ID="Button1" runat="server" Text="编辑" BackColor="#3399FF" Font-Bold="True"
            Font-Names="幼圆" Font-Size="Large" Height="37px" Width="81px" OnClick="Button1_Click" />
    </div>
   
    </form>
</body>
</html>

