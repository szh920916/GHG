var sPanelName = "";
var sPanelColSizes = "200,*";
var panelInfo = [["主菜单","Modules/Finance/UIPanelMenu.aspx"],["帮助","../../Modules/Finance/UIHelp.aspx"],["系统维护","Modules/Finance/UIAdminMenu.aspx"],["注销","../../UILogOut.aspx"]];

function showPanel(paramName, paramPath)
{
    if (paramName == sPanelName && paramPath != "")
    {
        closePanel();
    }
    else
    {
        sPanelName = paramName;
        document.all.tags( "FRAMESET" )[1].cols = sPanelColSizes;
        document.all.tags( "FRAME" )["PanelMenu"].src = paramPath;
        // alert(paramName);
        // var frm = frames["PanelHeader"];
        // alert(frm);
        frames["PanelHeader"].setHeader(paramName);
        // frm.setHeader(paramName);        
    }
}

//
// Close currently displayed panel
//
function closePanel()
{ 
    sPanelName = "";
    sPanelColSizes = document.all.tags( "frameset" )[1].cols;
    document.all.tags( "frameset" )[1].cols = "0,*";
}

function setPage(url)
{
    frames.fraContent.document.location.href = url;
}