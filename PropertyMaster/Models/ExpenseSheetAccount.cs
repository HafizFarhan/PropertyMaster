using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class ExpenseSheetAccount
    {
        public int id { get; set; }
        public int landAcqId { get; set; }
        public string details { get; set; }
        public double debit { get; set; }
        public DateTime datetime { get; set; }
        public DateTime updatedAt { get; set; }
        [NotMapped]
        public double balance { get; set; }

    }
}