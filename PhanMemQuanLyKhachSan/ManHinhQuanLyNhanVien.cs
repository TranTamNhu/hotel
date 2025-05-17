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

namespace PhanMemQuanLyKhachSan
{
    public partial class frmQuanLyNhanVien : Form
    {
        private QLKSModel context;

        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            context = new QLKSModel();
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
        private void BindGrid(List<LichLamViec> listLichLamViec)
        {
            try
            {
                dgvLichLamViec.Rows.Clear();
                int id = 1;
                foreach (var item in listLichLamViec)
                {
                    int index = dgvLichLamViec.Rows.Add();
                    dgvLichLamViec.Rows[index].Cells[0].Value = id++;

                    // Kiểm tra nếu NhanVien là null
                    dgvLichLamViec.Rows[index].Cells[1].Value = item.NhanVien != null ? item.NhanVien.TenNV : "Chưa có nhân viên";

                    dgvLichLamViec.Rows[index].Cells[2].Value = item.Ca;
                    dgvLichLamViec.Rows[index].Cells[3].Value = item.Ngay;
                    dgvLichLamViec.Rows[index].Cells[4].Value = item.NhanVienID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fmmhgc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnTrovecuaqlnv_Click(object sender, EventArgs e)
        {
            frmManHinhChinh fmmhc = new frmManHinhChinh(); 
            fmmhc.Show();
            this.Hide();
        }
        private void fmmhc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void btnCapnhatthongtinnv_Click(object sender, EventArgs e)
        {
            frmCapNhatThongTinNhanVien cnttnv = new frmCapNhatThongTinNhanVien();
            cnttnv.Show();
            this.Hide();
        }
        private void xttnv_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void BtnCapnhatlichlvnv_Click(object sender, EventArgs e)
        {
            frmCapNhatLichLamViec llv = new frmCapNhatLichLamViec();
            llv.Show();
            this.Hide();
        }

        private void BtnXemLaiNV_Click(object sender, EventArgs e)
        {

        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLichLamViec.SelectedRows.Count > 0)
                {
                    int nhanVienId = Convert.ToInt32(dgvLichLamViec.SelectedRows[0].Cells["id"].Value);
                    
                    // Kiểm tra xem nhân viên có hóa đơn nào không
                    var hoaDons = context.HoaDons.Where(h => h.NhanVienID == nhanVienId).ToList();
                    if (hoaDons.Any())
                    {
                        var formXemHoaDon = new PhanMemQuanLyKhachSan.XemHoaDonNhanVien(nhanVienId);
                        formXemHoaDon.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Nhân viên này chưa có hóa đơn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để xem hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvLichLamViec);
                BindGrid(LichLamViec.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlQLNV_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
