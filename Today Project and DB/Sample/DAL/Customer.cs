using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class Customer :DBHelper
    {
        public static Entity.Customer GetCustomerByPhone(string phoneNo)
        {
            Entity.Customer obj = new Entity.Customer();
            try
            {
                ParametersAddWithValue("@PhoneNo", phoneNo);
                SqlDataReader dr = ExecuteReader("GetCustomerByPhone");
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
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return obj;
        }

        public static List<Entity.Customer> GetCustomer()
        {
            List<Entity.Customer> lst = new List<Entity.Customer>();

            try
            {
                SqlDataReader dr = ExecuteReader("GetCustomer");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Entity.Customer obj = new Entity.Customer();
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

        public static Entity.Customer GetCustomerByID(Int64 customerID)
        {
            Entity.Customer obj = new Entity.Customer();
            try
            {
                ParametersAddWithValue("@CustomerID", customerID);
                SqlDataReader dr = ExecuteReader("GetCustomerByID");
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
                CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return obj;
        }

        public static int InsertUpdateCustomer(Entity.Customer obj)
        {
            ParametersAddWithValue("@CustomerID", obj.CustomerID);
            ParametersAddWithValue("@FirstName", obj.FirstName);
            ParametersAddWithValue("@LastName", obj.LastName);
            ParametersAddWithValue("@BirthDate", obj.BirthDate);
            ParametersAddWithValue("@Phone", obj.Phone);
            ParametersAddWithValue("@Email", obj.Email);
            ParametersAddWithValue("@Address", obj.Address);
            ParametersAddWithValue("@ProvinceID", obj.ProvinceID);
            ParametersAddWithValue("@CountryID", obj.CountryID);
            ParametersAddWithValue("@IsActive", obj.IsActive);

            int i = ExecuteNonQuery("InsertUpdateCustomer");

            return i;
        }

        public static int DeleteCustomer(Int64 customerID)
        {
            ParametersAddWithValue("@CustomerID", customerID);
            int i = ExecuteNonQuery("DeleteCustomer");
            return i;
        }
    }
}
