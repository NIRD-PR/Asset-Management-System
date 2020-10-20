using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.Globalization;

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
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
        if (!IsPostBack)
        {
            getOldNew();
            getWarrenty();
            getAllItemTypes();
            getAllItemsinInventory();
            getManufacturers();
            getSectionOfCenter();
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
        PRResp r = objPRIBC.getItemInventory_IID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_ItemType.SelectedIndex = int.Parse(dt.Rows[0]["ITID"].ToString());
            string ItemType = dt.Rows[0]["ItemType"].ToString();
            if (ItemType == "New")
            {
                ddl_NewOld.SelectedIndex = 1;
            }
            else
            {
                ddl_NewOld.SelectedIndex = 2;
            }
            txt_Model.Text = dt.Rows[0]["Model"].ToString();
            txt_ComputerNo.Text = dt.Rows[0]["ComputerNumber"].ToString();
            ddl_Manufacturer.SelectedValue = dt.Rows[0]["Manufacturer"].ToString().ToUpper();
            txt_SerialNo.Text = dt.Rows[0]["SerialNo"].ToString();
            txt_PurchaseDate.Text = dt.Rows[0]["DOP"].ToString();
            txt_Vendor.Text = dt.Rows[0]["Vendor"].ToString();
            txt_WarrantyDate.Text = dt.Rows[0]["WarrantyDate"].ToString();
            ddl_status.SelectedValue = dt.Rows[0]["Status"].ToString();
            efile.Text = dt.Rows[0]["eFile"].ToString();
            price.Text = dt.Rows[0]["Price"].ToString();
            bill.Text = dt.Rows[0]["Bill"].ToString();
            ddl_soc.SelectedValue = dt.Rows[0]["SectionofCenter"].ToString();
            string warranty = dt.Rows[0]["Warranty"].ToString();
            if (warranty == "Warranty")
            {
                ddl_Warranty.SelectedIndex = 1;
            }
            else if (warranty == "AMC")
            {
                ddl_Warranty.SelectedIndex = 2;
            }
            else
            {
                ddl_Warranty.SelectedIndex = 3;
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
    public void getManufacturers()
    {
        PRResp r = objPRIBC.getAllManufacturers(objPRReq);
        DataTable dt = r.GetTable;
        ddl_Manufacturer.DataSource = dt;
        ddl_Manufacturer.DataTextField = "Name";
        ddl_Manufacturer.DataValueField = "Name";
        ddl_Manufacturer.DataBind();
        ddl_Manufacturer.Items.Insert(0, "--Select Manufacturer--");
    }
    public void getSectionOfCenter()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getDepartments(objPRReq);
        DataTable dt = r.GetTable;
        ddl_soc.DataSource = dt;
        ddl_soc.DataTextField = "Department";
        ddl_soc.DataValueField = "DeptID";
        ddl_soc.DataBind();
        ddl_soc.Items.Insert(0, "--Select Center--");
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
            objPRReq.Status = ddl_status.SelectedItem.Text;
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

            if (ddl_Manufacturer.SelectedIndex > 0)
            {
                objPRReq.Manufacturer = ddl_Manufacturer.SelectedItem.Text.Trim();
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
            objPRReq.InvoiceNumber = bill.Text.Trim();
            if (price.Text.Length > 0)
            {
                try
                {
                    objPRReq.APrice = double.Parse(price.Text);
                }
                catch
                {
                    throw new Exception("Enter only a numeric value in Price");
                }
            }
            if (efile.Text.Length > 0)
            {
                try
                {
                    objPRReq.EID = int.Parse(efile.Text);
                }
                catch
                {
                    throw new Exception("Enter only a numeric value in eFile");
                }
            }
            if (ddl_soc.SelectedIndex > 0)
            {
                objPRReq.Department = ddl_soc.SelectedItem.Value.Trim();
            }
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Added Successfully..!!!'); window.open('../CIT_ADDInv/{0}','_self');", true);
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
            PRResp r = objPRIBC.getAllItemInventoryNotAbandoned(objPRReq);
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " window.open('../CIT_ADDInv/{0}','_self');", true);
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
    public string GetColor(string a)
    {
        if (a == "Active")
        {
            return "text-warning";
        }
        if (a == "Inactive")
        {
            return "text-info";
        }
        if (a == "Abandoned")
        {
            return "text-danger";
        }
        return "text-success";
    }
}