namespace ElasticSearchLoggingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productchange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        category_id = c.Int(nullable: false),
                        name = c.String(),
                        MyProperty = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        count = c.Byte(nullable: false),
                        categories_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.categories", t => t.categories_id)
                .Index(t => t.categories_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "categories_id", "dbo.categories");
            DropIndex("dbo.products", new[] { "categories_id" });
            DropTable("dbo.products");
            DropTable("dbo.categories");
        }
    }
}
