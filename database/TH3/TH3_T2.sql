USE HolyBird
GO
-- T2: Tiếp tân xem hóa đơn (Xử lý Dirty Read)
-- Chạy lại cái này nếu chưa có cột TrangThaiHD
CREATE OR ALTER PROCEDURE sp_TH3_T2_XemHD_TranhChap
    @MaNV NVARCHAR(10),
    @MaHD NVARCHAR(10) = NULL,
    @IsFix INT
AS
BEGIN
    IF (@IsFix = 1) SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    ELSE SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    SELECT MaHD, MaDoan, NgayLap, TongTien, TrangThaiHD 
    FROM HOADON 
    WHERE NVLap = @MaNV 
    AND (@MaHD IS NULL OR MaHD = @MaHD);
END
GO