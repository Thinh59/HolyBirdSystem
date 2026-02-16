USE HolyBird
GO

-- Procedure cho Quản lý 1: Cập nhật giá 550.000 (Gây lỗi)
CREATE OR ALTER PROCEDURE sp_TH1_T1_CapNhatGiaLoaiPhong
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
        -- B1: Kiểm tra tồn tại
        IF NOT EXISTS (SELECT 1 FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong)
        BEGIN
            ROLLBACK TRAN
			RAISERROR(N'Lỗi: Mã Loại Phòng "%s" chưa tồn tại! Vui lòng lưu thường trước.', 16, 1, @MaLoaiPhong)
            RETURN 0
        END

        -- B2: Tạm dừng để Quản lý 2 cùng vào đọc dữ liệu cũ
        WAITFOR DELAY '00:00:10'

        -- B3: Cập nhật
        UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong
        
        COMMIT TRAN
        RETURN 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RETURN 0
    END CATCH
END
GO

-- Procedure GIẢI QUYẾT: Sử dụng REPEATABLE READ để khóa dữ liệu không cho người khác đọc/ghi
CREATE OR ALTER PROCEDURE sp_TH1_GiaiQuyet_LostUpdate
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2)
AS
BEGIN
    BEGIN TRAN
    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM LOAIPHONG WITH (XLOCK) WHERE MaLoaiPhong = @MaLoaiPhong)
        BEGIN
            ROLLBACK TRAN
            RETURN 0
        END

        WAITFOR DELAY '00:00:10'

        UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong
        
        COMMIT TRAN
        RETURN 1
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN
        RETURN 0
    END CATCH
END
GO
