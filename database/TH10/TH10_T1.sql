USE HolyBird
GO

-- T1: Quản lý đọc thống kê giao dịch (Gây lỗi: Đọc 2 lần thấy số lượng khác nhau)
CREATE OR ALTER PROCEDURE sp_TH10_T1_KiemTraGiaoDich_TranhChap
    @IsFix INT -- 0: Lỗi (Read Committed), 1: Giải quyết (Serializable)
AS
BEGIN
    -- Nếu giải quyết thì nâng mức cô lập lên SERIALIZABLE (Khóa phạm vi - Range Lock)
    IF (@IsFix = 1)
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    ELSE
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

    BEGIN TRAN
    BEGIN TRY
        -- B1: Đếm số lượng lần 1
        SELECT COUNT(*) AS SoLuong FROM GIAODICH;

        -- B2: Tạm dừng 10 giây để Tiếp tân kịp thêm mới
        WAITFOR DELAY '00:00:10';

        -- B3: Đếm số lượng lần 2
        SELECT COUNT(*) AS SoLuong FROM GIAODICH;

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
    END CATCH
END
GO
