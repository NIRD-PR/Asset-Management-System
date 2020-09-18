using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_AssetRequest : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    int oid; string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        if (!IsPostBack)
        {
            getAllRequests();
            getAllPastRequests();
        }
    }
    public void getAdminUser()
    {
        if (Session["UserID"].ToString() != "")
        {
            objPRReq.Status = "Active";
            objPRReq.UID = int.Parse(Session["UserID"].ToString());
            PRResp resp = objPRIBC.getAdminData(objPRReq);
            DataTable dt = resp.GetTable;
            if (dt.Rows.Count > 0)
            {
                oid = int.Parse(dt.Rows[0]["OID"].ToString());
                uname = dt.Rows[0]["Name"].ToString();
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
    public void getAllRequests()
    {
        PRResp r = objPRIBC.getAllPendingAssetRequests(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_reqPending.DataSource = dt;
            rptr_reqPending.DataBind();
        }
    }
    public void getAllPastRequests()
    {
        PRResp r = objPRIBC.getAllPastAssetRequests(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_req.DataSource = dt;
            rptr_req.DataBind();
        }
    }
    protected void rptr_request_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Approve")
        {
            objPRReq.Status = "Approved";
            objPRReq.RID = int.Parse(e.CommandArgument.ToString());
            objPRIBC.changeRequest(objPRReq);
            Response.Redirect(Request.RawUrl);
        }
        if(e.CommandName == "rid")
        {
            hdn_rid.Value = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "show();", true);
        }
        
    }

    public string GetColor(string a)
    {
        if( a == "Active")
        {
            return "text-warning";
        }
        if( a == "Rejected")
        {
            return "text-danger";
        }
        return "text-success";
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        objPRReq.Status = "Rejected";
        objPRReq.Remarks = txt_remark.Text;
        objPRReq.RID = int.Parse(hdn_rid.Value);
        objPRIBC.changeRequest(objPRReq);
        Response.Redirect(Request.RawUrl);
    }

    protected void rptr_req_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "rid")
        {
            hdn_rid1.Value = e.CommandArgument.ToString();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "show1();", true);
        }
    }
    protected void btn_Submit_Click1(object sender, EventArgs e)
    {
        objPRReq.Remarks = txt_remark1.Text;
        objPRReq.RID = int.Parse(hdn_rid1.Value);
        objPRIBC.editRemark(objPRReq);
        Response.Redirect(Request.RawUrl);
    }
}