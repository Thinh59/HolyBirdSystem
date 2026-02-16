using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QL_HolyBird.QuanTriVien;
using System.Configuration;

namespace QL_HolyBird
{
    // CẤU HÌNH (Đã sửa ThueVAT thành decimal để tính tiền ko lỗi)
    public static class CauHinh
    {
        public static string DinhDangNgay { get; set; } = "dd/MM/yyyy";
        public static string DonViTienTe { get; set; } = "VNĐ";
        public static string GioCheckIn { get; set; } = "14:00";
        public static string GioCheckOut { get; set; } = "12:00";
        public static string NgonNgu { get; set; } = "Tiếng Việt";

        // QUAN TRỌNG: Để decimal để nhân với tiền tệ không bị lỗi convert
        public static decimal ThueVAT { get; set; } = 0.1m;
        public static decimal TiGiaUSD { get; set; } = 23500m;

        // Thêm hàm Save giả để code cũ gọi ko bị lỗi
        public static void Save() { }
    }

    public class ServiceDAL
    {
        protected readonly string connectionString = ConfigurationManager.ConnectionStrings["HolyBirdConn"].ConnectionString;
        private string logFilePath = "SystemLog.txt";

        public SqlConnection GetConnection() => new SqlConnection(connectionString);

        // --- CÁC HÀM THỰC THI (ĐÃ BỔ SUNG ĐẦY ĐỦ TÊN HÀM CŨ) ---

        public DataTable GetDataTable(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi SQL: " + ex.Message); }
            return dt;
        }

        // Đây là hàm mà code cũ của mày đang tìm kiếm
        public bool ExecuteSPNonQuery(string spName, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(spName, con);
                    cmd.CommandType = CommandType.StoredProcedure; // Quan trọng: Báo đây là SP
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi SP: " + ex.Message); return false; }
        }

        // Hàm chạy lệnh thường (SQL String)
        //public bool ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        //{
        //    try
        //    {
        //        using (SqlConnection con = GetConnection())
        //        {
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand(query, con);
        //            if (parameters != null) cmd.Parameters.AddRange(parameters);
        //            return cmd.ExecuteNonQuery() > 0;
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); return false; }
        //}

        // Trong ServiceDAL.cs
        public bool ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // 1. Tự động nhận diện Stored Procedure hay SQL thường
                        // Nếu chuỗi không chứa dấu cách (ví dụ "sp_Them"), coi là SP.
                        if (!sql.Trim().Contains(" "))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                        }
                        else
                        {
                            cmd.CommandType = CommandType.Text;
                        }

                        // 2. Thêm tham số
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        // 3. Thực thi
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // --- QUAN TRỌNG: KHÔNG ĐƯỢC "GIẤU" LỖI ---
                // Ném lỗi ra ngoài để Form hiển thị lên MessageBox
                throw new Exception("Lỗi SQL: " + ex.Message);
            }
        }

        public DataTable ExecuteStoredProcedure(string spName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(spName, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi SP: " + ex.Message); }
            return dt;
        }

        // Hàm trả về 1 giá trị (ví dụ SELECT COUNT...)
        public int ExecuteStoredProcedureWithReturnValue(string spName, SqlParameter[] parameters)
        {
            using (SqlConnection con = GetConnection())
            {
                if (con.State == ConnectionState.Closed) con.Open();
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    SqlParameter returnParameter = new SqlParameter();
                    returnParameter.ParameterName = "@ReturnValue";
                    returnParameter.SqlDbType = SqlDbType.Int;
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnParameter);

                    cmd.ExecuteNonQuery();

                    // Ép kiểu (int) ở đây để trả về đúng kiểu dữ liệu
                    return (int)returnParameter.Value;
                }
            }
        }
        public DataSet ExecuteStoredProcedure_DataSet(string spName, SqlParameter[] parameters)
        {
            using (SqlConnection con = GetConnection())
            {
                if (con.State == ConnectionState.Closed) con.Open();
                using (SqlCommand cmd = new SqlCommand(spName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    // Hàm Fill sẽ nạp tất cả các kết quả SELECT từ Procedure vào DataSet
                    da.Fill(ds);
                    return ds;
                }
            }
        }

        // --- CÁC HÀM NGHIỆP VỤ (BỔ SUNG TimKiemTaiKhoan) ---
        public DataTable TD_LayDSPhongTrong(string maDoan, string hang, string hinhThuc, string tang)
        {
            // Chuyển đổi tang sang kiểu int an toàn, nếu trống thì mặc định là 0 (để SQL xử lý @Tang = 0)
            int tangInt = 0;
            int.TryParse(tang, out tangInt);

            SqlParameter[] p = {
        new SqlParameter("@MaDoan", maDoan),
        new SqlParameter("@Hang", hang ?? (object)DBNull.Value),
        new SqlParameter("@HinhThuc", hinhThuc ?? (object)DBNull.Value),
        new SqlParameter("@Tang", tangInt)
    };

            return ExecuteStoredProcedure("sp_TD_LayDSPhongTrong", p);
        }

        // Lấy danh sách các Tầng hiện có trong bảng PHONG
        public DataTable LayDS_Tang()
        {
            return GetDataTable("SELECT DISTINCT Tang FROM PHONG ORDER BY Tang");
        }

        // Lấy danh sách Hạng phòng (Vip, Thường...)
        public DataTable LayDS_Hang()
        {
            return GetDataTable("SELECT DISTINCT Hang FROM LOAIPHONG");
        }

        // Lấy danh sách Hình thức (Đơn, Đôi...)
        public DataTable LayDS_HinhThuc()
        {
            return GetDataTable("SELECT DISTINCT HinhThuc FROM LOAIPHONG");
        }
        // Dán vào ServiceDAL.cs
        public DataTable GetDataTableSP(string procName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        // --- ĐÂY LÀ DÒNG QUAN TRỌNG NHẤT BẠN ĐANG THIẾU ---
                        cmd.CommandType = CommandType.StoredProcedure;
                        // ---------------------------------------------------

                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log hoặc ném lỗi để dễ debug
                throw new Exception("Lỗi gọi SP: " + ex.Message);
            }
            return dt;
        }

        public string TD_KiemTraRangBuoc(string maDoan, int soPhongThem, int soNguoiThem, DateTime ngayBD, DateTime ngayKT)
        {
            try
            {
                // Code tạo tham số cũ của bạn giữ nguyên
                SqlParameter[] p = {
            new SqlParameter("@MaDoan", maDoan ?? ""),
            new SqlParameter("@SoPhongMuonThem", soPhongThem),
            new SqlParameter("@SoNguoiMuonThem", soNguoiThem),
            new SqlParameter("@NgayBD_CT", ngayBD),
            new SqlParameter("@NgayKT_CT", ngayKT)
        };

                // --- SỬA DÒNG NÀY ---
                // Cũ: DataTable dt = GetDataTable("sp_TD_KiemTraRangBuocGiaoDich", p);

                // Mới (Dùng hàm vừa tạo ở Bước 1):
                DataTable dt = GetDataTableSP("sp_TD_KiemTraRangBuocGiaoDich", p);
                // --------------------

                if (dt != null && dt.Rows.Count > 0)
                    return dt.Rows[0]["Error"].ToString();

                return "Lỗi không xác định";
            }
            catch (Exception ex)
            {
                return "Lỗi DAL: " + ex.Message;
            }
        }

        // Lấy chi tiết giao dịch theo đoàn
        public DataTable TD_GetChiTietGiaoDich(string maDoan)
        {
            return ExecuteStoredProcedure("sp_TD_GetChiTietGiaoDichByMaDoan",
                new SqlParameter[] { new SqlParameter("@MaDoan", maDoan) });
        }

        public DataTable TD_GetThongTinGiaoDich(string maDoan)
        {
            return ExecuteQuery("SELECT SoNguoi, SoPhong, NgayBD, NgayKT FROM GIAODICH WHERE MaDoan = @ma",
                new SqlParameter[] { new SqlParameter("@ma", maDoan) });
        }

        public DataTable ExecuteQuery(string sql, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                // Thay "connectionString" bằng biến chuỗi kết nối thực tế của bạn
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi truy vấn: " + ex.Message);
            }
            return dt;
        }

        // Hủy chi tiết giao dịch
        public bool TD_HuyChiTietGiaoDich(string maCTGD)
        {
            return ExecuteSPNonQuery("sp_TD_HuyChiTietGiaoDich",
                new SqlParameter[] { new SqlParameter("@MaCTGD", maCTGD) });
        }
        public DataTable TT8_GetDoanDangSuDung() => ExecuteStoredProcedure("sp_TT8_GetDoanDangSuDung");

        // Lấy chi tiết phòng của đoàn để trả
        public DataTable TT8_GetChiTietTraPhong(string maDoan)
        {
            return ExecuteStoredProcedure("sp_TT8_GetChiTietTraPhong", new[] { new System.Data.SqlClient.SqlParameter("@MaDoan", maDoan) });
        }

        // Thực hiện trả phòng cho từng chi tiết
        public bool TT8_XacNhanTraPhong(string maCTGD)
        {
            return ExecuteSPNonQuery("sp_TT8_XacNhanTraPhong", new[] { new System.Data.SqlClient.SqlParameter("@MaCTGD", maCTGD) });
        }
        public DataTable TimKiemTaiKhoan(string tuKhoa)
        {
            return GetDataTable($"SELECT * FROM TAIKHOAN WHERE TenDangNhap LIKE '%{tuKhoa}%'");
        }

        public DataTable LayDSVaiTro() => ExecuteStoredProcedure("sp_LayDSVaiTro");
        public DataTable LayDSTaiKhoan() => ExecuteStoredProcedure("sp_LayDSTaiKhoan");

        public bool ThemVaiTro(string ten) => ExecuteSPNonQuery("sp_ThemVaiTroMoi", new[] { new SqlParameter("@TenVaiTroMoi", ten), new SqlParameter("@UserThucHien", Session.TenDangNhap) });
        public bool XoaVaiTro(string ten) => ExecuteSPNonQuery("sp_XoaVaiTro", new[] { new SqlParameter("@TenVaiTro", ten), new SqlParameter("@UserThucHien", Session.TenDangNhap) });
        public bool KhoaTaiKhoan(string user) => ExecuteSPNonQuery("sp_KhoaTaiKhoan", new[] { new SqlParameter("@TenDangNhap", user), new SqlParameter("@UserThucHien", Session.TenDangNhap) });
        public bool DatLaiMatKhau(string user) => ExecuteSPNonQuery("sp_DatLaiMatKhau", new[] { new SqlParameter("@TenDangNhap", user), new SqlParameter("@UserThucHien", Session.TenDangNhap) });

        public bool ThemTaiKhoan(string user, string loai)
        {
            DataTable dt = ExecuteStoredProcedure("sp_ThemTaiKhoanMoi", new[] {
                new SqlParameter("@TenDangNhap", user), new SqlParameter("@LoaiTaiKhoan", loai),
                new SqlParameter("@MatKhau", "123"), new SqlParameter("@UserThucHien", Session.TenDangNhap)
            });
            return dt.Rows.Count > 0 && dt.Rows[0]["Result"].ToString() == "1";
        }

        // --- CÁC HÀM KHÁC ---
        public DataTable GetThongTinCaNhan(string username) => ExecuteStoredProcedure("sp_ALL3_GetThongTinCaNhan", new SqlParameter[] { new SqlParameter("@TenDangNhap", username) });

        public bool UpdateThongTinCaNhan(string username, string hoTen, DateTime ngaySinh, string sdt, string email)
        {
            return ExecuteSPNonQuery("sp_ALL3_UpdateThongTinCaNhan", new SqlParameter[] {
                new SqlParameter("@TenDangNhap", username), new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgaySinh", ngaySinh), new SqlParameter("@SDT", sdt), new SqlParameter("@Email", email)
            });
        }

        public string TT1_TaoGiaoDich(string usernameNV, string hoTenKH, string cmnd, int soNguoi, int soPhong, DateTime ngayBD, DateTime ngayKT)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_TT1_TaoGiaoDich", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Truyền các tham số đầu vào (Input)
                    cmd.Parameters.AddWithValue("@UsernameNV", usernameNV);
                    cmd.Parameters.AddWithValue("@HoTenKH", hoTenKH);
                    cmd.Parameters.AddWithValue("@CMND", cmnd);
                    cmd.Parameters.AddWithValue("@SoNguoi", soNguoi);
                    cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                    cmd.Parameters.AddWithValue("@NgayBD", ngayBD);
                    cmd.Parameters.AddWithValue("@NgayKT", ngayKT);

                    // Khai báo tham số đầu ra (Output) để nhận chuỗi thông báo từ SQL
                    SqlParameter outputParam = new SqlParameter("@KetQua", SqlDbType.NVarChar, 255);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    // Trả về giá trị từ tham số Output
                    return outputParam.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối: " + ex.Message;
            }
        }

        public void GhiNhatKy(string doiTuong, string hanhDong, string ketQua)
        {
            try { File.AppendAllLines(logFilePath, new[] { $"{DateTime.Now}|{Session.TenDangNhap}|{doiTuong}|{hanhDong}|{ketQua}" }); } catch { }
        }

        public List<NhatKyHeThong> DocTatCaNhatKy()
        {
            var ds = new List<NhatKyHeThong>();
            if (File.Exists(logFilePath))
                foreach (var l in File.ReadAllLines(logFilePath))
                { var p = l.Split('|'); if (p.Length >= 5) ds.Add(new NhatKyHeThong { ThoiGian = p[0], NguoiThucHien = p[1], DoiTuong = p[2], HanhDong = p[3], KetQua = p[4] }); }
            return ds.OrderByDescending(x => x.ThoiGian).ToList();
        }

        public bool SaoLuuHeThong(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return ExecuteSPNonQuery("sp_SaoLuuDuLieu", new[] { new SqlParameter("@Path", path), new SqlParameter("@UserThucHien", Session.TenDangNhap) });
        }

        public DataTable LayDanhSachPhong(string loai, string status, string price, string floor, string style, string search)
        {
            // Chuyển floor sang int nếu có giá trị
            object floorVal = string.IsNullOrEmpty(floor) ? DBNull.Value : (object)int.Parse(floor);

            SqlParameter[] p = {
        new SqlParameter("@LoaiPhong", string.IsNullOrEmpty(loai) ? DBNull.Value : (object)loai),
        new SqlParameter("@TrangThai", string.IsNullOrEmpty(status) ? DBNull.Value : (object)status),
        new SqlParameter("@MucGia", string.IsNullOrEmpty(price) ? DBNull.Value : (object)price),
        new SqlParameter("@Tang", floorVal),
        new SqlParameter("@HinhThuc", string.IsNullOrEmpty(style) ? DBNull.Value : (object)style),
        new SqlParameter("@TimKiem", string.IsNullOrEmpty(search) ? DBNull.Value : (object)search)
    };

            // Đảm bảo procedure này đã được chạy trong SQL
            return ExecuteStoredProcedure("sp_LayDanhSachPhong", p);
        }

        private static Dictionary<string, List<ChucNangQuyen>> boNho = new Dictionary<string, List<ChucNangQuyen>>();
        public List<ChucNangQuyen> LayQuyenTheoVaiTro(string vt) => boNho.ContainsKey(vt) ? boNho[vt] : new List<ChucNangQuyen>();
        public void LuuThayDoiQuyen(string vt, List<ChucNangQuyen> ds) => boNho[vt] = ds;
    }
}