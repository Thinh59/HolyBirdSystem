USE HolyBird
GO

--
--TH2: 
---Giao tác 2: Cập nhật giá của phí phát sinh A (Quản lý 1 cập nhật giá của phí phát sinh A thành 150.000 và lưu vào CSDL)
----=> Giao tác 2 xảy ra sau giao tác 1 và khi giao tác 1 chưa hoàn thành


CREATE OR ALTER PROCEDURE sp_TH2_T2_CapNhatGiaPPS
@MaPPS NVARCHAR(10),
@GiaMoi INT
AS
BEGIN
	BEGIN TRAN
	IF NOT EXISTS (SELECT * FROM PHIPHATSINH WHERE MaPPS = @MaPPS)

	BEGIN
		PRINT N'Không tồn tại phí phát sinh này.'
		ROLLBACK TRAN

		RETURN 0
	END

	UPDATE PHIPHATSINH
	SET GiaPhi = 150000
	WHERE MaPPS = @MaPPS;

	COMMIT

	RETURN 1
END
GO
  


