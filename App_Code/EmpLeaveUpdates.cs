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
using System.Globalization;
using System.IO;
using esms_client;
public class EmpLeaveUpdates : Page
{
    public static bool _leaves = false;
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname, email, pwd, smsapi; int oid = 1,day=0;
    string smsUN, smsPwd, smsSender, smsKey;
    DataTable dtf = new DataTable();
    public EmpLeaveUpdates()
    {

    }
    public static void Yearly_MasterLeaveUpdates()
    {
        EmpLeaveUpdates update = new EmpLeaveUpdates();
        //update.getProjStaffClosedHoliday();
        //update.get_Essential_RegularStaff_ClosedHoliday();
        //update.get_Non_Essential_RegularStaff_ClosedHoliday();
        //update.updateCL_RH_REmp();
        update.update_EL_HPL_REmp_HalfYearly();
        //update.setPSLeaves_DDUGKY();
    }

    //el hpl updation
    //public static void HalfYearly_Master_EL_HPL_Updates()
    //{
    //    EmpLeaveUpdates el_hpl_update = new EmpLeaveUpdates();
    //    el_hpl_update.update_EL_HPL_REmp_HalfYearly();
    //}
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
    public void getProjStaffClosedHoliday()
    {
        objPRReq.Year = DateTime.Now.Year;
        objPRReq.OID = oid;
        DateTime starting = DateTime.Parse("01/Jan/" + DateTime.Now.Year);
        DateTime ending = DateTime.Parse("31/Dec/" + DateTime.Now.Year);
        int mon = DateTime.Now.Month;
        for (DateTime date = starting; date <= ending; date = date.AddDays(1))
        {
            for (mon = date.Date.Month; mon <= date.Date.Month; mon++)
            {                
                if (date.Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    //for Saturdays
                    int weekOfMonth = (date.Date.Day + ((int)date.Date.DayOfWeek)) / 7;
                    if (weekOfMonth == 2 || weekOfMonth == 4)
                    {
                        day += 1;
                        objPRReq.FromDate = date.Date.ToString("dd/MMM/yyyy");
                        objPRReq.OID = oid;
                        objPRReq.Year = DateTime.Now.Year;
                        objPRReq.DayNo = day;
                        PRResp rkt = objPRIBC.get_PH_forProjectStaff(objPRReq);
                        DataTable dtkt = rkt.GetTable;
                        if (dtkt.Rows.Count > 0)
                        {
                            // skip repeated date
                        }
                        else
                        {
                            objPRIBC.AddProject_Closedholiday(objPRReq);
                        }
                    }
                }
            }
        }
    }

    public void get_Essential_RegularStaff_ClosedHoliday()
    {
        objPRReq.Year = DateTime.Now.Year;
        objPRReq.OID = oid;
        DateTime starting = DateTime.Parse("01/Jan/" + DateTime.Now.Year);
        DateTime ending = DateTime.Parse("31/Dec/" + DateTime.Now.Year);
        int mon = DateTime.Now.Month;
        for (DateTime date = starting; date <= ending; date = date.AddDays(1))
        {
            for (mon = date.Date.Month; mon <= date.Date.Month; mon++)
            {
                if (date.Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    //for Saturdays
                    int weekOfMonth = (date.Date.Day + ((int)date.Date.DayOfWeek)) / 7;
                    if (weekOfMonth == 2)
                    {
                        day += 1;
                        objPRReq.FromDate = date.Date.ToString("dd/MMM/yyyy");
                        objPRReq.OID = oid;
                        objPRReq.Year = DateTime.Now.Year;
                        objPRReq.DayNo = day;
                        PRResp rkt = objPRIBC.get_RS_Essential_Closedholidays(objPRReq);
                        DataTable dtkt = rkt.GetTable;
                        if (dtkt.Rows.Count > 0)
                        {
                            // skip repeated date
                        }
                        else
                        {
                            objPRIBC.Add_RS_Essential_Closedholiday(objPRReq);
                        }
                    }
                }

                if (date.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    day += 1;
                    objPRReq.FromDate = date.Date.ToString("dd/MMM/yyyy");
                    objPRReq.OID = oid;
                    objPRReq.Year = DateTime.Now.Year;
                    objPRReq.DayNo = day;
                    PRResp rkt = objPRIBC.get_RS_Essential_Closedholidays(objPRReq);
                    DataTable dtkt = rkt.GetTable;
                    if (dtkt.Rows.Count > 0)
                    {
                        // skip repeated date
                    }
                    else
                    {
                        objPRIBC.Add_RS_Essential_Closedholiday(objPRReq);
                    }
                }
            }
        }
    }

    public void get_Non_Essential_RegularStaff_ClosedHoliday()
    {
        objPRReq.Year = DateTime.Now.Year;
        objPRReq.OID = oid;
        DateTime starting = DateTime.Parse("01/Jan/" + DateTime.Now.Year);
        DateTime ending = DateTime.Parse("31/Dec/" + DateTime.Now.Year);
        int mon = DateTime.Now.Month;
        for (DateTime date = starting; date <= ending; date = date.AddDays(1))
        {
            for (mon = date.Date.Month; mon <= date.Date.Month; mon++)
            {
                if (date.Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    day += 1;
                    objPRReq.FromDate = date.Date.ToString("dd/MMM/yyyy");
                    objPRReq.OID = oid;
                    objPRReq.Year = DateTime.Now.Year;
                    objPRReq.DayNo = day;
                    PRResp rkt = objPRIBC.get_RS_NON_Essential_Closedholidays(objPRReq);
                    DataTable dtkt = rkt.GetTable;
                    if (dtkt.Rows.Count > 0)
                    {
                        // skip repeated date
                    }
                    else
                    {
                        objPRIBC.Add_RS_NON_Essential_Closedholiday(objPRReq);
                    }
                }

                if (date.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    day += 1;
                    objPRReq.FromDate = date.Date.ToString("dd/MMM/yyyy");
                    objPRReq.OID = oid;
                    objPRReq.Year = DateTime.Now.Year;
                    objPRReq.DayNo = day;
                    PRResp rkt = objPRIBC.get_RS_NON_Essential_Closedholidays(objPRReq);
                    DataTable dtkt = rkt.GetTable;
                    if (dtkt.Rows.Count > 0)
                    {
                        // skip repeated date
                    }
                    else
                    {
                        objPRIBC.Add_RS_NON_Essential_Closedholiday(objPRReq);
                    }
                }
            }
        }
    }

    public void updateCL_RH_REmp()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp remp = objPRIBC.getAllEmployees(objPRReq);
        DataTable dtemp = remp.GetTable;
        if(dtemp.Rows.Count>0)
        {
            for(int i=0;i<dtemp.Rows.Count;i++)
            {
                objPRReq.CL = 8;
                objPRReq.RH = 2;
                objPRReq.EmpID = int.Parse(dtemp.Rows[i]["EmpID"].ToString());
                objPRIBC.update_REmp_CL_RH_YearlyOnce(objPRReq);
            }
        }
    }

    public void update_EL_HPL_REmp_HalfYearly()  // 1st Jan  & 1st July of Every Year
    {
        
        int year = DateTime.Now.Year;
        DateTime firstDay = new DateTime(year, 1, 1);
        string fday = firstDay.ToString("dd/MMM/yyyy");
        string now = DateTime.Now.ToString("dd/MMM/yyyy");
        DateTime JulFirst = new DateTime(year, 7, 1);
        string JulF = JulFirst.ToString("dd/MMM/yyyy");
        if ((now == fday || now == JulF) && _leaves == false)
        {
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            PRResp remp = objPRIBC.getAllEmployees(objPRReq);
            DataTable dtemp = remp.GetTable;
            if (dtemp.Rows.Count > 0)
            {
                for (int i = 0; i < dtemp.Rows.Count; i++)
                {
                    double e_EL = 0, e_HPL = 0;
                    objPRReq.EmpID = double.Parse(dtemp.Rows[i]["EmpID"].ToString());
                    PRResp r = objPRIBC.getEmpLeavesByEmpID_UID(objPRReq);
                    DataTable dt = r.GetTable;
                    if (dt.Rows.Count > 0)
                    {
                        e_EL = double.Parse(dt.Rows[0]["EL"].ToString());
                        e_HPL = double.Parse(dt.Rows[0]["HPL"].ToString());
                        //EL Calc
                        if (e_EL >= 315)
                        {
                            objPRReq.EL = 315;
                        }
                        else if (e_EL < 315)
                        {
                            double el = (e_EL + 15);
                            if (el >= 315)
                            {
                                objPRReq.EL = 315;
                            }
                            else
                            {
                                objPRReq.EL = el;
                            }
                        }

                        //HPL Calc
                        objPRReq.HPL = e_HPL + 10;
                        objPRIBC.update_REmp_EL_HPL_HalfYearlyOnce(objPRReq);
                    }
                }
                _leaves = true;
            }

        }
        else
        {
            _leaves = false;
        }
    }

    public void setPSLeaves_DDUGKY()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getAllProjectStaff_Active_DDUGKY(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                objPRReq.EmpID = int.Parse(dt.Rows[i]["EmpID"].ToString());
                objPRReq.NoofLeaves = 18.0;
                objPRReq.ColumnName = "CL";
                objPRReq.Year = DateTime.Now.Year;
                objPRIBC.updatePSEmpLeaves_YearlyOnce(objPRReq);

                objPRReq.NoofLeaves = 6.0;
                objPRReq.ColumnName = "SL";
                objPRReq.Year = DateTime.Now.Year;
                objPRIBC.updatePSEmpLeaves_YearlyOnce(objPRReq);
            }
        }
    }
}