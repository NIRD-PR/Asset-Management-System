using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using esms_client;

public partial class Site_ResetPassword : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid = 1, EmpID;
    string email, pwd, smsapi;
    string smsUN, smsPwd, smsSender, smsKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        RandomPassword();
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
            if (txt_OTP.Text != "" && txt_CPwd.Text != "" && txt_NewPwd.Text != "")
            {
                objPRReq.EmpID = int.Parse(txt_EmpID.Text.Trim());
                objPRReq.Mobile = double.Parse(txt_Mobile.Text.Trim());
                objPRReq.Status = "Active";
                PRResp r = objPRIBC.getResetEmpPassword(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    objPRReq.Mobile = double.Parse(dt.Rows[0]["Mobile"].ToString());
                    string otp = dt.Rows[0]["OTP"].ToString();
                    if (txt_OTP.Text.Trim() == otp)
                    {
                        objPRReq.NewPassword = cpwd.Value;
                        objPRIBC.ResetEmpPassword(objPRReq);
                        string msg = " Password Updated Successfully...!!!";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + msg + "'); window.open('Home','_self');", true);
                        clear();
                    }
                    else
                    {
                        string msg = " Invalid OTP Entered..!!!";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                        return;
                    }
                }
                else
                {
                    PRResp rp = objPRIBC.getResetProjEmpPassword(objPRReq);
                    DataTable dtp = rp.GetTable;
                    if (dtp.Rows.Count > 0)
                    {
                        objPRReq.Mobile = double.Parse(dtp.Rows[0]["Mobile"].ToString());
                        string otpp = dtp.Rows[0]["OTP"].ToString();
                        if (txt_OTP.Text.Trim() == otpp)
                        {
                            objPRReq.NewPassword = cpwd.Value;
                            objPRIBC.ResetProjEmpPassword(objPRReq);
                            string msg = " Password Updated Successfully...!!!";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + msg + "'); window.open('Home','_self');", true);
                            clear();
                        }
                        else
                        {
                            string msg = " Invalid OTP Entered..!!!";
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                            return;
                        }
                    }
                }
            }
            else
            {
                string msg = "Enter All the fields";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); Response.Redirect(string.Format("~/Error.aspx?st=" + ex.ToString()), false);
        }
    }

    public void clear()
    {
        txt_CPwd.Text = "";
        txt_NewPwd.Text = "";
        txt_Mobile.Text = "";
    }

    public void RandomPassword()
    {
        Random rnd = new Random();
        int Value = rnd.Next(100000, 999999);
        hdn_Random.Value = Value.ToString();
    }

    public void getMailService()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp rm = objPRIBC.getMailServices_OID(objPRReq);
        System.Data.DataTable dtm = rm.GetTable;
        if (dtm.Rows.Count > 0)
        {
            email = dtm.Rows[0]["Email"].ToString();
            pwd = dtm.Rows[0]["Password"].ToString();
            smsapi = dtm.Rows[0]["SMSAPI"].ToString();

            smsSender = dtm.Rows[0]["SMS_SenderID"].ToString();
            smsKey = dtm.Rows[0]["SMS_SecureKey"].ToString();
            smsPwd = dtm.Rows[0]["SMS_Password"].ToString();
            smsUN = dtm.Rows[0]["SMS_UserName"].ToString();
        }
    }
    protected void btn_SendOTP_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_EmpID.Text != "" && txt_Mobile.Text != "")
            {
                objPRReq.EmpID = int.Parse(txt_EmpID.Text.Trim());
                objPRReq.Mobile = double.Parse(txt_Mobile.Text.Trim());
                objPRReq.Status = "Active";
                PRResp r = objPRIBC.getResetEmpPassword(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string mob = dt.Rows[0]["Mobile"].ToString();
                    getMailService();
                    objPRReq.OTP = hdn_Random.Value;
                    objPRIBC.UpdateOTPByEmpID(objPRReq);
                    string ssms = "OTP for Reset Password in NIRDPR-ERP is " + hdn_Random.Value;
                    SMSHttpPostClient s = new SMSHttpPostClient();
                    string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, mob, ssms, smsKey);

                    string msg = "OTP Sent to Your Registered Mobile Number";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                    pnl_Reset.Visible = true;
                }
                else
                {
                    PRResp rp = objPRIBC.getResetProjEmpPassword(objPRReq);
                    DataTable dtp = rp.GetTable;
                    if (dtp.Rows.Count > 0)
                    {
                        string mob = dtp.Rows[0]["Mobile"].ToString();
                        getMailService();
                        objPRReq.OTP = hdn_Random.Value;
                        objPRIBC.UpdateOTPByPEmpID(objPRReq);

                        string ssms = "OTP for Reset Password in NIRDPR-ERP is " + hdn_Random.Value;
                        SMSHttpPostClient s = new SMSHttpPostClient();
                        string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, mob, ssms, smsKey);

                        string msg = "OTP Sent to Your Registered Mobile Number";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                        pnl_Reset.Visible = true;
                    }
                    else
                    {
                        string msg = "Enter Valid EmpID & Registered Mobile Number";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                    }
                }
            }
            else
            {
                string msg = "Enter EmpID & Registered Mobile Number";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); Response.Redirect(string.Format("~/Error.aspx?st=" + ex.ToString()), false);
        }
    }
}