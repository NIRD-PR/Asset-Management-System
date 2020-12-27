using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["st"] != null)
        {
            lbl_Error.Text = Request.QueryString["st"].ToString();
        }
        else
        {
            lbl_Error.Text = "";
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://erp.nirdpr.in");
    }
}