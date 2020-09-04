using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using NIRDPR.RK.PRReferences;
using System.Data;
public partial class VideoTutorials : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["Thotapally"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Id, FileName, Description from tbl_VideoFiles where Status='Active'";
                cmd.Connection = con;
                con.Open();
                dl_Data.DataSource = cmd.ExecuteReader();
                dl_Data.DataBind();
                con.Close();
            }
        }
    }
}