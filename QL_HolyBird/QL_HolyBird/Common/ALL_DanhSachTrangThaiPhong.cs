using QL_HolyBird.QuanTriVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HolyBird.Common
{
    public partial class ALL_DanhSachTrangThaiPhong: UserControl
    {
        ServiceDAL logic = new ServiceDAL();

        public ALL_DanhSachTrangThaiPhong()
        {
            InitializeComponent();
            SetupFilterData();
            this.Load += new System.EventHandler(ALL_DanhSachTrangThaiPhong_Load);
        }

        private void ALL_DanhSachTrangThaiPhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SetupFilterData()
        {
            // Cập nhật đúng các hạng phòng trong database
            boxLoaiPhong.Items.Clear();
            boxLoaiPhong.Items.AddRange(new string[] { "Thường", "Trung bình", "Sang", "Rất sang", "VIP" });

            // Cập nhật đúng trạng thái phòng
            boxTrangThai.Items.Clear();
            boxTrangThai.Items.AddRange(new string[] { "Đang trống", "Đang có khách", "Đang đặt trước" });

            boxTang.Items.Clear();
            boxTang.Items.AddRange(Enumerable.Range(1, 13).Select(i => i.ToString()).ToArray());

            boxHinhThuc.Items.Clear();
            boxHinhThuc.Items.AddRange(new string[] { "1 giường đơn", "1 giường đôi", "2 giường đơn", "2 giường đôi" });

            boxMucGia.Items.Clear();
            boxMucGia.Items.AddRange(new string[] { "Dưới 500k", "500k - 1tr", "Trên 1tr" });

            ResetFilters();
        }

        private void ResetFilters()
        {
            boxLoaiPhong.SelectedIndex = -1;
            boxTrangThai.SelectedIndex = -1;
            boxTang.SelectedIndex = -1;
            boxHinhThuc.SelectedIndex = -1;
            boxMucGia.SelectedIndex = -1;
        }

        private void LoadData()
        {
            try
            {
                // 1. Lấy giá trị từ các box
                string loai = boxLoaiPhong.Text;
                string trangThai = boxTrangThai.Text;
                string gia = boxMucGia.Text;
                string tang = boxTang.Text;
                string hinhThuc = boxHinhThuc.Text;
                string timKiem = textTimKiem.Text.Trim();

                // 2. Gọi logic
                DataTable dt = logic.LayDanhSachPhong(loai, trangThai, gia, tang, hinhThuc, timKiem);

                // 3. Hiển thị (Dùng SuspendLayout để tránh giật lag khi load lại)
                dataGridView_NhatKy.SuspendLayout();
                dataGridView_NhatKy.DataSource = null; // Clear nguồn cũ
                dataGridView_NhatKy.DataSource = dt;

                // Chỉ gán lại nếu AutoGenerateColumns = false
                if (dataGridView_NhatKy.AutoGenerateColumns == false)
                {
                    dataGridView_NhatKy.Columns["MaPhong"].DataPropertyName = "MaPhong";
                    dataGridView_NhatKy.Columns["LoaiPhong"].DataPropertyName = "LoaiPhong";
                    dataGridView_NhatKy.Columns["HinhThuc"].DataPropertyName = "HinhThuc";
                    dataGridView_NhatKy.Columns["Tang"].DataPropertyName = "Tang";
                    dataGridView_NhatKy.Columns["GiaTien"].DataPropertyName = "GiaTien";
                    dataGridView_NhatKy.Columns["TrangThai"].DataPropertyName = "TrangThai";
                }
                dataGridView_NhatKy.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            string loaiPhong = boxLoaiPhong.Text; // Lấy giá trị combo box Loại phòng

            // -----------------------------------------------------------
            // KỊCH BẢN TH6: XEM GIÁ VIP (Unrepeatable Read)
            // Điều kiện: Chọn loại phòng VIP + Tích Demo
            // -----------------------------------------------------------
            if (checkBox_TD_DM.Checked && loaiPhong == "VIP")
            {
                int isFix = (cbBox_TD_DemoGiaiQuyet.Text == "Giải quyết") ? 1 : 0;

                // Gọi Procedure T1 (Xem 2 lần)
                SqlParameter[] p = {
            new SqlParameter("@MaLoaiPhong", "VIP"), // Giả sử mã trong DB là 'VIP'
            new SqlParameter("@IsFix", isFix)
        };

                MessageBox.Show($"DEMO T1 (TH6): Đang xem giá phòng VIP lần 1. Hệ thống sẽ giữ giao dịch trong 10s để chờ Quản lý đổi giá...", "Thông báo Demo");

                // Dùng hàm DataSet để lấy 2 bảng kết quả (Lần 1 và Lần 2)
                DataSet ds = logic.ExecuteStoredProcedure_DataSet("sp_TH6_T1_XemGiaPhong_TranhChap", p);

                if (ds.Tables.Count >= 2 && ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    decimal giaLano1 = Convert.ToDecimal(ds.Tables[0].Rows[0]["MucGia"]); // Cột MucGia
                    decimal giaLano2 = Convert.ToDecimal(ds.Tables[1].Rows[0]["MucGia"]);

                    string msg = $"Kết quả đọc dữ liệu:\n- Lần 1: {giaLano1:N0} VNĐ\n- Lần 2: {giaLano2:N0} VNĐ";

                    if (giaLano1 != giaLano2)
                        MessageBox.Show(msg + "\n\n=> LỖI UNREPEATABLE READ: Giá đã bị thay đổi trong quá trình xem!", "Kết quả Demo");
                    else
                        MessageBox.Show(msg + "\n\n=> THÀNH CÔNG: Dữ liệu nhất quán (Repeatable Read).", "Kết quả Demo");

                    // Load lại lưới với dữ liệu mới nhất
                    dataGridView_NhatKy.DataSource = null;
                    LoadData();
                }
                return; // Kết thúc demo, không chạy code lọc thường
            }

            string trangThai = boxTrangThai.Text;

            if (checkBox_TD_DM.Checked && trangThai == "Đang trống")
            {
                int isFix = (cbBox_TD_DemoGiaiQuyet.Text == "Giải quyết") ? 1 : 0;
                SqlParameter[] p = {
            new SqlParameter("@TrangThai", trangThai),
            new SqlParameter("@IsFix", isFix)
        };

                MessageBox.Show("Bắt đầu Demo T1. Hệ thống sẽ đọc danh sách phòng trống lần 1 và dừng 15s...", "Thông báo");

                // Sử dụng hàm DataSet để nhận 2 bảng kết quả
                DataSet ds = logic.ExecuteStoredProcedure_DataSet("sp_TH4_T1_XemDSPhongTrong_TranhChap", p);

                if (ds.Tables.Count >= 2)
                {
                    int count1 = ds.Tables[0].Rows.Count;
                    int count2 = ds.Tables[1].Rows.Count;

                    string msg = $"Lần 1 thấy: {count1} phòng trống.\nLần 2 thấy: {count2} phòng trống.";
                    if (count1 != count2)
                        MessageBox.Show(msg + "\n=> LỖI PHANTOM: Danh sách phòng trống đã thay đổi!", "Kết quả");
                    else
                        MessageBox.Show(msg + "\n=> THÀNH CÔNG: Dữ liệu nhất quán.", "Kết quả");

                    dataGridView_NhatKy.DataSource = ds.Tables[1]; // Hiển thị kết quả lần 2
                }
                return;
            }
            LoadData(); // Chạy bình thường
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            // Xóa sạch các lựa chọn lọc
            boxLoaiPhong.SelectedIndex = -1;
            boxTrangThai.SelectedIndex = -1;
            boxTang.SelectedIndex = -1;
            boxHinhThuc.SelectedIndex = -1;
            boxMucGia.SelectedIndex = -1;
            textTimKiem.Clear();
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Bổ sung: Tìm kiếm ngay khi nhấn Enter trong ô TextBox
        private void textTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadData();
            }
        }

        private void textTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void boxTang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void boxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxMucGia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxHinhThuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_NhatKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox_TD_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TD_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
