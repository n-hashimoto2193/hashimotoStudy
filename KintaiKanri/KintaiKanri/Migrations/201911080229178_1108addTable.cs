namespace KintaiKanri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1108_busho : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Syains",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        SyainName = c.String(nullable: false),
                        No = c.String(),
                        Email = c.String(nullable: false),
                        Busho_Id = c.Long(),
                        Role_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bushoes", t => t.Busho_Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Busho_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kintais",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RecordingDate = c.DateTime(nullable: false),
                        Syain_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Syains", t => t.Syain_Id)
                .Index(t => t.Syain_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kintais", "Syain_Id", "dbo.Syains");
            DropForeignKey("dbo.Syains", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Syains", "Busho_Id", "dbo.Bushoes");
            DropIndex("dbo.Kintais", new[] { "Syain_Id" });
            DropIndex("dbo.Syains", new[] { "Role_Id" });
            DropIndex("dbo.Syains", new[] { "Busho_Id" });
            DropTable("dbo.Kintais");
            DropTable("dbo.Roles");
            DropTable("dbo.Syains");
        }
    }
}
