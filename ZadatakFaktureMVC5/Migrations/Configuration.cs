namespace ZadatakFaktureMVC5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZadatakFaktureMVC5.DatabaseModels;

    internal sealed class Configuration : DbMigrationsConfiguration<ZadatakFaktureMVC5.DataContext.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(DataContext.ApplicationDbContext context)
        {
            context.Stavka.AddOrUpdate(x => x.Id,
                new Stavka()
                {
                    Id = 1,
                    Opis = "Telekomunikacijske usluge",
                    Cijena = 450

                },
                 new Stavka()
                 {
                     Id = 2,
                     Opis = "Usluge èišæenja",
                     Cijena = 150

                 },
                  new Stavka()
                  {
                      Id = 3,
                      Opis = "Montiranje vrata",
                      Cijena = 200

                  },
                   new Stavka()
                   {
                       Id = 4,
                       Opis = "Montiranje prozora",
                       Cijena = 499

                   },
                    new Stavka()
                    {
                        Id = 5,
                        Opis = "SamsungTV",
                        Cijena = 800

                    },
                     new Stavka()
                     {
                         Id = 6,
                         Opis = "ASUS Prijenosno raèunalo",
                         Cijena = 4500

                     },
                      new Stavka()
                      {
                          Id = 7,
                          Opis = "HP Prijenosno raèunalo",
                          Cijena = 3900

                      },
                       new Stavka()
                       {
                           Id = 8,
                           Opis = "BENQ Monitor",
                           Cijena = 999

                       }
                );
        }
    }
}
