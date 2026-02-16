USE HolyBird
GO

-- T1: Trưởng đoàn A xem danh sách phòng trống (Gây lỗi Phantom)
CREATE OR ALTER PROCEDURE sp_TH4_T1_XemDSPhongTrong_TranhChap
    @TrangThai NVARCHAR(50),
    @IsFix INT -- 0: Lỗi, 1: Giải quyết
AS
BEGIN
    -- Nếu giải quyết thì nâng mức cô lập lên SERIALIZABLE để khóa toàn bảng/phạm vi
    IF (@IsFix = 1)
        SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
    ELSE
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

    BEGIN TRAN
    BEGIN TRY
        -- Lần 1: Xem danh sách phòng trống
        SELECT MaPhong, TrangThai, Tang FROM PHONG WHERE TrangThai = @TrangThai;

        -- Dừng 15 giây để Trưởng đoàn B đặt phòng ở máy khác
        WAITFOR DELAY '00:00:15';

        -- Lần 2: Xem lại danh sách phòng trống (Nếu bị Phantom, dòng vừa bị đặt sẽ biến mất)
        SELECT MaPhong, TrangThai, Tang FROM PHONG WHERE TrangThai = @TrangThai;

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
    END CATCH
END
GO

