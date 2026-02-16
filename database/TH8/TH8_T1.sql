USE HolyBird
GO

CREATE OR ALTER PROCEDURE sp_TH8_T1_XemHoaDon_TranhChap
    @MaHD NVARCHAR(10),
    @IsFix INT -- 0: Lỗi (Demo), 1: Giải quyết
AS
BEGIN
    BEGIN TRAN
    BEGIN TRY
        DECLARE @TongTien DECIMAL(18, 0); 
        DECLARE @MaDoan NVARCHAR(10);
        
        -- Lấy Mã Đoàn
        SELECT @MaDoan = MaDoan FROM HOADON WHERE MaHD = @MaHD;


        IF (@IsFix = 0)
        BEGIN
            SELECT @TongTien = (
                ISNULL(( 
                     -- Tiền phòng (vẫn đọc bình thường hoặc NOLOCK tùy bạn)
                     SELECT SUM(LP.MucGia * (DATEDIFF(DAY, CTGD.NgayBD, CTGD.NgayKT) + CASE WHEN DATEDIFF(DAY, CTGD.NgayBD, CTGD.NgayKT) = 0 THEN 1 ELSE 0 END)) 
                     FROM CT_GIAODICH CTGD WITH (NOLOCK)
                     JOIN PHONG P WITH (NOLOCK) ON CTGD.MaPhong = P.MaPhong 
                     JOIN LOAIPHONG LP WITH (NOLOCK) ON P.MaLoaiPhong = LP.MaLoaiPhong 
                     WHERE CTGD.MaDoan = @MaDoan
                ), 0) +               
                ISNULL(( 
                     -- Tiền phí phát sinh (QUAN TRỌNG: PHẢI CÓ NOLOCK ĐỂ ĐỌC GIÁ ĐANG SỬA)
                     SELECT SUM(CTPPS.SoLuong * PPS.GiaPhi) 
                     FROM CT_PHIPS CTPPS WITH (NOLOCK)
                     JOIN PHIPHATSINH PPS WITH (NOLOCK) ON CTPPS.MaPPS = PPS.MaPPS 
                     WHERE CTPPS.MaDoan = @MaDoan
                ), 0) 
            ); 
        END


        ELSE
        BEGIN
            -- Thiết lập mức cô lập chặt chẽ
            SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

            SELECT @TongTien = (
                ISNULL(( 
                     SELECT SUM(LP.MucGia * (DATEDIFF(DAY, CTGD.NgayBD, CTGD.NgayKT) + CASE WHEN DATEDIFF(DAY, CTGD.NgayBD, CTGD.NgayKT) = 0 THEN 1 ELSE 0 END)) 
                     FROM CT_GIAODICH CTGD 
                     JOIN PHONG P ON CTGD.MaPhong = P.MaPhong 
                     JOIN LOAIPHONG LP ON P.MaLoaiPhong = LP.MaLoaiPhong 
                     WHERE CTGD.MaDoan = @MaDoan
                ), 0) +               
                ISNULL(( 
                     SELECT SUM(CTPPS.SoLuong * PPS.GiaPhi) 
                     FROM CT_PHIPS CTPPS 
                     JOIN PHIPHATSINH PPS ON CTPPS.MaPPS = PPS.MaPPS 
                     WHERE CTPPS.MaDoan = @MaDoan
                ), 0) 
            ); 
        END

        -- Trả về kết quả
        SELECT @MaHD AS MaHoaDon, @TongTien AS TongTienThanhToan;

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
    END CATCH
END
GO