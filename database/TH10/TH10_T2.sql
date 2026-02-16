USE HolyBird
GO
-- T2: Tiếp tân đăng ký giao dịch mới (Chen ngang)
CREATE OR ALTER PROCEDURE sp_TH10_T2_DangKyGiaoDich_TranhChap
    @MaDoan NVARCHAR(10),
    @DaiDienDoan NVARCHAR(12),
    @SoNguoi INT,
    @SoPhong INT,
    @NgayBD DATETIME,
    @NgayKT DATETIME,
    @MaNV NVARCHAR(10),
    @MaDaiLy NVARCHAR(10),
    @TenDangNhap NVARCHAR(50)
AS
BEGIN
    -- Mức cô lập Read Committed là đủ cho việc Insert
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
        -- Kiểm tra tồn tại
        IF EXISTS (SELECT 1 FROM GIAODICH WHERE MaDoan = @MaDoan)
        BEGIN
            ROLLBACK TRAN; RETURN 0;
        END

        -- Chèn mới
        INSERT INTO GIAODICH (MaDoan, DaiDienDoan, SoNguoi, SoPhong, NgayBD, NgayKT, MaNV, MaDaiLy, TenDangNhap)
        VALUES (@MaDoan, @DaiDienDoan, @SoNguoi, @SoPhong, @NgayBD, @NgayKT, @MaNV, @MaDaiLy, @TenDangNhap);
        
        COMMIT TRAN; RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN; RETURN 0;
    END CATCH
END
GO