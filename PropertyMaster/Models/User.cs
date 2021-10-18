using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyMaster.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nic { get; set; }
        public string cell { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool deleted { get; set; }

        public UserType usertype{ get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public DateTime datetime { get; set; }
    }

    public enum UserType
    {
        Admin,
        Customer,
        Acquisition,
        Dealer
    }
}