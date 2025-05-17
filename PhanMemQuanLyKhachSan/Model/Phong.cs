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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int PhongID { get; set; }

        public int? LoaiPhongID { get; set; }

        public int? GiaPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }
    }
    public partial class Phong
    {
     // THÊM dòng này trên đầu file nếu chưa có

public static List<Phong> GetAll()
    {
        using (var context = new QLKSModel())
        {
            return context.Phongs
                          .Include(p => p.LoaiPhong) // Eager load navigation property
                          .ToList();
        }
    }


    public static List<Phong> GetAll(int loaiPhong)
        {
            QLKSModel context = new QLKSModel();
            return context.Phongs.Where(p => p.LoaiPhongID == loaiPhong).ToList();
        }
        public static Phong GetPhong(int phongId)
        {
            using (var context = new QLKSModel())
            {
                return context.Phongs
                              .Include(p => p.LoaiPhong) // Load cả thông tin loại phòng
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
                    // Cập nhật thông tin nếu phòng đã tồn tại
                    phong.LoaiPhongID = this.LoaiPhongID;
                    phong.GiaPhong = this.GiaPhong;
                }
                else
                {
                    // Nếu chưa tồn tại thì thêm mới
                    context.Phongs.Add(this);
                }
                context.SaveChanges();
            }
        }


    }
}
