using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class CICTInventory_CITSupportingStaff : System.Web.UI.Page
{
    PRReq objPRReq = new PRReq();
    PRResp objPRResp = new PRResp();
    PRIBC objPRIBC = new PRIBC();
    string uname,deptname="CICT"; int oid=1,did=14;
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Photo"] = "";
        getAdminUser();
        if (!IsPostBack)
        {
            getAllCITsupporingStaff();
            if (Request.QueryString["st"] != null)
            {
                hdn_CSID.Value = Request.QueryString["st"].ToString();
                Update();
            }
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
    public string convertQuotes(string str)
    {
        return str.Replace("'", "''");
    }
    public void Update()
    {
        objPRReq.CSID = int.Parse(hdn_CSID.Value);
        objPRReq.OID = oid;
        objPRReq.Status = "Active";
        PRResp r = objPRIBC.getCITSupporintStaff_CSID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            txt_EmpID.Text = dt.Rows[0]["EmpID"].ToString();
            txt_Name.Text = dt.Rows[0]["Name"].ToString();
            txt_Design.Text = dt.Rows[0]["Design"].ToString();
            txt_Email.Text = dt.Rows[0]["Email"].ToString();
            txt_Mobile.Text = dt.Rows[0]["Mobile"].ToString();
            lbl_Photo.Text = dt.Rows[0]["Photo"].ToString();
            btn_Submit.Text = "Update";
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            HttpFileCollection uploadFilCol = Request.Files;
            string m = txt_EmpID.Text.Trim();

            if (fu_Photo.HasFile)
            {
                Dictionary<string, byte[]> imageHeader = new Dictionary<string, byte[]>();
                imageHeader.Add("JPG", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 });
                //imageHeader.Add("JPG", new byte[] { 255, 216, 255, 224 });
                //imageHeader.Add("JPG", new byte[] { 255, 216, 255, 225 });
                imageHeader.Add("JPEG", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 });
                imageHeader.Add("PNG", new byte[] { 0x89, 0x50, 0x4E, 0x47 });
                imageHeader.Add("TIF", new byte[] { 0x49, 0x49, 0x2A, 0x00 });
                imageHeader.Add("TIFF", new byte[] { 0x49, 0x49, 0x2A, 0x00 });
                imageHeader.Add("GIF", new byte[] { 0x47, 0x49, 0x46, 0x38 });
                imageHeader.Add("BMP", new byte[] { 0x42, 0x4D });
                imageHeader.Add("ICO", new byte[] { 0x00, 0x00, 0x01, 0x00 });

                byte[] header;

                if (fu_Photo.PostedFile.ContentLength < 10240000)
                {
                    string PhotoExt;

                    PhotoExt = fu_Photo.FileName.Substring(fu_Photo.FileName.LastIndexOf('.') + 1).ToUpper();

                    byte[] tmp = imageHeader[PhotoExt];
                    header = new byte[tmp.Length];

                    // GET HEADER INFORMATION OF UPLOADED FILE
                    fu_Photo.FileContent.Read(header, 0, header.Length);

                    if (CompareArray(tmp, header) && PhotoExt == "JPG" || PhotoExt == "PNG" || PhotoExt == "JPEG")
                    {
                        string pic = ViewState["Photo"].ToString();
                        string p1 = MapPath("~\\SPhotos\\");

                        fu_Photo.SaveAs(p1 + m + "_" + fu_Photo.FileName);
                        pic = m + "_" + fu_Photo.FileName;

                        objPRReq.Photo = pic;
                    }
                    else
                    {
                        string msg = "Invalid ." + PhotoExt + " file format ... Upload only JPG/JPEG/PNG/TIF Files";
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                        return;
                    }

                }
                else
                {
                    string msg = "Photo Size Should be Less than 1 MB";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                    return;
                }
            }
            else
            {
                string msg = "Please Upload Photo";
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                return;
            }
            objPRReq.OID = oid;
            objPRReq.Status = "Active";
            objPRReq.DID = did;
            objPRReq.DeptID = deptname;
            objPRReq.Dated = DateTime.Now;
            objPRReq.UID = int.Parse(Session["UserID"].ToString());
            objPRReq.UName = uname;
            objPRReq.Role = 11;
            objPRReq.EmpID = int.Parse(txt_EmpID.Text.Trim());
            objPRReq.Name = convertQuotes(txt_Name.Text.Trim());
            objPRReq.Design = convertQuotes(txt_Design.Text.Trim());
            objPRReq.Email = convertQuotes(txt_Email.Text.Trim());
            objPRReq.Mobile = double.Parse(txt_Mobile.Text.Trim());
            objPRReq.Password = "7c4a8d09ca3762af61e59520943dc26494f8941b";
            if (btn_Submit.Text != "Update")
            {
                PRResp r = objPRIBC.getCITSupporintStaff(objPRReq);
                DataTable dt = r.GetTable;
                if (dt.Rows.Count > 0)
                {
                    string msg = txt_Name.Text.Trim()+" is Already Registered with us..";
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
                }
                else
                {
                    objPRIBC.RegisterCITSupporintStaff(objPRReq);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('"+txt_Name.Text.Trim()+"' Updated Successfully..!!!'); window.open('../CIT_SS/{0}','_self');", true);
                }
            }
            else
            {
                objPRReq.CSID = int.Parse(hdn_CSID.Value);
                objPRIBC.updateCITSupporintStaff_CSID(objPRReq);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", " alert('Item Type Updated Successfully..!!!'); window.open('../CIT_SS/{0}','_self');", true);
            }

        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", ""); ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            return;
        }
    }
    private bool CompareArray(byte[] a1, byte[] a2)
    {
        if (a1.Length != a2.Length)
            return false;

        for (int i = 0; i < a1.Length; i++)
        {
            if (a1[i] != a2[i])
                return false;
        }

        return true;
    }
    protected void rptr_CITSS_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("../CIT_SS/{0}?st=" + e.CommandArgument.ToString());
        }

        if (e.CommandName == "Delete")
        {
            objPRReq.OID = oid;
            objPRReq.CSID = int.Parse(e.CommandArgument.ToString());
            objPRIBC.DelCITSupporintStaff_CSID(objPRReq);
            string msg = "Deleted Successfully...!!!";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            getAllCITsupporingStaff();
        }

        if (e.CommandName == "Block")
        {
            objPRReq.Status = "In-Active";
            objPRReq.OID = oid;
            objPRReq.CSID = int.Parse(e.CommandArgument.ToString());
            objPRIBC.BlockCITSupporintStaff_CSID(objPRReq);
            string msg = "Blocked Successfully...!!!";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Alert...!!!", "alert('" + msg + "');", true);
            getAllCITsupporingStaff();
        }
    }

    public void getAllCITsupporingStaff()
    {
        objPRReq.OID = oid;
        PRResp r = objPRIBC.getAllCITSupporintStaff_CSID(objPRReq);
        DataTable dt = r.GetTable;
        if (dt.Rows.Count > 0)
        {
            rptr_CITSS.DataSource = dt;
            rptr_CITSS.DataBind();
            lbl_Count.Text = "No.of Staff Members Listed : " + dt.Rows.Count.ToString();
        }
        else
        {
            rptr_CITSS.DataSource = dt;
            rptr_CITSS.DataBind();
            lbl_Count.Text = "No.of Staff Members Listed : " + dt.Rows.Count.ToString();
        }
    }
}