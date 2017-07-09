namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres(name) values('Action')");
            Sql("insert into genres(name) values('Drama')");
            Sql("insert into genres(name) values('Sci-fi')");
            Sql("insert into genres(name) values('Comedy')");
            Sql("insert into genres(name) values('Documentary')");
        }
        
        public override void Down()
        {
        }
    }
}
