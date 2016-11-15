<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RanShaoPaiFangLiang.aspx.cs"
    Inherits="Modules_GHG_DataCollection_TaoCi_RanShaoPaiFangLiang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="margin-top: 30px; margin-left: 480px">
            <asp:Label ID="Label2" runat="server" Text="化石燃料燃烧量表" Font-Bold="True"></asp:Label>
        </div>
        <div style="margin-top: 15px; margin-left: 60px">
            <asp:Label ID="Label3" runat="server" Text="年份：" Font-Bold="True"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                EnableModelValidation="True" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="RanLiaoMingCheng" HeaderText="RanLiaoMingCheng" SortExpression="RanLiaoMingCheng"  />
                    <asp:TemplateField HeaderText="净消耗量（t,万Nm3）">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="数据来源">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="80px">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="单位热值含碳量（tC/GJ）">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DanWeiReZhiHanTanLiang" HeaderText="DanWeiReZhiHanTanLiang"
                        SortExpression="DanWeiReZhiHanTanLiang" />
                    <asp:TemplateField HeaderText="碳氧化率 （%)">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TanYangHuaLv" HeaderText="TanYangHuaLv" SortExpression="TanYangHuaLv" />
                    <asp:TemplateField HeaderText="低位发热量 （GJ/t，GJ/万Nm3） ">
                        <ItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Width="80px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DiWeiFaReZhi" HeaderText="DiWeiFaReZhi" SortExpression="DiWeiFaReZhi" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div style="margin-top: 15px; margin-left: 480px">
        <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" Height="28px"
            Width="73px" Font-Bold="True" />
    </div>
    </form>
</body>
</html>
