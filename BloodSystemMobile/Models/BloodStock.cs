using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class BloodStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string BloodType { get; set; }
        public decimal BloodAmount { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
