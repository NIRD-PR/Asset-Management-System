using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RK.HCConnections
{
    public class HCConnections
    {
        public static SqlConnection GetConnction()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Kittus"].ToString();
            return con;
        }

        public static int ProcessQuery(string Sql)
        {
            int count = 0;
            SqlConnection con = GetConnction();
            SqlCommand cmd = new SqlCommand(Sql, con);
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return count;
        }

        public static string GetSingleValue(string Sql)
        {
            object obj = null;
            SqlConnection con = GetConnction();
            SqlCommand cmd = new SqlCommand(Sql, con);
            try
            {
                con.Open();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

            if (obj != null)
                return obj.ToString();
            else
                return "";
        }

        public static DataTable GetTable(string Sql)
        {
            SqlConnection con = GetConnction();
            SqlDataAdapter da = new SqlDataAdapter(Sql, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return dt;
        }
    }

    public class DbFunctionWithSP : HCConnections
    {
        public static int ProcessQueryWithSP(string ProcName, SqlParameter[] parms)
        {
            int count = 0;
            SqlConnection con = GetConnction();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;
            cmd.Connection = con;
            foreach (SqlParameter p in parms)
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
            return count;
        }

        public static DataTable GetTableWithSP(string ProcName, SqlParameter[] parm)
        {

            SqlConnection con = GetConnction();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            return dt;
        }
    }
}
