using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using DotNet.Model;
using DotNet.Manager;
using GHG.Model;
using System.Configuration;
using System.IO;

public partial class Company : BasePage
{
    //private static int count = 0;
    static string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
    SqlConnection conn = new SqlConnection(strConn);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (!DateIsExist.IsExist("*","Company","QiYeZuZhiJiGouDaiMa",Session["UserName"].ToString()))
            {
                this.drpHangYeBianHao.Items.Insert(0, new ListItem("--请选择--"));
                this.drpMainHangYeBianHao.Items.Insert(0, new ListItem("--请选择--"));
                this.drpSuoShuHangYe.Items.Insert(0, new ListItem("--请选择--"));
                this.drpProvince.Items.Insert(0, new ListItem("河南省", "410000"));
                this.drpProvince.Items.Insert(0, new ListItem("--省--", "-1"));
                this.txtQiYeZuZhiJiGouDaiMa.Value = Session["UserName"].ToString();
                bindHangYeBianHao();//绑定行业编号
                bindLiShuGuanXi();//绑定隶属关系
                bindMainHangYeBianHao(this.drpMainHangYeBianHao);//绑定主行业名称
                bindZhuCeLeiXing();//绑定注册类型
                
            }

            else
            {
                this.drpHangYeBianHao.Items.Insert(0, new ListItem("--请选择--"));
                this.drpMainHangYeBianHao.Items.Insert(0, new ListItem("--请选择--"));
                this.drpProvince.Items.Insert(0, new ListItem("河南省", "410000"));
                this.drpProvince.Items.Insert(0, new ListItem("--省--", "-1"));
                this.txtQiYeZuZhiJiGouDaiMa.Value = Session["UserName"].ToString();
                bindHangYeBianHao();//绑定行业编号
                bindLiShuGuanXi();//绑定隶属关系
                bindMainHangYeBianHao(this.drpMainHangYeBianHao);//绑定主行业名称
                bindZhuCeLeiXing();//绑定注册类型
                BindCompany();
            }
         
        }
    }
    /// <summary>
    ///  隶属关系集合
    /// </summary>
    public enum LiShuGuanXi
    {
        请选择,
        中央,
        省,
        地,
        县,
        县级以下,
        其他,
    }
    /// <summary>
    /// 注册类型集合
    /// </summary>
    public enum ZhuCeLeiXing
    {
        请选择, 国有, 集体, 股份合作, 国有联营, 集体联营, 国有与集体联营, 其他联营, 国有独资公司, 其他有限责任公司, 股份有限公司,
        私营独资, 私营合伙, 私营有限责任公司, 私营股份有限公司, 与港澳台商合资经营, 与港澳台商合作经营, 港澳台商独资, 港澳台商投资股份有限公司, 其他港澳台投资, 中外合资经营, 中外合作经营, 外资企业, 外商投资股份有限公司, 其他外商投资其他,
    }
    /// <summary>
    /// 绑定数据库中的行业编号
    /// </summary>
    protected void bindHangYeBianHao()
    {
        conn.Open();
        string s = "select HangYeBianHao from HangYe";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            this.drpHangYeBianHao.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        conn.Close();
    }
    /// <summary>
    /// 绑定隶属关系
    /// </summary>
    protected void bindLiShuGuanXi()
    {
        List<string> lishuguanxi = Enum.GetNames(typeof(LiShuGuanXi)).ToList<string>();
        this.drpLiShuGuanXi.DataSource = lishuguanxi;
        this.drpLiShuGuanXi.DataBind();
    }
    /// <summary>
    /// 绑定主行业名称
    /// </summary>
    protected void bindMainHangYeBianHao(DropDownList drp)
    {
        string strConn = System.Configuration.ConfigurationManager.ConnectionStrings["GHG"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConn);
        conn.Open();
        string s = "select HangYeMingCheng from HangYe";
        SqlDataAdapter sda = new SqlDataAdapter(s, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            drp.Items.Add(ds.Tables[0].Rows[i][0].ToString());
        }
    }
    /// <summary>
    /// 绑定注册类型
    /// </summary>
    protected void bindZhuCeLeiXing()
    {
        List<string> zhuceleixing = Enum.GetNames(typeof(ZhuCeLeiXing)).ToList<string>();
        this.drpZhuCeLeiXing.DataSource = zhuceleixing;
        this.drpZhuCeLeiXing.DataBind();
    }

    /// <summary>
    /// 显示用户属性
    /// </summary>
    private void ShowUser()
    {
        if (this.UserInfo.Id.Length > 0)
        {
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            //获取员工ID所约束的数据库记录
            DataTable dataTable = userManager.Get(this.UserInfo.Id);
            BaseUserEntity userEntity = new BaseUserEntity(dataTable);
        }
        else
        {
            // 这条记录已经被删除了
            Page.Response.Redirect(Utilities.NotFindPage);
        }
    }
    /// <summary>
    /// 所属省
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drpProvince.SelectedValue != "-1")
        {
            BindArea(this.drpProvince.SelectedValue, "市");
        }
    }
    /// <summary>
    /// 实体
    /// </summary>
    /// <param name="companyEntity"></param>
    private void ShowEntity(CompanyEntity companyEntity)
    {

        BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.UserCenterDbHelper, this.UserInfo);
        BaseOrganizeEntity organizeEntity1 = organizeManager.GetEntity(companyEntity.DiShiBianHao);
        if (organizeEntity1.ParentId != null)
        {
            BaseOrganizeEntity organizeEntity2 = organizeManager.GetEntity(organizeEntity1.ParentId);
            if (organizeEntity2.ParentId != null)
            {
                //province city area
                BaseOrganizeEntity organizeEntity3 = organizeManager.GetEntity(organizeEntity2.ParentId);
                this.drpProvince.SelectedValue = organizeEntity3.Id.ToString();

                BindArea(organizeEntity2.ParentId.ToString(), "市");
                this.drpCity.SelectedValue = organizeEntity2.Id.ToString();
                BindArea(organizeEntity1.ParentId.ToString(), "县（市）/区");
                this.drpRegion.SelectedValue = organizeEntity1.Id.ToString();

            }
            else
            {
                //province city
                this.drpProvince.SelectedValue = organizeEntity2.Id.ToString();
                BindArea(organizeEntity1.ParentId.ToString(), "市");
                this.drpCity.SelectedValue = organizeEntity1.Id.ToString();
            }
        }
        else
        {
            //province
            this.drpProvince.SelectedValue = organizeEntity1.Id.ToString();
        }


    }
    /// <summary>
    /// 绑定所属省市
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
            this.drpCity.DataValueField = BaseOrganizeTable.FieldId;
            this.drpCity.DataTextField = BaseOrganizeTable.FieldFullName;
            this.drpCity.DataSource = dataTable;
            this.drpCity.DataBind();
            this.drpCity.Items.Insert(0, new ListItem("--" + grand + "--", "-1"));

        }
        else
        {
            this.drpRegion.DataValueField = BaseOrganizeTable.FieldId;
            this.drpRegion.DataTextField = BaseOrganizeTable.FieldFullName;
            this.drpRegion.DataSource = dataTable;
            this.drpRegion.DataBind();
            this.drpRegion.Items.Insert(0, new ListItem("--" + grand + "--", "-1"));

        }


    }
    /// <summary>
    /// 所属市
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drpCity.SelectedValue != "-1")
        {
            BindArea(this.drpCity.SelectedValue, "县（市）/区");
        }
    }
    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        //连接权限数据库
        string strConnUser = System.Configuration.ConfigurationManager.ConnectionStrings["UserCenter_GHG"].ConnectionString;
        SqlConnection connUser = new SqlConnection(strConnUser);
        connUser.Open();
        //读取数据库中的所属市县区
        string RegionSql = "select ItemName from Items_Area where ItemCode= '" + this.drpRegion.Text + "'";
        string CitySql = "select ItemName from Items_Area where ItemCode= '" + this.drpCity.Text + "'";
        string ProvinceSql = "select ItemName from Items_Area where ItemCode= '" + this.drpProvince.Text + "'";
        SqlCommand cmdRegion = new SqlCommand(RegionSql, connUser);
        SqlCommand cmdCity = new SqlCommand(CitySql, connUser);
        SqlCommand cmdProvince = new SqlCommand(ProvinceSql, connUser);
        string DiShiBianHao = null;
      
        //判断必填项是否为空
        if (this.drpProvince.Text == "-1" || this.drpCity.Text == "" || this.drpCity.Text == "-1" || this.drpRegion.Text == "" || this.drpRegion.Text == "-1" || this.drpHangYeBianHao.Text == "--请选择--" || this.drpIsTanJiaoYi.Text == "--请选择--" || this.drpMainHangYeBianHao.Text == "--请选择--" || this.drpLiShuGuanXi.Text == "--请选择--" || this.drpZhuCeLeiXing.Text == "--请选择--" || this.txtCompanyName.Text == "" || this.txtXiangXiDiZhi.Text == "" || this.txtEmail.Text == "" || this.txtZhuCeShiJian.Value == "" || this.txtFaRen.Text == "" || this.txtFaRenTel.Text == "" || this.txtLianXiRen.Text == "" || this.txtLianXiRenTel.Text == "" || this.txtLianXiRenEmail.Text == "" || this.FileUploadZuZhiJiGou.FileName == string.Empty || this.drpHasFenChang.Text == "--请选择--")
        {
            Response.Write("<script>alert('必填项不能为空!')</script>");
        }
        else
        {
            //读取数据库中的所属市县区
            string region = cmdRegion.ExecuteScalar().ToString();
            string city = cmdCity.ExecuteScalar().ToString();
            string province = cmdProvince.ExecuteScalar().ToString();
            DiShiBianHao = province + "-" + city + "-" + region;
            connUser.Close();

            SqlConnection connGHG = new SqlConnection(strConn);
            connGHG.Open(); 
            try
            {
                //判断记录是否存在
                if (DateIsExist.IsExist("*", "Company", "QiYeZuZhiJiGouDaiMa", Session["UserName"].ToString()))
                {
                    string savepathZuZhiJiGou = SaveZuZhiJiGouImage();
                    string savepathGongYiLiuCheng1=SaveGongYiLiuChengTuImage(this.txtCompanyName ,this.FileUploadGongYiLiuCheng1);
                    //string savepathGongYiLiuCheng=null;
                    if (this.drpHasFenChang.Text=="是")
                    {
                       
                        //savepathGongYiLiuCheng = SaveGongYiLiuChengTuImage(this.txtFenChangName, this.FileUploadGongYiLiuCheng1);
                    }
                    //记录存在则更新数据库
                    string strSql = "update Company set SheHuiXinYingDaiMa='" + this.txtXinYongDaiMa.Text + "', QiYeMingCheng='" + this.txtCompanyName.Text + "', HangYeBianHao= '" + Int32.Parse(this.drpHangYeBianHao.Text.Trim()) + "',MainHangYeMingCheng= '" + this.drpMainHangYeBianHao.Text + "', IsTanJiaoYi= '" + this.drpIsTanJiaoYi.Text + "',ZuZhiJiGouTu= '" + savepathZuZhiJiGou + "',ChanZhi='" + this.txtChanZhi.Text + "', ZengJiaZhi='" + this.txtZengJiaLiang.Text + "', JianZhuMianJi= '" + this.txtJianZhuMianJi.Text + "',IsHaveChild= '" + this.drpHasFenChang.Text + "',GongYiLiuCheng= '" + savepathGongYiLiuCheng1 + "',DiShiBianHao= '" + DiShiBianHao + "', XiangXiDiZhi= '" + this.txtXiangXiDiZhi.Text + "',YouBian= '" + this.txtEmail.Text + "',ChengLiShiJian='" + this.txtZhuCeShiJian.Value + "', ZhuCeLeiXing='" + this.drpZhuCeLeiXing.Text + "', LiShuGuanXi= '" + this.drpLiShuGuanXi.Text + "',FaRenDaiBiao= '" + this.txtFaRen.Text + "', FaRenDaiBiaoEmail= '" + this.txtFaRenEmail.Text + "',FaRenDaiBiaoTelNum= '" + this.txtFaRenTel.Text + "',LianXiRen='" + this.txtLianXiRen.Text + "', LianXiRenTelNum='" + this.txtLianXiRenTel.Text + "', LianXiRenGuHua= '" + this.LianXiRenGuHua.Value + "',LianXiRenFax= '" + this.txtFax.Text + "', LianXiRenEmail= '" + this.txtLianXiRenEmail.Text + "' where QiYeZuZhiJiGouDaiMa='" + this.txtQiYeZuZhiJiGouDaiMa.Value + "'";
                    SqlCommand cmd1 = new SqlCommand(strSql, connGHG);
                    cmd1.ExecuteNonQuery();
                }

                    //,FenChangMingCheng,GongYiLiuChengTu,FenChangDiZhi    ,FenChangMingCheng= '" + this.txtFenChangName.Text + "',GongYiLiuChengTu= '" + savepathGongYiLiuCheng + "', FenChangDiZhi= '" + this.txtAddress.Text + "' 
                else
                {
                    string savepath = SaveZuZhiJiGouImage();
                    //记录不存在,插入数据
                    string strSql = "insert into Company(QiYeZuZhiJiGouDaiMa,QiYeMingCheng,SheHuiXinYingDaiMa,HangYeBianHao,IsTanJiaoYi,ZuZhiJiGouTu,MainHangYeMingCheng,ChanZhi,ZengJiaZhi,JianZhuMianJi,IsHaveChild,DiShiBianHao,XiangXiDiZhi,YouBian,ChengLiShiJian,ZhuCeLeiXing,LiShuGuanXi,FaRenDaiBiao,FaRenDaiBiaoEmail,FaRenDaiBiaoTelNum,LianXiRen,LianXiRenTelNum,LianXiRenGuHua,LianXiRenFax,LianXiRenEmail) values('" + this.txtQiYeZuZhiJiGouDaiMa.Value + "','" + this.txtCompanyName.Text + "','" + this.txtXinYongDaiMa.Text + "','" + this.drpHangYeBianHao.Text + "','" + this.drpIsTanJiaoYi.Text + "','" + savepath+ "','" + this.drpMainHangYeBianHao.Text + "','" + this.txtChanZhi.Text + "','" + this.txtZengJiaLiang.Text + "','" + this.txtJianZhuMianJi.Text + "','" + this.drpHasFenChang.SelectedValue + "','" + DiShiBianHao + "','" + this.txtXiangXiDiZhi.Text + "','" + this.txtEmail.Text + "','" + this.txtZhuCeShiJian.Value.ToString() + "','" + this.drpZhuCeLeiXing.Text + "','" + this.drpLiShuGuanXi.Text + "','" + this.txtFaRen.Text + "','" + this.txtFaRenEmail.Text + "','" + this.txtFaRenTel.Text + "','" + this.txtLianXiRen.Text + "','" + this.txtLianXiRenTel.Text + "','" + this.LianXiRenGuHua.Value + "','" + this.txtFax.Text + "','" + this.txtLianXiRenEmail.Text + "')";
                    SqlCommand cmd = new SqlCommand(strSql, connGHG);
                    cmd.ExecuteNonQuery();
                }

                Response.Write("<script>alert('信息保存成功,请查看!');location.href='CompanyInfo.aspx';</script>");
            }


            catch (Exception)
            {

                throw;
            }

        }



    }


    /// <summary>
    /// 读取所属地市
    /// </summary>
    //protected string[] SuoShuDiShi(DropDownList drp1,DropDownList drp2,DropDownList drp3)
    //{
    //    //连接权限数据库
    //    string strConnUser = System.Configuration.ConfigurationManager.ConnectionStrings["UserCenter_GHG"].ConnectionString;
    //    SqlConnection connUser = new SqlConnection(strConnUser);
    //    connUser.Open();
    //    //读取数据库中的所属市县区
    //    string RegionSql = "select ItemName from Items_Area where ItemCode= '" + drp3.Text + "'";
    //    string CitySql = "select ItemName from Items_Area where ItemCode= '" + drp2.Text + "'";
    //    string ProvinceSql = "select ItemName from Items_Area where ItemCode= '" + drp1.Text + "'";
    //    SqlCommand cmdRegion = new SqlCommand(RegionSql, connUser);
    //    SqlCommand cmdCity = new SqlCommand(CitySql, connUser);
    //    SqlCommand cmdProvince = new SqlCommand(ProvinceSql, connUser);
    //    string region = cmdRegion.ExecuteScalar().ToString();
    //    string city = cmdCity.ExecuteScalar().ToString();
    //    string province = cmdProvince.ExecuteScalar().ToString();
    //    string[] s={province,city,region};
    //    return s;
    //}
    /// <summary>
    /// 保存组织机构图
    /// </summary>
    /// <returns></returns>
    protected string SaveZuZhiJiGouImage()
    {
        Boolean fileOK = false;
        string savepath = null;
       
        //获取上传的文件名
      
            string fileName = this.FileUploadZuZhiJiGou.FileName;

            string UpLoadName = DateTime.Now.Year.ToString();
            bool FileUploadPathExists = File.Exists(Server.MapPath("组织机构图" + "\\" + UpLoadName));
            string newFileName = Session["UserName"].ToString() + "-组织机构图";
            String fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
            //指定文件夹不存在，如果不存在就创建该文件夹
            if (!FileUploadPathExists)
            {
                Directory.CreateDirectory(Server.MapPath("组织机构图" + "\\" + UpLoadName));
            }
            savepath = Server.MapPath("组织机构图" + "\\" + UpLoadName);//保存路径

            //判断上传控件是否上传文件
            if (this.FileUploadZuZhiJiGou.HasFile)
            {
                //判断上传文件的扩展名是否为允许的扩展名".gif", ".png", ".jpeg", ".jpg" ,".bmp"

                String[] Extensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
                for (int i = 0; i < Extensions.Length; i++)
                {
                    if (fileExtension == Extensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            //如果上传文件扩展名为允许的扩展名，则将文件保存在服务器上指定的目录中
            if (fileOK)
            {
                try
                {
                    this.FileUploadZuZhiJiGou.PostedFile.SaveAs(savepath + "\\" + newFileName + fileExtension);
                }
                catch (Exception ex)
                {
                    MessageBox("文件不能上传，原因：" + ex.Message);
                }
            }
            else
            {
                MessageBox("只支持上传图片");
            }
          
       
        return newFileName;
    }
    /// <summary>
    /// 保存工艺流程图
    /// </summary>
    /// <returns></returns>
    protected string SaveGongYiLiuChengTuImage(TextBox t, FileUpload f)
    {
        Boolean fileOK = false;
        string savepath = null;

        //获取上传的文件名

        string fileName = f.FileName;

        string UpLoadName = DateTime.Now.Year.ToString();
        bool FileUploadPathExists = File.Exists(Server.MapPath("工艺流程图" + "\\" + UpLoadName));
        string newFileName = t.Text + "-工艺流程图";
        String fileExtension = System.IO.Path.GetExtension(fileName).ToLower();
        //指定文件夹不存在，如果不存在就创建该文件夹
        if (!FileUploadPathExists)
        {
            Directory.CreateDirectory(Server.MapPath("工艺流程图" + "\\" + UpLoadName));
        }
        savepath = Server.MapPath("工艺流程图" + "\\" + UpLoadName);//保存路径

        //判断上传控件是否上传文件
        if (f.HasFile)
        {
            //判断上传文件的扩展名是否为允许的扩展名".gif", ".png", ".jpeg", ".jpg" ,".bmp"

            String[] Extensions = { ".gif", ".png", ".jpeg", ".jpg", ".bmp" };
            for (int i = 0; i < Extensions.Length; i++)
            {
                if (fileExtension == Extensions[i])
                {
                    fileOK = true;
                }
            }
        }

        //如果上传文件扩展名为允许的扩展名，则将文件保存在服务器上指定的目录中
        if (fileOK)
        {
            try
            {
                f.PostedFile.SaveAs(savepath + "\\" + newFileName + fileExtension);
            }
            catch (Exception ex)
            {
                MessageBox("文件不能上传，原因：" + ex.Message);
            }
        }
        else
        {
            MessageBox("只支持上传图片");
        }
        return Session["UserName"].ToString()+newFileName;
    }

    protected void MessageBox(string str)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('" + str + "');</script>");
    }

    protected void drpHasFenChang_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.drpHasFenChang.SelectedValue=="否")
        {
            this.Panel4.Visible = false;
            this.btnAdd.Visible = false;
            this.Label1.Visible = false;
        }
        else
        {
            this.Panel4.Visible = true;
            this.btnAdd.Visible = true;
            this.Label1.Visible = true;
            
        }
        
    }


    /// <summary>
    /// 绑定企业信息
    /// </summary>
    protected void BindCompany()
    {
        conn.Open();
        string sql = "select * from Company where QiYeZuZhiJiGouDaiMa='" + Session["UserName"].ToString() + "'";
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
        sda.Fill(dt);
        
        this.txtCompanyName.Text = dt.Rows[0][2].ToString();
        this.txtXinYongDaiMa.Text = dt.Rows[0][3].ToString();
        this.drpHangYeBianHao.SelectedValue = dt.Rows[0][4].ToString();
        this.drpIsTanJiaoYi.SelectedValue = dt.Rows[0][5].ToString();
        //this.FileUploadZuZhiJiGou.FileName = dt.Rows[0][5].ToString();
        this.drpMainHangYeBianHao.SelectedValue = dt.Rows[0][7].ToString();
        this.txtChanZhi.Text = dt.Rows[0][8].ToString();
        this.txtZengJiaLiang.Text = dt.Rows[0][9].ToString();
        this.txtJianZhuMianJi.Text = dt.Rows[0][10].ToString();
        this.drpHasFenChang.SelectedValue = dt.Rows[0][11].ToString();
        //this.FileUploadGongYiLiuCheng1.FileName = dt.Rows[0][12].ToString();
        this.txtXiangXiDiZhi.Text = dt.Rows[0][14].ToString();
        this.txtEmail.Text = dt.Rows[0][15].ToString();
        this.txtZhuCeShiJian.Value = dt.Rows[0][16].ToString();
        this.drpZhuCeLeiXing.SelectedValue = dt.Rows[0][17].ToString();
        this.drpLiShuGuanXi.SelectedValue = dt.Rows[0][18].ToString();
        this.txtFaRen.Text = dt.Rows[0][19].ToString();
        this.txtFaRenEmail.Text = dt.Rows[0][20].ToString();
        this.txtFaRenTel.Text = dt.Rows[0][21].ToString();
        this.txtLianXiRen.Text = dt.Rows[0][22].ToString();
        this.txtLianXiRenTel.Text = dt.Rows[0][23].ToString();
        this.LianXiRenGuHua.Value = dt.Rows[0][24].ToString();
        this.txtFax.Text = dt.Rows[0][25].ToString();
        this.txtLianXiRenEmail.Text = dt.Rows[0][26].ToString();
        //this.txtFenChangName.Text = dt.Rows[0][27].ToString();
        //this.txtAddress.Text = dt.Rows[0][28].ToString();

        conn.Close();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
    //    string target = this.Request["btnAdd"];

    //    if (target == "添加")
    //    {
    //        count++;
    //    }
    //    for (int i = 0; i < count; i++)
    //    {

    //        Control c = LoadControl(@"~\Modules\Common\UserAdmin\FenChangControl.ascx");
    //        c.ID = "uc" + i.ToString();
    //        this.Panel5.Controls.Add(c);

    //    }
        //连接权限数据库
        conn.Open();



    }
}