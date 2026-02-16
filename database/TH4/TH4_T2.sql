-- T2: Trưởng đoàn B đặt phòng (Thay đổi trạng thái phòng)
USE HolyBird
GO

CREATE OR ALTER PROCEDURE sp_TH4_T2_DatPhong_TranhChap
    @MaCTGD NVARCHAR(50), -- Mã sinh tự động từ C#
    @MaDoan NVARCHAR(10),
    @MaPhong INT,
    @CMND NVARCHAR(20),
    @HoTen NVARCHAR(100),
    @NgayBD DATETIME,
    @NgayKT DATETIME,
    @Gia DECIMAL(18,2)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL READ COMMITTED
    BEGIN TRAN
    BEGIN TRY
        -- 1. Kiểm tra phòng tồn tại
        IF NOT EXISTS (SELECT 1 FROM PHONG WHERE MaPhong = @MaPhong)
        BEGIN
            ROLLBACK TRAN; RETURN 0;
        END

        -- 2. QUAN TRỌNG: Cập nhật trạng thái phòng ngay lập tức
        -- Hành động này làm thay đổi kết quả tìm kiếm "Đang trống" của Máy 1 -> Gây Phantom Read
        UPDATE PHONG 
        SET TrangThai = N'Đang đặt trước' 
        WHERE MaPhong = @MaPhong;

        -- 3. Chèn dữ liệu thật vào CT_GIAODICH (giống hệt quy trình bình thường)
        INSERT INTO CT_GIAODICH (MaCTGD, MaDoan, MaPhong, CMND, CaNhan, NgayBD, NgayKT, ThanhTien, TrangThaiGD) 
        VALUES (@MaCTGD, @MaDoan, @MaPhong, @CMND, @HoTen, @NgayBD, @NgayKT, @Gia, N'Chưa nhận phòng');
        
        COMMIT TRAN; 
        RETURN 1;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN; 
        RETURN 0;
    END CATCH
END
GO