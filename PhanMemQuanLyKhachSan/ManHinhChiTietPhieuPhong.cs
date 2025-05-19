using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmChiTietPhieuPhong : Form
    {
        private const string DATE_FORMAT = "dd/MM/yyyy";
        private static readonly CultureInfo DATE_CULTURE = CultureInfo.InvariantCulture;

        public frmManHinhChinh objManHinhChinh;
        public int selectedPhongId;
        public frmChiTietPhieuPhong()
        {
            InitializeComponent();
            SetupDateControls();
        }

        public frmChiTietPhieuPhong(int phongId)
        {
            InitializeComponent();
            selectedPhongId = phongId;
            SetupDateControls();
        }

        public frmChiTietPhieuPhong(frmManHinhChinh frm)
        {
            InitializeComponent();
            objManHinhChinh = frm;
            SetupDateControls();
        }

        public frmChiTietPhieuPhong(frmManHinhChinh frm, int phongId)
        {
            InitializeComponent();
            objManHinhChinh = frm;
            selectedPhongId = phongId;
            SetupDateControls();
        }

        private void SetupDateControls()   //Thiết lập định dạng cho DateTimePicker ngày đến và ngày đi theo format dd/MM/yyyy
        {
            
            dtpNgayDen.Format = DateTimePickerFormat.Custom;
            dtpNgayDen.CustomFormat = DATE_FORMAT;
            dtpNgayDi.Format = DateTimePickerFormat.Custom;
            dtpNgayDi.CustomFormat = DATE_FORMAT;
        }

        private string FormatDate(DateTime date)    //chuyển đối tượng Datimer thành chuỗi theo định dạng
        {
            return date.ToString(DATE_FORMAT, DATE_CULTURE);
        }

        private DateTime? ParseDate(string dateStr)   // chuyển chuỗi ngày thành đối tượng date
        {
            if (string.IsNullOrWhiteSpace(dateStr))
                return null;

            if (DateTime.TryParseExact(dateStr.Trim(), DATE_FORMAT, DATE_CULTURE, DateTimeStyles.None, out DateTime result))
                return result;

            return null;
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
        private void FillDichVuCombobox(List<DichVu> listDichVu)   // thiết lập comboxb
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
            frmManHinhChinh fmmhc = new frmManHinhChinh();
            fmmhc.Show();
            this.Hide();
        }
        //bindgrid khi chương trình tắt đi mở lên vẫn còn dl
        private void BindGrid(List<ChiTietHoaDon> listChiTiet)
        {
            try
            {
                dgvChiTietDichVu.Rows.Clear();
                for (int i = 0; i < listChiTiet.Count; i++)
                {
                    var item = listChiTiet[i];
                    int index = dgvChiTietDichVu.Rows.Add();
                    dgvChiTietDichVu.Rows[index].Cells["STT"].Value = (i + 1).ToString();
                    dgvChiTietDichVu.Rows[index].Cells["TenDV"].Value = item.DichVu?.TenDV;
                    dgvChiTietDichVu.Rows[index].Cells["Column3"].Value = string.Format("{0:#,##0 VNĐ}", item.GiaDV);
                    dgvChiTietDichVu.Rows[index].Cells["Column5"].Value = item.SoLuong.ToString();
                    dgvChiTietDichVu.Rows[index].Cells["Column6"].Value = string.Format("{0:#,##0 VNĐ}", item.ThanhTien);
                    dgvChiTietDichVu.Rows[index].Cells["id"].Value = item.DichVuID.ToString();
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Không thể hiển thị chi tiết hóa đơn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
             

                List<DichVu> listDV = GetListDichVu();   // lấy danh sách dv 
            

                //insert hoa don
                HoaDon hd = GetHoaDon();

                //insert  khách hàng trước khi insert hóa đơn
                hd.KhachHangID = kh.KhachHangID;

                // Tính tổng tiền từ giá trị đã được tính
                if (int.TryParse(lblChiTietTongTien.Text.Replace(",", ""), out int tongTien))
                {
                    hd.TongTien = tongTien;
                }
                else
                {
                    hd.TongTien = 0;
                }

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

                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (objManHinhChinh != null)
                {
                    // Refresh the main screen
                    objManHinhChinh.SetBookingRoom();
                    objManHinhChinh.Show();
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khi lưu thông tin: {ex.Message}\n\nChi tiết lỗi đã được ghi vào log.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Reset all fields by default
                txtChiTietTenKhach.Text = "";
                txtChiTietQuocTich.Text = "";
                txtChiTietSoKhach.Text = "";
                txtChiTietSoDem.Text = "";
                dtpNgayDen.Value = DateTime.Now;
                dtpNgayDi.Value = DateTime.Now.AddDays(1);
                cmbTenBooking.SelectedIndex = -1;
                dgvChiTietDichVu.Rows.Clear();
                lblChiTietTongTien.Text = "0";

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

                        // Nếu phòng không ở trạng thái "Đang ở", không cần load thông tin hóa đơn
                        if (phong.TrangThai != "Đang ở")
                        {
                            return;
                        }

                        // Kiểm tra và hiển thị thông tin hóa đơn nếu có
                        var hoaDon = HoaDon.GetHoaDonByPhongID(phong.PhongID);
                        if (hoaDon != null && hoaDon.KhachHang != null)
                        {
                            // Cập nhật thông tin hóa đơn
                            txtChiTietTenKhach.Text = hoaDon.KhachHang.TenKH;
                            txtChiTietQuocTich.Text = hoaDon.KhachHang.QuocTich;
                            txtChiTietSoKhach.Text = hoaDon.SoKhach?.ToString() ?? "";

                            // Xử lý ngày tháng
                            if (!string.IsNullOrEmpty(hoaDon.NgayHD))
                            {
                                if (DateTime.TryParseExact(hoaDon.NgayHD, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngayDi))
                                {
                                    dtpNgayDi.Value = ngayDi;
                                    
                                    if (hoaDon.SoDem.HasValue)
                                    {
                                        txtChiTietSoDem.Text = hoaDon.SoDem.Value.ToString();
                                        dtpNgayDen.Value = ngayDi.AddDays(-hoaDon.SoDem.Value);
                                    }
                                }
                            }

                            // Hiển thị thông tin booking
                            if (hoaDon.BookingID.HasValue)
                            {
                                var booking = Booking.GetBooking(hoaDon.BookingID.Value);
                                if (booking != null)
                                {
                                    cmbTenBooking.SelectedValue = booking.BookingID;
                                }
                            }

                            // Hiển thị tổng tiền
                            lblChiTietTongTien.Text = hoaDon.TongTien?.ToString("#,##0") ?? "0";

                            // Load chi tiết dịch vụ
                            if (hoaDon.ChiTietHoaDons != null && hoaDon.ChiTietHoaDons.Any())
                            {
                                BindGrid(hoaDon.ChiTietHoaDons.ToList());
                            }
                        }
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

            hd.NgayHD = FormatDate(dtpNgayDi.Value);

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
            try 
            {
                foreach (DataGridViewRow row in this.dgvChiTietDichVu.Rows)
                {
                    // Kiểm tra xem cột id có tồn tại không
                    if (!dgvChiTietDichVu.Columns.Contains("id"))
                    {
                        MessageBox.Show("Không tìm thấy cột id trong DataGridView!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return list;
                    }

                    if (row.Cells["id"].Value == null) continue;

                   

                    DichVu dv = new DichVu();
                    
                    // Lấy DichVuID từ cột ẩn "id"
                    if (int.TryParse(row.Cells["id"].Value?.ToString(), out int dichVuId))
                    {
                        dv.DichVuID = dichVuId;
                        
                        // Lấy giá dịch vụ từ cột "Column3" (Giá)
                        string giaStr = row.Cells["Column3"].Value?.ToString().Replace(",", "").Replace("VNĐ", "").Trim();
                        if (int.TryParse(giaStr, out int giaDv))
                            dv.GiaDV = giaDv;

                        // Lấy số lượng từ cột "Column5" (Số lượng)
                        if (int.TryParse(row.Cells["Column5"].Value?.ToString(), out int soLuong))
                            dv.SoLuong = soLuong;

                        // Lấy thành tiền từ cột "Column6" (Thành tiền)
                        string thanhTienStr = row.Cells["Column6"].Value?.ToString().Replace(",", "").Replace("VNĐ", "").Trim();
                        if (int.TryParse(thanhTienStr, out int thanhTien))
                            dv.ThanhTien = thanhTien;

                      
                        list.Add(dv);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }

         
            return list;
        }

        private void TinhTongTien()
        {
            try
            {
                // Tính tổng tiền dịch vụ
                int tongTienDichVu = 0;
                foreach (DataGridViewRow row in dgvChiTietDichVu.Rows)
                {
                    string thanhTienStr = row.Cells["Column6"].Value?.ToString()
                        .Replace(",", "")
                        .Replace("VNĐ", "")
                        .Trim();
                        
                    if (int.TryParse(thanhTienStr, out int thanhTien))
                    {
                        tongTienDichVu += thanhTien;
                    }
                }

                // Tính tiền phòng
                int tienPhong = 0;
                if (int.TryParse(txtChiTietGiaPhong.Text.Replace(",", ""), out int giaPhong) &&
                    int.TryParse(txtChiTietSoDem.Text, out int soDem))
                {
                    tienPhong = giaPhong * soDem;
                    lblThanhTien.Text = tienPhong.ToString("#,##0");
                }

                // Cập nhật tổng tiền (tiền phòng + tiền dịch vụ)
                int tongTien = tongTienDichVu + tienPhong;
                lblChiTietTongTien.Text = tongTien.ToString("#,##0");
                
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tính tổng tiền: {ex.Message}");
                lblChiTietTongTien.Text = "0";
            }
        }

        private void txtChiTietGiaPhong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtChiTietGiaPhong.Text, out int giaPhong) &&
                    int.TryParse(txtChiTietSoDem.Text, out int soDem))
                {
                    lblThanhTien.Text = (giaPhong * soDem).ToString("#,##0");
                }
                else
                {
                    lblThanhTien.Text = "0";
                }
                TinhTongTien();
            }
            catch
            {
                lblThanhTien.Text = "0";
            }
        }

        private void txtChiTietSoDem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtChiTietGiaPhong.Text, out int giaPhong) &&
                    int.TryParse(txtChiTietSoDem.Text, out int soDem))
                {
                    lblThanhTien.Text = (giaPhong * soDem).ToString("#,##0");
                }
                else
                {
                    lblThanhTien.Text = "0";
                }
                TinhTongTien();
            }
            catch
            {
                lblThanhTien.Text = "0";
            }
        }

        private void btnThemCuaCTPP_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text))
                    throw new Exception("Vui lòng nhập số lượng!");

                if (!int.TryParse(txtSoLuong.Text, out int soLuong))
                    throw new Exception("Số lượng phải là số nguyên!");

                if (soLuong <= 0)
                    throw new Exception("Số lượng phải lớn hơn 0!");

                DichVu dv = DichVu.GetDichVu(int.Parse(cmbTenDichVu.SelectedValue.ToString()));
                if (dv == null)
                    throw new Exception("Không tìm thấy thông tin dịch vụ!");

                int thanhTien = dv.GiaDV.GetValueOrDefault() * soLuong;

                int index = dgvChiTietDichVu.Rows.Add();
                dgvChiTietDichVu.Rows[index].Cells["STT"].Value = (index + 1).ToString(); // STT
                dgvChiTietDichVu.Rows[index].Cells["TenDV"].Value = dv.TenDV; // Tên dịch vụ
                dgvChiTietDichVu.Rows[index].Cells["Column3"].Value = string.Format("{0:#,##0 VNĐ}", dv.GiaDV); // Giá
                dgvChiTietDichVu.Rows[index].Cells["Column5"].Value = soLuong.ToString(); // Số lượng
                dgvChiTietDichVu.Rows[index].Cells["Column6"].Value = string.Format("{0:#,##0 VNĐ}", thanhTien); // Thành tiền
                dgvChiTietDichVu.Rows[index].Cells["id"].Value = dv.DichVuID.ToString(); // ID (cột ẩn)

                TinhTongTien();                     //tính tông tiền sau khi thêm cái mới
                
                // Clear số lượng sau khi thêm
                txtSoLuong.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaCuaCTPP_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvChiTietDichVu.SelectedRows)
            {
                dgvChiTietDichVu.Rows.RemoveAt(item.Index);
            }
            TinhTongTien();
        }

        private void cmbTenDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tendv = cmbTenDichVu.SelectedItem.ToString();
            List<DichVu> listKQTK = DichVu.GetAll();
        }

        private void cbxLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSoPhong.SelectedValue != null)
                { 
                    Phong objPHong = Phong.GetPhong(int.Parse(cmbSoPhong.SelectedValue + ""));  //Chuyển đổi giá trị được chọn sang kiểu int bằng cách thêm chuỗi rỗng và sử dụng int.Parse
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
