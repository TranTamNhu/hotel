﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PhanMemQuanLyKhachSan.Model;

namespace PhanMemQuanLyKhachSan
{
    public partial class frmQuanLyPhong : Form
    {
        public frmQuanLyPhong()
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
        private void BindGrid(List<Phong> listPhong)
        {
            dgvQuanLyPhong.Rows.Clear();

            foreach (var item in listPhong)
            {
                int index = dgvQuanLyPhong.Rows.Add();
                dgvQuanLyPhong.Rows[index].Cells[0].Value = item.PhongID;
                dgvQuanLyPhong.Rows[index].Cells[1].Value = item.LoaiPhong.TenLoai;
                dgvQuanLyPhong.Rows[index].Cells[2].Value = item.GiaPhong;
                dgvQuanLyPhong.Rows[index].Cells[3].Value = item.TrangThai;

                // Đặt màu cho từng trạng thái
                switch (item.TrangThai)
                {
                    case "Trống":
                        dgvQuanLyPhong.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Đang ở":
                        dgvQuanLyPhong.Rows[index].DefaultCellStyle.BackColor = Color.LightPink;
                        break;
                    case "Đã đặt":
                        dgvQuanLyPhong.Rows[index].DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case "Bảo trì":
                        dgvQuanLyPhong.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                }
            }
        }
        private void ButtonCapNhapLoaiPhong_Click(object sender, EventArgs e)
        {
            frmCapNhatLoaiPhong fmb = new frmCapNhatLoaiPhong();
            fmb.Show();
            this.Hide();
        }
        private void fmb_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmCapNhatDichVu fmdv = new frmCapNhatDichVu();
            fmdv.Show();
            this.Hide();
        }
        private void fmdv_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmCapNhatVatTu fmvt = new frmCapNhatVatTu();
            fmvt.Show();
            this.Hide();
        }
        private void fmvt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void BtnTroVeCuaCTPP_Click(object sender, EventArgs e)
        {
            frmManHinhChinh mhc = new frmManHinhChinh();
            mhc.Show();
            this.Hide();
        }

        private void dgvQuanLyPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvQuanLyPhong.Rows[e.RowIndex];
                var phongId = int.Parse(row.Cells[0].Value.ToString());
                var phong = Phong.GetPhong(phongId);
                
                if (phong != null)
                {
                    if (phong.TrangThai == "Trống")
                    {
                        // Nếu phòng trống thì cho phép đặt phòng
                        var mainForm = Application.OpenForms.OfType<frmManHinhChinh>().FirstOrDefault();
                        frmChiTietPhieuPhong ctpp;
                        
                        if (mainForm != null)
                        {
                            ctpp = new frmChiTietPhieuPhong(mainForm, phongId);
                        }
                        else
                        {
                            ctpp = new frmChiTietPhieuPhong(phongId);
                        }
                        
                        ctpp.FormClosed += (s, args) => {
                            this.Show();
                            BindGrid(Phong.GetAll()); // Refresh lại danh sách phòng
                        };
                        ctpp.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show($"Phòng đang trong trạng thái {phong.TrangThai}, không thể đặt phòng!", 
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvQuanLyPhong);
                KhoiTaoTrangThaiPhong();
                BindGrid(Phong.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void KhoiTaoTrangThaiPhong()
        {
            try
            {
                var context = new QLKSModel();
                var phongsChuaCoTrangThai = context.Phongs.Where(p => p.TrangThai == null || p.TrangThai == "").ToList();
                
                foreach (var phong in phongsChuaCoTrangThai)
                {
                    phong.TrangThai = "Trống";
                }
                
                if (phongsChuaCoTrangThai.Any())
                {
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo trạng thái phòng: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
