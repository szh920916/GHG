using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Modules_GHG_SystemManage_HeChaJiGouPeiDui1 : System.Web.UI.Page
{
    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    SqlConnection conn = new SqlConnection(strConn);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)    //这句很重要,如果不加,则每次加载时都要执行一次绑定,易丢失数据.
        {
            this.DropDownList1.Items.Insert(0, new ListItem("--请选择--"));
            BindDrpHangYe();
            BindQiYe();
            BindHeChaJiGou();
        }
    }
    

    protected void BindDrpHangYe()
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

    protected void BindQiYe()
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand("select QiYeMingCheng from Company", conn);
        SqlDataReader sdr = cmd.ExecuteReader();
        this.CheckBoxList1.DataTextField = "QiYeMingCheng";
        this.CheckBoxList1.DataValueField = "QiYeMingCheng";
        this.CheckBoxList1.DataSource = sdr;
        this.CheckBoxList1.DataBind();
        sdr.Close();        //关闭记录集
        conn.Close();        //关闭链接
    }
    protected void BindHeChaJiGou()
    {

        conn.Open();
        SqlCommand cmd = new SqlCommand("select HeChaJiGouMingCheng from HeChaJiGou", conn);
        SqlDataReader sdr = cmd.ExecuteReader();
        this.RadioButtonList1.DataTextField = "HeChaJiGouMingCheng";
        this.RadioButtonList1.DataValueField = "HeChaJiGouMingCheng";
        this.RadioButtonList1.DataSource = sdr;
        this.RadioButtonList1.DataBind();
        sdr.Close();        //关闭记录集
        conn.Close();        //关闭链接
    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select QiYeMingCheng from Company where MainHangYeMingCheng='" + this.DropDownList1.SelectedValue.ToString() + "'", conn);
        SqlDataReader sdr = cmd.ExecuteReader();
        this.CheckBoxList1.DataTextField = "QiYeMingCheng";
        this.CheckBoxList1.DataValueField = "QiYeMingCheng";
        this.CheckBoxList1.DataSource = sdr;
        this.CheckBoxList1.DataBind();

        sdr.Close();        //关闭记录集
        conn.Close();        //关闭链接
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        int JiGouBianHao=0;
        conn.Open();
        if (DateIsExist.IsExist("*", "HeChaJiGou", "HeChaJiGouMingCheng",this.RadioButtonList1.SelectedValue.ToString()))
        {
            JiGouBianHao = Convert.ToInt32(DateIsExist.XIsExist("JiGouBianHao", "HeChaJiGou", "HeChaJiGouMingCheng", this.RadioButtonList1.SelectedValue.ToString()));
        }
        else
        {
            Response.Write("<script>alert('核查机构：" + this.RadioButtonList1.SelectedValue.ToString() + "暂时未注册');</script>");
            return;
        }
        
        for (int i = 0; i <= this.CheckBoxList1.Items.Count - 1; i++)
        {
            if (this.CheckBoxList1.Items[i].Selected)
            {
                int QiYeID = Convert.ToInt32(DateIsExist.XIsExist("QiYeID", "Company", "QiYeMingCheng", this.CheckBoxList1.Items[i].Value.ToString()));
                if (DateIsExist.IsExist("*", "PeiDui", "QiYeID", QiYeID.ToString()))
                {
                    Response.Write("<script>alert('" + this.CheckBoxList1.Items[i].Value.ToString() + "已配对，不允许重复!');location.href='PeiDuiMingDanChaKan.aspx';</script>");
                }
                else
                {
                    string cmdtext1 = "insert into PeiDui(JiGouBianHao,QiYeID,NianFen) values('" + JiGouBianHao + "','" + QiYeID + "','" + DateTime.Now.Year.ToString() + "')";
                    SqlCommand cmd1 = new SqlCommand(cmdtext1, conn);
                    cmd1.ExecuteNonQuery();
                    
                }
            }
            conn.Close();
            Response.Write("<script>alert('保存配对名单成功,请查看!');location.href='PeiDuiMingDanChaKan.aspx';</script>");
        }
    }
}