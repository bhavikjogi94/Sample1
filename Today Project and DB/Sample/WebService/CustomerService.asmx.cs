using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Services;
using System.Web;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace WebService
{
    /// <summary>
    /// Summary description for CustomerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CustomerService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<BAL.CountryBAL> GetCountry()
        {
            List<BAL.CountryBAL> lst = new List<BAL.CountryBAL>();
            DAL.CountryDAL objDAL = new DAL.CountryDAL();
            lst = objDAL.GetCountry();
            if (lst == null)
            {
                //throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return lst;
        }

        [WebMethod]
        public List<BAL.ProvinceBAL> GetProvince(string id)
        {
            List<BAL.ProvinceBAL> lst = new List<BAL.ProvinceBAL>();
            DAL.ProvinceDAL objDAL = new DAL.ProvinceDAL();
            lst = objDAL.GetProvince(Convert.ToInt32(id));
            if (lst == null)
            {
                //throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return lst;
        }

        [WebMethod]
        public List<BAL.CustomerBAL> GetCustomer()
        {
            List<BAL.CustomerBAL> lst = new List<BAL.CustomerBAL>();
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            lst = objDAL.GetCustomer(0);
            if (lst == null)
            {
                //throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return lst;
        }

        [WebMethod]
        public BAL.CustomerBAL GetCustomerByID(string id)
        {
            BAL.CustomerBAL obj = new BAL.CustomerBAL();
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            obj = objDAL.GetCustomerByID(Convert.ToInt64(id));
            if (obj == null)
            {
                //throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return obj;
        }

        //  To Call from Ajax Call
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCustomerByIDByAjax(string id)
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            BAL.CustomerBAL obj = new BAL.CustomerBAL();
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            obj = objDAL.GetCustomerByID(Convert.ToInt64(id));
            if (obj == null)
            {
                //throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            Context.Response.Write(JsonConvert.SerializeObject(obj));
        }

        [WebMethod]
        public int AddCustomer(BAL.CustomerBAL obj)
        {
            int retval = 0;
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            retval = objDAL.InsertUpdateCustomer(obj);
            return retval;
        }

        [WebMethod]
        public int UpdateCustomer(BAL.CustomerBAL obj)
        {
            int retval = 0;
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            retval = objDAL.InsertUpdateCustomer(obj);
            return retval;
        }

        [WebMethod]
        public int DeleteCustomer(string id)
        {
            int retval = 0;
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            retval = objDAL.DeleteCustomer(Convert.ToInt64(id));
            return retval;
        }
    }
}
