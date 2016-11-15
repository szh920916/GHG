<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FenChangControl.ascx.cs"
    Inherits="Modules_Common_FenChangControl" %>
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
<div class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
    font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
    
</div>
<div style="margin-top: 15px">
    <asp:Panel ID="Panel4" Font-Bold="False" BackColor="white" runat="server" Height="200px"
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
    </asp:Panel>
</div>
