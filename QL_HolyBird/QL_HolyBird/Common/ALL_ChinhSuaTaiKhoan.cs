using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QL_HolyBird.Common; // Đảm bảo namespace này chứa lớp Session

namespace QL_HolyBird
{
    public partial class ALL_ChinhSuaTaiKhoan : UserControl
    {
        ServiceDAL db = new ServiceDAL();

        public ALL_ChinhSuaTaiKhoan()
        {
            InitializeComponent();
        }

        private void ALL_ChinhSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            // Tên đăng nhập lấy từ Session và khóa lại không cho sửa
            tb_ALL_TenDangNhap.Text = Session.TenDangNhap;
            tb_ALL_TenDangNhap.ReadOnly = true;
            tb_ALL_TenDangNhap.BackColor = System.Drawing.Color.LightGray;
        }

        private void btn_ALL_XacNhan_Click(object sender, EventArgs e)
        {
            string mkCu = txb_ALL_MKCu.Text.Trim();
            string mkMoi = txb_ALL_MKMoi.Text.Trim();

            // 1. Kiểm tra đầu vào cơ bản
            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu cũ và mật khẩu mới!", "Thông báo");
                return;
            }

            if (mkMoi.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Thông báo");
                return;
            }

            try
            {
                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();

                    // 2. Kiểm tra mật khẩu cũ có đúng không
                    string sqlCheck = "SELECT COUNT(*) FROM TAIKHOAN WHERE TenDangNhap = @user AND MatKhau = @pass";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, con);
                    cmdCheck.Parameters.AddWithValue("@user", Session.TenDangNhap);
                    cmdCheck.Parameters.AddWithValue("@pass", mkCu);

                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        // 3. Tiến hành cập nhật mật khẩu mới
                        string sqlUpdate = "UPDATE TAIKHOAN SET MatKhau = @newPass WHERE TenDangNhap = @user";
                        SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con);
                        cmdUpdate.Parameters.AddWithValue("@newPass", mkMoi);
                        cmdUpdate.Parameters.AddWithValue("@user", Session.TenDangNhap);

                        cmdUpdate.ExecuteNonQuery();
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Xóa trắng các ô nhập sau khi thành công
                        txb_ALL_MKCu.Clear();
                        txb_ALL_MKMoi.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btn_ALL_Huy_Click(object sender, EventArgs e)
        {
            txb_ALL_MKCu.Clear();
            txb_ALL_MKMoi.Clear();
        }
    }
}