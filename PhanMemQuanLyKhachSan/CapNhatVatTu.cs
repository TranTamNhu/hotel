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
    public partial class frmCapNhatVatTu : Form
    {
        public frmCapNhatVatTu()
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
        private void BtnThoatCapNhatVatTu_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong qlp = new frmQuanLyPhong();
            qlp.Show();
            this.Hide();
        }

        private void BindGrid(List<VatTu> listVatTu)
        {
            dgvCapNhatVatTu.Rows.Clear();
            int id = 1;
            foreach (var item in listVatTu)
            {
                int index = dgvCapNhatVatTu.Rows.Add();
                dgvCapNhatVatTu.Rows[index].Cells[0].Value = id++;
                dgvCapNhatVatTu.Rows[index].Cells[1].Value = item.VatTuID;
                dgvCapNhatVatTu.Rows[index].Cells[2].Value = item.TenVT;
            }
        }
        private void frmCapNhatVatTu_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvCapNhatVatTu);
                BindGrid(VatTu.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private VatTu GetVatTu()
        {
            VatTu k = new VatTu();
            k.TenVT = txtCapNhatVatTu.Text;
            return k;
        }

        private void btnThemDichVuVT_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtCapNhatVatTu.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên vật tư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCapNhatVatTu.Focus();
                    return;
                }

                VatTu s = GetVatTu();
                s.InsertUpdate();
                MessageBox.Show("Thêm vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCapNhatVatTu.Clear();
                txtCapNhatVatTu.Focus();
                BindGrid(VatTu.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaDichVuVT_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn dòng cần xóa chưa
                if (dgvCapNhatVatTu.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn vật tư cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại xác nhận
                string tenVT = dgvCapNhatVatTu.CurrentRow.Cells[2].Value.ToString();
                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa vật tư '{tenVT}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    int rowIndex = (int)dgvCapNhatVatTu.CurrentRow.Cells[1].Value;
                    VatTu.Delete(rowIndex);
                    MessageBox.Show("Xóa vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGrid(VatTu.GetAll());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cell_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvCapNhatVatTu.Rows[e.RowIndex];
                int maVT = int.Parse(row.Cells[1].Value.ToString());
                VatTu db = VatTu.GetVatTu(maVT);
                txtCapNhatVatTu.Text = db.TenVT.ToString();
            }
        }

        private void btnLuuCapNhatVatTu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra đã chọn dòng cần sửa chưa
                if (dgvCapNhatVatTu.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn vật tư cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtCapNhatVatTu.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên vật tư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCapNhatVatTu.Focus();
                    return;
                }

                int vatTuId = (int)dgvCapNhatVatTu.CurrentRow.Cells[1].Value;
                VatTu db = VatTu.GetVatTu(vatTuId);
                if (db != null)
                {
                    db.TenVT = txtCapNhatVatTu.Text.Trim();
                    db.InsertUpdate();
                    MessageBox.Show("Cập nhật vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCapNhatVatTu.Clear();
                    txtCapNhatVatTu.Focus();
                    BindGrid(VatTu.GetAll());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblVatTuKhachSan_Click(object sender, EventArgs e)
        {

        }
    }
}