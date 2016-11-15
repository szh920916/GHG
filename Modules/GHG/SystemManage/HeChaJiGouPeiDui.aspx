<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeChaJiGouPeiDui.aspx.cs" Inherits="Modules_GHG_SystemManage_HeChaJiGouPeiDui1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>机构配对</title>
    <style type="text/css">
        #form1
        {
            width: 724px;
            height: 410px;
            text-align: center;
        }
    </style>
</head>
<body style="height: 271px; width: 1152px">
    <form id="form1" runat="server">
    <div style="width: 431px;">
        <div style="width: 132px; height: 235px; float: left; display: inline; margin-left: 20px;">
            <asp:Panel ID="Panel1" runat="server" Height="252px" Width="162px" BorderColor="#3399FF"
                BorderStyle="Double">
                <div style="margin-top: 20px">
                    <asp:Label ID="Label1" runat="server" Text="选择核查机构" Font-Bold="True"></asp:Label>
                </div>
                <table>
                    <tr>
                        <td style="text-align: left">
                            <div class="autoScroll" style="width: 151px; height: 204px; overflow: auto">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div style="width: 140px; height: auto; float: left; display: inline; margin-left: 0px;">
            <asp:Panel ID="Panel2" runat="server" Height="252px" Width="496px" BorderColor="#3399FF"
                BorderStyle="Double" Style="margin-left: 30px">
                <div style="margin-top: 20px; width: 491px; height: 21px; margin-left: 2px;">
                    <asp:Label ID="Label2" runat="server" Text="按行业选择企业" Font-Bold="True"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        style="height: 19px; margin-left: 9px">
                    </asp:DropDownList>
                    </div>
                <table>
                    <tr>
                        <td style="text-align: left">
                            <div class="autoScroll" style="width: 488px; height: 204px; overflow: auto">
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                </asp:CheckBoxList>
                            </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Button ID="btnSave" runat="server" 
                style="margin-left: 207px; margin-top: 48px" Text="保存" BackColor="#3399FF" Font-Bold="True"
            Font-Names="幼圆" Font-Size="Large" Height="37px" Width="81px" 
                onclick="Button1_Click1" />
        </div>
    </div>
  
    </form>
</body>
</html>
