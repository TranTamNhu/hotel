namespace PhanMemQuanLyKhachSan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        TenBooking = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BookingID);
            
            CreateTable(
                "dbo.ChiTietHoaDon",
                c => new
                    {
                        ChiTietHoaDonID = c.Int(nullable: false, identity: true),
                        HoaDonID = c.Int(),
                        DichVuID = c.Int(),
                        GiaDV = c.Int(),
                        SoLuong = c.Int(),
                        ThanhTien = c.Int(),
                    })
                .PrimaryKey(t => t.ChiTietHoaDonID)
                .ForeignKey("dbo.DichVu", t => t.DichVuID)
                .ForeignKey("dbo.HoaDon", t => t.HoaDonID)
                .Index(t => t.HoaDonID)
                .Index(t => t.DichVuID);
            
            CreateTable(
                "dbo.DichVu",
                c => new
                    {
                        DichVuID = c.Int(nullable: false, identity: true),
                        TenDV = c.String(maxLength: 50),
                        GiaDV = c.Int(),
                    })
                .PrimaryKey(t => t.DichVuID);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        HoaDonID = c.Int(nullable: false, identity: true),
                        NhanVienID = c.Int(),
                        KhachHangID = c.Int(),
                        PhongID = c.Int(),
                        TenLoai = c.String(maxLength: 15, unicode: false),
                        SoDem = c.Int(),
                        SoKhach = c.Int(),
                        NgayHD = c.String(maxLength: 15, unicode: false),
                        TongTien = c.Int(),
                        BookingID = c.Int(),
                    })
                .PrimaryKey(t => t.HoaDonID)
                .ForeignKey("dbo.KhachHang", t => t.KhachHangID)
                .ForeignKey("dbo.NhanVien", t => t.NhanVienID)
                .ForeignKey("dbo.Phong", t => t.PhongID)
                .Index(t => t.NhanVienID)
                .Index(t => t.KhachHangID)
                .Index(t => t.PhongID);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        KhachHangID = c.Int(nullable: false, identity: true),
                        TenKH = c.String(maxLength: 50),
                        QuocTich = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.KhachHangID);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        NhanVienID = c.Int(nullable: false, identity: true),
                        TenNV = c.String(maxLength: 50),
                        PathImage = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.NhanVienID);
            
            CreateTable(
                "dbo.LichLamViec",
                c => new
                    {
                        LichLamViecID = c.Int(nullable: false, identity: true),
                        NhanVienID = c.Int(),
                        Ca = c.String(maxLength: 10),
                        Ngay = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.LichLamViecID)
                .ForeignKey("dbo.NhanVien", t => t.NhanVienID)
                .Index(t => t.NhanVienID);
            
            CreateTable(
                "dbo.Phong",
                c => new
                    {
                        PhongID = c.Int(nullable: false, identity: true),
                        LoaiPhongID = c.Int(),
                        GiaPhong = c.Int(),
                    })
                .PrimaryKey(t => t.PhongID)
                .ForeignKey("dbo.LoaiPhong", t => t.LoaiPhongID)
                .Index(t => t.LoaiPhongID);
            
            CreateTable(
                "dbo.LoaiPhong",
                c => new
                    {
                        LoaiPhongID = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.LoaiPhongID);
            
            CreateTable(
                "dbo.MatKhau",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.username);
            
            CreateTable(
                "dbo.VatTu",
                c => new
                    {
                        VatTuID = c.Int(nullable: false, identity: true),
                        TenVT = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.VatTuID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phong", "LoaiPhongID", "dbo.LoaiPhong");
            DropForeignKey("dbo.HoaDon", "PhongID", "dbo.Phong");
            DropForeignKey("dbo.LichLamViec", "NhanVienID", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDon", "NhanVienID", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDon", "KhachHangID", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietHoaDon", "HoaDonID", "dbo.HoaDon");
            DropForeignKey("dbo.ChiTietHoaDon", "DichVuID", "dbo.DichVu");
            DropIndex("dbo.Phong", new[] { "LoaiPhongID" });
            DropIndex("dbo.LichLamViec", new[] { "NhanVienID" });
            DropIndex("dbo.HoaDon", new[] { "PhongID" });
            DropIndex("dbo.HoaDon", new[] { "KhachHangID" });
            DropIndex("dbo.HoaDon", new[] { "NhanVienID" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "DichVuID" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "HoaDonID" });
            DropTable("dbo.VatTu");
            DropTable("dbo.MatKhau");
            DropTable("dbo.LoaiPhong");
            DropTable("dbo.Phong");
            DropTable("dbo.LichLamViec");
            DropTable("dbo.NhanVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.HoaDon");
            DropTable("dbo.DichVu");
            DropTable("dbo.ChiTietHoaDon");
            DropTable("dbo.Booking");
        }
    }
}
