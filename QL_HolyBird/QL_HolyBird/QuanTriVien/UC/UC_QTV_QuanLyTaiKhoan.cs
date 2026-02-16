using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QL_HolyBird
{
    public partial class UC_QTV_QuanLyTaiKhoan : UserControl, ILocalizable
    {
        ServiceDAL logic = new ServiceDAL();

        public UC_QTV_QuanLyTaiKhoan()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.UC_QTV_QuanLyTaiKhoan_Load);
            btnThemTK.Click += btnThemTK_Click;
            btnLuu.Click += btnLuu_Click;
        }

        private void UC_QTV_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDSTaiKhoan();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            // 1. Kiểm tra ngôn ngữ tồn tại
            if (!LanguageManager.Languages.ContainsKey(LanguageManager.CurrentLang))
                LanguageManager.CurrentLang = "Tiếng Việt";

            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];

            // 2. Hàm lấy từ an toàn (Không bao giờ crash)
            string Get(string key)
            {
                return lang.ContainsKey(key) ? lang[key] : $"[{key}]";
            }

            lbTKHT.Text = Get("QuanLyTaiKhoan"); 
            btnThemTK.Text = Get("ThemTaiKhoan"); 
            btn_TimKiem.Text = Get("TimKiem");    
            btnLuu.Text = Get("LuuThayDoi");      

            if (dgv_QTV_DSVaiTro.Columns["TenDangNhap"] != null)
                dgv_QTV_DSVaiTro.Columns["TenDangNhap"].HeaderText = Get("TenDangNhap");

            if (dgv_QTV_DSVaiTro.Columns["LoaiTK"] != null)
                dgv_QTV_DSVaiTro.Columns["LoaiTK"].HeaderText = Get("LoaiTaiKhoan");

            if (dgv_QTV_DSVaiTro.Columns["NgayTao"] != null)
                dgv_QTV_DSVaiTro.Columns["NgayTao"].HeaderText = Get("NgayTao"); // Sửa key "ThoiGian" -> "NgayTao"

            if (dgv_QTV_DSVaiTro.Columns["TrangThai"] != null)
                dgv_QTV_DSVaiTro.Columns["TrangThai"].HeaderText = Get("TrangThai");

            // Các cột Button
            if (dgv_QTV_DSVaiTro.Columns["DatLaiMatKhau"] != null)
                dgv_QTV_DSVaiTro.Columns["DatLaiMatKhau"].HeaderText = Get("DatLaiMK");

            if (dgv_QTV_DSVaiTro.Columns["KhoaTaiKhoan"] != null)
                dgv_QTV_DSVaiTro.Columns["KhoaTaiKhoan"].HeaderText = Get("Khoa");
        }

        private void LoadDSTaiKhoan()
        {
            dgv_QTV_DSVaiTro.AutoGenerateColumns = false;

            DataTable dt = logic.LayDSTaiKhoan();
            dgv_QTV_DSVaiTro.DataSource = dt;

            dgv_QTV_DSVaiTro.Columns["TenDangNhap"].DataPropertyName = "TenDangNhap";
            dgv_QTV_DSVaiTro.Columns["LoaiTK"].DataPropertyName = "LoaiTaiKhoan";
            dgv_QTV_DSVaiTro.Columns["NgayTao"].DataPropertyName = "NgayTao";
            dgv_QTV_DSVaiTro.Columns["TrangThai"].DataPropertyName = "TrangThaiTK";
        }

        private void dgv_QTV_DSVaiTro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string userName = dgv_QTV_DSVaiTro.Rows[e.RowIndex].Cells["TenDangNhap"].Value.ToString();

            // Xử lý nút Đặt lại mật khẩu
            if (dgv_QTV_DSVaiTro.Columns[e.ColumnIndex].Name == "DatLaiMatKhau")
            {
                if (MessageBox.Show($"Đặt lại mật khẩu cho {userName} về '123'?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // GỌI HÀM GHI LOG
                    logic.GhiNhatKy("Tài khoản", "Đặt lại mật khẩu cho " + userName, "Thành công");

                    logic.DatLaiMatKhau(userName);
                    MessageBox.Show("Đã đặt lại mật khẩu!");
                }
            }

            // Xử lý nút Khóa tài khoản
            if (dgv_QTV_DSVaiTro.Columns[e.ColumnIndex].Name == "KhoaTaiKhoan")
            {
                // Lấy trạng thái hiện tại để hiển thị thông báo chính xác (Khóa hoặc Mở khóa)
                string trangThaiHT = dgv_QTV_DSVaiTro.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();
                string hanhDong = (trangThaiHT == "Hoạt động") ? "khóa" : "mở khóa";

                if (MessageBox.Show($"Bạn có chắc chắn muốn {hanhDong} tài khoản {userName} không?",
                    "Xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (logic.KhoaTaiKhoan(userName))
                    {
                        // GỌI HÀM GHI LOG
                        logic.GhiNhatKy("Tài khoản", "Khóa/Mở khóa " + userName, "Thành công");

                        MessageBox.Show($"Đã {hanhDong} tài khoản thành công!");
                        LoadDSTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Thao tác thất bại, vui lòng kiểm tra lại.");
                    }
                }
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            dgv_QTV_DSVaiTro.DataSource = logic.TimKiemTaiKhoan(textBox_TimKiem.Text);
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            // 1. Nhập tên đăng nhập
            string newUser = Interaction.InputBox("Nhập tên đăng nhập mới:", "Tạo tài khoản", "");

            if (!string.IsNullOrWhiteSpace(newUser))
            {
                // 2. Nhập loại tài khoản (Quản lý, Tiếp tân, v.v.)
                string loaiTK = Interaction.InputBox("Nhập vai trò (Quản lý, Tiếp tân, Quản trị viên...):", "Chọn vai trò", "Tiếp tân");

                if (!string.IsNullOrWhiteSpace(loaiTK))
                {
                    // 3. Gọi logic thực thi
                    if (logic.ThemTaiKhoan(newUser.Trim(), loaiTK.Trim()))
                    {
                        // GỌI HÀM GHI LOG
                        logic.GhiNhatKy("Tài khoản", "Tạo tài khoản mới" + newUser + " cho " + loaiTK, "Thành công");

                        MessageBox.Show($"Thành công! Đã tạo tài khoản {newUser} với mật khẩu mặc định là '123'.", "Thông báo");
                        LoadDSTaiKhoan();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Tên đăng nhập đã tồn tại hoặc vai trò không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mọi thay đổi đã được lưu hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
