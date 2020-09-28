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
    int oid; string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ChosenDropDown", "ChosenDropDown();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
        if (!IsPostBack)
        {
            getITemType();
            getAllInvItems();
        }
    }
    public void getITemType()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getAllHWItemTypes(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_Item.DataSource = dt;
            ddl_Item.DataTextField = "ItemType";
            ddl_Item.DataValueField = "ITID";
            ddl_Item.DataBind();
            ddl_Item.Items.Insert(0, "-- Select ---");
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
        PRResp r;
        DataTable dt;
        if (ddl_Item.SelectedIndex > 0)
        {
            objPRReq.ITID = int.Parse(ddl_Item.SelectedValue.ToString());
            r = objPRIBC.getAllItemInventory_DeptWise_NameWise_ITID(objPRReq);
            dt = r.GetTable;
        }
        else
        {
            r = objPRIBC.getAllItemInventory_DeptWise_NameWise(objPRReq);
            dt = r.GetTable;
        }
        if (dt.Rows.Count > 0)
        {
            rptr_Inventory.DataSource = dt;
            rptr_Inventory.DataBind();
            lbl_Count.Text = "No.of Records Listed : " + dt.Rows.Count.ToString();
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        getAllInvItems();
    }
}