using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        static string cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        static SqlConnection con = new SqlConnection();
        static SqlCommand cmd = new SqlCommand();
        static SqlParameter sprm = new SqlParameter();
        static SqlDataAdapter adp = new SqlDataAdapter();
        static DataTable dt = new DataTable();

        public DBHelper()
        {

        }

        public static void CreateConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = cnstr;
                cmd.Connection = con;
                con.Open();
            }
        }

        public static void CloseConnection()
        {
            con.Close();
            con.Dispose();
            cmd.Parameters.Clear();
            cmd.Dispose();
        }

        public static void ParametersAddWithValue(string pname, object pval)
        {
            sprm = cmd.CreateParameter();
            sprm.ParameterName = pname;
            sprm.Value = pval;
            cmd.Parameters.Add(sprm);
        }

        public static int ExecuteNonQuery(string cmdText)
        {
            int i, j = 0;
            try
            {
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.StoredProcedure;
                CreateConnection();
                sprm.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(sprm);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    j = int.Parse(sprm.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return j;
        }

        public static SqlDataReader ExecuteReader(string cmdText)
        {
            SqlDataReader dr;
            try
            {
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.StoredProcedure;
                CreateConnection();

                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return dr;
        }

        public static object ExecuteScalar(string cmdText)
        {
            object val;
            try
            {
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.StoredProcedure;
                CreateConnection();

                val = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return val;
        }

        public static DataTable ExecuteDataSet(string cmdText)
        {
            try
            {
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.StoredProcedure;
                CreateConnection();

                dt = new DataTable();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            return dt;
        }
    }
}
