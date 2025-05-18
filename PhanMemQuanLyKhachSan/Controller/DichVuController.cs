using PhanMemQuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PhanMemQuanLyKhachSan.Controller
{
    public class DichVuController
    {
        // Get all services
        public List<DichVu> GetAllDichVu()
        {
            return DichVu.GetAll();
        }

        // Get a specific service by ID
        public DichVu GetDichVu(int dichVuID)
        {
            return DichVu.GetDichVu(dichVuID);
        }

        // Add or update a service
        public void SaveDichVu(DichVu dichVu)
        {
            dichVu.InsertUpdate();
        }

        // Delete a service
        public void DeleteDichVu(int dichVuID)
        {
            DichVu.Delete(dichVuID);
        }

        // Create a new DichVu object
        public DichVu CreateDichVu(string tenDV, int giaDV)
        {
            DichVu dichVu = new DichVu
            {
                TenDV = tenDV,
                GiaDV = giaDV
            };
            return dichVu;
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

        // Populate DataGridView with services
        public void PopulateDataGridView(DataGridView dgv, List<DichVu> listDichVu)
        {
            dgv.Rows.Clear();
            int id = 1;
            foreach (var item in listDichVu)
            {
                int index = dgv.Rows.Add();
                dgv.Rows[index].Cells[0].Value = id++;
                dgv.Rows[index].Cells[1].Value = item.DichVuID;
                dgv.Rows[index].Cells[2].Value = item.TenDV;
                dgv.Rows[index].Cells[3].Value = item.GiaDV;
            }
        }

        // Validate service inputs
        public bool ValidateServiceInput(string tenDV, string giaDVText, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(tenDV))
            {
                errorMessage = "Tên dịch vụ không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(giaDVText))
            {
                errorMessage = "Giá dịch vụ không được để trống!";
                return false;
            }

            if (!int.TryParse(giaDVText, out int giaDV))
            {
                errorMessage = "Giá dịch vụ phải là số!";
                return false;
            }

            if (giaDV < 0)
            {
                errorMessage = "Giá dịch vụ không được âm!";
                return false;
            }

            return true;
        }
    }
}