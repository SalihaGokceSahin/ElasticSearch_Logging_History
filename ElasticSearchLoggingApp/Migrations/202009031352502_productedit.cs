namespace ElasticSearchLoggingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productedit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.products", "categories_id", "dbo.categories");
            DropIndex("dbo.products", new[] { "categories_id" });
            AddColumn("dbo.products", "categories_id1", c => c.Int());
            AlterColumn("dbo.products", "categories_id", c => c.Int(nullable: false));
            CreateIndex("dbo.products", "categories_id1");
            AddForeignKey("dbo.products", "categories_id1", "dbo.categories", "id");
            DropColumn("dbo.products", "category_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.products", "category_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.products", "categories_id1", "dbo.categories");
            DropIndex("dbo.products", new[] { "categories_id1" });
            AlterColumn("dbo.products", "categories_id", c => c.Int());
            DropColumn("dbo.products", "categories_id1");
            CreateIndex("dbo.products", "categories_id");
            AddForeignKey("dbo.products", "categories_id", "dbo.categories", "id");
        }
    }
}
