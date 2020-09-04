using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.Diagnostics;
using Mydll17032016;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using System.Text;
using System.IO;
public partial class CITStaff_NewETickets : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname, email, pwd, smsapi, mob, qrcode; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
         getCITUser();
         if (!IsPostBack)
         {
             getAllRegisteredTickets();
         }
    }
    public void getCITUser()
    {
        if (Session["UserID"].ToString() != "")
        {
            objPRReq.Status = "Active";
            objPRReq.CSID = int.Parse(Session["UserID"].ToString());
            PRResp resp = objPRIBC.getCITSSInfo(objPRReq);
            DataTable dt = resp.GetTable;
            if (dt.Rows.Count > 0)
            {
                oid = int.Parse(dt.Rows[0]["OID"].ToString());
                uname = dt.Rows[0]["Name"].ToString(); 
                hdn_Email.Value = dt.Rows[0]["Email"].ToString();
                hdn_EmpID.Value = dt.Rows[0]["EmpID"].ToString();
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
    protected void rptr_TicketData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        MydllSendMail mdll = new Mydll17032016.MydllSendMail();
        Boolean mailstate = new Boolean();
        if (e.CommandName == "Initiate")
        {
            objPRReq.TicketNo = int.Parse(e.CommandArgument.ToString());
            objPRReq.Flag1 = 1;
            objPRReq.OID = oid;
            objPRReq.Flag2 = 1;
            objPRReq.Status = "Active";
            objPRReq.EmpID = int.Parse(hdn_EmpID.Value.Trim());
            objPRIBC.AcceptTicket_CITStaff(objPRReq);

            objPRReq.UEmpID = int.Parse(hdn_EmpID.Value.Trim());
            PRResp rm = objPRIBC.getCIT_eTicket_UEmpID_TicketNo(objPRReq);
            DataTable dtm = rm.GetTable;
            if (dtm.Rows.Count > 0)
            {
                getMailService();

                string fm = email;
                string fp = pwd;
                string tomail = dtm.Rows[0]["Email"].ToString();

                string sub = "Ticket No." + dtm.Rows[0]["TicketNo"] + " is  initiated by " + dtm.Rows[0]["UName"].ToString() + ". He will come to you shortly, to resolve your problem." + Environment.NewLine + "Thank You," + Environment.NewLine + "-: CICT";
                string body = "Dear " + dtm.Rows[0]["Name"].ToString() + "," + Environment.NewLine + "Ticket No." + dtm.Rows[0]["TicketNo"] + " is  iniated by " + dtm.Rows[0]["UName"].ToString() + ". He will come to you shortly, to resolve your problem." + Environment.NewLine + "Thank You," + Environment.NewLine + "-: CICT";
                mob = dtm.Rows[0]["Mobile"].ToString();
                 mailstate = mdll.sndmailswithoutattchment(465, "mail.gov.in", fm, fp, fm, tomail, "", "", sub, body);
                string strUrl = smsapi + "=" + mob + "&msg=" + sub + "&type=1&dnd_check=0";
                // Create a request object  
                WebRequest request = HttpWebRequest.Create(strUrl);
                // Get the response back  
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = (Stream)response.GetResponseStream();
                StreamReader readStream = new StreamReader(s);
                string dataString = readStream.ReadToEnd();
                response.Close();
                s.Close();
                readStream.Close();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Ticket Accepted and Work Initiated Successfully..!!!'); window.open('../CITSS_NewTkt/{0}','_self');", true);
        }
        if (e.CommandName == "View")
        {
            string st = e.CommandArgument.ToString();
            getTickeDetails(st);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "showModal();", true);
            hdn_QuertyString.Value = st;
        }
    }
    public void getMailService()
    {
        objPRReq.OID = 1;
        objPRReq.Status = "Active";
        PRResp rm = objPRIBC.getMailServices_OID(objPRReq);
        System.Data.DataTable dtm = rm.GetTable;
        if (dtm.Rows.Count > 0)
        {
            email = dtm.Rows[0]["Email"].ToString();
            pwd = dtm.Rows[0]["Password"].ToString();
            smsapi = dtm.Rows[0]["SMSAPI"].ToString();
        }
    }
    public void getTickeDetails(string st)
    {
        objPRReq.TicketNo = double.Parse(st);
       
        objPRReq.Status = "Active";
        objPRReq.Flag1 = 1;
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getMappedCIT_eTicketDetails(objPRReq);
        DataTable dt = r.GetTable;
        objPRReq.EmpID = int.Parse(dt.Rows[0]["EmpID"].ToString());
        if (dt.Rows.Count > 0)
        {           
            PRResp rr = objPRIBC.getEmp_MonthlySalayByEmpID_Status(objPRReq);
            DataTable drr = rr.GetTable;
            if (drr.Rows.Count > 0)
            {
                dl_EmpDetails.DataSource = drr;
                dl_EmpDetails.DataBind();
                DateTime dob = DateTime.Parse(drr.Rows[0]["DOB"].ToString());
                DateTime dor = dob.AddYears(60);
                // Retirement Date
                Label lbl_dor = (Label)dl_EmpDetails.Items[0].FindControl("lbl_DOR");
                lbl_dor.Text = dor.ToString("dd/MM/yyyy");
                // Current age
                Label lblage = (Label)dl_EmpDetails.Items[0].FindControl("lbl_Age");
                DateTime now = DateTime.Now;
                TimeSpan ts = now - dob;
                double year = (ts).Days / 365;
                lblage.Text = year.ToString();
            }
            else
            {
                PRResp rp = objPRIBC.getProjStffData(objPRReq);
                DataTable drp = rp.GetTable;
                if (drp.Rows.Count > 0)
                {
                    dl_EmpDetails.DataSource = drp;
                    dl_EmpDetails.DataBind();
                    DateTime dob = DateTime.Parse(drp.Rows[0]["DOB"].ToString());
                    DateTime dor = DateTime.Parse(drp.Rows[0]["EndDate"].ToString());
                    // Retirement Date
                    Label lbl_dor = (Label)dl_EmpDetails.Items[0].FindControl("lbl_DOR");
                    lbl_dor.Text = dor.ToString("dd/MM/yyyy");
                    // Current age
                    Label lblage = (Label)dl_EmpDetails.Items[0].FindControl("lbl_Age");
                    DateTime now = DateTime.Now;
                    TimeSpan ts = now - dob;
                    double year = (ts).Days / 365;
                    lblage.Text = year.ToString();
                }
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                objPRReq.Flag1 = 1;
                objPRReq.ITID = int.Parse(dt.Rows[j]["ITID"].ToString());
                PRResp rd = objPRIBC.getAllMappedInventory_EmpIDITID(objPRReq);
                DataTable dtd = rd.GetTable;
                if (dtd.Rows.Count > 0)
                {
                    rptr_Items.DataSource = dtd;
                    rptr_Items.DataBind();
                    for (int i = 0; i < dtd.Rows.Count; i++)
                    {
                        DataList dl = (DataList)rptr_Items.Items[i].FindControl("dl_CITData");
                        objPRReq.ITID = int.Parse(dtd.Rows[i]["ITID"].ToString());
                        PRResp rk = objPRIBC.getAllMappedInventory_ITID_EmpID(objPRReq);
                        DataTable dtk = rk.GetTable;
                        if (dtk.Rows.Count > 0)
                        {
                            dl.DataSource = dtk;
                            dl.DataBind();
                            lbl_TicketNo.Text = "";
                        }
                    }
                }
                else
                {
                    rptr_Items.DataSource = dtd;
                    rptr_Items.DataBind();
                    lbl_NoDevice.Text = dt.Rows[j]["ItemName"].ToString(); ;
                }
                lbl_AvailableTime.Text = dt.Rows[j]["AvailableTime"].ToString();
                lbl_Floor.Text = dt.Rows[j]["Floor"].ToString();
                lbl_Location.Text = dt.Rows[j]["Location"].ToString();
                lbl_RoomNo.Text = dt.Rows[j]["RoomNo"].ToString();
                lbl_UName.Text = dt.Rows[j]["UName"].ToString();
                //lbl_UEmail.Text = dt.Rows[j]["UEmail"].ToString();
                //lbl_UMobile.Text = dt.Rows[j]["UMobile"].ToString();
                lbl_ProblemDescription.Text = dt.Rows[j]["ProblemDescription"].ToString();                
                lbl_TicketNo.Text = dt.Rows[j]["TicketNo"].ToString();
                lbl_Tickt.Text = dt.Rows[j]["TicketNo"].ToString();
                lbl_Date.Text = dt.Rows[j]["Dated"].ToString();
            }
        }
    }
    public void getAllRegisteredTickets()
    {
        objPRReq.OID = oid;
        objPRReq.Flag1 = 1;
        objPRReq.Flag2 = 0;
        objPRReq.UEmpID = int.Parse(hdn_EmpID.Value.Trim());
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getCIT_eTicket_UEmpID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_TicketData.DataSource = dt;
            rptr_TicketData.DataBind();
            lbl_Count.Text = "No.of Tickets Listed : " + dt.Rows.Count.ToString();
            lbl_NoData.Text = "";
            lbl_NoData.Visible = false;
        }
        else
        {
            rptr_TicketData.DataSource = dt;
            rptr_TicketData.DataBind();
            lbl_Count.Text = "No.of Tickets Listed : " + dt.Rows.Count.ToString();
            lbl_NoData.Visible = true;
            lbl_NoData.Text = " No New Tickets are assigend till now..";
        }
    }
}