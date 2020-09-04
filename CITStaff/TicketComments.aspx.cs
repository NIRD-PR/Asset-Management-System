using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITStaff_TicketComments : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getCITUser();
        if (!IsPostBack)
        {
            getStatus();
            if (Request.QueryString["st"] != null)
            {
                hdn_TicketNo.Value = Request.QueryString["st"].ToString();
                getTicketInfo();                
            }
            getOldComments();
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
                hdn_UEmpID.Value = dt.Rows[0]["EmpID"].ToString();
                hdn_UName.Value = uname;
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }

    public void getTicketInfo()
    {
        objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value);
        objPRReq.UEmpID = int.Parse(hdn_UEmpID.Value);
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getCIT_eTicket_UEmpID_TicketNo(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dl_TicketInfo.DataSource = dt;
            dl_TicketInfo.DataBind();
            hdn_ItemName.Value = dt.Rows[0]["ItemName"].ToString();
            hdn_ITID.Value = dt.Rows[0]["ITID"].ToString();
            hdn_ProblemDesciption.Value = dt.Rows[0]["ProblemDescription"].ToString();
            hdn_EmpID.Value = dt.Rows[0]["EmpID"].ToString();
            hdn_Name.Value = dt.Rows[0]["Name"].ToString();
        }
    }
    public void getStatus()
    {
        ddl_Status.Items.Insert(0, "--Select Status--");
        ddl_Status.Items.Insert(1, "In-Progress");
        ddl_Status.Items.Insert(2, "Transfered to Others");
        ddl_Status.Items.Insert(3, "Kept on Hold");
        ddl_Status.Items.Insert(4, "Closed");
        ddl_Status.DataBind();
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Status.SelectedIndex > 0)
            {
                objPRReq.OID = oid;
                objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value);
                objPRReq.Dated = DateTime.Now;
                objPRReq.Status = ddl_Status.SelectedItem.Text.Trim();
                objPRReq.Comment = convertQuotes(txt_Comment.Text.Trim());
                objPRReq.ITID = int.Parse(hdn_ITID.Value);
                objPRReq.ItemName = hdn_ItemName.Value;
                objPRReq.ProblemDescription = hdn_ProblemDesciption.Value;
                objPRReq.Name = hdn_Name.Value;
                objPRReq.EmpID = int.Parse(hdn_EmpID.Value);
                objPRReq.UEmpID = int.Parse(hdn_UEmpID.Value);
                objPRReq.UName = hdn_UName.Value;
                if (ddl_Status.SelectedItem.Text.Trim() == "Closed")
                {
                    objPRReq.Flag4 = 1;
                    objPRReq.Status = "Closed";
                    objPRReq.Dated = DateTime.Now;
                    objPRIBC.CloseCIT_eTicket_TicketNo(objPRReq);

                    PRResp r = objPRIBC.getAllTicketComment_UEmpID_ITID_Comment(objPRReq);
                    DataTable dt = r.GetTable;
                    if (dt.Rows.Count > 0)
                    {
                        //
                    }
                    else 
                    {
                        objPRIBC.AddeTicketComment(objPRReq);
                        string msg = hdn_TicketNo.Value + " Closed Successfully..!!!";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", " alert('" + msg + "'); window.open('../CITSS_Cmts/{0}','_self');", true);
                    }
                }
                else if (ddl_Status.SelectedItem.Text.Trim() == "Kept on Hold")
                {
                    objPRReq.Flag3 = 1;
                    objPRIBC.HoldCIT_eTicket_TicketNo(objPRReq);
                    PRResp r = objPRIBC.getAllTicketComment_UEmpID_ITID_Comment(objPRReq);
                    DataTable dt = r.GetTable;
                    if (dt.Rows.Count > 0)
                    {
                        //
                    }
                    else
                    {
                        objPRReq.Flag3 = 1;
                        objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value);
                        objPRIBC.HoldCIT_eTicket_TicketNo(objPRReq);

                        objPRIBC.AddeTicketComment(objPRReq);
                        string msg = hdn_TicketNo.Value + " Kept on Hold Successfully..!!!";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", " alert('" + msg + "'); window.open('../CITSS_Cmts/{0}','_self');", true);
                    }
                }
                else if (ddl_Status.SelectedItem.Text.Trim() == "Transfered to Others")
                {
                    objPRReq.Flag2 = 0;
                    objPRIBC.TransferCIT_eTicket_TicketNo(objPRReq);
                    string msg ="You can Map / Transfer this Ticket No."+ hdn_TicketNo.Value + " to others..!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "alert", " alert('" + msg + "'); window.open('../CITSS_SelfMap/{0}','_self');", true);
                }
                else
                {
                    PRResp r = objPRIBC.getAllTicketComment_UEmpID_ITID_Comment(objPRReq);
                    DataTable dt = r.GetTable;
                    if (dt.Rows.Count > 0)
                    {
                        string msg = "Comment is Already Registered for this ticket no." + dt.Rows[0]["TicketNo"].ToString();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                    }
                    else
                    {
                        objPRIBC.AddeTicketComment(objPRReq);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Comment Submitted Successfully..!!!'); window.open('../CITSS_Cmts/{0}','_self');", true);
                    }
                }
            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }
    }
    public void getOldComments()
    {
        if (hdn_TicketNo.Value != "")
        {
            objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value);
            objPRReq.OID = oid;
            PRResp r = objPRIBC.getAllTicketComment_UEmpID(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                rptr_TicketComments.DataSource = dt;
                rptr_TicketComments.DataBind();
                lbl_Counts.Text = "No.of Comments : " + dt.Rows.Count.ToString();
                lbl_TicketNo.Text = dt.Rows[0]["TicketNo"].ToString();
            }
        }
    }
}