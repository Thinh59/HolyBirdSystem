USE HolyBird
GO

--GT1 chạy nhưng chưa commit, T2 chạy commit ngay, sau T1 mới commit và đè lên T2 => mất giá trị T2 cập nhật
--TH1: 
---T2: Cập nhật mức giá của loại phòng (Loại phòng A có giá 500.000, Quản lý 2 cập nhật giá của loại phòng A thành 600.000) 
----=> Giao tác 2 ghi nhận giá của loại phòng A là 600.000

CREATE OR ALTER PROCEDURE sp_TH1_T2_CapNhatGiaLoaiPhong
@MaLoaiPhong NVARCHAR(10),
@MucGia INT
AS
BEGIN
	BEGIN TRAN
	IF NOT EXISTS (SELECT * FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong)

	BEGIN
		PRINT 'Loại phòng' + @MaLoaiPhong + N'không tồn tại'
		ROLLBACK TRAN

		RETURN 0
	END

	UPDATE LOAIPHONG
	SET MucGia = 600000
	WHERE MaLoaiPhong = @MaLoaiPhong;

	COMMIT
	RETURN 1
END
GO