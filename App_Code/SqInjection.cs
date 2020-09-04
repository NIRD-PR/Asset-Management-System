using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SqInjection
/// </summary>
public class SqInjection
{
    public SqInjection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static Boolean checkForSQLInjection(string userInput)
    {
        
            bool isSQLInjection = false;

            string[] sqlCheckList = { "--",";--",";","/*","*/","@@","char","nchar","varchar","nvarchar","alter","begin","cast","create","cursor","declare","delete","drop","end","exec","execute","fetch","insert","kill","select","sys","sysobjects",
                                    "syscolumns","table","update","insert","open","<script>","sp_",".js",".exe",".sh",".php","<",">",".dll","<applet>","<body>","<embed>","<frame>","<script>","<frameset>","<html>","<iframe>","<img>","<style>","<layer>","<link>","<ilayer>","<meta>","<object>"

                                      };
            string CheckString = userInput.Replace("'", "''");
            try
            {
                for (int i = 0; i <= sqlCheckList.Length - 1; i++)
                {

                    if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))

                    { isSQLInjection = true; }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message.Replace("'", "");
                HttpResponse.ReferenceEquals("~/Error.aspx", false);
            }
            return isSQLInjection;
       
    }
}