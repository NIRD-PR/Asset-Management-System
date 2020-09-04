using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class Inventory_ChangePassword : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid, EmpID;
    
    protected void Page_Load(object sender, EventArgs e)
    {
         getAdminUser();
         if (!IsPostBack)
         {
             Random _rand = new Random();
             ViewState["KeyGenerator"] = _rand.Next();
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
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_CPwd.Text != "" && txt_NewPwd.Text != "")
            {
                objPRReq.Password = opwd.Value;
                objPRReq.UID = int.Parse(Session["UserID"].ToString());
                objPRReq.Status = "Active";
                PRResp r = objPRIBC.getAdminsPassword(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string pwd = dt.Rows[0]["Password"].ToString();
                    objPRReq.NewPassword = cpwd.Value;
                    objPRReq.Password = pwd;
                    objPRIBC.ChangeAdminsPassword(objPRReq);
                    string msg = "Password Updated Successfully...!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + msg + "'); window.open('../CIT_InvHome/{0}','_self');", true);
                    clear();
                }
                else
                {
                    string msg = " Invalid Old Password Entered..!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
            }
            else
            {
                string msg = "Enter Old & New Passwords";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        {
             string msg = ex.Message.Replace("'", ""); Response.Redirect(string.Format("~/Error.aspx?st="+ex.ToString()), false);
        }
    }

    public void clear()
    {
        txt_CPwd.Text = "";
        txt_NewPwd.Text = "";
        txt_OldPwd.Text = "";
    }
}