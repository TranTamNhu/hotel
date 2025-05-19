using PhanMemQuanLyKhachSan.Model;
using PhanMemQuanLyKhachSan.Controller;
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
    public partial class frmCapNhatLichLamViec : Form
    {
        // Khai báo controller
        private LichLamViecController controller;

        public frmCapNhatLichLamViec()
        {
            InitializeComponent();
            // Khởi tạo controller
            controller = new LichLamViecController();
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

        private void BindGrid(List<LichLamViec> listVatTu) /// hiển thị lên bảng
        {
            dgvCapNhatLichLamViec.Rows.Clear();
            int id = 1;
            foreach (var item in listVatTu)
            {
                int index = dgvCapNhatLichLamViec.Rows.Add();
                dgvCapNhatLichLamViec.Rows[index].Cells[0].Value = id++;
                dgvCapNhatLichLamViec.Rows[index].Cells[1].Value = item.NhanVien != null ? item.NhanVien.TenNV : "Chưa có nhân viên";
                dgvCapNhatLichLamViec.Rows[index].Cells[2].Value = item.Ca;
                dgvCapNhatLichLamViec.Rows[index].Cells[3].Value = item.Ngay;
                dgvCapNhatLichLamViec.Rows[index].Cells[4].Value = item.LichLamViecID;
            }
        }

        private void FillCaCombobox(List<LichLamViec> listLLV)        //nạp dữ liệu vào cbb
        {
            this.cbxCa.DataSource = listLLV;
            this.cbxCa.DisplayMember = "Ca";
            this.cbxCa.ValueMember = "LichLamViecID";
        }

        private void FillTenNhanVienCombobox(List<NhanVien> listTenNV)     // nạp dữ liệu vào cbb
        {
            this.cbxTenNV.DataSource = listTenNV;
            this.cbxTenNV.DisplayMember = "TenNV";
            this.cbxTenNV.ValueMember = "NhanVienID";
        }

        private LichLamViec GetLichLamViecFromForm() //lấy dữ liệu người dùng
        {
            LichLamViec k = new LichLamViec();                //khởi tạo đối tượng
            // Lấy NhanVienID từ giá trị được chọn trong combobox
            k.NhanVienID = (int)cbxTenNV.SelectedValue;
            k.Ca = cbxCa.Text;
            k.Ngay = dtpNgayLamViec.Value.ToString("dd/MM/yyyy");
            return k;
        }

        private void LblLichLamViec_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnTroVeCuaCapNhatLichLamViec_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frmback = new frmQuanLyNhanVien();
            frmback.Show();
            this.Hide();
        }

        private void frmCapNhatLichLamViec_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvCapNhatLichLamViec);
                // Sử dụng controller để lấy dữ liệu
                FillTenNhanVienCombobox(controller.GetAllNhanVien());
                FillCaCombobox(controller.GetAllLichLamViec());
                BindGrid(controller.GetAllLichLamViec());              // hiển thị toàn bộ llv
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemLichLamViec_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ form                              
                LichLamViec lichLamViec = GetLichLamViecFromForm();

                // Sử dụng controller để thêm lịch làm việc
                if (controller.InsertUpdateLichLamViec(lichLamViec))
                {
                    MessageBox.Show("Thêm Lịch Làm Việc thành công!");
                    // Cập nhật lại grid
                    BindGrid(controller.GetAllLichLamViec());                  // hiển thị lên
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaLichLamViec_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = (int)dgvCapNhatLichLamViec.CurrentRow.Cells[4].Value;      //lấy id dòng được chọn

                // Sử dụng controller để xóa lịch làm việc
                if (controller.DeleteLichLamViec(rowIndex))
                {
                    // Cập nhật lại grid
                    BindGrid(controller.GetAllLichLamViec());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaLichLamViec_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ form
                LichLamViec lichLamViec = GetLichLamViecFromForm();
                lichLamViec.LichLamViecID = (int)dgvCapNhatLichLamViec.CurrentRow.Cells[4].Value;        //lấy id của dòng đang chọn

                // Sử dụng controller để cập nhật lịch làm việc
                if (controller.InsertUpdateLichLamViec(lichLamViec))
                {
                    MessageBox.Show("Sửa thành công!");
                    // Cập nhật lại grid
                    BindGrid(controller.GetAllLichLamViec());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}