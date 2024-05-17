using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
  [Table("RequestTable")]
    public class Request
    {
      [PrimaryKey]
      [AutoIncrement]
      [Column("Id")]
        public int Id { get; set; }
        
        [Column("HospitalID")]
        public int HosId { get; set; }
        
        public Hospital Hospital { get; set; }
        
        [Column("Date")]
        public DateTime Date { get; set; }
        
        [Column("BloodType")]
        public string BloodType { get; set; }
        
        [Column("Amount")]
        public decimal BloodAmount { get; set; }
    }
}
