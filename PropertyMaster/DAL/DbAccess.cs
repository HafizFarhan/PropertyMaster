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
        public DbSet<Plot> Plots { get; set; }
        public DbSet<PlotEntry> PlotEntries { get; set; }
        public DbSet<PlotSale> PlotSales { get; set; }
        public DbSet<LandAcqAP> LandAcqAP { get; set; }
        public DbSet<LandAcqAR> LandAcqAR { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseEntry> ExpenseEntries { get; set; }
    }
}