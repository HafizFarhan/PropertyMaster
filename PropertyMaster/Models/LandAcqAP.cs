using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class LandAcqAP
    {
        public int id { get; set; }
        public int landAcqId { get; set; }
        public double paidAmount{ get; set; }
        public string details{ get; set; }
        public DateTime datetime{ get; set; }
    }
}