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
public class ApprovalAlert : Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname, email, pwd, smsapi; int oid = 1;
    string smsUN, smsPwd, smsSender, smsKey;
    DataTable dtf = new DataTable();
    public ApprovalAlert()
    {
        if (!IsPostBack)
        {
            dtf.Rows.Clear();
        }
    }
    public static void DoART_StoreApprovalAlert()
    {
        ApprovalAlert alert = new ApprovalAlert();
       // alert.SendARTAlert();
        alert.sendLeave_Tour_ApprovalAlert();
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
    protected void SendARTAlert()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        objPRReq.Flag1 = 0;
        objPRReq.Flag2 = 1;
        objPRReq.Flag3 = 1;
        PRResp ri = objPRIBC.getAllIndentssbyStore_forARTApproval(objPRReq);
        DataTable dti = ri.GetTable;
        if (dti.Rows.Count > 0)
        {
            objPRReq.UserID = "ART";
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            PRResp r = objPRIBC.getAdminUserInfo(objPRReq);
            DataTable dtr = r.GetTable;
            if (dtr.Rows.Count > 0)
            {
                string uMob = dtr.Rows[0]["Mobile"].ToString();
                string name = dtr.Rows[0]["Name"].ToString();
                string msms = "Dear " + name + ", " + dti.Rows.Count.ToString() + " Store Indent(s) are pending for your approval, Please login and Approve those. Thank You";
                getMailService();
                SMSHttpPostClient s = new SMSHttpPostClient();
                string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
            }
        }
    }
    public void sendLeave_Tour_ApprovalAlert()
    {
        getAll_RS_LeaveApprovals();
        getAll_RS_TourApprovals();
        getAll_PS_LeaveApproval();
        getAll_PS_TourApproval();
    }

    public void getAll_RS_LeaveApprovals()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.Approval = 0;
        objPRReq.Reject = 0;
        DateTime now = DateTime.Now;
        objPRReq.FromDate = now.AddDays(-30).ToString("dd/MMM/yyyy");
        PRResp r = objPRIBC.getAllEmpLeavesforApprovalProcessFlow_SMS(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                string elevID = dt.Rows[m]["ELeaveID"].ToString();
                objPRReq.ELeaveID = elevID.ToString();
                PRResp rs = objPRIBC.getAllEmpLeavesforApprovalProcessFlow_OEmpIDasUID_SMS_OLevelDesc(objPRReq);
                DataTable dts = rs.GetTable;
                if (dts.Rows.Count > 0)
                {
                    for (int n = 0; n < 1; n++)
                    {
                        string uid = dts.Rows[n]["UID"].ToString();
                        objPRReq.OEmpID = int.Parse(dts.Rows[n]["OEmpID"].ToString());
                        objPRReq.Flag1 = 0;
                        objPRReq.Flag2 = 0;
                        objPRReq.Flag3 = 0;
                        objPRReq.Flag4 = 0;
                        objPRReq.Flag5 = 0;
                        objPRReq.EmpID = int.Parse(dt.Rows[m]["EmpID"].ToString());
                        objPRReq.ELeaveID = dt.Rows[m]["ELeaveID"].ToString();
                        PRResp rk = objPRIBC.getAllEmpLeavesforApproval_EmpID_Flag1_OEmpID_SMS(objPRReq);
                        DataTable dtk = rk.GetTable;
                        if (dtk.Rows.Count > 0)
                        {
                            dtf.Merge(dtk);
                            break;
                        }
                        else
                        {
                            objPRReq.Flag1 = 1;
                            objPRReq.Flag2 = 0;
                            objPRReq.Flag3 = 0;
                            objPRReq.Flag4 = 0;
                            objPRReq.Flag5 = 0;
                            PRResp rf2 = objPRIBC.getAllEmpLeavesforApproval_EmpID_Flag2_OEmpID_SMS(objPRReq);
                            DataTable dtf2 = rf2.GetTable;
                            if (dtf2.Rows.Count > 0)
                            {
                                dtf.Merge(dtf2);
                                break;
                            }
                            else
                            {
                                objPRReq.Flag1 = 1;
                                objPRReq.Flag2 = 1;
                                objPRReq.Flag3 = 0;
                                objPRReq.Flag4 = 0;
                                objPRReq.Flag5 = 0;
                                PRResp rf3 = objPRIBC.getAllEmpLeavesforApproval_EmpID_Flag3_OEmpID_SMS(objPRReq);
                                DataTable dtf3 = rf3.GetTable;
                                if (dtf3.Rows.Count > 0)
                                {
                                    dtf.Merge(dtf3);
                                    break;
                                }
                                else
                                {
                                    objPRReq.Flag1 = 1;
                                    objPRReq.Flag2 = 1;
                                    objPRReq.Flag3 = 1;
                                    objPRReq.Flag4 = 0;
                                    objPRReq.Flag5 = 0;
                                    PRResp rf4 = objPRIBC.getAllEmpLeavesforApproval_EmpID_Flag4_OEmpID_SMS(objPRReq);
                                    DataTable dtf4 = rf4.GetTable;
                                    if (dtf4.Rows.Count > 0)
                                    {
                                        dtf.Merge(dtf4);
                                        break;
                                    }
                                    else
                                    {
                                        objPRReq.Flag1 = 1;
                                        objPRReq.Flag2 = 1;
                                        objPRReq.Flag3 = 1;
                                        objPRReq.Flag4 = 1;
                                        objPRReq.Flag5 = 0;
                                        PRResp rf5 = objPRIBC.getAllEmpLeavesforApproval_EmpID_Flag5_OEmpID_SMS(objPRReq);
                                        DataTable dtf5 = rf5.GetTable;
                                        if (dtf5.Rows.Count > 0)
                                        {
                                            dtf.Merge(dtf5);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    objPRReq.Approval = 0;
                    PRResp rnf = objPRIBC.getAllEmpLeavesforApproval_withoutFlag_SMS(objPRReq);
                    DataTable dtnf = rnf.GetTable;
                    if (dtnf.Rows.Count > 0)
                    {
                        dtf.Merge(dtnf);
                    }
                }
            }
        }
        if (dtf.Rows.Count > 0)
        {
            for (int j = 0; j < dtf.Rows.Count; j++)
            {
                objPRReq.OEmpID = int.Parse(dtf.Rows[j]["OEmpID"].ToString());
                objPRReq.OID = oid;
                objPRReq.Status = "Active";
                PRResp rsms = objPRIBC.getAllOHeadsInfo_SearchforSMS(objPRReq);
                DataTable dtsms = rsms.GetTable;
                if (dtsms.Rows.Count > 0)
                {
                    string uMob = dtsms.Rows[0]["Mobile"].ToString();                   
                    string name = dtsms.Rows[0]["Name"].ToString();
                    objPRReq.Name = name;
                    objPRReq.Mobile = double.Parse(uMob.ToString());
                    objPRReq.EmpID = double.Parse(dtsms.Rows[0]["EmpID"].ToString());
                    objPRReq.Dates = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                    PRResp rs = objPRIBC.getLT_SMSAlert(objPRReq);
                    DataTable dts = rs.GetTable;
                    if (dts.Rows.Count > 0)
                    {
                        //skipped
                    }
                    else
                    {
                        string msms = "Dear " + name + ", One or more Leave / Tour requests are waiting for your approval, Please login to ERP (http://erp.nirdpr.in) with EmpNo & Password. Thank You";
                        getMailService();
                        SMSHttpPostClient s = new SMSHttpPostClient();
                        string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
                        objPRIBC.Add_LT_SMSAlert(objPRReq);
                    }
                }
            }
        }
    }

    public void getAll_RS_TourApprovals()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.Approval = 0;
        objPRReq.Reject = 0;
        DateTime now = DateTime.Now;
        objPRReq.FromDate = now.AddDays(-30).ToString("dd/MMM/yyyy");
        PRResp r = objPRIBC.getAllEmpToursforApprovalProcessFlow_SMS(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            for (int m = 0; m < dt.Rows.Count; m++)
            {
                string elevID = dt.Rows[m]["ETourID"].ToString();
                objPRReq.ETourID = elevID.ToString();
                PRResp rs = objPRIBC.getAllEmpToursforApprovalProcessFlow_OEmpIDasUID_SMS_OLevelDesc(objPRReq);
                DataTable dts = rs.GetTable;
                if (dts.Rows.Count > 0)
                {
                    for (int n = 0; n < 1; n++)
                    {
                        string uid = dts.Rows[n]["UID"].ToString();
                        objPRReq.OEmpID = int.Parse(dts.Rows[n]["OEmpID"].ToString());
                        objPRReq.Flag1 = 0;
                        objPRReq.Flag2 = 0;
                        objPRReq.Flag3 = 0;
                        objPRReq.Flag4 = 0;
                        objPRReq.Flag5 = 0;
                        objPRReq.EmpID = int.Parse(dt.Rows[m]["EmpID"].ToString());
                        objPRReq.ETourID = dt.Rows[m]["ETourID"].ToString();
                        PRResp rk = objPRIBC.getAllEmpToursforApproval_EmpID_Flag1_OEmpID_SMS(objPRReq);
                        DataTable dtk = rk.GetTable;
                        if (dtk.Rows.Count > 0)
                        {
                            dtf.Merge(dtk);
                            break;
                        }
                        else
                        {
                            objPRReq.Flag1 = 1;
                            objPRReq.Flag2 = 0;
                            objPRReq.Flag3 = 0;
                            objPRReq.Flag4 = 0;
                            objPRReq.Flag5 = 0;
                            PRResp rf2 = objPRIBC.getAllEmpToursforApproval_EmpID_Flag2_OEmpID_SMS(objPRReq);
                            DataTable dtf2 = rf2.GetTable;
                            if (dtf2.Rows.Count > 0)
                            {
                                dtf.Merge(dtf2);
                                break;
                            }
                            else
                            {
                                objPRReq.Flag1 = 1;
                                objPRReq.Flag2 = 1;
                                objPRReq.Flag3 = 0;
                                objPRReq.Flag4 = 0;
                                objPRReq.Flag5 = 0;
                                PRResp rf3 = objPRIBC.getAllEmpToursforApproval_EmpID_Flag3_OEmpID_SMS(objPRReq);
                                DataTable dtf3 = rf3.GetTable;
                                if (dtf3.Rows.Count > 0)
                                {
                                    dtf.Merge(dtf3);
                                    break;
                                }
                                else
                                {
                                    objPRReq.Flag1 = 1;
                                    objPRReq.Flag2 = 1;
                                    objPRReq.Flag3 = 1;
                                    objPRReq.Flag4 = 0;
                                    objPRReq.Flag5 = 0;
                                    PRResp rf4 = objPRIBC.getAllEmpToursforApproval_EmpID_Flag4_OEmpID_SMS(objPRReq);
                                    DataTable dtf4 = rf4.GetTable;
                                    if (dtf4.Rows.Count > 0)
                                    {
                                        dtf.Merge(dtf4);
                                        break;
                                    }
                                    else
                                    {
                                        objPRReq.Flag1 = 1;
                                        objPRReq.Flag2 = 1;
                                        objPRReq.Flag3 = 1;
                                        objPRReq.Flag4 = 1;
                                        objPRReq.Flag5 = 0;
                                        PRResp rf5 = objPRIBC.getAllEmpToursforApproval_EmpID_Flag5_OEmpID_SMS(objPRReq);
                                        DataTable dtf5 = rf5.GetTable;
                                        if (dtf5.Rows.Count > 0)
                                        {
                                            dtf.Merge(dtf5);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    objPRReq.Approval = 0;
                    PRResp rnf = objPRIBC.getAllEmpToursforApproval_withoutFlag_SMS(objPRReq);
                    DataTable dtnf = rnf.GetTable;
                    if (dtnf.Rows.Count > 0)
                    {
                        dtf.Merge(dtnf);
                    }
                }
            }

            if (dtf.Rows.Count > 0)
            {
                for (int j = 0; j < dtf.Rows.Count; j++)
                {
                    objPRReq.OEmpID = int.Parse(dtf.Rows[j]["OEmpID"].ToString());
                    objPRReq.OID = oid;
                    objPRReq.Status = "Active";
                    PRResp rsms = objPRIBC.getAllOHeadsInfo_SearchforSMS(objPRReq);
                    DataTable dtsms = rsms.GetTable;
                    if (dtsms.Rows.Count > 0)
                    {
                        string uMob = dtsms.Rows[0]["Mobile"].ToString();                   
                        string name = dtsms.Rows[0]["Name"].ToString();
                        objPRReq.Name = name;
                        objPRReq.Mobile = double.Parse(uMob.ToString());
                        objPRReq.EmpID = double.Parse(dtsms.Rows[0]["EmpID"].ToString());
                        objPRReq.Dates = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                        PRResp rs = objPRIBC.getLT_SMSAlert(objPRReq);
                        DataTable dts = rs.GetTable;
                        if (dts.Rows.Count > 0)
                        {
                            //skipped
                        }
                        else
                        {
                            string msms = "Dear " + name + ", One or more Leave / Tour requests are waiting for your approval, Please login to ERP (http://erp.nirdpr.in) with EmpNo & Password. Thank You";
                            getMailService();
                            SMSHttpPostClient s = new SMSHttpPostClient();
                            string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
                            objPRIBC.Add_LT_SMSAlert(objPRReq);
                        }
                    }
                }
            }
        }
    }
   
    public void getAll_PS_LeaveApproval()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.Flag1 = 1;
        objPRReq.Flag2 = 0;
        objPRReq.Approval = 0;
        objPRReq.Reject = 0;
        DateTime now = DateTime.Now;
        objPRReq.FromDate = now.AddDays(-30).ToString("dd/MMM/yyyy");
        PRResp rpc = objPRIBC.getAllPSEmpLeavesforApprovalProcessFlow_SMS(objPRReq);
        DataTable dtpc = rpc.GetTable;
        if (dtpc.Rows.Count > 0)
        {
            dtf.Merge(dtpc);
        }

        if (dtf.Rows.Count > 0)
        {
            for (int j = 0; j < dtf.Rows.Count; j++)
            {
                if (dtf.Rows[j]["PCStatus"].ToString() == "")
                {
                    string pcid = dtf.Rows[j]["PCEmpID"].ToString();
                    if (pcid != "")
                    {
                        objPRReq.OEmpID = int.Parse(pcid);
                    }
                    else
                    {
                        objPRReq.OEmpID = 0;
                    }
                }
                objPRReq.OID = oid;
                objPRReq.Status = "Active";
                PRResp rsms = objPRIBC.getAllOHeadsInfo_SearchforSMS(objPRReq);
                DataTable dtsms = rsms.GetTable;
                if (dtsms.Rows.Count > 0)
                {
                    string uMob = dtsms.Rows[0]["Mobile"].ToString();                   
                    string name = dtsms.Rows[0]["Name"].ToString();
                    objPRReq.Name = name;
                    objPRReq.Mobile = double.Parse(uMob.ToString());
                    objPRReq.EmpID = double.Parse(dtsms.Rows[0]["EmpID"].ToString());
                    objPRReq.Dates = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                    PRResp rs = objPRIBC.getLT_SMSAlert(objPRReq);
                    DataTable dts = rs.GetTable;
                    if (dts.Rows.Count > 0)
                    {
                        //skipped
                    }
                    else
                    {
                        string msms = "Dear " + name + ", One or more Leave/Tour requests are waiting for your approval, Please login to ERP(http://erp.nirdpr.in) with EmpNo & Password.";
                        getMailService();
                        SMSHttpPostClient s = new SMSHttpPostClient();
                        string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
                        objPRIBC.Add_LT_SMSAlert(objPRReq);
                    }
                }
            }
        }

        // Head Level
        PRResp rh = objPRIBC.getAllPSEmpLeavesforApprovalProcessFlow_HSMS(objPRReq);
        DataTable dth = rh.GetTable;
        if (dth.Rows.Count > 0)
        {
            for (int j = 0; j < dth.Rows.Count; j++)
            {
                if (dth.Rows[j]["HStatus"].ToString() == "")
                {
                    string pcid = dth.Rows[j]["HEmpID"].ToString();
                    if (pcid != "")
                    {
                        objPRReq.OEmpID = int.Parse(pcid);
                    }
                    else
                    {
                        objPRReq.OEmpID = 0;
                    }
                }
                objPRReq.OID = oid;
                objPRReq.Status = "Active";
                PRResp rsms = objPRIBC.getAllOHeadsInfo_SearchforSMS(objPRReq);
                DataTable dtsms = rsms.GetTable;
                if (dtsms.Rows.Count > 0)
                {
                    string uMob = dtsms.Rows[0]["Mobile"].ToString();                   
                    string name = dtsms.Rows[0]["Name"].ToString();
                    objPRReq.Name = name;
                    objPRReq.Mobile = double.Parse(uMob.ToString());
                    objPRReq.EmpID = double.Parse(dtsms.Rows[0]["EmpID"].ToString());
                    objPRReq.Dates = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                    PRResp rs = objPRIBC.getLT_SMSAlert(objPRReq);
                    DataTable dts = rs.GetTable;
                    if (dts.Rows.Count > 0)
                    {
                        //skipped
                    }
                    else
                    {
                        string msms = "Dear " + name + ", One or more Leave/Tour requests are waiting for your approval, Please login to ERP(http://erp.nirdpr.in) with EmpNo & Password.";
                        getMailService();
                        SMSHttpPostClient s = new SMSHttpPostClient();
                        string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
                        objPRIBC.Add_LT_SMSAlert(objPRReq);
                    }
                }
            }
        }
    }
    public void getAll_PS_TourApproval()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.Flag1 = 1;
        objPRReq.Flag2 = 0;
        objPRReq.Approval = 0;
        objPRReq.Reject = 0;
        DateTime now = DateTime.Now;
        objPRReq.FromDate = now.AddDays(-30).ToString("dd/MMM/yyyy");
        PRResp rpc = objPRIBC.getAllPSEmpToursforApprovalProcessFlow_PCSMS(objPRReq);
        DataTable dtpc = rpc.GetTable;
        if (dtpc.Rows.Count > 0)
        {
            dtf.Merge(dtpc);
        }

        if (dtf.Rows.Count > 0)
        {
            for (int j = 0; j < dtf.Rows.Count; j++)
            {
                if (dtf.Rows[j]["PCStatus"].ToString() == "")
                {
                    string pcid = dtf.Rows[j]["PCEmpID"].ToString();
                    if (pcid != "")
                    {
                        objPRReq.OEmpID = int.Parse(pcid);
                    }
                    else
                    {
                        objPRReq.OEmpID = 0;
                        break;
                    }
                }
                objPRReq.OID = oid;
                objPRReq.Status = "Active";
                PRResp rsms = objPRIBC.getAllOHeadsInfo_SearchforSMS(objPRReq);
                DataTable dtsms = rsms.GetTable;
                if (dtsms.Rows.Count > 0)
                {
                    string uMob = dtsms.Rows[0]["Mobile"].ToString();                   
                    string name = dtsms.Rows[0]["Name"].ToString();
                    objPRReq.Name = name;
                    objPRReq.Mobile = double.Parse(uMob.ToString());
                    objPRReq.EmpID = double.Parse(dtsms.Rows[0]["EmpID"].ToString());
                    objPRReq.Dates = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                    PRResp rs = objPRIBC.getLT_SMSAlert(objPRReq);
                    DataTable dts = rs.GetTable;
                    if (dts.Rows.Count > 0)
                    {
                        //skipped
                    }
                    else
                    {
                        string msms = "Dear " + name + ", One or more Leave/Tour requests are waiting for your approval, Please login to ERP(http://erp.nirdpr.in) with EmpNo & Password.";
                        getMailService();
                        SMSHttpPostClient s = new SMSHttpPostClient();
                        string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
                        objPRIBC.Add_LT_SMSAlert(objPRReq);
                    }
                }
            }
        }

        PRResp rh = objPRIBC.getAllPSEmpToursforApprovalProcessFlow_HSMS(objPRReq);
        DataTable dth = rh.GetTable;
        if (dth.Rows.Count > 0)
        {
            for (int j = 0; j < dth.Rows.Count; j++)
            {
                if (dth.Rows[j]["HStatus"].ToString() == "")
                {
                    string pcid = dth.Rows[j]["HEmpID"].ToString();
                    if (pcid != "")
                    {
                        objPRReq.OEmpID = int.Parse(pcid);
                    }
                    else
                    {
                        objPRReq.OEmpID = 0;
                        break;
                    }
                }
                objPRReq.OID = oid;
                objPRReq.Status = "Active";
                PRResp rsms = objPRIBC.getAllOHeadsInfo_SearchforSMS(objPRReq);
                DataTable dtsms = rsms.GetTable;
                if (dtsms.Rows.Count > 0)
                {
                    string uMob = dtsms.Rows[0]["Mobile"].ToString();                   
                    string name = dtsms.Rows[0]["Name"].ToString();
                    objPRReq.Name = name;
                    objPRReq.Mobile = double.Parse(uMob.ToString());
                    objPRReq.EmpID = double.Parse(dtsms.Rows[0]["EmpID"].ToString());
                    objPRReq.Dates = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                    PRResp rs = objPRIBC.getLT_SMSAlert(objPRReq);
                    DataTable dts = rs.GetTable;
                    if (dts.Rows.Count > 0)
                    {
                        //skipped
                    }
                    else
                    {
                        string msms = "Dear " + name + ", One or more Leave/Tour requests are waiting for your approval, Please login to ERP(http://erp.nirdpr.in) with EmpNo & Password.";
                        getMailService();
                        SMSHttpPostClient s = new SMSHttpPostClient();
                        string res = s.sendSingleSMS(smsUN, smsPwd, smsSender, uMob, msms, smsKey);
                        objPRIBC.Add_LT_SMSAlert(objPRReq);
                    }
                }
            }
        }
    }
}