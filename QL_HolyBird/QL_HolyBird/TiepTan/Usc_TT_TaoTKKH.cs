using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_HolyBird.TiepTan
{
    public partial class Usc_TT_TaoTKKH : UserControl
    {
        ServiceDAL dal = new ServiceDAL();
        private bool isEditMode = false;

        public Usc_TT_TaoTKKH()
        {
            InitializeComponent();
        }

        private void Usc_TT_TaoTKKH_Load(object sender, EventArgs e)
        {
            txb_TT2_Username.ReadOnly = true;
            txb_TT2_MatKhau.Text = "123";
            btn_TT2_XacNhan.Enabled = false;
        }

        // Đổi tên sự kiện cho đúng ý nghĩa: Kiểm tra theo Mã Đoàn
        private void txb_TT2_MaDoan_TextChanged(object sender, EventArgs e)
        {
            string maDoan = txb_TT2_MaDoan.Text.Trim();
            if (string.IsNullOrEmpty(maDoan))
            {
                txb_TT2_Username.Text = "";
                btn_TT2_XacNhan.Enabled = false;
                return;
            }

            // Kiểm tra xem Mã Đoàn này có tồn tại không
            string queryCheckGD = "SELECT TenDangNhap FROM GIAODICH WHERE MaDoan = @MaDoan";
            DataTable dtGD = dal.GetDataTable(queryCheckGD, new SqlParameter[] { new SqlParameter("@MaDoan", maDoan) });

            if (dtGD.Rows.Count == 0)
            {
                txb_TT2_Username.Text = "Giao dịch không tồn tại";
                txb_TT2_Username.ForeColor = Color.Gray;
                btn_TT2_XacNhan.Enabled = false;
                return;
            }

            // Lấy Username đã được cấp cho đoàn này
            string currentUsername = dtGD.Rows[0]["TenDangNhap"].ToString();
            txb_TT2_Username.Text = currentUsername;

            if (!string.IsNullOrEmpty(currentUsername))
            {
                // Đoàn này đã có tài khoản -> Chuyển sang chế độ Reset mật khẩu
                isEditMode = true;
                txb_TT2_Username.ForeColor = Color.Blue;
                btn_TT2_XacNhan.Text = "Reset Mật khẩu Đoàn";
                btn_TT2_XacNhan.Enabled = true;
            }
            else
            {
                // Đoàn này chưa có tài khoản (Trường hợp hi hữu do lỗi TT1)
                isEditMode = false;
                txb_TT2_Username.Text = "USER_" + maDoan; // Gợi ý tạo mới
                txb_TT2_Username.ForeColor = Color.Green;
                btn_TT2_XacNhan.Text = "Cấp tài khoản mới";
                btn_TT2_XacNhan.Enabled = true;
            }
        }

        private void btn_TT2_XacNhan_Click(object sender, EventArgs e)
        {
            string maDoan = txb_TT2_MaDoan.Text.Trim();
            string user = txb_TT2_Username.Text;
            string pass = txb_TT2_MatKhau.Text;

            if (isEditMode)
            {
                // Logic Reset mật khẩu cho tài khoản Đoàn
                string query = "UPDATE TAIKHOAN SET MatKhau = @Pass WHERE TenDangNhap = @User";
                SqlParameter[] p = {
                    new SqlParameter("@Pass", pass),
                    new SqlParameter("@User", user)
                };
                if (dal.ExecuteNonQuery(query, p))
                    MessageBox.Show("Đã cập nhật mật khẩu mới cho đoàn thành công!");
            }
            else
            {
                // Logic Cấp mới tài khoản (Nếu TT1 lỡ quên hoặc chưa tạo)
                try
                {
                    // 1. Insert vào bảng TAIKHOAN
                    string queryIns = "INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, LoaiTaiKhoan) VALUES (@User, @Pass, N'Khách hàng')";
                    dal.ExecuteNonQuery(queryIns, new SqlParameter[] {
                        new SqlParameter("@User", user),
                        new SqlParameter("@Pass", pass)
                    });

                    // 2. Update TenDangNhap vào bảng GIAODICH
                    string queryUp = "UPDATE GIAODICH SET TenDangNhap = @User WHERE MaDoan = @MaDoan";
                    dal.ExecuteNonQuery(queryUp, new SqlParameter[] {
                        new SqlParameter("@User", user),
                        new SqlParameter("@MaDoan", maDoan)
                    });

                    MessageBox.Show("Đã cấp tài khoản bổ sung cho đoàn thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btn_TT2_Huy_Click(object sender, EventArgs e)
        {
            txb_TT2_MaDoan.Clear();
            txb_TT2_MatKhau.Text = "123";
        }
    }
}