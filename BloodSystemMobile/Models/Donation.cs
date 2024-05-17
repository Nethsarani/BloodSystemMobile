using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BloodDonationManamentSystem
{
  [Table("DonationTable")]
    public class Donation
    {
      [PrimaryKey]
      [AutoIncrement]
      [Column("ID")]
        public int ID { get; set; }
        
              [Column("DonorID")]
              public int DonorID { get; set; }
              
        public Donor Donor { get; set; }
        
              [Column("Place")]
              public int placeId { get; set; }
              
        public CollectionPoint collectionPoint { get; set; }
        
              [Column("Date")]
        public DateTime Date { get; set; }
        
                      [Column("Status")]
        public string Status { get; set; }
    }
}
