function ShowControl(ElementID){
 document.getElementById(ElementID).style.display="block";
}

function HideControl(ElementID){
 document.getElementById(ElementID).style.display="none";
}

function InsertFlash(Flash,Width,Height,ID){
 document.write("<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" ");
 document.write("codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0\" ");
 document.write("width=\"" + Width + "\" height=\"" + Height + "\" id=\"" + ID + "\">");
 document.write("<param name=\"movie\" value=\"" + Flash + "\">");
 document.write("<param name=\"quality\" value=\"high\">");
 document.write("<param name=\"wmode\" value=\"transparent\">");
 document.write("<embed src=\"" + Flash + "\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" ");
 document.write("type=\"application/x-shockwave-flash\" width=\"" + Width + "\" height=\"" + Height + "\"></embed>");
 document.write("</object>");
}
