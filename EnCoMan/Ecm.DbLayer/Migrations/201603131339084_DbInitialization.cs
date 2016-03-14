namespace Ecm.DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbInitialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Short(nullable: false),
                        Name = c.String(nullable: false, maxLength: 64),
                        UserId = c.Int(nullable: false),
                        EnergyTypeId = c.Int(nullable: false),
                        Periodicity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EnergyTypeId);
            
            CreateTable(
                "dbo.EnergyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 256),
                        Unit = c.String(nullable: false, maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GETDATE()"),
                        Value = c.Double(nullable: false),
                        Note = c.String(maxLength: 512),
                        UserId = c.Int(nullable: false),
                        EnergyTypeId = c.Int(nullable: false),
                        Periodicity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnergyTypes", t => t.EnergyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EnergyTypeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.Id);

            

        }

        public override void Down()
        {
            DropForeignKey("dbo.Records", "UserId", "dbo.Users");
            DropForeignKey("dbo.Configurations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Records", "EnergyTypeId", "dbo.EnergyTypes");
            DropForeignKey("dbo.Configurations", "EnergyTypeId", "dbo.EnergyTypes");
            DropIndex("dbo.Records", new[] { "EnergyTypeId" });
            DropIndex("dbo.Records", new[] { "UserId" });
            DropIndex("dbo.Configurations", new[] { "EnergyTypeId" });
            DropIndex("dbo.Configurations", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Records");
            DropTable("dbo.EnergyTypes");
            DropTable("dbo.Configurations");
        }
    }
}
