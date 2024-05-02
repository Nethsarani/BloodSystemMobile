using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class HospitalUser : User
    {
        public Hospital hospital { get; set; }
    }
}
