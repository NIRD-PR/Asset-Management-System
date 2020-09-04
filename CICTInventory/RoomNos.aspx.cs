using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CITInventory_RoomNos : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string name; int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        if (!IsPostBack)
        {
            getLocations();
            getFloorTypes();
            if (Request.QueryString["st"] != null)
            {
                hdn_RMID.Value = Request.QueryString["st"].ToString();
                Update();
            }
            getAllRoomNos();
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
            Response.Redirect("~/Default.aspx");
        }
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void Update()
    {
        objPRReq.RMID = int.Parse(hdn_RMID.Value);
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getRoomNoByRMID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            lbl_Floor.Text = dt.Rows[0]["Floor"].ToString();
            lbl_Location.Text = dt.Rows[0]["Location"].ToString();
            lbl_RoomNo.Text = dt.Rows[0]["RoomNo"].ToString();
            btn_Submit.Text = "Update";
        }
    }
    public void getLocations()
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
            ddl_Location.Items.Insert(0, "---Select---");
        }
    }

    public void getFloorTypes()
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
            ddl_Floor.Items.Insert(0, "---Select---");
        }
    }
    
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.Status = "Active";
            objPRReq.OID = oid;
            objPRReq.RoomNo = convertQuotes(txt_RoomNo.Text.Trim());
            if (ddl_Location.SelectedIndex > 0)
            {
                objPRReq.LID = int.Parse(ddl_Location.SelectedValue.ToString());
                objPRReq.Location = ddl_Location.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Location";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (ddl_Floor.SelectedIndex>0)
            {
                objPRReq.FLID = int.Parse(ddl_Floor.SelectedValue.ToString());
                objPRReq.Floor = ddl_Floor.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Select Floor..";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (btn_Submit.Text != "Update")
            {
                PRResp r = objPRIBC.getRoomNoByName(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string msg = "Location Name: " + txt_RoomNo.Text.Trim() + " already registered..!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
                else
                {
                    objPRIBC.AddRoomNos(objPRReq);
                    string msg = txt_RoomNo.Text.Trim() + " Registered Successfully...!!!";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                    getAllRoomNos();
                    txt_RoomNo.Text = "";
                }
            }
            else
            {
                objPRReq.RMID = int.Parse(Request.QueryString["st"].ToString());
                objPRIBC.EditRoomNoByRMID(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + txt_RoomNo.Text + " Updated Successfully..!!!'); window.open('../CIT_Rooms/{0}','_self');", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('" + ex.ToString() + "')",true);
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
            rptr_Data.DataSource = dt;
            rptr_Data.DataBind();
            lbl_Count.Text = "No.of Rooms Listed :" + dt.Rows.Count.ToString();
        }
    }
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_Rooms/{0}?st=" + e.CommandArgument.ToString());
        }

        if (e.CommandName == "Delete")
        {
            objPRReq.OID = oid;
            objPRReq.RMID = int.Parse(e.CommandArgument.ToString());
            objPRIBC.DelRoomNo(objPRReq);
            string msg = "Deleted Successfully...!!!";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            getAllRoomNos();
        }
    }
}