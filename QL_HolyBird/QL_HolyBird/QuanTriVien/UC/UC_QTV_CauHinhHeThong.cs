using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QL_HolyBird
{
    public partial class UC_QTV_CauHinhHeThong : UserControl, ILocalizable
    {
        ServiceDAL logic = new ServiceDAL();
        public UC_QTV_CauHinhHeThong()
        {
            InitializeComponent();
            SetupDefaultData();
            this.Load += new System.EventHandler(this.UC_QTV_CauHinhHeThong_Load);
        }

        // Bổ sung các giá trị lựa chọn cho ComboBox
        private void SetupDefaultData()
        {
            comboBox_NgayGio.Items.AddRange(new string[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" });
            comboBox_TienTe.Items.AddRange(new string[] { "VND", "USD", "EUR" });
            comboBox_NgonNgu.Items.AddRange(new string[] { "Tiếng Việt", "English" });
        }

        private void UC_QTV_CauHinhHeThong_Load(object sender, EventArgs e)
        {
            LoadSettings();
            ApplyLanguage();
        }

        // Đọc dữ liệu từ Settings của ứng dụng
        private void LoadSettings()
        {
            comboBox_NgayGio.Text = CauHinh.DinhDangNgay;
            comboBox_TienTe.Text = CauHinh.DonViTienTe;
            comboBox_NgonNgu.Text = CauHinh.NgonNgu;
            nud_VAT.Value = CauHinh.ThueVAT;
            nud_TiGia.Value = CauHinh.TiGiaUSD;
            dtp_CheckIn.Value = DateTime.ParseExact(CauHinh.GioCheckIn, "HH:mm", null);
            dtp_CheckOut.Value = DateTime.ParseExact(CauHinh.GioCheckOut, "HH:mm", null);
        }

        // Xử lý nút Lưu thay đổi
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Sử dụng hàm an toàn ngay trong sự kiện click
            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];
            string Get(string key) => lang.ContainsKey(key) ? lang[key] : key;

            if (MessageBox.Show(Get("CauHoiLuu"), Get("XacNhan"),
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CauHinh.DinhDangNgay = comboBox_NgayGio.Text;
                CauHinh.DonViTienTe = comboBox_TienTe.Text;
                CauHinh.NgonNgu = comboBox_NgonNgu.Text;
                CauHinh.ThueVAT = nud_VAT.Value;
                CauHinh.TiGiaUSD = nud_TiGia.Value;
                CauHinh.GioCheckIn = dtp_CheckIn.Value.ToString("HH:mm");
                CauHinh.GioCheckOut = dtp_CheckOut.Value.ToString("HH:mm");
                CauHinh.Save();

                LanguageManager.CurrentLang = comboBox_NgonNgu.Text;

                // Cập nhật giao diện Dashboard
                if (QTV_Dashboard.Instance != null)
                {
                    QTV_Dashboard.Instance.ApplyLanguage();
                }

                // Cập nhật lại chính form này
                ApplyLanguage();

                logic.GhiNhatKy("Hệ thống", "Thay đổi cấu hình", "Thành công");

                MessageBox.Show("Đã lưu cấu hình thành công!", Get("ThongBao"));
            }
        }

        public void ApplyLanguage()
        {
            // 1. Kiểm tra ngôn ngữ
            if (!LanguageManager.Languages.ContainsKey(LanguageManager.CurrentLang))
                LanguageManager.CurrentLang = "Tiếng Việt";

            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];

            // 2. Hàm lấy key an toàn
            string Get(string key) => lang.ContainsKey(key) ? lang[key] : $"[{key}]";

            // 3. Gán text
            lbCauHinh.Text = Get("CauHinh");
            btnLuu.Text = Get("LuuThayDoi");
            lbDinhDang.Text = Get("DinhDangNgayGio");
            lbDonViTT.Text = Get("DonViTienTe");
            lbNgonNgu.Text = Get("NgonNgu");
            lbThueVAT.Text = Get("ThueVAT");
            lbGioCheckin.Text = Get("GioCheckIn");
            lbGioCheckout.Text = Get("GioCheckOut");
            lbTiGia.Text = Get("TiGia");
            btnHuy.Text = Get("Huy");
        }

        // Xử lý nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadSettings();
            MessageBox.Show("Đã hủy các thay đổi chưa lưu.");
        }

        private void comboBox_NgayGio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
