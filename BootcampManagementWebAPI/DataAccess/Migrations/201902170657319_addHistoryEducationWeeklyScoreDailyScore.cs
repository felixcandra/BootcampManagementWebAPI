namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHistoryEducationWeeklyScoreDailyScore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Score1 = c.Int(),
                        Score2 = c.Int(),
                        Score3 = c.Int(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .Index(t => t.Employees_Id);
            
            CreateTable(
                "dbo.HistoryEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Degree = c.String(),
                        StudyProgram = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        Ipk = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Universities_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Universities", t => t.Universities_Id)
                .Index(t => t.Universities_Id);
            
            CreateTable(
                "dbo.WeeklyScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Score1 = c.Int(),
                        Score2 = c.Int(),
                        Score3 = c.Int(),
                        Score4 = c.Int(),
                        Score5 = c.Int(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .Index(t => t.Employees_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeeklyScores", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.HistoryEducations", "Universities_Id", "dbo.Universities");
            DropForeignKey("dbo.DailyScores", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.WeeklyScores", new[] { "Employees_Id" });
            DropIndex("dbo.HistoryEducations", new[] { "Universities_Id" });
            DropIndex("dbo.DailyScores", new[] { "Employees_Id" });
            DropTable("dbo.WeeklyScores");
            DropTable("dbo.HistoryEducations");
            DropTable("dbo.DailyScores");
        }
    }
}
