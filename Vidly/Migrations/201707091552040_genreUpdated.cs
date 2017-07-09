namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "genreid", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "genreid");
        }
    }
}
