<%@ WebHandler Language="C#" Class="UploadVideoFile" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

public class UploadVideoFile : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request.QueryString["id"]);
        byte[] bytes;
        string contentType;
        string strConnString = ConfigurationManager.ConnectionStrings["Thotapally"].ConnectionString;
        string title, description;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Title,Description, Data, ContentType from tbl_VideoFiles where Id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                bytes = (byte[])sdr["Data"];
                contentType = sdr["ContentType"].ToString();
                title = sdr["Title"].ToString();
                description = sdr["Description"].ToString();
                con.Close();
            }
        }
        context.Response.Clear();
        context.Response.Buffer = true;
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + title);
        context.Response.ContentType = contentType;
        context.Response.BinaryWrite(bytes);
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}