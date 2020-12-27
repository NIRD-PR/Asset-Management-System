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
    string uname, deptname = "CICT"; int oid = 1, did = 14;
    int active = 0, idle = 0, inactive = 0, abandoned = 0, tot = 0;
    int tactive = 0, tidle = 0, tinactive = 0, tabandoned = 0, ttot = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
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
            Response.Redirect("~/CICTInventory/Default.aspx");
        }
    }
    public void getAllInvItems()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getItemTypes(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_Inventory.DataSource = dt;
            rptr_Inventory.DataBind();
            lbl_Count.Text = "No.of Items Listed :" + dt.Rows.Count.ToString();
            lbl_ItemCount.Text = "No.of Items Listed : " + dt.Rows.Count.ToString();
            lbl_Dated.Text = DateTime.Now.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Label lbl_active = rptr_Inventory.Items[i].FindControl("lbl_active") as Label;
                Label lbl_idle = rptr_Inventory.Items[i].FindControl("lbl_idle") as Label;
                Label lbl_inactive = rptr_Inventory.Items[i].FindControl("lbl_inactive") as Label;
                Label lbl_abandoned = rptr_Inventory.Items[i].FindControl("lbl_abandoned") as Label;
                Label lbl_Total = rptr_Inventory.Items[i].FindControl("lbl_total") as Label;
                objPRReq.ItemName = dt.Rows[i]["ItemType"].ToString();
                objPRReq.Status = "Active";
                PRResp rname = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
                DataTable dtname = rname.GetTable;
                if (dtname.Rows.Count > 0)
                {
                    active = int.Parse(dtname.Rows.Count.ToString());
                    lbl_active.Text = active.ToString();
                    tactive += active;
                }
                else
                {
                    lbl_active.Text = "0";
                }

                objPRReq.Status = "Idle";
                PRResp rw = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
                DataTable dtw = rw.GetTable;
                if (dtw.Rows.Count > 0)
                {
                    idle = int.Parse(dtw.Rows.Count.ToString());
                    lbl_idle.Text = idle.ToString();
                    tidle += idle;
                }
                else
                {
                    lbl_idle.Text = "0";
                }
                objPRReq.Status = "Inactive";
                PRResp rww = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
                DataTable dtww = rww.GetTable;
                if (dtww.Rows.Count > 0)
                {
                    inactive = int.Parse(dtww.Rows.Count.ToString());
                    lbl_inactive.Text = inactive.ToString();
                    tinactive += inactive;
                }
                else
                {
                    lbl_inactive.Text = "0";
                }
                objPRReq.Status = "Abandoned";
                rww = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
                dtww = rww.GetTable;
                if (dtww.Rows.Count > 0)
                {
                    abandoned = int.Parse(dtww.Rows.Count.ToString());
                    lbl_abandoned.Text = abandoned.ToString();
                    tabandoned += abandoned;
                }
                else
                {
                    lbl_abandoned.Text = "0";
                }
                tot = active + idle + inactive + abandoned;
                if (objPRReq.ItemName == "Printer")
                {
                    printer.Text = "Total: " + tot + " Active: " + active + "  Idle: " + idle + "  Inactive: " + inactive ;
                }
                if (objPRReq.ItemName == "Laptop")
                {
                    laptop.Text = "Total: " + tot + " Active: " + active + "  Idle: " + idle + "  Inactive: " + inactive;
                }
                if (objPRReq.ItemName == "Desktop")
                {
                    desktop.Text = "Total: " + tot + " Active: " + active + "  Idle: " + idle + "  Inactive: " + inactive;
                }
                if (objPRReq.ItemName == "Scanner")
                {
                    scanner.Text = "Total: " + tot + " Active: " + active + "  Idle: " + idle + "  Inactive: " + inactive;
                }
                lbl_Total.Text = tot.ToString();
                active = 0; idle = 0; inactive = 0; abandoned = 0;
                ttot += tot;
            }

            System.Web.UI.WebControls.Label lbl_tactive = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_tactive") as System.Web.UI.WebControls.Label;
            lbl_tactive.Text = tactive.ToString();

            System.Web.UI.WebControls.Label lbl_tidle = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_tidle") as System.Web.UI.WebControls.Label;
            lbl_tidle.Text = tidle.ToString();

            System.Web.UI.WebControls.Label lbl_tinactive = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_tinactive") as System.Web.UI.WebControls.Label;
            lbl_tinactive.Text = tinactive.ToString();

            System.Web.UI.WebControls.Label lbl_tabandoned = rptr_Inventory.Controls[rptr_Inventory.Controls.Count - 1].Controls[0].FindControl("lbl_tabandoned") as System.Web.UI.WebControls.Label;
            lbl_tabandoned.Text = tabandoned.ToString();

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
    public string GetColor(string a)
    {
        if (a == "Active")
        {
            return "text-warning";
        }
        if (a == "Inactive")
        {
            return "text-info";
        }
        if (a == "Abandoned")
        {
            return "text-danger";
        }
        return "text-success";
    }

    protected void rptr_Inventory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "total")
        {
            string[] args = e.CommandArgument.ToString().Split('|');
            objPRReq.ITID = int.Parse(args[0]);
            objPRReq.OID = 1;
            PRResp r = objPRIBC.getItemInventory4SerialNo(objPRReq);
            DataTable dt = r.GetTable;
            rptr_list.DataSource = dt;
            rptr_list.DataBind();
            heading.Text = "Item Type: " + args[1];
        }
        else if (e.CommandName == "active")
        {
            objPRReq.ItemName = e.CommandArgument.ToString();
            objPRReq.OID = 1;
            objPRReq.Status = "Active";
            PRResp r = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
            DataTable dt = r.GetTable;
            rptr_list.DataSource = dt;
            rptr_list.DataBind();
            heading.Text = "Item Type: " + objPRReq.ItemName + " , Status: Active";
        }
        else if (e.CommandName == "idle")
        {
            objPRReq.ItemName = e.CommandArgument.ToString();
            objPRReq.OID = 1;
            objPRReq.Status = "Idle";
            PRResp r = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
            DataTable dt = r.GetTable;
            rptr_list.DataSource = dt;
            rptr_list.DataBind();
            heading.Text = "Item Type: " + objPRReq.ItemName + " , Status: Idle";
        }
        else if (e.CommandName == "inactive")
        {
            objPRReq.ItemName = e.CommandArgument.ToString();
            objPRReq.OID = 1;
            objPRReq.Status = "Inactive";
            PRResp r = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
            DataTable dt = r.GetTable;
            rptr_list.DataSource = dt;
            rptr_list.DataBind();
            heading.Text = "Item Type: " + objPRReq.ItemName + " , Status: Inactive";
        }
        else if (e.CommandName == "abandoned")
        {
            objPRReq.ItemName = e.CommandArgument.ToString();
            objPRReq.OID = 1;
            objPRReq.Status = "Abandoned";
            PRResp r = objPRIBC.getAllItemInventory_ITemName_Status(objPRReq);
            DataTable dt = r.GetTable;
            rptr_list.DataSource = dt;
            rptr_list.DataBind();
            heading.Text = "Item Type: " + objPRReq.ItemName + " , Status: Abandoned";
        }
        else if(e.CommandName == "tstatus")
        {
            objPRReq.Status = e.CommandArgument.ToString();
            objPRReq.OID = 1;
            PRResp r = objPRIBC.getAvailableItemInventory(objPRReq);
            DataTable dt = r.GetTable;
            rptr_list.DataSource = dt;
            rptr_list.DataBind();
            heading.Text = "All Assets Status: " + objPRReq.Status;
        }
        else if(e.CommandName == "tall")
        {
            objPRReq.OID = 1;
            PRResp r = objPRIBC.getAllItemInventory(objPRReq);
            DataTable dt = r.GetTable;
            rptr_list.DataSource = dt;
            rptr_list.DataBind();
            heading.Text = "All Assets ";
        }
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "show();", true);
    }
}