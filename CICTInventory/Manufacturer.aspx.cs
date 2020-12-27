using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITInventory_Manufacturer : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string name; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
        if (!IsPostBack)
        {
            getAllManufacturers();
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
            Response.Redirect("~/CICTInventory/Default.aspx");
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
        PRResp r = objPRIBC.getManufacturerByMID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            txt_Manufacturer.Text = dt.Rows[0]["Name"].ToString();
            btn_Submit.Text = "Update";
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.Manufacturer = convertQuotes(txt_Manufacturer.Text.Trim());
            PRResp r = objPRIBC.getManufacturersByName(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                string msg = "Manufacturer " + txt_Manufacturer.Text.Trim() + " already registered..!!!";
                throw new Exception(msg);
            }
            if (btn_Submit.Text != "Update")
            {
                objPRIBC.AddManufacturers(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Manufacturer Added Successfully..!!!'); window.open('../CIT_Manu/{0}','_self');", true);
            }
            else
            {
                objPRReq.ID = int.Parse(Request.QueryString["st"].ToString());
                objPRIBC.EditManufacturerByMID(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Manufacturer Updated Successfully..!!!'); window.open('../CIT_Manu/{0}','_self');", true);
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
        rptr_Data.DataSource = dt;
        rptr_Data.DataBind();
        lbl_Count.Text = " No. of Manufacturers Listed : " + dt.Rows.Count.ToString();

    }
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_Manu/{0}?st=" + e.CommandArgument.ToString());
        }
        else
        {
            if (e.CommandName == "Delete")
            {
                objPRReq.ID = int.Parse(e.CommandArgument.ToString());
                objPRIBC.DelManufacturers(objPRReq);
                string msg = "Deleted Successfully...!!!";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                getAllManufacturers();
            }
        }
    }
}