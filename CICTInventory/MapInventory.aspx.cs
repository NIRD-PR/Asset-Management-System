using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_MapInventory : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
         getAdminUser();
         if (!IsPostBack)
         {
             getAllItemTypes();
             getEmpType();
             if (Request.QueryString["st"] != null)
             {
                 hdn_MIID.Value = Request.QueryString["st"].ToString();
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
                uname = dt.Rows[0]["Name"].ToString(); 
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
    public void Update()
    {
        objPRReq.MIID = int.Parse(hdn_MIID.Value);
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getMappedInventory_MIID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_SerialNo.Text = dt.Rows[0]["SerialNo"].ToString();
            lbl_ItemType.Text = dt.Rows[0]["ItemName"].ToString();
            lbl_EmpName.Text = dt.Rows[0]["Name"].ToString();
            lbl_Warranty.Text = dt.Rows[0]["Warranty"].ToString();
            lbl_Manufacturer.Text = dt.Rows[0]["Manufacturer"].ToString();
            lbl_Model.Text = dt.Rows[0]["Model"].ToString();

            btn_Submit.Text = "Update";
        }
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
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
        //getSerialNos();
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
    }
    public void getEmpType()
    {
        ddl_EmpType.Items.Insert(0, "--Select --");
        ddl_EmpType.Items.Insert(1, "Academic");
        ddl_EmpType.Items.Insert(2, "Non-Academic");
        ddl_EmpType.Items.Insert(3, "Project Staff");
        ddl_EmpType.Items.Insert(4, "Others");
        ddl_EmpType.DataBind();
    }
    //public void getEmpType()
    //{
    //    objPRReq.OID = oid;
    //    objPRReq.Status = "Active";
    //    PRResp r = objPRIBC.getEmpGroups(objPRReq);
    //    DataTable dt = r.GetTable;
    //    if (dt.Rows.Count > 0)
    //    {
    //        ddl_EmpType.DataSource = dt;
    //        ddl_EmpType.DataTextField = "EmpGroup";
    //        ddl_EmpType.DataValueField = "EmpGroup";
    //        ddl_EmpType.DataBind();
    //        ddl_EmpType.Items.Insert(0, "--Select EmpType--");
    //    }
    //}

    public void getEmpNames()
    {
        if (ddl_EmpType.SelectedIndex > 0)
        {
            objPRReq.EmpGroup = ddl_EmpType.SelectedItem.Text.Trim();
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            objPRReq.Name = txt_Name.Text.Trim().Replace("'", "");
            if (ddl_EmpType.SelectedItem.Text != "Project Staff" && ddl_EmpType.SelectedItem.Text != "Others")
            {
                PRResp r = objPRIBC.SearchEmpNamebyGroup(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    ddl_EmpName.DataSource = dt;
                    ddl_EmpName.DataTextField = "Name";
                    ddl_EmpName.DataValueField = "EmpID";
                    ddl_EmpName.DataBind();
                    ddl_EmpName.Items.Insert(0, "--EmpName--");
                }
                else
                {
                    ddl_EmpName.Items.Insert(0, "--No Data Found--");
                    ddl_EmpName.DataBind();
                }
            }
            else if (ddl_EmpType.SelectedItem.Text == "Project Staff")
            {
                PRResp r = objPRIBC.SearchPSEmpDetails_EmpID(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    ddl_EmpName.DataSource = dt;
                    ddl_EmpName.DataTextField = "Name";
                    ddl_EmpName.DataValueField = "EmpID";
                    ddl_EmpName.DataBind();
                    ddl_EmpName.Items.Insert(0, "--EmpName--");
                }
                else
                {
                    ddl_EmpName.Items.Insert(0, "--No Data Found--");
                    ddl_EmpName.DataBind();
                }
            }
            else if (ddl_EmpType.SelectedItem.Text == "Others")
            {
                PRResp r = objPRIBC.SearchHallsByName(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    ddl_EmpName.DataSource = dt;
                    ddl_EmpName.DataTextField = "HallName";
                    ddl_EmpName.DataValueField = "HID";
                    ddl_EmpName.DataBind();
                    ddl_EmpName.Items.Insert(0, "--EmpName--");
                }
                else
                {
                    ddl_EmpName.Items.Insert(0, "--No Data Found--");
                    ddl_EmpName.DataBind();
                }
            }

        }
    }

    protected void ddl_EmpName_SelectedIndexChanged(object sender, EventArgs e)
    {
        getEmpDetails();
    }
    public void getEmpDetails()
    {
        if (ddl_EmpType.SelectedIndex > 0 && ddl_EmpName.SelectedIndex > 0)
        {
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            objPRReq.EmpID = int.Parse(ddl_EmpName.SelectedValue.ToString());
            if (ddl_EmpType.SelectedItem.Text != "Project Staff" && ddl_EmpType.SelectedItem.Text != "Others")
            {
                PRResp r = objPRIBC.getEmpDetails_EmpID(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    lbl_Dept.Text = dt.Rows[0]["DeptID"].ToString();
                    lbl_EmpID.Text = dt.Rows[0]["EmpID"].ToString();
                    lbl_Name.Text = dt.Rows[0]["Name"].ToString();
                    lbl_Design.Text = dt.Rows[0]["Design"].ToString();
                    hdn_DID.Value = dt.Rows[0]["DID"].ToString();
                    hdn_Email.Value = dt.Rows[0]["Email"].ToString();
                    hdn_Mobile.Value = dt.Rows[0]["Mobile"].ToString();
                }
                else
                {
                    lbl_Dept.Text = "";
                    lbl_EmpID.Text = "";
                    lbl_Name.Text = "";
                    lbl_Design.Text = "";
                }
            }
            else if (ddl_EmpType.SelectedItem.Text == "Project Staff")
            {
                PRResp r = objPRIBC.getPSEmpDetails_EmpID(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    lbl_Dept.Text = dt.Rows[0]["DeptID"].ToString();
                    lbl_EmpID.Text = dt.Rows[0]["EmpID"].ToString();
                    lbl_Name.Text = dt.Rows[0]["Name"].ToString();
                    lbl_Design.Text = dt.Rows[0]["Design"].ToString();
                    hdn_DID.Value = dt.Rows[0]["DID"].ToString();
                    hdn_Email.Value = dt.Rows[0]["Email"].ToString();
                    hdn_Mobile.Value = dt.Rows[0]["Mobile"].ToString();
                }
                else
                {
                    lbl_Dept.Text = "";
                    lbl_EmpID.Text = "";
                    lbl_Name.Text = "";
                    lbl_Design.Text = "";
                }
            }
            else if (ddl_EmpType.SelectedItem.Text == "Others")
            {
                PRResp r = objPRIBC.getHallDetails_HID(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    lbl_Dept.Text = dt.Rows[0]["Location"].ToString();
                    lbl_EmpID.Text = dt.Rows[0]["HID"].ToString();
                    lbl_Name.Text = dt.Rows[0]["HallName"].ToString();
                    lbl_Design.Text = dt.Rows[0]["Location"].ToString();
                    hdn_DID.Value = dt.Rows[0]["LID"].ToString();
                    hdn_Email.Value = "";
                    hdn_Mobile.Value = "0";
                }
                else
                {
                    lbl_Dept.Text = "";
                    lbl_EmpID.Text = "";
                    lbl_Name.Text = "";
                    lbl_Design.Text = "";
                }
            }
        }
    }
    protected void ddl_ItemTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        getAll_MappedItemsinInventory();
    }
    public void getAll_MappedItemsinInventory()
    {
        if (ddl_ItemTypes.SelectedIndex > 0)
        {
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            objPRReq.ITID = int.Parse(ddl_ItemTypes.SelectedValue.ToString());
            PRResp r = objPRIBC.getAllMappedInventory_ITID(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
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

    protected void rptr_InventoryData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_MAPInv/{0}?st=" + e.CommandArgument.ToString());
        }

        if (e.CommandName == "Delete")
        {
            objPRReq.OID = oid;
            objPRReq.MIID = int.Parse(e.CommandArgument.ToString());
            objPRIBC.DelMappedITInvetoryItem(objPRReq);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Deleted Successfully..!!!'); window.open('../CIT_MAPInv/{0}','_self');", true);
        }

        if (e.CommandName == "Release")
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.MIID = int.Parse(e.CommandArgument.ToString());
            objPRReq.Flag1 = 0;
            objPRIBC.ReleaseMappedItem_EmpID(objPRReq);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Released Successfully..!!!'); window.open('../CIT_MAPInv/{0}','_self');", true);
           
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (ddl_ItemType.SelectedIndex > 0)
        {
            objPRReq.ITID = int.Parse(ddl_ItemType.SelectedValue.ToString());
            objPRReq.ItemName = ddl_ItemType.SelectedItem.Text.Trim();
        }
        else
        {
            string msg = "Select Item Type";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }
        if (ddl_SerialNo.SelectedIndex > 0)
        {
            objPRReq.SerialNo = ddl_SerialNo.SelectedItem.Text.Trim();
            objPRReq.ModelType = lbl_Model.Text.Trim();
            objPRReq.Manufacturer = lbl_Manufacturer.Text.Trim();
            objPRReq.Warranty = lbl_Warranty.Text.Trim();
            objPRReq.ComputerNo = lbl_ItemNo.Text.Trim();
            
        }
        else
        {
            string msg = "Select SerialNo";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }

        if (ddl_EmpName.SelectedIndex > 0)
        {
            objPRReq.EmpID = int.Parse(lbl_EmpID.Text.Trim());
            objPRReq.Name = lbl_Name.Text.Trim();
            objPRReq.Email = hdn_Email.Value;
            objPRReq.Mobile = double.Parse(hdn_Mobile.Value);
            objPRReq.DID = int.Parse(hdn_DID.Value);
            objPRReq.DeptID = lbl_Dept.Text.Trim();
            objPRReq.Design = lbl_Design.Text.Trim();
        }
        else
        {
            string msg = "Select Name";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }

        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.UID = int.Parse(Session["UserID"].ToString());
        objPRReq.UName = uname;
        objPRReq.Dated = DateTime.Now;
        objPRReq.Flag1 = 1;

        if (btn_Submit.Text != "Update")
        {
            PRResp r = objPRIBC.getMappedInventory_SerialNo(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                string msg = "Item is Already Mapped with.. "+dt.Rows[0]["Name"].ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            }
            else
            {
                objPRIBC.MapITInventorytoEmp(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Mapped  Successfully..!!!'); window.open('../CIT_MAPInv/{0}','_self');", true);
            }
        }
        else
        {
            objPRReq.MIID = int.Parse(hdn_MIID.Value);
            objPRIBC.updateMappedItemtoOthers(objPRReq);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Updated Successfully..!!!'); window.open('../CIT_MAPInv/{0}','_self');", true);
        }
    }
    protected void txt_SNo_TextChanged(object sender, EventArgs e)
    {
        if (ddl_ItemType.SelectedIndex > 0)
        {
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            objPRReq.ITID = int.Parse(ddl_ItemType.SelectedValue.ToString());
            objPRReq.SerialNo = txt_SNo.Text.Trim();
            PRResp r = objPRIBC.getAllMappedInventory_ITID_SNo(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                ddl_SerialNo.Items.Clear();
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
    protected void txt_Name_TextChanged(object sender, EventArgs e)
    {
        getEmpNames();
    }
}