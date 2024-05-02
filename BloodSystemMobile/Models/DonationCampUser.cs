using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class DonationCampUser : User
    {
        public DonationCamp donationCamp { get; set; }
    }
}
