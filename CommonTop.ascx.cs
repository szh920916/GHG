//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Zhengzhou Rising Software Technology Co., Ltd .
//------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using System.Text;

using DotNet.Utilities;
using DotNet.Model;

public partial class CommonTop :BaseUserControl
{
    #region 定义属性
    /// <summary>
    /// 页面传递来的模块代码
    /// </summary>
    private string _myQuery;
    /// <summary>
    /// 页面传递来的模块代码
    /// </summary>
    public string myQuery
    {
        get { return (this._myQuery); }
        set { this._myQuery = value; }
    }

    /// <summary>
    /// 显示宽度,默认为100%
    /// </summary>
    private string _pageWidth;
    /// <summary>
    /// 显示宽度,默认为100%
    /// </summary>
    public string pageWidth
    {
        get { return (this._pageWidth); }
        set { this._pageWidth = value; }
    }

    /// <summary>
    /// 是否首页
    /// </summary>
    private bool _bolDefault = false;
    /// <summary>
    /// 是否首页
    /// </summary>
    public bool bolDefault
    {
        get { return (this._bolDefault); }
        set { this._bolDefault = value; }
    }

    /// <summary>
    /// flash动画高度
    /// </summary>
    private int _FlashHeight = 80;
    /// <summary>
    /// flash动画高度
    /// </summary>
    public int FlashHeight
    {
        get { return (this._FlashHeight); }
        set { this._FlashHeight = value; }
    }

    /// <summary>
    /// 系统路径 
    /// </summary>
    public string SysPath = "";

    #endregion 定义属性

    /// <summary>
    /// 加载页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 加载数据
    /// </summary>
    new public void Load()
    {
        //去掉部门，仅显示用户名 吴亚平 2011-1-14
        //this.lblLoginInfo.Text = this.UserInfo.RealName + " （" + this.UserInfo.DepartmentFullName + "）欢迎您使用本系统";
        this.lblLoginInfo.Text = this.UserInfo.RealName  + " 欢迎您使用本系统";
        this.UserCenterDbHelper.Open();
        //链接处理
        //设置为首页
        //this.hypSet.Attributes.Add("onclick", "javascript:this.style.behavior='url(#default#homepage)';this.setHomePage('河南省工业企业能源利用信息管理及能耗诊断预警系统'); return(false);");
        //this.hypSet.Style.Add("cursor", "hand");

        //添加到收藏
        //this.hypAdd.Attributes.Add("onclick", "javascript:window.external.addFavorite(window.location,'河南省工业企业能源利用信息管理及能耗诊断预警系统'); return(false);");
        //this.hypAdd.Style.Add("cursor", "hand");


        //显示日期与星期
        this.dateInfo.Text = "今天是 " + DateTime.Now.ToString("yyyy年MM月dd日") + " 星期" + this.GetWeekZn(DateTime.Now.DayOfWeek.GetHashCode() + 1);


        this.bannel1.Style.Add("width", this.pageWidth);
        this.bannel3.Style.Add("width", this.pageWidth);

        // 生成顶级模块
        this.LoadParentModule();

        if (this.bolDefault == true)
        {
            //首页不同
            this.bannel1.Style.Add("display", "block");
        }
        else
        {
            if ((new FrameInfo()).ShowTopFrame)
            {
                //上框架展开,则两个被隐藏的表格显示
                this.bannel1.Style.Add("display", "block");
            }
            else
            {
                //隐藏
                this.bannel1.Style.Add("display", "none");
            }
        }
        this.UserCenterDbHelper.Close();
    }

    /// <summary>
    /// 获取某个数字的中文表示(星期)
    /// </summary>
    /// <returns></returns>
    private string GetWeekZn(int i)
    {
        switch (i)
        {
            case 1:
                return ("日");
            case 2:
                return ("一");
            case 3:
                return ("二");
            case 4:
                return ("三");
            case 5:
                return ("四");
            case 6:
                return ("五");
            case 7:
                return ("六");
            default:
                return ("一");
        }
    }

    /// <summary>
    /// 生成顶级模块
    /// </summary>
    private void LoadParentModule()
    {
        StringBuilder moduleHtml = new StringBuilder();
        moduleHtml.Append("<table border=0>");
        moduleHtml.Append("<td align=left width=\"40\" nowrap class=\"menuclass\" onMouseOver=\"changeMenu(this);\" onMouseOut=\"OutMenu(this);\">");
        moduleHtml.Append("<a href=\"" + this.ResolveUrl("Work.aspx") + "\" target=_top>首 页</a>");
        moduleHtml.Append("</td>");
        moduleHtml.Append(this.GetSeparatorTd());
        // 判断是否为空
        if (this.DTModule != null)
        {
            string parentId = BaseBusinessLogic.GetProperty(this.DTModule, BaseModuleTable.FieldCode, BaseSystemInfo.RootMenuCode, BaseModuleTable.FieldId);
            foreach (DataRow dataRow in this.DTModule.Rows)
            {
                BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                if (moduleEntity.ParentId != null && moduleEntity.ParentId.ToString().Equals(parentId))
                {
                    moduleHtml.Append(this.GetMenu(moduleEntity.FullName, moduleEntity.Code, "Work.aspx?ModuleCode=" + moduleEntity.Code + "&Left=LeftMenu.aspx&Page=" + moduleEntity.NavigateUrl));
                }
            }
        }
        moduleHtml.Append("</table>");
        this.Module_Title.Text = moduleHtml.ToString();
    }

    /// <summary>
    /// 获得下面的菜单
    /// </summary>
    /// <param name="moduleName"></param>
    /// <param name="moduleCode"></param>
    /// <param name="moduleUrl"></param>
    /// <returns></returns>
    private string GetMenu(string moduleName, string moduleCode, string moduleUrl)
    {
        StringBuilder menuItem = new StringBuilder();
        string style = this.GetCurrentMenuStyle(moduleCode);
        menuItem.Append("<td height=\"20\" align=center" + style + " width=\"" + this.GetTdWidth(moduleName) + "\" nowrap onMouseOver=\"changeMenu(this);\" onMouseOut=\"OutMenu(this);\">");
        menuItem.Append("<a href=\"" + moduleUrl + "\" target=_top>" + moduleName + "</a>");
        menuItem.Append("</td><td width=4 align=center>|</td>");
        return menuItem.ToString();
    }

    private string GetCurrentMenuStyle(string moduleCode)
    {
        string style = " class=\"menuclass\"";
        if (Page.Request["ModuleCode"] != null)
        {
            if (Page.Request["ModuleCode"].Equals(moduleCode))
            {
                style = " class=\"menuclick\"";
            }
        }
        return style;
    }

    /// <summary>
    /// 获取分隔符列
    /// </summary>
    /// <returns></returns>
    private string GetSeparatorTd()
    {
        string str = "<td width=4 align=center>|</td>";
        return (str);
    }

    /// <summary>
    /// 根据模块名称求取该列占用的宽度
    /// </summary>
    /// <param name="mdl_name"></param>
    /// <returns></returns>
    private int GetTdWidth(string mdl_name)
    {
        return mdl_name.Length * 10 + 20;
    }
}