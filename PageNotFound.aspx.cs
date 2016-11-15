using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;

public partial class PageNotFound : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.StatusCode = 404;
        Response.Status = "404 Not Found";
    }
}
