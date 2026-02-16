USE HolyBird
GO

-- T1: Trưởng đoàn thanh toán (Gây lỗi Dirty Read)
CREATE OR ALTER PROCEDURE sp_TH3_T1_ThanhToan_TranhChap
    @MaHD NVARCHAR(10)
AS
BEGIN
    BEGIN TRAN
    BEGIN TRY
        -- B1: Cập nhật trạng thái sang 'Đã thanh toán'
        UPDATE HOADON 
        SET TrangThaiHD = N'Đã thanh toán' 
        WHERE MaHD = @MaHD;

        -- B2: Tạm dừng 15 giây để Tiếp tân bên máy kia kịp xem dữ liệu bẩn này
        WAITFOR DELAY '00:00:15';

        -- B3: GIẢ LẬP LỖI - Hệ thống kiểm tra thấy ngày thanh toán sai logic nên ROLLBACK
        -- Ở đây ta ép Rollback luôn để chứng minh dữ liệu bẩn biến mất
        ROLLBACK TRAN;
        RETURN 2; -- Mã báo hiệu đã Rollback
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        RETURN 0;
    END CATCH
END
GO
