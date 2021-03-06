﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Modules_GHG_DataCollection_TaoCi_PaiFangYInZi_HuaShiRanLiao1 : System.Web.UI.Page
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();

        //获取企业ID
        string QiYeZuZhiJiGouDaiMa = Session["UserName"].ToString();
        string QiYeIDSql = "select QiYeID from Company where QiYeZuZhiJiGouDaiMa='" + QiYeZuZhiJiGouDaiMa + "'";
        SqlCommand QiYeIDcmd = new SqlCommand(QiYeIDSql, conn);
        string QiYeID = QiYeIDcmd.ExecuteScalar().ToString();

        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {

            //获取燃料ID
            string RanLiaoMingCheng = GridView1.Rows[i].Cells[0].Text.ToString();//遍历每一行的燃料名称
            string RanLiaoIDsql = "select RanLiaoID from HuaShiRanLiao where RanLiaoMingCheng='" + RanLiaoMingCheng + "'";
            SqlCommand RanLiaoIDcmd = new SqlCommand(RanLiaoIDsql, conn);
            string RanLiaoID = RanLiaoIDcmd.ExecuteScalar().ToString();//获取燃料ID


            TextBox T1 = (GridView1.Rows[i].Cells[1].FindControl("TextBox2")) as TextBox;
            TextBox T2 = (GridView1.Rows[i].Cells[3].FindControl("TextBox3")) as TextBox;
            TextBox T3 = (GridView1.Rows[i].Cells[5].FindControl("TextBox4")) as TextBox;
            string DanWeiReZhiHanTanLiang = null ;
            string TanYangHuaLv = null ;
            string DiWeiFaReZhi=null;
            if (T1.Text == "" )
            {
                if (GridView1.Rows[i].Cells[2].Text.ToString() == "无")
                {
                    Response.Write("<script>alert('请检查数据!')</script>");
                    return;
                }
                else
                {
                    string T11 = GridView1.Rows[i].Cells[2].Text.ToString();
                    DanWeiReZhiHanTanLiang = T11;
                }
                
            }
            else
            {
                DanWeiReZhiHanTanLiang = T1.Text;
            }
            if (T2.Text == "")
            {
                if (GridView1.Rows[i].Cells[4].Text.ToString() == "无")
                {
                    Response.Write("<script>alert('请检查数据!')</script>");
                    return;
                }
                else
                {
                    string T21 = GridView1.Rows[i].Cells[4].Text.ToString();
                    TanYangHuaLv = T21;
                }
               
            }
            else
            {
                TanYangHuaLv = T2.Text;

            }
            if (T3.Text == "")
            {
                if (GridView1.Rows[i].Cells[6].Text.ToString() == "无")
                {
                    Response.Write("<script>alert('请检查数据!')</script>");
                    return;
                }
                else
                {
                    string T31 = GridView1.Rows[i].Cells[6].Text.ToString();
                    DiWeiFaReZhi = T31;
                }
               
            }
            else
            {
                DiWeiFaReZhi = T3.Text;
            }

            bool b = DateIsExist.IsExist("*", "TaoCi_HuaShiRanLiaoZongBiao", "QiYeID", QiYeID, "RanLiaoID", RanLiaoID, "NianFen", this.DropDownList1.SelectedValue.ToString());

            if (b)
            {

                string strSql = "update TaoCi_HuaShiRanLiaoZongBiao set DanWeiReZhiHanTanLiang='" + DanWeiReZhiHanTanLiang + "',TanYangHuaLv='" + TanYangHuaLv + "',DiWeiFaReLiang='" + DiWeiFaReZhi + "' where RanLiaoID='" + RanLiaoID + "' and QiYeID='" + QiYeID + "' and NianFen='" + this.DropDownList1.SelectedValue.ToString() + "'";
                SqlCommand cmdSql = new SqlCommand(strSql, conn);
                cmdSql.ExecuteNonQuery();


            }
            else
            {
                string strSql = "insert into TaoCi_HuaShiRanLiaoZongBiao(RanLiaoID,QiYeID,DanWeiReZhiHanTanLiang,TanYangHuaLv,DiWeiFaReLiang,NianFen) values('" + RanLiaoID + "','" + QiYeID + "','" + DanWeiReZhiHanTanLiang + "','" + TanYangHuaLv + "','" + DiWeiFaReZhi + "','" + DateTime.Now.Year.ToString() + "')";
                SqlCommand cmdSql = new SqlCommand(strSql, conn);
                cmdSql.ExecuteNonQuery();
            }


        }
        conn.Close();
        Response.Write("<script>alert('保存成功!');location.href='PaiFangShuJuTianBao.aspx';</script>");
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