using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITInventory_ItemType : System.Web.UI.Page
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
            getAllItemTypes();
            if (Request.QueryString["st"] != null)
            {
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
            Response.Redirect("~/CICTInventory/Default.aspx");
        }
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void Update()
    {
        objPRReq.ITID = int.Parse(Request.QueryString["st"].ToString());
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getItemTypeByOID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            txt_ItemType.Text = dt.Rows[0]["ItemType"].ToString();
            btn_Submit.Text = "Update";
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.ItemType = convertQuotes(txt_ItemType.Text.Trim());
            if (btn_Submit.Text != "Update")
            {
                PRResp r = objPRIBC.getItemTypeByName(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string msg = "ItemType of"+txt_ItemType.Text.Trim()+" already registered..!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
                else
                {
                    objPRIBC.AddItemType(objPRReq);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Added Successfully..!!!'); window.open('../CIT_InvItems/{0}','_self');", true);
                }
            }
            else
            {
                objPRReq.ITID = int.Parse(Request.QueryString["st"].ToString());
                objPRIBC.EditItemTypeByOID(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Updated Successfully..!!!'); window.open('../CIT_InvItems/{0}','_self');", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
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
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = " # of ItemTypes Listed : " + dt.Rows.Count.ToString();
        }
        else
        {
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = " # of ItemTypes Listed : " + dt.Rows.Count.ToString();
        }
    }
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_InvItems/{0}?st=" + e.CommandArgument.ToString());
        }
        else
            if (e.CommandName == "Delete")
            {
                objPRReq.OID = oid;
                objPRReq.ITID = int.Parse(e.CommandArgument.ToString());
                objPRIBC.DelItemType(objPRReq);
                string msg = "Deleted Successfully...!!!";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                getAllItemTypes();
            }
    }
}