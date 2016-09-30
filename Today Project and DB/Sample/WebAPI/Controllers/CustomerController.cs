using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private WebAPIEntities context = new WebAPIEntities();

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> obj = context.Customers.OrderBy(o => o.FirstName).ThenBy(p => p.LastName);
            if (obj == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return obj;
            }
        }

        [HttpGet]
        [ActionName("Single")]
        public Customer GetCustomersByID(Int64 customersID, Int64 createdByID)
        {
            Int64 customerID = Convert.ToInt64(customersID);
            Customer customers = context.Customers.Where(m => m.CustomerID == customerID && m.CreatedByID == createdByID).FirstOrDefault();
            if (customers == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return customers;
            }
        }

        [HttpPost]
        [ActionName("Single")]
        public string AddCustomersByID(Int64 id)
        {
            return "Saved Successfully";
        }

        [HttpGet]
        public Customer GetByID(Int64 id)
        {
            Int64 customerID = Convert.ToInt64(id);
            Customer customers = context.Customers.Where(m => m.CustomerID == customerID).FirstOrDefault();
            if (customers == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return customers;
            }
        }

        [HttpGet]
        public IEnumerable<Country> GetCountry()
        {
            IEnumerable<Country> countries = context.Countries.OrderBy(o => o.Country1);
            if (countries == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return countries;
            }
        }

        [HttpGet]
        public IEnumerable<Province> GetProvince(Int32 id)
        {
            Int32 countryID = Convert.ToInt32(id);
            IEnumerable<Province> provinces = context.Provinces.Where(t => t.CountryID == countryID).OrderBy(o => o.Province1);
            if (provinces == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "No record(s) found."));
            }
            else
            {
                return provinces;
            }
        }

        [HttpGet]
        [NonAction]
        public string GetNonAction(Int64 id)
        {
            return "Non Action Method";
        }

        [HttpPost]
        public string SaveCustomer(Customer obj)
        {
            if (obj.CustomerID > 0)
            {
                obj.ModifiedDate = DateTime.Now;

                context.Customers.Attach(obj);
                var entry = context.Entry(obj);
                context.Configuration.ValidateOnSaveEnabled = false;

                context.Entry(obj).Property(u => u.FirstName).IsModified = true;
                context.Entry(obj).Property(u => u.LastName).IsModified = true;
                context.Entry(obj).Property(u => u.BirthDate).IsModified = true;
                context.Entry(obj).Property(u => u.Phone).IsModified = true;
                context.Entry(obj).Property(u => u.Email).IsModified = true;
                context.Entry(obj).Property(u => u.Address).IsModified = true;
                context.Entry(obj).Property(u => u.CountryID).IsModified = true;
                context.Entry(obj).Property(u => u.ProvinceID).IsModified = true;
                context.Entry(obj).Property(u => u.ModifiedDate).IsModified = true;
                context.Entry(obj).Property(u => u.IsActive).IsModified = true;

                if (context.SaveChanges() > 0)
                {
                    context.Configuration.ValidateOnSaveEnabled = true;
                    return "Updated Successfully.";
                }
                else
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while updating."));
                }
            }
            else
            {
                obj.CreatedDate = DateTime.Now;
                obj.CreatedByID = 1;
                obj.ModifiedDate = DateTime.Now;
                obj.ModifiedByID = 1;
                obj.IsDeleted = false;

                context.Customers.Add(obj);
                try
                {
                    if (context.SaveChanges() > 0)
                    {

                        var customerID = obj.CustomerID;
                        return customerID.ToString() + " " + "Saved Successfully.";
                    }
                    else
                    {
                        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while saving."));
                    }
                }
                catch
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while saving."));
                }
            }
        }

        [HttpPost]
        public string DeleteCustomer(Int64 id)
        {
            Int64 customerID = Convert.ToInt64(id);
            Customer customers = context.Customers.Where(m => m.CustomerID == customerID).FirstOrDefault();
            context.Customers.Remove(customers);
            if (context.SaveChanges() > 0)
            {
                return "Deleted Successfully.";
            }
            else
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error while deleting."));
            }
        }

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}