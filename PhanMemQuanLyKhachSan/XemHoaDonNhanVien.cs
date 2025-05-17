using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemQuanLyKhachSan.Model;

namespace PhanMemQuanLyKhachSan
{
    public partial class XemHoaDonNhanVien : Form
    {
        private QLKSModel context;
        private int nhanVienId;

        public XemHoaDonNhanVien(int nhanVienId)
        {
            InitializeComponent();
            context = new QLKSModel();
            this.nhanVienId = nhanVienId;
            LoadHoaDon();
            SetGridViewStyle(dgvHoaDon);
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

        private void LoadHoaDon()
        {
            try
            {
                var hoaDons = context.HoaDons
                    .Include(h => h.Phong)
                    .Include(h => h.Phong.LoaiPhong)
                    .Include(h => h.KhachHang)
                    .Where(h => h.NhanVienID == nhanVienId)
                    .Select(h => new
                    {
                        h.HoaDonID,
                        h.NgayHD,
                        h.TongTien,
                        TenKhachHang = h.KhachHang.TenKH,
                        TenPhong = h.Phong != null && h.Phong.LoaiPhong != null 
                            ? $"Phòng {h.PhongID} - {h.Phong.LoaiPhong.TenLoai}" 
                            : $"Phòng {h.PhongID}",
                        h.SoKhach,
                        h.SoDem
                    })
                    .ToList();

                dgvHoaDon.DataSource = hoaDons;

                // Đặt tiêu đề cho các cột
                dgvHoaDon.Columns["HoaDonID"].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns["NgayHD"].HeaderText = "Ngày lập";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                dgvHoaDon.Columns["TenPhong"].HeaderText = "Phòng";
                dgvHoaDon.Columns["SoKhach"].HeaderText = "Số khách";
                dgvHoaDon.Columns["SoDem"].HeaderText = "Số đêm";

                // Format số tiền
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "#,##0 VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                int hoaDonId = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["HoaDonID"].Value);
                XemChiTietHoaDon formChiTiet = new XemChiTietHoaDon(hoaDonId);
                formChiTiet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 