using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QL_HolyBird.TruongDoan; // Namespace chứa TD_main
using QL_HolyBird.TiepTan;   // Namespace chứa TiepTan_main
using QL_HolyBird.QuanTriVien; // Namespace chứa QTV_Dashboard

namespace QL_HolyBird.Common
{
    public partial class ALL_Login : Form
    {
        ServiceDAL dal = new ServiceDAL();

        public ALL_Login()
        {
            InitializeComponent();
            this.AcceptButton = btn_ALL_LI; // Nhấn Enter để đăng nhập
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void btn_ALL_LI_Click(object sender, EventArgs e)
        {
            string user = tbox_ALL_LI_TDN.Text.Trim();
            string pass = tbox_ALL_LI_MK.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }

            try
            {
                SqlParameter[] p = {
            new SqlParameter("@TenDangNhap", user),
            new SqlParameter("@MatKhau", pass)
        };

                DataTable dt = dal.ExecuteStoredProcedure("sp_Login", p);

                if (dt.Rows.Count > 0)
                {
                    Session.Clear();
                    DataRow row = dt.Rows[0];

                    Session.TenDangNhap = row["TenDangNhap"].ToString();
                    Session.LoaiTaiKhoan = row["LoaiTaiKhoan"].ToString();

                    if (Session.LoaiTaiKhoan == "Khách hàng" || Session.LoaiTaiKhoan == "Trưởng đoàn")
                    {
                        Session.MaDoan = row["MaDinhDanh"].ToString();
                        Session.TenNV = row["HoTen"].ToString();
                        Session.NgayKT = Convert.ToDateTime(row["NgayKT"]);
                    }
                    else
                    {
                        Session.MaNV = row["MaDinhDanh"].ToString();
                        Session.TenNV = row["HoTen"].ToString();
                    }

                    MessageBox.Show($"Chào mừng {Session.TenNV} đăng nhập thành công!", "Thông báo");

                    // --- FIX LỖI TẠI ĐÂY ---
                    // 1. Phải gọi hàm mở giao diện ở đây
                    // 2. Truyền Session.LoaiTaiKhoan và User vào
                    MoGiaoDienTheoQuyen(Session.LoaiTaiKhoan, user);

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, hoặc tài khoản bị khóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hệ thống: " + ex.Message);
            }
        }

        // Cập nhật tham số nhận vào cho hàm này
        private void MoGiaoDienTheoQuyen(string loai, string user)
        {
            switch (loai)
            {
                case "Tiếp tân":
                    TiepTan_main frmTT = new TiepTan_main();
                    frmTT.Show();
                    break;

                case "Quản lý":
                    QL_main frmQL = new QL_main();
                    frmQL.Show();
                    break;

                case "Quản trị viên":
                    QTV_Dashboard frmQTV = new QTV_Dashboard();
                    frmQTV.Show();
                    break;

                case "Khách hàng":
                case "Trưởng đoàn":
                    // Truyền user (Tên đăng nhập) vào Constructor của TD_main
                    TD_main frmTD = new TD_main(user);
                    frmTD.Show();
                    break;

                default:
                    MessageBox.Show("Tài khoản chưa được phân quyền truy cập.");
                    this.Show();
                    break;
            }
        }

        private void linkLab_ALL_LI_QMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ bộ phận Tiếp tân hoặc Quản lý để được hỗ trợ cấp lại mật khẩu.");
        }
    }
}