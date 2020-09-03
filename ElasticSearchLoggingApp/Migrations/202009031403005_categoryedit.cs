namespace ElasticSearchLoggingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryedit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.categories", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.categories", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
