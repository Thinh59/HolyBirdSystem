USE HolyBird
GO

--ALL: Login
CREATE OR ALTER PROCEDURE sp_Login
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(255)
AS
BEGIN
    -- Kiểm tra tài khoản trong bảng TAIKHOAN trước
    IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau AND TrangThaiTK = N'Hoạt động')
    BEGIN
        -- Trường hợp 1: Nếu là NHÂN VIÊN
        IF EXISTS (SELECT 1 FROM NHANVIEN WHERE TenDangNhap = @TenDangNhap)
        BEGIN
            SELECT 
                T.TenDangNhap, 
                T.LoaiTaiKhoan, 
                N.MaNV AS MaDinhDanh, 
                N.HoTenNV AS HoTen,
                NULL AS NgayKT -- Bổ sung để tránh lỗi "Column not belong to table"
            FROM TAIKHOAN T
            JOIN NHANVIEN N ON T.TenDangNhap = N.TenDangNhap
            WHERE T.TenDangNhap = @TenDangNhap
        END
        -- Trường hợp 2: Nếu là KHÁCH HÀNG (Đoàn)
        ELSE IF EXISTS (SELECT 1 FROM GIAODICH WHERE TenDangNhap = @TenDangNhap)
        BEGIN
            SELECT 
                T.TenDangNhap, 
                T.LoaiTaiKhoan, 
                G.MaDoan AS MaDinhDanh, 
                K.HoTenKH AS HoTen,
                G.NgayKT -- Có sẵn cột này
            FROM TAIKHOAN T
            JOIN GIAODICH G ON T.TenDangNhap = G.TenDangNhap
            JOIN KHACHHANG K ON G.DaiDienDoan = K.CMND
            WHERE T.TenDangNhap = @TenDangNhap
        END
    END
END
GO

---All: chỉnh sửa tk

CREATE OR ALTER PROCEDURE sp_GetThongTinTaiKhoan
    @TenDangNhap NVARCHAR(50)
AS
BEGIN
    -- 1. Nếu là Nhân viên
    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        SELECT 
            HoTenNV AS HoTen, 
            NgaySinhNV AS NgaySinh, 
            SDT_NV AS SDT, 
            EmailNV AS Email,
            N'Nhân viên' AS LoaiND
        FROM NHANVIEN WHERE TenDangNhap = @TenDangNhap
    END
    -- 2. Nếu là Tài khoản Đoàn (Khách hàng dùng chung)
    ELSE IF EXISTS (SELECT 1 FROM GIAODICH WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        SELECT 
            K.HoTenKH AS HoTen, 
            K.NgaySinhKH AS NgaySinh, 
            K.SDT_KH AS SDT, 
            K.EmailKH AS Email,
            N'Khách hàng (Đoàn)' AS LoaiND
        FROM GIAODICH G
        JOIN KHACHHANG K ON G.DaiDienDoan = K.CMND
        WHERE G.TenDangNhap = @TenDangNhap
    END
END
GO

CREATE OR ALTER PROCEDURE sp_LoginDoan
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(255)
AS
BEGIN
    SELECT 
        T.TenDangNhap, 
        T.LoaiTaiKhoan,
        G.MaDoan, 
        G.NgayBD, 
        G.NgayKT, 
        G.SoNguoi, 
        G.SoPhong,
        K.HoTenKH AS TenTruongDoan
    FROM TAIKHOAN T
    INNER JOIN GIAODICH G ON T.TenDangNhap = G.TenDangNhap
    INNER JOIN KHACHHANG K ON G.DaiDienDoan = K.CMND
    WHERE T.TenDangNhap = @TenDangNhap 
      AND T.MatKhau = @MatKhau 
      AND T.TrangThaiTK = N'Hoạt động'
END
GO

CREATE OR ALTER PROCEDURE sp_CapNhatTaiKhoan
    @TenDangNhap NVARCHAR(50),
    @MatKhauMoi NVARCHAR(255) = NULL,
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @SDT NVARCHAR(20),
    @Email NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
    BEGIN TRY
        -- 1. Cập nhật mật khẩu nếu có nhập mới (bảng TAIKHOAN)
        IF @MatKhauMoi IS NOT NULL AND @MatKhauMoi <> ''
        BEGIN
            UPDATE TAIKHOAN SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap;
        END

        -- 2. Cập nhật thông tin nhân thân
        -- Trường hợp A: Nếu là Nhân viên (Tiếp tân, Quản lý, QTV)
        IF EXISTS (SELECT 1 FROM NHANVIEN WHERE TenDangNhap = @TenDangNhap)
        BEGIN
            UPDATE NHANVIEN 
            SET HoTenNV = @HoTen, NgaySinhNV = @NgaySinh, SDT_NV = @SDT, EmailNV = @Email
            WHERE TenDangNhap = @TenDangNhap;
        END
        -- Trường hợp B: Nếu là Tài khoản Đoàn (Khách hàng dùng chung)
        ELSE IF EXISTS (SELECT 1 FROM GIAODICH WHERE TenDangNhap = @TenDangNhap)
        BEGIN
            -- Tìm CMND của trưởng đoàn dựa trên TenDangNhap của Giao dịch
            DECLARE @CMND_TD NVARCHAR(12);
            SELECT @CMND_TD = DaiDienDoan FROM GIAODICH WHERE TenDangNhap = @TenDangNhap;

            -- Cập nhật vào bảng KHACHHANG dựa trên CMND tìm được
            UPDATE KHACHHANG 
            SET HoTenKH = @HoTen, NgaySinhKH = @NgaySinh, SDT_KH = @SDT, EmailKH = @Email
            WHERE CMND = @CMND_TD;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END
GO

--ALL3: THÔNG TIN CHI TIẾT

-- 1. Lấy thông tin chi tiết dựa trên Username
CREATE OR ALTER PROCEDURE sp_ALL3_GetThongTinCaNhan
    @TenDangNhap NVARCHAR(50)
AS
BEGIN
    -- 1. Trường hợp là NHÂN VIÊN (Tiếp tân, Quản lý, Quản trị viên)
    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        SELECT 
            N.TenDangNhap,
            N.HoTenNV AS HoTen,
            N.NgaySinhNV AS NgaySinh,
            N.SDT_NV AS SDT,
            N.EmailNV AS Email,
            T.LoaiTaiKhoan AS LoaiNguoiDung
        FROM NHANVIEN N
        JOIN TAIKHOAN T ON N.TenDangNhap = T.TenDangNhap
        WHERE N.TenDangNhap = @TenDangNhap
    END
    -- 2. Trường hợp là KHÁCH HÀNG (Tài khoản dùng chung của Đoàn)
    ELSE IF EXISTS (SELECT 1 FROM GIAODICH WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        SELECT 
            G.TenDangNhap,
            K.HoTenKH AS HoTen,
            K.NgaySinhKH AS NgaySinh,
            K.SDT_KH AS SDT,
            K.EmailKH AS Email,
            N'Khách hàng' AS LoaiNguoiDung
        FROM GIAODICH G
        JOIN KHACHHANG K ON G.DaiDienDoan = K.CMND
        WHERE G.TenDangNhap = @TenDangNhap
    END
    -- 3. Trường hợp tài khoản QTV chưa gắn với NV nào (Tài khoản mẫu)
    ELSE
    BEGIN
        SELECT TenDangNhap, N'Hệ thống' AS HoTen, NULL AS NgaySinh, NULL AS SDT, NULL AS Email, LoaiTaiKhoan
        FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap
    END
END
GO

-- 2. Cập nhật thông tin cá nhân (Không đổi Password, không đổi Username)
CREATE OR ALTER PROCEDURE sp_ALL3_UpdateThongTinCaNhan
    @TenDangNhap NVARCHAR(50),
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @SDT NVARCHAR(20),
    @Email NVARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- A. Cập nhật nếu là Nhân viên (Tiếp tân, Quản lý, QTV)
        IF EXISTS (SELECT 1 FROM NHANVIEN WHERE TenDangNhap = @TenDangNhap)
        BEGIN
            UPDATE NHANVIEN
            SET HoTenNV = @HoTen, NgaySinhNV = @NgaySinh, SDT_NV = @SDT, EmailNV = @Email
            WHERE TenDangNhap = @TenDangNhap
        END
        -- B. Cập nhật nếu là Khách hàng (Dựa vào CMND Trưởng đoàn trong GIAODICH)
        ELSE IF EXISTS (SELECT 1 FROM GIAODICH WHERE TenDangNhap = @TenDangNhap)
        BEGIN
            DECLARE @CMND_TD NVARCHAR(12)
            SELECT @CMND_TD = DaiDienDoan FROM GIAODICH WHERE TenDangNhap = @TenDangNhap

            UPDATE KHACHHANG
            SET HoTenKH = @HoTen, NgaySinhKH = @NgaySinh, SDT_KH = @SDT, EmailKH = @Email
            WHERE CMND = @CMND_TD
        END

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END
GO

--- 1. Procedure Lấy danh sách phòng
-- Cập nhật: Tang -> SoTang, DonGiaPhong -> MucGia
CREATE PROCEDURE sp_GetAllRooms
AS
BEGIN
    SELECT 
        P.MaPhong, 
        P.MaLoaiPhong, 
        P.Tang, 
        LP.Hang, 
        LP.HinhThuc, 
        P.TrangThai, 
        LP.MucGia
    FROM PHONG P
    INNER JOIN LOAIPHONG LP ON P.MaLoaiPhong = LP.MaLoaiPhong
END
GO

-- 2. Procedure Thêm hoặc Cập nhật Phòng & Loại Phòng
-- Cập nhật các tham số và câu lệnh INSERT/UPDATE cho khớp với thuộc tính mới
CREATE PROCEDURE sp_UpsertRoom
    @MaPhong INT,
    @MaLoaiPhong NVARCHAR(10),
    @Tang INT,
    @Hang NVARCHAR(50),
    @HinhThuc NVARCHAR(50),
    @TrangThai NVARCHAR(20),
    @Gia DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
    BEGIN TRY
        -- A. Xử lý bảng LOAIPHONG (Dựa trên MaLoaiPhong)
        IF NOT EXISTS (SELECT 1 FROM LOAIPHONG WHERE MaLoaiPhong = @MaLoaiPhong)
        BEGIN
            INSERT INTO LOAIPHONG (MaLoaiPhong, Hang, HinhThuc, MucGia)
            VALUES (@MaLoaiPhong, @Hang, @HinhThuc, @Gia)
        END
        ELSE
        BEGIN
            UPDATE LOAIPHONG 
            SET Hang = @Hang, 
                HinhThuc = @HinhThuc, 
                MucGia = @Gia
            WHERE MaLoaiPhong = @MaLoaiPhong
        END

        -- B. Xử lý bảng PHONG
        IF NOT EXISTS (SELECT 1 FROM PHONG WHERE MaPhong = @MaPhong)
        BEGIN
            INSERT INTO PHONG (MaPhong, Tang, MaLoaiPhong, TrangThai)
            VALUES (@MaPhong, @Tang, @MaLoaiPhong, @TrangThai)
        END
        ELSE
        BEGIN
            UPDATE PHONG 
            SET Tang = @Tang, 
                MaLoaiPhong = @MaLoaiPhong, 
                TrangThai = @TrangThai
            WHERE MaPhong = @MaPhong
        END

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END
GO

-- 3. Procedure Xóa Phòng
CREATE PROCEDURE sp_DeleteRoom
    @MaPhong INT
AS
BEGIN
    DELETE FROM PHONG WHERE MaPhong = @MaPhong
END
GO

--- Danh sách hóa đơn

CREATE or ALTER PROCEDURE sp_LocHoaDon_DaNang
    @SearchKeyword NVARCHAR(50) = NULL, -- Dùng cho MaHD, MaDoan, MaNV
    @NgayLap DATE = NULL,
    @TrangThai NVARCHAR(50) = NULL -- 'Đã thanh toán', 'Chưa thanh toán' hoặc NULL (Tất cả)
AS
BEGIN
    SELECT 
        HD.MaHD,
        HD.MaDoan, 
        HD.NgayLap,
        NV.HoTenNV,
        HD.TongTien,
        HD.TrangThaiHD
    FROM HOADON HD
    LEFT JOIN NHANVIEN NV ON HD.NVLap = NV.MaNV
    WHERE 
        -- Lọc theo từ khóa (Mã HD hoặc Mã Đoàn hoặc Mã NV)
        (@SearchKeyword IS NULL OR HD.MaHD LIKE '%' + @SearchKeyword + '%' 
                                OR HD.MaDoan LIKE '%' + @SearchKeyword + '%' 
                                OR HD.NVLap LIKE '%' + @SearchKeyword + '%')
        -- Lọc theo ngày (Nếu có chọn ngày)
        AND (@NgayLap IS NULL OR CAST(HD.NgayLap AS DATE) = @NgayLap)
        -- Lọc theo trạng thái từ Combobox
        AND (@TrangThai IS NULL OR HD.TrangThaiHD = @TrangThai)
    ORDER BY HD.NgayLap DESC
END
GO

---QL PPS
-- 1. Lấy toàn bộ danh sách phí
CREATE PROCEDURE sp_GetAllPPS
AS
BEGIN
    SELECT MaPPS as [Mã Phí Phát Sinh], 
           TenPPS as [Tên Phí Phát Sinh], 
           GiaPhi as [Đơn Giá]
    FROM PHIPHATSINH
END
GO

-- 2. Thêm hoặc cập nhật Phí (Upsert)
CREATE PROCEDURE sp_UpsertPPS
    @MaPPS NVARCHAR(10),
    @TenPPS NVARCHAR(100),
    @GiaPhi DECIMAL(18,2)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM PHIPHATSINH WHERE MaPPS = @MaPPS)
        INSERT INTO PHIPHATSINH (MaPPS, TenPPS, GiaPhi) VALUES (@MaPPS, @TenPPS, @GiaPhi);
    ELSE
        UPDATE PHIPHATSINH SET TenPPS = @TenPPS, GiaPhi = @GiaPhi WHERE MaPPS = @MaPPS;
END
GO

---DS Nhân viên

CREATE OR ALTER PROCEDURE sp_LocNhanVien
    @Keyword NVARCHAR(100) = NULL, -- Tìm theo Mã NV, Tên NV hoặc Mã Đại Lý
    @ChucVu NVARCHAR(50) = NULL    -- 'Tiếp tân', 'Quản lý', 'Quản trị viên' hoặc NULL (Tất cả)
AS
BEGIN
    SELECT 
        MaNV AS [Mã Nhân Viên], 
        HoTenNV AS [Họ Và Tên], 
        NgaySinhNV AS [Ngày Sinh], 
        SDT_NV AS [SĐT], 
        EmailNV AS [Email], 
        ChucVu AS [Chức Vụ], 
        MaDaiLy AS [Mã Đại Lý]
    FROM NHANVIEN
    WHERE 
        (@Keyword IS NULL OR MaNV LIKE '%' + @Keyword + '%' 
                          OR HoTenNV LIKE '%' + @Keyword + '%' 
                          OR MaDaiLy LIKE '%' + @Keyword + '%')
        AND (@ChucVu IS NULL OR ChucVu = @ChucVu)
END
GO

---DS Giao Dịch

CREATE OR ALTER PROCEDURE sp_LocGiaoDich
    @MaDoan NVARCHAR(10) = NULL,
    @NgayBD DATE = NULL,
    @TrangThai NVARCHAR(50) = NULL
AS
BEGIN
    SELECT DISTINCT
        GD.MaDoan AS [Mã Đoàn],
        KH.HoTenKH AS [Đại Diện],
        GD.SoNguoi AS [Số Người],
        GD.SoPhong AS [Số Phòng],
        GD.NgayBD AS [Ngày Bắt Đầu],
        GD.NgayKT AS [Ngày Kết Thúc],
        GD.MaNV AS [NV Thực Hiện],
        GD.MaDaiLy AS [Mã Đại Lý],
        -- Sử dụng ISNULL để xử lý trường hợp chưa có chi tiết (Giao dịch mới thêm)
        ISNULL(CT.TrangThaiGD, N'Mới tạo (Chưa có phòng)') AS [Trạng Thái] 
    FROM GIAODICH GD
    INNER JOIN KHACHHANG KH ON GD.DaiDienDoan = KH.CMND
    -- SỬA Ở ĐÂY: Đổi INNER JOIN thành LEFT JOIN
    LEFT JOIN CT_GIAODICH CT ON GD.MaDoan = CT.MaDoan
    WHERE 
        (@MaDoan IS NULL OR GD.MaDoan LIKE '%' + @MaDoan + '%')
        AND (@NgayBD IS NULL OR CAST(GD.NgayBD AS DATE) = @NgayBD)
        AND (@TrangThai IS NULL OR ISNULL(CT.TrangThaiGD, '') = @TrangThai)
    ORDER BY GD.NgayBD DESC
END
GO

---Kích Hoạt Nhận Phòng

-- 1. Tìm các chi tiết giao dịch chưa nhận phòng của một đoàn
CREATE PROCEDURE sp_GetGiaoDichKichHoat
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT 
        MaCTGD, 
        CMND AS [CCCD], 
        MaPhong, 
        NgayBD AS [Ngày Bắt Đầu], 
        NgayKT AS [Ngày Kết Thúc]
    FROM CT_GIAODICH
    WHERE MaDoan = @MaDoan AND TrangThaiGD = N'Chưa nhận phòng'
END
GO

-- 2. Cập nhật trạng thái sang 'Đã nhận phòng'
CREATE PROCEDURE sp_KichHoatGiaoDich
    @MaCTGD NVARCHAR(10)
AS
BEGIN
    UPDATE CT_GIAODICH 
    SET TrangThaiGD = N'Đã nhận phòng' 
    WHERE MaCTGD = @MaCTGD
END
GO

--PHÂN HỆ 3: TIẾP TÂN
--TT1: Đăng ký giao dịch cho khách hàng

CREATE OR ALTER PROCEDURE sp_TT1_TaoGiaoDich
    @UsernameNV NVARCHAR(50), 
    @HoTenKH NVARCHAR(100),
    @CMND NVARCHAR(20), -- Đã mở rộng lên 20 kí tự như các bước trước
    @SoNguoi INT,
    @SoPhong INT,
    @NgayBD DATETIME,
    @NgayKT DATETIME,
    @KetQua NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION
    BEGIN TRY
        -- 1. Xử lý thông tin Khách hàng
        IF NOT EXISTS (SELECT 1 FROM KHACHHANG WHERE CMND = @CMND)
        BEGIN
            INSERT INTO KHACHHANG (CMND, HoTenKH) VALUES (@CMND, @HoTenKH);
        END

        -- 2. SỬA LỖI TẠO MÃ ĐOÀN TẠI ĐÂY
        -- Cách cũ (Sai): Lấy đuôi mili-giây -> ra toàn số 0
        -- Cách mới (Đúng): Lấy Giờ-Phút-Giây (HHmmss) để đảm bảo không trùng
        -- Dùng REPLACE và CONVERT style 108 (hh:mm:ss) để lấy chuỗi thời gian sạch
        DECLARE @TimeStr NVARCHAR(20) = REPLACE(CONVERT(VARCHAR(8), GETDATE(), 108), ':', ''); 
        -- @TimeStr sẽ là '095108' (ví dụ lúc 9h 51p 08s)
        
        DECLARE @MaDoan NVARCHAR(10) = 'D' + RIGHT(@TimeStr, 5); 
        -- Lấy 5 số cuối cho gọn, ví dụ: 'D95108'. Nếu muốn ngắn hơn dùng RIGHT(..., 4)
        
        -- Kiểm tra nếu trùng mã (hiếm khi xảy ra nhưng cho chắc) thì cộng thêm 1 số ngẫu nhiên
        IF EXISTS (SELECT 1 FROM GIAODICH WHERE MaDoan = @MaDoan)
        BEGIN
             SET @MaDoan = 'D' + LEFT(CAST(ABS(CHECKSUM(NEWID())) AS VARCHAR), 5);
        END

        DECLARE @UserMoi NVARCHAR(50) = @MaDoan + @CMND;

        -- 3. Tạo TÀI KHOẢN
        INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, TrangThaiTK)
        VALUES (@UserMoi, '123', N'Khách hàng', N'Hoạt động');

        -- 4. Lấy thông tin NV
        DECLARE @MaNV NVARCHAR(10), @MaDaiLy NVARCHAR(10);
        SELECT @MaNV = MaNV, @MaDaiLy = MaDaiLy FROM NHANVIEN WHERE TenDangNhap = @UsernameNV;

        -- 5. Tạo GIAODICH
        INSERT INTO GIAODICH (MaDoan, DaiDienDoan, SoNguoi, SoPhong, NgayBD, NgayKT, MaNV, MaDaiLy, TenDangNhap)
        VALUES (@MaDoan, @CMND, @SoNguoi, @SoPhong, @NgayBD, @NgayKT, @MaNV, @MaDaiLy, @UserMoi);

        SET @KetQua = N'Thành công! Mã Đoàn: ' + @MaDoan + N' | TK: ' + @UserMoi;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @KetQua = N'Lỗi: ' + ERROR_MESSAGE();
    END CATCH
END
GO
--TT3: Xác nhận nhận phòng
-- 1. Lấy danh sách đoàn
CREATE OR ALTER PROCEDURE sp_TT3_GetDoanHienThi
AS
BEGIN
    SELECT DISTINCT g.MaDoan, k.CMND, k.HoTenKH, (k.CMND + ' - ' + k.HoTenKH) as HienThi
    FROM GIAODICH g
    JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND
    JOIN CT_GIAODICH ct ON g.MaDoan = ct.MaDoan
    WHERE ct.TrangThaiGD = N'Chưa nhận phòng' OR ct.TrangThaiGD = N'Đã đặt trước'
END
GO

-- 2. SP Kiểm tra thời gian trễ 
-- Trả về 1 nếu hợp lệ, 0 nếu trễ quá 120p
CREATE OR ALTER PROCEDURE sp_TT3_KiemTraTreHen
    @MaDoan NVARCHAR(10),
    @IsHopLe INT OUTPUT,
    @SoPhutTre INT OUTPUT
AS
BEGIN
    DECLARE @NgayBD DATETIME
    SELECT @NgayBD = NgayBD FROM GIAODICH WHERE MaDoan = @MaDoan

    SET @SoPhutTre = DATEDIFF(MINUTE, @NgayBD, GETDATE())

    IF @SoPhutTre > 120
        SET @IsHopLe = 0 
    ELSE
        SET @IsHopLe = 1 
END
GO

-- 3. Xác nhận nhận phòng 
CREATE OR ALTER PROCEDURE sp_TT3_XacNhanNhanPhong
    @MaCTGD NVARCHAR(10)
AS
BEGIN
    -- 1. Cập nhật trạng thái trong Chi tiết giao dịch
    UPDATE CT_GIAODICH 
    SET TrangThaiGD = N'Chờ cấp thẻ'
    WHERE MaCTGD = @MaCTGD

    -- 2. Cập nhật trạng thái của Phòng tương ứng sang 'Đang có khách'
    -- Lấy MaPhong từ MaCTGD ra để update
    DECLARE @MaPhong INT
    SELECT @MaPhong = MaPhong FROM CT_GIAODICH WHERE MaCTGD = @MaCTGD

    UPDATE PHONG 
    SET TrangThai = N'Đang có khách'
    WHERE MaPhong = @MaPhong
END
GO

CREATE OR ALTER PROCEDURE sp_TT3_GetChiTietDoan
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT 
        ct.MaCTGD, 
        ct.CaNhan as [CCCD],          -- CMND người ở phòng
        k.HoTenKH as [HoTen],         -- Lấy từ bảng KHACHHANG
        ct.MaPhong, 
        ct.NgayBD as [NgayBatDau], 
        ct.TrangThaiGD
    FROM CT_GIAODICH ct
    LEFT JOIN KHACHHANG k ON ct.CaNhan = k.CMND
    WHERE ct.MaDoan = @MaDoan 
    AND (ct.TrangThaiGD = N'Chưa nhận phòng' OR ct.TrangThaiGD = N'Đã đặt trước')
END
GO

--TT4: Cấp thẻ từ
-- 1. Lấy danh sách đoàn có ít nhất 1 phòng chưa cấp thẻ
CREATE OR ALTER PROCEDURE sp_TT4_GetMaDoanChoCapThe
AS
BEGIN
    SELECT DISTINCT g.MaDoan, (g.MaDoan + ' - ' + k.HoTenKH) as HienThi
    FROM GIAODICH g
    JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND
    JOIN CT_GIAODICH ct ON g.MaDoan = ct.MaDoan
    WHERE ct.MaThe IS NULL 
    AND ct.TrangThaiGD = N'Chờ cấp thẻ'
END
GO

-- 2. Lấy thẻ nhựa còn trống
CREATE OR ALTER PROCEDURE sp_TT4_GetTheTrong
AS
BEGIN
    SELECT MaThe FROM THETU WHERE MaCTGD IS NULL AND TrangThaiThe = N'Đang hoạt động'
END
GO

-- 3. Lấy danh sách để nạp vào ComboBox CTGD (Chỉ người chưa có thẻ)
CREATE OR ALTER PROCEDURE sp_TT4_GetCTGDChuaCapByMaDoan
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT MaCTGD, (MaCTGD + ' - P.' + CAST(MaPhong AS NVARCHAR)) as HienThi, NgayKT
    FROM CT_GIAODICH
    WHERE MaDoan = @MaDoan AND MaThe IS NULL AND TrangThaiGD = N'Chờ cấp thẻ'
END
GO

-- 4. Lấy toàn bộ danh sách để nạp vào DataGrid (Hiển thị tất cả trạng thái)
CREATE OR ALTER PROCEDURE sp_TT4_GetTatCaCTGDByMaDoan
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT ct.MaCTGD, ct.MaPhong, k.HoTenKH as HoTen, ct.MaThe, ct.NgayKT
    FROM CT_GIAODICH ct
    LEFT JOIN KHACHHANG k ON ct.CaNhan = k.CMND
    WHERE ct.MaDoan = @MaDoan
END
GO

-- 5. Nghiệp vụ xác nhận cấp thẻ
CREATE OR ALTER PROCEDURE sp_TT4_XacNhanCapThe
    @MaThe NVARCHAR(10),
    @MaCTGD NVARCHAR(10),
    @NgayCap DATETIME,
    @NgayHetHan DATETIME
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        UPDATE CT_GIAODICH SET MaThe = @MaThe, TrangThaiGD = N'Đang sử dụng' WHERE MaCTGD = @MaCTGD;
        UPDATE THETU SET MaCTGD = @MaCTGD, NgayCap = @NgayCap, NgayHetHan = @NgayHetHan WHERE MaThe = @MaThe;
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH ROLLBACK TRANSACTION; THROW; END CATCH
END
GO

--TT5:
-- 1. Lấy danh sách Mã Đoàn có phòng đang "Chờ kiểm tra phòng"
CREATE OR ALTER PROCEDURE sp_TT5_GetDoanChoKT
AS
BEGIN
    SELECT DISTINCT g.MaDoan, (g.MaDoan + ' - ' + k.HoTenKH) as HienThi
    FROM GIAODICH g
    JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND
    JOIN CT_GIAODICH ct ON g.MaDoan = ct.MaDoan
    WHERE ct.TrangThaiGD = N'Chờ kiểm tra phòng'
END
GO

-- 2. Lấy danh sách CTGD của đoàn đang chờ kiểm tra
CREATE OR ALTER PROCEDURE sp_TT5_GetCTGDByMaDoan
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT MaCTGD, (MaCTGD + ' - P.' + CAST(MaPhong AS NVARCHAR)) as HienThi
    FROM CT_GIAODICH
    WHERE MaDoan = @MaDoan AND TrangThaiGD = N'Chờ kiểm tra phòng'
END
GO

-- 3. Nghiệp vụ: Thêm phí phát sinh, cập nhật Tổng phí và trạng thái CTGD
CREATE OR ALTER PROCEDURE sp_TT5_XacNhanKTPhong
    @MaCTGD NVARCHAR(10),
    @MaDoan NVARCHAR(10),
    @MaPPS NVARCHAR(10),
    @SoLuong INT
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Lấy giá phí từ bảng PHIPHATSINH
        DECLARE @GiaPhi DECIMAL(18,2)
        SELECT @GiaPhi = GiaPhi FROM PHIPHATSINH WHERE MaPPS = @MaPPS

        -- 1. Insert vào CT_PHIPS
        INSERT INTO CT_PHIPS (MaCTGD, MaDoan, MaPPS, SoLuong, ThanhTienPPS)
        VALUES (@MaCTGD, @MaDoan, @MaPPS, @SoLuong, @SoLuong * @GiaPhi);

        -- 2. Cập nhật TongPhiPhatSinh trong CT_GIAODICH
        UPDATE CT_GIAODICH
        SET TongPhiPhatSinh = (SELECT SUM(ThanhTienPPS) FROM CT_PHIPS WHERE MaCTGD = @MaCTGD),
            TrangThaiGD = N'Chờ lập hóa đơn'
        WHERE MaCTGD = @MaCTGD;

        -- 3. Cập nhật trạng thái phòng thành 'Đang trống' (Khách đã trả phòng)
        UPDATE PHONG 
        SET TrangThai = N'Đang trống'
        WHERE MaPhong = (SELECT MaPhong FROM CT_GIAODICH WHERE MaCTGD = @MaCTGD);

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_TT5_ThemPhiPhatSinh
    @MaCTGD NVARCHAR(10),
    @MaDoan NVARCHAR(10),
    @MaPPS NVARCHAR(10),
    @SoLuong INT
AS
BEGIN
    DECLARE @GiaPhi DECIMAL(18,2)
    SELECT @GiaPhi = GiaPhi FROM PHIPHATSINH WHERE MaPPS = @MaPPS

    INSERT INTO CT_PHIPS (MaCTGD, MaDoan, MaPPS, SoLuong, ThanhTienPPS)
    VALUES (@MaCTGD, @MaDoan, @MaPPS, @SoLuong, @SoLuong * @GiaPhi)

    -- Cập nhật tổng phí tạm thời vào chi tiết giao dịch
    UPDATE CT_GIAODICH
    SET TongPhiPhatSinh = (SELECT SUM(ThanhTienPPS) FROM CT_PHIPS WHERE MaCTGD = @MaCTGD)
    WHERE MaCTGD = @MaCTGD
END
GO

CREATE OR ALTER PROCEDURE sp_TT5_ChuyenTrangThaiChoHD
    @MaCTGD NVARCHAR(10)
AS
BEGIN
    -- Tính tổng phí vừa nhập để lưu vào chi tiết giao dịch
    UPDATE CT_GIAODICH 
    SET TongPhiPhatSinh = ISNULL((SELECT SUM(ThanhTienPPS) FROM CT_PHIPS WHERE MaCTGD = @MaCTGD), 0),
        TrangThaiGD = N'Chờ lập hóa đơn' 
    WHERE MaCTGD = @MaCTGD

    -- Giải phóng phòng thành Đang trống
    UPDATE PHONG SET TrangThai = N'Đang trống' 
    WHERE MaPhong = (SELECT MaPhong FROM CT_GIAODICH WHERE MaCTGD = @MaCTGD)
END
GO

CREATE OR ALTER PROCEDURE sp_TT5_HoanTatTatCa
    @MaDoan NVARCHAR(10)
AS
BEGIN
    -- Chuyển TẤT CẢ các phòng đang 'Chờ kiểm tra' sang 'Chờ lập hóa đơn'
    UPDATE CT_GIAODICH 
    SET TrangThaiGD = N'Chờ lập hóa đơn'
    WHERE MaDoan = @MaDoan AND TrangThaiGD = N'Chờ kiểm tra phòng';

    -- Giải phóng tất cả phòng tương ứng
    UPDATE PHONG
    SET TrangThai = N'Đang trống'
    WHERE MaPhong IN (
        SELECT MaPhong FROM CT_GIAODICH 
        WHERE MaDoan = @MaDoan AND TrangThaiGD = N'Chờ lập hóa đơn'
    )
END
GO

CREATE OR ALTER PROCEDURE sp_TT5_HoanTatKiemTraTatCa
    @MaDoan NVARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- 1. Chuyển TẤT CẢ các phòng đang 'Chờ kiểm tra phòng' của đoàn này sang 'Chờ lập hóa đơn'
        -- Lưu ý: Chỉ update những phòng chưa xử lý xong (đang chờ kiểm tra)
        UPDATE CT_GIAODICH 
        SET TrangThaiGD = N'Chờ lập hóa đơn',
            -- Nếu chưa nhập phí gì thì gán bằng 0, nếu lỡ nhập rồi thì giữ nguyên tổng phí đã tính
            TongPhiPhatSinh = ISNULL((SELECT SUM(ThanhTienPPS) FROM CT_PHIPS WHERE MaCTGD = CT_GIAODICH.MaCTGD), 0)
        WHERE MaDoan = @MaDoan AND TrangThaiGD = N'Chờ kiểm tra phòng';

        -- 2. Giải phóng phòng (Set trạng thái phòng thành Đang trống)
        UPDATE PHONG
        SET TrangThai = N'Đang trống'
        WHERE MaPhong IN (
            SELECT MaPhong FROM CT_GIAODICH 
            WHERE MaDoan = @MaDoan AND TrangThaiGD = N'Chờ lập hóa đơn'
        );

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

--TT6: Lập hóa đơn
-- 1. Lấy danh sách đoàn có TẤT CẢ thành viên đã ở trạng thái "Chờ lập hóa đơn"
CREATE OR ALTER PROCEDURE sp_TT6_GetDoanChoLapHD
AS
BEGIN
    SELECT DISTINCT g.MaDoan, (g.MaDoan + ' - ' + k.HoTenKH) as HienThi
    FROM GIAODICH g
    JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND
    WHERE 
    -- 1. Phải có ít nhất 1 phòng đang chờ lập hóa đơn
    EXISTS (SELECT 1 FROM CT_GIAODICH WHERE MaDoan = g.MaDoan AND TrangThaiGD = N'Chờ lập hóa đơn')
    -- 2. VÀ KHÔNG CÒN phòng nào đang 'Đang sử dụng' hoặc 'Chờ kiểm tra phòng'
    AND NOT EXISTS (
        SELECT 1 FROM CT_GIAODICH 
        WHERE MaDoan = g.MaDoan 
        AND TrangThaiGD IN (N'Đang sử dụng', N'Chờ kiểm tra phòng')
    )
END
GO

-- 2. Lấy thông tin tổng quát và chi tiết các phòng để hiện lên form
CREATE OR ALTER PROCEDURE sp_TT6_GetThongTinHoaDon
    @MaDoan NVARCHAR(10)
AS
BEGIN
    -- Lấy thông tin chi tiết từng phòng cho Grid
    -- Tính SoNgay = NgayKT - NgayBD (ít nhất là 1 ngày)
    SELECT 
        ct.MaCTGD, 
        lp.MucGia as DonGiaPhong,
        DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) + CASE WHEN DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) = 0 THEN 1 ELSE 0 END as SoNgay,
        ct.NgayBD, 
        ct.NgayKT, 
        ct.TongPhiPhatSinh,
        ((lp.MucGia * (DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) + CASE WHEN DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) = 0 THEN 1 ELSE 0 END)) + ct.TongPhiPhatSinh) as ThanhTien
    FROM CT_GIAODICH ct
    JOIN PHONG p ON ct.MaPhong = p.MaPhong
    JOIN LOAIPHONG lp ON p.MaLoaiPhong = lp.MaLoaiPhong
    WHERE ct.MaDoan = @MaDoan;

    -- Lấy thông tin tổng hợp cho TextBox (Số điện thoại đại diện)
    SELECT k.SDT_KH 
    FROM GIAODICH g 
    JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND 
    WHERE g.MaDoan = @MaDoan;
END
GO

-- 3. Lưu Hóa Đơn và chuyển trạng thái đoàn
CREATE OR ALTER PROCEDURE sp_TT6_XacNhanLapHD
    @MaHD NVARCHAR(10),
    @MaDoan NVARCHAR(10),
    @MaNV NVARCHAR(10),
    @TongTien DECIMAL(18,2)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- 1. Thêm vào bảng HOADON
        INSERT INTO HOADON (MaHD, NgayLap, NVLap, TrangThaiHD, TongTien, MaDoan)
        VALUES (@MaHD, GETDATE(), @MaNV, N'Chờ thanh toán', @TongTien, @MaDoan);

        -- 2. Cập nhật trạng thái tất cả chi tiết giao dịch của đoàn
        UPDATE CT_GIAODICH 
        SET TrangThaiGD = N'Chờ thanh toán'
        WHERE MaDoan = @MaDoan;

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION; THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_TT6_GetChiTietHoaDon
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT 
        ct.MaCTGD, 
        lp.MucGia as DonGiaPhong,
        DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) + CASE WHEN DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) = 0 THEN 1 ELSE 0 END as SoNgay,
        ct.TongPhiPhatSinh,
        ((lp.MucGia * (DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) + CASE WHEN DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) = 0 THEN 1 ELSE 0 END)) + ct.TongPhiPhatSinh) as ThanhTien
    FROM CT_GIAODICH ct
    JOIN PHONG p ON ct.MaPhong = p.MaPhong
    JOIN LOAIPHONG lp ON p.MaLoaiPhong = lp.MaLoaiPhong
    WHERE ct.MaDoan = @MaDoan
END
GO

-- SP Lấy thông tin hóa đơn tổng hợp
CREATE OR ALTER PROCEDURE sp_TT6_GetFullInvoiceData
    @MaDoan NVARCHAR(10)
AS
BEGIN
    -- Bảng 1: Chi tiết các phòng (LOẠI BỎ PHÒNG ĐÃ HỦY)
    SELECT 
        ct.MaCTGD, 
        ct.CMND, 
        lp.MucGia as DonGiaPhong, 
        DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) + CASE WHEN DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) = 0 THEN 1 ELSE 0 END as SoNgay,
        ISNULL(ct.TongPhiPhatSinh, 0) as TongPhiPhatSinh, 
        
        -- Công thức tính tiền: (Giá phòng * Số ngày) + Phí phát sinh
        ((lp.MucGia * (DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) + CASE WHEN DATEDIFF(DAY, ct.NgayBD, ct.NgayKT) = 0 THEN 1 ELSE 0 END)) 
         + ISNULL(ct.TongPhiPhatSinh, 0)) as ThanhTien
    
    FROM CT_GIAODICH ct
    JOIN PHONG p ON ct.MaPhong = p.MaPhong
    JOIN LOAIPHONG lp ON p.MaLoaiPhong = lp.MaLoaiPhong
    WHERE ct.MaDoan = @MaDoan
    AND ct.TrangThaiGD != N'Đã hủy đặt trước' -- <--- QUAN TRỌNG: Lọc bỏ phòng hủy
    AND ct.TrangThaiGD != N'Đã hoàn thành';    -- (Optional) Tùy nghiệp vụ có muốn in lại HD cũ không

    -- Bảng 2: Lấy thông tin khách hàng đại diện
    SELECT k.HoTenKH, k.SDT_KH, k.DiaChiKH 
    FROM GIAODICH g 
    JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND
    WHERE g.MaDoan = @MaDoan;
END
GO

-- SP Lấy chi tiết phí phát sinh của một phòng
CREATE OR ALTER PROCEDURE sp_TT6_GetChiTietPPS
    @MaCTGD NVARCHAR(10)
AS
BEGIN
    SELECT p.TenPPS, cp.SoLuong, cp.ThanhTienPPS 
    FROM CT_PHIPS cp 
    JOIN PHIPHATSINH p ON cp.MaPPS = p.MaPPS 
    WHERE cp.MaCTGD = @MaCTGD;
END
GO

--TT7: Xem Danh sách hóa đơn đã lập
CREATE OR ALTER PROCEDURE sp_TT7_TimKiemHoaDon
    @MaNV NVARCHAR(10),
    @MaHD NVARCHAR(10) = NULL,
    @MaDoan NVARCHAR(10) = NULL,
    @NgayLap DATE = NULL
AS
BEGIN
	--SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
    SELECT 
        MaHD, 
        MaDoan, 
        NgayLap, 
        TongTien, 
		TrangThaiHD
    FROM HOADON
    WHERE NVLap = @MaNV -- Chỉ lấy hóa đơn nhân viên này lập
    AND (@MaHD IS NULL OR MaHD = @MaHD)
    AND (@MaDoan IS NULL OR MaDoan = @MaDoan)
    AND (@NgayLap IS NULL OR CAST(NgayLap AS DATE) = @NgayLap)
    ORDER BY NgayLap DESC
END
GO

-- Lấy danh sách mã hóa đơn và mã đoàn mà nhân viên này đã từng lập
CREATE OR ALTER PROCEDURE sp_TT7_GetDataForCmb
    @MaNV NVARCHAR(10)
AS
BEGIN
    -- Lấy danh sách Mã Hóa Đơn
    SELECT DISTINCT MaHD FROM HOADON WHERE NVLap = @MaNV;
    -- Lấy danh sách Mã Đoàn
    SELECT DISTINCT MaDoan FROM HOADON WHERE NVLap = @MaNV;
END
GO

--TT8:
-- 1. Lấy tất cả giao dịch hoặc lọc theo Mã Đoàn
CREATE OR ALTER PROCEDURE sp_TT8_GetGiaoDich
    @MaDoan NVARCHAR(10) = NULL
AS
BEGIN
    SELECT MaDoan, DaiDienDoan, SoNguoi, SoPhong, NgayBD, NgayKT, MaNV, MaDaiLy
    FROM GIAODICH
    WHERE (@MaDoan IS NULL OR MaDoan = @MaDoan)
END
GO

-- 2. Cập nhật giao dịch
CREATE OR ALTER PROCEDURE sp_TT8_UpdateGiaoDich
    @MaDoan NVARCHAR(10),
    @DaiDienDoan NVARCHAR(20),
    @SoNguoi INT,
    @SoPhong INT,
    @NgayBD DATETIME,
    @NgayKT DATETIME
AS
BEGIN
    UPDATE GIAODICH
    SET DaiDienDoan = @DaiDienDoan,
        SoNguoi = @SoNguoi,
        SoPhong = @SoPhong,
        NgayBD = @NgayBD,
        NgayKT = @NgayKT
    WHERE MaDoan = @MaDoan
END
GO

-- 3. Xóa giao dịch (Lưu ý xóa CT_GIAODICH trước nếu có ràng buộc)
CREATE OR ALTER PROCEDURE sp_TT8_DeleteGiaoDich
    @MaDoan NVARCHAR(10)
AS
BEGIN
    DELETE FROM CT_GIAODICH WHERE MaDoan = @MaDoan
    DELETE FROM GIAODICH WHERE MaDoan = @MaDoan
END
GO

-- Hàm bổ trợ kiểm tra quyền QTV
IF OBJECT_ID('dbo.fn_KiemTraQuyenQTV', 'FN') IS NOT NULL DROP FUNCTION dbo.fn_KiemTraQuyenQTV
GO

CREATE FUNCTION dbo.fn_KiemTraQuyenQTV (@TenDangNhap NVARCHAR(50))
RETURNS BIT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap AND LoaiTaiKhoan = N'Quản trị viên' AND TrangThaiTK = N'Hoạt động')
        RETURN 1
    RETURN 0
END
GO

--TT9:
-- 1. Lấy danh sách đoàn có phòng đang sử dụng (để nạp vào ComboBox)
CREATE OR ALTER PROCEDURE sp_TT8_GetDoanDangSuDung
AS
BEGIN
    SELECT DISTINCT g.MaDoan, (g.MaDoan + ' - ' + k.HoTenKH) as HienThi
    FROM GIAODICH g
    JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND
    JOIN CT_GIAODICH ct ON g.MaDoan = ct.MaDoan
    WHERE ct.TrangThaiGD = N'Đang sử dụng'
END
GO

-- 2. Lấy chi tiết các phòng đang sử dụng của một đoàn cụ thể
CREATE OR ALTER PROCEDURE sp_TT8_GetChiTietTraPhong
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT 
        CAST(0 AS BIT) AS [TraPhong], -- Cột Checkbox để chọn trả phòng
        ct.MaCTGD, 
        ct.CaNhan AS [CCCD], 
        ct.MaPhong, 
        ct.NgayBD AS [NgayBatDau], 
        ct.NgayKT AS [NgayKetThuc]
    FROM CT_GIAODICH ct
    WHERE ct.MaDoan = @MaDoan AND ct.TrangThaiGD = N'Đang sử dụng'
END
GO

-- 3. Thực hiện trả phòng (Chuyển trạng thái sang Chờ kiểm tra phòng)
CREATE OR ALTER PROCEDURE sp_TT8_XacNhanTraPhong
    @MaCTGD NVARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- 1. Cập nhật trạng thái chi tiết giao dịch
        UPDATE CT_GIAODICH 
        SET TrangThaiGD = N'Chờ kiểm tra phòng'
        WHERE MaCTGD = @MaCTGD;

        -- 2. Thu hồi thẻ từ (Xóa MaCTGD khỏi thẻ và cập nhật trạng thái thẻ nếu cần)
        UPDATE THETU 
        SET MaCTGD = NULL , TrangThaiThe = N'Đang hoạt động'
        WHERE MaCTGD = @MaCTGD;

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- QTV1: Phân quyền người dùng

-- Thêm vai trò mới bằng cách tạo tài khoản mặc định
IF OBJECT_ID('dbo.sp_ThemVaiTroMoi', 'P') IS NOT NULL
	DROP PROC dbo.sp_ThemVaiTroMoi
GO

CREATE OR ALTER PROCEDURE sp_ThemVaiTroMoi
    @TenVaiTroMoi NVARCHAR(20),
	@UserThucHien NVARCHAR(50)
AS
BEGIN
	IF dbo.fn_KiemTraQuyenQTV(@UserThucHien) = 0
    BEGIN
        RAISERROR(N'Lỗi: Bạn không có quyền thực hiện chức năng này!', 16, 1);
        RETURN;
    END
    -- Kiểm tra nếu vai trò này đã tồn tại trong hệ thống chưa
    IF NOT EXISTS (SELECT 1 FROM TAIKHOAN WHERE LoaiTaiKhoan = @TenVaiTroMoi)
    BEGIN
        -- Tạo tài khoản mặc định đại diện cho vai trò
        -- Ví dụ: TenDangNhap = 'Mau_' + TenVaiTro, MatKhau = '11111111'
        INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, NgayTao, TrangThaiTK)
        VALUES (N'Mau_' + @TenVaiTroMoi, N'11111111', @TenVaiTroMoi, GETDATE(), N'Hoạt động');
    END
END;
GO

-- Lấy danh sách vai trò duy nhất (không trùng lặp) để hiển thị lên GridView
IF OBJECT_ID('dbo.sp_LayDSVaiTro', 'P') IS NOT NULL
	DROP PROC dbo.sp_LayDSVaiTro
GO

CREATE PROCEDURE sp_LayDSVaiTro
AS
BEGIN
    SELECT DISTINCT LoaiTaiKhoan AS VaiTro 
    FROM TAIKHOAN;
END;
GO

-- Xóa các vai trò và các tài khoản liên quan

CREATE OR ALTER PROCEDURE sp_XoaVaiTro
    @TenVaiTro NVARCHAR(20),
    @UserThucHien NVARCHAR(50)
AS
BEGIN
    IF dbo.fn_KiemTraQuyenQTV(@UserThucHien) = 0
    BEGIN
        RAISERROR(N'Lỗi: Bạn không có quyền thực hiện!', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        -- 1. Xóa các chi tiết giao dịch liên quan đến các tài khoản thuộc vai trò này
        DELETE CT FROM CT_GIAODICH CT
        JOIN GIAODICH G ON CT.MaDoan = G.MaDoan
        JOIN TAIKHOAN T ON G.TenDangNhap = T.TenDangNhap
        WHERE T.LoaiTaiKhoan = @TenVaiTro;

        -- 2. Gỡ liên kết TenDangNhap trong GIAODICH trước khi xóa TAIKHOAN
        UPDATE GIAODICH 
        SET TenDangNhap = NULL 
        WHERE TenDangNhap IN (SELECT TenDangNhap FROM TAIKHOAN WHERE LoaiTaiKhoan = @TenVaiTro);

        -- 3. Xóa Nhân viên liên quan
        DELETE FROM NHANVIEN WHERE TenDangNhap IN (SELECT TenDangNhap FROM TAIKHOAN WHERE LoaiTaiKhoan = @TenVaiTro);

        -- 4. Cuối cùng mới xóa TAIKHOAN
        DELETE FROM TAIKHOAN WHERE LoaiTaiKhoan = @TenVaiTro;

        COMMIT TRANSACTION;
        SELECT @@ROWCOUNT AS Result;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- QTV2: Quản lý tài khoản

-- Lấy danh sách tài khoản
IF OBJECT_ID('dbo.sp_LayDSTaiKhoan', 'P') IS NOT NULL
	DROP PROC dbo.sp_LayDSTaiKhoan
GO

CREATE PROCEDURE sp_LayDSTaiKhoan
AS
BEGIN
    SELECT TenDangNhap, LoaiTaiKhoan, NgayTao, TrangThaiTK FROM TAIKHOAN;
END;
GO

-- Tạo tài khoản mới
IF OBJECT_ID('dbo.sp_ThemTaiKhoanMoi', 'P') IS NOT NULL
	DROP PROC dbo.sp_ThemTaiKhoanMoi
GO

CREATE PROCEDURE sp_ThemTaiKhoanMoi
    @TenDangNhap NVARCHAR(50),
    @LoaiTaiKhoan NVARCHAR(20),
    @MatKhau NVARCHAR(50),
    @UserThucHien NVARCHAR(50)
AS
BEGIN
	IF dbo.fn_KiemTraQuyenQTV(@UserThucHien) = 0
    BEGIN
        SELECT -1 AS Result; -- Không có quyền
        RETURN;
    END
    -- Kiểm tra trùng tên đăng nhập
    IF NOT EXISTS (SELECT 1 FROM TAIKHOAN WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan, NgayTao, TrangThaiTK)
        VALUES (@TenDangNhap, @MatKhau, @LoaiTaiKhoan, GETDATE(), N'Hoạt động');
        SELECT 1 AS Result; -- Thành công
    END
    ELSE
    BEGIN
        SELECT 0 AS Result; -- Thất bại (trùng tên)
    END
END;

GO

-- Khóa hoặc mở khóa tài khoản
IF OBJECT_ID('dbo.sp_KhoaTaiKhoan', 'P') IS NOT NULL
	DROP PROC dbo.sp_KhoaTaiKhoan
GO

CREATE PROCEDURE sp_KhoaTaiKhoan
    @TenDangNhap NVARCHAR(50),
    @UserThucHien NVARCHAR(50)
AS
BEGIN
	-- Kiểm tra quyền Quản trị viên của người thực hiện
    IF dbo.fn_KiemTraQuyenQTV(@UserThucHien) = 0
    BEGIN
        RAISERROR(N'Lỗi: Bạn không có quyền khóa hoặc mở khóa tài khoản!', 16, 1);
        RETURN;
    END

    UPDATE TAIKHOAN 
    SET TrangThaiTK = CASE WHEN TrangThaiTK = N'Hoạt động' THEN N'Bị khóa' ELSE N'Hoạt động' END
    WHERE TenDangNhap = @TenDangNhap;
END;
GO

-- Đặt lại mật khẩu mặc định (ví dụ: 123)
IF OBJECT_ID('dbo.sp_DatLaiMatKhau', 'P') IS NOT NULL
	DROP PROC dbo.sp_DatLaiMatKhau
GO

CREATE PROCEDURE sp_DatLaiMatKhau
    @TenDangNhap NVARCHAR(50),
    @UserThucHien NVARCHAR(50)
AS
BEGIN
-- Kiểm tra quyền Quản trị viên của người thực hiện
    IF dbo.fn_KiemTraQuyenQTV(@UserThucHien) = 0
    BEGIN
        RAISERROR(N'Lỗi: Bạn không có quyền đặt lại mật khẩu của người khác!', 16, 1);
        RETURN;
    END
    UPDATE TAIKHOAN SET MatKhau = '123' WHERE TenDangNhap = @TenDangNhap;
END;
GO

-- QTV5: Sao lưu dữ liệu
IF OBJECT_ID('dbo.sp_SaoLuuDuLieu', 'P') IS NOT NULL
	DROP PROC dbo.sp_SaoLuuDuLieu
GO

CREATE OR ALTER PROC sp_SaoLuuDuLieu
    @Path NVARCHAR(500),
    @UserThucHien NVARCHAR(50)
AS
BEGIN
	IF dbo.fn_KiemTraQuyenQTV(@UserThucHien) = 0
    BEGIN
        RAISERROR(N'Bạn không có quyền sao lưu hệ thống!', 16, 1);
        RETURN;
    END

    -- Đảm bảo đường dẫn kết thúc bằng dấu \
    IF RIGHT(@Path, 1) <> '\' SET @Path = @Path + '\'
    DECLARE @FileName NVARCHAR(500) = @Path + 'Backup_HolyBird_' + FORMAT(GETDATE(), 'yyyyMMdd_HHmmss') + '.bak'
    
    BACKUP DATABASE [HolyBird] TO DISK = @FileName WITH FORMAT;
END
GO

-- ALL5: Xem danh sách và trạng thái phòng
IF OBJECT_ID('dbo.sp_LayDanhSachPhong', 'P') IS NOT NULL
	DROP PROC dbo.sp_LayDanhSachPhong
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachPhong
    @LoaiPhong NVARCHAR(50) = NULL, -- Tương ứng với cột 'Hang'
    @TrangThai NVARCHAR(50) = NULL,
    @MucGia NVARCHAR(50) = NULL,
    @Tang INT = NULL,
    @HinhThuc NVARCHAR(50) = NULL, -- Tương ứng với cột 'HinhThuc'
    @TimKiem NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        P.MaPhong, 
        LP.Hang AS LoaiPhong,     -- Sửa: Dùng cột 'Hang' thay vì TenLoaiPhong
        LP.HinhThuc AS HinhThuc,  -- Sửa: Dùng trực tiếp cột 'HinhThuc', bỏ CASE WHEN
        P.Tang, 
        LP.MucGia AS GiaTien,     -- Sửa: Dùng cột 'MucGia' thay vì DonGiaPhong
        P.TrangThai
    FROM PHONG P
    INNER JOIN LOAIPHONG LP ON P.MaLoaiPhong = LP.MaLoaiPhong
    WHERE 
        -- 1. Lọc theo Loại phòng (Hang)
        (@LoaiPhong IS NULL OR LP.Hang = @LoaiPhong) -- Sửa: Đã điền tên cột bị thiếu
        
        -- 2. Lọc theo Trạng thái
        AND (@TrangThai IS NULL OR P.TrangThai = @TrangThai)
        
        -- 3. Lọc theo Tầng
        AND (@Tang IS NULL OR P.Tang = @Tang)
        
        -- 4. Lọc theo Hình thức (Đơn, Đôi...)
        -- Vì bảng LOAIPHONG đã lưu chữ 'Đơn', 'Đôi' trong cột HinhThuc nên so sánh trực tiếp
        AND (@HinhThuc IS NULL OR LP.HinhThuc = @HinhThuc)
        
        -- 5. Tìm kiếm theo mã phòng hoặc Hạng phòng
        AND (
            @TimKiem IS NULL 
            OR CAST(P.MaPhong AS NVARCHAR) LIKE '%' + @TimKiem + '%' 
            OR LP.Hang LIKE N'%' + @TimKiem + '%' -- Sửa: Tìm theo Hang
        )
        
        -- 6. Lọc theo Mức giá (Dựa trên MucGia)
        AND (
            @MucGia IS NULL 
            OR (@MucGia = N'Dưới 500k' AND LP.MucGia < 500000)
            OR (@MucGia = N'500k - 1tr' AND LP.MucGia BETWEEN 500000 AND 1000000)
            OR (@MucGia = N'Trên 1tr' AND LP.MucGia > 1000000)
        )
    ORDER BY P.Tang, P.MaPhong;
END
GO

---KHÁCH HÀNG

-- 1. Lấy danh sách phòng trống dựa trên bộ lọc
CREATE OR ALTER PROC sp_TD_LayDSPhongTrong
    @MaDoan NVARCHAR(10),
    @Hang NVARCHAR(50),
    @HinhThuc NVARCHAR(50),
    @Tang INT
AS
BEGIN
    DECLARE @NgayBD DATETIME, @NgayKT DATETIME
    SELECT @NgayBD = NgayBD, @NgayKT = NgayKT FROM GIAODICH WHERE MaDoan = @MaDoan

    SELECT 
        P.MaPhong, 
        LP.Hang, 
        LP.HinhThuc, 
        LP.MucGia, 
        P.Tang,
        -- Tính sức chứa tối đa dựa trên chuỗi HinhThuc
        CASE 
            WHEN LP.HinhThuc = N'1 giường đơn' THEN 1
            WHEN LP.HinhThuc = N'1 giường đôi' THEN 2
            WHEN LP.HinhThuc = N'2 giường đơn' THEN 2
            WHEN LP.HinhThuc = N'2 giường đôi' THEN 4
            ELSE 2 -- Mặc định
        END AS SucChuaToiDa
    FROM PHONG P
    JOIN LOAIPHONG LP ON P.MaLoaiPhong = LP.MaLoaiPhong
    WHERE (@Hang = '' OR LP.Hang = @Hang)
      AND (@HinhThuc = '' OR LP.HinhThuc = @HinhThuc)
      AND (@Tang = 0 OR P.Tang = @Tang)
      AND P.MaPhong NOT IN (
          SELECT MaPhong FROM CT_GIAODICH 
          WHERE TrangThaiGD != N'Đã hủy đặt trước'
            AND NOT (NgayKT <= @NgayBD OR NgayBD >= @NgayKT)
      )
END
GO

-- 2. Kiểm tra ràng buộc số lượng phòng và số người của GIAODICH

CREATE OR ALTER PROC sp_TD_KiemTraRangBuocGiaoDich
    @MaDoan NVARCHAR(10),
    @SoPhongMuonThem INT, 
    @SoNguoiMuonThem INT,
    @NgayBD_CT DATETIME, 
    @NgayKT_CT DATETIME
AS
BEGIN
    DECLARE @SoPhongDK INT, @SoNguoiDK INT
    DECLARE @NgayBD_GD DATETIME, @NgayKT_GD DATETIME
    DECLARE @SoPhongHienCo INT, @SoNguoiHienCo INT

    -- Lấy thông tin gốc của đoàn
    SELECT @SoPhongDK = SoPhong, @SoNguoiDK = SoNguoi, 
           @NgayBD_GD = NgayBD, @NgayKT_GD = NgayKT 
    FROM GIAODICH WHERE MaDoan = @MaDoan

    -- 1. KIỂM TRA THỜI GIAN (QUAN TRỌNG: Dùng CAST AS DATE để bỏ qua giờ phút)
    -- Logic: Ngày bắt đầu của khách < Ngày bắt đầu của đoàn OR Ngày kết thúc của khách > Ngày kết thúc đoàn
    IF (CAST(@NgayBD_CT AS DATE) < CAST(@NgayBD_GD AS DATE) 
        OR CAST(@NgayKT_CT AS DATE) > CAST(@NgayKT_GD AS DATE))
    BEGIN
        -- In ra lỗi kèm giờ để bạn dễ debug nếu cần
        SELECT N'Lỗi: Thời gian đặt (' + CONVERT(VARCHAR, @NgayBD_CT, 103) + N') nằm ngoài thời gian đăng ký của đoàn (' 
               + CONVERT(VARCHAR, @NgayBD_GD, 103) + N')' as Error
        RETURN;
    END

    -- 2. Đếm số lượng đã có (Chỉ đếm phòng chưa hủy)
    SELECT @SoPhongHienCo = COUNT(DISTINCT MaPhong), 
           @SoNguoiHienCo = COUNT(DISTINCT CMND)
    FROM CT_GIAODICH 
    WHERE MaDoan = @MaDoan AND TrangThaiGD != N'Đã hủy đặt trước'

    -- 3. Kiểm tra số lượng
    IF (@SoPhongHienCo + @SoPhongMuonThem > @SoPhongDK)
        SELECT N'Lỗi: Vượt quá số phòng đăng ký (' + CAST(@SoPhongDK AS NVARCHAR) + N')' as Error
    ELSE IF (@SoNguoiHienCo + @SoNguoiMuonThem > @SoNguoiDK)
        SELECT N'Lỗi: Vượt quá số người đăng ký (' + CAST(@SoNguoiDK AS NVARCHAR) + N')' as Error
    ELSE
        SELECT 'OK' as Error
END
GO

-- 1. Lấy danh sách chi tiết giao dịch của một đoàn cụ thể
-- Chỉ lấy các chi tiết có khả năng sửa/xóa (trước khi nhận phòng)
CREATE OR ALTER PROCEDURE sp_TD_GetChiTietGiaoDichByMaDoan
    @MaDoan NVARCHAR(10)
AS
BEGIN
    SELECT 
        -- Chỉ cho phép chọn để Xóa/Sửa nếu chưa nhận phòng
        CASE WHEN TrangThaiGD IN (N'Đã đặt trước', N'Chưa nhận phòng') THEN CAST(0 AS BIT) 
             ELSE CAST(0 AS BIT) END AS [Chon], 
        MaCTGD,
        CMND,
        MaPhong,
        NgayBD AS [BatDau],
        NgayKT AS [KetThuc],
        TrangThaiGD
    FROM CT_GIAODICH
    WHERE MaDoan = @MaDoan 
      AND TrangThaiGD != N'Đã hoàn thành' -- Không hiện các giao dịch cũ đã kết thúc
END
GO

-- 2. Cập nhật trạng thái hủy đặt trước

CREATE OR ALTER PROCEDURE sp_TD_HuyChiTietGiaoDich
    @MaCTGD NVARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- 1. Cập nhật trạng thái chi tiết giao dịch
        UPDATE CT_GIAODICH
        SET TrangThaiGD = N'Đã hủy đặt trước'
        WHERE MaCTGD = @MaCTGD

        -- 2. Giải phóng phòng tương ứng (QUAN TRỌNG)
        -- Lấy mã phòng từ MaCTGD đang xử lý
        DECLARE @MaPhong INT
        SELECT @MaPhong = MaPhong FROM CT_GIAODICH WHERE MaCTGD = @MaCTGD

        -- Đưa phòng về trạng thái 'Đang trống'
        UPDATE PHONG 
        SET TrangThai = N'Đang trống' 
        WHERE MaPhong = @MaPhong

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        THROW;
    END CATCH
END
GO

-- Procedure xử lý thanh toán cho Trưởng đoàn
CREATE OR ALTER PROCEDURE sp_TD_ThanhToanHoaDon
    @MaHD NVARCHAR(10),
    @MaDoan NVARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- 1. Cập nhật trạng thái Hóa đơn
        UPDATE HOADON 
        SET TrangThaiHD = N'Đã thanh toán' 
        WHERE MaHD = @MaHD;

        -- 2. Cập nhật tất cả chi tiết giao dịch của đoàn
        UPDATE CT_GIAODICH 
        SET TrangThaiGD = N'Đã hoàn thành' 
        WHERE MaDoan = @MaDoan;

        -- 3. Giải phóng tất cả phòng thuộc đoàn này (Đổi trạng thái phòng sang Đang trống)
        UPDATE PHONG
        SET TrangThai = N'Đang trống'
        WHERE MaPhong IN (SELECT MaPhong FROM CT_GIAODICH WHERE MaDoan = @MaDoan);

        -- 4. Khóa tài khoản đoàn (để khách không đăng nhập sau khi đã rời đi - Optional)
        -- UPDATE TAIKHOAN SET TrangThaiTK = N'Bị khóa' 
        -- WHERE TenDangNhap = (SELECT TenDangNhap FROM GIAODICH WHERE MaDoan = @MaDoan);

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE OR ALTER PROCEDURE sp_Job_TuDongHuyPhongTre
AS
BEGIN
    -- Tìm các phòng chưa nhận mà đã trễ quá 120 phút
    DECLARE @DS_Tre TABLE (MaCTGD NVARCHAR(10), MaPhong INT)

    INSERT INTO @DS_Tre
    SELECT MaCTGD, MaPhong
    FROM CT_GIAODICH
    WHERE TrangThaiGD IN (N'Chưa nhận phòng', N'Đã đặt trước')
      AND DATEDIFF(MINUTE, NgayBD, GETDATE()) > 120

    -- 1. Cập nhật trạng thái Giao dịch thành 'Đã hủy (Trễ)'
    UPDATE CT_GIAODICH
    SET TrangThaiGD = N'Đã hủy (Trễ)'
    WHERE MaCTGD IN (SELECT MaCTGD FROM @DS_Tre)

    -- 2. Trả phòng về trạng thái 'Đang trống'
    UPDATE PHONG
    SET TrangThai = N'Đang trống'
    WHERE MaPhong IN (SELECT MaPhong FROM @DS_Tre)

    -- Trả về số lượng đã hủy (int)
    SELECT COUNT(*) FROM @DS_Tre
END
GO