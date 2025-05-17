using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmManHinhChinh : Form
    {
        public frmManHinhChinh()
        {
            InitializeComponent();
        }
          
        public void SetBookingRoom()
        {
            var listHD = HoaDon.GetAll();
            var listPhong = Phong.GetAll();

            // Cập nhật trạng thái cho tất cả các phòng
            void UpdateRoomStatus(int phongId, Panel pnlPhong, Label lblNoiDungTenBooking, 
                Label lblNoiDungTenKhach, Label lblNoiDungSoKhach, Label lblNoiDungQuocTich,
                Label lblNoiDungNgayDen, Label lblNoiDungNgayDi)
            {
                var phong = listPhong.FirstOrDefault(p => p.PhongID == phongId);
                var hoaDon = listHD.LastOrDefault(p => p.PhongID != null && p.PhongID == phongId);

                // Cập nhật màu nền dựa trên trạng thái
                if (phong != null)
                {
                    switch (phong.TrangThai)
                    {
                        case Phong.TrangThaiPhong.DangO:
                            pnlPhong.BackColor = Color.LightPink; // Đang có khách
                            break;
                        case Phong.TrangThaiPhong.DaDat:
                            pnlPhong.BackColor = Color.LightYellow; // Đã đặt trước
                            break;
                        case Phong.TrangThaiPhong.BaoTri:
                            pnlPhong.BackColor = Color.LightGray; // Đang bảo trì
                            break;
                        default:
                            pnlPhong.BackColor = Color.LightGreen; // Trống
                            break;
                    }
                }

                // Cập nhật thông tin hóa đơn nếu có
                if (hoaDon != null)
                {
                    DateTime dt = DateTime.ParseExact(hoaDon.NgayHD, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (dt.Date >= DateTime.Now)
                    {
                        if (hoaDon.BookingID.HasValue)
                        {
                            Booking findBook = Booking.GetBooking(hoaDon.BookingID.Value);
                            if (findBook != null)
                            {
                                lblNoiDungTenBooking.Text = findBook.TenBooking;
                            }
                        }
                        lblNoiDungTenKhach.Text = hoaDon.KhachHang.TenKH;
                        lblNoiDungSoKhach.Text = hoaDon.SoKhach + "";
                        lblNoiDungQuocTich.Text = hoaDon.KhachHang.QuocTich;
                        lblNoiDungNgayDen.Text = dt.AddDays(0 - hoaDon.SoDem.Value).ToString("dd/MM/yyyy");
                        lblNoiDungNgayDi.Text = hoaDon.NgayHD;
                    }
                }
            }

            // Cập nhật cho từng phòng
            UpdateRoomStatus(1, pnlPhong1, lblNoiDungTenBooking1, lblNoiDungTenKhach1, 
                lblNoiDungSoKhach1, lblNoiDungQuocTich1, lblNoiDungNgayDen1, lblNoiDungNgayDi1);

            UpdateRoomStatus(2, pnlPhong2, lblNoiDungTenBooking2, lblNoiDungTenKhach2,
                lblNoiDungSoKhach2, lblNoiDungQuocTich2, lblNoiDungNgayDen2, lblNoiDungNgayDi2);

            UpdateRoomStatus(3, pnlPhong3, lblNoiDungTenBooking3, lblNoiDungTenKhach3,
                lblNoiDungSoKhach3, lblNoiDungQuocTich3, lblNoiDungNgayDen3, lblNoiDungNgayDi3);

            UpdateRoomStatus(4, pnlPhong4, lblNoiDungTenBooking4, lblNoiDungTenKhach4,
                lblNoiDungSoKhach4, lblNoiDungQuocTich4, lblNoiDungNgayDen4, lblNoiDungNgayDi4);

            UpdateRoomStatus(5, pnlPhong5, lblNoiDungTenBooking5, lblNoiDungTenKhach5,
                lblNoiDungSoKhach5, lblNoiDungQuocTich5, lblNoiDungNgayDen5, lblNoiDungNgayDi5);

            UpdateRoomStatus(6, pnlPhong6, lblNoiDungTenBooking6, lblNoiDungTenKhach6,
                lblNoiDungSoKhach6, lblNoiDungQuocTich6, lblNoiDungNgayDen6, lblNoiDungNgayDi6);

            UpdateRoomStatus(7, pnlPhong7, lblNoiDungTenBooking7, lblNoiDungTenKhach7,
                lblNoiDungSoKhach7, lblNoiDungQuocTich7, lblNoiDungNgayDen7, lblNoiDungNgayDi7);

            UpdateRoomStatus(8, pnlPhong8, lblNoiDungTenBooking8, lblNoiDungTenKhach8,
                lblNoiDungSoKhach8, lblNoiDungQuocTich8, lblNoiDungNgayDen8, lblNoiDungNgayDi8);
        }

        private void btnChitiet1_Click(object sender, EventArgs e)
        {
            // Lấy phòng từ database
            var phong = Phong.GetPhong(1); // 1 là ID của phòng 1
            
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }
        private void fmmhctpp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }


        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang fmqlkh = new frmQuanLyKhachHang();
            fmqlkh.Show();
            this.Hide();
        }

        private void fmqlkh_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void LblKhachSan_Click(object sender, EventArgs e)
        {

        }

        private void FrmManHinhChinh_Load(object sender, EventArgs e)
        {
            SetBookingRoom();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe frmThongKe = new frmThongKe();
            frmThongKe.Show();
         
        }

       

        private void cậpNhậtVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapNhatVatTu frmCapNhatVatTu = new frmCapNhatVatTu();
            frmCapNhatVatTu.Show();
            this.Hide();
        }

        private void cậpNhậtDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapNhatDichVu frmCapNhatDichVu = new frmCapNhatDichVu();
            frmCapNhatDichVu.Show();
            this.Hide();
        }

        private void cậpNhậtLoạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapNhatLoaiPhong frmCapNhatLoaiPhong = new frmCapNhatLoaiPhong();
            frmCapNhatLoaiPhong.Show();
            this.Hide();
        }

        private void cậpNhậtThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frmNhanVien = new frmQuanLyNhanVien();
            frmNhanVien.Show();
            this.Hide();
        }


        private void cậpNhậtLịchLàmViệcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCapNhatLichLamViec frmcnllv = new frmCapNhatLichLamViec();
            frmcnllv.Show();
            this.Hide();
        }
        private void lblTien1_Click(object sender, EventArgs e)
        {

        }

        private void lblSoPhong1_Click(object sender, EventArgs e)
        {

        }

        private void pnlPhong1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong qlp = new frmQuanLyPhong();
            qlp.Show();
            this.Hide();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien qlnv = new frmQuanLyNhanVien();
            qlnv.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut1_Click(object sender, EventArgs e)
        {
            // Lấy phòng từ database
            var phong = Phong.GetPhong(1);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                // Cập nhật trạng thái phòng thành Trống
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                // Xóa thông tin hiển thị
                lblNoiDungTenBooking1.Text = ".........................................";
                lblNoiDungTenKhach1.Text = ".........................................";
                lblNoiDungSoKhach1.Text = ".........................................";
                lblNoiDungQuocTich1.Text = ".........................................";
                lblNoiDungNgayDen1.Text = ".........................................";
                lblNoiDungNgayDi1.Text = ".........................................";

                // Cập nhật lại hiển thị các phòng
                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckOut2_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(2);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                lblNoiDungTenBooking2.Text = ".........................................";
                lblNoiDungTenKhach2.Text = ".........................................";
                lblNoiDungSoKhach2.Text = ".........................................";
                lblNoiDungQuocTich2.Text = ".........................................";
                lblNoiDungNgayDen2.Text = ".........................................";
                lblNoiDungNgayDi2.Text = ".........................................";

                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckOut3_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(3);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                lblNoiDungTenBooking3.Text = ".........................................";
                lblNoiDungTenKhach3.Text = ".........................................";
                lblNoiDungSoKhach3.Text = ".........................................";
                lblNoiDungQuocTich3.Text = ".........................................";
                lblNoiDungNgayDen3.Text = ".........................................";
                lblNoiDungNgayDi3.Text = ".........................................";

                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckOut4_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(4);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                lblNoiDungTenBooking4.Text = ".........................................";
                lblNoiDungTenKhach4.Text = ".........................................";
                lblNoiDungSoKhach4.Text = ".........................................";
                lblNoiDungQuocTich4.Text = ".........................................";
                lblNoiDungNgayDen4.Text = ".........................................";
                lblNoiDungNgayDi4.Text = ".........................................";

                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCheckOut5_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(5);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                lblNoiDungTenBooking5.Text = ".........................................";
                lblNoiDungTenKhach5.Text = ".........................................";
                lblNoiDungSoKhach5.Text = ".........................................";
                lblNoiDungQuocTich5.Text = ".........................................";
                lblNoiDungNgayDen5.Text = ".........................................";
                lblNoiDungNgayDi5.Text = ".........................................";

                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCheckOut6_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(6);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                lblNoiDungTenBooking6.Text = ".........................................";
                lblNoiDungTenKhach6.Text = ".........................................";
                lblNoiDungSoKhach6.Text = ".........................................";
                lblNoiDungQuocTich6.Text = ".........................................";
                lblNoiDungNgayDen6.Text = ".........................................";
                lblNoiDungNgayDi6.Text = ".........................................";

                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCheckOut7_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(7);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                lblNoiDungTenBooking7.Text = ".........................................";
                lblNoiDungTenKhach7.Text = ".........................................";
                lblNoiDungSoKhach7.Text = ".........................................";
                lblNoiDungQuocTich7.Text = ".........................................";
                lblNoiDungNgayDen7.Text = ".........................................";
                lblNoiDungNgayDi7.Text = ".........................................";

                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCheckOut8_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(8);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                phong.CapNhatTrangThai(Phong.TrangThaiPhong.Trong);

                lblNoiDungTenBooking8.Text = ".........................................";
                lblNoiDungTenKhach8.Text = ".........................................";
                lblNoiDungSoKhach8.Text = ".........................................";
                lblNoiDungQuocTich8.Text = ".........................................";
                lblNoiDungNgayDen8.Text = ".........................................";
                lblNoiDungNgayDi8.Text = ".........................................";

                SetBookingRoom();

                MessageBox.Show("Đã check-out phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có khách để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      
       

       
       

       


        

       
        private void lblSoKhach3_Click(object sender, EventArgs e)
        {

        }

        private void lblPhong8_Click(object sender, EventArgs e)
        {

        }

        private void btnChitiet2_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(2);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }

        private void btnChitiet3_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(3);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }

        private void btnChitiet4_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(4);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }

        private void btnChitiet5_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(5);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }

        private void btnChitiet6_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(6);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }

        private void btnChitiet7_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(7);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }

        private void btnChitiet8_Click(object sender, EventArgs e)
        {
            var phong = Phong.GetPhong(8);
            if (phong != null && phong.TrangThai == Phong.TrangThaiPhong.DangO)
            {
                MessageBox.Show("Phòng đang có khách ở, không thể đặt phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmChiTietPhieuPhong fmmhctpp = new frmChiTietPhieuPhong(this);
            fmmhctpp.Show();
            this.Hide();
        }
    }
}
