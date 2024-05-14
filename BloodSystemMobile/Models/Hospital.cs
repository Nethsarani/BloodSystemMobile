using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem
{
    public class Hospital : CollectionPoint
    {
        public string RegNo { get; set; }
        public bool isTesting { get; set; }
        public bool isCollecting { get; set; }
        public List<TimeSpan> OpenTimes { get; set; }

        public Hospital() 
        {
            
        }
    }
}
