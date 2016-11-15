//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Zhengzhou Rising Software Technology Co., Ltd .
//------------------------------------------------------------

using System;
using System.Data;
using System.Web.UI;
using DotNet.Utilities;
using DotNet.Model;

public partial class LeftMenu : BasePage
{
    // 1。需要读取参数，知道现在需要调用的是哪个模块
    // 2。当前模块的ID主键是什么？
    // 3。从当前用户的允许访问的模块里获取ParenID为模块ID的数据进行加载菜单
    // 4。需要修改文件名，修改为LeftMenu就可以了。
    // 5。将其他多余的菜单全部删除掉，文件数量少了，程序编译的速度也会快，需要维护的内容也会少一些。
    // 6。子菜单也需要进行一次整理，把多余的都删除掉，这样菜单用工具修改于前台就可以彻底同步了。

    private string ModuleCode = string.Empty;

    #region private void GetParamter() 读取参数
    /// <summary>
    /// 读取参数
    /// </summary>
    private void GetParamter()
    {
        if (Page.Request["ModuleCode"] != null)
        {
            this.ModuleCode = Page.Request["ModuleCode"].ToString();
        }
        else
        {
            this.ModuleCode = BaseSystemInfo.RootMenuCode;
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        this.GetParamter();
        this.LoadMenu();
    }

    private void LoadMenu()
    {
        if (String.IsNullOrEmpty(this.ModuleCode))
        {
            return;
        }
        string parentId = BaseBusinessLogic.GetProperty(this.DTModule, BaseModuleTable.FieldCode, this.ModuleCode, BaseModuleTable.FieldId);
        this.LoadMenu(parentId);
    }

    private void LoadMenu(string parentId)
    {
        if (String.IsNullOrEmpty(parentId))
        {
            return;
        }
        //吴亚平修改，如果是点击的根，则显示整棵树，否则，只显示选择项
        DataRow[] dataRows = null;
        if (this.ModuleCode == BaseSystemInfo.RootMenuCode)
        {
            dataRows = this.DTModule.Select(BaseModuleTable.FieldParentId + "='" + parentId + "'", BaseModuleTable.FieldSortCode);
        }
        else
        {
            dataRows = this.DTModule.Select(BaseModuleTable.FieldId + "='" + parentId + "'", BaseModuleTable.FieldSortCode);
        }
        
        ydBar menu = new ydBar(this.tblMenu);
        MenuItem Item = null;
        foreach (DataRow dataRow in dataRows)
        {
            Item = new MenuItem();
            Item.Text = dataRow[BaseModuleTable.FieldFullName].ToString();
            Item.LinkUrl = dataRow[BaseModuleTable.FieldNavigateUrl].ToString();
            Item.LinkTarget = dataRow[BaseModuleTable.FieldTarget].ToString();
            Item.Url = "LeftSubMenu.aspx?ModuleCode=" + dataRow[BaseModuleTable.FieldCode].ToString();
            Item.IsExpand = true;
            Item.ToolTip = dataRow[BaseModuleTable.FieldFullName].ToString();
            menu.Add(Item);
        }
        menu.Load();
    }
}