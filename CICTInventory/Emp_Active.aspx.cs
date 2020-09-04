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
public partial class Inventory_Emp_Active : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname; int oid, EmpID;
    protected void Page_Load(object sender, EventArgs e)
    {
        getAdminUser();
        if (!IsPostBack)
        {
            getEmpType();
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
    public void getEmpType()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getEmpGroups(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            ddl_EmpType.DataSource = dt;
            ddl_EmpType.DataTextField = "EmpGroup";
            ddl_EmpType.DataValueField = "EGID";
            ddl_EmpType.DataBind();
            ddl_EmpType.Items.Insert(0, "Select EmpType");
        }
    }

    protected void ddl_EmpGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        getAllEmp_EGID();
    }
    public void getAllEmp_EGID()
    {
        if(ddl_EmpType.SelectedIndex>0)
        {
            objPRReq.EGID = int.Parse(ddl_EmpType.SelectedValue.ToString());
            objPRReq.OID = oid;
            objPRReq.Flag1 = 1;
            lbl_EmpGroup.Text = ddl_EmpType.SelectedItem.Text.Trim();
            objPRReq.Status = "Active";
            if (ddl_EmpType.SelectedValue.ToString() != "3")
            {
                PRResp r = objPRIBC.getAllRegStaff_EGID_DID(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    rptr_Data.DataSource = dt;
                    rptr_Data.DataBind();
                    lbl_Count.Text = "No.of Employees Listed :" + dt.Rows.Count.ToString();
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        ImageMap Img_Photo = rptr_Data.Items[k].FindControl("Album_Image") as ImageMap;
                        Label newempid = rptr_Data.Items[k].FindControl("lbl_NewEmpID") as Label;
                        Label regattId = rptr_Data.Items[k].FindControl("lbl_RegAttID") as Label;
                       
                        objPRReq.EmpID = int.Parse(dt.Rows[k]["EmpID"].ToString());
                        newempid.Text = dt.Rows[k]["EmpID"].ToString();
                        PRResp rat = objPRIBC.getBioMetric_EmpID_AttID(objPRReq);
                        DataTable dtrat = rat.GetTable;
                        if(dtrat.Rows.Count>0)
                        {
                            string attid = dtrat.Rows[0]["AttendanceID"].ToString();
                            int cou = attid.Length;
                            if (cou <= 8)
                            {
                                if (cou == 8)
                                {
                                    regattId.Text = attid;
                                }
                                else
                                if (cou == 7)
                                {
                                    regattId.Text = "0" + attid;
                                }
                                else if (cou == 6)
                                {
                                    regattId.Text = "00" + attid;
                                }
                                else if (cou == 5)
                                {
                                    regattId.Text = "000" + attid;
                                }

                            }
                        }
                                                               

                        PRResp re = objPRIBC.getEmpDetails_EmpID(objPRReq);
                        DataTable dte = re.GetTable;
                        if (dte.Rows.Count > 0)
                        {
                            if (File.Exists(Server.MapPath("../SPhotos/" + dte.Rows[0]["Photo"].ToString()))) //It passes this condition 
                            {
                                Img_Photo.ImageUrl = "~/SPhotos/" + dte.Rows[0]["Photo"].ToString();
                            }
                            else
                            {
                                Img_Photo.ImageUrl = "~/SPhotos/user.png";
                            }
                        }
                    }
                }
            }
            else
            {
                PRResp rp = objPRIBC.getAllProjStaff_EGID(objPRReq);
                DataTable dtp = rp.GetTable;
                if (dtp.Rows.Count > 0)
                {
                    rptr_Data.DataSource = dtp;
                    rptr_Data.DataBind();
                    lbl_Count.Text = "No.of Project Staff Listed :" + dtp.Rows.Count.ToString();
                    for (int k = 0; k < dtp.Rows.Count; k++)
                    {
                        ImageMap Img_Photo = rptr_Data.Items[k].FindControl("Album_Image") as ImageMap;
                        Label att = rptr_Data.Items[k].FindControl("lbl_AttID") as Label;
                        string attid = dtp.Rows[k]["AttendanceID"].ToString();
                        int cou = attid.Length;
                        if(cou<=8)
                        {
                            if (cou == 8)
                            {
                                att.Text = attid;
                            }
                            else
                            if (cou==7)
                            {
                                att.Text = "0" + attid;
                            }
                            else if (cou == 6)
                            {
                                att.Text = "00" + attid;
                            }
                            else if (cou == 5)
                            {
                                att.Text = "000" + attid;
                            }
                            
                        }
                        Label newempid = rptr_Data.Items[k].FindControl("lbl_NewEmpID") as Label;
                        newempid.Text = dtp.Rows[k]["EmpID"].ToString();
                        DateTime ddor = DateTime.Parse(dtp.Rows[k]["DOR"].ToString());
                        
                        objPRReq.EmpID = int.Parse(dtp.Rows[k]["EmpID"].ToString());
                        PRResp rep = objPRIBC.getPSEmpDetails_EmpID(objPRReq);
                        DataTable dtep = rep.GetTable;
                        if (dtep.Rows.Count > 0)
                        {
                            if (File.Exists(Server.MapPath("../SPhotos/" + dtep.Rows[0]["Photo"].ToString()))) //It passes this condition 
                            {
                                Img_Photo.ImageUrl = "~/SPhotos/" + dtep.Rows[0]["Photo"].ToString();
                            }
                            else
                            {
                                Img_Photo.ImageUrl = "~/SPhotos/user.png";
                            }
                        }
                    }
                }
            }
        }
    }
    protected void rptr_Data_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "Block")
        {
            objPRReq.OID = oid;            
            objPRReq.EmpID = double.Parse(e.CommandArgument.ToString());
            objPRReq.EGID = int.Parse(ddl_EmpType.SelectedValue.ToString());
            if(ddl_EmpType.SelectedValue.ToString()!="3")
            {
                objPRReq.Status = "Blocked";
                objPRIBC.BlockRegStaffBy_EmpID(objPRReq);
                objPRIBC.BlockRegStaff_SalBy_EmpID(objPRReq);
            }
            else
            {
                objPRReq.Status = "Blocked";
                objPRIBC.BlockProjStaffBy_EmpID(objPRReq);
                objPRIBC.BlockProjStaffCLsBy_EmpID(objPRReq);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Employee Blocked Successfully..!!!'); window.open('../Admin_ActS/{0}','_self');", true);
        }
        if(e.CommandName=="Delete")
        {

        }
        if (e.CommandName == "Print")
        {

        }
    }
}