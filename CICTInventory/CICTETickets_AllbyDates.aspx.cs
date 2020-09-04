using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.Globalization;
public partial class Inventory_CICTIniatedETicketsHold : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
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
        if (e.CommandName == "View")
        {
            string st = e.CommandArgument.ToString();
            getTickeDetails(st);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "showModal();", true);
            hdn_QuertyString.Value = st;
        }
        if (e.CommandName == "History")
        {
            string st1 = e.CommandArgument.ToString();
            getHistoryDetails(st1);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "showDivModal();", true);
            hdn_QuertyString.Value = st1;
        }
    }
    public void getTickeDetails(string st)
    {
        objPRReq.TicketNo = double.Parse(st);

        objPRReq.Status = "Active";
        objPRReq.Flag1 = 0;
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getMappedCIT_eTicketDetails_TicketNo(objPRReq);
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
            }
            else
            {
                PRResp rp = objPRIBC.getProjStffData(objPRReq);
                DataTable drp = rp.GetTable;
                if (drr.Rows.Count > 0)
                {
                    dl_EmpDetails.DataSource = drp;
                    dl_EmpDetails.DataBind();
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
    public void getAllTickets()
    {
        if (txt_FromDate.Text != "" && txt_ToDate.Text != "")
        {
            objPRReq.OID = oid;
            objPRReq.StartDate = DateTime.ParseExact(txt_FromDate.Text.Trim(), "dd/MMM/yyyy", CultureInfo.InvariantCulture);
            objPRReq.EndDate = DateTime.ParseExact(txt_ToDate.Text.Trim(), "dd/MMM/yyyy", CultureInfo.InvariantCulture);
            objPRReq.ToDate = txt_ToDate.Text.Trim();
            PRResp r = objPRIBC.getAllCIT_eTicketDetails_Dates(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                rptr_TicketData.DataSource = dt;
                rptr_TicketData.DataBind();
                lbl_Count.Text = "No.of Tickets Listed : " + dt.Rows.Count.ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Label lblStatus = (Label)rptr_TicketData.Items[i].FindControl("lbl_Status");
                    if (dt.Rows[i]["Flag1"].ToString() == "1" && dt.Rows[i]["Flag2"].ToString() == "0")
                    {
                        lblStatus.Text = "Action Assigned to " + dt.Rows[i]["UName"].ToString();
                        lblStatus.Attributes.Add("style", "color:#F00;");
                    }
                    else if (dt.Rows[i]["Flag1"].ToString() == "1" && dt.Rows[i]["Flag2"].ToString() == "1")
                    {
                        lblStatus.Text = "Action is In-Progress by " + dt.Rows[i]["UName"].ToString();
                        lblStatus.Attributes.Add("style", "color:#009900;");
                    }
                    else if (dt.Rows[i]["Flag1"].ToString() == "1" && dt.Rows[i]["Flag2"].ToString() == "1" && dt.Rows[i]["Flag3"].ToString() == "1")
                    {
                        lblStatus.Text = "This Ticket is Kept on Hold for Sometime by " + dt.Rows[i]["UName"].ToString();
                        lblStatus.Attributes.Add("style", "color:#0000FF;");
                    }
                    else if (dt.Rows[i]["Flag1"].ToString() == "1" && dt.Rows[i]["Flag2"].ToString() == "1" && dt.Rows[i]["Flag4"].ToString() == "1")
                    {
                        lblStatus.Text = "This Ticket Closed by " + dt.Rows[i]["UName"].ToString();
                        lblStatus.Attributes.Add("style", "color:#00;");
                    }
                    else
                    {
                        lblStatus.Text = "Action Not Yet Initiated";
                    }
                    lbl_NoData.Text = "";
                    lbl_NoData.Visible = false;
                }
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

    public void getHistoryDetails(string st1)
    {
        hdn_QuertyString.Value = st1;
        objPRReq.TicketNo = double.Parse(hdn_QuertyString.Value);
        objPRReq.Status = "Active";
        objPRReq.Flag1 = 1;
        objPRReq.Flag2 = 1;
        objPRReq.Flag4 = 0;
        objPRReq.OID = oid;
        lbl_Ticketnos.Text = "History of the Ticket No. " + st1.ToString();
        lbl_CTicketno.Text = st1.ToString();
        PRResp rc = objPRIBC.getMappedCIT_eTicketDetails_TicketNo(objPRReq);
        DataTable dtc = rc.GetTable;
        if (dtc.Rows.Count > 0)
        {
            lbl_Problem.Text = dtc.Rows[0]["ProblemDescription"].ToString();
            lbl_PDated.Text = "Printed Date: " + DateTime.Now.ToString();
            lbl_ItemName.Text = dtc.Rows[0]["ItemName"].ToString();
            lbl_EDated.Text = dtc.Rows[0]["Dated"].ToString();
            lbl_ENames.Text = dtc.Rows[0]["Name"].ToString();
            lbl_IDated.Text = dtc.Rows[0]["UDated"].ToString();
            lbl_UNames.Text = dtc.Rows[0]["UName"].ToString();
        }
        PRResp r = objPRIBC.getHistoryCIT_eTicketDetails(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_History.DataSource = dt;
            rptr_History.DataBind();
            lbl_pCount.Text = (int.Parse(dt.Rows.Count.ToString()) + 2).ToString();
        }
    }

    protected void btn_GetData_Click(object sender, EventArgs e)
    {
        getAllTickets();
    }
}