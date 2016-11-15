using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_HeChaBaoGaoJinDu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DropDownList1.Items.Insert(0, new ListItem("--请选择--"));
        this.DropDownList2.Items.Insert(0, new ListItem("--请选择--"));
        this.DropDownList3.Items.Insert(0, new ListItem("--请选择--"));
        bindDatelb();
        bindDateDr1();
        bindDateDr3();
        int year = DateTime.Now.Year;// 取当前时间年                
        ListItem yearItem = null;
        //向过去的年份循环100年
        for (int i = year; i > year - 16; i--)
        {
            yearItem = new ListItem(i.ToString(), i.ToString());
            DropDownList2.Items.Add(yearItem);//ddyear为下拉框id
        }
    }

    protected void bindDatelb()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string sql = "select count(*) from TaoCi_PaiFangBaoGaoXinXi";
        SqlCommand cmd = new SqlCommand(sql, conn);
        this.Label2.Text = cmd.ExecuteScalar().ToString();

        string sql1 = "select count(*) from Company";
        SqlCommand cmd1 = new SqlCommand(sql1, conn);
        this.Label4.Text = cmd1.ExecuteScalar().ToString();
    }

    protected void bindDateDr1()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select ItemName from Items_Area where ParentId='" + "410000" + "'";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }


    protected void bindDateDr3()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select HeChaJiGouMingCheng from HeChaJiGou";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }

}