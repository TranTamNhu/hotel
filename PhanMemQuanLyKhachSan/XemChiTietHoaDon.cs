using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemQuanLyKhachSan.Model;
using System.Data.Entity;

namespace PhanMemQuanLyKhachSan
{
    public partial class XemChiTietHoaDon : Form
    {
        private QLKSModel context;
        private int hoaDonId;

        public XemChiTietHoaDon(int hoaDonId)
        {
            InitializeComponent();
            context = new QLKSModel();
            this.hoaDonId = hoaDonId;
            LoadChiTietHoaDon();
            SetGridViewStyle(dgvChiTietHoaDon);
        }

        public void SetGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgview.BackgroundColor = Color.White;
            dgview.EnableHeadersVisualStyles = false;
            dgview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgview.AllowUserToDeleteRows = false;
            dgview.AllowUserToAddRows = false;
            dgview.AllowUserToOrderColumns = true;
            dgview.MultiSelect = false;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadChiTietHoaDon()
        {
            try
            {
                // Lấy thông tin hóa đơn
                var hoaDon = context.HoaDons
                    .Include(h => h.Phong)
                    .Include(h => h.Phong.LoaiPhong)
                    .Include(h => h.KhachHang)
                    .Include(h => h.NhanVien)
                    .FirstOrDefault(h => h.HoaDonID == hoaDonId);

                if (hoaDon != null)
                {
                    lblNgayLap.Text = hoaDon.NgayHD;
                    lblTongTien.Text = hoaDon.TongTien.HasValue ? hoaDon.TongTien.Value.ToString("#,##0 VNĐ") : "0 VNĐ";
                    lblKhachHang.Text = hoaDon.KhachHang?.TenKH ?? "Không có thông tin";
                    lblNhanVien.Text = hoaDon.NhanVien?.TenNV ?? "Không có thông tin";

                    // Hiển thị thông tin phòng
                    if (hoaDon.Phong != null && hoaDon.Phong.LoaiPhong != null)
                    {
                        lblPhong.Text = $"Phòng {hoaDon.PhongID} - {hoaDon.Phong.LoaiPhong.TenLoai}";
                    }
                    else
                    {
                        lblPhong.Text = $"Phòng {hoaDon.PhongID}";
                    }

                    lblSoKhach.Text = hoaDon.SoKhach.HasValue ? hoaDon.SoKhach.Value.ToString() + " khách" : "0 khách";
                    lblSoDem.Text = hoaDon.SoDem.HasValue ? hoaDon.SoDem.Value.ToString() + " đêm" : "0 đêm";
                }

                // Lấy chi tiết hóa đơn
                var chiTietHoaDon = context.ChiTietHoaDons
                    .Include(ct => ct.DichVu)
                    .Where(ct => ct.HoaDonID == hoaDonId)
                    .Select(ct => new
                    {
                        TenDichVu = ct.DichVu.TenDV,
                        ct.SoLuong,
                        ct.GiaDV,
                        ThanhTien = ct.SoLuong * ct.GiaDV
                    })
                    .ToList();

                dgvChiTietHoaDon.DataSource = chiTietHoaDon;

                // Đặt tiêu đề cho các cột
                dgvChiTietHoaDon.Columns["TenDichVu"].HeaderText = "Tên dịch vụ";
                dgvChiTietHoaDon.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvChiTietHoaDon.Columns["GiaDV"].HeaderText = "Đơn giá";
                dgvChiTietHoaDon.Columns["ThanhTien"].HeaderText = "Thành tiền";

                // Format số tiền
                dgvChiTietHoaDon.Columns["GiaDV"].DefaultCellStyle.Format = "#,##0 VNĐ";
                dgvChiTietHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "#,##0 VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 