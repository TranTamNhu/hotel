using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PhanMemQuanLyKhachSan.Model;
using System.Data.Entity;

namespace PhanMemQuanLyKhachSan
{
    public partial class XemChiTietHoaDon : Form
    {
        private QLKSModel context;
        private int hoaDonId;

        public XemChiTietHoaDon(int hoaDonId)                                 // constructor được gọi nhân vào id để hiển thị
        {
            InitializeComponent();
            context = new QLKSModel();                    //khởi tạo đối tương kêt nối csdl
            this.hoaDonId = hoaDonId;
            SetupDataGridView();                                  //thiết lập dgv
            LoadChiTietHoaDon();                                      
            SetGridViewStyle(dgvChiTietHoaDon);
        }

        private void SetupDataGridView()         //thêm các thuộc tính vào các cột của datagridview
        {
            dgvChiTietHoaDon.Columns.Clear();

            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenDV",
                HeaderText = "Tên dịch vụ",
                Width = 200,
                DataPropertyName = "TenDV"
            });

            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SoLuong",
                HeaderText = "Số lượng",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                DataPropertyName = "SoLuong"
            });

            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DonGia",
                HeaderText = "Đơn giá",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "#,##0 VNĐ"
                },
                DataPropertyName = "GiaDV"
            });

            dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThanhTien",
                HeaderText = "Thành tiền",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "#,##0 VNĐ"
                },
                DataPropertyName = "ThanhTien"
            });

            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHoaDon.AllowUserToAddRows = false;
            dgvChiTietHoaDon.AllowUserToDeleteRows = false;
            dgvChiTietHoaDon.ReadOnly = true;
            dgvChiTietHoaDon.RowHeadersVisible = false;
            dgvChiTietHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietHoaDon.AutoGenerateColumns = false;
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

        private void LoadChiTietHoaDon()      // tải dữ liệu chi tiết hoá đơn
        {
            var hoaDon = context.HoaDons                  //truy cập vào bảng hoá đơn
                .Include(h => h.Phong.LoaiPhong)            //tải dối tượng phòng liên quan đến hoá đơn và tải loại phòng liên quan đên phòng
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .FirstOrDefault(h => h.HoaDonID == hoaDonId);            

            if (hoaDon == null)
            {
                MessageBox.Show("Không tìm thấy thông tin hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // hiển thị thông tin lên giao diện, gán các giá trị vào các lb tương ứng
            lblNgayLap.Text = hoaDon.NgayHD;
            lblTongTien.Text = hoaDon.TongTien.HasValue ? hoaDon.TongTien.Value.ToString("#,##0 VNĐ") : "0 VNĐ";
            lblKhachHang.Text = hoaDon.KhachHang?.TenKH ?? "Không có thông tin";    // ? nếu KhachHang là null, biểu thức sẽ trả về null mà không gây lỗi
            lblNhanVien.Text = hoaDon.NhanVien?.TenNV ?? "Không có thông tin";       //??) sẽ sử dụng "Không có thông tin" nếu biểu thức trước là nul
            lblPhong.Text = hoaDon.Phong != null ?                               //dùng toán tử đk lồng nhau để xử lí các th
                (hoaDon.Phong.LoaiPhong != null ?                     
                    $"Phòng {hoaDon.PhongID} - {hoaDon.Phong.LoaiPhong.TenLoai}" :
                    $"Phòng {hoaDon.PhongID}") :
                "Không có thông tin";
            lblSoKhach.Text = hoaDon.SoKhach.HasValue ? hoaDon.SoKhach.Value + " khách" : "0 khách";
            lblSoDem.Text = hoaDon.SoDem.HasValue ? hoaDon.SoDem.Value + " đêm" : "0 đêm";

            var chiTietHoaDons = context.ChiTietHoaDons     // truy cập vào bảng
                .Include(ct => ct.DichVu)                    //nạp đối tượng dịch vự lq đến cthd
                .Where(ct => ct.HoaDonID == hoaDonId && ct.DichVu != null)       // chỉ lấy các chi tiết của hóa đơn hiện tại (HoaDonID = hoaDonId)
                .Select(ct => new              // lấy ra
                {
                    TenDV = ct.DichVu.TenDV,
                    ct.SoLuong,
                    GiaDV = ct.GiaDV,
                    ThanhTien = ct.ThanhTien
                })
                .ToList();

            dgvChiTietHoaDon.DataSource = chiTietHoaDons;                           // Các cột sẽ được liên kết với các thuộc tính tương ứng của đối tượng thông qua thuộc tính DataPropertyName
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
