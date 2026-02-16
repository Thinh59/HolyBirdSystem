using System;
using System.Windows.Forms;
using QL_HolyBird.Common; // Đảm bảo có namespace này để dùng SessionData/Session

namespace QL_HolyBird
{
    public partial class QL_main : Form
    {
        private bool isDangXuat = false;

        public QL_main()
        {
            InitializeComponent();
            // Đăng ký sự kiện đóng form để thoát ứng dụng hoàn toàn nếu không phải đăng xuất
            this.FormClosed += QL_main_FormClosed;
        }

        // Hàm dùng chung để load các UserControl vào Panel hiển thị chính
        private void LoadControl(UserControl usc)
        {
            if (usc != null)
            {
                pnl_QL_HienThiChinh.Controls.Clear();
                usc.Dock = DockStyle.Fill;
                pnl_QL_HienThiChinh.Controls.Add(usc);
                usc.BringToFront();
            }
        }

        private void QL_main_Load(object sender, EventArgs e)
        {
            // Mặc định khi vừa mở sẽ hiện Dashboard hoặc Danh sách Giao dịch
            btn_QL_DSGD_Click(sender, e);
        }

        private void btn_QL_DSGD_Click(object sender, EventArgs e)
        {
            LoadControl(new QL_DSGD());
        }

        private void btn_QL_DSHD_Click_1(object sender, EventArgs e)
        {
            LoadControl(new QL_DSHD());
        }

        private void btn_QL_DSNV_Click(object sender, EventArgs e)
        {
            LoadControl(new QL_DSNV());
        }

        private void btn_QL_QLPPS_Click(object sender, EventArgs e)
        {
            LoadControl(new QL_QLPPS());
        }

        private void btn_ChinhSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadControl(new ALL_ChinhSuaTaiKhoan());
        }

        private void btn_QL_QLP_Click(object sender, EventArgs e)
        {
            LoadControl(new QL_QLPhong());
        }

        private void btn_QL_KHGD_Click(object sender, EventArgs e)
        {
            LoadControl(new QL_KHGD());
        }

        private void btn_TaiKhoan_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_ALL_ThongTinChiTiet());
        }

        private void QL_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Nếu người dùng nhấn dấu X ở góc màn hình mà không nhấn Đăng xuất
            if (!isDangXuat)
            {
                Application.Exit();
            }
        }

        private void btn_QL_logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                isDangXuat = true;

                // 1. Xóa sạch dữ liệu phiên làm việc
                // Lưu ý: Kiểm tra class của bạn là Session hay SessionData để gọi cho đúng
                Session.Clear();

                // 2. Ẩn form hiện tại
                this.Hide();

                // 3. Mở lại form đăng nhập
                // Giả sử form đăng nhập của bạn tên là ALL_Login
                ALL_Login loginForm = new ALL_Login();
                loginForm.Show();

                // 4. Đóng form chính
                this.Close();
            }
        }
    }
}