using System;
using System.Collections.Generic;

namespace QL_HolyBird
{
    public interface ILocalizable { void ApplyLanguage(); }

    public static class Session
    {
        public static string TenDangNhap { get; set; } = "admin_test";
        public static string MaNV { get; set; }
        public static string TenNV { get; set; }
        public static string LoaiTaiKhoan { get; set; } // "Quản trị viên", "Tiếp tân", "Khách hàng"

        // --- THÊM MỚI CHO ĐOÀN KHÁCH ---
        public static string MaDoan { get; set; }      // Lưu MaDoan nếu là tài khoản đoàn
        public static DateTime? NgayKT { get; set; }    // Hạn dùng của tài khoản (Ngày trả phòng)
        public static string TenTruongDoan { get; set; }

        public static string Username { get { return TenDangNhap; } set { TenDangNhap = value; } }

        public static void Clear()
        {
            TenDangNhap = null;
            MaNV = null;
            TenNV = null;
            LoaiTaiKhoan = null;
            MaDoan = null;
            NgayKT = null;
            TenTruongDoan = null;
        }
    }

    public static class SessionData
    {
        public static string TenDangNhap { get { return Session.TenDangNhap; } set { Session.TenDangNhap = value; } }
        public static void Clear() { Session.Clear(); }
    }

    public class ChucNangQuyen
    {
        public string ChucNang { get; set; }
        public bool Xem { get; set; }
        public bool Sua { get; set; }
        public bool Xoa { get; set; }
    }

    public class NhatKyHeThong
    {
        public string ThoiGian { get; set; }
        public string NguoiThucHien { get; set; }
        public string DoiTuong { get; set; }
        public string HanhDong { get; set; }
        public string KetQua { get; set; }
    }

    public class BanSaoLuu
    {
        public string ThoiGian { get; set; }
        public string TenTep { get; set; }
        public string NguoiThucHien { get; set; }
        public string DungLuong { get; set; }
    }

    // BỔ SUNG DICTIONARY NGÔN NGỮ ĐỂ HẾT LỖI
    // Trong file SessionData.cs

    // Trong file SessionData.cs
    public static class LanguageManager
    {
        public static string CurrentLang = "Tiếng Việt";

        public static Dictionary<string, Dictionary<string, string>> Languages = new Dictionary<string, Dictionary<string, string>>
    {
        { "Tiếng Việt", new Dictionary<string, string> {
            // --- Chung ---
            { "ThongBao", "Thông báo" },
            { "ThanhCong", "Thành công" },
            { "Loi", "Lỗi" },
            { "XacNhan", "Xác nhận" },
            { "Huy", "Hủy bỏ" },
            { "LuuThayDoi", "Lưu thay đổi" },
            { "ApDung", "Áp dụng" },
            { "DatLai", "Đặt lại" },
            { "ThoiGian", "Thời gian" },
            { "NguoiThucHien", "Người thực hiện" },

            // --- Sao Lưu Dữ Liệu (BẠN ĐANG THIẾU CÁI NÀY) ---
            { "SaoLuu", "Sao lưu & Phục hồi" },
            { "DanhSachSaoLuu", "Danh sách các bản sao lưu" }, // Đã sửa lỗi chính tả 'Dah' -> 'Danh'
            { "TaoBanSaoLuu", "Tạo bản sao lưu mới" },
            { "TenTep", "Tên tệp tin" },
            { "DungLuong", "Dung lượng" },

            // --- Nhật Ký Hệ Thống ---
            { "NhatKy", "Nhật ký hoạt động" },
            { "LocTheoNgay", "Lọc theo thời gian:" },
            { "LocTheoUser", "Lọc theo người dùng:" },
            { "DoiTuong", "Đối tượng" },
            { "HanhDong", "Hành động" },
            { "KetQua", "Kết quả" },

            // --- Cấu Hình ---
            { "CauHinh", "Cấu hình hệ thống" },
            { "DinhDangNgayGio", "Định dạng ngày giờ" },
            { "DonViTienTe", "Đơn vị tiền tệ" },
            { "NgonNgu", "Ngôn ngữ hiển thị" },
            { "ThueVAT", "Thuế VAT (%)" },
            { "TiGia", "Tỉ giá USD (VND)" },
            { "GioCheckIn", "Giờ Check-in mặc định" },
            { "GioCheckOut", "Giờ Check-out mặc định" },
            { "CauHoiLuu", "Bạn có chắc chắn muốn lưu cấu hình này không?" },

            // --- Quản Lý Tài Khoản ---
            { "QuanLyTaiKhoan", "Quản lý Tài khoản" },
            { "TimKiem", "Tìm kiếm" },
            { "ThemTaiKhoan", "Thêm tài khoản" },
            { "TenDangNhap", "Tên đăng nhập" },
            { "MatKhau", "Mật khẩu" },
            { "LoaiTaiKhoan", "Loại tài khoản" },
            { "TrangThai", "Trạng thái" },
            { "NgayTao", "Ngày tạo" },
            { "Khoa", "Khóa/Mở" },
            { "DatLaiMK", "Đặt lại MK" },

            // --- Phân Quyền ---
            { "PhanQuyen", "Phân quyền Vai trò" },
            { "DsVaiTro", "Danh sách vai trò" },
            { "ThemVaiTro", "Thêm vai trò" },
            { "VaiTro", "Vai trò" },
            { "ChinhSua", "Chỉnh sửa" },
            { "Xoa", "Xóa" },
            { "NhapTenVaiTro", "Nhập tên vai trò mới:" }
        }},

        { "English", new Dictionary<string, string> {
            // --- General ---
            { "ThongBao", "Notification" },
            { "ThanhCong", "Success" },
            { "Loi", "Error" },
            { "XacNhan", "Confirm" },
            { "Huy", "Cancel" },
            { "LuuThayDoi", "Save Changes" },
            { "ApDung", "Apply" },
            { "DatLai", "Reset" },
            { "ThoiGian", "Time" },
            { "NguoiThucHien", "User" },

            // --- Backup Data ---
            { "SaoLuu", "Backup & Restore" },
            { "DanhSachSaoLuu", "List of Backups" },
            { "TaoBanSaoLuu", "Create New Backup" },
            { "TenTep", "File Name" },
            { "DungLuong", "Size" },

            // --- System Log ---
            { "NhatKy", "System Activity Log" },
            { "LocTheoNgay", "Filter by Date:" },
            { "LocTheoUser", "Filter by User:" },
            { "DoiTuong", "Target" },
            { "HanhDong", "Action" },
            { "KetQua", "Result" },

            // --- Configuration ---
            { "CauHinh", "System Configuration" },
            { "DinhDangNgayGio", "Date/Time Format" },
            { "DonViTienTe", "Currency Unit" },
            { "NgonNgu", "Display Language" },
            { "ThueVAT", "VAT Tax (%)" },
            { "TiGia", "USD Exchange Rate" },
            { "GioCheckIn", "Default Check-in Time" },
            { "GioCheckOut", "Default Check-out Time" },
            { "CauHoiLuu", "Are you sure you want to save these settings?" },

            // --- Account Management ---
            { "QuanLyTaiKhoan", "Account Management" },
            { "TimKiem", "Search" },
            { "ThemTaiKhoan", "Add Account" },
            { "TenDangNhap", "Username" },
            { "MatKhau", "Password" },
            { "LoaiTaiKhoan", "Role" },
            { "TrangThai", "Status" },
            { "NgayTao", "Created Date" },
            { "Khoa", "Lock/Unlock" },
            { "DatLaiMK", "Reset Pass" },

            // --- Permissions ---
            { "PhanQuyen", "Permissions and Roles" },
            { "DsVaiTro", "List of Roles" },
            { "ThemVaiTro", "Add Role" },
            { "VaiTro", "Role Name" },
            { "ChinhSua", "Edit" },
            { "Xoa", "Delete" },
            { "NhapTenVaiTro", "Enter new role name:" }
        }}
    };
    }
}