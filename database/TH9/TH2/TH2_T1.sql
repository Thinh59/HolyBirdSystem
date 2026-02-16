USE HolyBird
GO

--
--TH2: 
---Giao tác 1 (đọc lần thứ nhất): Xem thông tin giá của phí phát sinh (Tiếp tân 1 muốn xem giá của phí phát sinh A, ở thời điểm này đọc lên là 100.000) 
---Giao tác 1 (đọc lần thứ hai, sau khi giao tác 2 đã thực hiện thay đổi): Đọc lại giá phí phát sinh để in hóa đơn của phí phát sinh A, nhưng lần này là 150.000 thay vì 100.000 như lúc tính tiền.


CREATE OR ALTER PROCEDURE sp_TH2_T1_XemGiaPPS
@MaPPS NVARCHAR(10)
AS
BEGIN
	BEGIN TRAN
	IF NOT EXISTS (SELECT * FROM PHIPHATSINH WHERE MaPPS = @MaPPS)

	BEGIN
		PRINT N'Không tồn tại phí phát sinh này.'
		ROLLBACK TRAN

		RETURN 0
	END

	SELECT GiaPhi
	FROM PHIPHATSINH
	WHERE MaPPS = @MaPPS;

	WAITFOR DELAY '00:00:05';

	SELECT GiaPhi
	FROM PHIPHATSINH
	WHERE MaPPS = @MaPPS;

	COMMIT

	RETURN 1
END
GO
  


