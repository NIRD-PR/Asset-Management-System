using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class Inventory : System.Web.UI.MasterPage
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //lbl_Count.Text = Application["NoOfVisitors"].ToString();
        if (Session["UserID"].ToString() != "")
        {
            objPRReq.Status = "Active";
            objPRReq.UID = int.Parse(Session["UserID"].ToString());
            PRResp resp = objPRIBC.getAdminData(objPRReq);
            DataTable dt = resp.GetTable;
            if (dt.Rows.Count > 0)
            {
                dl_Admin.DataSource = dt;
                dl_Admin.DataBind(); lbl_Name.Text ="Welcome...! " + dt.Rows[0]["Name"].ToString().ToUpper();
                dl_top.DataSource = dt;
                dl_top.DataBind();
                oid = int.Parse(dt.Rows[0]["OID"].ToString());
            }
            getNewTickets();
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void dl_Admin_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Logout")
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
   
    protected void lbtn_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }

    public void getNewTickets()
    {
        objPRReq.OID = oid;
        objPRReq.Flag1 = 0;
        PRResp r = objPRIBC.getAllUnAssignedTickets_Head(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_NewTickets.Text = dt.Rows[0]["count"].ToString();
        }
    }
}
