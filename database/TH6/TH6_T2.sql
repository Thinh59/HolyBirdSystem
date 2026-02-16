USE HolyBird
GO

-- T2: Quản lý cập nhật giá phòng VIP
CREATE OR ALTER PROCEDURE sp_TH6_T2_UpdateGiaPhong
    @MaLoaiPhong NVARCHAR(10),
    @DonGia DECIMAL(18,2)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
        -- Kiểm tra tồn tại
        IF NOT EXISTS (SELECT 1 FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong)
        BEGIN
            ROLLBACK TRAN; RETURN 0;
        END

        -- Cập nhật giá mới
        UPDATE LOAIPHONG SET MucGia = @DonGia WHERE MaLoaiPhong = @MaLoaiPhong;
        
        COMMIT TRAN; RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN; RETURN 0;
    END CATCH
END
GO