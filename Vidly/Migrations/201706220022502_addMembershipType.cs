namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        id = c.Byte(nullable: false),
                        signUpFee = c.Short(nullable: false),
                        durationInMonths = c.Byte(nullable: false),
                        discountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Customers", "membershipTypeid", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "membershipTypeid");
            AddForeignKey("dbo.Customers", "membershipTypeid", "dbo.MembershipTypes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membershipTypeid", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "membershipTypeid" });
            DropColumn("dbo.Customers", "membershipTypeid");
            DropTable("dbo.MembershipTypes");
        }
    }
}
