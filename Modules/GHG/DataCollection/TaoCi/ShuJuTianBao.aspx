<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShuJuTianBao.aspx.cs" Inherits="Modules_GHG_DataCollection_TaoCi_ShuJuTianBao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 274px">
    <form id="form1" runat="server">
    <div class="css" style="margin-top: 15px; font-family: 黑体; font-size: x-large; font-weight: 100;
        font-style: normal; font-variant: normal; text-transform: inherit; color: #000000;">
        选择燃料
    </div>
    <div style="margin-top: 15px">
    <asp:Panel ID="Panel1" Font-Bold="False" BackColor="white" runat="server" Height="448px"
            BorderStyle="Ridge" Font-Names="幼圆" Font-Size="Medium" Width="100%">
         <table>
                    <tr>
                        <td style="text-align: left">
                            <div class="autoScroll" style="width: 288px; height: 448px; overflow: auto">
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                                    DataSourceID="SqlDataSource1" DataTextField="RanLiaoMingCheng" 
                                    DataValueField="RanLiaoMingCheng">
                                </asp:CheckBoxList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:GHGSZH %>" 
                                    SelectCommand="SELECT [RanLiaoMingCheng] FROM [RanLiao]">
                                </asp:SqlDataSource>
                            </div>
                        </td>
                    </tr>
                </table>
    </asp:Panel>
    </div>
    <div style="width: 83px; margin-left: auto; margin-right: auto; margin-top: 16px">
        <asp:Button ID="btnSaveAbove" runat="server" Text="保存" BackColor="#3399FF" Font-Bold="True"
            Font-Names="幼圆" Font-Size="Large" Height="37px" Width="81px" 
            onclick="btnSaveAbove_Click"  />
    </div>
    </form>
</body>
</html>
