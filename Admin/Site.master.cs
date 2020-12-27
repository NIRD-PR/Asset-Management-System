using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class Site : System.Web.UI.MasterPage
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid = 1,count=0;
    string email, pwd, smsapi;
    protected void Page_Load(object sender, EventArgs e)
    {
	   //lbl_Count.Text = Application["NoOfVisitors"].ToString();
       if (!IsPostBack)
       {
            getTodayBDays();
        }
    }
    public void getTodayBDays()
    {
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        objPRReq.DOB = DateTime.Today;
       // PRResp r = objPRIBC.getAllTodaysREmpBDays(objPRReq);
        //DataTable dt = r.GetTable;
        //if (dt.Rows.Count > 0)
        //{
        ////    for (int i = 0; i < dt.Rows.Count; i++)
        ////    {
        ////        string bday = dt.Rows[i]["DOB"].ToString();
        ////        string today = DateTime.Today.ToString("M/d/yyyy") + " 12:00:00 AM";
        ////        if (today == bday)
        ////        {
        ////            count += 1;
        ////        }                
        ////    }
        //    lbl_BDays.Text = dt.Rows.Count.ToString();
        //}
    }
}
