using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite

namespace BloodDonationManamentSystem.Models
{
  [Table("AppointmentTable")]
    public class Appointment
    {
      [PrimaryKey]
      [AutoIncrement]
      [Column("Id")]
        public int Id { get; set; }
        
        [Column("DonorID")]
        public Donor Donor { get; set; }
        
        [Column("CollectionPointID")]
        public CollectionPoint Place { get; set; }
        
        [Column("Date")]
        public DateTime Date { get; set; }
        
        [Column("Time")]
        public TimeSpan Time { get; set; }
        
        [Column("Description")]
        public string Description { get; set; }
        
        [Column("Status")]
        public string Status { get; set; }

    }
}
