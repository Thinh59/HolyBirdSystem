USE HolyBird
GO

CREATE OR ALTER PROCEDURE sp_TH9_T1_GayLoiDirtyRead
    @MaHD NVARCHAR(10), 
    @MaDoan NVARCHAR(10), 
    @MaNV NVARCHAR(10), 
    @TongTien DECIMAL(18,2), 
    @NgayLapLoi DATETIME
AS
BEGIN
    BEGIN TRAN
        -- B1: Chèn dữ liệu bẩn
        INSERT INTO HOADON (MaHD, NgayLap, NVLap, TrangThaiHD, TongTien, MaDoan)
        VALUES (@MaHD, @NgayLapLoi, @MaNV, N'Chờ thanh toán', @TongTien, @MaDoan);

        -- B2: Câu giờ
        WAITFOR DELAY '00:00:15'; 

        -- B3: Rollback và trả giá trị về cho C#
        ROLLBACK TRAN; 
        
        -- QUAN TRỌNG: C# đang đợi số 2 để hiện thông báo thành công
        RETURN 2; 
END
GO

