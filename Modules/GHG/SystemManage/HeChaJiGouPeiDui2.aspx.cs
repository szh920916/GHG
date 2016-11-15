using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_HeChaJiGouPeiDui : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DropDownList1.Items.Insert(0, new ListItem("--请选择--"));
            this.DropDownList3.Items.Insert(0, new ListItem("--请选择--"));
            BindData1();
            BindData2();
        }
    }

    protected void BindData1()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select HeChaQiYeZuZhiJiGouDaiMa from HeChaJiGou";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }
    protected void BindData2()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select QiYeZuZhiJiGouDaiMa from Company";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList3.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
       
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        //核查机构编号
        string HeChaQiYeZuZhiJiGouDaiMa = DropDownList1.Text;
        string HeChaJiGouBianHaoSql = "select JiGouBianHao from HeChaJiGou where  HeChaQiYeZuZhiJiGouDaiMa='" + HeChaQiYeZuZhiJiGouDaiMa + "'";
        SqlCommand cmdHeChaQiYeZuZhiJiGouDaiMa = new SqlCommand(HeChaJiGouBianHaoSql, conn);
        string JiGouBianHao = cmdHeChaQiYeZuZhiJiGouDaiMa.ExecuteScalar().ToString();

        //企业编号
        string QiYeZuZhiJiGouDaiMa = DropDownList3.Text;
        string QiYeIDSql = "select QiYeID from Company where  QiYeZuZhiJiGouDaiMa='" + QiYeZuZhiJiGouDaiMa + "'";
        SqlCommand cmdQiYeID = new SqlCommand(QiYeIDSql, conn);
        string QiYeID = cmdQiYeID.ExecuteScalar().ToString();

        if (DateIsExist.IsExist("*","HeChaJiGouPeiDui","QiYeID",QiYeID))
        {
            Response.Write("<script>alert('已配对，不允许重复!');location.href='PeiDuiMingDanChaKan.aspx';</script>");
        }
        else
        {
            string cmdtext1 = "insert into HeChaJiGouPeiDui(JiGouBianHao,QiYeID,Year) values('" + JiGouBianHao + "','" + QiYeID + "','" + DateTime.Now.Year.ToString() + "')";
            SqlCommand cmd1 = new SqlCommand(cmdtext1, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }
        Response.Write("<script>alert('保存配对名单成功,请查看!');location.href='PeiDuiMingDanChaKan.aspx';</script>");
    }

   
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
       
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string QiYeZuZhiJiGouDaiMa = DropDownList3.Text;
        string cmdtext2 = "select QiYeMingCheng from Company where  QiYeZuZhiJiGouDaiMa='" + QiYeZuZhiJiGouDaiMa + "'";
        SqlCommand cmd = new SqlCommand(cmdtext2, conn);
        string s3 = cmd.ExecuteScalar().ToString();
        this.TextBox2.Text = s3;
        conn.Close();
    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string HeChaQiYeZuZhiJiGouDaiMa = DropDownList1.Text;
        string cmdtext1 = "select HeChaJiGouMingCheng from HeChaJiGou where  HeChaQiYeZuZhiJiGouDaiMa='" + HeChaQiYeZuZhiJiGouDaiMa + "'";
        SqlCommand cmd = new SqlCommand(cmdtext1, conn);
        string s2 = cmd.ExecuteScalar().ToString();
        this.TextBox1.Text = s2;
        conn.Close();

    }
}






