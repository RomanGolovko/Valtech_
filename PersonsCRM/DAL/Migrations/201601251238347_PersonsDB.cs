namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonsDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "PersonId", "dbo.People");
            DropIndex("dbo.Phones", new[] { "PersonId" });
            AlterColumn("dbo.Phones", "PersonId", c => c.Int());
            CreateIndex("dbo.Phones", "PersonId");
            AddForeignKey("dbo.Phones", "PersonId", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "PersonId", "dbo.People");
            DropIndex("dbo.Phones", new[] { "PersonId" });
            AlterColumn("dbo.Phones", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Phones", "PersonId");
            AddForeignKey("dbo.Phones", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
