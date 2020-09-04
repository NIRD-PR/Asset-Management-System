using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using NIRDPR.RK.PRReferences;
using System.Data;
public class StoreStockBackup : Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
	public StoreStockBackup()
	{

	}
    public static void DoClosingStockBackup()
    {
        StoreStockBackup c = new StoreStockBackup();
        c.getDetails();
    }
    protected void getDetails()
    {
        var now = DateTime.Now;
        var startOfMonth = new DateTime(now.Year, now.Month, 1);
        var DaysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
        var lastDay = new DateTime(now.Year, now.Month, DaysInMonth);
        if (lastDay == DateTime.Today)
        {
            DateTime tme = DateTime.Now;
            string time = tme.ToString("T");
            if (time == "7:05:10 AM")
            {
                string mon = DateTime.Now.ToString("MMMMMMMMMMMMMMMM");
                string year = DateTime.Now.Year.ToString();
                objPRReq.Status = "Active";
                objPRReq.OID = 1;
                PRResp r = objPRIBC.getStoreClosingStock(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objPRReq.MonthYear = mon + ", " + year;
                        objPRReq.STID = int.Parse(dt.Rows[i]["STID"].ToString());
                        objPRReq.OID = int.Parse(dt.Rows[i]["OID"].ToString());
                        objPRReq.VID = int.Parse(dt.Rows[i]["VID"].ToString());
                        objPRReq.Vendor = dt.Rows[i]["Vendor"].ToString();
                        objPRReq.InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString();
                        objPRReq.ICID = int.Parse(dt.Rows[i]["ICID"].ToString());
                        objPRReq.ItemCategory = dt.Rows[i]["ItemCategory"].ToString();
                        objPRReq.ITID = int.Parse(dt.Rows[i]["ITID"].ToString());
                        objPRReq.ItemName = dt.Rows[i]["ItemName"].ToString();
                        objPRReq.ItemType = dt.Rows[i]["ItemType"].ToString();
                        objPRReq.FileNo = dt.Rows[i]["FileNo"].ToString();
                        objPRReq.BatchNo = dt.Rows[i]["BatchNo"].ToString();
                        objPRReq.Quantity = double.Parse(dt.Rows[i]["Quantity"].ToString());
                        objPRReq.Rate = double.Parse(dt.Rows[i]["Rate"].ToString());
                        objPRReq.UnitCost = double.Parse(dt.Rows[i]["UnitCost"].ToString());
                        objPRReq.MinQty = double.Parse(dt.Rows[i]["MinQty"].ToString());
                        objPRReq.Status = "Active";
                        objPRReq.UID = int.Parse(dt.Rows[i]["UID"].ToString());
                        objPRReq.UName = dt.Rows[i]["UName"].ToString();
                        objPRReq.Dated = DateTime.Now;

                        PRResp ri = objPRIBC.getStockMonthlyClosing(objPRReq);
                        DataTable dti = ri.GetTable;
                        if (dti.Rows.Count > 0)
                        {
                        }
                        else
                        {
                            objPRIBC.AddStockMonthlyClosing(objPRReq);
                        }
                    }
                }
            }
        }
    }
}