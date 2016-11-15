using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Modules_GHG_DataCollection_TaoCi_RanShaoPaiFangLiang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            int year = DateTime.Now.Year;// 取当前时间年                
            ListItem yearItem = null;
            for (int i = year; i > year - 16; i--)//初始化DropDownList年份
            {
                yearItem = new ListItem(i.ToString(), i.ToString());
                DropDownList1.Items.Add(yearItem);
            }
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        int headerIndex = 0;

        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                //第一行表头
                TableCellCollection tcHeader = e.Row.Cells;
                tcHeader.Clear();
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("rowspan", "2"); //跨Row
                tcHeader[headerIndex].Text = "燃料名称";

                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("colspan", "2"); //跨Row
                tcHeader[headerIndex].Text = "单位热值含碳量（tC/GJ）";

                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("colspan", "2"); //两列
                tcHeader[headerIndex].Text = "碳氧化率（%)";


                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("colspan", "2"); //两列
                tcHeader[headerIndex].Text = "低位发热量（GJ/t，GJ/万Nm3）</th></tr>";



                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("rowspan", "1"); //跨Row
                tcHeader[headerIndex].Attributes.Add("class", "HeadC");
                tcHeader[headerIndex].Text = "实际值";

                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("rowspan", "1"); //跨Row
                tcHeader[headerIndex].Attributes.Add("class", "HeadC");
                tcHeader[headerIndex].Text = "缺省值";

                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("rowspan", "1"); //跨Row
                tcHeader[headerIndex].Attributes.Add("class", "HeadC");
                tcHeader[headerIndex].Text = "实际值";

                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("rowspan", "1"); //跨Row
                tcHeader[headerIndex].Attributes.Add("class", "HeadC");
                tcHeader[headerIndex].Text = "缺省值";

                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("rowspan", "1"); //跨Row
                tcHeader[headerIndex].Attributes.Add("class", "HeadC");
                tcHeader[headerIndex].Text = "实际值";

                headerIndex++;
                tcHeader.Add(new TableHeaderCell());
                tcHeader[headerIndex].Attributes.Add("rowspan", "1"); //跨Row
                tcHeader[headerIndex].Attributes.Add("class", "HeadC");
                tcHeader[headerIndex].Text = "缺省值";


                break;
        }
    }
}