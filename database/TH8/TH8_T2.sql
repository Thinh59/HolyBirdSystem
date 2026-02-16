USE HolyBird
GO

CREATE OR ALTER PROCEDURE sp_TH8_T2_CapNhatGiaPPS_TranhChap
    @MaPPS NVARCHAR(10),
    @GiaPhiMoi DECIMAL(18,2)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    
    -- BỎ TRY CATCH ĐỂ HIỆN LỖI RA MẶT
    BEGIN TRAN

    -- 1. Update
    UPDATE PHIPHATSINH SET GiaPhi = @GiaPhiMoi WHERE MaPPS = @MaPPS;

    -- 2. Wait
    WAITFOR DELAY '00:00:15';

    -- 3. Check Rollback
    IF (@GiaPhiMoi < 0)
    BEGIN
        ROLLBACK TRAN;
        RETURN 2;
    END

    COMMIT TRAN;
    RETURN 1;
END
GO