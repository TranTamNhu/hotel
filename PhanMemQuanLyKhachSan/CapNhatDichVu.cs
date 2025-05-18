using PhanMemQuanLyKhachSan.Controller;
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
    public partial class frmCapNhatDichVu : Form
    {
        private DichVuController _dichVuController;

        public frmCapNhatDichVu()
        {
            InitializeComponent();
            _dichVuController = new DichVuController();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong mqv = new frmQuanLyPhong();
            mqv.Show();
            this.Hide();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Empty event handler
        }

        private void frmCapNhatDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                _dichVuController.SetGridViewStyle(dgvCapNhatDichVu);
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshData()
        {
            List<DichVu> dichVuList = _dichVuController.GetAllDichVu();   
            _dichVuController.PopulateDataGridView(dgvCapNhatDichVu, dichVuList);  //cập nhập lại sau khi làm mới
        }

        private void ClearInputs()
        {
            txtCapNhatDichVu.Text = string.Empty;
            txtGia.Text = string.Empty;
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDV = txtCapNhatDichVu.Text;
                string giaDVText = txtGia.Text;

                // Validate input
                string errorMessage;
                if (!_dichVuController.ValidateServiceInput(tenDV, giaDVText, out errorMessage))  //kiểm tra tên và giá có hợp lệ không
                {
                    MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int giaDV = int.Parse(giaDVText);  //chuyển giá từ string sang int
                DichVu dichVu = _dichVuController.CreateDichVu(tenDV, giaDV);

                _dichVuController.SaveDichVu(dichVu);
                MessageBox.Show("Thêm dịch vụ thành công!");

                ClearInputs();
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCapNhatDichVu.CurrentRow != null)
                {
                    int dichVuID = (int)dgvCapNhatDichVu.CurrentRow.Cells[1].Value;
                    _dichVuController.DeleteDichVu(dichVuID);

                    MessageBox.Show("Xóa dịch vụ thành công!");
                    ClearInputs();
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!");
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
                DataGridViewRow row = this.dgvCapNhatDichVu.Rows[e.RowIndex];
                int dichVuID = int.Parse(row.Cells[1].Value.ToString());
                DichVu dichVu = _dichVuController.GetDichVu(dichVuID); // truy xuất thông tin từ db

                if (dichVu != null)
                {
                    txtCapNhatDichVu.Text = dichVu.TenDV;  //gán tên vào txt
                    txtGia.Text = dichVu.GiaDV.ToString(); //gán giá
                }
            }
        }

        private void btnLuuCapNhatDichVu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCapNhatDichVu.CurrentRow != null)
                {
                    string tenDV = txtCapNhatDichVu.Text;
                    string giaDVText = txtGia.Text;

                    // Validate input
                    string errorMessage;
                    if (!_dichVuController.ValidateServiceInput(tenDV, giaDVText, out errorMessage))
                    {
                        MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int dichVuID = (int)dgvCapNhatDichVu.CurrentRow.Cells[1].Value;
                    int giaDV = int.Parse(giaDVText);

                    DichVu dichVu = _dichVuController.GetDichVu(dichVuID);
                    if (dichVu != null)
                    {
                        dichVu.TenDV = tenDV;
                        dichVu.GiaDV = giaDV;

                        _dichVuController.SaveDichVu(dichVu);
                        MessageBox.Show("Cập nhật dịch vụ thành công!");

                        ClearInputs();
                        RefreshData();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần cập nhật!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}