using System;
using System.Data.Entity;
using System.Linq;
using SystemSrodkowTrwalych.Models;

namespace SystemSrodkowTrwalych.DAL
{
    public class FixedAssetsContext : DbContext
    {
       
        public FixedAssetsContext()
            : base("name=FixedAssetsContext")
        {
            Database.SetInitializer<FixedAssetsContext>(new DropCreateDatabaseIfModelChanges<FixedAssetsContext>());
         
        
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Raports> Raports { get; set; }

        public DbSet<FixedAssets> FixedAssets  { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Amortization> Amortization { get; set; }

        public DbSet<AmortizationRow> AmortizationRows { get; set; }
    }

   
}