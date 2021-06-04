using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidaysWeb.Models
{
    public class Holiday
    {
        public Date Date { get; set; }
        public IEnumerable<HolidayName> Name { get; set; }
        public string HolidayType { get; set; }

    }
}
