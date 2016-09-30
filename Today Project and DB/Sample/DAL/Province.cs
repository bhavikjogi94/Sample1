using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Province : DBHelper
    {
        public static List<Entity.Province> GetProvince(Int32 countryID)
        {
            List<Entity.Province> lst = new List<Entity.Province>();
            try
            {
                ParametersAddWithValue("@CountryID", countryID);
                SqlDataReader dr = ExecuteReader("GetProvince");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Entity.Province obj = new Entity.Province();
                        obj.ProvinceID = dr.GetInt32(dr.GetOrdinal("ProvinceID"));
                        obj.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                        obj.ProvinceName = dr.GetString(dr.GetOrdinal("Province"));

                        lst.Add(obj);
                    }
                    //dr.NextResult();
                }
                dr.Close();
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return lst;
        }
    }
}
