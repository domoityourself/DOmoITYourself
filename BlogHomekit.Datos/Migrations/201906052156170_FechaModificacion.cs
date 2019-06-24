namespace BlogHomekit.Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaModificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "FechaModificacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "FechaModificacion");
        }
    }
}
