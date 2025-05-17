using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan.Controller
{
    public class LichLamViecController
    {
        // Lấy tất cả lịch làm việc
        public List<LichLamViec> GetAllLichLamViec()
        {
            try
            {
                return LichLamViec.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<LichLamViec>();
            }
        }

        // Lấy tất cả nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            try
            {
                return NhanVien.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<NhanVien>();
            }
        }

        // Thêm hoặc cập nhật lịch làm việc
        public bool InsertUpdateLichLamViec(LichLamViec lichLamViec)
        {
            try
            {
                LichLamViec db = LichLamViec.GetLichLamViec(lichLamViec.LichLamViecID);

                if (db == null) // Thêm mới
                {
                    lichLamViec.InsertUpdate();
                    return true;
                }
                else // Cập nhật
                {
                    db = lichLamViec;
                    db.InsertUpdate();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // Xóa lịch làm việc
        public bool DeleteLichLamViec(int lichLamViecID)
        {
            try
            {
                LichLamViec.Delete(lichLamViecID);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // Lấy thông tin lịch làm việc theo ID
        public LichLamViec GetLichLamViecByID(int lichLamViecID)
        {
            return LichLamViec.GetLichLamViec(lichLamViecID);
        }
    }
}