USE HolyBird
GO

CREATE OR ALTER PROCEDURE sp_TH9_T2_XemHoaDon_TranhChap
    @MaNV NVARCHAR(10),
    @MaHD NVARCHAR(10) = NULL,
    @IsFix INT
AS
BEGIN
    -- Thiết lập mức cô lập dữ liệu
    IF (@IsFix = 1) 
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    ELSE 
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

    BEGIN TRAN
        SELECT 
            MaHD, 
            MaDoan, 
            NgayLap, 
            TongTien, 
            TrangThaiHD -- Phải có cột này để khớp với DataPropertyName trong C#
        FROM HOADON 
        WHERE NVLap = @MaNV 
        AND (@MaHD IS NULL OR MaHD = @MaHD);
    COMMIT
END
GO