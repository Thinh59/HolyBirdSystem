USE HolyBird
GO

-- T1: Trưởng đoàn xem thông tin giao dịch (Gây lỗi: Đọc 2 lần thấy dữ liệu khác nhau)
CREATE OR ALTER PROCEDURE sp_TH7_T1_XemGiaoDich_TranhChap
    @MaDoan NVARCHAR(10),
    @IsFix INT -- 0: Lỗi, 1: Giải quyết
AS
BEGIN
    -- Nếu giải quyết thì nâng mức cô lập lên REPEATABLE READ (Giữ khóa Shared Lock đến hết giao dịch)
    IF (@IsFix = 1)
        SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
    ELSE
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

    BEGIN TRAN
    BEGIN TRY
        -- B1: Xem thông tin lần 1
        SELECT MaDoan, SoNguoi, SoPhong FROM GIAODICH WHERE MaDoan = @MaDoan;

        -- B2: Tạm dừng 15 giây để Tiếp tân kịp Update ở máy khác
        WAITFOR DELAY '00:00:15';

        -- B3: Xem thông tin lần 2 (Nếu bị lỗi Unrepeatable Read, số người ở đây sẽ khác lần 1)
        SELECT MaDoan, SoNguoi, SoPhong FROM GIAODICH WHERE MaDoan = @MaDoan;

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
    END CATCH
END
GO

