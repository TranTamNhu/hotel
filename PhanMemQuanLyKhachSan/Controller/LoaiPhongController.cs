using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan.Controller
{
    public class LoaiPhongController
    {
        // Lấy danh sách tất cả các phòng kèm thông tin loại phòng
        public List<Phong> GetAllPhongs()
        {
            try
            {
                using (QLKSModel context = new QLKSModel())
                {
                    // Sử dụng Include để load cả thông tin LoaiPhong
                    return context.Phongs.Include(p => p.LoaiPhong).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách phòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Phong>();
            }
        }

        // Lấy thông tin phòng theo ID
        public Phong GetPhongById(int phongID)
        {
            try
            {
                return Phong.GetPhong(phongID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy thông tin phòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Cập nhật loại phòng
        public bool UpdateLoaiPhong(int phongID, int loaiPhongID)
        {
            try
            {
                using (QLKSModel context = new QLKSModel())
                {
                    var phongToUpdate = context.Phongs.Find(phongID);

                    if (phongToUpdate == null)
                    {
                        MessageBox.Show($"Không tìm thấy phòng có ID: {phongID} trong cơ sở dữ liệu!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    phongToUpdate.LoaiPhongID = loaiPhongID;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Kiểm tra ID phòng có hợp lệ không
        public bool IsValidPhongID(int phongID)
        {
            return phongID > 0;
        }
    }
}