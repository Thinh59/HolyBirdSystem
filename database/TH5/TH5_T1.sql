USE HolyBird
GO

-- T1: Quản lý 1 cập nhật thành 'Đang có khách' (Gây lỗi: Có Delay)
CREATE OR ALTER PROCEDURE sp_TH5_T1_UpdateTrangThai
    @MaPhong NVARCHAR(10),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    -- Mức cô lập mặc định hoặc Read Committed
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
        -- B1: Kiểm tra tồn tại
        IF NOT EXISTS (SELECT 1 FROM PHONG WHERE MaPhong = @MaPhong)
        BEGIN
            ROLLBACK TRAN
            RETURN 0
        END

        -- B2: Giả lập thời gian suy nghĩ/xử lý (Check-in) 10 giây
        WAITFOR DELAY '00:00:10'

        -- B3: Cập nhật trạng thái
        UPDATE PHONG SET TrangThai = @TrangThai WHERE MaPhong = @MaPhong
        
        COMMIT TRAN
        RETURN 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RETURN 0
    END CATCH
END
GO

-- FIX: Giải quyết Lost Update bằng REPEATABLE READ hoặc XLOCK
CREATE OR ALTER PROCEDURE sp_TH5_Fix_UpdateTrangThai
    @MaPhong NVARCHAR(10),
    @TrangThai NVARCHAR(50)
AS
BEGIN
    -- Giải pháp: Nâng mức cô lập lên REPEATABLE READ để giữ khóa lâu hơn
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM PHONG WITH (XLOCK) WHERE MaPhong = @MaPhong)
        BEGIN
            ROLLBACK TRAN
            RETURN 0
        END

        WAITFOR DELAY '00:00:10' -- Vẫn delay để mô phỏng thời gian check-in

        UPDATE PHONG SET TrangThai = @TrangThai WHERE MaPhong = @MaPhong
        
        COMMIT TRAN
        RETURN 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RETURN 0
    END CATCH
END
GO