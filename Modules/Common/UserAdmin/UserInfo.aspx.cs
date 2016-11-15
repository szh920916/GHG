//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , Jirisoft , Ltd .
//-----------------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;



using DotNet.Model;
using DotNet.Manager;

/// <remarks>
/// UserInfo
/// 默认页面
///		
/// 修改记录
///
///		2008.10.05 版本：1.0 JiRiGaLa 建立代码。 
///		
/// 版本：1.0
///
/// <author>
///		<name>JiRiGaLa</name>
///		<date>2008.10.05</date>
/// </author> 
/// </remarks>
public partial class UserInfo : BasePage
{
    public string downloadUrl = string.Empty;

    #region private void BindContractYear() 绑定年份
    /// <summary>
    /// 绑定年份
    /// </summary>
    private void BindContractYear()
    {
        for (int i = DateTime.Now.Year - 50; i <= DateTime.Now.Year; i++)
        {
            ListItem listItem = new ListItem(i.ToString(), i.ToString());
            //this.ddlBirthYear.Items.Add(listItem);
        }
    }
    #endregion

    #region private void DoPageLoad() 页面初次加载时的动作
    /// <summary>
    /// 页面初次加载时的动作
    /// </summary>
    private void DoPageLoad()
    {
        try
        {
            this.BindContractYear();
            this.UserCenterDbHelper.Open();
            this.downloadUrl = ConfigurationManager.AppSettings["DownloadUrl"];
            this.ShowUser();
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
    }
    #endregion

    #region private void ShowUser(BaseUserEntity userEntity) 显示员工内容
    /// <summary>
    /// 用户对象
    /// </summary>
    /// <param name="userEntity"></param>
    private void ShowUser(BaseUserEntity userEntity)
    {
        this.txtUserName.Text = userEntity.UserName;
        this.txtRealName.Text = userEntity.RealName;
       

        if (!String.IsNullOrEmpty(userEntity.Birthday))
        {
            char[] flags = { '-' };
            //this.ddlBirthYear.SelectedValue = userEntity.Birthday.Split(flags)[0];
            //this.ddlBirthMonth.SelectedValue = userEntity.Birthday.Split(flags)[1];
            //this.ddlBirthDay.SelectedValue = userEntity.Birthday.Split(flags)[2];
        }
        this.txtMobile.Text = userEntity.Mobile;
        this.txtEmail.Text = userEntity.Email;
        this.txtQQ.Text = userEntity.OICQ;
    }
    #endregion

    #region private void ShowUser() 显示员工内容
    /// <summary>
    /// 显示员工内容
    /// </summary>
    private void ShowUser()
    {
        if (this.UserInfo.Id.Length > 0)
        {
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            //获取员工ID所约束的数据库记录
            DataTable dataTable = userManager.Get(this.UserInfo.Id);
            BaseUserEntity userEntity = new BaseUserEntity(dataTable);
            this.ShowUser(userEntity);
        }
        else
        {
            // 这条记录已经被删除了
            Page.Response.Redirect(Utilities.NotFindPage);
        }
    }
    #endregion

    #region private bool CheckInput() 检查页面的输入
    /// <summary>
    /// 检查页面的输入
    /// </summary>
    /// <returns>是否正确</returns>
    private bool CheckInput()
    {
        string checkInput = string.Empty;
        if (this.txtUserName.Text.Length == 0)
        {
            checkInput = "<script>alert('提示信息：请输入用户名。');document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "checkInput", checkInput);
            return false;
        }
        return true;
    }
    #endregion

    #region private BaseUserEntity GetEntity(BaseUserEntity userEntity) 从窗体读取奖励实体
    /// <summary>
    /// 从窗体读取用户实体
    /// </summary>
    /// <returns>用户</returns>
    private BaseUserEntity GetEntity(BaseUserEntity userEntity)
    {
        userEntity.UserName = this.txtUserName.Text;
        userEntity.RealName = this.txtRealName.Text;
        
        userEntity.Mobile = this.txtMobile.Text;
        userEntity.Email = this.txtEmail.Text;
        userEntity.OICQ = this.txtQQ.Text;
        return userEntity;
    }
    #endregion

    #region private void ClearForm() 清空页面
    /// <summary>
    /// 清空页面
    /// </summary>
    private void ClearForm()
    {
        // this.txtUserName.Text = string.Empty;
        this.txtRealName.Text = string.Empty;
        //this.txtStudentID.Text = string.Empty;
        //this.txtClass.Text = string.Empty;
        //this.rblSex.ClearSelection();
        //this.ddlBirthYear.SelectedIndex = 0;
        //this.ddlBirthMonth.SelectedIndex = 0;
        //this.ddlBirthDay.SelectedIndex = 0;
        this.txtMobile.Text = string.Empty;
        this.txtEmail.Text = string.Empty;
        this.txtQQ.Text = string.Empty;
    }
    #endregion

    #region private int DoUpdate(bool clearForm) 保存员工信息
    /// <summary>
    /// 保存员工信息
    /// </summary>
    /// <returns>员工代码</returns>
    private int DoUpdate(bool clearForm)
    {
        int returnValue = 0;
        // 检查页面的输入
        if (!this.CheckInput())
        {
            return returnValue;
        }
        try
        {
            this.UserCenterDbHelper.Open();
            BaseUserManager userManager = new BaseUserManager(this.UserCenterDbHelper, this.UserInfo);
            if (this.UserInfo.Id.Length > 0)
            {
                DataTable dataTable = userManager.Get(this.UserInfo.Id);
                BaseUserEntity userEntity = new BaseUserEntity(dataTable);
                this.GetEntity(userEntity);
                returnValue = userManager.UpdateEntity(userEntity);
            }
        }
        catch (Exception ex)
        {
            this.LogException(ex);
            throw ex;
        }
        finally
        {
            this.UserCenterDbHelper.Close();
        }
        // 显示提示信息
        if (Utilities.ShowInformation)
        {
            if (returnValue > 0)
            {
                // 提示修改成功
                this.ClientScript.RegisterStartupScript(this.GetType(), "updateSuccessed", "<script>alert('提示信息： 修改成功。');document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>");
            }
            else
            {
                // 提示修改失败
                this.ClientScript.RegisterStartupScript(this.GetType(), "updateFailure", "<script>alert('提示信息： 修改失败。');document.getElementById('" + this.txtUserName.ClientID + "').focus();</script>");
            }
        }
        return returnValue;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 页面初次加载时执行此方法
            this.DoPageLoad();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        this.DoUpdate(true);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        this.ClearForm();
    }

    protected void btnChangePwd_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("ChangePassword.aspx");
    }
}