using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using WcfService.BAL;

namespace WcfService.DAL
{
    public class ProvinceDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlParameter prm = new SqlParameter();
        SqlDataAdapter adp;
        DataTable dt;

        public ProvinceDAL()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            string cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            con.ConnectionString = cnstr;
            cmd.Connection = con;
        }

        public List<ProvinceBAL> GetProvince(Int64 countryID)
        {
            List<ProvinceBAL> lst = new List<ProvinceBAL>();
            SqlDataReader dr;
            try
            {
                cmd.Parameters.AddWithValue("@CountryID", countryID);
                cmd.CommandText = "GetProvince";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProvinceBAL obj = new ProvinceBAL();
                        obj.ProvinceID = dr.GetInt32(dr.GetOrdinal("ProvinceID"));
                        obj.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                        obj.Province = dr.GetString(dr.GetOrdinal("Province"));

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