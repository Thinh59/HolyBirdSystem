using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace QL_HolyBird
{
    public partial class UC_QTV_NhatKyHeThong : UserControl, ILocalizable
    {
        ServiceDAL logic = new ServiceDAL();

        public UC_QTV_NhatKyHeThong()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(UC_QTV_NhatKyHeThong_Load);
        }

        private void UC_QTV_NhatKyHeThong_Load(object sender, EventArgs e)
        {
            LoadNhatKy();
            // Nạp dữ liệu mặc định cho bộ lọc ngày
            comboBox_LocTheoNgay.Items.AddRange(new string[] { "Hôm nay", "Hôm qua", "3 ngày trước", "7 ngày trước", "Tất cả" });
            ApplyLanguage();
        }

        private void LoadNhatKy()
        {
            var data = logic.DocTatCaNhatKy();
            //MessageBox.Show("Số lượng nhật ký tìm thấy: " + data.Count.ToString());

            dataGridView_NhatKy.AutoGenerateColumns = false;
            dataGridView_NhatKy.DataSource = data;

            // Ánh xạ các cột theo thiết kế của bạn
            dataGridView_NhatKy.Columns["ThoiGian"].DataPropertyName = "ThoiGian";
            dataGridView_NhatKy.Columns["NguoiThucHien"].DataPropertyName = "NguoiThucHien";
            dataGridView_NhatKy.Columns["DoiTuong"].DataPropertyName = "DoiTuong";
            dataGridView_NhatKy.Columns["HanhDong"].DataPropertyName = "HanhDong";
            dataGridView_NhatKy.Columns["KetQua"].DataPropertyName = "KetQua";
        }

        private void ThucHienLoc()
        {
            // 1. Lấy toàn bộ dữ liệu gốc từ file
            var allData = logic.DocTatCaNhatKy();

            // 2. Lấy giá trị từ các điều khiển lọc
            string textSearch = textBox_LocNguoiDung.Text.Trim().ToLower();
            string dateFilter = comboBox_LocTheoNgay.Text;

            // 3. Thực hiện lọc theo Username (nếu có nhập)
            var filteredData = allData.Where(x =>
                string.IsNullOrEmpty(textSearch) || x.NguoiThucHien.ToLower().Contains(textSearch)
            ).ToList();

            // 4. Thực hiện lọc theo mốc thời gian (nếu không chọn "Tất cả")
            if (!string.IsNullOrEmpty(dateFilter) && dateFilter != "Tất cả")
            {
                DateTime ngayHienTai = DateTime.Now.Date;
                DateTime mocThoiGian = ngayHienTai;

                switch (dateFilter)
                {
                    case "Hôm nay": mocThoiGian = ngayHienTai; break;
                    case "Hôm qua": mocThoiGian = ngayHienTai.AddDays(-1); break;
                    case "3 ngày trước": mocThoiGian = ngayHienTai.AddDays(-3); break;
                    case "7 ngày trước": mocThoiGian = ngayHienTai.AddDays(-7); break;
                }

                filteredData = filteredData.Where(x => {
                    if (DateTime.TryParseExact(x.ThoiGian, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime logDate))
                    {
                        if (dateFilter == "Hôm qua") return logDate.Date == mocThoiGian;
                        return logDate.Date >= mocThoiGian;
                    }
                    return false;
                }).ToList();
            }

            // 5. Hiển thị kết quả
            dataGridView_NhatKy.DataSource = null;
            dataGridView_NhatKy.DataSource = filteredData;
        }


        // Lọc theo tên người dùng khi nhập vào TextBox
        private void textBox_LocNguoiDung_TextChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        // Lọc theo ngày khi chọn ComboBox
        private void comboBox_LocTheoNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        public void ApplyLanguage()
        {
            // 1. Kiểm tra ngôn ngữ
            if (!LanguageManager.Languages.ContainsKey(LanguageManager.CurrentLang))
                LanguageManager.CurrentLang = "Tiếng Việt";

            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];

            // 2. Hàm lấy từ an toàn
            string Get(string key) => lang.ContainsKey(key) ? lang[key] : $"[{key}]";

            // 3. Gán text cho Label/Button
            lbCauHinh.Text = Get("NhatKy");
            lbLocTheoNgay.Text = Get("LocTheoNgay");
            lbLocNguoiDung.Text = Get("LocTheoUser");

            // Gán thêm cho 2 nút bấm (nếu file design bạn có 2 nút này)
            if (btnApDung != null) btnApDung.Text = Get("ApDung");
            if (btnDatLai != null) btnDatLai.Text = Get("DatLai");

            // 4. Dịch tiêu đề cột DataGridView (Kiểm tra null để an toàn)
            if (dataGridView_NhatKy.Columns["ThoiGian"] != null)
                dataGridView_NhatKy.Columns["ThoiGian"].HeaderText = Get("ThoiGian");

            if (dataGridView_NhatKy.Columns["NguoiThucHien"] != null)
                dataGridView_NhatKy.Columns["NguoiThucHien"].HeaderText = Get("NguoiThucHien");

            if (dataGridView_NhatKy.Columns["DoiTuong"] != null)
                dataGridView_NhatKy.Columns["DoiTuong"].HeaderText = Get("DoiTuong");

            if (dataGridView_NhatKy.Columns["HanhDong"] != null)
                dataGridView_NhatKy.Columns["HanhDong"].HeaderText = Get("HanhDong");

            if (dataGridView_NhatKy.Columns["KetQua"] != null)
                dataGridView_NhatKy.Columns["KetQua"].HeaderText = Get("KetQua");
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            ThucHienLoc();
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            // Xóa trắng các ô nhập liệu
            textBox_LocNguoiDung.Clear();

            // Đưa ComboBox về trạng thái ban đầu (Tất cả)
            if (comboBox_LocTheoNgay.Items.Count > 0)
            {
                comboBox_LocTheoNgay.SelectedIndex = comboBox_LocTheoNgay.Items.IndexOf("Tất cả");
            }

            // Tải lại toàn bộ dữ liệu
            LoadNhatKy();
        }
    }
}
