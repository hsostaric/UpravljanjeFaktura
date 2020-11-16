namespace ZadatakFaktureMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.FaktureViews",
                 c => new
                 {
                     Id = c.Int(nullable: false, identity: true),
                     Spremljeno = c.Boolean(nullable: false),
                 })
                 .PrimaryKey(t => t.Id);
        }


    }
}
