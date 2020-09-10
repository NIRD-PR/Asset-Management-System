using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_AddInventory : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string name; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ChosenDropDown", "ChosenDropDown();", true);
        if (!IsPostBack)
        {
            getOldNew();
            getWarrenty();
            getAllItemTypes();
            getAllItemsinInventory();
            if (Request.QueryString["st"] != null)
            {
                hdn_IID.Value = Request.QueryString["st"].ToString();
                Update();
            }
            getItemTypes();
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
                name = dt.Rows[0]["Name"].ToString();
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void Update()
    {
        objPRReq.IID = int.Parse(hdn_IID.Value);
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getItemInventory_IID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_ItemType.SelectedIndex = int.Parse(dt.Rows[0]["ITID"].ToString());
            string ItemType = dt.Rows[0]["ItemType"].ToString();
            if (ItemType == "New")
            {
                ddl_NewOld.SelectedIndex = 2;
            }
            else
            {
                ddl_NewOld.SelectedIndex = 1;
            }
            txt_Model.Text = dt.Rows[0]["Model"].ToString();
            txt_ComputerNo.Text = dt.Rows[0]["ComputerNumber"].ToString();
            txt_Manufacturer.Text = dt.Rows[0]["Manufacturer"].ToString();
            txt_SerialNo.Text = dt.Rows[0]["SerialNo"].ToString();
            txt_PurchaseDate.Text = dt.Rows[0]["DOP"].ToString();
            txt_Vendor.Text = dt.Rows[0]["Vendor"].ToString();
            txt_WarrantyDate.Text = dt.Rows[0]["WarrantyDate"].ToString();
            string warranty = dt.Rows[0]["Warranty"].ToString();
            if(warranty == "No Warranty / No AMC")
            {
                ddl_Warranty.SelectedIndex = 3;
            }
            else if (warranty == "AMC")
            {
                ddl_Warranty.SelectedIndex = 2;
            }
            else
            {
                ddl_Warranty.SelectedIndex = 1;
            }

            btn_Submit.Text = "Update";
        }
    }
    public void getWarrenty()
    {
        ddl_Warranty.Items.Insert(0, "Select Warranty");
        ddl_Warranty.Items.Insert(1, "Warranty");
        ddl_Warranty.Items.Insert(2, "AMC");
        ddl_Warranty.Items.Insert(3, "No Warranty / No AMC");
        ddl_Warranty.DataBind();
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
    public void getOldNew()
    {
        ddl_NewOld.Items.Insert(0, "-- Select ---");
        ddl_NewOld.Items.Insert(1, "New");
        ddl_NewOld.Items.Insert(2, "Old");
        ddl_NewOld.DataBind();
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.Dated = DateTime.Now;
            objPRReq.UID = int.Parse(Session["UserID"].ToString());
            objPRReq.UName = name;
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            if (ddl_ItemType.SelectedIndex > 0)
            {
                objPRReq.ITID = int.Parse(ddl_ItemType.SelectedValue.ToString());
                objPRReq.ItemName = ddl_ItemType.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Item Category";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (ddl_NewOld.SelectedIndex > 0)
            {
                objPRReq.ItemType = ddl_NewOld.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Item Type";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (ddl_Warranty.SelectedIndex > 0)
            {
                objPRReq.Warranty = ddl_Warranty.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Warrenty Type";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (txt_Model.Text.Trim() != "")
            {
                objPRReq.ModelType = convertQuotes(txt_Model.Text.Trim());
            }
            else
            {
                string msg = "Enter Model";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (txt_SerialNo.Text.Trim() != "")
            {
                objPRReq.SerialNo = convertQuotes(txt_SerialNo.Text.Trim());
            }
            else
            {
                string msg = "Enter Serial Number";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (txt_Manufacturer.Text.Trim() != "")
            {
                objPRReq.Manufacturer = convertQuotes(txt_Manufacturer.Text.Trim());
            }
            else
            {
                string msg = "Enter Manufacturer";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            objPRReq.WarrantyDate = convertQuotes(txt_WarrantyDate.Text.Trim());
            objPRReq.Vendor = convertQuotes(txt_Vendor.Text.Trim());
            objPRReq.ComputerNo = convertQuotes(txt_ComputerNo.Text.Trim());
            objPRReq.DOP = convertQuotes(txt_PurchaseDate.Text.Trim());
            if (btn_Submit.Text != "Update")
            {
                PRResp r = objPRIBC.getItemInventory_SerialNo(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string msg = "Item is Already Registered with us..";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
                else
                {
                    objPRIBC.AddItemInventory(objPRReq);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Updated Successfully..!!!'); window.open('../CIT_ADDInv/{0}','_self');", true);
                }
            }
            else
            {
                objPRReq.IID = int.Parse(hdn_IID.Value);
                objPRIBC.EditItemInventory_SerialNo(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Updated Successfully..!!!'); window.open('../CIT_ADDInv/{0}','_self');", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }
    }
    public void getAllItemsinInventory()
    {
        if (ddl_ItemTypes.SelectedIndex > 0)
        {
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            objPRReq.ITID = int.Parse(ddl_ItemTypes.SelectedValue.ToString());
            PRResp r = objPRIBC.getAllItemInventory_ITID(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                lbl_Date.Text = DateTime.Now.ToString();
                lbl_ItemName.Text = ddl_ItemTypes.SelectedItem.Text.Trim()+"'s ";
                dt.DefaultView.Sort = "SerialNo Asc";
                rptr_InventoryData.DataSource = dt;
                rptr_InventoryData.DataBind();
                lbl_Count.Text = "No.of Items Listed :" + dt.Rows.Count.ToString();
            }
            else
            {
                rptr_InventoryData.DataSource = dt;
                rptr_InventoryData.DataBind();
                lbl_Count.Text = "No.of Items Listed :" + dt.Rows.Count.ToString();
            }
        }
        else
        {
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            PRResp r = objPRIBC.getAllItemInventory(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                lbl_Date.Text = DateTime.Now.ToString();
                lbl_ItemName.Text = "All items";
                dt.DefaultView.Sort = "SerialNo Asc";
                rptr_InventoryData.DataSource = dt;
                rptr_InventoryData.DataBind();
                lbl_Count.Text = "No.of Items Listed :" + dt.Rows.Count.ToString();
            }
        }
    }
    protected void rptr_InventoryData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_ADDInv/{0}?st=" + e.CommandArgument.ToString());
        }

        if (e.CommandName == "Delete")
        {
            objPRReq.OID = oid;
            objPRReq.IID = int.Parse(e.CommandArgument.ToString());
            objPRIBC.DelItemInventory(objPRReq);
            string msg = "Deleted Successfully...!!!";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            getAllItemTypes();
        }
    }
    public void getItemTypes()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getItemTypes(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_ItemTypes.DataSource = dt;
            ddl_ItemTypes.DataTextField = "ItemType";
            ddl_ItemTypes.DataValueField = "ITID";
            ddl_ItemTypes.DataBind();
            ddl_ItemTypes.Items.Insert(0, "Select Type");
        }
    }
    protected void ddl_ItemTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        getAllItemsinInventory();
    }
}