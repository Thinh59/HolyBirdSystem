USE HolyBird
GO

--UPDLOCK
USE HolyBird
GO

-- GIẢI PHÁP: Dùng UPDLOCK để "xí chỗ" ngay từ đầu
CREATE OR ALTER PROCEDURE sp_Deadlock_Conversion_Fix
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2)
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
    BEGIN TRAN
    BEGIN TRY
        DECLARE @GiaCu DECIMAL(18,2);
        
        -- BÍ KÍP LÀ Ở ĐÂY: WITH (UPDLOCK)
        -- Nó bảo SQL: "Tao đọc để lát tao sửa, đứa nào muốn sửa giống tao thì đứng chờ, đừng vào đọc chung."
        SELECT @GiaCu = MucGia FROM LOAIPHONG WITH (UPDLOCK) WHERE MaLoaiPhong = @MaLoaiPhong;
        
        -- Vẫn delay để kiểm chứng việc máy kia phải chờ
        WAITFOR DELAY '00:00:10'; 

        UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong;

        COMMIT TRAN
        SELECT 1 AS Result;
    END TRY
    BEGIN CATCH
        ROLLBACK TRAN;
        SELECT 0 AS Result;
    END CATCH
END
GO

-- MÁY 1 (HIGH): Priority = 10
CREATE OR ALTER PROCEDURE sp_Deadlock_Conversion_WoundWait_High
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2)
AS
BEGIN 
    SET DEADLOCK_PRIORITY 10; 

    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
    BEGIN TRAN
    
    -- 1. Đọc (S-Lock)
    DECLARE @GiaCu DECIMAL(18,2);
    SELECT @GiaCu = MucGia FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong;

    WAITFOR DELAY '00:00:10'; 
    
    -- 3. Update (X-Lock)
    UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong;

    COMMIT TRAN
    SELECT 1 AS Result;
END
GO


-- MÁY 2 (LOW): Priority = -10
CREATE OR ALTER PROCEDURE sp_Deadlock_Conversion_WoundWait_Low
    @MaLoaiPhong NVARCHAR(10),
    @MucGia DECIMAL(18,2)
AS
BEGIN
    SET DEADLOCK_PRIORITY -10; 

    SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
    BEGIN TRAN
    
    DECLARE @GiaCu DECIMAL(18,2);
    SELECT @GiaCu = MucGia FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong;
    
    WAITFOR DELAY '00:00:10';
    
    UPDATE LOAIPHONG SET MucGia = @MucGia WHERE MaLoaiPhong = @MaLoaiPhong;

    COMMIT TRAN
    SELECT 1 AS Result;
END
GO


/*
USE master;
GO
-- Đá văng tất cả kết nối đang vào HolyBird (để xóa Transaction treo)
DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('HolyBird')

EXEC(@kill);
GO

USE HolyBird
GO
-- Reset dữ liệu sạch sẽ
UPDATE LOAIPHONG SET MucGia = 300000 WHERE MaLoaiPhong = 'LP01'
UPDATE LOAIPHONG SET MucGia = 600000 WHERE MaLoaiPhong = 'LP02'
UPDATE LOAIPHONG SET MucGia = 1200000 WHERE MaLoaiPhong = 'LP03'
UPDATE LOAIPHONG SET MucGia = 2500000 WHERE MaLoaiPhong = 'LP04'
UPDATE LOAIPHONG SET MucGia = 5000000 WHERE MaLoaiPhong = 'LP05'

UPDATE PHONG SET TrangThai = N'Đang trống';
GO
*/
