USE HolyBird
GO
-- T2: Giữ LOAIPHONG -> Cần PHONG
CREATE OR ALTER PROCEDURE sp_Deadlock_Cyclic_T2
    @MaPhong NVARCHAR(10), 
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2),    -- Giá mới
    @TrangThai NVARCHAR(50)   -- Trạng thái mới
AS
BEGIN
    BEGIN TRAN

    -- 1. Khóa bảng LOAIPHONG trước
    UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong;

    -- 2. Chờ
    WAITFOR DELAY '00:00:10';

    -- 3. Cố gắng Update PHONG
    UPDATE PHONG SET TrangThai = @TrangThai WHERE MaPhong = @MaPhong;

    COMMIT TRAN
    SELECT 1 AS Result; 
END
GO