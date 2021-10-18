using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class LandAcqAR
    {
        public int id { get; set; }
        public int landAcqId { get; set; }
        public string details { get; set; }
        public double amount { get; set; }
        public DateTime datetime { get; set; }
    }
}