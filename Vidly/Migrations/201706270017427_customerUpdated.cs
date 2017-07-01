namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "birthDay", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "birthDay");
        }
    }
}
