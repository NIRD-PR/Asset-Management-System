using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Data;
public partial class CITInventory_InventoryHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = FlipDataSet(c());
            GridView1.DataBind();
        }
    }
    public DataSet c()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable("Company");
        DataRow dr;
        dt.Columns.Add(new DataColumn("accountNo", typeof(Int32)));
        dt.Columns.Add(new DataColumn("ItemName", typeof(string)));
        dt.Columns.Add(new DataColumn("Address", typeof(string)));
        for (int i = 0; i <= 10; i++)
        {
            dr = dt.NewRow();
            dr[0] = i;
            dr[1] = "Company" + i + Environment.NewLine + "Title" + i;
            dr[2] = "Address" + i + Environment.NewLine + "Title" + i;
            dt.Rows.Add(dr);
        }
        ds.Tables.Add(dt);
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
}