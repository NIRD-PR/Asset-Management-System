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
using System.Text.RegularExpressions;
public partial class CITStaff_CITSSHome : System.Web.UI.Page
{PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid;
    DataTable dtrow,dtcol;
    int k = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        getCITUser();
        if (!IsPostBack)
        {
            
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
    public void getUEmp_TicketDetails()
    {
        if (txt_FromDate.Text != "" && txt_ToDate.Text != "")
        {
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            objPRReq.Flag1 = 1;
            objPRReq.Flag2 =1;
            objPRReq.UEmpID = int.Parse(hdn_EmpID.Value);

            objPRReq.StartDate = DateTime.ParseExact(txt_FromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            objPRReq.EndDate = DateTime.ParseExact(txt_ToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Rows Data
            PRResp r = objPRIBC.getCIT_eTicket_Dashboard_rows_UEmpID(objPRReq);
            dtrow = r.GetTable;
            //Cols Data
            PRResp rc = objPRIBC.getCIT_eTicket_Dashboard_cols_UEmpID(objPRReq);
            dtcol = rc.GetTable;
            if (dtrow.Rows.Count > 0)
            {
                gv_Tickets.DataSource = FlipDataSet(c());
                gv_Tickets.DataBind();
                lbl_NoData.Text = "";
                lbl_NoData.Visible = false;
            }
            else
            {
                DataTable dtnull = null;
                gv_Tickets.DataSource = dtnull;
                gv_Tickets.DataBind();
                lbl_NoData.Visible = true;
                lbl_NoData.Text = " No Data found Between Selected Dates ";
            }
        }
    }

    public DataSet c()
    {
        DataSet ds = new DataSet();
        DataTable dttr = new DataTable("dashboard");
        DataRow dr;
        dttr.Columns.Add(new DataColumn("Items/Dates", typeof(string)));
        for (int j = 0; j < dtrow.Rows.Count; j++)
        {
            dttr.Columns.Add(new DataColumn(dtrow.Rows[j]["ItemName"].ToString(), typeof(string)));             
        }
        dttr.Columns.Add(new DataColumn("Grand Total", typeof(string))); 
        for (int i = 0; i < dtcol.Rows.Count; i++)
        {
            dr = dttr.NewRow();
            DateTime dob = DateTime.Parse(dtcol.Rows[i]["Dated"].ToString());
            dr[0] = dob.ToString("dd/MM/yyyy");
            DateTime dats = DateTime.Parse(dtcol.Rows[i]["Dated"].ToString());
            objPRReq.Dated = dats;
            for (k = 0; k < dtrow.Rows.Count; k++)
            {
                objPRReq.ITID = int.Parse(dtrow.Rows[k]["ITID"].ToString());
                PRResp rc = objPRIBC.getCIT_eTicket_Dashboard_colsCount_UEmpID_ITID(objPRReq);
                DataTable dtc = rc.GetTable;
                if (dtc.Rows.Count > 0)
                {
                    dr[k+1] = dtc.Rows[0]["ITID"].ToString();
                }

                PRResp rs = objPRIBC.getCIT_eTicket_Dashboard_colsSum_UEmpID_ITID(objPRReq);
                DataTable dts = rs.GetTable;
                if (dts.Rows.Count > 0)
                {
                    dr[dtrow.Rows.Count+1] = dts.Rows[0]["count"].ToString();
                }
            }
            dttr.Rows.Add(dr);
        }
        ds.Tables.Add(dttr);
        return ds;
    }
    public DataSet FlipDataSet(DataSet my_DataSet)
    {
        DataSet ds = new DataSet();
        foreach (DataTable dt in my_DataSet.Tables)
        {
            DataTable table = new DataTable();
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }
            DataRow r = null;
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                r = table.NewRow();
                r[0] = dt.Columns[k].ToString();
                for (int j = 1; j <= dt.Rows.Count; j++)
                    r[j] = dt.Rows[j - 1][k];
                table.Rows.Add(r);
            }
            ds.Tables.Add(table);
        }

        return ds;
    }
    protected void gv_Tickets_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == 0)
        {
            e.Row.Style.Add("height", "25px");
            e.Row.Style.Add("Background", "#E9B0FC");
            e.Row.Style.Add("color", "#fff");
            e.Row.Cells[0].Style.Add("text-align", "Center");
        }
        if (e.Row.RowIndex == dtrow.Rows.Count + 1)
        {
            e.Row.Style.Add("height", "25px");
            e.Row.Style.Add("Background", "#FFE8E8");
        }
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[0].Style.Add("Background", "#95B3E5");
            e.Row.Cells[0].Style.Add("text-align", "Left");
        }

    }
    protected void btn_GetDetails_Click(object sender, EventArgs e)
    {
        getUEmp_TicketDetails();
    }
}