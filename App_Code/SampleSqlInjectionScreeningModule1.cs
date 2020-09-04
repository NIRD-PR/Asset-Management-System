using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SampleSqlInjectionScreeningModule
/// </summary>
public class SampleSqlInjectionScreeningModule1:IHttpModule
{
	public SampleSqlInjectionScreeningModule1()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string[] blackList = {"--",";--",";","/*","*/","@@","char","nchar","varchar","nvarchar","alter","begin","cast","create","cursor","declare","delete","drop","end","exec","execute","fetch","insert","kill","select","sys","sysobjects",
                                    "syscolumns","table","update","insert","open","<script>","sp_",".js",".exe",".php",".sh","<",">",".dll","<applet>","<body>","<embed>","<frame>","<script>","<frameset>","<html>","<iframe>","<img>","<style>","<layer>","<link>","<ilayer>","<meta>","<object>"

                                       };

    public void Dispose()
    {
        //no-op 
    }

    //Tells ASP.NET that there is code to run during BeginRequest
    public void Init(HttpApplication app)
    {
        app.BeginRequest += new EventHandler(app_BeginRequest);
    }

    //For each incoming request, check the query-string, form and cookie values for suspicious values.
    void app_BeginRequest(object sender, EventArgs e)
    {
        
        HttpRequest Request = (sender as HttpApplication).Context.Request;
        //if (Request.Url.AbsolutePath.ToLowerInvariant().Contains("elmah.axd"))
        //{
        //    HttpContext.Current.Response.Redirect("~/Error.aspx");
        //}
        string url= Request.Url.ToString();
        foreach (string key in Request.QueryString)
            CheckInput(Request.QueryString[key]);
        foreach (string key in Request.Form)
            CheckInput(Request.Form[key]);
        foreach (string key in Request.Cookies)
            CheckInput(Request.Cookies[key].Value);
    }

    //The utility method that performs the blacklist comparisons
    //You can change the error handling, and error redirect location to whatever makes sense for your site.
    private void CheckInput(string parameter)
    {
        for (int i = 0; i < blackList.Length; i++)
        {
            if ((parameter.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
            {
                //
                //Handle the discovery of suspicious Sql characters here
                //
                if (blackList[i] == "'")
                {
                    HttpContext.Current.Response.Redirect("~/Error.aspx");  //generic error page on your site
                }
                string[] paramWords = parameter.Split(' ');
                foreach (string word in paramWords)
                {
                    if (blackList[i] == word)
                    {
                        HttpContext.Current.Response.Redirect("~/Error.aspx");  //generic error page on your site
                    }
                }
            }
        }
    }
}