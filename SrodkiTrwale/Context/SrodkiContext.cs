using SrodkiTrwale.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Context
{
    public class SrodkiContext : DbContext
    {
        public SrodkiContext():base("SrodkiCS")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Raports> Raports { get; set; }

        public DbSet<FixedAssets> FixedAssets { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Amortization> Amortization { get; set; }

        public DbSet<AmortizationRow> AmortizationRows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}