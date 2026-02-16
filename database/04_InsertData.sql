USE HolyBird
GO

PRINT N'--- Đang dọn dẹp hệ thống...'
EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'
DELETE FROM CT_PHIPS; DELETE FROM HOADON; DELETE FROM THETU; 
DELETE FROM CT_GIAODICH; DELETE FROM GIAODICH; DELETE FROM PHONG; 
DELETE FROM NHANVIEN; DELETE FROM KHACHHANG; DELETE FROM PHIPHATSINH; 
DELETE FROM LOAIPHONG; DELETE FROM TAIKHOAN; DELETE FROM DAILY;
EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'
GO

PRINT N'--- Đang nạp danh mục Đại lý và Loại phòng...'

INSERT INTO DAILY (MaDaiLy, TenDaiLy, SDT_DL, DiaChiDL) VALUES
(N'RESORT', N'HolyBird Resort Nha Trang (Trụ sở)', N'0258300111', N'Trần Phú, Nha Trang'),
(N'DL_HCM', N'Đại lý HolyBird TP. Hồ Chí Minh', N'0283800111', N'Quận 1, TP.HCM'),
(N'DL_HN', N'Đại lý HolyBird Hà Nội', N'0243900111', N'Hoàn Kiếm, Hà Nội'),
(N'DL_DN', N'Đại lý HolyBird Đà Nẵng', N'0236300111', N'Hải Châu, Đà Nẵng');

INSERT INTO LOAIPHONG (MaLoaiPhong, Hang, HinhThuc, MucGia) VALUES
(N'LP01', N'Thường', N'1 giường đơn', 300000),
(N'LP02', N'Trung bình', N'2 giường đơn', 600000),
(N'LP03', N'Sang', N'1 giường đôi', 1200000),
(N'LP04', N'Rất sang', N'2 giường đôi', 2500000),
(N'LP05', N'VIP', N'2 giường đôi', 5000000);

PRINT N'--- Đang khởi tạo 13 tầng phòng (15 phòng/tầng)...'
DECLARE @t INT = 1;
WHILE @t <= 13
BEGIN
    DECLARE @p INT = 1;
    WHILE @p <= 15
    BEGIN
        DECLARE @MaP INT = @t * 100 + @p;
        DECLARE @Loai NVARCHAR(10) = CASE 
            WHEN @t <= 5 THEN N'LP01'
            WHEN @t <= 8 THEN N'LP02'
            WHEN @t <= 11 THEN N'LP03'
            WHEN @t = 12 THEN N'LP04'
            ELSE N'LP05' END;

        INSERT INTO PHONG (MaPhong, Tang, MaLoaiPhong, TrangThai) 
        VALUES (@MaP, @t, @Loai, N'Đang trống');
        SET @p = @p + 1;
    END
    SET @t = @t + 1;
END
GO

PRINT N'--- Đang nạp nhân sự...'

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, TrangThaiTK) VALUES
(N'tt_resort', N'123456', N'Tiếp tân', N'Hoạt động'),
(N'tt_hcm', N'123456', N'Tiếp tân', N'Hoạt động'),
(N'tt_hn', N'123456', N'Tiếp tân', N'Hoạt động'),
(N'ql_resort', N'123456', N'Quản lý', N'Hoạt động'),
(N'admin_sys', N'123456', N'Quản trị viên', N'Hoạt động');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, TrangThaiTK) VALUES
(N'ql_resort1', N'123456', N'Quản lý', N'Hoạt động')

INSERT INTO NHANVIEN (MaNV, HoTenNV, NgaySinhNV, SDT_NV, EmailNV, ChucVu, MaDaiLy, TenDangNhap) VALUES
(N'NV_RS01', N'Lê Tiếp Tân Resort', '1995-01-01', N'0901000001', N'tt_rs@hb.vn', N'Tiếp tân', N'RESORT', N'tt_resort'),
(N'NV_QL01', N'Nguyễn Quản Lý', '1985-01-01', N'0901000002', N'ql@hb.vn', N'Quản lý', N'RESORT', N'ql_resort'),
(N'NV_QL02', N'Nguyễn Quản Lý2', '1985-01-01', N'0901000004', N'ql@hb.vn', N'Quản lý', N'RESORT', N'ql_resort'),
(N'NV_HCM01', N'Trần Tiếp Tân HCM', '1996-02-02', N'0902000001', N'tt_hcm@hb.vn', N'Tiếp tân', N'DL_HCM', N'tt_hcm'),
(N'NV_HN01', N'Phạm Tiếp Tân HN', '1997-03-03', N'0903000001', N'tt_hn@hb.vn', N'Tiếp tân', N'DL_HN', N'tt_hn'),
(N'NV_ADMIN', N'Ngô Quản Trị', '1988-08-08', N'0900000000', N'admin@hb.vn', N'Quản trị viên', N'RESORT', N'admin_sys');

INSERT INTO NHANVIEN (MaNV, HoTenNV, NgaySinhNV, SDT_NV, EmailNV, ChucVu, MaDaiLy, TenDangNhap) VALUES
(N'NV_QL03', N'Nguyễn Quản Lý2', '1985-01-01', N'0901000004', N'ql@hb.vn', N'Quản lý', N'RESORT', N'ql_resort1')

PRINT N'--- Đang nạp kịch bản Giao dịch & Tài khoản Đoàn...'

INSERT INTO KHACHHANG (CMND, HoTenKH, NgaySinhKH, SDT_KH, EmailKH, DiaChiKH) VALUES
(N'12345', N'Mạnh Trường Thanh', '1980-05-15', N'0988123456', N'thanh@gmail.com', N'Hà Nội'),
(N'67557', N'Trương Thúy Hằng', '1982-10-20', N'0988123457', N'hang@gmail.com', N'Hà Nội'),
(N'079000111222', N'Lê Văn Test', '1990-01-01', N'0900111222', N'test@gmail.com', N'Đà Nẵng');

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan) VALUES (N'D00112345', N'123', N'Khách hàng');

INSERT INTO GIAODICH (MaDoan, DaiDienDoan, SoNguoi, SoPhong, NgayBD, NgayKT, MaNV, MaDaiLy, TenDangNhap) VALUES
(N'D001', N'12345', 4, 2, '2026-01-10 07:00:00', '2026-01-15 12:00:00', N'NV_HN01', N'DL_HN', N'D00112345');

INSERT INTO CT_GIAODICH (MaCTGD, MaDoan, NgayBD, NgayKT, TrangThaiGD, CMND, MaPhong, CaNhan) VALUES
(N'CT01', N'D001', '2026-01-10 07:00:00', '2026-01-15 12:00:00', N'Đang sử dụng', N'12345', 203, N'12345'),
(N'CT02', N'D001', '2026-01-10 07:00:00', '2026-01-15 12:00:00', N'Đang sử dụng', N'12345', 204, N'67557');

UPDATE PHONG SET TrangThai = N'Đang có khách' WHERE MaPhong IN (203, 204);

DECLARE @StartTime DATETIME = DATEADD(HOUR, -3, GETDATE());
INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan) VALUES (N'D00267557', N'123', N'Khách hàng');

INSERT INTO GIAODICH (MaDoan, DaiDienDoan, SoNguoi, SoPhong, NgayBD, NgayKT, MaNV, MaDaiLy, TenDangNhap) VALUES
(N'D002', N'67557', 1, 1, @StartTime, DATEADD(DAY, 1, GETDATE()), N'NV_RS01', N'RESORT', N'D00267557');

INSERT INTO CT_GIAODICH (MaCTGD, MaDoan, NgayBD, NgayKT, TrangThaiGD, CMND, MaPhong, CaNhan) VALUES
(N'CT03', N'D002', @StartTime, DATEADD(DAY, 1, GETDATE()), N'Chưa nhận phòng', N'67557', 501, N'67557');


INSERT INTO PHIPHATSINH (MaPPS, TenPPS, GiaPhi) VALUES
(N'DV01', N'Nước suối', 20000),
(N'BT01', N'Bồi thường hư hại', 500000);

GO
PRINT N'--- HỆ THỐNG ĐÃ SẴN SÀNG ĐỂ TEST! ---'

INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, TrangThaiTK) 
VALUES (N'DIRTY_USER', N'123', N'Khách hàng', N'Hoạt động');

INSERT INTO GIAODICH (MaDoan, DaiDienDoan, SoNguoi, SoPhong, NgayBD, NgayKT, MaNV, MaDaiLy, TenDangNhap)
VALUES (N'GD_DIRTY', N'079000111222', 2, 1, '2026-01-01', '2026-01-05', N'NV_RS01', N'RESORT', N'DIRTY_USER');


INSERT INTO CT_GIAODICH (MaCTGD, MaDoan, NgayBD, NgayKT, TrangThaiGD, CMND, MaPhong, CaNhan, ThanhTien, TongPhiPhatSinh)
VALUES (N'CT_DIRTY', N'GD_DIRTY', '2026-01-01', '2026-01-05', N'Chờ lập hóa đơn', N'079000111222', 101, N'Lê Văn Test', 1200000, 50000);

INSERT INTO CT_PHIPS (MaCTGD, MaDoan, MaPPS, SoLuong, ThanhTienPPS)
VALUES (N'CT_DIRTY', N'GD_DIRTY', N'DV01', 2, 40000);

PRINT N'--- Đã nạp thành công đoàn GD_DIRTY. Bây giờ bạn có thể mở TT6 để lập hóa đơn! ---'

USE HolyBird
GO

PRINT N'--- Bắt đầu tạo dữ liệu Thẻ từ (Chỉ thêm mới, không xóa cũ)...'

DECLARE @i INT = 1;
DECLARE @MaThe NVARCHAR(10);

WHILE @i <= 50
BEGIN
    SET @MaThe = 'T' + RIGHT('000' + CAST(@i AS NVARCHAR(10)), 3);

    IF NOT EXISTS (SELECT 1 FROM THETU WHERE MaThe = @MaThe)
    BEGIN
        INSERT INTO THETU (MaThe, MaCTGD, NgayCap, NgayHetHan, TrangThaiThe)
        VALUES (@MaThe, NULL, NULL, NULL, N'Đang hoạt động');
    END

    SET @i = @i + 1;
END

PRINT N'--- Hoàn tất! Đã có dữ liệu Thẻ từ để test.'
GO

SELECT * FROM THETU;

USE HolyBird
GO

PRINT N'--- Bổ sung hóa đơn sẵn cho TH8 (Dirty Read) và TH3 ---'

IF NOT EXISTS (SELECT 1 FROM HOADON WHERE MaHD = 'HD_DIRTY')
BEGIN
    INSERT INTO HOADON (MaHD, MaDoan, NVLap, NgayLap, TongTien, TrangThaiHD)
    VALUES (
        N'HD_DIRTY',       
        N'GD_DIRTY',       
        N'NV_RS01',        
        GETDATE(),         
        1250000,           
        N'Chờ thanh toán'  
    );
END

UPDATE CT_GIAODICH 
SET TrangThaiGD = N'Đã lập hóa đơn'
WHERE MaDoan = N'GD_DIRTY';

PRINT N'--- Đã xong! Bây giờ vào Form Thanh Toán sẽ thấy ngay hóa đơn HD_DIRTY ---'
GO