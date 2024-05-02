using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationManamentSystem.Models
{
    public class HealthCondition
    {
        public float Weight { get; set; }
        public float Hemoglobin { get; set; }
        public bool isDiseased { get; set; }
        public string Diseases { get; set; }
        public bool Suitability { get; set; }
    }
}
