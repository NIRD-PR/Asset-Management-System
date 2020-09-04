using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NIRDPR.RK.PRReferences;
using System.Globalization;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
public class EmpBirthDayGreetings
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string email, name, pwd, smsapi;
    public EmpBirthDayGreetings()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static SqlConnection GetConnction()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["test"].ToString();
        return con;
    }
    public static void SendGreetings()
    {
        string mStatus = ""; string readFile, myString = "";
        SqlConnection con = GetConnction();
        string s = "select * from PR_tbl_Employee where Status='Active' and OID='1' and month(DOB)= month(getDate()) and day(DOB)= day(getDate())";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        System.Data.DataTable dt = new System.Data.DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string fm = "pay.nirdpr@gmail.com";
                string fp = "9246832775";
                string tomail = dt.Rows[i]["Email"].ToString();
                string name = dt.Rows[i]["Name"].ToString();
                StreamReader reader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/BirthDayGreetings.htm"));
                readFile = reader.ReadToEnd();
                myString = readFile;
                myString = myString.Replace("[Name]", name);
                MailMessage m = new MailMessage(fm, tomail);
                m.Body = myString.ToString();
                m.IsBodyHtml = true;
                m.Subject = "Dear, " + dt.Rows[i]["NAME"] + ", Happy Birthday to You... from DG, NIRDPR  & NIRDPR Family... ";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                m.Priority = MailPriority.High;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fm, fp);
                smtp.Send(m);
            }
        }
        //for Project Staff
        string ss = "select * from PR_tbl_ProjectStaff where Status='Active' and OID='1' and month(DOB)= month(getDate()) and day(DOB)= day(getDate())";
        SqlDataAdapter das = new SqlDataAdapter(ss, con);
        System.Data.DataTable dts = new System.Data.DataTable();
        das.Fill(dts);
        if (dts.Rows.Count > 0)
        {
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                string fm = "pay.nirdpr@gmail.com";
                string fp = "9246832775";
                string tomail = dts.Rows[i]["Email"].ToString();
                string name = dts.Rows[i]["Name"].ToString();
                StreamReader reader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/BirthDayGreetings.htm"));
                readFile = reader.ReadToEnd();
                myString = readFile;
                myString = myString.Replace("[Name]", name);
                MailMessage m = new MailMessage(fm, tomail);
                m.Body = myString.ToString();
                m.IsBodyHtml = true;
                m.Subject = "Dear, " + dts.Rows[i]["NAME"] + ", Happy Birthday to You... from DG, NIRDPR  & NIRDPR Family... ";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                m.Priority = MailPriority.High;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fm, fp);
                smtp.Send(m);
            }
        }
    }
}