using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DotNet.Manager;
using DotNet.Model;

public partial class Modules_Common_UserAdmin_HeChaJiGouEdit : BasePage
{
    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    SqlConnection conn = new SqlConnection(strConn);//连接数据库
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!DateIsExist.IsExist("*", "HeChaJiGou", "HeChaJiGouDaiMa", Session["UserName"].ToString()))
            {
                this.txtHeChaZuZhiJiGouDaiMa.Value = Session["UserName"].ToString();
                bindDrp();//绑定所属行业
                this.dropPrvince.Items.Insert(0, new ListItem("河南省", "410000"));
                this.dropPrvince.Items.Insert(0, new ListItem("--省--", "-1"));
            }
            else
            {
                this.txtHeChaZuZhiJiGouDaiMa.Value = Session["UserName"].ToString();
                bindDrp();//绑定所属行业
                this.dropPrvince.Items.Insert(0, new ListItem("河南省", "410000"));
                this.dropPrvince.Items.Insert(0, new ListItem("--省--", "-1"));
                BindHeChaJiGou();
            }
           
        }
    }
    /// <summary>
    /// 下拉框响应
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dropPrvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.dropPrvince.SelectedValue != "-1")
        {
            BindArea(this.dropPrvince.SelectedValue, "市");
        }
    }
    /// <summary>
    /// 下拉框响应
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dropCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.dropCity.SelectedValue != "-1")
        {
            BindArea(this.dropCity.SelectedValue, "县（市）/区");
        }
    }
    /// <summary>
    /// 保存信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        //连接权限数据库
        conn.Open();
        
        //判断必填项是否为空
        if (this.dropPrvince.Text == "-1" || this.dropCity.Text == "" || this.dropArea.Text == "-1" || this.txtHeChaJiGouName.Text == "" || this.drpHangYeMingCheng.Text == "--请选择--" || this.txtXiangXiDiZhi.Text == "" || this.txtLianXiRen.Text == "" || this.txtLianXiRenTel.Text == "" || this.txtLianXiRenEmail.Text == "")
        {
            Response.Write("<script>alert('必填项不能为空!')</script>");
        }
        else
        {
           
            try
            {
                string SuoShuDiShi = this.dropPrvince.SelectedValue + "-" + this.dropCity.SelectedValue + "-" + this.dropArea.SelectedValue;
                //判断记录是否存在
                if (DateIsExist.IsExist("*", "HeChaJiGou", "HeChaJiGouDaiMa", Session["UserName"].ToString()))
                {
                  
                    //记录存在则更新数据库
                    string strSql = "update HeChaJiGou set HeChaJiGouMingCheng='" + this.txtHeChaJiGouName.Text + "', HangYeMingCheng='" + this.drpHangYeMingCheng.SelectedValue + "', SuoShuDiShi= '" + SuoShuDiShi + "',XiangXiDiZhi= '" + this.txtXiangXiDiZhi.Text + "', LianXiRen= '" + this.txtLianXiRen.Text + "',LianXiTelNum= '" + this.txtLianXiRenTel.Text + "',Email='" + this.txtLianXiRenEmail.Text + "' where HeChaJiGouDaiMa='" + this.txtHeChaZuZhiJiGouDaiMa.Value + "'";
                    SqlCommand cmd1 = new SqlCommand(strSql, conn);
                    cmd1.ExecuteNonQuery();
                }


                else
                {
                   
                    //记录不存在,插入数据
                    string strSql = "insert into HeChaJiGou(HeChaJiGouDaiMa,HeChaJiGouMingCheng,HangYeMingCheng,SuoShuDiShi,XiangXiDiZhi,LianXiRen,LianXiTelNum,Email) values('" + Int32.Parse( this.txtHeChaZuZhiJiGouDaiMa.Value) + "','" + this.txtHeChaJiGouName.Text + "','" + this.drpHangYeMingCheng.SelectedValue + "','" + SuoShuDiShi + "','" + this.txtXiangXiDiZhi.Text + "','" + this.txtLianXiRen.Text + "','" + this.txtLianXiRenTel.Text + "','" + this.txtLianXiRenEmail.Text + "')";
                    SqlCommand cmd = new SqlCommand(strSql, conn);
                    cmd.ExecuteNonQuery();
                }

                Response.Write("<script>alert('信息保存成功,请查看!');location.href='HeChaJiGouInfo.aspx';</script>");
            }


            catch (Exception)
            {

                throw;
            }

        }


    }
    /// <summary>
    /// 绑定所属行业名称
    /// </summary>
    public void bindDrp()
    {
       
        conn.Open();
        string sql = "select HangYeMingCheng from HangYe";
        SqlCommand cmd = new SqlCommand(sql, conn);

        try
        {
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            drpHangYeMingCheng.DataSource = sdr;
            drpHangYeMingCheng.DataTextField = "HangYeMingCheng";
            drpHangYeMingCheng.DataValueField = "HangYeMingCheng";
            drpHangYeMingCheng.DataBind();
            drpHangYeMingCheng.ClearSelection();
            drpHangYeMingCheng.Items.Insert(0, "--请选择--");
        }
        catch
        {
        }
        conn.Close();
    }
    /// <summary>
    /// 绑定所属地市县
    /// </summary>
    /// <param name="id"></param>
    /// <param name="grand"></param>
    private void BindArea(string id, string grand)
    {
        BaseOrganizeManager baseOrganizeManager = null;
        DataTable dataTable = new DataTable(BaseOrganizeTable.TableName);
        baseOrganizeManager = new BaseOrganizeManager(this.UserCenterDbHelper, this.UserInfo);
        dataTable = baseOrganizeManager.GetDT(BaseOrganizeTable.FieldParentId, id, BaseOrganizeTable.FieldSortCode);
        dataTable.DefaultView.Sort = BaseOrganizeTable.FieldSortCode;
        dataTable.TableName = BaseOrganizeTable.TableName;
        if (grand == "市")
        {
            this.dropCity.DataValueField = BaseOrganizeTable.FieldId;
            this.dropCity.DataTextField = BaseOrganizeTable.FieldFullName;
            this.dropCity.DataSource = dataTable;
            this.dropCity.DataBind();
            this.dropCity.Items.Insert(0, new ListItem("--" + grand + "--", "-1"));

        }
        else
        {
            this.dropArea.DataValueField = BaseOrganizeTable.FieldId;
            this.dropArea.DataTextField = BaseOrganizeTable.FieldFullName;
            this.dropArea.DataSource = dataTable;
            this.dropArea.DataBind();
            this.dropArea.Items.Insert(0, new ListItem("--" + grand + "--", "-1"));

        }


    }


    protected void BindHeChaJiGou()
    {
        conn.Open();
        string sql = "select * from HeChaJiGou where HeChaJiGouDaiMa='" + Session["UserName"].ToString() + "'";
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        sda.Fill(dt);
        this.txtHeChaJiGouName.Text = dt.Rows[0][2].ToString();
        this.drpHangYeMingCheng.SelectedValue = dt.Rows[0][3].ToString();
       
        this.txtXiangXiDiZhi.Text = dt.Rows[0][5].ToString();
        this.txtLianXiRen.Text = dt.Rows[0][6].ToString();
        this.txtLianXiRenTel.Text = dt.Rows[0][7].ToString();
        this.txtLianXiRenEmail.Text = dt.Rows[0][8].ToString();
        conn.Close();

    }

}