namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Batches_Id = c.Int(),
                        Departments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.Batches_Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .Index(t => t.Batches_Id)
                .Index(t => t.Departments_Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Villages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Districts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.Districts_Id)
                .Index(t => t.Districts_Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Regencies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regencies", t => t.Regencies_Id)
                .Index(t => t.Regencies_Id);
            
            CreateTable(
                "dbo.Regencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Provinces_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.Provinces_Id)
                .Index(t => t.Provinces_Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Description = c.String(),
                        Solution = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Departments_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Departments_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        PlaceOfBirth = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Status = c.String(),
                        SecretQuestion = c.String(),
                        SecretAnswer = c.String(),
                        HiringLocation = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Classes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Classes_Id)
                .Index(t => t.Classes_Id);
            
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
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Villages_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Villages", t => t.Villages_Id)
                .Index(t => t.Villages_Id);
            
            CreateTable(
                "dbo.HistoryPlacements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        Description = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Placements_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Placements", t => t.Placements_Id)
                .Index(t => t.Placements_Id);
            
            CreateTable(
                "dbo.Placements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        LinkFile = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Departments_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Departments_Id)
                .Index(t => t.Departments_Id);
            
            CreateTable(
                "dbo.Lockers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        Location = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Classes_Id = c.Int(),
                        Lessons_Id = c.Int(),
                        Rooms_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Classes_Id)
                .ForeignKey("dbo.Lessons", t => t.Lessons_Id)
                .ForeignKey("dbo.Rooms", t => t.Rooms_Id)
                .Index(t => t.Classes_Id)
                .Index(t => t.Lessons_Id)
                .Index(t => t.Rooms_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Skills_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.Skills_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Skills_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.StudentAccesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentLockers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.String(),
                        DateStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DateEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeeklyScores", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.SkillStudents", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.SkillStudents", "Skills_Id", "dbo.Skills");
            DropForeignKey("dbo.Schedules", "Rooms_Id", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "Lessons_Id", "dbo.Lessons");
            DropForeignKey("dbo.Schedules", "Classes_Id", "dbo.Classes");
            DropForeignKey("dbo.Lessons", "Departments_Id", "dbo.Departments");
            DropForeignKey("dbo.HistoryPlacements", "Placements_Id", "dbo.Placements");
            DropForeignKey("dbo.HistoryEducations", "Universities_Id", "dbo.Universities");
            DropForeignKey("dbo.Universities", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.ErrorBanks", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Classes_Id", "dbo.Classes");
            DropForeignKey("dbo.ErrorBanks", "Departments_Id", "dbo.Departments");
            DropForeignKey("dbo.DailyScores", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Villages", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.Districts", "Regencies_Id", "dbo.Regencies");
            DropForeignKey("dbo.Regencies", "Provinces_Id", "dbo.Provinces");
            DropForeignKey("dbo.Employees", "Religions_Id", "dbo.Religions");
            DropForeignKey("dbo.Classes", "Departments_Id", "dbo.Departments");
            DropForeignKey("dbo.Classes", "Batches_Id", "dbo.Batches");
            DropIndex("dbo.WeeklyScores", new[] { "Employees_Id" });
            DropIndex("dbo.SkillStudents", new[] { "Students_Id" });
            DropIndex("dbo.SkillStudents", new[] { "Skills_Id" });
            DropIndex("dbo.Schedules", new[] { "Rooms_Id" });
            DropIndex("dbo.Schedules", new[] { "Lessons_Id" });
            DropIndex("dbo.Schedules", new[] { "Classes_Id" });
            DropIndex("dbo.Lessons", new[] { "Departments_Id" });
            DropIndex("dbo.HistoryPlacements", new[] { "Placements_Id" });
            DropIndex("dbo.Universities", new[] { "Villages_Id" });
            DropIndex("dbo.HistoryEducations", new[] { "Universities_Id" });
            DropIndex("dbo.Students", new[] { "Classes_Id" });
            DropIndex("dbo.ErrorBanks", new[] { "Students_Id" });
            DropIndex("dbo.ErrorBanks", new[] { "Departments_Id" });
            DropIndex("dbo.Regencies", new[] { "Provinces_Id" });
            DropIndex("dbo.Districts", new[] { "Regencies_Id" });
            DropIndex("dbo.Villages", new[] { "Districts_Id" });
            DropIndex("dbo.Employees", new[] { "Villages_Id" });
            DropIndex("dbo.Employees", new[] { "Religions_Id" });
            DropIndex("dbo.DailyScores", new[] { "Employees_Id" });
            DropIndex("dbo.Classes", new[] { "Departments_Id" });
            DropIndex("dbo.Classes", new[] { "Batches_Id" });
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.WeeklyScores");
            DropTable("dbo.StudentLockers");
            DropTable("dbo.StudentAccesses");
            DropTable("dbo.SkillStudents");
            DropTable("dbo.Skills");
            DropTable("dbo.Schedules");
            DropTable("dbo.Rooms");
            DropTable("dbo.Organizations");
            DropTable("dbo.Lockers");
            DropTable("dbo.Lessons");
            DropTable("dbo.Placements");
            DropTable("dbo.HistoryPlacements");
            DropTable("dbo.Universities");
            DropTable("dbo.HistoryEducations");
            DropTable("dbo.Students");
            DropTable("dbo.ErrorBanks");
            DropTable("dbo.Provinces");
            DropTable("dbo.Regencies");
            DropTable("dbo.Districts");
            DropTable("dbo.Villages");
            DropTable("dbo.Religions");
            DropTable("dbo.Employees");
            DropTable("dbo.DailyScores");
            DropTable("dbo.Departments");
            DropTable("dbo.Classes");
            DropTable("dbo.Batches");
            DropTable("dbo.Achievements");
            DropTable("dbo.Accesses");
        }
    }
}
