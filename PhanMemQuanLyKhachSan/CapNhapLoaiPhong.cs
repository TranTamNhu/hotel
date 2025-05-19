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
    public partial class frmCapNhatLoaiPhong : Form
    {
        // Tạo một từ điển để lưu trữ ánh xạ giữa chuỗi hiển thị và ID phòng
        private Dictionary<string, int> roomMappings = new Dictionary<string, int>();

        // Khai báo controller
        private LoaiPhongController controller;

        public frmCapNhatLoaiPhong()
        {
            InitializeComponent();

            // Khởi tạo controller
            controller = new LoaiPhongController();
        }

        private void frmCapNhatLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
        }

        private void LoadDanhSachPhong()
        {
            try
            {
                cmbChonSoPhong.SelectedIndexChanged -= cmbChonSoPhong_SelectedIndexChanged;
                cmbChonSoPhong.Items.Clear();
                roomMappings.Clear();

                // Lấy danh sách phòng từ controller
                List<Phong> phongs = controller.GetAllPhongs();

                if (phongs.Count == 0)
                {
                    MessageBox.Show("Không có phòng nào trong cơ sở dữ liệu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Đổ dữ liệu vào combobox - sắp xếp theo PhongID
                foreach (var phong in phongs.OrderBy(p => p.PhongID))       //duyệt qua danh sách phòng, sắp sếp theo id
                {
                    string display = $"Phòng {phong.PhongID}";                     // Tạo chuỗi để hiển thị trong box
                    roomMappings.Add(display, phong.PhongID);                       // lưu ảnh xạ. chọn phòng 111 thì tìm phòng 111
                    cmbChonSoPhong.Items.Add(display);                                   
                }

                cmbChonSoPhong.SelectedIndexChanged += cmbChonSoPhong_SelectedIndexChanged;                 //gắn lại sk, chọn phòng khác thì sựu kiện được gọi

                if (cmbChonSoPhong.Items.Count > 0)                                                           //tự động chọn item đầu tiên
                {
                    cmbChonSoPhong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách phòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbChonSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongTinLoaiPhong();
        }

        private void LoadThongTinLoaiPhong()
        {
            if (cmbChonSoPhong.SelectedItem == null) return;
             
            string selectedItem = cmbChonSoPhong.SelectedItem.ToString();          //lấy phongID từ chuỗi cbb hiển thị
            if (!roomMappings.TryGetValue(selectedItem, out int phongID))         //mp để tra phòng tương ứng
            {
                MessageBox.Show("Không tìm thấy ID phòng tương ứng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Sử dụng controller để lấy thông tin phòng
            var phong = controller.GetPhongById(phongID);
            if (phong == null)
            {
                MessageBox.Show($"Không tìm thấy thông tin phòng ID: {phongID}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                 // xoá radio trc khi set đúng cái tương ứng
            rdoStandard.Checked = false;
            rdoSuperior.Checked = false;
            rdoDeluxe.Checked = false;

            // Set RadioButton tương ứng
            switch (phong.LoaiPhongID)                               // lấy idloaiphong
            {
                case 1: rdoStandard.Checked = true; break;
                case 2: rdoDeluxe.Checked = true; break;
                case 3: rdoSuperior.Checked = true; break;
                default: rdoStandard.Checked = true; break;
            }
        }

        private void BtnTroVeCuaQLNV_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong qlp = new frmQuanLyPhong();
            qlp.Show();
            this.Hide();
        }

        private void btnHuyCapNhatLoaiPhong_Click(object sender, EventArgs e)
        {
            // Đóng form hiện tại và quay lại form Quản lý phòng
            frmQuanLyPhong qlp = new frmQuanLyPhong();
            qlp.Show();
            this.Close();
        }

        private void btnLuuCapNhatLoaiPhong_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem ComboBox có mục nào được chọn không
                if (cmbChonSoPhong.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn phòng cần cập nhật!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedItem = cmbChonSoPhong.SelectedItem.ToString();
                if (!roomMappings.ContainsKey(selectedItem))
                {
                    MessageBox.Show("Lỗi: Không thể xác định ID phòng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int phongID = roomMappings[selectedItem];

                // Kiểm tra ID phòng hợp lệ sử dụng controller
                if (!controller.IsValidPhongID(phongID))
                {
                    MessageBox.Show("Lỗi: ID phòng không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác định loại phòng được chọn
                int loaiPhongID;
                if (rdoStandard.Checked)
                    loaiPhongID = 1; // Standard có ID = 1
                else if (rdoDeluxe.Checked)
                    loaiPhongID = 2; // Deluxe có ID = 2
                else if (rdoSuperior.Checked)
                    loaiPhongID = 3; // Superior có ID = 3
                else
                {
                    MessageBox.Show("Vui lòng chọn loại phòng cần cập nhật!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sử dụng controller để cập nhật loại phòng
                if (controller.UpdateLoaiPhong(phongID, loaiPhongID))
                {
                    MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Quay lại form Quản lý phòng
                    frmQuanLyPhong qlp = new frmQuanLyPhong();
                    qlp.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}