using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WCF.DAL;

namespace WCF.BAL
{
    public class ProvinceBAL
    {
        public Int32 ProvinceID { get; set; }
        public Int32 CountryID { get; set; }
        public string Province { get; set; }

        public List<ProvinceBAL> GetProvince(Int32 countryID)
        {
            ProvinceDAL obj = new ProvinceDAL();
            return obj.GetProvince(countryID);
        }
    }
}