using BloodDonationManamentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem
{
    public class CollectionPoint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
