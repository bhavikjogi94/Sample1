using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DAL;

namespace BAL
{
    public class Customer
    {
        public static Entity.Customer GetCustomerByPhone(string phoneNo)
        {
            return DAL.Customer.GetCustomerByPhone(phoneNo);
        }

        public static List<Entity.Customer> GetCustomer()
        {
            return DAL.Customer.GetCustomer();
        }

        public static Entity.Customer GetCustomerByID(Int64 customerID)
        {
            return DAL.Customer.GetCustomerByID(customerID);
        }

        public static int InsertUpdateCustomer(Entity.Customer obj)
        {
            return DAL.Customer.InsertUpdateCustomer(obj);
        }

        public static int DeleteCustomer(Int64 customerID)
        {
            return DAL.Customer.DeleteCustomer(customerID);
        }
    }
}
