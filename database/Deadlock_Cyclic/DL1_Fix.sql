USE HolyBird
GO
CREATE OR ALTER PROCEDURE sp_Deadlock_Cyclic_Fix
    @MaPhong NVARCHAR(10), 
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    BEGIN TRAN
    BEGIN TRY
        -- Tuân thủ thứ tự: PHONG trước -> LOAIPHONG sau
        UPDATE PHONG SET TrangThai = @TrangThai WHERE MaPhong = @MaPhong;
        
        WAITFOR DELAY '00:00:10'; -- Giả lập xử lý lâu (Test Blocking)
        
        UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong;

        COMMIT TRAN
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        SELECT 0 AS Result;
    END CATCH
END
GO