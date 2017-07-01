namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerUpdated2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "birthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "birthDay", c => c.DateTime(nullable: false));
        }
    }
}
