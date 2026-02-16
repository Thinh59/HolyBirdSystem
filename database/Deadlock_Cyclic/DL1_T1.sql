USE HolyBird
GO

-- LOẠI 1: CYCLIC DEADLOCK (Vòng tròn 2 bảng: PHONG <-> LOAIPHONG)

-- T1: Giữ PHONG -> Cần LOAIPHONG
CREATE OR ALTER PROCEDURE sp_Deadlock_Cyclic_T1
    @MaPhong NVARCHAR(10), 
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2),    -- Giá mới
    @TrangThai NVARCHAR(50)   -- Trạng thái mới
AS
BEGIN
    BEGIN TRAN
    
    -- 1. Khóa bảng PHONG (Cập nhật trạng thái người dùng chọn)
    UPDATE PHONG SET TrangThai = @TrangThai WHERE MaPhong = @MaPhong;
    
    -- 2. Chờ
    WAITFOR DELAY '00:00:10';

    -- 3. Cố gắng Update LOAIPHONG (Cập nhật giá người dùng nhập)
    UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong;

    COMMIT TRAN
    SELECT 1 AS Result; 
END
GO


