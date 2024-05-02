using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem
{
    public class Donation
    {
        public int ID { get; set; }
        public Donor Donor { get; set; }
        public CollectionPoint collectionPoint { get; set; }
        public DateTime Date { get; set; }
    }
}
