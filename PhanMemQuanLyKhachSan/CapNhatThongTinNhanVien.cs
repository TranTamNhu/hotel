using PhanMemQuanLyKhachSan.Controller;
using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmCapNhatThongTinNhanVien : Form
    {
        private NhanVienController _nhanVienController;

        public frmCapNhatThongTinNhanVien()
        {
            InitializeComponent();
            _nhanVienController = new NhanVienController();
        }

        private void BtnBackTTNV_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien mhc = new frmQuanLyNhanVien();
            mhc.Show();
            this.Hide();
        }

        private void frmCapNhatThongTinNhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                // Initialize UI
                _nhanVienController.SetGridViewStyle(dgvThongTinNhanVien);
                RefreshData();

                // Load default image
                picThongTinNhanVien.Image = _nhanVienController.LoadImage(_nhanVienController.GetDefaultImagePath());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshData()
        {
            List<NhanVien> nhanVienList = _nhanVienController.GetAllNhanVien();
            _nhanVienController.PopulateDataGridView(dgvThongTinNhanVien, nhanVienList);
        }

        private void ClearInputs()
        {
            txtTimKiemTTNV.Text = string.Empty;
            // Reset image to default
            picThongTinNhanVien.Image = _nhanVienController.LoadImage(_nhanVienController.GetDefaultImagePath());
        }

        private void btnThemTTNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTimKiemTTNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhanVien nhanVien = _nhanVienController.CreateNhanVien(txtTimKiemTTNV.Text);
                _nhanVienController.SaveNhanVien(nhanVien);

                MessageBox.Show("Thêm nhân viên thành công!");
                RefreshData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaTTNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongTinNhanVien.CurrentRow != null)
                {
                    int nhanVienID = (int)dgvThongTinNhanVien.CurrentRow.Cells[1].Value;
                    _nhanVienController.DeleteNhanVien(nhanVienID);

                    RefreshData();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa không thành công vì liên quan đến các dữ liệu khác!");
            }
        }

        private void btnLuuTTNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongTinNhanVien.CurrentRow != null)
                {
                    int nhanVienID = (int)dgvThongTinNhanVien.CurrentRow.Cells[1].Value;
                    NhanVien nhanVien = _nhanVienController.GetNhanVien(nhanVienID);

                    if (nhanVien != null)
                    {
                        nhanVien.TenNV = txtTimKiemTTNV.Text.Trim();
                        _nhanVienController.SaveNhanVien(nhanVien);

                        MessageBox.Show("Cập nhật thành công!");
                        RefreshData();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvThongTinNhanVien.Rows[e.RowIndex];
                int nhanVienID = int.Parse(row.Cells[1].Value.ToString());
                NhanVien nhanVien = _nhanVienController.GetNhanVien(nhanVienID);

                if (nhanVien != null)
                {
                    // Update text field
                    txtTimKiemTTNV.Text = nhanVien.TenNV;

                    // Load employee image
                    string imagePath = _nhanVienController.GetImagePath(nhanVien);
                    picThongTinNhanVien.Image = _nhanVienController.LoadImage(imagePath);
                }
            }
        }

        private void btnTimKiemTTNV_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTimKiemTTNV.Text.Trim();
                List<NhanVien> searchResults = _nhanVienController.SearchNhanVien(searchText);

                if (searchResults.Count > 0)
                {
                    _nhanVienController.PopulateDataGridView(dgvThongTinNhanVien, searchResults);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuyCapNhatLoaiPhong_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearInputs();
        }
    }
}