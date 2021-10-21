using PropertyMaster.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PropertyMaster.DAL
{
    public class DbAccess:DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LandAcquisition> LandAcquisitions { get; set; }
        public DbSet<LandAcquisitionAccount> LandAcquisitionsAccount { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<LandAcqAP> LandAcqAP { get; set; }
        public DbSet<LandAcqAR> LandAcqAR { get; set; }
    }
}