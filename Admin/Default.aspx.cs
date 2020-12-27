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
    string captcha="True", name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClearCache();
            Random _rand = new Random();
            ViewState["KeyGenerator"] = _rand.Next();
            txt_UserID.Focus();
        }
        //txt_Captcha.Attributes.Add("autocomplete", "off");
    }
    public static void ClearCache()
    {
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetExpires(DateTime.Now);
        HttpContext.Current.Response.Cache.SetNoServerCaching();
        HttpContext.Current.Response.Cache.SetNoStore();
        HttpContext.Current.Response.Cookies.Clear();
        HttpContext.Current.Request.Cookies.Clear();
    }
    protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
    {
        //Captcha1.ValidateCaptcha(txt_Captcha.Text.Trim());
        //e.IsValid = Captcha1.UserValidated;
        //if (e.IsValid)
        //{
        //    captcha = e.IsValid.ToString();
        //}

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
                        return;
                    }
                    else
                    {
                        name = Encrypt(txt_UserID.Text.Trim());
                        objPRReq.UserID = HttpUtility.UrlEncode(txt_UserID.Text.Trim());
                        objPRReq.SGNO = txt_UserID.Text.Trim();
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
                    objPRReq.Role = 0;
                    if (dt.Rows.Count > 0)
                    {
                        string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                        string password = dt.Rows[0]["Password"].ToString();
                        string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");

                        if(txtPwdHash.Value == value.ToLower())
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["Role"].ToString() != "0")
                                {
                                    continue;
                                }
                                // CIT Inventory
                                if (dr["Status"].ToString() == "Active")
                                {
                                    Session["UserID"] = dr["UID"];
                                    Response.Redirect(string.Format("~/Admin/AssignRole.aspx?st={0}", name), false);
                                }
                            }
                            throw new Exception("You are not authorised for the role of Admin");
                        }
                    }
                    try
                    {
                        objPRReq.EmpID = double.Parse(objPRReq.UserID);
                    }
                    catch
                    {
                        throw new Exception("Invalid User Login Credentials");
                    }
                    r = objPRIBC.EmpLogin(objPRReq);
                    dt = r.GetTable;
                    if (dt.Rows.Count > 0)
                    {
                        r = objPRIBC.getAdminRoleEmpID(objPRReq);
                        DataTable dr = r.GetTable;
                        string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                        string password = dt.Rows[0]["Password"].ToString();
                        string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");

                        // CIT Inventory
                        if (txtPwdHash.Value != value.ToLower())
                        {
                            
                        }
                        else if (dr.Rows.Count > 0 && dr.Rows[0]["Status"].ToString() == "Active")
                        {
                            Session["UserID"] = dr.Rows[0]["UID"];
                            Response.Redirect(string.Format("~/Admin/AssignRole.aspx?st={0}", name), false);
                        }
                        else
                        {
                            throw new Exception("You are not authorised for the role of Admin");
                        }
                    }
                    r = objPRIBC.ProjStaffLogin(objPRReq);
                    dt = r.GetTable;
                    if (dt.Rows.Count > 0)
                    {
                        r = objPRIBC.getAdminRoleEmpID(objPRReq);
                        DataTable dr = r.GetTable;
                        string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                        string password = dt.Rows[0]["Password"].ToString();
                        string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");

                        // CIT Inventory
                        if (txtPwdHash.Value != value.ToLower())
                        {
                                
                        }
                        else if (dr.Rows.Count > 0 && dr.Rows[0]["Status"].ToString() == "Active")
                        {
                            Session["UserID"] = dr.Rows[0]["UID"];
                            Response.Redirect(string.Format("~/Admin/AssignRole.aspx?st={0}", name), false);
                        }
                        else
                        {
                            throw new Exception("You are not authorised for the role of Admin");
                        }
                    }
                    throw new Exception(" Invalid User Login Credintials");
                }
                else
                {
                    throw new Exception(" Enter UserID & Password");
                }
            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
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
