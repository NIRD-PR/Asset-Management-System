using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITInventory_Models : System.Web.UI.Page
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
            getAllManufacturers();
            getModels();
            if (Request.QueryString["st"] != null)
            {
                Update();
            }
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
        objPRReq.ID = int.Parse(Request.QueryString["st"].ToString());
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getModelByMID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_manufacturer.SelectedValue = dt.Rows[0]["Manufacturer"].ToString();
            txt_model.Text = dt.Rows[0]["Model"].ToString();
            btn_Submit.Text = "Update";
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_manufacturer.SelectedIndex == 0)
            {
                string msg = "Please Select a Manufacturer..!!!";
                throw new Exception(msg);
            }
            objPRReq.Manufacturer = ddl_manufacturer.SelectedItem.Text;
            objPRReq.ModelType = convertQuotes(txt_model.Text.Trim());
            PRResp r = objPRIBC.getModelByName(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                string msg = "Model " + txt_model.Text.Trim() + ", Manufacturer " + objPRReq.Manufacturer + " already registered..!!!";
                throw new Exception(msg);
            }
            if (btn_Submit.Text != "Update")
            {
                objPRIBC.AddModel(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Model Added Successfully..!!!'); window.open('../CIT_Models/{0}','_self');", true);
            }
            else
            {
                objPRReq.ID = int.Parse(Request.QueryString["st"].ToString());
                objPRIBC.EditModelByMID(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Model Updated Successfully..!!!'); window.open('../CIT_Models/{0}','_self');", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
        }

    }
    public void getAllManufacturers()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getAllManufacturers(objPRReq);
        DataTable dt = r.GetTable;
        dt.DefaultView.Sort = "Name asc";
        ddl_manufacturer.DataSource = dt;
        ddl_manufacturer.DataTextField = "Name";
        ddl_manufacturer.DataValueField = "Name";
        ddl_manufacturer.DataBind();
        ddl_manufacturer.Items.Insert(0, "--Select Manufacturer--");

    }
    public void getModels()
    {
        if (ddl_manufacturer.SelectedIndex > 0)
        {
            objPRReq.Manufacturer = ddl_manufacturer.SelectedItem.Text;
            PRResp r = objPRIBC.getModelByManufacturer(objPRReq);
            DataTable dt = r.GetTable;
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            manufacturer.Text = objPRReq.Manufacturer + "'s ";
        }
        else
        {
            rptr_Data.DataSource = null;
            rptr_Data.DataBind();
            manufacturer.Text = "";
        }
    }
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_Models/{0}?st=" + e.CommandArgument.ToString());
        }
        else
        {
            if (e.CommandName == "Delete")
            {
                objPRReq.ID = int.Parse(e.CommandArgument.ToString());
                objPRIBC.DelModel(objPRReq);
                string msg = "Deleted Successfully...!!!";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                getAllManufacturers();
            }
        }
    }

    protected void ddl_manufacturer_SelectedIndexChanged(object sender, EventArgs e)
    {
        getModels();
    }
}
