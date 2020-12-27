using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class AddRole : System.Web.UI.Page
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
            PRResp r = objPRIBC.getMaxRole(objPRReq);
            DataTable dt = r.GetTable;
            txt_role.Text = (int.Parse(dt.Rows[0].ItemArray[0].ToString()) + 1).ToString();
            getAllRoles();
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
            if (dt.Rows.Count > 0 && dt.Rows[0]["Role"].ToString() == "0")
            {
                oid = int.Parse(dt.Rows[0]["OID"].ToString());
                name = dt.Rows[0]["Name"].ToString();
            }
            else
            {
                Session.Abandon();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('Unauthorized User. Access Denied. Please Login on this Page.');window.open('../Admin/Default.aspx','_self');", true);
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Admin/Default.aspx");
        }
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.RoleType = convertQuotes(txt_application.Text.Trim());
            try
            {
                objPRReq.Role = int.Parse(txt_role.Text.Trim());
            }
            catch
            {
                throw new Exception("Enter only a number in Role Number");
            }
            PRResp r = objPRIBC.getARole(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                string msg = "Role " + txt_application.Text.Trim() + " already registered..!!!";
                throw new Exception(msg);
            }
            objPRIBC.AddRoleTable(objPRReq);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Role Added Successfully..!!!'); window.open('../AddRole/{0}','_self');", true);
            
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
        }

    }
    public void getAllRoles()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getRoles(objPRReq);
        DataTable dt = r.GetTable;
        dt.DefaultView.Sort = "Role asc";
        rptr_Data.DataSource = dt;
        rptr_Data.DataBind();
        lbl_Count.Text = " No. of Roles Listed : " + dt.Rows.Count.ToString();

    }
}