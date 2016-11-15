using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_Common_UserAdmin_CompanyInfo : System.Web.UI.Page
{
    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    SqlConnection conn = new SqlConnection(strConn);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DateIsExist.IsExist("*", "Company", "QiYeZuZhiJiGouDaiMa", Session["UserName"].ToString()))
        {
            Response.Write("<script>alert('企业信息不存在，请点击完善!');location.href='CompanyEdit.aspx';</script>");
        }
        else
        {
            BindComapny();
        }
        
    }

    protected void BindComapny()
    {
        conn.Open();
        string sql = "select * from Company where QiYeZuZhiJiGouDaiMa='" + Session["UserName"].ToString() + "'";
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        sda.Fill(dt);
        this.lblQiYeZuZhiJiGouDaiMa.Text = dt.Rows[0][1].ToString();
        this.lblCompanyName.Text = dt.Rows[0][2].ToString();
        this.lblXinYongDaiMa.Text = dt.Rows[0][3].ToString();
        this.lblHangYeBianHao.Text = dt.Rows[0][4].ToString();
        this.lblIsTanJiaoYi.Text = dt.Rows[0][5].ToString();
        this.lblZuZhiJiGouTu.Text = dt.Rows[0][6].ToString();
        this.lblMainHangYeMingCheng.Text = dt.Rows[0][7].ToString();
        this.lblChanZhi.Text = dt.Rows[0][8].ToString();
        this.lblZengJiaZhi.Text = dt.Rows[0][9].ToString();
        this.lblJianZhuMianJi.Text = dt.Rows[0][10].ToString();
        this.lblHasFenChang.Text = dt.Rows[0][11].ToString();
        this.lblGongYiLiuChengTu1.Text = dt.Rows[0][12].ToString();
        this.lblSuoShuDiShi.Text = dt.Rows[0][13].ToString();
        this.lblXiangXiDiZhi.Text = dt.Rows[0][14].ToString();
        this.lblYouBian.Text = dt.Rows[0][15].ToString();
        this.lblChengLiShiJian.Text = dt.Rows[0][16].ToString();
        this.lblZhuCeLeiXing.Text = dt.Rows[0][17].ToString();
        this.lblLiShuGuanXi.Text = dt.Rows[0][18].ToString();
        this.lblFaRen.Text = dt.Rows[0][19].ToString();
        this.lblFaRenEmail.Text = dt.Rows[0][20].ToString();
        this.lblFaRenTel.Text = dt.Rows[0][21].ToString();
        this.lblXiTongLianXiRen.Text = dt.Rows[0][22].ToString();
        this.lblLianXiRenTel.Text = dt.Rows[0][23].ToString();
        this.lblGuHua.Text = dt.Rows[0][24].ToString();
        this.lblFax.Text = dt.Rows[0][25].ToString();
        this.lblLianXiRenEmail.Text = dt.Rows[0][26].ToString();
        //this.lblFenChangName.Text = dt.Rows[0][27].ToString();
        //this.lblAdd.Text = dt.Rows[0][29].ToString();
        //this.lblGongYiLiuCheng.Text = dt.Rows[0][28].ToString();

        conn.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("CompanyEdit.aspx");
    }
}