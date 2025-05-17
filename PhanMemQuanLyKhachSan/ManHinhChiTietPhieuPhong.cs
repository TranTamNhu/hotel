using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmChiTietPhieuPhong : Form
    {
        public frmManHinhChinh objManHinhChinh;
        private int selectedPhongId;

        public frmChiTietPhieuPhong()
        {
            InitializeComponent();
        }

        public frmChiTietPhieuPhong(int phongId)
        {
            InitializeComponent();
            selectedPhongId = phongId;
        }

        public frmChiTietPhieuPhong(frmManHinhChinh frm)
        {
            InitializeComponent();
            objManHinhChinh = frm;
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
        private void FillDichVuCombobox(List<DichVu> listDichVu)
        {
            this.cmbTenDichVu.DataSource = listDichVu;
            this.cmbTenDichVu.DisplayMember = "TenDV";
            this.cmbTenDichVu.ValueMember = "DichVuID";
        }
        private void FillLoaiPhongCombobox(List<LoaiPhong> listLoaiPhong)
        {
            this.cmbLoaiPhong.DataSource = listLoaiPhong;
            this.cmbLoaiPhong.DisplayMember = "TenLoai";
            this.cmbLoaiPhong.ValueMember = "LoaiPhongID";
        }
        private void FillSoPhongCombobox(List<Phong> listSoPhong)
        {
            this.cmbSoPhong.DataSource = listSoPhong;
            this.cmbSoPhong.DisplayMember = "PhongID";
            this.cmbSoPhong.ValueMember = "PhongID";
        }
        private void FillTenBookingCombobox(List<Booking> listTenBooking)
        {
            this.cmbTenBooking.DataSource = listTenBooking;
            this.cmbTenBooking.DisplayMember = "TenBooking";
            this.cmbTenBooking.ValueMember = "BookingID";
        }
        private void FillComboboxNhanVien(ComboBox cmbName,List<NhanVien> listNhanVien)
        {
            this.cmbNhanVien.DataSource = listNhanVien;
            this.cmbNhanVien.DisplayMember = "TenNV";
            this.cmbNhanVien.ValueMember = "NhanVienID";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //bindgrid khi chương trình tắt đi mở lên vẫn còn dl
        private void BindGrid(List<ChiTietHoaDon> listDichVu)
        {
            dgvChiTietDichVu.Rows.Clear();
            foreach (var item in listDichVu)
            {
                int index = dgvChiTietDichVu.Rows.Add();
                dgvChiTietDichVu.Rows[index].Cells[0].Value = index++;
                dgvChiTietDichVu.Rows[index].Cells[1].Value = item.DichVuID;
                //dgvChiTietDichVu.Rows[index].Cells[2].Value = ;
                dgvChiTietDichVu.Rows[index].Cells[3].Value = item.GiaDV;
                dgvChiTietDichVu.Rows[index].Cells[4].Value = item.SoLuong;
                dgvChiTietDichVu.Rows[index].Cells[5].Value = item.ThanhTien;
            }
        }
        private void fmmhc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void btnLuuCuaCTPP_Click(object sender, EventArgs e)
        {
            try
            {
                //insert khách hàng trước mới có hóa đơn
                KhachHang kh = new KhachHang();
                kh.TenKH = txtChiTietTenKhach.Text;
                kh.QuocTich = txtChiTietQuocTich.Text;
                kh = kh.InsertUpdate();
                List<DichVu> listDV = GetListDichVu();

                //insert hoa don
                HoaDon hd = GetHoaDon();

                //insert  khách hàng trước khi insert hóa đơn
                hd.KhachHangID = kh.KhachHangID;

                // Tính tổng tiền an toàn với kiểu nullable
                int giaPhong = 0;
                if (int.TryParse(txtChiTietGiaPhong.Text, out int giaPhongTemp))
                    giaPhong = giaPhongTemp;

                hd.TongTien = listDV.Sum(p => p.ThanhTien) + (giaPhong * (hd.SoDem ?? 0));

                int hoaDonID = hd.InsertUpdate();

                // Cập nhật trạng thái phòng thành "Đang ở"
                var phong = Phong.GetPhong(hd.PhongID ?? 0);
                if (phong != null)
                {
                    phong.TrangThai = Phong.TrangThaiPhong.DangO;
                    phong.InsertUpdate();
                }

                //có hóa đơn rồi insert chi tiet hoa don
                foreach(DichVu d in listDV)
                {
                    ChiTietHoaDon item = new ChiTietHoaDon();
                    item.DichVuID = d.DichVuID;
                    item.GiaDV = d.GiaDV;
                    item.HoaDonID = hoaDonID;
                    item.SoLuong = d.SoLuong;
                    item.ThanhTien = d.ThanhTien;
                    item.InsertUpdate();                  
                }

                objManHinhChinh.SetBookingRoom();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void frmChiTietPhieuPhong_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvChiTietDichVu);
                FillDichVuCombobox(DichVu.GetAll());
                FillLoaiPhongCombobox(LoaiPhong.GetAll());
                FillTenBookingCombobox(Booking.GetAll());
                FillComboboxNhanVien(cmbNhanVien, NhanVien.GetAll());

                if (selectedPhongId > 0)
                {
                    var phong = Phong.GetPhong(selectedPhongId);
                    if (phong != null)
                    {
                        // Chọn loại phòng
                        cmbLoaiPhong.SelectedValue = phong.LoaiPhongID;
                        
                        // Chọn số phòng
                        cmbSoPhong.Text = phong.PhongID.ToString();
                        
                        // Hiển thị giá phòng
                        txtChiTietGiaPhong.Text = phong.GiaPhong.ToString();
                    }
                }
                else
                {
                    cmbLoaiPhong.SelectedIndex = 0;
                    cmbSoPhong.SelectedIndex = 0;
                }
                
                cmbNhanVien.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin phòng: " + ex.Message);
            }
        }

        private HoaDon GetHoaDon()
        {
            HoaDon hd = new HoaDon();
            hd.TenLoai = cmbLoaiPhong.Text;

            // Chuyển đổi an toàn từ string sang int?
            if (int.TryParse(cmbNhanVien.SelectedValue?.ToString(), out int nhanVienId))
                hd.NhanVienID = nhanVienId;

            if (int.TryParse(cmbSoPhong.SelectedValue?.ToString(), out int phongId))
                hd.PhongID = phongId;

            if (int.TryParse(txtChiTietSoDem.Text, out int soDem))
                hd.SoDem = soDem;

            if (int.TryParse(txtChiTietSoKhach.Text, out int soKhach))
                hd.SoKhach = soKhach;

            hd.NgayHD = dtpNgayDi.Value.ToString("dd/MM/yyyy");

            if (!string.IsNullOrEmpty(cmbTenBooking.Text) && 
                int.TryParse(cmbTenBooking.SelectedValue?.ToString(), out int bookingId))
            {
                hd.BookingID = bookingId;
            }

            return hd;
        }
        private List<DichVu> GetListDichVu()  //lay nguoc tu datagrid ra
        {
            List<DichVu> list = new List<DichVu>();
            foreach (DataGridViewRow row in this.dgvChiTietDichVu.Rows)
            {
                DichVu dv = new DichVu();
                
                if (int.TryParse(row.Cells["id"].Value?.ToString(), out int dichVuId))
                    dv.DichVuID = dichVuId;

                if (int.TryParse(row.Cells[2].Value?.ToString(), out int giaDv))
                    dv.GiaDV = giaDv;

                if (int.TryParse(row.Cells[3].Value?.ToString(), out int soLuong))
                    dv.SoLuong = soLuong;

                if (int.TryParse(row.Cells[4].Value?.ToString(), out int thanhTien))
                    dv.ThanhTien = thanhTien;

                list.Add(dv);
            }

            return list;
        }

        private void btnThemCuaCTPP_Click(object sender, EventArgs e)
        {
            try
            {
                DichVu dv = DichVu.GetDichVu(int.Parse(cmbTenDichVu.SelectedValue.ToString()));
                if (txtSoLuong.Text == "")
                    throw new Exception("Vui long nhap so luong!");
                int index = dgvChiTietDichVu.Rows.Add();
                dgvChiTietDichVu.Rows[index].Cells[0].Value = (index + 1).ToString();
                dgvChiTietDichVu.Rows[index].Cells[1].Value = dv.TenDV;
                dgvChiTietDichVu.Rows[index].Cells[2].Value = dv.GiaDV + "";
                dgvChiTietDichVu.Rows[index].Cells[3].Value = txtSoLuong.Text + "";
                int thanhtien =  dv.GiaDV.Value * int.Parse(txtSoLuong.Text);
                dgvChiTietDichVu.Rows[index].Cells[4].Value = thanhtien.ToString();

                dgvChiTietDichVu.Rows[index].Cells["id"].Value = dv.DichVuID + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tendv = cmbTenDichVu.SelectedItem.ToString();
            List<DichVu> listKQTK = DichVu.GetAll();
        }

        private void btnXoaCuaCTPP_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvChiTietDichVu.SelectedRows)
            {
                dgvChiTietDichVu.Rows.RemoveAt(item.Index);
            }
        }

        private void cbxLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        
        private void txtChiTietGiaPhong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblThanhTien.Text = ( int.Parse(txtChiTietGiaPhong.Text) * int.Parse(txtChiTietSoDem.Text)).ToString();
            }
            catch 
            {
                lblThanhTien.Text = "";
            }
        }

        private void cmbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSoPhong.SelectedValue != null)
                {
                    Phong objPHong = Phong.GetPhong(int.Parse(cmbSoPhong.SelectedValue + ""));
                    if (objPHong != null)
                    {
                        txtChiTietGiaPhong.Text = objPHong.GiaPhong.ToString();
                    }
                }
            }
            catch { }
        }

        private void cmbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLoaiPhong.SelectedValue != null)
                {
                    LoaiPhong temp =  (LoaiPhong)cmbLoaiPhong.SelectedItem;
                    var list = Phong.GetAll(temp.LoaiPhongID);
                    FillSoPhongCombobox(list);
                }
            }
            catch { }
        }
    }
}
