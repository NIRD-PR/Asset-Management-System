using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
using System.IO;
using System.Text;
using System.Globalization;
public partial class GovMailRequestForm : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    int oid = 1;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            getEmpType();
            getDepartmentIDs();
        }
    }
    public void getEmpType()
    {
        ddl_EmpType.Items.Insert(0, "Select Type");
        ddl_EmpType.Items.Insert(1, "Regular Staff");
        ddl_EmpType.Items.Insert(2, "Deputation Staff");
        ddl_EmpType.Items.Insert(3, "Project Staff");
        ddl_EmpType.Items.Insert(4, "Consultant");
        ddl_EmpType.DataBind();
    }
    public void getDepartmentIDs()
    {
        objPRReq.Status = "Active";
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getDepartments(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            dt.DefaultView.Sort = "DeptID Asc";
            ddl_Dept.DataSource = dt;
            ddl_Dept.DataTextField = "DeptID";
            ddl_Dept.DataValueField = "DID";
            ddl_Dept.DataBind();
            ddl_Dept.Items.Insert(0, "Select Department");
        }
    }
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    protected void btn_Send_Click(object sender, EventArgs e)
    {
        try
        {
            objPRReq.Dated = DateTime.Now;
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            if (ddl_EmpType.SelectedIndex > 0)
            {
                objPRReq.EmpType = ddl_EmpType.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Please Select Employee Type";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (ddl_Dept.SelectedIndex > 0)
            {
                objPRReq.DID = int.Parse(ddl_Dept.SelectedValue.ToString());
                objPRReq.DeptID = ddl_Dept.SelectedItem.Text.Trim();
            }
            else
            {
                string msg = "Please Select Department";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (txt_Name.Text != "")
            {
                objPRReq.Name = convertQuotes(txt_Name.Text.Trim());
            }
            else
            {
                string msg = "Please Enter Name";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (txt_Email.Text != "")
            {
                objPRReq.Email = convertQuotes(txt_Email.Text.Trim());
            }
            else
            {
                string msg = "Please Email";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if(txt_Mobile.Text!="")
            {
                objPRReq.Mobile = double.Parse(txt_Mobile.Text.Trim());
            }
            else
            {
                string msg = "Please Enter Mobile";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (txt_EmpID.Text != "")
            {
                objPRReq.EmpID = int.Parse(txt_EmpID.Text.Trim());
            }
            else
            {
                objPRReq.EmpID = 1111;
            }
            if (txt_Designation.Text.Trim() != "")
            {
                objPRReq.Design = convertQuotes(txt_Designation.Text.Trim());
            }
            else
            {
                string msg = "Please Enter Designation";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            objPRReq.SurName = convertQuotes(txt_SurName.Text.Trim());
            objPRReq.ProjectTitle = convertQuotes(txt_ProjectTitle.Text.Trim());
            if (txt_GovMail.Text.Trim() != "")
            {
                objPRReq.GovMail = convertQuotes(txt_GovMail.Text.Trim());
            }
            else
            {
                string msg = "Please Enter Gov Mail Expected Format";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (txt_DOB.Text.Trim() != "")
            {
                DateTime dob = DateTime.ParseExact(txt_DOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objPRReq.DOB = dob; 
            }
            else
            {
                string msg = "Please Select Date of Birth";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            if (txt_DOJ.Text.Trim() != "")
            {
                DateTime doj = DateTime.ParseExact(txt_DOJ.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objPRReq.DOJ = doj;
            }
            else
            {
                string msg = "Please Select Date of Birth";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            if (txt_DOR.Text.Trim() != "")
            {
                DateTime dor = DateTime.ParseExact(txt_DOR.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                objPRReq.DOR = dor;
            }
            else
            {
                string msg = "Please Select Valid Date";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }

            PRResp r = objPRIBC.getRequestforGovMail_EMPID(objPRReq);
            DataTable dt = r.GetTable;
            if (dt.Rows.Count > 0)
            {
                string msg = "Data Already Available with us..";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            else
            {
                objPRIBC.AddRequestforGovMail(objPRReq);
                string msg = "Data Submitted Successfully...!!!";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }
    }
}