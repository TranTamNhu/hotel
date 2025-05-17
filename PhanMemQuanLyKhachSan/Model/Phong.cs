namespace PhanMemQuanLyKhachSan.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Phong")]
    public partial class Phong
    {
        public static class TrangThaiPhong
        {
            public const string Trong = "Trống";      // Phòng trống
            public const string DangO = "Đang ở";      // Đang có khách ở
            public const string DaDat = "Đã đặt";      // Đã đặt trước
            public const string BaoTri = "Bảo trì";    // Đang bảo trì
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            HoaDons = new HashSet<HoaDon>();
            TrangThai = TrangThaiPhong.Trong; // Mặc định là phòng trống
        }

        public int PhongID { get; set; }

        public int? LoaiPhongID { get; set; }

        public int? GiaPhong { get; set; }

        [StringLength(30)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        public static List<Phong> GetAll()
        {
            using (var context = new QLKSModel())
            {
                return context.Phongs
                          .Include(p => p.LoaiPhong)
                          .ToList();
            }
        }

        public static List<Phong> GetAll(int loaiPhong)
        {
            using (var context = new QLKSModel())
            {
                return context.Phongs.Where(p => p.LoaiPhongID == loaiPhong).ToList();
            }
        }

        public static Phong GetPhong(int phongId)
        {
            using (var context = new QLKSModel())
            {
                return context.Phongs
                          .Include(p => p.LoaiPhong)
                          .FirstOrDefault(p => p.PhongID == phongId);
            }
        }

        public void InsertUpdate()
        {
            using (var context = new QLKSModel())
            {
                var phong = context.Phongs.FirstOrDefault(p => p.PhongID == this.PhongID);
                if (phong != null)
                {
                    phong.LoaiPhongID = this.LoaiPhongID;
                    phong.GiaPhong = this.GiaPhong;
                    phong.TrangThai = this.TrangThai;
                }
                else
                {
                    context.Phongs.Add(this);
                }
                context.SaveChanges();
            }
        }

        public void CapNhatTrangThai(string trangThaiMoi)
        {
            using (var context = new QLKSModel())
            {
                var phong = context.Phongs.FirstOrDefault(p => p.PhongID == this.PhongID);
                if (phong != null)
                {
                    phong.TrangThai = trangThaiMoi; 
                    context.SaveChanges();
                    this.TrangThai = trangThaiMoi;
                }
            }
        }
    }
}
