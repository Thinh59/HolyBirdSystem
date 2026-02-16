using QL_HolyBird.Common;
using System;
using System.Windows.Forms;

namespace QL_HolyBird.TruongDoan
{
    public partial class TD_main : Form
    {
        private bool isDangXuat = false;
        private string username; // Lưu username người đăng nhập

        // Constructor mặc định
        public TD_main()
        {
            InitializeComponent();
            this.FormClosed += TD_main_FormClosed;
        }

        // Constructor có truyền tham số (giống mẫu PetCare)
        public TD_main(string user) : this()
        {
            this.username = user;
        }

        // Hàm dùng chung để load UserControl vào Panel chính (Tối ưu code)
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

        private void TD_main_Load(object sender, EventArgs e)
        {
            // Load mặc định trang đặt phòng hoặc trang thông tin khi vừa mở
            btn_TD_DatPhong_Click(sender, e);
        }

        private void btn_TD_DatPhong_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TD_DatPhongChoTV());
        }

        private void btn_TD_TTCT_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_ALL_ThongTinChiTiet());
        }

        private void btn_TD_ChinhSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            // Lưu ý: Nếu là Form thì dùng .Show(), nếu là UserControl thì dùng LoadControl
            LoadControl(new ALL_ChinhSuaTaiKhoan());
        }

        private void btn_DanhSachPhong_Click(object sender, EventArgs e)
        {
            LoadControl(new ALL_DanhSachTrangThaiPhong());
        }

        private void btn_TD_XemPhongDaDat_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TD_QuanLyGiaoDich());
        }

        private void btn_TD_DSHD_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TD_ThanhToanHoaDon());
        }

        private void btn_TD_LSGD_Click(object sender, EventArgs e)
        {
            // Ví dụ: LoadControl(new Usc_TD_LichSuGiaoDich());
        }

        // Xử lý khi đóng Form để thoát hẳn ứng dụng (Tránh chạy ngầm)
        private void TD_main_FormClosed(object sender, FormClosedEventArgs e)
        {
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
                SessionData.Clear(); // Xóa phiên làm việc

                this.Hide();
                ALL_Login loginForm = new ALL_Login(); // Mở lại form Login
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}