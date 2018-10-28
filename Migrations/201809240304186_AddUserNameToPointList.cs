namespace StudyPoints.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameToPointList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PointLists", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PointLists", "UserName");
        }
    }
}
