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
public partial class CICTInventory_eTicketMapping2Staff : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string name, email, pwd, smsapi,mob, qrcode; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
         getAdminUser();
         if (!IsPostBack)
         {
             getAllUnAssignedTickets();
             getCITSupportingStaff();
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
                name = dt.Rows[0]["Name"].ToString();
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
    public void getAllUnAssignedTickets()
    {
        objPRReq.OID = oid;
        objPRReq.Flag1 = 0;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getAllunMappedCIT_eTicket(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            gv_Tickets.DataSource = dt;
            gv_Tickets.DataBind();
            lbl_Count.Text = "No.of Tickets Listed : " + dt.Rows.Count.ToString();
            lbl_NoData.Visible = false;
        }
        else
        {
            gv_Tickets.DataSource = dt;
            gv_Tickets.DataBind();
            lbl_Count.Text = "No.of Tickets Listed : " + dt.Rows.Count.ToString();
            lbl_NoData.Visible = true;
            lbl_NoData.Text = " No New Tickets found ";
        }
    }
    public void getCITSupportingStaff()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getAllCITSupporintStaff(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < gv_Tickets.Rows.Count; i++)
            {
                DropDownList ddlEmp = (DropDownList)gv_Tickets.Rows[i].FindControl("ddl_EmpName");
               
                ddlEmp.DataSource = dt;
                ddlEmp.DataTextField = "Name";
                ddlEmp.DataValueField = "EmpID";
                ddlEmp.DataBind();
                ddlEmp.Items.Insert(0, "--Select--");
            }
        }
    }
    protected void btn_CheckAll_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true);
    }
    protected void btn_UnCheckAll_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false);
    }
    private void ToggleCheckState(bool checkState)
    {
        // Iterate through the Products.Rows property
        foreach (GridViewRow row in gv_Tickets.Rows)
        {
            // Access the CheckBox
            CheckBox cb = (CheckBox)row.FindControl("cb_Emp");
            if (cb != null)
            {
                cb.Checked = checkState;
            }
        }
    }
    
    protected void btn_MapTicket_Click(object sender, EventArgs e)
    {
        MydllSendMail mdll = new Mydll17032016.MydllSendMail();
        Boolean mailstate = new Boolean();
        try
        {
            for (int i = 0; i < gv_Tickets.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gv_Tickets.Rows[i].FindControl("cb_Emp");
                DropDownList ddlEmp = (DropDownList) gv_Tickets.Rows[i].FindControl("ddl_EmpName");
                Label lbluEmail = (Label)gv_Tickets.Rows[i].FindControl("lbl_UEmail");
                Label lbluMobile = (Label)gv_Tickets.Rows[i].FindControl("lbl_UMobile");
                if (cb.Checked == true)
                {
                    objPRReq.TicketNo = double.Parse(gv_Tickets.Rows[i].Cells[1].Text.Trim());
                    objPRReq.UEmail=gv_Tickets.Rows[i].Cells[6].Text.Trim();
                    
                    if (ddlEmp.SelectedIndex > 0)
                    {
                        objPRReq.UEmpID = int.Parse(ddlEmp.SelectedValue.ToString());
                        objPRReq.UName = ddlEmp.SelectedItem.Text.Trim();
                    }
                    else
                    {
                        ddlEmp.Style.Add("border","#F00");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Please Select Supporting Staff Name..!!!'); window.open('../CIT_TMap/{0}','_self');", true);
                    }
                    objPRReq.Flag1 = 1;
                    objPRReq.UEmail = lbluEmail.Text.Trim();
                    objPRReq.UMobile = double.Parse(lbluMobile.Text.Trim());
                    objPRReq.Status = "Active";
                    objPRReq.OID = oid;
                    objPRReq.Dated = DateTime.Now;
                    objPRIBC.AssigneTicket2CITStaff(objPRReq);

                    getMailService();

                    string fm = email;
                    string fp = pwd;
                    string tomail = lbluEmail.Text.Trim();
                    string sub = "Ticket No." + gv_Tickets.Rows[i].Cells[1].Text.Trim() + " is  from " + gv_Tickets.Rows[i].Cells[3].Text.Trim() + " Assigned to you. Please accept and resolve the problem immediately." + Environment.NewLine + "Thank You," + Environment.NewLine + "-: CICT";
                   // string body = "Dear " + ddlEmp.SelectedItem.Text.Trim() + "," + Environment.NewLine + "Ticket No." + gv_Tickets.Rows[i].Cells[1].Text.Trim() + " Registered Successully..!!!" + Environment.NewLine + "One of our Technical Team member will get back to you to resolve your problem." + Environment.NewLine + "Thank you";
                    mob = lbluMobile.Text.Trim();
                   // mailstate = mdll.sndmailswithoutattchment(465, "mail.gov.in", fm, fp, fm, tomail, "", "", sub, body);
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
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('All the Selected Tickets are mapped to respective Supporting Staff Successfully..!!!'); window.open('../CIT_TMap/{0}','_self');", true);
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
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
    protected void ddl_EmpName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl= (DropDownList)sender;
        GridViewRow row= (GridViewRow)ddl.NamingContainer;
        if (row != null)
        {
            string uempID = ((DropDownList)(row.FindControl("ddl_EmpName"))).SelectedValue;
            Label lbluEmail = (Label)row.FindControl("lbl_UEmail");
            Label lbluMobile = (Label)row.FindControl("lbl_UMobile");
            objPRReq.EmpID = int.Parse(uempID);
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            PRResp r = objPRIBC.getCITSS_EmpID(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                lbluEmail.Text = dt.Rows[0]["Email"].ToString();
                lbluMobile.Text = dt.Rows[0]["Mobile"].ToString();
            }

        }
    }
}