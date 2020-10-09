using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.Globalization;

public partial class CICTInventory_ConsolidatedInventory : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    int oid; string uname;
    Dictionary<string, string> map = new Dictionary<string, string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        map.Clear();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ChosenDropDown", "ChosenDropDown();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
        if (!IsPostBack)
        {
            getAllFY();
            getItems();
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
    protected void getItems()
    {
        objPRReq.OID = oid;
        if (start.Text == "" && end.Text == "" && ddl_fy.SelectedIndex == 0)
        {
            PRResp resp = objPRIBC.getAllItemInventoryNotAbandoned(objPRReq);
            DataTable dt = resp.GetTable;
            rptr_Inventory.DataSource = dt;
            rptr_Inventory.DataBind();
            stdate.Text = new DateTime(2000, 1, 1).ToString("dd/MM/yyyy");
            enddate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            try
            {
                objPRReq.StartDate = DateTime.ParseExact(start.Text, "dd/MM/yyyy", null);
                objPRReq.EndDate = DateTime.ParseExact(end.Text, "dd/MM/yyyy", null);
                PRResp resp = objPRIBC.getAllItemInventoryNotAbandonedByDate(objPRReq);
                DataTable dt = resp.GetTable;
                rptr_Inventory.DataSource = dt;
                rptr_Inventory.DataBind();
                stdate.Text = start.Text;
                enddate.Text = end.Text;
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg.ToString() + "');", true);
            }
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        getItems();
    }
    public void getAllFY()
    {
        DateTime start = new DateTime(2010, 1, 1);
        DateTime end = DateTime.Now;
        DateTime temp = start;
        CultureInfo culture = new CultureInfo("pt-BR");
        while (temp.Year != end.Year)
        {
            string next = (temp.Year + 1).ToString();
            string fy = "FY " + temp.Year + "-" + next[2] + next[3];
            DateTime date1 = new DateTime(temp.Year, 4, 1);
            DateTime date2 = new DateTime(temp.Year + 1, 3, 31);
            string d1 = date1.ToString("d", culture);
            string d2 = date2.ToString("d", culture);
            map.Add(fy, d1 + "|" + d2);
            ddl_fy.Items.Insert(0, fy);
            temp = temp.AddYears(1);
        }
        if (end.Month > 3)
        {
            string next = (temp.Year + 1).ToString();
            string fy = "FY " + temp.Year + "-" + next[2] + next[3];
            DateTime date1 = new DateTime(temp.Year, 4, 1);
            DateTime date2 = new DateTime(temp.Year + 1, 3, 31);
            string d1 = date1.ToString("d", culture);
            string d2 = date2.ToString("d", culture);
            map.Add(fy, d1 + "|" + d2);
            ddl_fy.Items.Insert(0, fy);
        }
        ddl_fy.Items.Insert(0, "---Select a Fiscal Year---");
    }

    protected void ddl_fy_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idx = ddl_fy.SelectedIndex;
        ddl_fy.Items.Clear();
        getAllFY();
        ddl_fy.SelectedIndex = idx;
        if (ddl_fy.SelectedIndex > 0)
        {
            string[] s = map[ddl_fy.SelectedValue].ToString().Split('|');
            start.Text = s[0];
            end.Text = s[1];
        }
    }

    protected void rptr_Inventory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Response.ContentType = "Application/text";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + e.CommandArgument.ToString());
        Response.TransmitFile(Server.MapPath("..\\Disposed\\" + e.CommandArgument.ToString()));
        Response.End();
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
}