namespace ZadatakFaktureMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FakturaStavkaViews", name: "StavkaID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.FakturaStavkaViews", name: "FakturaID", newName: "StavkaID");
            RenameColumn(table: "dbo.FakturaStavkaViews", name: "__mig_tmp__0", newName: "FakturaID");
            RenameIndex(table: "dbo.FakturaStavkaViews", name: "IX_StavkaID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.FakturaStavkaViews", name: "IX_FakturaID", newName: "IX_StavkaID");
            RenameIndex(table: "dbo.FakturaStavkaViews", name: "__mig_tmp__0", newName: "IX_FakturaID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FakturaStavkaViews", name: "IX_FakturaID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.FakturaStavkaViews", name: "IX_StavkaID", newName: "IX_FakturaID");
            RenameIndex(table: "dbo.FakturaStavkaViews", name: "__mig_tmp__0", newName: "IX_StavkaID");
            RenameColumn(table: "dbo.FakturaStavkaViews", name: "FakturaID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.FakturaStavkaViews", name: "StavkaID", newName: "FakturaID");
            RenameColumn(table: "dbo.FakturaStavkaViews", name: "__mig_tmp__0", newName: "StavkaID");
        }
    }
}
