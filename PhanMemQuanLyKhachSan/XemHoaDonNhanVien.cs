using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhanMemQuanLyKhachSan.Model;
using System.Data.Entity;

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
                var hoaDons = context.HoaDons                         // truy cập vào bảng hoá đơn
                    .Include(h => h.Phong)                           //tải thông tin phòng cùng với hoá đơn
                    .Include(h => h.Phong.LoaiPhong)
                    .Include(h => h.KhachHang)
                    .Where(h => h.NhanVienID == nhanVienId)                //lọc hoá đơn theo id của nhân viên
                    .Select(h => new                             //Ánh xạ kết quả thành đối tượng ẩn danh mới với các thuộc tính cần thiết
                    {
                        h.HoaDonID,
                        h.NgayHD,
                        h.TongTien,
                        TenKhachHang = h.KhachHang.TenKH,
                        PhongID = h.PhongID,
                        TenLoaiPhong = h.Phong.LoaiPhong.TenLoai,
                        h.SoKhach,
                        h.SoDem
                    })
                    .ToList()
                    .Select(h => new
                    {
                        h.HoaDonID,
                        h.NgayHD,
                        h.TongTien,
                        h.TenKhachHang,
                        TenPhong = string.IsNullOrEmpty(h.TenLoaiPhong)
                            ? $"Phòng {h.PhongID}"
                            : $"Phòng {h.PhongID} - {h.TenLoaiPhong}",
                        h.SoKhach,
                        h.SoDem
                    })
                    .ToList();                 //thực thi truy vấn chuyển thành ds

                dgvHoaDon.DataSource = hoaDons;

                dgvHoaDon.Columns["HoaDonID"].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns["NgayHD"].HeaderText = "Ngày lập";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvHoaDon.Columns["TenKhachHang"].HeaderText = "Khách hàng";
                dgvHoaDon.Columns["TenPhong"].HeaderText = "Phòng";
                dgvHoaDon.Columns["SoKhach"].HeaderText = "Số khách";
                dgvHoaDon.Columns["SoDem"].HeaderText = "Số đêm";

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
                int hoaDonId = Convert.ToInt32(dgvHoaDon.SelectedRows[0].Cells["HoaDonID"].Value);  //lấy giá trị hoá đơn id được chon

                XemChiTietHoaDon formChiTiet = new XemChiTietHoaDon(hoaDonId);           //mở form chi tiết vs id hoá đơn đó
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
