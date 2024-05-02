using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string Position { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public Privilages Privilages { get; set; }


    }
}
