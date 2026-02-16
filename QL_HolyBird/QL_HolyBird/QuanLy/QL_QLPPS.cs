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

namespace QL_HolyBird
{
    public partial class QL_QLPPS : UserControl
    {
        ServiceDAL db = new ServiceDAL();
        bool isAdding = false;
        public QL_QLPPS()
        {
            InitializeComponent();
            dat_QL_QLPPS.AutoGenerateColumns = false;
            this.Load += QL_QLPPS_Load;
        }
        private void QL_QLPPS_Load(object sender, EventArgs e) // Nhớ gán event này trong Designer
        {
            // Nạp danh sách lựa chọn
            cbBox_QL_DemoGiaiQuyet.Items.Clear();
            cbBox_QL_DemoGiaiQuyet.Items.Add("Demo TH2"); // Update thành công (gây Lost Update/Unrepeatable)
            cbBox_QL_DemoGiaiQuyet.Items.Add("Demo TH8"); // Update sai -> Rollback (gây Dirty Read)
            cbBox_QL_DemoGiaiQuyet.SelectedIndex = 0;

            LoadData();
        }

        private void LoadData()
        {
            string sql = "SELECT MaPPS, TenPPS, GiaPhi FROM PHIPHATSINH";
            DataTable dt = db.GetDataTable(sql);

            dat_QL_QLPPS.DataSource = dt;
        }

        private void ResetForm()
        {
            txt_QL_QLPPS_MPPS.Clear();
            txt_QL_QLPPS_TenPPS.Clear();
            txt_QL_QLPPS_DG.Clear();
            txt_QL_QLPPS_MPPS.ReadOnly = false;
            txt_QL_QLPPS_MPPS.Focus();
        }

        private void btn_QL_PPS_Them_Click(object sender, EventArgs e)
        {

        }

        private void btn_QL_QLP_Them_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ResetForm();
        }

        private void btn_QL_QLP_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_QL_QLPPS_MPPS.Text))
            {
                MessageBox.Show("Vui lòng chọn loại phí cần sửa từ danh sách!");
                return;
            }
            isAdding = false;
            txt_QL_QLPPS_MPPS.ReadOnly = true; // Khóa mã phí khi sửa
        }

        private void btn_QL_QLP_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_QL_QLPPS_MPPS.Text)) return;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại phí này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] p = { new SqlParameter("@Ma", txt_QL_QLPPS_MPPS.Text) };
                    if (db.ExecuteNonQuery("DELETE FROM PHIPHATSINH WHERE MaPPS = @Ma", p))
                    {
                        MessageBox.Show("Xóa phí phát sinh thành công!");
                        LoadData();
                        ResetForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa do phí này đang được sử dụng trong các hóa đơn!");
                }
            }
        }

        private void txt_QL_QLPPS_MPPS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_QL_QLPPS_TenPPS_TextChanged(object sender, EventArgs e)
        {

        }

        private void dat_QL_QLPPS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dat_QL_PPS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dat_QL_QLPPS.Rows[e.RowIndex];

                // Sử dụng tên (Name) MaPPS bạn vừa đặt ở Bước 1
                txt_QL_QLPPS_MPPS.Text = row.Cells["MaPPS"].Value.ToString();
                txt_QL_QLPPS_TenPPS.Text = row.Cells["TenPPS"].Value.ToString();
                txt_QL_QLPPS_DG.Text = row.Cells["GiaPhi"].Value.ToString();
            }
        }

        private void btn_QL_QLPPS_Luu_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu đầu vào
            string maPPS = txt_QL_QLPPS_MPPS.Text.Trim();
            string strGia = txt_QL_QLPPS_DG.Text.Trim();

            if (string.IsNullOrEmpty(maPPS) || string.IsNullOrEmpty(strGia))
            {
                MessageBox.Show("Mã phí và giá phí không được để trống!");
                return;
            }

            // Parse giá tiền (cho phép số âm để test TH8)
            if (!decimal.TryParse(strGia, out decimal giaMoi))
            {
                MessageBox.Show("Giá tiền không hợp lệ!");
                return;
            }

            // -------------------------------------------------------------
            // 2. KIỂM TRA CHẾ ĐỘ DEMO
            // -------------------------------------------------------------
            if (checkBox_QL_DM.Checked)
            {
                string kichBan = cbBox_QL_DemoGiaiQuyet.Text;

                // BẮT ĐẦU CHẠY DEMO: KHÓA GIAO DIỆN + HIỆN CHUỘT LOADING
                this.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    // === KỊCH BẢN TH2: CẬP NHẬT GIÁ (COMMIT THÀNH CÔNG) ===
                    // Dùng để test Lost Update / Unrepeatable Read
                    if (kichBan == "Demo TH2")
                    {
                        MessageBox.Show($"DEMO TH2: Bắt đầu cập nhật giá {giaMoi:N0}.\nHệ thống sẽ treo 15s rồi COMMIT.", "Bắt đầu Demo");

                        SqlParameter[] p = {
                    new SqlParameter("@MaPPS", maPPS),
                    new SqlParameter("@GiaPhiMoi", giaMoi)
                };

                        // Gọi Procedure TH2 (Update + Wait + Commit)
                        // App sẽ bị đơ ở dòng này trong 15s
                        if (db.ExecuteSPNonQuery("sp_TH2_T2_CapNhatGiaPPS", p))
                        {
                            MessageBox.Show("Cập nhật giá thành công (TH2)!", "Hoàn tất");
                        }
                    }

                    // === KỊCH BẢN TH8: DIRTY READ (ROLLBACK NẾU ÂM) ===
                    // Dùng để test Dirty Read
                    else if (kichBan == "Demo TH8")
                    {
                        MessageBox.Show($"DEMO TH8: Bắt đầu cập nhật giá {giaMoi:N0}.\n(Nếu giá ÂM -> Sẽ Rollback sau 15s).", "Bắt đầu Demo");

                        SqlParameter[] p = {
                    new SqlParameter("@MaPPS", maPPS),
                    new SqlParameter("@GiaPhiMoi", giaMoi)
                };

                        // Gọi Procedure TH8 (Update + Wait + Rollback nếu âm)
                        // App sẽ bị đơ ở dòng này trong 15s
                        int result = db.ExecuteStoredProcedureWithReturnValue("sp_TH8_T2_CapNhatGiaPPS_TranhChap", p);

                        if (result == 2)
                        {
                            MessageBox.Show("Hệ thống: Giá trị update < 0.\nĐã tự động ROLLBACK (Khôi phục giá cũ).", "Thông báo Rollback");
                        }
                        else if (result == 1)
                        {
                            MessageBox.Show("Update thành công (Giá dương)!", "Thông báo");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Bắt lỗi SQL (Ví dụ: Constraint Check Violation)
                    MessageBox.Show("LỖI SQL: " + ex.Message, "Lỗi");
                }
                finally
                {
                    // DÙ THÀNH CÔNG HAY LỖI: Luôn mở khóa giao diện lại
                    this.Enabled = true;
                    Cursor.Current = Cursors.Default;
                    LoadData(); // Load lại dữ liệu mới nhất
                }

                return; // Kết thúc xử lý Demo, không chạy xuống phần lưu thường
            }

            // -------------------------------------------------------------
            // 3. LƯU BÌNH THƯỜNG (KHI KHÔNG TÍCH DEMO)
            // -------------------------------------------------------------
            try
            {
                using (SqlConnection con = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_UpsertPPS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaPPS", maPPS);
                    cmd.Parameters.AddWithValue("@TenPPS", txt_QL_QLPPS_TenPPS.Text.Trim());
                    cmd.Parameters.AddWithValue("@GiaPhi", giaMoi);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lưu thông tin phí phát sinh thành công!");
                    LoadData();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void checkBox_QL_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_QL_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
