namespace ZadatakFaktureMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fakturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumStvaranja = c.DateTime(nullable: false),
                        DatumDospijeća = c.DateTime(nullable: false),
                        CijenaPDV = c.Double(nullable: false),
                        CijenaBezPDV = c.Double(nullable: false),
                        PrimateljRacuna = c.String(),
                        VrstaPDV = c.Int(nullable: false),
                        Spremljeno = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Stavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Opis = c.String(nullable: false, maxLength: 255),
                        Cijena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FakturaStavkaViews",
                c => new
                    {
                        FakturaID = c.Int(nullable: false),
                        StavkaID = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        KolicinskaCijena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FakturaID, t.StavkaID })
                .ForeignKey("dbo.Fakturas", t => t.StavkaID, cascadeDelete: true)
                .ForeignKey("dbo.Stavkas", t => t.FakturaID, cascadeDelete: true)
                .Index(t => t.FakturaID)
                .Index(t => t.StavkaID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StavkaFakturas",
                c => new
                    {
                        Stavka_Id = c.Int(nullable: false),
                        Faktura_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stavka_Id, t.Faktura_Id })
                .ForeignKey("dbo.Stavkas", t => t.Stavka_Id, cascadeDelete: true)
                .ForeignKey("dbo.Fakturas", t => t.Faktura_Id, cascadeDelete: true)
                .Index(t => t.Stavka_Id)
                .Index(t => t.Faktura_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FakturaStavkaViews", "FakturaID", "dbo.Stavkas");
            DropForeignKey("dbo.FakturaStavkaViews", "StavkaID", "dbo.Fakturas");
            DropForeignKey("dbo.StavkaFakturas", "Faktura_Id", "dbo.Fakturas");
            DropForeignKey("dbo.StavkaFakturas", "Stavka_Id", "dbo.Stavkas");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fakturas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.StavkaFakturas", new[] { "Faktura_Id" });
            DropIndex("dbo.StavkaFakturas", new[] { "Stavka_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FakturaStavkaViews", new[] { "StavkaID" });
            DropIndex("dbo.FakturaStavkaViews", new[] { "FakturaID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Fakturas", new[] { "UserId" });
            DropTable("dbo.StavkaFakturas");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FakturaStavkaViews");
            DropTable("dbo.Stavkas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Fakturas");
        }
    }
}
