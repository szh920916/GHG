//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Zhengzhou Rising Software Technology Co., Ltd .
//------------------------------------------------------------

using System;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

/// <summary>
/// 树页面OUTLOOK菜单
/// </summary>
public class ydBar
{
    /// <summary>
    /// 构造器
    /// </summary>
    /// <param name="tab"></param>
    public ydBar(Table tab)
    {
        this._tab = tab;

        //初始化表及其他对象
        this.InitInfo();
    }

    #region 定义变量

    /// <summary>
    /// 菜单存放的表格对象
    /// </summary>
    private Table _tab = null;
    /// <summary>
    /// 菜单存放的表格对象
    /// </summary>
    private Table tab
    {
        get
        {
            return (this._tab);
        }
    }

    /// <summary>
    /// 当前存储参数数据表
    /// </summary>
    private Hashtable _dt = null;
    /// <summary>
    /// 当前存储参数数据表
    /// </summary>
    private Hashtable dt
    {
        get { return (this._dt); }
        set { this._dt = value; }
    }

    /// <summary>
    /// 生成iFrame语法
    /// </summary>
    private string strIFrame = "\"<iframe frameborder=0 height=100% width=100% src=\\\"\" + url + \"\\\"></iframe>\";";

    #endregion 结束定义属性

    #region 公共方法
    /// <summary>
    /// 添加新菜单
    /// </summary>
    /// <param name="Item">菜单对象</param>
    public void Add(MenuItem Item)
    {
        this.AddAt(this.dt.Count, Item);
    }


    /// <summary>
    /// 添加新菜单
    /// </summary>
    /// <param name="pos">要添加在哪个位置</param>
    /// <param name="Item">菜单对象</param>
    public void AddAt(int pos, MenuItem Item)
    {
        //添加行
        this.dt.Add(pos, Item);
    }

    /// <summary>
    /// 开始加载菜单
    /// </summary>
    /// <returns></returns>
    public bool Load()
    {
        try
        {
            //输出脚本
            this.CreateScript();

            //重新初始化对象
            this.InitLoadMenuItem();

            //将生成的行添加到表格中去
            int icount = this.dt.Count;
            for (int i = 0; i < icount; i++)
            {
                this.tab.Rows.Add(this.AddTitleRows((MenuItem)this.dt[i]));
                this.tab.Rows.Add(this.AddContentRows((MenuItem)this.dt[i]));
            }

            return (true);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    #endregion 公共方法

    #region 私有方法
    /// <summary>
    /// 初始化当前对象
    /// </summary>
    private void InitInfo()
    {
        //清除表格所有内容
        this.tab.Rows.Clear();
        //为表格添加样式
        this.tab.Attributes.Remove("border");
        this.tab.Attributes.Add("border", "1px");
        this.tab.BorderWidth = Unit.Pixel(1);
        this.tab.Style.Add("width", "100%");
        this.tab.Style.Add("height", "100%");
        this.tab.CellPadding = 0;
        this.tab.CellSpacing = 0;

        //初始化数据表
        this._dt = new Hashtable();
    }

    /// <summary>
    /// 重新计算菜单中的展开项
    /// </summary>
    private void InitLoadMenuItem()
    {
        bool isExpand = false;

        int iCount = this.dt.Count;
        if (iCount == 0) return;

        for (int i = 0; i < iCount; i++)
        {
            if (isExpand == false)
            {
                if (((MenuItem)this.dt[i]).IsExpand == true)
                {
                    isExpand = true;
                }
            }
            else
            {
                //当已经有展开项时,其他展开项全部置为否
                ((MenuItem)this.dt[i]).IsExpand = false;
            }
        }

        if (isExpand == false)
        {
            //如果都没有展开项,则默认展开第一项
            ((MenuItem)this.dt[0]).IsExpand = true;
        }
    }

    /// <summary>
    /// 添加标签行
    /// </summary>
    /// <param name="Item"></param>
    private TableRow AddTitleRows(MenuItem Item)
    {
        //标签行
        TableRow Title = new TableRow();
        Title.CssClass = "tdSelectBar";
        Title.Attributes.Add("onclick", "ydBarClick(this,'" + Item.Url + "','" + this.tab.Page.Server.UrlEncode(Item.OnClickScript.Replace(";", "").Replace("'", "\"")) + "');");
        TableCell TitleCell = new TableCell();
        TitleCell.Height = Unit.Pixel(22);
        TitleCell.HorizontalAlign = HorizontalAlign.Left;
        TitleCell.CssClass = "heardcss";
        TitleCell.Font.Bold = true;
        TitleCell.Text = "<img src=\"" + this.tab.Page.ResolveUrl("Themes/Blue/Images/normal/icon_to.gif") + "\" border=0 align=absmiddle> ";
        if (Item.LinkUrl != null && Item.LinkUrl != "")
        {
            TitleCell.Text += "<a href=\"" + Item.LinkUrl + "\" target=\"" + Item.LinkTarget + "\" title=\"" + Item.ToolTip + "\">" + Item.Text + "</a>";
        }
        else
        {
            TitleCell.Text += Item.Text;
        }
        Title.Cells.Add(TitleCell);

        return (Title);
    }

    /// <summary>
    /// 添加内容行
    /// </summary>
    /// <param name="Item"></param>
    private TableRow AddContentRows(MenuItem Item)
    {
        //内容行
        TableRow Content = new TableRow();
        Content.CssClass = "contentcss";
        Content.Style.Add("height", "100%");
        Content.Style.Add("display", Item.IsExpand ? "" : "none");

        TableCell ContentCell = new TableCell();
        ContentCell.VerticalAlign = VerticalAlign.Top;
        if (Item.IsExpand == true)
        {
            ContentCell.Text = "<iframe frameborder=0 height=100% width=100% src=\"" + Item.Url + "\"></iframe>";
        }
        Content.Cells.Add(ContentCell);


        return (Content);
    }


    /// <summary>
    /// 向页面输出脚本
    /// </summary>
    private void CreateScript()
    {
        //添加样式及脚本
        StringBuilder sb = new StringBuilder();
        sb.Append("     <script language=javascript> \n");
        sb.Append("     function ydBarClick(trObj,url,func) \n");
        sb.Append("     { \n");
        sb.Append("         var nextTr = $(trObj).next(\"tr\"); \n");

        sb.Append("         //当前行下一行为隐藏时,显示 \n");
        sb.Append("         //如果原来为显示的,则不再显示一次 \n");
        sb.Append("         if(nextTr.css(\"display\") == \"none\") \n");
        sb.Append("         { \n");
        sb.Append("             //为内容行添加iframe \n");
        sb.Append("             var nextTd = $(nextTr).find(\"td\").eq(0); \n");
        sb.Append("             if(nextTd.html() == \"\")\n");
        sb.Append("             {\n");
        sb.Append("                 var html = " + this.strIFrame + " \n");
        sb.Append("                 nextTd.html(html); \n");
        sb.Append("             }\n");
        sb.Append("             //显示内容行 \n");
        sb.Append("             $(nextTr).show(); \n");
        sb.Append("              \n");
        sb.Append("             //隐藏所有其他内容行 \n");
        sb.Append("             $(\".contentcss\").not(nextTr).hide(); \n");
        sb.Append("             if(func != null && func != ''){execScript(decodeURI(func));}\n\n");
        sb.Append("         } \n");
        sb.Append("         else \n");
        sb.Append("         { \n");
        sb.Append("             //如果原来已经显示了,检测其下是否还有其他标签,如果有,则隐藏当前,显示新标签\n");
        sb.Append("             var lastTr = $(trObj).next(\"tr\").next(\"tr\"); \n");
        sb.Append("             if(lastTr != null && lastTr.length >0) \n");
        sb.Append("             { \n");
        sb.Append("                 //找到下一个标签,点击它 \n");
        sb.Append("                 lastTr.click(); \n");
        sb.Append("             } \n");
        sb.Append("         } \n");

        ////自动设置页面展现样式
        //sb.Append(" $().ready(function()\n");
        //sb.Append(" {\n");
        //sb.Append("    var iBody = $(document.body);\n");
        //sb.Append("     alert($(iBody).attr(\"scroll\"));");
        //sb.Append("    if($(iBody).attr(\"scroll\") != \"no\")\n");
        //sb.Append("    {\n");
        //sb.Append("        $(iBody).attr(\"scroll\",\"no\");\n");
        //sb.Append("        $(iBody).css(\"margin\",\"0 0 0 0;\");\n");
        //sb.Append("    }\n");
        //sb.Append(" });\n");


        sb.Append("     } \n");
        sb.Append("     </script> \n");
        sb.Append("     <style type=\"text/css\"> \n");
        sb.Append("     .tdSelectBar \n");
        sb.Append("     { \n");
        sb.Append("         BACKGROUND-COLOR: #f4f4f4; \n");
        sb.Append("         width: 100%; \n");
        //sb.Append("         height: 100%; \n");
        sb.Append("         text-align: center; \n");
        sb.Append("         vertical-align : top; \n");
        sb.Append("         CURSOR: hand; \n");
        sb.Append("         border:#999999 1px solid; \n");
        sb.Append("     } \n");
        sb.Append("     </style> \n");
        sb.Append("  \n");

        this.tab.Page.ClientScript.RegisterClientScriptBlock(this.tab.Page.GetType(), "ydBarScript", sb.ToString());
    }

    #endregion 私有方法
}

/// <summary>
/// 菜单项
/// </summary>
public class MenuItem
{
    /// <summary>
    /// 当前菜单对象文本值
    /// </summary>
    private string _Text = string.Empty;
    /// <summary>
    /// 当前菜单对象文本值
    /// </summary>
    public string Text
    {
        get { return (this._Text); }
        set { this._Text = value; }
    }

    /// <summary>
    /// 点击当前菜单后转向的IFrame页面(下方)
    /// </summary>
    private string _Url = string.Empty;
    /// <summary>
    /// 点击当前菜单后转向的IFrame页面(下方)
    /// </summary>
    public string Url
    {
        get { return (this._Url); }
        set { this._Url = value; }
    }

    /// <summary>
    /// 当前菜单所链接的显示页面(框架右侧)
    /// </summary>
    private string _LinkUrl = string.Empty;
    /// <summary>
    /// 当前菜单所链接的显示页面(框架右侧)
    /// </summary>
    public string LinkUrl
    {
        get { return (this._LinkUrl); }
        set { this._LinkUrl = value; }
    }

    /// <summary>
    /// 当前菜单所链接的显示页面(框架右侧)打开方式,默认为fraContent
    /// </summary>
    private string _LinkTarget = "fraContent";
    /// <summary>
    /// 当前菜单所链接的显示页面(框架右侧)打开方式,默认为fraContent
    /// </summary>
    public string LinkTarget
    {
        get { return (this._LinkTarget); }
        set { this._LinkTarget = value; }
    }

    /// <summary>
    /// 是否展开,只能有一个展开
    /// </summary>
    private bool _IsExpand = false;
    /// <summary>
    /// 是否展开,只能有一个展开
    /// </summary>
    public bool IsExpand
    {
        get { return (this._IsExpand); }
        set { this._IsExpand = value; }
    }

    /// <summary>
    /// 点击菜单时响应的脚本事件,可带参数,但不可带;(分号)
    /// </summary>
    private string _OnClickScript = string.Empty;
    /// <summary>
    /// 点击菜单时响应的脚本事件,可带参数,但不可带;(分号)
    /// </summary>
    public string OnClickScript
    {
        get { return (this._OnClickScript); }
        set { this._OnClickScript = value; }
    }

    /// <summary>
    /// 菜单提示信息
    /// </summary>
    private string _ToolTip = string.Empty;
    /// <summary>
    /// 菜单提示信息
    /// </summary>
    public string ToolTip
    {
        get { return (this._ToolTip); }
        set { this._ToolTip = value; }
    }


    /// <summary>
    /// 构造器
    /// </summary>
    public MenuItem()
    {

    }


    /// <summary>
    /// 构造器
    /// </summary>
    /// <param name="Text">显示的文本</param>
    /// <param name="Url">指向的页面地址</param>
    public MenuItem(string Text, string Url)
    {
        this._Url = Url;
        this._Text = Text;
        this._IsExpand = false;
    }

    /// <summary>
    /// 构造器
    /// </summary>
    /// <param name="Text">显示的文本</param>
    /// <param name="Url">指向的页面地址</param>
    public MenuItem(string Text, string Url, bool isExpand)
    {
        this._Url = Url;
        this._Text = Text;
        this._IsExpand = IsExpand;
    }
}

public partial class LeftMain : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
}