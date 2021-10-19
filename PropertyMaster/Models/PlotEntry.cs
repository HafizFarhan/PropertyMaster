using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class PlotEntry
    {
        public int id { get; set; }
        public int plotId { get; set; }
        public string details { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        [NotMapped]
        public double balance { get; set; }
        public DateTime datetime { get; set; }
        public int createdby { get; set; }
        public DateTime createdAt { get; set; }
        public int updatedby { get; set; }
        public DateTime updatedAt { get; set; }
    }
}