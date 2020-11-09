using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class Inventory_CITInventory : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid, egid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ChosenDropDown", "ChosenDropDown();", true);
        if (!IsPostBack)
        {
            getEmpType();
            getCITInventory();
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
    public void getEmpType()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getEmpGroups(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_EmpType.DataSource = dt;
            ddl_EmpType.DataTextField = "EmpGroup";
            ddl_EmpType.DataValueField = "EmpGroup";
            ddl_EmpType.DataBind();
            ddl_EmpType.Items.Insert(0, "--Select EmpType--");
        }
    }

    public void getEmpNames()
    {
        if (ddl_EmpType.SelectedIndex > 0)
        {
            objPRReq.EmpGroup = ddl_EmpType.SelectedItem.Text.Trim();
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            if (ddl_EmpType.SelectedItem.Text != "Project Staff")
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
            else
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
   
    protected void txt_Name_TextChanged(object sender, EventArgs e)
    {
        getEmpNames();
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
            if (ddl_EmpType.SelectedItem.Text != "Project Staff")
            {
                PRResp r = objPRIBC.getEmpDetails_EmpID(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    lbl_Dept.Text = dt.Rows[0]["DeptID"].ToString();
                    lbl_EmpID.Text = dt.Rows[0]["EmpID"].ToString();
                     lbl_Name.Text = dt.Rows[0]["Name"].ToString() + "(" + lbl_EmpID.Text + ")";
                    Label2.Text = dt.Rows[0]["Name"].ToString();
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
            else
            {
                PRResp r = objPRIBC.getPSEmpDetails_EmpID(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    lbl_Dept.Text = dt.Rows[0]["DeptID"].ToString();
                    lbl_EmpID.Text = dt.Rows[0]["EmpID"].ToString();
                    lbl_Name.Text = dt.Rows[0]["Name"].ToString() + "(" + lbl_EmpID.Text + ")";
                    Label2.Text = dt.Rows[0]["Name"].ToString();
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
                    Label2.Text = "";
                }
            }
            getCITInventory();
        }
    }
    public void getCITInventory()
    {
        if (ddl_EmpName.SelectedIndex > 0)
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.Flag1 = 1;
            objPRReq.EmpID = int.Parse(ddl_EmpName.SelectedValue.ToString());
            PRResp rr = objPRIBC.getEmp_MonthlySalayByEmpID_Status(objPRReq);
            DataTable drr = rr.GetTable;
            if (drr.Rows.Count > 0)
            {
                dl_EmpDetails.DataSource = drr;
                dl_EmpDetails.DataBind();
                DateTime dob = DateTime.Parse(drr.Rows[0]["DOB"].ToString());
                DateTime dor = dob.AddYears(60);
                // Retirement Date
                Label lbl_dor = (Label)dl_EmpDetails.Items[0].FindControl("lbl_DOR");
                lbl_dor.Text = dor.ToString("dd/MM/yyyy");
                // Current age
                Label lblage = (Label)dl_EmpDetails.Items[0].FindControl("lbl_Age");
                DateTime now = DateTime.Now;
                TimeSpan ts = now - dob;
                double year = (ts).Days / 365;
                lblage.Text = year.ToString();
            }
            else
            {
                dl_EmpDetails.DataSource = null;
                dl_EmpDetails.DataBind();
            }
            PRResp r = objPRIBC.getAllMappedInventory_EmpID(objPRReq);
            DataTable dt = r.GetTable;
            //if (dt.Rows.Count > 0)
            //{
                rptr_Items.DataSource = dt;
                rptr_Items.DataBind();
                //Label lblName =rptr_Items.FindControl("lbl_Name") as Label;
                //lblName.Text = uname.ToUpper();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataList dl = (DataList)rptr_Items.Items[i].FindControl("dl_CITData");
                    objPRReq.ITID = int.Parse(dt.Rows[i]["ITID"].ToString());
                    objPRReq.EmpID = int.Parse(ddl_EmpName.SelectedValue.ToString());
                    PRResp rk = objPRIBC.getAllMappedInventory_ITID_EmpID(objPRReq);
                    DataTable dtk = rk.GetTable;
                    if (dtk.Rows.Count > 0)
                    {
                        dl.DataSource = dtk;
                        dl.DataBind();
                    }
                    else
                    {
                        dl.DataSource = dtk;
                        dl.DataBind();
                    }
                }
            //}
        }
    }
    protected void rptr_InventoryData_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //if (e.CommandName == "Edit")
        //{
        //    Response.Redirect("../CIT_MAPInv/{0}?st=" + e.CommandArgument.ToString());
        //}

        //if (e.CommandName == "Delete")
        //{
        //    objPRReq.OID = oid;
        //    objPRReq.MIID = int.Parse(e.CommandArgument.ToString());
        //    objPRIBC.DelMappedITInvetoryItem(objPRReq);
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Deleted Successfully..!!!'); window.open('../CIT_EInv/{0}','_self');", true);
        //}

        if (e.CommandName == "Release")
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.MIID = int.Parse(e.CommandArgument.ToString());
            objPRReq.Flag1 = 0;
            objPRIBC.ReleaseMappedItem_EmpID(objPRReq);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Asset Released Successfully..!!!'); window.open('../CIT_EInv/{0}','_self');", true);

        }
    }
}