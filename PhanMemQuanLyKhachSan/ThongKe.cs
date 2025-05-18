using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            SetupChart();
        }

        private void SetupChart()
        {
            // Thiết lập định dạng cho biểu đồ
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:#,##0} VNĐ";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            
            // Thiết lập series
            chart1.Series["Tổng Tiền"].ChartType = SeriesChartType.Column;
            chart1.Series["Tổng Tiền"].IsValueShownAsLabel = true;
            chart1.Series["Tổng Tiền"].LabelFormat = "{0:#,##0} VNĐ";
        }

        private DateTime? ParseNgayHD(string ngayHD)
        {
            if (DateTime.TryParseExact(ngayHD, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            return null;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

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
                    lblSoKhachHang.Text = soKhachHang.ToString("#,##0");

                    // Lấy tổng doanh thu từ 2025 trở đi
                    var hoaDons = context.HoaDons.ToList();
                    var tongDoanhThu = hoaDons
                        .Where(h => ParseNgayHD(h.NgayHD)?.Year >= 2025)
                        .Sum(h => h.TongTien) ?? 0;
                    lblDoanhThu.Text = tongDoanhThu.ToString("#,##0") + " VNĐ";

                    // Cập nhật biểu đồ chỉ hiển thị từ 2025
                    var doanhThuTheoThang = hoaDons
                        .Where(h => ParseNgayHD(h.NgayHD)?.Year >= 2025)
                        .GroupBy(h => ParseNgayHD(h.NgayHD))
                        .Where(g => g.Key.HasValue)
                        .Select(g => new { 
                            Ngay = g.Key.Value,
                            TongTien = g.Sum(h => h.TongTien) ?? 0 
                        })
                        .OrderBy(x => x.Ngay)
                        .ToList();

                    chart1.Series["Tổng Tiền"].Points.Clear();
                    foreach (var item in doanhThuTheoThang)
                    {
                        chart1.Series["Tổng Tiền"].Points.AddXY(item.Ngay, item.TongTien);
                    }

                    // Cập nhật tiêu đề biểu đồ
                    chart1.Titles.Clear();
                    chart1.Titles.Add("DOANH THU TỪ NĂM 2025");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê: " + ex.Message, 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
