using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AddUpdateController : Controller
    {
        private MVCContext context = new MVCContext();
        public ActionResult AddUpdate(Int32? id)
        {
            if (id == null)
            {
                ViewBag.TiTle = "Add";
                ViewBag.CountryList = context.Countries.OrderBy(o => o.CountryName);
                ViewBag.ProvinceList = context.Provinces.Where(t => t.CountryID == 0).OrderBy(o => o.ProvinceName);
                var customers = new Customer();
                return View("~/Views/Edit/Edit.cshtml", customers);
            }
            else
            {
                ViewBag.TiTle = "Update";
                Int64 customerID = Convert.ToInt64(id);
                var customers = context.Customers.Where(t => t.CustomerID == customerID).OrderBy(o => o.FirstName).ThenBy(p => p.LastName).FirstOrDefault();
                ViewBag.CountryList = context.Countries;
                ViewBag.ProvinceList = context.Provinces.Where(t => t.CountryID == customers.CountryID);
                return View("~/Views/Edit/Edit.cshtml", customers);
            }
        }

        public ActionResult FillProvince(Int32 countryID)
        {
            Int64 customerID = Convert.ToInt64(countryID);
            var provinces = context.Provinces.Where(t => t.CountryID == customerID).OrderBy(o => o.ProvinceName);
            return Json(provinces, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer obj)
        {
            if (ModelState.IsValid)
            {
                if (Convert.ToInt64(obj.CustomerID) > 0)
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
                        TempData["Message"] = "Updated Successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error whle updating";
                    }
                }
                else
                {
                    obj.CreatedDate = DateTime.Now;
                    obj.CreatedByID = 1;
                    obj.ModifiedDate = DateTime.Now;
                    obj.ModifiedByID = 1;

                    context.Customers.Add(obj);
                    if (context.SaveChanges() > 0)
                    {
                        var customerID = obj.CustomerID;
                        TempData["Message"] = "Saved Successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error whle saving";
                    }
                }
                return RedirectToAction("List", "List");
            }
            return View("~/Views/Edit/Edit.cshtml", obj);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
