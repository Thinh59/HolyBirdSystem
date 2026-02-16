using System;
using System.Windows.Forms;
using QL_HolyBird.TiepTan;
using QL_HolyBird.Common;

namespace QL_HolyBird
{
    public partial class TiepTan_main : Form
    {
        private bool isDangXuat = false;

        public TiepTan_main()
        {
            InitializeComponent();
            // Đăng ký sự kiện đóng form để thoát ứng dụng hoàn toàn
            this.FormClosed += TT_main_FormClosed;
        }

        // Hàm dùng chung để load các UserControl vào Panel chính (Tối ưu code)
        private void LoadControl(UserControl usc)
        {
            if (usc != null)
            {
                pnl_HienThiCHinh.Controls.Clear();
                usc.Dock = DockStyle.Fill;
                pnl_HienThiCHinh.Controls.Add(usc);
                usc.BringToFront();
            }
        }

        private void TiepTan_main_Load(object sender, EventArgs e)
        {
            // Mặc định khi vừa mở sẽ hiện trang Danh sách phòng hoặc Đăng ký giao dịch
            btn_DSP_Click(sender, e);
        }

        private void btn_DKGD_Click(object sender, EventArgs e)
        {
            LoadControl(new TT_DK_GiaoDich());
        }

        private void btn_TTKKH_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TT_TaoTKKH());
        }

        private void btn_KHGD_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TT_KichHoatGD());
        }

        private void btn_CTT_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TT_CapTheTu());
        }

        private void btn_TT_XNTraPhong_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TT_XNTraPhong());
        }

        private void btn_KTP_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TT_KTPhong());
        }

        private void button16_Click(object sender, EventArgs e) // Nút Lập hóa đơn
        {
            LoadControl(new Usc_TT6_LapHD());
        }

        private void btn_XHD_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TT_XemHD());
        }

        private void btn_CNGD_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_TT_CapNhatGiaoDich());
        }

        private void btn_DSP_Click(object sender, EventArgs e)
        {
            LoadControl(new ALL_DanhSachTrangThaiPhong());
        }

        private void btn_TT_TaiKhoan_Click(object sender, EventArgs e)
        {
            LoadControl(new Usc_ALL_ThongTinChiTiet());
        }

        private void btn_ChinhSuaTK_Click(object sender, EventArgs e)
        {
            LoadControl(new ALL_ChinhSuaTaiKhoan());
        }

        private void TT_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Nếu người dùng nhấn X mà chưa nhấn Đăng xuất, đóng toàn bộ ứng dụng
            if (!isDangXuat)
            {
                Application.Exit();
            }
        }

        private void btn_DX_Click(object sender, EventArgs e)
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
                SessionData.Clear(); // Xóa sạch dữ liệu phiên làm việc

                this.Hide();
                // Hiển thị lại form Login
                ALL_Login loginForm = new ALL_Login();
                loginForm.Show();
                this.Close(); // Đóng form main sau khi quay lại login
            }
        }
    }
}