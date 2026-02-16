USE HolyBird
GO

-- T2: Quản lý 2 cập nhật thành 'Đang đặt trước' (Chạy nhanh)
-- Procedure này dùng cho máy 2 chen ngang
CREATE OR ALTER PROCEDURE sp_TH5_T2_UpdateTrangThai
    @MaPhong NVARCHAR(10),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    BEGIN TRAN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM PHONG WHERE MaPhong = @MaPhong)
        BEGIN
            ROLLBACK TRAN
            RETURN 0
        END

        -- Cập nhật ngay lập tức
        UPDATE PHONG SET TrangThai = @TrangThai WHERE MaPhong = @MaPhong
        
        COMMIT TRAN
        RETURN 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RETURN 0
    END CATCH
END
GO

