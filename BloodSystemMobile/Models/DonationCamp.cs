using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem
{
    public class DonationCamp : CollectionPoint
    {
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
