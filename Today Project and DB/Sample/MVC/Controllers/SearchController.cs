using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class SearchController : Controller
    {
        private MVCContext context = new MVCContext();
        public ActionResult Search()
        {
            return View("Search");
        }

        #region Search
        [HttpPost]
        public JsonResult Search(string Phone)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                var customers = context.Customers.GroupJoin(context.Countries, m => m.CountryID, n => n.CountryID, (m, n) => new { m, n })
                .GroupJoin(context.Provinces, j => j.m.ProvinceID, k => k.ProvinceID, (j, k) => new { j, k })
                .Where(t => t.j.m.Phone == Phone)
                .Select(l => new
                {
                    CustomerID = l.j.m.CustomerID,
                    FirstName = l.j.m.FirstName,
                    LastName = l.j.m.LastName,
                    BirthDate = l.j.m.BirthDate,
                    Phone = l.j.m.Phone,
                    Email = l.j.m.Email,
                    Address = l.j.m.Address,
                    ProvinceID = l.j.m.ProvinceID,
                    CountryID = l.j.m.CountryID,
                    IsActive = l.j.m.IsActive,
                    Country = l.j.m.Country.CountryName,
                    Province = l.j.m.Province.ProvinceName
                }).FirstOrDefault();                

                if (customers != null)
                {
                    return Json(customers);
                }
                else
                {
                    return Json("0");
                }
            }
            else
            {
                return Json("0");
            }
        }
        #endregion

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
