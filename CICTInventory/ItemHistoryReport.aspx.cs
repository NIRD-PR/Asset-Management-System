using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_ItemHistoryReport : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    int oid; string uname;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ChosenDropDown", "ChosenDropDown();", true);
        if (!IsPostBack)
        {
            getAllItemTypes();
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
    public void getAllItemTypes()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getItemTypes(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_ItemType.DataSource = dt;
            ddl_ItemType.DataTextField = "ItemType";
            ddl_ItemType.DataValueField = "ITID";
            ddl_ItemType.DataBind();
            ddl_ItemType.Items.Insert(0, "Select Type");
        }
    }
    protected void ddl_ItemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSerialNos();
    }
    public void getSerialNos()
    {
        if (ddl_ItemType.SelectedIndex > 0)
        {
            objPRReq.ITID = int.Parse(ddl_ItemType.SelectedValue.ToString());
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            PRResp r = objPRIBC.getItemInventory4SerialNo(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                dt.DefaultView.Sort = "SerialNo Asc";
                ddl_SerialNo.DataSource = dt;
                ddl_SerialNo.DataTextField = "SerialNo";
                ddl_SerialNo.DataValueField = "IID";
                ddl_SerialNo.DataBind();
                ddl_SerialNo.Items.Insert(0, "--Select SerialNo--");
            }
            else
            {
                ddl_SerialNo.Items.Clear();
                ddl_SerialNo.Items.Insert(0, "--No Data found--");
                ddl_SerialNo.DataBind();
            }
        }
    }

    public void getSerialNoDetails()
    {
        if (ddl_ItemType.SelectedIndex > 0)
        {
            objPRReq.ITID = int.Parse(ddl_ItemType.SelectedValue.ToString());
            objPRReq.SerialNo = ddl_SerialNo.SelectedItem.Text.Trim();
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            PRResp r = objPRIBC.getItemInventory_SerialNo(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                lbl_Model.Text = dt.Rows[0]["Model"].ToString();
                lbl_SerialNo.Text = dt.Rows[0]["SerialNo"].ToString();
                lbl_Warranty.Text = dt.Rows[0]["Warranty"].ToString();
                lbl_Manufacturer.Text = dt.Rows[0]["Manufacturer"].ToString();
                lbl_ItemNo.Text = dt.Rows[0]["ComputerNumber"].ToString();
            }
            else
            {
                lbl_Model.Text = "";
                lbl_SerialNo.Text = "";
                lbl_Warranty.Text = "";
                lbl_Manufacturer.Text = "";
                lbl_ItemNo.Text = "";
            }
        }
    }
    protected void ddl_SerialNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSerialNoDetails();
        getAllInvItems();
    }
    public void getAllInvItems()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.ITID = int.Parse(ddl_ItemType.SelectedValue.ToString());
        PRResp r = objPRIBC.getAllMappedInventory_SerialNo(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_Inventory.DataSource = dt;
            rptr_Inventory.DataBind();
        }
    }
}