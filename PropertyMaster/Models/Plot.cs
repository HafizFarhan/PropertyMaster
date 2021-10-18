using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class Plot
    {
        public int id { get; set; }
        public int projId{ get; set; }
        public string details { get; set; }
        public double saleableAmount{ get; set; }
        public bool deleted{ get; set; }
        public DateTime datetime{ get; set; }
    }

}