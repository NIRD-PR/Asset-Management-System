using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

public partial class CICTInventory_DisposeAsset : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string name; int oid;
    string connectionString = ""; string strFileName="";
    string msg1 = "Please choose assets to be disposed from table above. Select the checkbox of desired assets and click on green button. The chosen assets will display in a table here.";
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "ChosenDropDown", "ChosenDropDown();", true);
        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "dt", "dt();", true);
        if (!IsPostBack)
        {
            isChoosen.Text = msg1;
            getAllItemsinInventory();
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
            Response.Redirect("~/CICTInventory/Default.aspx");
        }
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void getAllItemsinInventory()
    {
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getAllItemInventoryNotAbandoned(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "SerialNo Asc";
            rptr_InventoryData.DataSource = dt;
            rptr_InventoryData.DataBind();
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

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        List<int> s = new List<int>();
        foreach (RepeaterItem i in rptr_InventoryData.Items)
        {
            CheckBox c = i.FindControl("del") as CheckBox;
            if (c.Checked)
            {
                string iid = (i.FindControl("iid") as HiddenField).Value;
                s.Add(int.Parse(iid));
            }
        }

        if (s.Count < 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('Please choose an asset to dispose');", true);
            rptr_del.DataSource = null;
            rptr_del.DataBind();
            isChoosen.Text = msg1;
        }
        else
        {
            objPRReq.OID = 1;
            DataTable dTable = new DataTable();
            foreach(int i in s)
            {
                objPRReq.IID = i;
                PRResp r = objPRIBC.getItemInventory_IID(objPRReq);
                DataTable dt = r.GetTable;
                dTable.Merge(dt);
            }
            rptr_del.DataSource = dTable;
            rptr_del.DataBind();
            isChoosen.Text = "";
        }
    }

    protected void final_Click(object sender, EventArgs e)
    {
        try
        {
            HttpFileCollection uploadfile = Request.Files;
            string p1 = Server.MapPath("..\\Disposed\\");
            if (dispose.HasFile)
            {
                strFileName = DateTime.Now.ToFileTime() + "_" + dispose.FileName.ToString();
                dispose.SaveAs(p1 + strFileName);
            }
            if (rptr_del.Items.Count < 1)
            {
                throw new Exception("Please choose an asset to dispose");
            }
            if (remarks.Text.Length < 1)
            {
                throw new Exception("Please enter a remark");
            }
            if (sale.Text.Length > 0)
            {
                try
                {
                    objPRReq.APrice = double.Parse(sale.Text);
                }
                catch
                {
                    throw new Exception("Enter only numeric digits in Sale price field");
                }
                
            }
            objPRReq.Remarks = remarks.Text.Trim();
            objPRReq.FileName = strFileName;
            objPRReq.Status = "Abandoned";
            objPRReq.OID = 1;
            foreach (RepeaterItem i in rptr_del.Items)
            {
                string iid = (i.FindControl("iid") as HiddenField).Value;
                objPRReq.IID = int.Parse(iid);
                PRResp r = objPRIBC.EditItemInventoryDisposal(objPRReq);
            }
            string m = "Status of " + rptr_del.Items.Count + " assets successfully changed to abandoned.";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + m.ToString() + "'); window.open('../CIT_DelInv/{0}','_self');", true);
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg.ToString() + "');", true);
            return;
        }
    }
}