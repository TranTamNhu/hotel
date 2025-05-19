namespace PhanMemQuanLyKhachSan.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Globalization;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        private const string DATE_FORMAT = "dd/MM/yyyy";
        private static readonly CultureInfo DATE_CULTURE = CultureInfo.InvariantCulture;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int HoaDonID { get; set; }

        public int? NhanVienID { get; set; }

        public int? KhachHangID { get; set; }

        public int? PhongID { get; set; }

        [StringLength(15)]
        public string TenLoai { get; set; }

        public int? SoDem { get; set; }

        public int? SoKhach { get; set; }

        [StringLength(15)]
        public string NgayHD { get; set; }

        public int? TongTien { get; set; }

        public int? BookingID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Phong Phong { get; set; }

        public static List<HoaDon> GetAll()
        {
            using (var context = new QLKSModel())
            {
                return context.HoaDons
                    .Include(h => h.KhachHang)
                    .Include(h => h.NhanVien)
                    .Include(h => h.Phong)
                    .Include(h => h.ChiTietHoaDons)
                    .ToList();
            }
        }

        public static HoaDon GetHoaDon(int hoaDonId)
        {
            using (var context = new QLKSModel())
            {
                return context.HoaDons
                    .Include(h => h.KhachHang)
                    .Include(h => h.NhanVien)
                    .Include(h => h.Phong)
                    .Include(h => h.ChiTietHoaDons.Select(ct => ct.DichVu))
                    .FirstOrDefault(p => p.HoaDonID == hoaDonId);
            }
        }

        public static HoaDon GetHoaDonByPhong(int? phongId)
        {
            using (var context = new QLKSModel())
            {
                return context.HoaDons
                    .Include(h => h.KhachHang)
                    .Include(h => h.NhanVien)
                    .Include(h => h.Phong)
                    .Include(h => h.ChiTietHoaDons.Select(ct => ct.DichVu))
                    .Where(p => p.PhongID == phongId)
                    .OrderByDescending(p => p.HoaDonID)
                    .FirstOrDefault();
            }
        }

        public int InsertUpdate()
        {
            try
            {
                using (var context = new QLKSModel())
                {
                    // Validate required fields
                    if (!PhongID.HasValue)
                        throw new Exception("PhongID is required");
                    if (!KhachHangID.HasValue)
                        throw new Exception("KhachHangID is required");
                    if (string.IsNullOrWhiteSpace(NgayHD))
                        throw new Exception("NgayHD is required");

                    // Validate date format
                    if (!DateTime.TryParseExact(NgayHD, DATE_FORMAT, DATE_CULTURE, DateTimeStyles.None, out _))
                        throw new Exception($"NgayHD must be in format {DATE_FORMAT}");

                    // Check if the room exists
                    var phong = context.Phongs.Find(PhongID.Value);
                    if (phong == null)
                        throw new Exception($"Room with ID {PhongID.Value} not found");

                    // Check if the customer exists
                    var khachHang = context.KhachHangs.Find(KhachHangID.Value);
                    if (khachHang == null)
                        throw new Exception($"Customer with ID {KhachHangID.Value} not found");

                    // Add or update the invoice
                    context.HoaDons.AddOrUpdate(this);
                    context.SaveChanges();

                    // Update room status
                    phong.TrangThai = Phong.TrangThaiPhong.DangO;
                    context.SaveChanges();

                    return HoaDonID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in HoaDon.InsertUpdate: {ex.Message}");
                throw;
            }
        }

        public static HoaDon GetHoaDonByPhongID(int phongId)
        {
            try
            {
                using (var context = new QLKSModel())
                {
                    // Kiểm tra trạng thái phòng trước
                    var phong = context.Phongs.Find(phongId);
                    if (phong == null || phong.TrangThai != "Đang ở")
                    {
                        return null;
                    }

                    // Chỉ lấy hóa đơn của phòng đang có khách ở
                    return context.HoaDons
                        .Include(h => h.KhachHang)
                        .Include(h => h.NhanVien)
                        .Include(h => h.Phong)
                        .Include(h => h.Phong.LoaiPhong)
                        .Include(h => h.ChiTietHoaDons.Select(ct => ct.DichVu))
                        .Where(h => h.PhongID == phongId)
                        .OrderByDescending(h => h.HoaDonID)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting invoice by room ID: {ex.Message}");
                return null;
            }
        }
    }
}
