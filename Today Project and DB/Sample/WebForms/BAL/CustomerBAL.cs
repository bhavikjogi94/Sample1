using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebForms.DAL;

namespace WebForms.BAL
{
    public class CustomerBAL
    {
        public Int64 CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Int32 ProvinceID { get; set; }
        public string Province { get; set; }
        public Int32 CountryID { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedByID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public long ModifiedByID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public CustomerBAL GetCustomerByPhone(string phone)
        {
            CustomerDAL obj = new CustomerDAL();
            return obj.GetCustomerByPhone(phone);
        }

        public List<CustomerBAL> GetCustomer(Int64 customerID)
        {
            CustomerDAL obj = new CustomerDAL();
            return obj.GetCustomer(customerID);
        }

        public int InsertUpdateCustomer(CustomerBAL obj)
        {
            CustomerDAL objDAL = new CustomerDAL();
            return objDAL.InsertUpdateCustomer(obj);
        }

        public int DeleteCustomer(Int64 customerID)
        {
            CustomerDAL objDAL = new CustomerDAL();
            return objDAL.DeleteCustomer(customerID);
        }
    }
}
