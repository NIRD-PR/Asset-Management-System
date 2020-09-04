using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_InventoryHome : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string name; int oid;
    int gTot = 1, lbltotCount = 0, lblProgCount = 0, lblHoldCount = 0, lblClosedCount = 0;
    int NewTckt,TotTckt, ProgTckt, HoldTckt, ClosedTckt;
    int GNewTckt=0,GTotTckt = 0, GProgTckt = 0, GHoldTckt = 0, GClosedTckt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
         getAdminUser();
         if (!IsPostBack)
         {
             getAllTickets();
             getNewTickets();
             getProgTickets();
             getHoldTickets();
             getClosedTickets();
             getAllDepts();
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
    public void getAllTickets()
    {
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getAllTotalTickets_Head(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_Count.Text = " Total Tickets : " + dt.Rows[0]["count"].ToString();
            gTot = int.Parse(dt.Rows[0]["count"].ToString());
        }
    }
    public void getNewTickets()
    {
        objPRReq.OID = oid;
        objPRReq.Flag1 = 0;
        PRResp r = objPRIBC.getAllUnAssignedTickets_Head(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_TotTicketsCount.Text = dt.Rows[0]["count"].ToString();
            int tott = int.Parse(dt.Rows[0]["count"].ToString());
           // gTot = int.Parse(dt.Rows[0]["count"].ToString());
            if (gTot != 0)
            {
                lbltotCount = (tott / gTot);
                lbl_TotCounts.Text = ((tott / gTot) * 100).ToString() + '%';
                lbl_totTckPer.Text = ((tott / gTot) * 100).ToString() + '%';
                tot_Pbar.Style.Add("width", lbl_TotCounts.Text);
            }
            else
            {
                lbltotCount = 0;
                lbl_TotCounts.Text = (0 * 100).ToString() + '%';
                lbl_totTckPer.Text = (0 * 100).ToString() + '%';
                tot_Pbar.Style.Add("width", lbl_TotCounts.Text);
            }
        }
    }

    public void getProgTickets()
    {
        objPRReq.OID = oid;
        objPRReq.Flag1 = 1;
        objPRReq.Flag2 = 1;
        objPRReq.Flag3 = 0;
        objPRReq.Flag4 = 0;
        PRResp r = objPRIBC.getAllInprogressTickets_Head(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_ProgTicketsCount.Text = dt.Rows[0]["count"].ToString();
            int totp = int.Parse(dt.Rows[0]["count"].ToString());
            if (gTot != 0)
            {
                lblProgCount = ((totp * 100) / gTot);
                lbl_ProgCounts.Text = ((totp * 100) / gTot).ToString() + '%';
                lbl_ProgTckPer.Text = ((totp * 100) / gTot).ToString() + '%';
                Prog_Pbar.Style.Add("width", lbl_ProgCounts.Text);
            }
        }
    }

    public void getHoldTickets()
    {
        objPRReq.OID = oid;
        objPRReq.Flag1 = 1;
        objPRReq.Flag2 = 1;
        objPRReq.Flag3 = 1;
        objPRReq.Flag4 = 0;
        PRResp r = objPRIBC.getAllInprogressTickets_Head(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_HoldTicketsCount.Text = dt.Rows[0]["count"].ToString();
            int tot = int.Parse(dt.Rows[0]["count"].ToString());
            if (gTot != 0)
            {
                lblHoldCount = ((tot * 100) / gTot);
                lbl_HoldCounts.Text = ((tot * 100) / gTot).ToString() + '%';
                lbl_HoldTckPer.Text = ((tot * 100) / gTot).ToString() + '%';
                Hold_Pbar.Style.Add("width", lbl_HoldCounts.Text);
            }
        }
    }

    public void getClosedTickets()
    {
        objPRReq.OID = oid;
        objPRReq.Flag1 = 1;
        objPRReq.Flag2 = 1;
        objPRReq.Flag3 = 0;
        objPRReq.Flag4 = 1;
        PRResp r = objPRIBC.getAllInprogressTickets_Head(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_ClosedTicketsCount.Text = dt.Rows[0]["count"].ToString();
            int tot = int.Parse(dt.Rows[0]["count"].ToString());
            if (gTot != 0)
            {
                lblClosedCount = ((tot * 100) / gTot);
                lbl_ClosedCounts.Text = ((tot * 100) / gTot).ToString() + '%';
                lbl_ClosedTckPer.Text = ((tot * 100) / gTot).ToString() + '%';
                Closed_Pbar.Style.Add("width", lbl_ClosedCounts.Text);
            }
        }
    }

    public void getAllDepts()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getDepartments(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_today.Text = DateTime.Now.ToString("dd/MM/yyyy");
            rptr_deptTicketsStatus.DataSource = dt;
            rptr_deptTicketsStatus.DataBind();
            lbl_IndentsCount.Text = "No.of Departments Listed :" + dt.Rows.Count.ToString();
            lbl_noofdepts.Text = "No.of Departments Listed :" + dt.Rows.Count.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label lblNewTickets = (Label)rptr_deptTicketsStatus.Items[i].FindControl("lbl_NewTickets");
                Label lbltotTickets = (Label)rptr_deptTicketsStatus.Items[i].FindControl("lbl_totTickets");
                Label lblProgTickets = (Label)rptr_deptTicketsStatus.Items[i].FindControl("lbl_ProgTickets");
                Label lblHoldTickets = (Label)rptr_deptTicketsStatus.Items[i].FindControl("lbl_HoldTickets");
                Label lblClosedTickets = (Label)rptr_deptTicketsStatus.Items[i].FindControl("lbl_ClosedTickets");
                Label lblGTotTickets = (Label)rptr_deptTicketsStatus.Items[i].FindControl("lbl_TotlTickets");

                objPRReq.DID = int.Parse(dt.Rows[i]["DID"].ToString());
                objPRReq.Flag1 = 0;
                objPRReq.Flag2 = 0;
                objPRReq.Flag3 = 0;
                objPRReq.Flag4 = 0;
                 PRResp rn = objPRIBC.getAllCountTickets_Head_DID(objPRReq);
                DataTable dtn = rn.GetTable;
                if (dtn.Rows.Count > 0)
                {
                    NewTckt = int.Parse(dtn.Rows[0]["count"].ToString());
                    lblNewTickets.Text = dtn.Rows[0]["count"].ToString();
                    GNewTckt += NewTckt;
                }
                else
                {
                    lblNewTickets.Text = dtn.Rows.Count.ToString();
                }
                System.Web.UI.WebControls.Label lbl_NCount = rptr_deptTicketsStatus.Controls[rptr_deptTicketsStatus.Controls.Count - 1].Controls[0].FindControl("lbl_gNewTickets") as System.Web.UI.WebControls.Label;
                lbl_NCount.Text = GNewTckt.ToString();

                objPRReq.Flag1 = 1;
                PRResp rt = objPRIBC.getAllCountTickets_Head_DID(objPRReq);
                DataTable dtt = rt.GetTable;
                if (dtt.Rows.Count > 0)
                {
                    TotTckt = int.Parse(dtt.Rows[0]["count"].ToString());
                    lbltotTickets.Text = dtt.Rows[0]["count"].ToString();
                    GTotTckt += TotTckt;
                }
                else
                {
                    lbltotTickets.Text = dtt.Rows.Count.ToString();
                }
                System.Web.UI.WebControls.Label lbl_TCount = rptr_deptTicketsStatus.Controls[rptr_deptTicketsStatus.Controls.Count - 1].Controls[0].FindControl("lbl_GtotTickets") as System.Web.UI.WebControls.Label;
                lbl_TCount.Text = GTotTckt.ToString();

                // InProgress
                objPRReq.Flag1 = 1;
                objPRReq.Flag2 = 1;
                objPRReq.Flag3 = 0;
                objPRReq.Flag4 = 0;
                PRResp rp = objPRIBC.getAllCountTickets_Head_DID(objPRReq);
                DataTable dtp = rt.GetTable;
                if (dtp.Rows.Count > 0)
                {
                    ProgTckt = int.Parse(dtp.Rows[0]["count"].ToString());
                    lblProgTickets.Text = dtp.Rows[0]["count"].ToString();
                    GProgTckt += ProgTckt;
                }
                else
                {
                    lblProgTickets.Text = dtp.Rows.Count.ToString();
                }
                System.Web.UI.WebControls.Label lbl_PCount = rptr_deptTicketsStatus.Controls[rptr_deptTicketsStatus.Controls.Count - 1].Controls[0].FindControl("lbl_GProgTickets") as System.Web.UI.WebControls.Label;
                lbl_PCount.Text = GProgTckt.ToString();

                // Hold Tickets
                objPRReq.Flag1 = 1;
                objPRReq.Flag2 = 1;
                objPRReq.Flag3 = 1;
                objPRReq.Flag4 = 0;
                PRResp rh = objPRIBC.getAllCountTickets_Head_DID(objPRReq);
                DataTable dth = rt.GetTable;
                if (dth.Rows.Count > 0)
                {
                    HoldTckt = int.Parse(dth.Rows[0]["count"].ToString());
                    lblHoldTickets.Text = dth.Rows[0]["count"].ToString();
                    GHoldTckt += HoldTckt;
                }
                else
                {
                    lblHoldTickets.Text = dth.Rows.Count.ToString();
                }
                System.Web.UI.WebControls.Label lbl_HCount = rptr_deptTicketsStatus.Controls[rptr_deptTicketsStatus.Controls.Count - 1].Controls[0].FindControl("lbl_GHoldTickets") as System.Web.UI.WebControls.Label;
                lbl_HCount.Text = GHoldTckt.ToString();

                //Closed Tickets
                objPRReq.Flag1 = 1;
                objPRReq.Flag2 = 1;
                objPRReq.Flag3 = 0;
                objPRReq.Flag4 = 1;
                PRResp rc = objPRIBC.getAllCountTickets_Head_DID(objPRReq);
                DataTable dtc = rt.GetTable;
                if (dtc.Rows.Count > 0)
                {
                    ClosedTckt = int.Parse(dtc.Rows[0]["count"].ToString());
                    lblClosedTickets.Text = dtc.Rows[0]["count"].ToString();
                    GClosedTckt += ClosedTckt;
                }
                else
                {
                    lblClosedTickets.Text = dtc.Rows.Count.ToString();
                }
                System.Web.UI.WebControls.Label lbl_CCount = rptr_deptTicketsStatus.Controls[rptr_deptTicketsStatus.Controls.Count - 1].Controls[0].FindControl("lbl_GClosedTickets") as System.Web.UI.WebControls.Label;
                lbl_CCount.Text = GClosedTckt.ToString();

                lblGTotTickets.Text = (NewTckt + TotTckt + ProgTckt + HoldTckt + ClosedTckt).ToString();

                System.Web.UI.WebControls.Label lbl_GTotCount = rptr_deptTicketsStatus.Controls[rptr_deptTicketsStatus.Controls.Count - 1].Controls[0].FindControl("lbl_gTotlTickets") as System.Web.UI.WebControls.Label;
                lbl_GTotCount.Text = (GNewTckt + GTotTckt + GProgTckt + GHoldTckt + GClosedTckt).ToString();
            }
        }
    }
}