namespace ZadatakFaktureMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispravakcijene : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FakturaStavkaViews", "KolicinskaCijena", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FakturaStavkaViews", "KolicinskaCijena", c => c.Int(nullable: false));
        }
    }
}
