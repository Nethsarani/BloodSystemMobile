using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class Request
    {
        public int Id { get; set; }
        public Hospital Hospital { get; set; }
        public DateTime Date { get; set; }
        public string BloodType { get; set; }
        public decimal BloodAmount { get; set; }
    }
}
