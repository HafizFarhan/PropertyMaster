using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class Expense
    {
        public int id { get; set; }
        public string title { get; set; }
        public string details{ get; set; }
        public DateTime createdAt{ get; set; }
        public int createdBy{ get; set; }
        public DateTime updatedAt{ get; set; }
        public int updatedBy{ get; set; }
    }
}