using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_Roles : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ChosenDropDown", "ChosenDropDown();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
        if (!IsPostBack)
        {
            getRoles();
            getAssignedRoles();
            getEmpType();
            // Updating of mapping feature (removed)
            //if (Request.QueryString["st"] != null)
            //{
            //    hdn_MIID.Value = Request.QueryString["st"].ToString();
            //    Update();
            //}
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
    //public void Update()
    //{
    //    objPRReq.MIID = int.Parse(hdn_MIID.Value);
    //    objPRReq.OID = oid;
    //    objPRReq.Status = "Active";
    //    PRResp r = objPRIBC.getMappedInventory_MIID(objPRReq);
    //    DataTable dt = r.GetTable;
    //    if (dt.Rows.Count > 0)
    //    {
    //        ddl_ItemType.SelectedIndex = int.Parse(dt.Rows[0]["ITID"].ToString());
    //        getSerialNos();
    //        objPRReq.ITID = int.Parse(dt.Rows[0]["ITID"].ToString());
    //        // next line causes error because the asset with this serial no. is no longer idle
    //        objPRReq.SerialNo = dt.Rows[0]["SerialNo"].ToString();
    //        PRResp r1 = objPRIBC.getItemInventory_SerialNo(objPRReq);
    //        DataTable dt1 = r1.GetTable;
    //        ddl_SerialNo.SelectedValue = dt1.Rows[0]["IID"].ToString();
    //        objPRReq.EmpID = double.Parse(dt.Rows[0]["EmpID"].ToString());
    //        PRResp r2 = objPRIBC.getEmpDetails_EmpID(objPRReq);
    //        DataTable dt2 = r2.GetTable;
    //        if(dt2.Rows.Count < 1)
    //        {
    //            r2 = objPRIBC.getPSEmpDetails_EmpID(objPRReq);
    //            dt2 = r2.GetTable;
    //        }
    //        ddl_EmpType.SelectedIndex = int.Parse(dt2.Rows[0]["EGID"].ToString());
    //        getEmpNames();
    //        ddl_EmpName.SelectedValue = dt2.Rows[0]["EmpID"].ToString();
    //        getEmpDetails();
    //        getSerialNoDetails();

    //        //lbl_SerialNo.Text = dt.Rows[0]["SerialNo"].ToString();
    //        //lbl_ItemType.Text = dt.Rows[0]["ItemName"].ToString();
    //        //lbl_EmpName.Text = dt.Rows[0]["Name"].ToString();
    //        //lbl_Warranty.Text = dt.Rows[0]["Warranty"].ToString();
    //        //lbl_Manufacturer.Text = dt.Rows[0]["Manufacturer"].ToString();
    //        //lbl_Model.Text = dt.Rows[0]["Model"].ToString();

    //        btn_Submit.Text = "Update";
    //    }
    //}
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void getRoles()
    {
        PRResp r = objPRIBC.getRoles(objPRReq);
        DataTable dt = r.GetTable;
        ddl_roles.DataSource = dt;
        ddl_roles.DataTextField = "Application";
        ddl_roles.DataValueField = "Role";
        ddl_roles.DataBind();
        ddl_roles.Items.Insert(0, "--Select Role--");
           
    }
    public void getEmpType()
    {
        ddl_EmpType.Items.Insert(0, "--Select --");
        ddl_EmpType.Items.Insert(1, "Academic");
        ddl_EmpType.Items.Insert(2, "Non-Academic");
        ddl_EmpType.Items.Insert(3, "Project Staff");
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
            PRResp r;
            DataTable dt;
            hdn_DSID.Value = null;
            hdn_photo.Value = null;
            if (ddl_EmpType.SelectedItem.Text != "Project Staff")
            {
                r = objPRIBC.getEmpDetails_EmpID(objPRReq);
                dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    lbl_Dept.Text = dt.Rows[0]["DeptID"].ToString();
                    lbl_EmpID.Text = dt.Rows[0]["EmpID"].ToString();
                    lbl_Name.Text = dt.Rows[0]["Name"].ToString();
                    lbl_Design.Text = dt.Rows[0]["Design"].ToString();
                    hdn_DID.Value = dt.Rows[0]["DID"].ToString();
                    hdn_Email.Value = dt.Rows[0]["Email"].ToString();
                    hdn_Mobile.Value = dt.Rows[0]["Mobile"].ToString();
                    hdn_DSID.Value = dt.Rows[0]["DSID"].ToString();
                    hdn_photo.Value = dt.Rows[0]["Photo"].ToString();
                }
                else
                {
                    lbl_Dept.Text = "";
                    lbl_EmpID.Text = "";
                    lbl_Name.Text = "";
                    lbl_Design.Text = "";
                }
            }
            else
            {
                r = objPRIBC.getPSEmpDetails_EmpID(objPRReq);
                dt = r.GetTable;
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
            dl_EmpDetails.DataSource = dt;
            dl_EmpDetails.DataBind();
            DateTime dob = DateTime.Parse(dt.Rows[0]["DOB"].ToString());
            DateTime dor = dob.AddYears(60);
            // Retirement Date
            Label lbl_dor = (Label)dl_EmpDetails.Items[0].FindControl("lbl_DOR");
            lbl_dor.Text = dor.ToString("dd/MM/yyyy");
            hdn_password.Value = dt.Rows[0]["Password"].ToString();
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.Flag1 = 1;
            objPRReq.EmpID = int.Parse(ddl_EmpName.SelectedValue.ToString());
            r = objPRIBC.getAdmin_Roles_EmpID(objPRReq);
            dt = r.GetTable;
            string s="";
            if(dt.Rows.Count > 0)
            {
                userid.Text = dt.Rows[0]["UserID"].ToString();
                userid.Enabled = false;
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (s.Length != 0)
                    {
                        s += " , ";
                    }
                    s+=dt.Rows[i]["Application"].ToString();
                }
            }
            Label lbl_roles = (Label)dl_EmpDetails.Items[0].FindControl("lbl_roles");
            lbl_roles.Text = s;
        }
    }
    //protected void rptr_InventoryData_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    if (e.CommandName == "Edit")
    //    {
    //        Response.Redirect("../CIT_MAPInv/{0}?st=" + e.CommandArgument.ToString());
    //    }

    //    if (e.CommandName == "Delete")
    //    {
    //        objPRReq.OID = oid;
    //        objPRReq.MIID = int.Parse(e.CommandArgument.ToString());
    //        objPRIBC.DelMappedITInvetoryItem(objPRReq);
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Deleted Successfully..!!!'); window.open('../CIT_MAPInv/{0}','_self');", true);
    //    }

    //    if (e.CommandName == "Release")
    //    {
    //        objPRReq.Status = "Active";
    //        objPRReq.OID = oid;
    //        objPRReq.MIID = int.Parse(e.CommandArgument.ToString());
    //        objPRReq.Flag1 = 0;
    //        objPRIBC.ReleaseMappedItem_EmpID(objPRReq);
    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Released Successfully..!!!'); window.open('../CIT_MAPInv/{0}','_self');", true);

    //    }
    //}
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (ddl_roles.SelectedIndex > 0)
        {
            objPRReq.ITID = int.Parse(ddl_roles.SelectedValue.ToString());
            objPRReq.Application = ddl_roles.SelectedItem.Text.Trim();
            objPRReq.Role = int.Parse(ddl_roles.SelectedValue.ToString());
        }
        else
        {
            string msg = "Please select Role";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }

        if (ddl_EmpName.SelectedIndex > 0)
        {
            objPRReq.UserID = userid.Text;
            objPRReq.EmpID = int.Parse(lbl_EmpID.Text.Trim());
            objPRReq.Name = lbl_Name.Text.Trim();
            objPRReq.Email = hdn_Email.Value;
            objPRReq.Password = hdn_password.Value;
            objPRReq.Mobile = double.Parse(hdn_Mobile.Value);
            objPRReq.DSID = int.Parse(hdn_DSID.Value);
            objPRReq.DeptID = lbl_Dept.Text.Trim();
            objPRReq.Design = lbl_Design.Text.Trim();
            objPRReq.Photo = hdn_photo.Value;
        }
        else
        {
            string msg = "Select Name";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }
        objPRReq.OrgName = "NIRDPR";
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.UID = int.Parse(Session["UserID"].ToString());
        objPRReq.UName = uname;
        objPRReq.Dated = DateTime.Now;
        objPRReq.Flag1 = 1;
        PRResp r = objPRIBC.getAdminRoleEmpID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            string msg = objPRReq.Application + " role is already assigned to " + objPRReq.Name;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" +msg+"');", true);
        }
        else
        {
            objPRIBC.AddRole(objPRReq);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Role assigned Successfully..!!!'); window.open('../Roles/{0}','_self');", true);
        }
    }
    protected void txt_Name_TextChanged(object sender, EventArgs e)
    {
        getEmpNames();
    }
    public void getAssignedRoles()
    {
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getAllAdmins(objPRReq);
        DataTable dt = r.GetTable;
        rptr_InventoryData.DataSource = dt;
        rptr_InventoryData.DataBind();
    }
}