using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.DAL;

namespace WcfService.BAL
{
    public class CountryBAL
    {
        public Int32 CountryID { get; set; }
        public string Country { get; set; }

        public List<CountryBAL> GetCountry()
        {
            CountryDAL obj = new CountryDAL();
            return obj.GetCountry();
        }
    }
}