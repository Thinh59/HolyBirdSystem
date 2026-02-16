using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace QL_HolyBird
{
    public partial class Usc_TD_QuanLyGiaoDich : UserControl
    {
        ServiceDAL dal = new ServiceDAL();

        public Usc_TD_QuanLyGiaoDich()
        {
            InitializeComponent();
            this.Load += Usc_TD_QuanLyGiaoDich_Load;
        }

        // Sự kiện Load dữ liệu (Bạn nên gọi hàm này khi người dùng chọn mã đoàn hoặc khi UserControl hiển thị)
        private void Usc_TD_QuanLyGiaoDich_Load(object sender, EventArgs e)
        {
            // 1. Lấy Mã đoàn từ Session
            if (!string.IsNullOrEmpty(Session.MaDoan))
            {
                lbl_TDD_MaDoan.Text = Session.MaDoan;
                // 2. Gọi hàm load dữ liệu chi tiết và các label thống kê
                LoadData(Session.MaDoan);
            }
        }

        public void LoadData(string maDoan)
        {
            try
            {
                // ---------------------------------------------------------
                // PHẦN DEMO TRANH CHẤP (TH7 - UNREPEATABLE READ)
                // ---------------------------------------------------------
                if (checkBox_TT8_DM.Checked) // Giả sử bạn dùng checkbox này
                {
                    int isFix = (cbBox_TT8_DemoGiaiQuyet.Text == "Giải quyết") ? 1 : 0;
                    SqlParameter[] p = {
                new SqlParameter("@MaDoan", maDoan),
                new SqlParameter("@IsFix", isFix)
            };

                    MessageBox.Show($"DEMO T1 (TH7): Đang xem thông tin đoàn {maDoan} lần 1. Hệ thống sẽ giữ giao dịch trong 15s để chờ Tiếp tân cập nhật số người...", "Thông báo Demo");

                    // Dùng hàm DataSet để nhận 2 bảng kết quả (Lần 1 và Lần 2)
                    DataSet ds = dal.ExecuteStoredProcedure_DataSet("sp_TH7_T1_XemGiaoDich_TranhChap", p);

                    if (ds.Tables.Count >= 2 && ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        int soNguoi1 = Convert.ToInt32(ds.Tables[0].Rows[0]["SoNguoi"]);
                        int soNguoi2 = Convert.ToInt32(ds.Tables[1].Rows[0]["SoNguoi"]);

                        string msg = $"Kết quả đọc dữ liệu:\n- Lần 1: {soNguoi1} người\n- Lần 2: {soNguoi2} người";

                        if (soNguoi1 != soNguoi2)
                            MessageBox.Show(msg + "\n\n=> LỖI UNREPEATABLE READ: Số lượng người đã bị thay đổi trong quá trình xem!", "Kết quả Demo");
                        else
                            MessageBox.Show(msg + "\n\n=> THÀNH CÔNG: Dữ liệu nhất quán (Repeatable Read).", "Kết quả Demo");

                        // Cập nhật lại UI với dữ liệu mới nhất
                        lbl_TD_SoNguoi.Text = soNguoi2.ToString();
                    }
                    return; // Kết thúc demo
                }
                // --- PHẦN 1: Load số lượng ĐĂNG KÝ từ GIAODICH ---
                DataTable dtGoc = dal.TD_GetThongTinGiaoDich(maDoan);
                if (dtGoc != null && dtGoc.Rows.Count > 0)
                {
                    // Đây là số lượng tối đa đoàn được phép có
                    lbl_TD_SoPhong.Text = dtGoc.Rows[0]["SoPhong"].ToString();
                    lbl_TD_SoNguoi.Text = dtGoc.Rows[0]["SoNguoi"].ToString();
                }

                // --- PHẦN 2: Load danh sách chi tiết hiện tại vào lưới ---
                DataTable dtChiTiet = dal.TD_GetChiTietGiaoDich(maDoan);
                dgv_TD_DSCTGD.DataSource = dtChiTiet;

                // Đảm bảo cột checkbox có thể thao tác
                if (dgv_TD_DSCTGD.Columns["Chon"] != null)
                    dgv_TD_DSCTGD.Columns["Chon"].ReadOnly = false;

                // Nếu bạn muốn hiển thị thêm một Label phụ: "Đã đặt: X/Y phòng" 
                // thì có thể tính: dtChiTiet.Rows.Count
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void btn_TD_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_TD_DSCTGD.CurrentRow == null) return;

            // Đánh dấu xóa tạm trên giao diện (Visual feedback)
            foreach (DataGridViewRow row in dgv_TD_DSCTGD.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void btn_TD_XacNhan_Click(object sender, EventArgs e)
        {
            bool hasChange = false;
            foreach (DataGridViewRow row in dgv_TD_DSCTGD.Rows)
            {
                // Kiểm tra các dòng được tích chọn để hủy
                if (Convert.ToBoolean(row.Cells["Chon"].Value) == true)
                {
                    string maCTGD = row.Cells["MaCTGD"].Value.ToString();
                    if (dal.TD_HuyChiTietGiaoDich(maCTGD))
                    {
                        hasChange = true;
                    }
                }
            }

            if (hasChange)
            {
                MessageBox.Show("Đã cập nhật trạng thái 'Đã hủy đặt trước' cho các phòng được chọn.", "Thành công");
                // Load lại dữ liệu để ẩn những dòng đã hủy
                LoadData(lbl_TDD_MaDoan.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một chi tiết giao dịch để xử lý!", "Thông báo");
            }
        }

        private void btn_TD_Huy_Click(object sender, EventArgs e)
        {
            // Reset lại bảng về trạng thái cũ
            LoadData(lbl_TDD_MaDoan.Text);
        }

        private void lbl_TDD_MaDoan_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TD_SoNguoi_Click(object sender, EventArgs e)
        {

        }

        private void lbl_TD_SoPhong_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_TT8_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TT8_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_TD_Xem_Click(object sender, EventArgs e)
        {
            // Lấy mã đoàn đang hiển thị
            string maDoan = lbl_TDD_MaDoan.Text;
            if (string.IsNullOrEmpty(maDoan)) return;

            try
            {
                // ---------------------------------------------------------
                // PHẦN DEMO TRANH CHẤP (TH7 - UNREPEATABLE READ)
                // ---------------------------------------------------------
                if (checkBox_TT8_DM.Checked)
                {
                    int isFix = (cbBox_TT8_DemoGiaiQuyet.Text == "Giải quyết") ? 1 : 0;
                    SqlParameter[] p = {
                new SqlParameter("@MaDoan", maDoan),
                new SqlParameter("@IsFix", isFix)
            };

                    MessageBox.Show($"DEMO T1 (TH7): Đang xem thông tin đoàn {maDoan} lần 1.\nHệ thống sẽ giữ giao dịch và chờ 15s...", "Thông báo Demo");

                    // Gọi Procedure T1 (Xem 2 lần)
                    // Lưu ý: Hàm này sẽ làm treo UI 15s (đúng kịch bản demo)
                    DataSet ds = dal.ExecuteStoredProcedure_DataSet("sp_TH7_T1_XemGiaoDich_TranhChap", p);

                    if (ds != null && ds.Tables.Count >= 2 && ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        int soNguoi1 = Convert.ToInt32(ds.Tables[0].Rows[0]["SoNguoi"]);
                        int soNguoi2 = Convert.ToInt32(ds.Tables[1].Rows[0]["SoNguoi"]);

                        string msg = $"Kết quả đọc dữ liệu:\n- Lần 1: {soNguoi1} người\n- Lần 2: {soNguoi2} người";

                        if (soNguoi1 != soNguoi2)
                            MessageBox.Show(msg + "\n\n=> LỖI UNREPEATABLE READ: Số lượng người đã bị thay đổi trong quá trình xem!", "Kết quả Demo");
                        else
                            MessageBox.Show(msg + "\n\n=> THÀNH CÔNG: Dữ liệu nhất quán (Repeatable Read).", "Kết quả Demo");

                        // Cập nhật lại giao diện với số liệu mới nhất (Lần 2)
                        lbl_TD_SoNguoi.Text = soNguoi2.ToString();
                    }
                    return; // Xong demo thì thoát, không chạy load thường
                }

                // --- CHẾ ĐỘ THƯỜNG (Nếu không tích Demo) ---
                // Gọi lại hàm LoadData cũ để refresh dữ liệu
                LoadData(maDoan);
                MessageBox.Show("Đã làm mới dữ liệu.", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}