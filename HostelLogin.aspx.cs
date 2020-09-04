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
using System.Security.Cryptography;
using System.Web.Security;
using Microsoft.Security.Application;
public partial class Login : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string captcha, name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   
            Random _rand = new Random();
            ViewState["KeyGenerator"] = _rand.Next();
            txt_UserID.Focus();
        }
    }
    protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
    {
        Captcha1.ValidateCaptcha(txt_Captcha.Text.Trim());
        e.IsValid = Captcha1.UserValidated;
        if (e.IsValid)
        {
            captcha = e.IsValid.ToString();
        }

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (captcha == "True")
            {
                if (txt_UserID.Text != "" && txt_Password.Text != "")
                {
                    if (SqInjection.checkForSQLInjection(txt_UserID.Text.Trim()))
                    {
                        Response.Redirect(string.Format("~/Error.aspx"), false);
                    }
                    else
                    {
                        name = HttpUtility.UrlEncode(Encrypt(txt_UserID.Text.Trim()));
                        objPRReq.UserID = HttpUtility.UrlEncode(txt_UserID.Text.Trim());
                    }
                    if (SqInjection.checkForSQLInjection(txt_UserID.Text.Trim()))
                    {
                        Response.Redirect(string.Format("~/Error.aspx"), false);
                    }
                    else
                    {
                        objPRReq.Email = txt_UserID.Text.Trim();
                    }
                    if (SqInjection.checkForSQLInjection(txt_Password.Text.Trim()))
                    {
                        Response.Redirect(string.Format("~/Error.aspx"), false);
                    }
                    else
                    {
                        objPRReq.Password = HttpUtility.UrlEncode(txt_Password.Text.Trim());
                    }
                    objPRReq.Status = "Active";
                    PRResp r = objPRIBC.AdminLogin(objPRReq);
                    DataTable dt = r.GetTable;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                            string password = dr["Password"].ToString();
                            string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");

                            if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "0" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("StoreAdmin/{0}?st={0}", name), false);
                            }
                            else
                                if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "1" && txtPwdHash.Value == value.ToLower())
                                {
                                    Session["UserID"] = dr["UID"];
                                    Response.Redirect(string.Format("~/DG/DG_Home.aspx?st={0}", name), false);
                                }
                                else
                                {
                                    string msg = " Invalid UserID or Password";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                                }
                        }
                    }
                    else
                    {
                        objPRReq.Status = "Active";
                        PRResp remp = objPRIBC.EmpLogin(objPRReq);
                        DataTable dtemp = remp.GetTable;
                        if (dtemp.Rows.Count > 0)
                        {
                            foreach (DataRow dremp in dtemp.Rows)
                            {
                                string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                                string password = dremp["Password"].ToString();
                                string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");

                                if (dremp["Status"].ToString() == "Active" && dremp["Role"].ToString() == "5" && txtPwdHash.Value == value.ToLower())
                                {
                                    Session["UserID"] = dremp["EID"];
                                    Response.Redirect(string.Format("~/Emp/EmpHome.aspx?st={0}", name), false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    string msg = " Enter UserID & Password";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
            }
            
        }
        catch (Exception ex)
        {
             string msg = ex.Message.Replace("'", ""); Response.Redirect(string.Format("~/Error.aspx?st="+ex.ToString()), false);
        }
    }
    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}
