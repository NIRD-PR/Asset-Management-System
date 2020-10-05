using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Windows.Forms;
public partial class CICTInventory_AddInventoryBulk : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid; string connectionString = ""; string strFileName;
    string location, roomno, floor, building;
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Excel"] = "";
        getAdminUser();
        if (!IsPostBack)
        {
        }
    }
    public void getAdminUser()
    {
        if (Session["UserID"].ToString() != "")
        {
            objPRReq.Status = "Active";
            objPRReq.UID = int.Parse(Session["UserID"].ToString());
            objPRReq.Now = DateTime.Parse(DateTime.Now.ToShortDateString());
            PRResp resp = objPRIBC.getAdminData(objPRReq);
            DataTable dt = resp.GetTable;
            if (dt.Rows.Count > 0)
            {
                oid = int.Parse(dt.Rows[0]["OID"].ToString());
                uname = dt.Rows[0]["Name"].ToString();
                hdn_EmpID.Value = dt.Rows[0]["EmpID"].ToString();
            }
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
    }


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {

            HttpFileCollection uploadFilCol = Request.Files;
            string excelFile = ViewState["Excel"].ToString();
            string p1 = Server.MapPath("..\\Files\\");
            if (fu_Excel.HasFile)
            {
                strFileName = DateTime.Now.ToFileTime() + "_" + fu_Excel.FileName.ToString();
                fu_Excel.SaveAs(p1 + strFileName);
            }
            string strFileType = System.IO.Path.GetExtension(DateTime.Now.ToFileTime() + "_" + fu_Excel.FileName.ToString()).ToString().ToLower();
            string path = p1 + strFileName;

            if (strFileType.Trim() == ".xls")
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + "Extended Properties=\"Excel 8.0; HDR=YES\";";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Persist Security Info=False; Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
            }

            OleDbConnection objConn = new OleDbConnection(connectionString);
            objConn.Open();
            String strConString = "SELECT * FROM [Sheet1$]";
            OleDbCommand objCmdSelect = new OleDbCommand(strConString, objConn);
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = objCmdSelect;
            DataSet ds = new DataSet();
            da.Fill(ds, "myExcel");
            int total = 0;
            for (int i = 0; i < ds.Tables["myExcel"].Rows.Count; i++)
            {
                objPRReq.ItemName = ds.Tables["myExcel"].Rows[i][0].ToString();
                objPRReq.ItemType = objPRReq.ItemName;
                int quantity;
                try
                {
                    quantity = int.Parse(ds.Tables["myExcel"].Rows[i][1].ToString());
                }
                catch
                {
                    throw new System.Exception("Check Quantity column");
                }
                if (quantity < 1)
                {
                    throw new System.Exception("Please enter a quantity greater than 0");
                }
                objPRReq.OID = 1;
                objPRReq.Status = "Active";
                PRResp r = objPRIBC.getItemTypeByName(objPRReq);
                DataTable dt = r.GetTable;
                if(dt.Rows.Count < 1)
                {
                    throw new System.Exception("Please enter a valid item category");
                }
                objPRReq.ITID = int.Parse(dt.Rows[0]["ITID"].ToString());
                objPRReq.DOP = ds.Tables["myExcel"].Rows[i][2].ToString();
                if (objPRReq.DOP == "")
                {
                    throw new System.Exception("Please enter a Date of Purchase");
                }
                objPRReq.InvoiceNumber = ds.Tables["myExcel"].Rows[i][3].ToString();
                objPRReq.APrice = double.Parse(ds.Tables["myExcel"].Rows[i][4].ToString());
                objPRReq.ModelType = ds.Tables["myExcel"].Rows[i][5].ToString();
                if (objPRReq.ModelType == "")
                {
                    throw new System.Exception("Please enter a Model");
                }
                objPRReq.Manufacturer = ds.Tables["myExcel"].Rows[i][6].ToString();
                if (objPRReq.Manufacturer == "")
                {
                    throw new System.Exception("Please enter a Manufacturer");
                }
                string[] serialnos = ds.Tables["myExcel"].Rows[i][7].ToString().Split(',');
                if(serialnos.Length != quantity)
                {
                    throw new System.Exception("Please enter " + quantity + "(quantity written) serial nos. separated by commas (,)");
                }
                objPRReq.ComputerNo = ds.Tables["myExcel"].Rows[i][8].ToString();
                objPRReq.Warranty = ds.Tables["myExcel"].Rows[i][9].ToString();
                objPRReq.WarrantyDate = ds.Tables["myExcel"].Rows[i][10].ToString();
                objPRReq.Vendor = ds.Tables["myExcel"].Rows[i][11].ToString();
                if (objPRReq.Warranty == "")
                {
                    objPRReq.Warranty = "No Warranty / No AMC";
                }
                objPRReq.Dated = DateTime.Now;
                objPRReq.UID = int.Parse(hdn_EmpID.Value.Trim());
                objPRReq.UName = uname;
                total += serialnos.Length;
                for(int j = 0; j < serialnos.Length; j++)
                {
                    objPRReq.Status = "Idle";
                    objPRReq.ItemType = "New";
                    objPRReq.SerialNo = serialnos[j];
                    PRResp ir = objPRIBC.AddItemInventory(objPRReq);
                }
            }
            total += ds.Tables["myExcel"].Rows.Count;
            string msg = total + " of Records Updated Successfully"; ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg.ToString() + "');", true);
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg.ToString() + "');", true);
        }
    }

    protected void download_Click(object sender, EventArgs e)
    {
        Response.ContentType = "Application/x-msexcel";
        Response.AppendHeader("Content-Disposition", "attachment; filename=AddInventory_Format.xlsx");
        Response.TransmitFile(Server.MapPath("..\\CICTInventory\\AddInventory_Format.xlsx"));
        Response.End();
    }
}