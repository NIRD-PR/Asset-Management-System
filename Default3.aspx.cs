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
public partial class Circulars : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string captcha, name; int bdn = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Random _rand = new Random();
            ViewState["KeyGenerator"] = _rand.Next();
            getCirculars();
            getOfficeOrders();
            getNotifications();
            getTodayBDays();
        }
    }

    public void getCirculars()
    {
        objPRReq.Status = "Active";
        objPRReq.CircularType = "Circulars";
        objPRReq.OID = 1;
        PRResp r = objPRIBC.DisplayCirculars(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "PCID desc";
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = "Listed Circulars :" + dt.Rows.Count.ToString();
        }
    }

    public void getOfficeOrders()
    {
        objPRReq.Status = "Active";
        objPRReq.CircularType = "Office Orders";
        objPRReq.OID = 1;
        PRResp r = objPRIBC.DisplayCirculars(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "PCID desc";
            rptr_OO.DataSource = dt;
            rptr_OO.DataBind();
            lbl_oocount.Text = "Listed Office Orders :" + dt.Rows.Count.ToString();
        }
    }

    public void getNotifications()
    {
        objPRReq.Status = "Active";
        objPRReq.CircularType = "Notifications";
        objPRReq.OID = 1;
        PRResp r = objPRIBC.DisplayCirculars(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "PCID desc";
            rptr_noti.DataSource = dt;
            rptr_noti.DataBind();
            lbl_noticount.Text = "Listed Notifications :" + dt.Rows.Count.ToString();
        }
    }

    // Admin Login
    protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
    {
        Captcha1.ValidateCaptcha(txt_Captcha.Text.Trim());
        e.IsValid = Captcha1.UserValidated;
        if (e.IsValid)
        {
            captcha = e.IsValid.ToString();
        }
    }
    protected void btn_AdminLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_UserID.Text != "" && txt_Password.Text != "")
            {
                if (captcha == "True")
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
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                            string password = dr["Password"].ToString();
                            string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");

                            //Application Admin

                            if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "0" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("Admin/{0}?st={0}", name), false);
                            }
                            else
                                // DG
                                if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "1" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/DG/DGHome.aspx?st={0}", name), false);
                            }
                            else
                                    //Project Staff Payroll
                                    if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "10" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/PSPayrolls/PSHome.aspx?st={0}", name), false);
                            }
                            else
                                        // Payroll Users
                                        if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "2" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/ACCPayrolls/PayrollHome.aspx?st={0}", name), false);
                            }
                            else
                                            // Vehicle Admin
                                            if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "3" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/Vehicle/VehicleHome.aspx?st={0}", name), false);
                            }

                            else
                                                //E Admin
                                                if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "4" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/EAdmin/eAdmnHome.aspx?st={0}", name), false);
                            }
                            else
                                                    // Security

                                                    if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "5" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/SecurityOfficer/SOHome.aspx?st={0}", name), false);
                            }
                            else
                                                        // ART
                                                        if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "6" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/AR_T/ARTHome.aspx?st={0}", name), false);
                            }
                            else //ARE
                                                            if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "7" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/AR_E/AREHome.aspx?st={0}", name), false);
                            }
                            else //GuestHouse
                                                                if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "8" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/GuestHouse/GHHome.aspx?st={0}", name), false);
                            }
                            else // CIT Inventory
                                                                if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "9" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/CICTInventory/InventoryHome.aspx?st={0}", name), false);
                            }
                            else // CIT Inventory
                                                                    if (dr["Status"].ToString() == "Active" && dr["Role"].ToString() == "11" && txtPwdHash.Value == value.ToLower())
                            {
                                Session["UserID"] = dr["UID"];
                                Response.Redirect(string.Format("~/eLeave/eLeaveAdminHome.aspx?st={0}", name), false);
                            }                            
                            else
                            {
                                string msg = " Invalid User Login Credintials";
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                            }
                        }
                    }
                    else
                    {
                        objPRReq.Status = "Active";
                        PRResp ru = objPRIBC.StoreUserLogin(objPRReq);
                        DataTable dtu = ru.GetTable;
                        if (dtu.Rows.Count > 0)
                        {
                            foreach (DataRow dru in dtu.Rows)
                            {
                                string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                                string password = dru["Password"].ToString();
                                string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");

                                if (dru["Status"].ToString() == "Active" && dru["Role"].ToString() == "10" && txtPwdHash.Value == value.ToLower())
                                {
                                    Session["UserID"] = dru["SUID"];
                                    Response.Redirect(string.Format("~/NIRDStores/StoreUser/StoreUserHome.aspx?st={0}", name), false);
                                }
                                else
                                {
                                    string msg = "Invalid User Login Credientials";
                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                                }
                            }
                        }
                        else
                        {
                            objPRReq.Status = "Active";
                            if (Microsoft.VisualBasic.Information.IsNumeric(txt_UserID.Text))
                            {
                                objPRReq.EmpID = int.Parse(txt_UserID.Text.Trim());
                            }
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
                                        Session["UserID"] = dremp["EmpID"];
                                        Response.Redirect(string.Format("~/HOC/Circulars.aspx?st={0}", name), false);
                                    }
                                    //else
                                    //    if (dremp["Status"].ToString() == "Active" && dremp["Role"].ToString() == "5" && txtPwdHash.Value == value.ToLower())
                                    //    {
                                    //        Session["UserID"] = dremp["EmpID"];
                                    //        Response.Redirect(string.Format("~/Emp/Circulars.aspx?st={0}", name), false);
                                    //    }
                                        else
                                        {
                                            string msg = "Invalid User Login Credientials";
                                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                                        }
                                }
                            }
                            else
                            {
                                PRResp rps = objPRIBC.ProjStaffLogin(objPRReq);
                                DataTable dps = rps.GetTable;
                                if (dps.Rows.Count > 0)
                                {
                                    foreach (DataRow drps in dps.Rows)
                                    {
                                        string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                                        string password = drps["Password"].ToString();
                                        string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
                                        if (drps["Status"].ToString() == "Active" && drps["Role"].ToString() == "12" && txtPwdHash.Value == value.ToLower())
                                        {
                                            Session["UserID"] = drps["EmpID"];
                                            Response.Redirect(string.Format("~/ProjectStaff/PSHome.aspx?st={0}", name), false);
                                        }
                                        else
                                        {
                                            string msg = "Invalid User Login Credientials";
                                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                                        }
                                    }
                                }
                                else
                                {
                                    // Security Guard
                                    objPRReq.Status = "Active";
                                    objPRReq.SGNO = txt_UserID.Text.Trim();
                                    PRResp rsg = objPRIBC.SGLogin(objPRReq);
                                    DataTable dsg = rsg.GetTable;
                                    if (dsg.Rows.Count > 0)
                                    {
                                        foreach (DataRow drg in dsg.Rows)
                                        {
                                            string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                                            string password = drg["Password"].ToString();
                                            string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
                                            if (drg["Status"].ToString() == "Active" && drg["Role"].ToString() == "100" && txtPwdHash.Value == value.ToLower())
                                            {
                                                Session["UserID"] = drg["SGID"];
                                                Response.Redirect(string.Format("~/Security/SecurityHomepage.aspx?st={0}", name), false);
                                            }
                                            else
                                            {
                                                string msg = "Invalid User Login Credientials";
                                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);

                                            }
                                        }
                                    }
                                    else
                                    {
                                        objPRReq.Status = "Active";
                                        objPRReq.Email = txt_UserID.Text.Trim();
                                        PRResp rcit = objPRIBC.CITSSLogin(objPRReq);
                                        DataTable dcit = rcit.GetTable;
                                        if (dcit.Rows.Count > 0)
                                        {
                                            foreach (DataRow dts in dcit.Rows)
                                            {
                                                string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                                                string password = dts["Password"].ToString();
                                                string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
                                                if (dts["Status"].ToString() == "Active" && dts["Role"].ToString() == "11" && txtPwdHash.Value == value.ToLower())
                                                {
                                                    Session["UserID"] = dts["CSID"];
                                                    Response.Redirect(string.Format("~/CITStaff/CITSSHome.aspx?st={0}", name), false);
                                                }
                                                else
                                                {
                                                    string msg = "Invalid User Login Credientials";
                                                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);

                                                }
                                            }
                                        }
                                        else
                                        {
                                            objPRReq.Status = "Active";
                                            objPRReq.UserID = txt_UserID.Text.Trim();
                                            PRResp rcelDA = objPRIBC.eLDALogin(objPRReq);
                                            DataTable dcelDA = rcelDA.GetTable;
                                            if (dcelDA.Rows.Count > 0)
                                            {
                                                foreach (DataRow dtelda in dcelDA.Rows)
                                                {
                                                    string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                                                    string password = dtelda["Password"].ToString();
                                                    string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
                                                    if (dtelda["Status"].ToString() == "Active" && dtelda["Role"].ToString() == "12" && txtPwdHash.Value == value.ToLower())
                                                    {
                                                        Session["UserID"] = dtelda["UserID"];
                                                        Response.Redirect(string.Format("~/eLeaveDA/eLDAHome.aspx?st={0}", name), false);
                                                    }
                                                    else
                                                    {
                                                        string msg = "Invalid User Login Credientials";
                                                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);

                                                    }
                                                }
                                            }
                                            else
                                            {
                                                string msg = " Enter User Login Credientials";
                                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }

                }
                else
                {
                    string msg = " Enter Valid Cpatch..";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
            }
            else
            {
                string msg = " Enter User Login Credientials";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); Response.Redirect(string.Format("~/Error.aspx?st=" + msg.ToString()), false);
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
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            Response.Redirect("~/Files/Download.aspx?st=" + e.CommandArgument.ToString());
        }
    }
    protected void rptr_OO_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            Response.Redirect("~/Files/Download.aspx?st=" + e.CommandArgument.ToString());
        }
    }
    protected void rptr_noti_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            Response.Redirect("~/Files/Download.aspx?st=" + e.CommandArgument.ToString());
        }
    }

    public void getTodayBDays()
    {
        objPRReq.OID = 1;
        objPRReq.Status = "Active";
        objPRReq.DOB = DateTime.Today;
        PRResp r = objPRIBC.getAllTodaysREmpBDays(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_BDays.DataSource = dt;
            rptr_BDays.DataBind();
            lbl_ItemTypesCount.Text = "No. of Birthday's Listed : " + dt.Rows.Count.ToString();
            lbl_Nodata.Visible = false;
            lbl_BDayWishes.Visible = true;
            lbl_BDayWishes.Text = " DG, NIRDPR  & NIRDPR Family..."+Environment.NewLine+" Wishing you a wonderful year of good health, happyness and success..";
        }
        else
        {
            lbl_Nodata.Text = "No Birthday's found for today";
            lbl_Nodata.Visible = true;
            lbl_BDayWishes.Visible = false;
        }

        lbl_Month.Text = DateTime.Now.ToString("MMMMMMMMMMMMMMMM") + ", " + DateTime.Now.Year.ToString();

        PRResp rr = objPRIBC.getAllMonthlyREmpBDays(objPRReq);
        DataTable dtr = rr.GetTable;
        if (dtr.Rows.Count > 0)
        {
            DataTable dtt = new DataTable();
            dtr.DefaultView.Sort = "DOB ASC";
            dtt = dtr.DefaultView.ToTable();

            rptr_MonthlyBDays.DataSource = dtt;
            rptr_MonthlyBDays.DataBind();
            lbl_MonthlyNoData.Visible = false;
            lbl_MonthlyCount.Text = "No.of Birthday's Listed : " + dtr.Rows.Count.ToString();

        }
        else
        {
            rptr_MonthlyBDays.DataSource = dtr;
            rptr_MonthlyBDays.DataBind();
            lbl_MonthlyNoData.Visible = true;
            lbl_MonthlyNoData.Text="No Birthday's found for this Month";;
        }
    }
}