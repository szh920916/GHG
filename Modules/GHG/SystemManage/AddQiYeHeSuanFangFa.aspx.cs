using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_AddQiYeHeSuanFangFa : System.Web.UI.Page
{
    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    SqlConnection conn = new SqlConnection(strConn);
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DropDownList1.Text.Insert(0,"--请选择--");
        bindData();
    }

    protected void bindData()
    {
        conn.Open();
        string s = "select HangYeMingCheng from HangYe";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        conn.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn.Open();
        string HangYeID =Convert.ToString( DateIsExist.XIsExist("HangYeBianHao","HangYe","HangYeMingCheng",DropDownList1.SelectedValue.ToString()));
        int HangYeBianHao=Convert.ToInt32(HangYeID);
        string strSql = "insert into TaoCi_JiSuanGongShi(HangYeBianHao,JiSuanGongShi) values('" + HangYeBianHao + "','" + this.TextBox1.Text+ "')";
        SqlCommand cmd = new SqlCommand(strSql, conn);
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Write("<script>alert('已保存!');location.href='QiYeHeSuanFangFa.aspx';</script>");
        Response.End();
    }
}