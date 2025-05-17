namespace PhanMemQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrangThaiPhong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phong", "TrangThai", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phong", "TrangThai");
        }
    }
} 