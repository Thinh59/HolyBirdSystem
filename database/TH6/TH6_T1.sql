USE HolyBird
GO

-- T1: Trưởng đoàn A xem giá phòng VIP (Gây lỗi: Đọc 2 lần thấy giá khác nhau)
CREATE OR ALTER PROCEDURE sp_TH6_T1_XemGiaPhong_TranhChap
    @MaLoaiPhong NVARCHAR(50), -- Chỉnh lại độ dài cho khớp với DB
    @IsFix INT
AS
BEGIN
    -- Mức cô lập
    IF (@IsFix = 1) SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
    ELSE SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

    BEGIN TRAN
        -- Lần 1
        SELECT Hang, MucGia FROM LOAIPHONG WHERE Hang = @MaLoaiPhong OR MaLoaiPhong = @MaLoaiPhong;
        
        WAITFOR DELAY '00:00:10';
        
        -- Lần 2
        SELECT Hang, MucGia FROM LOAIPHONG WHERE Hang = @MaLoaiPhong OR MaLoaiPhong = @MaLoaiPhong;
    COMMIT TRAN
END
GO

