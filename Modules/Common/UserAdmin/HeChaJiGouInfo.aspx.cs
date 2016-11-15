using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Modules_Common_UserAdmin_HeChaJiGouInfo : System.Web.UI.Page
{
    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    SqlConnection conn = new SqlConnection(strConn);//连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DateIsExist.IsExist("*", "HeChaJiGou", "HeChaJiGouDaiMa", Session["UserName"].ToString()))
        {
            Response.Write("<script>alert('机构信息不存在，请点击完善!');location.href='HeChaJiGouEdit.aspx';</script>");
        }
        else
        {
            DoPageLoad();
        }
        
    }

    
    /// <summary>
    /// 加载核查机构基本信息
    /// </summary>
    protected void DoPageLoad()
    {
        
        conn.Open();
        string sql = "select * from HeChaJiGou where HeChaJiGouDaiMa='" + Session["UserName"].ToString() + "'";
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        sda.Fill(dt);
        this.lblHeChaJiGouName.Text = dt.Rows[0][2].ToString();
        this.lblHangYeMingCheng.Text = dt.Rows[0][3].ToString();
       
        this.lblXiangXiDiZhi.Text = dt.Rows[0][5].ToString();
        this.lblLianXiRen.Text = dt.Rows[0][6].ToString();
        this.lblLianXiRenTelNum.Text = dt.Rows[0][7].ToString();
        this.lblLianXiRenEmail.Text = dt.Rows[0][8].ToString();
        conn.Close();


    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HeChaJiGouEdit.aspx");
    }
}