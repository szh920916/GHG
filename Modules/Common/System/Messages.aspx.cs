using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messages : System.Web.UI.Page
{
    // 提示框标题
    protected string Mtitle = string.Empty;
    // 提示框内容
    protected string Mbody = string.Empty;

    // 提示框内容
    protected string MessageType = string.Empty;

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["MessageType"] != null)
        {
            MessageType = Page.Request["MessageType"].ToString();
        }
        if (Page.Request["Mtitle"] != null)
        {
            Mtitle = Page.Request["Mtitle"].ToString();
        }
        if (Page.Request["Mbody"] != null)
        {
            Mbody = Page.Request["Mbody"].ToString();
        }
        if (Page.Request["MbuttonUrl"] != null)
        {
            this.txtMbuttonUrl.Value = Page.Request["MbuttonUrl"].ToString();
        }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // 读取参数
            this.GetParamter();
            if (MessageType.Equals("MessageError"))
            {
                this.imgMassage.ImageUrl = "../../../Themes/Blue/Images/MessageIcon/MessageError.gif";
            }
            else if (MessageType.Equals("MessageAlert"))
            {
                this.imgMassage.ImageUrl = "../../../Themes/Blue/Images/MessageIcon/MessageAlert.gif";
            }
            else
            {
                this.imgMassage.ImageUrl = "../../../Themes/Blue/Images/MessageIcon/MessageOk.gif";
            }
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(this.txtMbuttonUrl.Value) && !this.txtMbuttonUrl.Value.Equals("return"))
        {
            // 跳转页面
            Page.Response.Redirect(this.txtMbuttonUrl.Value);
        }
        if (!String.IsNullOrEmpty(this.txtMbuttonUrl.Value) && this.txtMbuttonUrl.Value.Equals("return"))
        {
            //返回上一页
            Response.Write("<script language=javascript>history.go(-2);</script>");
        }
    }
}
