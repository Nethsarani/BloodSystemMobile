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

        public DonationCamp(string name, Location location, string contact, string email, string username, string password, DateTime date, string sTime, string eTime)
        {
            Name = name;
            Location = location;
            ContactNo = contact;
            Email = email;
            Username = username;
            Password = password;
            Date = date;
            StartTime = sTime;
            EndTime= eTime;
        }

    }
}
