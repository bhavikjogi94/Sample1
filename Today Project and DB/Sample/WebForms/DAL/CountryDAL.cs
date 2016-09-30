using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using WebForms.BAL;

namespace WebForms.DAL
{
    public class CountryDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlParameter prm = new SqlParameter();
        SqlDataAdapter adp;
        DataTable dt;

        public CountryDAL()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            string cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            con.ConnectionString = cnstr;
            cmd.Connection = con;
        }

        public DataTable GetAllCountry()
        {
            cmd.CommandText = "GetCountry";
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            
            dt = new DataTable();
            adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            return dt;
        }

        public List<CountryBAL> GetCountry()
        {
            List<CountryBAL> lst = new List<CountryBAL>();
            SqlDataReader dr;
            try
            {
                cmd.CommandText = "GetCountry";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CountryBAL obj = new CountryBAL();
                        obj.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                        obj.Country = dr.GetString(dr.GetOrdinal("Country"));

                        lst.Add(obj);
                    }
                    //dr.NextResult();
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                con.Dispose();
                con.Close();
            }
            return lst;
        }


    }
}