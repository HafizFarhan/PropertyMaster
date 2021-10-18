using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class PlotSale
    {
        public int id { get; set; }
        public int plotId { get; set; }
        public int dealerId { get; set; }
        public int clientId { get; set; }
        public double saleAmount{ get; set; }
        public double commissionPercent{ get; set; }
        public DateTime dateTime{ get; set; }
    }
}