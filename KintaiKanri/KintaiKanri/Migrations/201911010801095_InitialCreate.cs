namespace KintaiKanri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bushoes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BushoName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bushoes");
        }
    }
}
