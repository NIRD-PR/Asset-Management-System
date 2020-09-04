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
public partial class CICTInventory_UpdateCITInventory_ExcelMapping : System.Web.UI.Page
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
            //string strFileName = upload_marks.PostedFile.FileName;
            string strFileType = System.IO.Path.GetExtension(DateTime.Now.ToFileTime() + "_" + fu_Excel.FileName.ToString()).ToString().ToLower();
            string path = p1 + strFileName;

            if (strFileType.Trim() == ".xls")
            {
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + path + ";" + "Extended Properties=Excel 8.0;";
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

            for (int i = 0; i < ds.Tables["myExcel"].Rows.Count; i++)
            {
                
                string empid = ds.Tables["myExcel"].Rows[i][1].ToString();
                objPRReq.EmpID = double.Parse(empid);
                string itid = ds.Tables["myExcel"].Rows[i][3].ToString();
                objPRReq.ITID = int.Parse(itid);
                string serial = ds.Tables["myExcel"].Rows[i][4].ToString();
                 roomno = ds.Tables["myExcel"].Rows[i][5].ToString();
                floor= ds.Tables["myExcel"].Rows[i][6].ToString();
                building = ds.Tables["myExcel"].Rows[i][7].ToString();
                location = roomno + ", " + floor + ", " + building;
                objPRReq.SerialNo = serial;
                objPRReq.OID = oid;
                objPRReq.Status = "Active";
                objPRReq.Dated = DateTime.Now;
                objPRReq.UID = int.Parse(hdn_EmpID.Value.Trim());
                objPRReq.UName = uname;
                objPRReq.Flag1 = 1;
                PRResp ir = objPRIBC.getItemInventory_ITID_SerialNo(objPRReq);
                DataTable dtir = ir.GetTable;
                if(dtir.Rows.Count>0)
                {
                    objPRReq.SerialNo = dtir.Rows[0]["SerialNo"].ToString();
                    objPRReq.ModelType = dtir.Rows[0]["Model"].ToString();
                    objPRReq.ItemType= dtir.Rows[0]["ItemType"].ToString();
                    objPRReq.Manufacturer = dtir.Rows[0]["Manufacturer"].ToString();
                    objPRReq.Warranty = dtir.Rows[0]["Warranty"].ToString();
                    objPRReq.ComputerNo = dtir.Rows[0]["ComputerNumber"].ToString();
                    objPRReq.ITID = int.Parse(dtir.Rows[0]["ITID"].ToString());
                    objPRReq.ItemName= dtir.Rows[0]["ItemName"].ToString();
                    objPRReq.Location = location;
                }

                PRResp er = objPRIBC.getEmployee_EmpID_DID(objPRReq);
                DataTable dtr = er.GetTable;
                if(dtr.Rows.Count>0)
                {
                    objPRReq.EmpID = int.Parse(dtr.Rows[0]["EmpID"].ToString());
                    objPRReq.Name = dtr.Rows[0]["Name"].ToString();
                    objPRReq.Design = dtr.Rows[0]["Design"].ToString();
                    objPRReq.DID = int.Parse(dtr.Rows[0]["DID"].ToString());
                    objPRReq.DeptID = dtr.Rows[0]["DeptID"].ToString();
                    objPRReq.Email = dtr.Rows[0]["Email"].ToString();
                    objPRReq.Mobile = double.Parse(dtr.Rows[0]["Mobile"].ToString());
                }

                PRResp rr = objPRIBC.getMappedInventory_SerialNo(objPRReq);
                DataTable dtrr = rr.GetTable;
                if (dtrr.Rows.Count > 0)
                {

                }
                else
                {
                    objPRIBC.MapITInventorytoEmp(objPRReq);
                }
            }
            string msg = ds.Tables["myExcel"].Rows.Count.ToString() + " of Records Updated Successfully"; ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg.ToString() + "');", true);
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + ex.ToString() + "');", true);
        }
    }
}