USE HolyBird
GO

-- Procedure cho Quản lý 2: Cập nhật giá 600.000 (Gây lỗi)
-- Tương tự T1 nhưng không cần Delay dài, dùng để chen ngang
CREATE OR ALTER PROCEDURE sp_TH1_T2_CapNhatGiaLoaiPhong
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
		IF NOT EXISTS (SELECT 1 FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong)
        BEGIN
            ROLLBACK TRAN
            RETURN 0
        END

        UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong
        COMMIT TRAN
        RETURN 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RETURN 0
    END CATCH
END
GO

