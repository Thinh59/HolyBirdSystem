using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QL_HolyBird.Common; // Đảm bảo namespace này chứa ALL_Login và Session/SessionData

namespace QL_HolyBird
{
    public partial class QTV_Dashboard : Form
    {
        private bool isDangXuat = false;
        public static QTV_Dashboard Instance { get; private set; }

        public QTV_Dashboard()
        {
            InitializeComponent();
            Instance = this;
            // Đăng ký sự kiện đóng form để thoát ứng dụng hoàn toàn
            this.FormClosed += QTV_main_FormClosed;
        }

        private void QTV_Dashboard_Load(object sender, EventArgs e)
        {
            // 1. Thiết lập ngôn ngữ
            string languageSetting = CauHinh.NgonNgu;
            LanguageManager.CurrentLang = string.IsNullOrEmpty(languageSetting) ? "Tiếng Việt" : languageSetting;

            // 2. Cập nhật Sidebar theo ngôn ngữ
            ApplyLanguage();

            // 3. Mở trang mặc định
            btnPhanQuyen_Click(null, null);
        }

        public void ApplyLanguage()
        {
            if (!LanguageManager.Languages.ContainsKey(LanguageManager.CurrentLang)) return;

            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];

            btnPhanQuyen.Text = SafeGetString(lang, "PhanQuyen", "Phân quyền");
            btnQLTaiKhoan.Text = SafeGetString(lang, "TaiKhoan", "Tài khoản");
            btnCauHinh.Text = SafeGetString(lang, "CauHinh", "Cấu hình");
            btnNhatKy.Text = SafeGetString(lang, "NhatKy", "Nhật ký");
            btnSaoLuu.Text = SafeGetString(lang, "SaoLuu", "Sao lưu");
            btnDangXuat.Text = SafeGetString(lang, "DangXuat", "Đăng xuất");

            if (pnlContent.Controls.Count > 0 && pnlContent.Controls[0] is ILocalizable uc)
            {
                uc.ApplyLanguage();
            }
        }

        private string SafeGetString(Dictionary<string, string> dictionary, string key, string defaultValue)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
        }

        // Tối ưu hàm thêm UserControl
        private void addUserControl(UserControl userControl)
        {
            pnlContent.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(userControl);

            if (userControl is ILocalizable localizableUC)
            {
                localizableUC.ApplyLanguage();
            }
            userControl.BringToFront();
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e) => addUserControl(new UC_QTV_PhanQuyen());

        private void btnQLTaiKhoan_Click(object sender, EventArgs e) => addUserControl(new UC_QTV_QuanLyTaiKhoan());

        private void btnCauHinh_Click(object sender, EventArgs e) => addUserControl(new UC_QTV_CauHinhHeThong());

        private void btnNhatKy_Click(object sender, EventArgs e) => addUserControl(new UC_QTV_NhatKyHeThong());

        private void btnSaoLuu_Click(object sender, EventArgs e) => addUserControl(new UC_QTV_SaoLuuDuLieu());

        // Xử lý nút Tài khoản (Thông tin cá nhân Admin)
        private void btn_TaiKhoan_Click(object sender, EventArgs e)
        {
            addUserControl(new Usc_ALL_ThongTinChiTiet());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
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
                Session.Clear(); // Sử dụng Session hoặc SessionData tùy theo cấu trúc của bạn

                this.Hide();
                // Quay lại form Login
                ALL_Login loginForm = new ALL_Login();
                loginForm.Show();
                this.Close();
            }
        }

        private void QTV_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Nếu người dùng nhấn X mà không phải đăng xuất, tắt toàn bộ ứng dụng
            if (!isDangXuat)
            {
                Application.Exit();
            }
        }

        private void btn_TT_ChinhSuaTK_Click(object sender, EventArgs e) => addUserControl(new ALL_ChinhSuaTaiKhoan());

    }
}