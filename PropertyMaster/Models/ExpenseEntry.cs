using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class ExpenseEntry
    {
        public int id { get; set; }
        public int expId { get; set; }
        public string details { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        public bool deleted { get; set; }
        public DateTime datetime { get; set; }
        [NotMapped]
        public double balance { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public int updatedBy { get; set; }
    }
}