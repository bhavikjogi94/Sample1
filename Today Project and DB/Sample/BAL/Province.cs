using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Province
    {
        public static List<Entity.Province> GetProvince(Int32 countryID)
        {
            return DAL.Province.GetProvince(countryID);
        }
    }
}
