using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.Net;
using Microsoft.Office.Core;
using System.Globalization;
using System.IO;
using esms_client;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Web.Script.Serialization;
public class AutoSQLBackupMail : Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname, email, pwd, smsapi; int oid = 1;
    string smsUN, smsPwd, smsSender, smsKey;
    public AutoSQLBackupMail()
    {
    }
    public static void AutoSqlBackupMail()
    {
        AutoSQLBackupMail automail = new AutoSQLBackupMail();
        automail.SendMail();
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
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void getSQLBackup()
    {
        objPRReq.SqlBackupPath = "D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_ERP.bak";
        objPRIBC.CreateSQLBackup_ERP(objPRReq);

        objPRReq.SqlBackupPath = "D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_HC.bak";
        objPRIBC.CreateSQLBackup_HC(objPRReq);

        objPRReq.SqlBackupPath = "D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_PSCareers.bak";
        objPRIBC.CreateSQLBackup_PSCareers(objPRReq);

        objPRReq.SqlBackupPath = "D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_SRMS.bak";
        objPRIBC.CreateSQLBackup_SRMS(objPRReq);

        objPRReq.SqlBackupPath = "D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_DDUGKYTicketing.bak";
        objPRIBC.CreateSQLBackup_DDUGKYTicketing(objPRReq);

    }
    public void SendMail()
    {
        string File_ERP = @"D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_ERP.bak";
        string File_HC= @"D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_HC.bak";
        string File_PSCareers= @"D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_PSCareers.bak";
        string File_SRMS= @"D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_SRMS.bak";
        string File_Ticket= "D:\\dotnet sws\\Websites\\SQLBackup\\NIRDPR_DDUGKYTicketing.bak";

        if (File.Exists(File_ERP))
        {
            File.Delete(File_ERP);
            File.Delete(File_HC);
            File.Delete(File_PSCareers);
            File.Delete(File_SRMS);
            File.Delete(File_Ticket);
        }
        getSQLBackup();
        getMailService();
        //string fm = "rk.nirdpr@gmail.com";//email;
        //string fpwd = "krishna@1983";//pwd;
        //string tomail = "pay.nirdpr@gmail.com";

        //string sub = "NIRDPR-ERP SQL Backup as on " + DateTime.Now.ToString();
        //string body = "NIRDPR-ERP SQL Backup as on " + DateTime.Now.ToString();

        //using (MailMessage mm = new MailMessage(fm,tomail))
        //{
        //    mm.Subject = "NIRDPR-ERP SQL Backup as on " + DateTime.Now.ToString();
        //    mm.Body = "NIRDPR-ERP SQL Backup as on " + DateTime.Now.ToString();
        //    mm.Attachments.Add(new Attachment(bFile));
        //    mm.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.UseDefaultCredentials = false;
        //    NetworkCredential NetworkCred = new NetworkCredential(fm, fpwd);
        //    smtp.EnableSsl = true;
        //    smtp.Credentials = NetworkCred;
        //    smtp.Port = 587;
        //    smtp.Timeout = 5000000;                
        //    smtp.Send(mm);
        //    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        //}
        //string eename = "T Rama Krishna";
        //string uMob = "9246832775";
        //string msms = convertQuotes("Dear " + eename + ", NIRD-ERP Backup Generated and Sent as Mail Successfully");
        //getMailService();
        //SMSHttpPostClient s = new SMSHttpPostClient();
        //string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
    }
}