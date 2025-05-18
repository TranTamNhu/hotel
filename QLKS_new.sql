-- Tạo database mới hoàn toàn
USE [master]
GO

-- Kiểm tra nếu database đã tồn tại thì xóa đi
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'PMQLKS_NEW')
BEGIN
    ALTER DATABASE [PMQLKS_NEW] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [PMQLKS_NEW];
END
GO

-- Tạo database mới (phiên bản đơn giản, không chỉ định file)
CREATE DATABASE [PMQLKS_NEW]
GO

USE [PMQLKS_NEW]
GO

-- 1. Bảng KhachHang
CREATE TABLE [dbo].[KhachHang](
    [KhachHangID] [int] IDENTITY(1,1) NOT NULL,
    [TenKH] [nvarchar](50) NULL,
    [QuocTich] [varchar](50) NULL,
    PRIMARY KEY CLUSTERED ([KhachHangID] ASC)
)
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (1, N'Thủy Tiên', N'Vietnam')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (2, N'Đồng Phương', N'canada')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (3, N'ABC', N'VN')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (4, N'1', N'VN')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (5, N'1', N'VN')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (6, N'abc', N'vvv')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (7, N'abc', N'cb')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (8, N'văn E', N'newzealand')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (9, N'tiên nguyễn 00', N'hàn')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (10, N'Lê Đồng Phương', N'châu phi')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (11, N'Đồng Bóng Phương', N'Congo')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (12, N'Đạt Nguyễn', N'm?')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (13, N'abcxyz', N'havana')
INSERT [dbo].[KhachHang] ([KhachHangID], [TenKH], [QuocTich]) VALUES (14, N'Lam Lam', N'mongo')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF


/*SELECT *FROM KhachHang;*/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 2. Bảng NhanVien
CREATE TABLE [dbo].[NhanVien](
    [NhanVienID] [int] IDENTITY(1,1) NOT NULL,
    [TenNV] [nvarchar](50) NULL,
    [PathImage] [nvarchar](200) NULL,
    PRIMARY KEY CLUSTERED ([NhanVienID] ASC)
)
SET IDENTITY_INSERT [dbo].[NhanVien] ON
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [PathImage]) VALUES (1, N'Hữu Đạt', N'1.jpg')
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [PathImage]) VALUES (2, N'Phương', N'2.jpg')
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [PathImage]) VALUES (3, N'Thủy Tiên', N'3.jpg')
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [PathImage]) VALUES (8, N'Thanh Lam', N'4.jpg')
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [PathImage]) VALUES (9, N'Văn B', NULL)
INSERT [dbo].[NhanVien] ([NhanVienID], [TenNV], [PathImage]) VALUES (11, N'Văn C', NULL)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
/*SELECT *FROM NhanVien;*/
-- 3. Bảng MatKhau
CREATE TABLE [dbo].[MatKhau](
    [username] [varchar](50) NOT NULL,
    [password] [varchar](50) NULL,
    PRIMARY KEY CLUSTERED ([username] ASC)
)
SET ANSI_PADDING OFF
GO
INSERT [dbo].[MatKhau] ([username], [password]) VALUES (N'dongphuong', N'1999')
INSERT [dbo].[MatKhau] ([username], [password]) VALUES (N'phamchicong', N'pass')
INSERT [dbo].[MatKhau] ([username], [password]) VALUES (N'thuytien', N'331212')
INSERT [dbo].[MatKhau] ([username], [password]) VALUES (N'tamnhu', N'270225')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
/*SELECT *FROM MatKhau;*/

-- 4. Bảng LoaiPhong
CREATE TABLE [dbo].[LoaiPhong](
    [LoaiPhongID] [int] IDENTITY(1,1) NOT NULL,
    [TenLoai] [varchar](15) NULL,
    PRIMARY KEY CLUSTERED ([LoaiPhongID] ASC)
)
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiPhong] ON
INSERT [dbo].[LoaiPhong] ([LoaiPhongID], [TenLoai]) VALUES (1, N'Standard')
INSERT [dbo].[LoaiPhong] ([LoaiPhongID], [TenLoai]) VALUES (2, N'Deluxe')
INSERT [dbo].[LoaiPhong] ([LoaiPhongID], [TenLoai]) VALUES (3, N'Superior')
SET IDENTITY_INSERT [dbo].[LoaiPhong] OFF
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*SELECT *FROM LoaiPhong;*/
-- 5. Bảng Booking
CREATE TABLE [dbo].[Booking](
    [BookingID] [int] IDENTITY(1,1) NOT NULL,
    [TenBooking] [nvarchar](50) NULL,
    PRIMARY KEY CLUSTERED ([BookingID] ASC)
)
SET IDENTITY_INSERT [dbo].[Booking] ON
INSERT [dbo].[Booking] ([BookingID], [TenBooking]) VALUES (1, N'Agoda')
INSERT [dbo].[Booking] ([BookingID], [TenBooking]) VALUES (2, N'Travel Loka')
INSERT [dbo].[Booking] ([BookingID], [TenBooking]) VALUES (3, N'Booking.com')
INSERT [dbo].[Booking] ([BookingID], [TenBooking]) VALUES (4, N'Expedia')
INSERT [dbo].[Booking] ([BookingID], [TenBooking]) VALUES (5, N'AirBnB')
INSERT [dbo].[Booking] ([BookingID], [TenBooking]) VALUES (6, N'Khách Tự Đến')
INSERT [dbo].[Booking] ([BookingID], [TenBooking]) VALUES (7, N'Khách Đối Tác')
SET IDENTITY_INSERT [dbo].[Booking] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*SELECT *FROM Booking;*/
-- 6. Bảng DichVu
CREATE TABLE [dbo].[DichVu](
    [DichVuID] [int] IDENTITY(1,1) NOT NULL,
    [TenDV] [nvarchar](50) NULL,
    [GiaDV] [int] NULL,
    PRIMARY KEY CLUSTERED ([DichVuID] ASC)
)
SET IDENTITY_INSERT [dbo].[DichVu] ON
INSERT [dbo].[DichVu] ([DichVuID], [TenDV], [GiaDV]) VALUES (1, N'fanta', 30000)
INSERT [dbo].[DichVu] ([DichVuID], [TenDV], [GiaDV]) VALUES (2, N'trà xanh', 15000)
INSERT [dbo].[DichVu] ([DichVuID], [TenDV], [GiaDV]) VALUES (3, N'bò cụng', 15000)
INSERT [dbo].[DichVu] ([DichVuID], [TenDV], [GiaDV]) VALUES (7, N'tour củ chi', 485000)
INSERT [dbo].[DichVu] ([DichVuID], [TenDV], [GiaDV]) VALUES (8, N'tiễn sân bay', 200000)
SET IDENTITY_INSERT [dbo].[DichVu] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*SELECT *FROM DichVu;*/

-- 7. Bảng VatTu
CREATE TABLE [dbo].[VatTu](
    [VatTuID] [int] IDENTITY(1,1) NOT NULL,
    [TenVT] [nvarchar](50) NULL,
    PRIMARY KEY CLUSTERED ([VatTuID] ASC)
)
SET IDENTITY_INSERT [dbo].[VatTu] ON
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (3, N'Bàn Ủi')
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (4, N'Dép')
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (5, N'Bàn Gỗ')
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (11, N'Thùng Rác')
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (14, N'Bàn Ủi')
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (17, N'Tivi')
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (18, N'tủ lạnh')
INSERT [dbo].[VatTu] ([VatTuID], [TenVT]) VALUES (19, N'Tách Trà')
SET IDENTITY_INSERT [dbo].[VatTu] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*SELECT*FROM VatTu;*/

-- 8. Bảng Phong
CREATE TABLE [dbo].[Phong](
    [PhongID] [int] IDENTITY(1,1) NOT NULL,
    [LoaiPhongID] [int] NULL,
    [GiaPhong] [int] NULL,
    PRIMARY KEY CLUSTERED ([PhongID] ASC)
)
SET IDENTITY_INSERT [dbo].[Phong] ON
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (1, 1, 500000)
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (2, 1, 500000)
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (3, 1, 500000)
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (4, 3, 700000)
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (5, 3, 700000)
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (6, 2, 1000000)
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (7, 2, 1000000)
INSERT [dbo].[Phong] ([PhongID], [LoaiPhongID], [GiaPhong]) VALUES (8, 2, 1000000)
SET IDENTITY_INSERT [dbo].[Phong] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
/*SELECT *FROM Phong*/

-- 9. Bảng LichLamViec
CREATE TABLE [dbo].[LichLamViec](
    [LichLamViecID] [int] IDENTITY(1,1) NOT NULL,
    [NhanVienID] [int] NULL,
    [Ca] [nvarchar](10) NULL,
    [Ngay] [varchar](50) NULL,
    PRIMARY KEY CLUSTERED ([LichLamViecID] ASC)
)
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LichLamViec] ON
INSERT [dbo].[LichLamViec] ([LichLamViecID], [NhanVienID], [Ca], [Ngay]) VALUES (1, 1, N'sáng', N'10/5/2025')
INSERT [dbo].[LichLamViec] ([LichLamViecID], [NhanVienID], [Ca], [Ngay]) VALUES (2, 2, N'trưa', N'10/5/2025')
INSERT [dbo].[LichLamViec] ([LichLamViecID], [NhanVienID], [Ca], [Ngay]) VALUES (3, 3, N'tối', N'10/5/2025')
INSERT [dbo].[LichLamViec] ([LichLamViecID], [NhanVienID], [Ca], [Ngay]) VALUES (6, 8, N'sáng', N'11/5/2025')
INSERT [dbo].[LichLamViec] ([LichLamViecID], [NhanVienID], [Ca], [Ngay]) VALUES (7, 9, N'trưa', N'11/5/2025')
INSERT [dbo].[LichLamViec] ([LichLamViecID], [NhanVienID], [Ca], [Ngay]) VALUES (8, 1, N'sáng', N'12/5/2025')
SET IDENTITY_INSERT [dbo].[LichLamViec] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
/*SELECT *FROM LichLamViec;*/

-- 10. Bảng HoaDon
CREATE TABLE [dbo].[HoaDon](
    [HoaDonID] [int] IDENTITY(1,1) NOT NULL,
    [NhanVienID] [int] NULL,
    [KhachHangID] [int] NULL,
    [PhongID] [int] NULL,
    [TenLoai] [varchar](15) NULL,
    [SoDem] [int] NULL,
    [SoKhach] [int] NULL,
    [NgayHD] [varchar](15) NULL,
    [TongTien] [int] NULL,
    [BookingID] [int] NULL,
    PRIMARY KEY CLUSTERED ([HoaDonID] ASC)
)
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (1, 1, 1, 3, N'Deluxe', 2, 10, N'15/5/2019', 1460000, 1)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (2, 1, 2, 1, N'Standard', 2, 1, N'15/5/2019', 1030000, 1)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (3, 1, 3, 2, N'Deluxe', 2, 1, N'23/5/2019', 2060000, 1)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (4, 1, 4, 1, N'Standard', 3, 3, N'15/5/2019', 1575000, 1)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (5, 1, 5, 1, N'Standard', 1, 2, N'15/5/2019', 530000, 1)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (6, 1, 6, 1, N'Standard', 2, 2, N'15/5/2019', 1030000, 3)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (7, 1, 7, 2, N'Standard', 1, 2, N'17/5/2019', 515000, 5)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (8, 1, 8, 1, N'Standard', 2, 2, N'17/5/2019', 1200000, 6)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (9, 1, 9, 1, N'Standard', 2, 3, N'17/5/2019', 1485000, 2)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (10, 1, 10, 3, N'Standard', 1, 3, N'17/5/2019', 515000, 4)
INSERT [dbo].[HoaDon] ([HoaDonID], [NhanVienID], [KhachHangID], [PhongID], [TenLoai], [SoDem], [SoKhach], [NgayHD], [TongTien], [BookingID]) VALUES (11, 1, 14, 4, N'Superior', 1, 3, N'17/5/2019', 730000, 7)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*SELECT* FROM HoaDon;*/

-- 11. Bảng ChiTietHoaDon
CREATE TABLE [dbo].[ChiTietHoaDon](
    [ChiTietHoaDonID] [int] IDENTITY(1,1) NOT NULL,
    [HoaDonID] [int] NULL,
    [DichVuID] [int] NULL,
    [GiaDV] [int] NULL,
    [SoLuong] [int] NULL,
    [ThanhTien] [int] NULL,
    PRIMARY KEY CLUSTERED ([ChiTietHoaDonID] ASC)
)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (1, 1, 1, 30000, 2, 60000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (2, 1, 1, 30000, 1, 30000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (3, 1, 1, 30000, 1, 30000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (4, 1, 1, 30000, 1, 30000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (5, 1, 2, 15000, 3, 45000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (6, 1, 2, 15000, 2, 30000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (7, 1, 1, 30000, 1, 30000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (8, 1, 1, 30000, 1, 30000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (9, 1, 2, 15000, 1, 15000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (10, 1, 8, 200000, 1, 200000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (11, 1, 7, 485000, 1, 485000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (12, 1, 2, 15000, 1, 15000)
INSERT [dbo].[ChiTietHoaDon] ([ChiTietHoaDonID], [HoaDonID], [DichVuID], [GiaDV], [SoLuong], [ThanhTien]) VALUES (13, 1, 1, 30000, 1, 30000)
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
/*SELECT *FROM ChiTietHoaDon;*/

-- Tạo các ràng buộc khóa ngoại
ALTER TABLE [dbo].[Phong] ADD CONSTRAINT [FK_Phong_LoaiPhong] FOREIGN KEY([LoaiPhongID]) REFERENCES [dbo].[LoaiPhong] ([LoaiPhongID])
ALTER TABLE [dbo].[LichLamViec] ADD CONSTRAINT [FK_LichLamViec_NhanVien] FOREIGN KEY([NhanVienID]) REFERENCES [dbo].[NhanVien] ([NhanVienID])
ALTER TABLE [dbo].[HoaDon] ADD CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([KhachHangID]) REFERENCES [dbo].[KhachHang] ([KhachHangID])
ALTER TABLE [dbo].[HoaDon] ADD CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([NhanVienID]) REFERENCES [dbo].[NhanVien] ([NhanVienID])
ALTER TABLE [dbo].[HoaDon] ADD CONSTRAINT [FK_HoaDon_Phong] FOREIGN KEY([PhongID]) REFERENCES [dbo].[Phong] ([PhongID])
ALTER TABLE [dbo].[ChiTietHoaDon] ADD CONSTRAINT [FK_ChiTietHoaDon_DichVu] FOREIGN KEY([DichVuID]) REFERENCES [dbo].[DichVu] ([DichVuID])
ALTER TABLE [dbo].[ChiTietHoaDon] ADD CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([HoaDonID]) REFERENCES [dbo].[HoaDon] ([HoaDonID])
GO

-- Thông báo thành công
SELECT * FROM LichLamViec
WHERE NhanVienID IS NULL
   OR NhanVienID NOT IN (SELECT NhanVienID FROM NhanVien)

