USE HolyBird
GO
-- LOẠI 2: CONVERSION DEADLOCK (Chuyển đổi trên 1 bảng LOAIPHONG)
CREATE OR ALTER PROCEDURE sp_Deadlock_Conversion
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2) -- Giá mới
AS
BEGIN
    -- Repeatable Read giữ khóa Shared (S) đến hết Tran
    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
    BEGIN TRAN

    DECLARE @GiaCu DECIMAL(18,2);
    
    -- 1. Đọc để lấy Shared Lock (S)
    SELECT @GiaCu = MucGia FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong;
    
    -- 2. Chờ máy kia cũng vào đọc
    WAITFOR DELAY '00:00:10'; 

    -- 3. Cố gắng Update (Cần Exclusive Lock -> BÙM)
    UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong;

    COMMIT TRAN
    SELECT 1 AS Result;
END
GO