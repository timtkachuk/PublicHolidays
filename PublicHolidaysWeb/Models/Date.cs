using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidaysWeb.Models
{

    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public DateTime NormalizedDate => new DateTime(Year, Month, Day);
    }

    
    
}
