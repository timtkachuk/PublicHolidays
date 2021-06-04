using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidaysWeb.Models
{
    public class Country
    {
        public string CountryCode { get; set; }
        public List<string> Regions { get; set; }
        public List<string> HolidayTypes { get; set; }
        public string FullName { get; set; }
        public Date FromDate { get; set; }
        public Date ToDate { get; set; }
    }

}
