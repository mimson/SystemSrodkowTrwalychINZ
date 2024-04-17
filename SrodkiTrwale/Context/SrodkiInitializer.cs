using SrodkiTrwale.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SrodkiTrwale.Context
{
    public class SrodkiInitializer : DropCreateDatabaseIfModelChanges<SrodkiContext>
    {
        protected override void Seed(SrodkiContext context)
        {
            var kategorie = new List<Categories>
            {
                new Categories { CatTypes = "nieruchomości"},
                new Categories { CatTypes = "budynki"},
                new Categories { CatTypes = "urzadzenia techiczne/maszyny"},
                new Categories { CatTypes = "srodki transportu"},
                new Categories { CatTypes = "inne"}
            };
            kategorie.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var role = new List<UserRoles>
            {
                new UserRoles { Roletype = "Administrator"},
                new UserRoles { Roletype = "Pracownik"}
            };
            role.ForEach(ro => context.UserRoles.Add(ro));
            context.SaveChanges();

            var uzytkownicy = new List<Users>
            {
                new Users { FirstName = "Michał", LastName = "Wolski", Mail = "mw@op.pl",Password ="mw",UserRolesID=1},
                new Users { FirstName = "Maciej", LastName = "Wolski", Mail = "mac@op.pl",Password ="mac",UserRolesID=1},
                new Users { FirstName = "Bartosz", LastName = "Ruta", Mail = "br@op.pl",Password ="br",UserRolesID=1}
            };
            uzytkownicy.ForEach(u => context.Users.Add(u));
            context.SaveChanges();


            var srodki_trwale = new List<FixedAssets>
            {
                new FixedAssets { Name = "Ławka", DateOfCollections = new DateTime(2013, 6, 1, 12, 32, 30),CategoriesID=1,UserID=1,AmortizationValue =0.1m,PurchasePrice=1000,CurrentPrice=1000 },
                new FixedAssets { Name = "Komputer", DateOfCollections = new DateTime(2014, 6, 1, 12, 32, 30),CategoriesID=1,UserID=1 ,AmortizationValue =0.2m,PurchasePrice=1500,CurrentPrice=1000 },
                new FixedAssets { Name = "Sala", DateOfCollections = new DateTime(2014, 6, 1, 12, 32, 30),CategoriesID=1,UserID=1,AmortizationValue =0.3m,PurchasePrice=2000,CurrentPrice=1000  }
            };
            srodki_trwale.ForEach(st => context.FixedAssets.Add(st));
            context.SaveChanges();
            var amortization = new List<Amortization>
            {
                new Amortization {FixedAssetsID=1,AmortizationValue=12,Description="dsadsad",ModificationDate=DateTime.Now},
                 new Amortization {FixedAssetsID=2,AmortizationValue=12,Description="sadsad",ModificationDate=DateTime.Now},
                  new Amortization {FixedAssetsID=3,AmortizationValue=12,Description="dsadasdasdsad",ModificationDate=DateTime.Now}
            };
            amortization.ForEach(st => context.Amortization.Add(st));
            context.SaveChanges();

            var amortizationRows = new List<AmortizationRow>
            {
                new AmortizationRow {AmortizationId=1,FixedAssetId=1},
                 new AmortizationRow {AmortizationId=1,FixedAssetId=2},
                  new AmortizationRow {AmortizationId=1,FixedAssetId=3},

            };
            amortizationRows.ForEach(st => context.AmortizationRows.Add(st));
            context.SaveChanges();
            //var raporty = new List<Raports>
            //{
            //    new Raports { CreactionDate = new DateTime(2020, 6, 1, 12, 32, 30),Description = "aaa"},
            //    new Raports { CreactionDate = new DateTime(2020, 6, 1, 14, 32, 30),Description = "bbb"},
            //    new Raports { CreactionDate = new DateTime(2020, 6, 1, 13, 33, 30),Description = "ccc"}
            //};
            //raporty.ForEach(r => context.Raports.Add(r));
            //context.SaveChanges();



        }
    }
}