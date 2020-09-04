using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITInventory_Floors : System.Web.UI.Page
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
            getAllFloorss();
            if (Request.QueryString["st"] != null)
            {
                hdn_FLID.Value = Request.QueryString["st"].ToString();
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
        if (Request.QueryString["st"] != null)
        {
            objPRReq.FLID = int.Parse(hdn_FLID.Value);
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            PRResp r = objPRIBC.getFloorByFLID(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                txt_Floors.Text = dt.Rows[0]["Floor"].ToString();
                btn_Submit.Text = "Update";
            }
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.Floor = convertQuotes(txt_Floors.Text.Trim());
            if (btn_Submit.Text != "Update")
            {
                PRResp r = objPRIBC.getFloorByName(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string msg = "Hostel Floor of "+txt_Floors.Text.Trim()+" already registered..!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
                else
                {
                    objPRIBC.AddFloor(objPRReq);
                    string msg = txt_Floors.Text.Trim() + " Registered Successfully...!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                    getAllFloorss();
                    txt_Floors.Text = "";
                }
            }
            else
            {
                objPRReq.FLID = int.Parse(hdn_FLID.Value);
                objPRIBC.EditFloorByFLID(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + txt_Floors.Text + " Updated Successfully..!!!'); window.open('../CIT_Floor/{0}','_self');", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
        }
        
    }
    public void getAllFloorss()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getFloors(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "Floor Asc";
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = " # of Floors Listed : " + dt.Rows.Count.ToString();
        }
        else
        {
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = " # of Floors Listed : " + dt.Rows.Count.ToString();
        }
    }
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_Floor/{0}?st=" + e.CommandArgument.ToString());
        }
        else
            if (e.CommandName == "Delete")
            {
                objPRReq.OID = oid;
                objPRReq.FLID = int.Parse(e.CommandArgument.ToString());
                objPRIBC.DelFloor(objPRReq);
                string msg = "Deleted Successfully...!!!";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                getAllFloorss();
            }
    }
}