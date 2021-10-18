using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class CustomSchedule
    {
        public int id { get; set; }
        public int plotId{ get; set; }
        public double amount { get; set; }
    }
}