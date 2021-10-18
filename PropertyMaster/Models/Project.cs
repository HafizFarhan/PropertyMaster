using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string details{ get; set; }
        public bool deleted{ get; set; }
        public DateTime datetime{ get; set; }
        public DateTime updatedAt{ get; set; }
    }
}