using BloodDonationManamentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///using System.Xaml.Schema;
using SQLite;

namespace BloodDonationManamentSystem
{
  [Table("DonorTable")]
    public class Donor
    {
      [PrimaryKey]
      [AutoIncrement]
      [Column("ID")]
        public int ID { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Gender")]
        public string Gender { get; set; }
        
        [Column("NIC")]
        public string NIC { get; set; }
        
        [Column("Location")]
        public Location Location { get; set; }
        
        [Column("DOB")]
        public DateTime DOB { get; set; }
        
        [Column("ContactNo")]
        public string ContactNo { get; set; }
        
        [Column("Email")]
        public string Email { get; set; }
        
        [Column("BloodType")]
        public string BloodType { get; set; }
        
        [Column("HealthCondition")]
        public HealthCondition health { get; set; }
        
        public List<Donation> donations { get; set; }
        
        [Column("Username")]
        public string Username { get; set; }
        
        [Column("Password")]
        public string Password { get; set; }
        
        [Column("Status")]
        public string Status { get; set; }
    }
}
