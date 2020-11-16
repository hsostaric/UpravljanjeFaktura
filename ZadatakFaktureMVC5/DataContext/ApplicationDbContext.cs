using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZadatakFaktureMVC5.DatabaseModels;

namespace ZadatakFaktureMVC5.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Faktura> Faktura { get; set; }
        public DbSet<Stavka> Stavka { get; set; }
        public DbSet<FakturaStavkaView> FakturaStavkaViews { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}