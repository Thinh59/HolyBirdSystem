USE HolyBird
GO
-- T2: Tiếp tân cập nhật số người trong đoàn (Chen ngang)
CREATE OR ALTER PROCEDURE sp_TH7_T2_UpdateSoNguoi
    @MaDoan NVARCHAR(10),
    @SoNguoiMoi INT
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
        -- Kiểm tra tồn tại
        IF NOT EXISTS (SELECT 1 FROM GIAODICH WHERE MaDoan = @MaDoan)
        BEGIN
            ROLLBACK TRAN; RETURN 0;
        END

        -- Cập nhật số người mới
        UPDATE GIAODICH SET SoNguoi = @SoNguoiMoi WHERE MaDoan = @MaDoan;
        
        COMMIT TRAN; RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN; RETURN 0;
    END CATCH
END
GO