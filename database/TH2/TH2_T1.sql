USE HolyBird
GO

-- T1: Tiếp tân xem giá PPS (Gây lỗi Unrepeatable Read)
CREATE OR ALTER PROCEDURE sp_TH2_T1_XemGiaPPS_TranhChap
    @MaPPS NVARCHAR(10),
    @IsFix INT -- 0: Lỗi, 1: Giải quyết
AS
BEGIN
    -- Nếu giải quyết thì nâng mức cô lập lên REPEATABLE READ
    IF (@IsFix = 1)
        SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
    ELSE
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

    BEGIN TRAN
    BEGIN TRY
        -- B1: Xem lần 1
        SELECT TenPPS, GiaPhi FROM PHIPHATSINH WHERE MaPPS = @MaPPS;

        -- B2: Tạm dừng 10 giây để Quản lý kịp Update ở máy khác
        WAITFOR DELAY '00:00:10';

        -- B3: Xem lần 2 (Nếu bị lỗi Unrepeatable Read, giá ở đây sẽ khác lần 1)
        SELECT TenPPS, GiaPhi FROM PHIPHATSINH WHERE MaPPS = @MaPPS;

        COMMIT TRAN
        RETURN 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RETURN 0
    END CATCH
END
GO
