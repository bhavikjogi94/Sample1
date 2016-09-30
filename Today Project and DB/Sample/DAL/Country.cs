using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Country : DBHelper
    {
        public static List<Entity.Country> GetCountry()
        {
            List<Entity.Country> lst = new List<Entity.Country>();
            try
            {
                SqlDataReader dr = ExecuteReader("GetCountry");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Entity.Country obj = new Entity.Country();
                        obj.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                        obj.CountryName = dr.GetString(dr.GetOrdinal("Country"));

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
