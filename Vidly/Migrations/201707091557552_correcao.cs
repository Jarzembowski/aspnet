namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "genreid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "genreid", c => c.Byte(nullable: false));
        }
    }
}
