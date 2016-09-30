using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using WcfService.BAL;

namespace WcfService.DAL
{
    public class CustomerDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlParameter sprm = new SqlParameter();
        SqlDataAdapter adp;
        DataTable dt;

        public CustomerDAL()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            string cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            con.ConnectionString = cnstr;
            cmd.Connection = con;
        }

        public CustomerBAL GetCustomerByPhone(string phone)
        {
            CustomerBAL obj = new CustomerBAL();
            SqlDataReader dr;
            try
            {
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.CommandText = "GetCustomerByPhone";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.CustomerID = dr.GetInt64(dr.GetOrdinal("CustomerID"));
                        obj.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                        obj.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                        obj.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
                        obj.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                        obj.Email = dr.GetString(dr.GetOrdinal("Email"));
                        obj.Address = dr.GetString(dr.GetOrdinal("Address"));
                        obj.ProvinceID = dr.GetInt32(dr.GetOrdinal("ProvinceID"));
                        obj.Province = dr.GetString(dr.GetOrdinal("Province"));
                        obj.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                        obj.Country = dr.GetString(dr.GetOrdinal("Country"));
                        obj.IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
                    }
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

            return obj;
        }

        public CustomerBAL GetCustomerByID(Int64 customerID)
        {
            CustomerBAL obj = new CustomerBAL();
            SqlDataReader dr;
            try
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.CommandText = "GetCustomerByID";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        obj.CustomerID = dr.GetInt64(dr.GetOrdinal("CustomerID"));
                        obj.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                        obj.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                        obj.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
                        obj.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                        obj.Email = dr.GetString(dr.GetOrdinal("Email"));
                        obj.Address = dr.GetString(dr.GetOrdinal("Address"));
                        obj.ProvinceID = dr.GetInt32(dr.GetOrdinal("ProvinceID"));
                        obj.Province = dr.GetString(dr.GetOrdinal("Province"));
                        obj.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                        obj.Country = dr.GetString(dr.GetOrdinal("Country"));
                        obj.IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));
                    }
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

            return obj;
        }

        public List<CustomerBAL> GetCustomer(Int64 customerID)
        {
            List<CustomerBAL> lst = new List<CustomerBAL>();
            SqlDataReader dr;
            try
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.CommandText = "GetCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CustomerBAL obj = new CustomerBAL();
                        obj.CustomerID = dr.GetInt64(dr.GetOrdinal("CustomerID"));
                        obj.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
                        obj.LastName = dr.GetString(dr.GetOrdinal("LastName"));
                        obj.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
                        obj.Phone = dr.GetString(dr.GetOrdinal("Phone"));
                        obj.Email = dr.GetString(dr.GetOrdinal("Email"));
                        obj.Address = dr.GetString(dr.GetOrdinal("Address"));
                        obj.ProvinceID = dr.GetInt32(dr.GetOrdinal("ProvinceID"));
                        obj.Province = dr.GetString(dr.GetOrdinal("Province"));
                        obj.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"));
                        obj.Country = dr.GetString(dr.GetOrdinal("Country"));
                        obj.IsActive = dr.GetBoolean(dr.GetOrdinal("IsActive"));

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

        public int InsertUpdateCustomer(CustomerBAL obj)
        {
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@BirthDate", obj.BirthDate);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Address", obj.Address);
            cmd.Parameters.AddWithValue("@ProvinceID", obj.ProvinceID);
            cmd.Parameters.AddWithValue("@CountryID", obj.CountryID);
            cmd.Parameters.AddWithValue("@CreatedByID", obj.CreatedByID);
            cmd.Parameters.AddWithValue("@ModifiedByID", obj.ModifiedByID);
            cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);

            sprm.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(sprm);

            int i, j = 0;
            try
            {
                cmd.CommandText = "InsertUpdateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
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
                cmd.Parameters.Clear();
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
            return j;
        }

        public int DeleteCustomer(Int64 customerID)
        {
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            int i, j = 0;
            try
            {
                sprm.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(sprm);
                cmd.CommandText = "DeleteCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
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
                cmd.Parameters.Clear();
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
            return j;
        }
    }
}
