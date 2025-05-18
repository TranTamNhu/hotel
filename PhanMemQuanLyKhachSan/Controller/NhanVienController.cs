using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan.Controller
{
    public class NhanVienController
    {
        private const string DEFAULT_IMAGE = "user.png";

        public List<NhanVien> GetAllNhanVien()
        {
            return NhanVien.GetAll();
        }

        // Get a specific staff member by ID
        public NhanVien GetNhanVien(int nhanVienID)
        {
            return NhanVien.GetNhanVien(nhanVienID);
        }

        // Add or update a staff member
        public void SaveNhanVien(NhanVien nhanVien)
        {
            nhanVien.InsertUpdate();
        }

        // Delete a staff member
        public void DeleteNhanVien(int nhanVienID)
        {
            NhanVien.Delete(nhanVienID);
        }

        // Search for staff members by name
        public List<NhanVien> SearchNhanVien(string searchText)
        {
            List<NhanVien> allNhanVien = GetAllNhanVien();
            return allNhanVien.Where(p => p.TenNV.ToLower().Contains(searchText.ToLower())).ToList();
        }

        // Create a new NhanVien object
        public NhanVien CreateNhanVien(string tenNV)
        {
            NhanVien nhanVien = new NhanVien
            {
                TenNV = tenNV.Trim(),
                PathImage = DEFAULT_IMAGE // Default image
            };
            return nhanVien;
        }

        // Get the image path for a staff member
        public string GetImagePath(NhanVien nhanVien)
        {
            string imageFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Images");
            string defaultImagePath = Path.Combine(imageFolder, DEFAULT_IMAGE);

            if (nhanVien != null && nhanVien.PathImage != null)
            {
                string customImagePath = Path.Combine(imageFolder, nhanVien.PathImage);
                if (File.Exists(customImagePath))
                {
                    return customImagePath;
                }
            }

            return defaultImagePath;
        }

        // Get the default image path
        public string GetDefaultImagePath()
        {
            string imageFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Images");
            return Path.Combine(imageFolder, DEFAULT_IMAGE);
        }

        // Load image from path
        public Image LoadImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }
            return null;
        }

        // Utility method for styling DataGridView
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

        // Populate DataGridView with staff members
        public void PopulateDataGridView(DataGridView dgv, List<NhanVien> listNhanVien)
        {
            dgv.Rows.Clear();
            int id = 1;
            foreach (var item in listNhanVien)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = id++;
                dgv.Rows[index].Cells[1].Value = item.NhanVienID;
                dgv.Rows[index].Cells[2].Value = item.TenNV;
            }
        }
    }
}