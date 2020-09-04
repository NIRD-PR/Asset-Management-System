using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_ConsoliInventory : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname, deptname = "CICT"; int oid = 1, did = 14;
    int amc=0,ww=0,oth=0,tot=0;
    int tamc = 0, tww = 0, toth = 0, ttot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
         getAdminUser();
         if (!IsPostBack)
         {
             getAllInvItems();
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
                uname = dt.Rows[0]["Name"].ToString(); 
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }
    public void getAllInvItems()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getAllHWItemTypes(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_Inventory.DataSource = dt;
            rptr_Inventory.DataBind();
            lbl_Count.Text = "No.of Items Listed :" + dt.Rows.Count.ToString();
            lbl_ItemCount.Text = "No.of Items Listed :" + dt.Rows.Count.ToString();
            lbl_Dated.Text = DateTime.Now.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label lbl_amc = rptr_Inventory.Items[i].FindControl("lbl_AMC") as Label;
                Label lbl_Warrenty = rptr_Inventory.Items[i].FindControl("lbl_withwarrenty") as Label;
                Label lbl_withoutWarrenty = rptr_Inventory.Items[i].FindControl("lbl_withoutWarrenty") as Label;
                Label lbl_Total = rptr_Inventory.Items[i].FindControl("lbl_total") as Label;
                objPRReq.ItemName = dt.Rows[i]["ItemType"].ToString();
                objPRReq.Warranty = "AMC";
                PRResp rname = objPRIBC.getAllItemInventory_ITemNameAMC(objPRReq);
                DataTable dtname = rname.GetTable;
                if (dtname.Rows.Count > 0)
                {
                    amc = int.Parse(dtname.Rows.Count.ToString());
                    lbl_amc.Text = amc.ToString();
                    tamc += amc;
                }
                else
                {
                    lbl_amc.Text = "0";
                }

                objPRReq.Warranty = "Warranty";
                PRResp rw = objPRIBC.getAllItemInventory_ITemNameAMC(objPRReq);
                DataTable dtw = rw.GetTable;
                if (dtw.Rows.Count > 0)
                {
                    ww = int.Parse(dtw.Rows.Count.ToString());
                    lbl_Warrenty.Text = ww.ToString();
                    tww += ww;
                }
                else
                {
                    lbl_Warrenty.Text = "0";
                }

                PRResp rww = objPRIBC.getAllItemInventory_ITemNameNoWarranty(objPRReq);
                DataTable dtww = rww.GetTable;
                if (dtww.Rows.Count > 0)
                {
                    oth = int.Parse(dtww.Rows.Count.ToString());
                    lbl_withoutWarrenty.Text = oth.ToString();
                    toth += oth;
                }
                else
                {
                    lbl_withoutWarrenty.Text = "0";
                }
                tot=amc + ww + oth;
                lbl_Total.Text = tot.ToString();
                amc = 0; ww = 0; oth = 0;
                ttot += tot;
            }

            System.Web.UI.WebControls.Label lbl_AMC = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_GAMC") as System.Web.UI.WebControls.Label;
            lbl_AMC.Text = tamc.ToString();

            System.Web.UI.WebControls.Label lbl_warnty = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_Gwithwarrenty") as System.Web.UI.WebControls.Label;
            lbl_warnty.Text = tww.ToString();

            System.Web.UI.WebControls.Label lbl_wowarnty = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_GwithoutWarrenty") as System.Web.UI.WebControls.Label;
            lbl_wowarnty.Text = toth.ToString();

            System.Web.UI.WebControls.Label lbl_gTot = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_GTotal") as System.Web.UI.WebControls.Label;
            lbl_gTot.Text = ttot.ToString();
        }
        else
        {
            rptr_Inventory.DataSource = dt;
            rptr_Inventory.DataBind();
            lbl_Count.Text = "No.of Items Listed :" + dt.Rows.Count.ToString();
        }
    }
}