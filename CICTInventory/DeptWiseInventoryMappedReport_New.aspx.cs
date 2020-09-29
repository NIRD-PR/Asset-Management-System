using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_DeptWiseInventoryMappedReport : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname, deptname = "CICT"; int oid = 1, did = 14;
    int amc = 0, ww = 0, oth = 0, tot = 0;
    int tamc = 0, tww = 0, toth = 0, ttot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
        if (!IsPostBack)
        {
            getAllInvItems();
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
    public void getAllInvItems()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getMappedInventoryDeptWise(objPRReq);
        DataTable dt = r.GetTable;
        rptr_Inventory.DataSource = dt;
        rptr_Inventory.DataBind();
        lbl_Count.Text = "No.of Items Listed : " + dt.Rows.Count.ToString();
        lbl_ItemCount.Text = "No.of Items Listed : " + dt.Rows.Count.ToString();
        lbl_Dated.Text = DateTime.Now.ToString();
        int d = dt.Select().Sum(v => Convert.ToInt32(v["Desktop"]));
        int l = dt.Select().Sum(v => Convert.ToInt32(v["Laptop"]));
        int p = dt.Select().Sum(v => Convert.ToInt32(v["Printer"]));
        int s = dt.Select().Sum(v => Convert.ToInt32(v["Scanner"]));
        int a = dt.Select().Sum(v => Convert.ToInt32(v["All-in-One"]));
        int t = dt.Select().Sum(v => Convert.ToInt32(v["Tablet"]));
        (rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("d") as Label).Text = d.ToString();
        (rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("l") as Label).Text = l.ToString();
        (rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("p") as Label).Text = p.ToString();
        (rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("s") as Label).Text = s.ToString();
        (rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("a") as Label).Text = a.ToString();
        (rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("t") as Label).Text = t.ToString();
    }
}