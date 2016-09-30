using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CustomerService : ICustomerService
    {
        public List<BAL.CustomerBAL> GetCustomer()
        {
            List<BAL.CustomerBAL> lst = new List<BAL.CustomerBAL>();
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            lst = objDAL.GetCustomer(0);
            if (lst == null)
            {
                throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return lst;
        }

        public BAL.CustomerBAL GetCustomerByID(string id)
        {
            BAL.CustomerBAL obj = new BAL.CustomerBAL();
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            obj = objDAL.GetCustomerByID(Convert.ToInt64(id));
            if (obj == null)
            {
                throw new WebFaultException<string>("Record(s) not found", HttpStatusCode.NotFound);
            }
            return obj;
        }

        public int AddCustomer(BAL.CustomerBAL obj)
        {
            int retval = 0;
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            retval = objDAL.InsertUpdateCustomer(obj);
            return retval;
        }

        public int UpdateCustomer(BAL.CustomerBAL obj)
        {
            int retval = 0;
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            retval = objDAL.InsertUpdateCustomer(obj);
            return retval;
        }

        public int DeleteCustomer(string id)
        {
            int retval = 0;
            DAL.CustomerDAL objDAL = new DAL.CustomerDAL();
            retval = objDAL.DeleteCustomer(Convert.ToInt64(id));
            return retval;
        }
    }
}
