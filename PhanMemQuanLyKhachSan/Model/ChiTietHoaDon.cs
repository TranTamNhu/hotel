namespace PhanMemQuanLyKhachSan.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        public int ChiTietHoaDonID { get; set; }

        public int? HoaDonID { get; set; }

        public int? DichVuID { get; set; }

        public int? GiaDV { get; set; }

        public int? SoLuong { get; set; }

        public int? ThanhTien { get; set; }

        public virtual DichVu DichVu { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
    public partial class ChiTietHoaDon
    {
        public static List<ChiTietHoaDon> GetAll()
        {
            QLKSModel context = new QLKSModel();
            return context.ChiTietHoaDons.ToList();
        }
        
        public static ChiTietHoaDon GetChiTietHoaDon(int cthdId)
        {
            QLKSModel context = new QLKSModel();
            return context.ChiTietHoaDons.Where(p => p.ChiTietHoaDonID == cthdId).FirstOrDefault();
        }

        public int InsertUpdate()
        {
            try
            {
                using (var context = new QLKSModel())
                {
                    // Validate required fields
                    if (!HoaDonID.HasValue)
                        throw new Exception("HoaDonID is required");
                    if (!DichVuID.HasValue)
                        throw new Exception("DichVuID is required");
                    if (!SoLuong.HasValue || SoLuong.Value <= 0)
                        throw new Exception("SoLuong must be greater than 0");

                    // Check if the invoice and service exist
                    var hoaDon = context.HoaDons.Find(HoaDonID.Value);
                    var dichVu = context.DichVus.Find(DichVuID.Value);

                    if (hoaDon == null)
                        throw new Exception($"Invoice with ID {HoaDonID.Value} not found");
                    if (dichVu == null)
                        throw new Exception($"Service with ID {DichVuID.Value} not found");

                    // Set the service price if not set
                    if (!GiaDV.HasValue)
                        GiaDV = dichVu.GiaDV;

                    // Calculate total amount
                    ThanhTien = GiaDV * SoLuong;

                    // Add or update the record
                    context.ChiTietHoaDons.AddOrUpdate(this);
                    context.SaveChanges();

                    // Update total amount in HoaDon
                    var totalAmount = context.ChiTietHoaDons
                        .Where(ct => ct.HoaDonID == HoaDonID)
                        .Sum(ct => ct.ThanhTien) ?? 0;

                    hoaDon.TongTien = totalAmount;
                    context.SaveChanges();

                    return ChiTietHoaDonID;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ChiTietHoaDon.InsertUpdate: {ex.Message}");
                throw;
            }
        }
    }
}
