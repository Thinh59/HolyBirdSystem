using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HolyBird
{
    public partial class UC_QTV_SaoLuuDuLieu : UserControl, ILocalizable
    {
        ServiceDAL logic = new ServiceDAL();
        public UC_QTV_SaoLuuDuLieu()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(UC_QTV_SaoLuuDuLieu_Load);
        }


        private void UC_QTV_SaoLuuDuLieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachSaoLuu();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            // 1. Kiểm tra ngôn ngữ
            if (!LanguageManager.Languages.ContainsKey(LanguageManager.CurrentLang))
                LanguageManager.CurrentLang = "Tiếng Việt";

            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];

            // 2. Hàm lấy từ an toàn
            string Get(string key) => lang.ContainsKey(key) ? lang[key] : $"[{key}]";

            // 3. Gán text (Đã sửa lỗi chính tả key của bạn: DahSach -> DanhSach)
            lbCauHinh.Text = Get("SaoLuu");
            lbDanhSachSaoLuu.Text = Get("DanhSachSaoLuu"); // Sửa key ở đây
            btnTaoSaoLuu.Text = Get("TaoBanSaoLuu");

            // 4. Dịch DataGridView (Kiểm tra null)
            if (dgv_NhatKy.Columns["ThoiGian"] != null)
                dgv_NhatKy.Columns["ThoiGian"].HeaderText = Get("ThoiGian");

            if (dgv_NhatKy.Columns["TenTep"] != null)
                dgv_NhatKy.Columns["TenTep"].HeaderText = Get("TenTep");

            if (dgv_NhatKy.Columns["NguoiThucHien"] != null)
                dgv_NhatKy.Columns["NguoiThucHien"].HeaderText = Get("NguoiThucHien");

            if (dgv_NhatKy.Columns["DungLuong"] != null)
                dgv_NhatKy.Columns["DungLuong"].HeaderText = Get("DungLuong");
        }

        private void btnTaoSaoLuu_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");

            if (logic.SaoLuuHeThong(path))
            {
                // Ghi nhật ký vào file log để theo dõi ai đã backup
                logic.GhiNhatKy("Hệ thống", "Tạo bản sao lưu dữ liệu", "Thành công");

                MessageBox.Show("Sao lưu dữ liệu thành công!", "Thông báo");
                LoadDanhSachSaoLuu();
            }
            else
            {
                MessageBox.Show("Lỗi thực hiện sao lưu. Vui lòng kiểm tra quyền truy cập thư mục.");
            }
        }

        private void LoadDanhSachSaoLuu()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                DirectoryInfo d = new DirectoryInfo(path);
                // Lấy tất cả file .bak và sắp xếp theo thời gian mới nhất
                FileInfo[] Files = d.GetFiles("*.bak").OrderByDescending(f => f.CreationTime).ToArray();

                List<BanSaoLuu> ds = new List<BanSaoLuu>();
                foreach (FileInfo file in Files)
                {
                    ds.Add(new BanSaoLuu
                    {
                        ThoiGian = file.CreationTime.ToString("dd/MM/yyyy HH:mm:ss"),
                        TenTep = file.Name,
                        NguoiThucHien = Session.TenDangNhap ?? "Hệ thống",
                        DungLuong = Math.Round((double)file.Length / (1024 * 1024), 2).ToString() + " MB"
                    });
                }

                dgv_NhatKy.AutoGenerateColumns = false;
                dgv_NhatKy.DataSource = null;
                dgv_NhatKy.DataSource = ds;

                // Thiết lập ánh xạ cột
                dgv_NhatKy.Columns["ThoiGian"].DataPropertyName = "ThoiGian";
                dgv_NhatKy.Columns["TenTep"].DataPropertyName = "TenTep";
                dgv_NhatKy.Columns["NguoiThucHien"].DataPropertyName = "NguoiThucHien";
                dgv_NhatKy.Columns["DungLuong"].DataPropertyName = "DungLuong";
            }
            catch (Exception ex)
            {
                // Tránh treo app khi thư mục không truy cập được
            }
        }

    }
}
