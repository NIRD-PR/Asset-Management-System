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
    string oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //lbl_Count.Text = Application["NoOfVisitors"].ToString();
        if (Session["UserID"].ToString() != "")
        {
            objPRReq.Status = "Active";
            objPRReq.CSID = int.Parse(Session["UserID"].ToString());
            PRResp resp = objPRIBC.getCITSSInfo(objPRReq);
            DataTable dt = resp.GetTable;
            if (dt.Rows.Count > 0)
            {
                dl_Admin.DataSource = dt;
                dl_Admin.DataBind(); lbl_Name.Text ="Welcome...! " + dt.Rows[0]["Name"].ToString().ToUpper();
                dl_top.DataSource = dt;
                dl_top.DataBind();
                oid = dt.Rows[0]["OID"].ToString();
                hdn_UEmpID.Value = dt.Rows[0]["EmpID"].ToString();
            }
            getUnAssignedTickets();
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

    public void getUnAssignedTickets()
    {
        objPRReq.OID = int.Parse(oid);
        objPRReq.Status = "Active";
        objPRReq.Flag1 = 0;
        PRResp r = objPRIBC.getTotalUnAssignedTickets_UEmpID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_UnAssignedTickets.Text = dt.Rows[0]["count"].ToString();
        }

        objPRReq.Flag1 = 1;
        objPRReq.UEmpID = int.Parse(hdn_UEmpID.Value);
        PRResp rn = objPRIBC.getAllNewTickets_UEmpID(objPRReq);
        DataTable dtn = rn.GetTable;
        if (dtn.Rows.Count > 0)
        {
            lbl_NewTickets.Text = dtn.Rows[0]["count"].ToString();
        }

        objPRReq.Flag2 = 1;
        PRResp rip = objPRIBC.getTotalInProgressTickets_UEmpID(objPRReq);
        DataTable dip = rip.GetTable;
        if (dip.Rows.Count > 0)
        {
            lbl_inprogressTickets.Text = dip.Rows[0]["count"].ToString();
        }

        objPRReq.Flag4 = 1;
        PRResp rc = objPRIBC.getTotalClosedTickets_UEmpID(objPRReq);
        DataTable dtc = rc.GetTable;
        if (dtc.Rows.Count > 0)
        {
            lbl_Closedtickets.Text = dtc.Rows[0]["count"].ToString();
        }
    }
}
