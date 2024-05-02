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

        public Hospital(string name, Location location, string contact, string email, string username, string password, string regno, bool testing, bool collecting, List<TimeSpan> open) 
        {
            Name = name;
            Location = location;
            ContactNo = contact;
            Email = email;
            Username = username;
            Password = password;
            RegNo= regno;
            isTesting = testing;
            isCollecting = collecting;
            OpenTimes = open;
        }
    }
}
