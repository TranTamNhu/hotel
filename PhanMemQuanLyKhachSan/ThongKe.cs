using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PhanMemQuanLyKhachSan.Model;
using System.Linq;
using System.Globalization;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }

        private void btnTroVeCuaThongKe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new QLKSModel())
                {
                    // Lấy tổng số khách hàng
                    int soKhachHang = context.KhachHangs.Count();
                    lblSoKhachHang.Text = soKhachHang.ToString("N0");

                    // Reset chart completely
                    chart1.Series.Clear();
                    chart1.Series.Add(new Series("Tổng Tiền"));
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    chart1.Series[0].Color = Color.FromArgb(135, 206, 235);

                    // Lấy dữ liệu hóa đơn năm 2025 và nhóm theo tháng
                    var hoaDonTheoThang = context.HoaDons
                        .AsEnumerable()
                        .Where(h => h.NgayHD != null && h.NgayHD.Contains("/2025"))
                        .GroupBy(h => int.Parse(h.NgayHD.Split('/')[1])) // Lấy tháng từ ngày
                        .OrderBy(g => g.Key)
                        .Select(g => new
                        {
                            Thang = g.Key,
                            TongTien = g.Sum(h => h.TongTien ?? 0)
                        })
                        .ToList();

                    // Tính tổng doanh thu
                    decimal tongDoanhThu = hoaDonTheoThang.Sum(h => h.TongTien);
                    lblDoanhThu.Text = $"{tongDoanhThu:N0} VNĐ";

                    // Cấu hình biểu đồ
                    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                    chart1.ChartAreas[0].AxisY.Title = "Doanh Thu (VNĐ)";
                    chart1.ChartAreas[0].AxisX.Title = "Tháng";
                    chart1.ChartAreas[0].AxisX.Interval = 1;

                    // Thêm dữ liệu vào biểu đồ
                    foreach (var data in hoaDonTheoThang)
                    {
                        var point = chart1.Series[0].Points.Add((double)data.TongTien);
                        point.AxisLabel = $"Tháng {data.Thang}";
                        point.Label = $"{data.TongTien:N0}";
                    }

                    // Cập nhật tiêu đề
                    chart1.Titles.Clear();
                    chart1.Titles.Add("DOANH THU THEO THÁNG TỪ NĂM 2025");
                    chart1.Titles[0].Font = new Font("Palatino Linotype", 16, FontStyle.Bold);
                    chart1.Titles[0].Alignment = ContentAlignment.TopCenter;

                    // Hiển thị chú thích
                    chart1.Legends[0].Enabled = true;
                    chart1.Legends[0].Docking = Docking.Top;
                    chart1.Legends[0].Alignment = StringAlignment.Far;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
