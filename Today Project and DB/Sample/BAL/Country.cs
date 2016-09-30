using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Country
    {
        public static List<Entity.Country> GetCountry()
        {
            return DAL.Country.GetCountry();
        }
    }
}
