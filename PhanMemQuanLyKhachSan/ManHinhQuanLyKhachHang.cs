using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmQuanLyKhachHang : Form
    {
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
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
        private void BindGrid(List<KhachHang> listKhachHang)
        {
            dgvQuanLyKhachHang.Rows.Clear();

            foreach (var item in listKhachHang)
            {
                int index = dgvQuanLyKhachHang.Rows.Add();
                dgvQuanLyKhachHang.Rows[index].Cells[0].Value = item.KhachHangID;
                dgvQuanLyKhachHang.Rows[index].Cells[1].Value = item.TenKH;
                dgvQuanLyKhachHang.Rows[index].Cells[2].Value = item.QuocTich;
            }
        }

        private void btnTrovecuaqlkh_Click(object sender, EventArgs e)
        {
            frmManHinhChinh fmmhc = new frmManHinhChinh();
            fmmhc.Show();
            this.Hide();
        }

        private void fmmhc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvQuanLyKhachHang);
                BindGrid(KhachHang.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblQuanLyKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            List<KhachHang> listkh = new List<KhachHang>();
            List<HoaDon> listHD = HoaDon.GetAll();

            // Sử dụng dtpTuNgay làm ngày duy nhất để lọc
            DateTime tungay = DateTime.Parse(dtpTuNgay.Text);

            // Danh sách các định dạng ngày để thử
            string[] dateFormats = {
        "dd/MM/yyyy",
        "MM/dd/yyyy",
        "yyyy-MM-dd",
        "dd-MM-yyyy",
        "dd.MM.yyyy"
    };

            foreach (var item in listHD)
            {
                try
                {
                    // Kiểm tra và parse ngày
                    DateTime dt = ParseDateFlexibly(item.NgayHD, dateFormats);

                    // So sánh với ngày được chọn
                    if (dt.Date == tungay.Date)
                    {
                        KhachHang kh = new KhachHang();
                        kh.KhachHangID = (int)item.KhachHangID;
                        kh.TenKH = item.KhachHang?.TenKH;
                        kh.QuocTich = item.KhachHang?.QuocTich;

                        // Chỉ thêm nếu không null
                        if (kh.KhachHangID != 0 && !string.IsNullOrEmpty(kh.TenKH))
                        {
                            listkh.Add(kh);
                        }
                    }
                }
                catch (FormatException)
                {
                    // Ghi log hoặc bỏ qua hóa đơn không có ngày hợp lệ
                    Console.WriteLine($"Không thể parse ngày: {item.NgayHD}");
                }
            }

            // Loại bỏ các bản ghi trùng lặp
            listkh = listkh
                .GroupBy(x => x.KhachHangID)
                .Select(g => g.First())
                .ToList();

            if (listkh.Count > 0)
            {
                BindGrid(listkh);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào trong ngày này.");
            }
        }

        // Phương thức parse ngày linh hoạt
        private DateTime ParseDateFlexibly(string dateString, string[] formats)
        {
            if (string.IsNullOrWhiteSpace(dateString))
            {
                throw new FormatException("Ngày không hợp lệ");
            }

            // Loại bỏ khoảng trắng thừa
            dateString = dateString.Trim();

            // Thử các định dạng
            foreach (string format in formats)
            {
                if (DateTime.TryParseExact(
                    dateString,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime result))
                {
                    return result;
                }
            }

            // Nếu không parse được, thử phương thức Parse thông thường
            try
            {
                return DateTime.Parse(dateString);
            }
            catch
            {
                throw new FormatException($"Không thể parse ngày: {dateString}");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<KhachHang> listKQTK = KhachHang.GetAll();
            var listKhacHang = listKQTK.Where(p => (p is KhachHang) && (p as KhachHang).TenKH.ToLower().Contains(txtTimKiem.Text.ToLower())).ToList();
            if (listKhacHang.Count > 0)
            {
                BindGrid(listKhacHang);
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào!");
            }
        }

        private void btnHuyCapNhatLoaiPhong_Click(object sender, EventArgs e)
        {
            BindGrid(KhachHang.GetAll());
        }
    }
}
