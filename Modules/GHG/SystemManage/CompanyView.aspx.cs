using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_CompanyView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //绑定数据;
            BindData();

        }

    }
    protected void BindData()
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        //where 企业组织机构代码='" + "888888" + "'"
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select QiYeZuZhiJiGouDaiMa,QiYeMingCheng,DiShiBianHao,MainHangYeMingCheng,XiangXiDiZhi,ChengLiShiJian,FaRenDaiBiao,LianXiRen,LianXiRenTelNum,LianXiRenEmail from Company";

        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();  //重新绑定GridView
    }
}