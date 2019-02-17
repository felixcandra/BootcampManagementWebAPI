namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Date_Of_Birth = c.DateTimeOffset(nullable: false, precision: 7),
                        Place_Of_Birth = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Secret_Question = c.String(),
                        Secret_Answer = c.String(),
                        Role = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Religions_Id = c.Int(),
                        Villages_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Religions", t => t.Religions_Id)
                .ForeignKey("dbo.Villages", t => t.Villages_Id)
                .Index(t => t.Religions_Id)
                .Index(t => t.Villages_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Employees", "Religions_Id", "dbo.Religions");
            DropIndex("dbo.Employees", new[] { "Villages_Id" });
            DropIndex("dbo.Employees", new[] { "Religions_Id" });
            DropTable("dbo.Employees");
        }
    }
}
