<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeChaJiGouEdit.aspx.cs" Inherits="Modules_Common_UserAdmin_HeChaJiGouEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title lang="ach">核查机构基本信息填报</title>

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
        核查机构主体信息
    </div>
    <div style="margin-top: 15px">
        <asp:Panel ID="Panel1" Font-Bold="False" BackColor="white" runat="server" Height="350px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
            <div>
                <div class="div" style="float: left;">
                    <span style="color: red">*</span>组织机构代码</div>
                <div class="div1">
                    <input id="txtHeChaZuZhiJiGouDaiMa"   runat="server" type="text" readonly="readonly" style="width: 350px;
                        height: 19px;" />
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>核查机构名称</div>
                <div class="div1">
                    <asp:TextBox ID="txtHeChaJiGouName"   runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>所属行业</div>
                <div class="div1">
                    <asp:DropDownList ID="drpHangYeMingCheng"   runat="server" Height="27px" Width="354px">
                    </asp:DropDownList>

                </div>
            </div>
            <div class="div">
            </div>
            
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>所属地市</div>
                <div class="div1">
                
                        <asp:DropDownList ID="dropPrvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropPrvince_SelectedIndexChanged"
                            >
                            
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="dropCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCity_SelectedIndexChanged"
                           >
                        </asp:DropDownList>
                        &nbsp;
                        <asp:DropDownList ID="dropArea" runat="server" onchange="SetNotChangeState(false);"
                            AutoPostBack="True" >
                        </asp:DropDownList>
                
            
            
                </div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>详细地址</div>
                <div class="div1">
                    <asp:TextBox ID="txtXiangXiDiZhi" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            <div>
                <div class="div" style="float: left">
                    <span style="color: red">*</span>联系人</div>
                <div class="div1">
                    <asp:TextBox ID="txtLianXiRen" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
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
                    <span style="color: red">*</span>联系人邮箱</div>
                <div class="div1">
                   <asp:TextBox ID="txtLianXiRenEmail" runat="server" Height="19px" Width="350px"></asp:TextBox></div>
            </div>
            <div class="div">
            </div>
            
        </asp:Panel>
    </div>
     <div style="width: 83px; margin-left: auto; margin-right: auto; margin-top: 45px">
        <asp:Button ID="Button1" runat="server" Text="保存" BackColor="#3399FF" Font-Bold="True"
            Font-Names="幼圆" Font-Size="Large" Height="37px" Width="81px" OnClick="Button1_Click" />
    </div>
   
    </form>
</body>
</html>
