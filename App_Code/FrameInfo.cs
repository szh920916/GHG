using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

/// <summary>
/// 获取当前模块的展开情况
/// </summary>
public class FrameInfo
{
    //private static FrameInfo instance;
    //private static Object locker = new Object();

    //public static FrameInfo Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            lock (locker)
    //            {
    //                if (instance == null)
    //                {
    //                    instance = new FrameInfo();
    //                }
    //            }
    //        }
    //        return instance;
    //    }
    //}

    /// <summary>
    /// 左侧框架是否展开,默认为是
    /// </summary>
    private bool _LeftFrameIsOpen = true;
    /// <summary>
    /// 左侧框架是否展开,默认为是
    /// </summary>
    public bool ShowLeftFrame
    {
        get { return (this._LeftFrameIsOpen); }
        set { this._LeftFrameIsOpen = value; }
    }

    /// <summary>
    /// 顶部框架是否展开,默认为是
    /// </summary>
    private bool _TopFrameIsOpen = true;
    /// <summary>
    /// 顶部框架是否展开,默认为是
    /// </summary>
    public bool ShowTopFrame
    {
        get { return (this._TopFrameIsOpen); }
        set { this._TopFrameIsOpen = value; }
    }

    /// <summary>
    /// 左框架展开宽度
    /// </summary>
    private int _LeftWidth = 160;
    /// <summary>
    /// 顶部框架是否展开,默认为160
    /// </summary>
    public int LeftWidth
    {
        get { return (this._LeftWidth); }
        set { this._LeftWidth = value; }
    }

    /// <summary>
    /// 上框架展开高度
    /// </summary>
    private int _TopExpandHeight = 100;
    /// <summary>
    /// 上框架展开高度,默认100
    /// </summary>
    public int TopExpandHeight
    {
        get { return (this._TopExpandHeight); }
        set { this._TopExpandHeight = value; }
    }

    /// <summary>
    /// 上框架收缩高度
    /// </summary>
    private int _TopShrinkHeight = 50;
    /// <summary>
    /// 上框架收缩高度,默认50
    /// </summary>
    public int TopShrinkHeight
    {
        get { return (this._TopShrinkHeight); }
        set { this._TopShrinkHeight = value; }
    }


    /// <summary>
    /// 构造器
    /// </summary>
    public FrameInfo()
    {
        Page p = new Page();
        try
        {
            p = (Page)System.Web.HttpContext.Current.Handler;

            this._LeftFrameIsOpen = p.Session["ShowLeftFrame"].ToString().ToLower().Equals("true");
            this._TopFrameIsOpen = p.Session["ShowTopFrame"].ToString().ToLower().Equals("true");

            this._LeftWidth = int.Parse(System.Configuration.ConfigurationManager.AppSettings["sysLeftWidth"].ToString());
            this._TopExpandHeight = int.Parse(System.Configuration.ConfigurationManager.AppSettings["sysTopOpenHeight"].ToString());
            this._TopShrinkHeight = int.Parse(System.Configuration.ConfigurationManager.AppSettings["sysTopOffHeight"].ToString());
        }
        catch
        {
            //未取到,重新生成session
            p.Session["ShowLeftFrame"] = "True";
            p.Session["ShowTopFrame"] = "True";
        }
    }
}