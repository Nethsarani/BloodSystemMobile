using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Donor Donor { get; set; }
        public CollectionPoint Place { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }

    }
}
