using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_BaoGaoShenHe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.DropDownList1.Items.Insert(0, "--请选择--");
            drDataBing();
        }
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string QiYeZuZhiJiGouDaiMa = DropDownList1.Text;
        string cmdtext2 = "select QiYeMingCheng from Company where  QiYeZuZhiJiGouDaiMa='" + QiYeZuZhiJiGouDaiMa + "'";
        SqlCommand cmd = new SqlCommand(cmdtext2, conn);
        string s3 = cmd.ExecuteScalar().ToString();
        this.TextBox1.Text = s3;
        conn.Close();
    }


    protected void drDataBing()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select 企业组织机构代码 from PeiDuiMingDanView where 核查机构代码='" + Session["UserName"].ToString() + "'";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        string QiYeZuZhiJiGouDaiMa=  this.DropDownList1.Text;
        int QiYeID = Convert.ToInt32( DateIsExist.XIsExist("QiYeID","Company","QiYeZuZhiJiGouDaiMa",QiYeZuZhiJiGouDaiMa));
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string sql = "update JianCeJiHuaShangChuan set Count= '" + '2' + "' where Code='1' and QiYeID='" + QiYeID + "'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();


        string sql1 = "update TaoCi_PaiFangBaoGaoXinXi set Count= '" + '2' + "' where QiYeID='" + QiYeID + "'";
        SqlCommand cmd1 = new SqlCommand(sql1, conn);
        cmd1.ExecuteNonQuery();
        conn.Close();
    }
}