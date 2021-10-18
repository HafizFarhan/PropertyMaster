using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public int plotSaleId { get; set; }
        public double amountPaid { get; set; }
        public string details{ get; set; }
        public DateTime datetime{ get; set; }
    }
}