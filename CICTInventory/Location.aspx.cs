using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITInventory_Location : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string name; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        if (!IsPostBack)
        {
            getAllLocations();
            if (Request.QueryString["st"] != null)
            {
                hdn_LID.Value = Request.QueryString["st"].ToString();
                Update();
            }
        }
    }
    public void getAdminUser()
    {
        if (Session["UserID"].ToString()!="")
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
        objPRReq.LID = int.Parse(hdn_LID.Value);
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getLocationByLID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            txt_Location.Text = dt.Rows[0]["Location"].ToString();
            btn_Submit.Text = "Update";
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.Location = convertQuotes(txt_Location.Text.Trim());
            if (btn_Submit.Text != "Update")
            {
                PRResp r = objPRIBC.getLocationByName(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string msg = "Location : "+txt_Location.Text.Trim()+" already registered..!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
                else
                {
                    objPRIBC.AddLocation(objPRReq);
                    string msg = txt_Location.Text.Trim() + " Registered Successfully...!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                    getAllLocations();
                    txt_Location.Text = "";
                }
            }
            else
            {
                objPRReq.LID = int.Parse(hdn_LID.Value);
                objPRIBC.EditLocationByLID(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('"+txt_Location.Text+" Updated Successfully..!!!'); window.open('../CIT_Location/{0}','_self');", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
        }
        
    }
    public void getAllLocations()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getLocation(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "Location Asc";
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = " # of Locations Listed : " + dt.Rows.Count.ToString();
        }
        else
        {
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = " # of Location Listed : " + dt.Rows.Count.ToString();
        }
    }
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_Location/{0}?st=" + e.CommandArgument.ToString());
        }
        else
            if (e.CommandName == "Delete")
            {
                objPRReq.OID = oid;
                objPRReq.LID = int.Parse(e.CommandArgument.ToString());
                objPRIBC.DelLocation(objPRReq);
                string msg = "Deleted Successfully...!!!";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                getAllLocations();
            }
    }
}