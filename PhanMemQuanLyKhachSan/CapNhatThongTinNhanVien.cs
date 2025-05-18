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
                    int nhanVienID = (int)dgvThongTinNhanVien.CurrentRow.Cells[1].Value; // truy ô thứ 2 của dòng hiện tại,  ép kiểu sang int id
                    NhanVien nhanVien = _nhanVienController.GetNhanVien(nhanVienID);// lấy thông tin nhân viên thong qua controler

                    if (nhanVien != null)                                                  // nếu nhân viên tồn tại
                    {
                        nhanVien.TenNV = txtTimKiemTTNV.Text.Trim(); // gán giá trị mới cho tên nhân viên
                        _nhanVienController.SaveNhanVien(nhanVien); // lưu lại trong csdl

                        MessageBox.Show("Cập nhật thành công!");
                        RefreshData();         //load lại danh sách
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
                DataGridViewRow row = this.dgvThongTinNhanVien.Rows[e.RowIndex];   //lấy dòng vừa click
                int nhanVienID = int.Parse(row.Cells[1].Value.ToString());//Lấy giá trị ở cột thứ 2 (Cells[1], thường là cột chứa ID) rồi ép kiểu sang int.   Đây là cách lấy NhanVienID của dòng được chọn.
                NhanVien nhanVien = _nhanVienController.GetNhanVien(nhanVienID);  // lấy đôi tượng nhân viên tư ID bằng controller         



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
                string searchText = txtTimKiemTTNV.Text.Trim(); //Lấy chuỗi người dùng nhập từ TextBox txtTimKiemTTNV.
                List<NhanVien> searchResults = _nhanVienController.SearchNhanVien(searchText);     //Gọi hàm SearchNhanVien() trong controller, truyền vào từ khóa tìm kiếm.    Trả về danh sách nhân viên phù hợp dưới dạng List<NhanVien>.



                if (searchResults.Count > 0)
                {
                    _nhanVienController.PopulateDataGridView(dgvThongTinNhanVien, searchResults); //Gọi hàm PopulateDataGridView trong controller để đổ dữ liệu danh sách nhân viên vừa tìm được lên bảng DataGridView (dgvThongTinNhanVien).
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