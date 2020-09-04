using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITStaff_BookATicket : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getCITUser();
        if (!IsPostBack)
        {
            getAllLocations();
            getAllFloors();
            getAllRoomNos();
            getAllItemTypes();
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
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void getAllItemTypes()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getItemTypes(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "ItemType Asc";
            ddl_ItemType.DataSource = dt;
            ddl_ItemType.DataTextField = "ItemType";
            ddl_ItemType.DataValueField = "ITID";
            ddl_ItemType.DataBind();
            ddl_ItemType.Items.Insert(0, "Select Type");
        }
    }
    public void getAllLocations()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getLocation(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "Location Asc";
            ddl_Location.DataSource = dt;
            ddl_Location.DataTextField = "Location";
            ddl_Location.DataValueField = "LID";
            ddl_Location.DataBind();
            ddl_Location.Items.Insert(0, "--Select Location--");
        }
    }

    public void getAllFloors()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getFloors(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "Floor Asc";
            ddl_Floor.DataSource = dt;
            ddl_Floor.DataTextField = "Floor";
            ddl_Floor.DataValueField = "FLID";
            ddl_Floor.DataBind();
            ddl_Floor.Items.Insert(0, "--Select Floor--");

        }
    }
    public void getAllRoomNos()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getRoomNos(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "RoomNo Asc";
            ddl_RoomNo.DataSource = dt;
            ddl_RoomNo.DataTextField = "RoomNo";
            ddl_RoomNo.DataValueField = "RMID";
            ddl_RoomNo.DataBind();
            ddl_RoomNo.Items.Insert(0, "--Select Room No--");
        }
    }
    public void getAllStaffNames()
    {
        if (txt_Name.Text != "")
        {
            objPRReq.Name = txt_Name.Text.Trim().Replace("'", "");
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            PRResp r = objPRIBC.SearchAllStaffNames_Regular_PS(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                dt.DefaultView.Sort = "Name Asc";
                ddl_EmpName.DataSource = dt;
                ddl_EmpName.DataTextField = "Name";
                ddl_EmpName.DataValueField = "EmpID";
                ddl_EmpName.DataBind();
                ddl_EmpName.Items.Insert(0, "--Select Name--");
                lbl_NameCount.Text = "* " + dt.Rows.Count.ToString();
            }
            else
            {
                ddl_EmpName.Items.Insert(0, "--No Data Found--");
                ddl_EmpName.DataBind();
            }
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.EmpID = int.Parse(hdn_EEmpID.Value.Trim());
            objPRReq.Name = hdn_EEmpName.Value.Trim();
            objPRReq.Email = hdn_Email.Value.Trim();
            objPRReq.Mobile = double.Parse(hdn_Mobile.Value.Trim());
            objPRReq.DID = int.Parse(hdn_DID.Value.Trim());
            objPRReq.DeptID = hdn_DeptID.Value.Trim();
            objPRReq.Design = hdn_Design.Value.Trim();
            objPRReq.Dated = DateTime.Now;
            objPRReq.Status = "Active";
            objPRReq.Flag1 = 0;
            objPRReq.Flag2 = 0;
            objPRReq.Flag3 = 0;
            objPRReq.Flag4 = 0;
            IncrementId();

            if (int.Parse(hdn_TNO.Value.Trim()) < 10)
            {
                hdn_TicketNo.Value = DateTime.Now.ToString("yy") + "00000" + int.Parse(hdn_TNO.Value.Trim());
                objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value.Trim());
            }
            else if (int.Parse(hdn_TNO.Value.Trim()) < 100)
            {
                hdn_TicketNo.Value = DateTime.Now.ToString("yy") + "0000" + int.Parse(hdn_TNO.Value.Trim());
                objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value.Trim());
            }
            else if (int.Parse(hdn_TNO.Value.Trim()) < 1000)
            {
                hdn_TicketNo.Value = DateTime.Now.ToString("yy") + "000" + int.Parse(hdn_TNO.Value.Trim());
                objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value.Trim());
            }
            else if (int.Parse(hdn_TNO.Value.Trim()) < 10000)
            {
                hdn_TicketNo.Value = DateTime.Now.ToString("yy") + "00" + int.Parse(hdn_TNO.Value.Trim());
                objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value.Trim());
            }
            else if (int.Parse(hdn_TNO.Value.Trim()) < 100000)
            {
                hdn_TicketNo.Value = DateTime.Now.ToString("yy") + "0" + int.Parse(hdn_TNO.Value.Trim());
                objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value.Trim());
            }
            else if (int.Parse(hdn_TNO.Value.Trim()) < 1000000)
            {
                hdn_TicketNo.Value = DateTime.Now.ToString("yy") + int.Parse(hdn_TNO.Value.Trim());
                objPRReq.TicketNo = double.Parse(hdn_TicketNo.Value.Trim());
            }

            if (ddl_Location.SelectedIndex > 0)
            {
                objPRReq.LID = int.Parse(ddl_Location.SelectedValue.ToString());
                objPRReq.Location = ddl_Location.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Your Location";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (ddl_Floor.SelectedIndex > 0)
            {
                objPRReq.FLID = int.Parse(ddl_Floor.SelectedValue.ToString());
                objPRReq.Floor = ddl_Floor.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Floor";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (ddl_RoomNo.SelectedIndex > 0)
            {
                objPRReq.RMID = int.Parse(ddl_RoomNo.SelectedValue.ToString());
                objPRReq.RoomNo = ddl_RoomNo.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Room No";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (txt_AvailableTime.Text != "")
            {
                objPRReq.AvailableTime = convertQuotes(txt_AvailableTime.Text.Trim());
            }
            else
            {
                string msg = "Enter Available Days and Time to Resolve your problem by Supporiting Engineer..";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (ddl_ItemType.SelectedIndex > 0)
            {
                objPRReq.ITID = int.Parse(ddl_ItemType.SelectedValue.ToString());
                objPRReq.ItemName = ddl_ItemType.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Problem with the Device / Application";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (txt_ProblemDescription.Text.Trim() != "")
            {
                objPRReq.ProblemDescription = convertQuotes(txt_ProblemDescription.Text.Trim());
            }
            else
            {
                string msg = "Enter Problem Description";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            PRResp r = objPRIBC.getCIT_eTicket(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                string msg = "This Problem is Already Registered with us, The Registered Ticket No" + dt.Rows[0]["TicketNo"].ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            }
            else
            {
                objPRIBC.RegisterCIT_eTicket(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Ticket Submitted Successfully..!!!'); window.open('../CITSS_CP/{0}','_self');", true);
            }
            string msg1 = "Your Registered Ticket No" + hdn_TicketNo.Value; ;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg1 + "');", true);
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }
    }

    int val = 0;
    public void IncrementId()
    {
        try
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.ColumnName = "TID";
            PRResp qno = objPRIBC.getTID(objPRReq);

            if (qno.SingleValue.ToString().Trim() == "")
            {
                hdn_TNO.Value = "1";
                val = int.Parse(hdn_TNO.Value.Trim());
            }
            else
            {
                val = int.Parse(qno.SingleValue.ToString().Trim());
                hdn_TNO.Value = (val + 1).ToString();
            }
            val += 1;
        }
        catch (NullReferenceException)
        {
            hdn_TNO.Value = "1";
        }
        catch (Exception ex)
        {
            hdn_TNO.Value = "Error...";
        }
    }
    protected void txt_Name_TextChanged(object sender, EventArgs e)
    {
        getAllStaffNames();
    }
    protected void ddl_EmpName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_EmpName.SelectedIndex > 0)
        {
            objPRReq.EmpID = int.Parse(ddl_EmpName.SelectedValue.ToString());
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            PRResp r = objPRIBC.getAllStaffNames_Regular_PS_EmpID(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                hdn_DeptID.Value = dt.Rows[0]["DeptID"].ToString();
                hdn_DID.Value = dt.Rows[0]["DID"].ToString();
                hdn_Email.Value = dt.Rows[0]["Email"].ToString();
                hdn_EEmpID.Value = dt.Rows[0]["EmpID"].ToString();
                hdn_EEmpName.Value = dt.Rows[0]["Name"].ToString();
                hdn_Design.Value = dt.Rows[0]["Design"].ToString();
                hdn_Mobile.Value = dt.Rows[0]["Mobile"].ToString();
            }
            else
            {
                hdn_DeptID.Value = dt.Rows[0]["DeptID"].ToString();
                hdn_DID.Value = dt.Rows[0]["DID"].ToString();
                hdn_Email.Value = dt.Rows[0]["Email"].ToString();
                hdn_EEmpID.Value = dt.Rows[0]["EmpID"].ToString();
                hdn_EEmpName.Value = dt.Rows[0]["Name"].ToString();
                hdn_Design.Value = dt.Rows[0]["Design"].ToString();
                hdn_Mobile.Value = dt.Rows[0]["Mobile"].ToString();
            }
        }
    }
}