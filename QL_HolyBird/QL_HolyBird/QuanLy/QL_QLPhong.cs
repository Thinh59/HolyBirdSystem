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
    public partial class QL_QLPhong : UserControl
    {

        ServiceDAL db = new ServiceDAL();
        bool isAdding = false;
        public QL_QLPhong()
        {
            InitializeComponent();
            LoadData();
            dat_QL_QLP.AutoGenerateColumns = false;
        }

        void LoadData()
        {
            string sql = @"SELECT P.MaPhong, P.MaLoaiPhong, P.Tang, LP.Hang, LP.HinhThuc, P.TrangThai, LP.MucGia 
                       FROM PHONG P INNER JOIN LOAIPHONG LP ON P.MaLoaiPhong = LP.MaLoaiPhong";
            dat_QL_QLP.DataSource = db.GetDataTable(sql);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ResetForm()
        {
            txt_QL_QLP_MP.Clear();
            txt_QL_QLP_MLP.Clear();
            txt_QL_QLP_Tang.Clear();
            txt_QL_QLP_Gia.Clear();
            combo_QL_QLP_Hang.SelectedIndex = -1;
            combo_QL_QLP_HT.SelectedIndex = -1;
            combo_QL_QLP_TT.SelectedIndex = -1;
            txt_QL_QLP_MP.ReadOnly = false;
            txt_QL_QLP_MP.Focus();
        }

        private void dat_QL_QLP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dat_QL_QLP.Rows[e.RowIndex];

                txt_QL_QLP_MP.Text = row.Cells["MaPhong"].Value.ToString();
                txt_QL_QLP_MLP.Text = row.Cells["MaLoaiPhong"].Value.ToString();
                txt_QL_QLP_Tang.Text = row.Cells["Tang"].Value.ToString();
                combo_QL_QLP_Hang.Text = row.Cells["Hang"].Value.ToString();
                combo_QL_QLP_HT.Text = row.Cells["HinhThuc"].Value.ToString();
                combo_QL_QLP_TT.Text = row.Cells["TrangThai"].Value.ToString();
                txt_QL_QLP_Gia.Text = row.Cells["MucGia"].Value.ToString();

                foreach (DataGridViewRow r in dat_QL_QLP.Rows)
                {
                    r.Cells[0].Value = false;
                }
                row.Cells[0].Value = true; 
            }
        }

        private void dat_QL_QLP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_QL_QLP_MP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_QL_QLP_MLP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_QL_QLP_Tang_TextChanged(object sender, EventArgs e)
        {

        }

        private void combo_QL_QLP_Hang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_QL_QLP_TT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_QL_QLP_HT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_QL_QLP_Gia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_QL_QLP_Them_Click(object sender, EventArgs e)
        {
            isAdding = true;
            txt_QL_QLP_MP.Clear();
            txt_QL_QLP_MLP.Clear();
            txt_QL_QLP_Tang.Clear();
            txt_QL_QLP_Gia.Clear();
            combo_QL_QLP_Hang.SelectedIndex = -1;
            combo_QL_QLP_HT.SelectedIndex = -1;
            combo_QL_QLP_TT.SelectedIndex = -1;
            txt_QL_QLP_MP.Focus(); 
        }

        private void btn_QL_QLP_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_QL_QLP_MP.Text))
            {
                MessageBox.Show("Vui lòng chọn một phòng từ danh sách để sửa!");
                return;
            }
            isAdding = false;
            txt_QL_QLP_MP.ReadOnly = true; // Không cho sửa khóa chính khi đang ở chế độ Sửa
            txt_QL_QLP_MP.Enabled = false;
            MessageBox.Show("Hãy chỉnh sửa thông tin bên dưới và nhấn LƯU.");
        }

        private void btn_QL_QLP_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_QL_QLP_MP.Text)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "DELETE FROM PHONG WHERE MaPhong = @MaP";
                System.Data.SqlClient.SqlParameter[] p = { new System.Data.SqlClient.SqlParameter("@MaP", txt_QL_QLP_MP.Text) };

                if (db.ExecuteNonQuery(sql, p))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
            }
        }

        private void btn_QL_QLP_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                // LẤY DỮ LIỆU
                string maPhong = txt_QL_QLP_MP.Text.Trim();
                string maLP = txt_QL_QLP_MLP.Text.Trim();
                string hang = combo_QL_QLP_Hang.Text;
                string hinhThuc = combo_QL_QLP_HT.Text;
                string trangThai = combo_QL_QLP_TT.Text;

                if (string.IsNullOrEmpty(maPhong) || string.IsNullOrEmpty(maLP)) { MessageBox.Show("Thiếu mã!"); return; }
                if (!int.TryParse(txt_QL_QLP_Tang.Text, out int tang)) return;
                if (!decimal.TryParse(txt_QL_QLP_Gia.Text, out decimal mucGia)) return;

                // ---------------------------------------------------------
                // XỬ LÝ DEMO
                // ---------------------------------------------------------
                if (checkBox_TD_DM.Checked)
                {
                    string kịchBan = cbBox_TD_DemoGiaiQuyet.Text;
                    int result = 0;
                    SqlParameter[] p;

                    // --- A. LOST UPDATE ---
                    if (kịchBan.Contains("TH1"))
                    {
                        p = new SqlParameter[] { new SqlParameter("@MaLoaiPhong", maLP), new SqlParameter("@MucGia", mucGia) };
                        if (kịchBan.Contains("Giải quyết"))
                        {
                            MessageBox.Show("FIX TH1: Repeatable Read.", "Giải quyết");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_TH1_GiaiQuyet_LostUpdate", p);
                        }
                        else if (kịchBan.Contains("T1"))
                        {
                            MessageBox.Show("TH1 (T1): Treo 10s...", "Demo");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_TH1_T1_CapNhatGiaLoaiPhong", p);
                        }
                        else
                        {
                            MessageBox.Show("TH1 (T2): Chen ngang...", "Demo");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_TH1_T2_CapNhatGiaLoaiPhong", p);
                        }
                    }
                    else if (kịchBan.Contains("TH5"))
                    {
                        p = new SqlParameter[] { new SqlParameter("@MaPhong", maPhong), new SqlParameter("@TrangThai", trangThai) };
                        if (kịchBan.Contains("Giải quyết"))
                        {
                            MessageBox.Show("FIX TH5: Dùng XLOCK.", "Giải quyết");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_TH5_Fix_UpdateTrangThai", p);
                        }
                        else
                        {
                            MessageBox.Show("TH5 (T1): Treo 10s...", "Demo");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_TH5_T1_UpdateTrangThai", p);
                        }
                    }

                    // --- B. DEADLOCK CYCLIC ---
                    else if (kịchBan.Contains("Cyclic"))
                    {
                        p = new SqlParameter[] { new SqlParameter("@MaPhong", maPhong), new SqlParameter("@MaLoaiPhong", maLP), new SqlParameter("@MucGia", mucGia), new SqlParameter("@TrangThai", trangThai) };

                        if (kịchBan.Contains("Fix"))
                        {
                            MessageBox.Show("FIX CYCLIC: Tuân thủ thứ tự.", "Giải quyết");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_Deadlock_Cyclic_Fix", p);
                        }
                        else if (kịchBan.Contains("Máy 1"))
                        {
                            MessageBox.Show("CYCLIC T1: Khóa PHÒNG -> Chờ LP.", "Demo");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_Deadlock_Cyclic_T1", p);
                        }
                        else
                        {
                            MessageBox.Show("CYCLIC T2: Khóa LP -> Chờ PHÒNG.", "Demo");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_Deadlock_Cyclic_T2", p);
                        }
                    }

                    // --- C. DEADLOCK CONVERSION ---

                    // C.1 FIX BẰNG UPDLOCK (Cái mới thêm)
                    else if (kịchBan.Contains("UPDLOCK"))
                    {
                        p = new SqlParameter[] { new SqlParameter("@MaLoaiPhong", maLP), new SqlParameter("@MucGia", mucGia) };

                        // THÔNG BÁO TRƯỚC KHI CHẠY
                        
                        // GỌI TRỰC TIẾP KHÔNG QUA ServiceDAL ĐỂ SET TIMEOUT
                        using (SqlConnection con = db.GetConnection())
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("sp_Deadlock_Conversion_Fix", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddRange(p);

                            // QUAN TRỌNG: Cho phép chờ tới 120 giây. 
                            // Nếu máy 2 chờ quá 30s mà code cũ ngắt -> Nó sẽ báo hủy.
                            cmd.CommandTimeout = 60;

                            try
                            {
                                // MÁY 2 SẼ ĐỨNG YÊN Ở DÒNG NÀY (BLOCKED)
                                // Nó không chết, nó chỉ đang chờ Máy 1.
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Giao dịch THÀNH CÔNG! (Đã xếp hàng xong)", "Kết quả");
                                LoadData();
                            }
                            catch (SqlException ex)
                            {
                                // NẾU VẪN LỖI, NÓ SẼ HIỆN RÕ LÝ DO TẠI ĐÂY
                                if (ex.Number == 1205)
                                    MessageBox.Show("LỖI DEADLOCK (Vô lý với UPDLOCK!)", "Lỗi");
                                else if (ex.Number == -2)
                                    MessageBox.Show("LỖI TIMEOUT (Chờ quá lâu)!", "Lỗi");
                                else
                                    MessageBox.Show("LỖI SQL: " + ex.Message, "Chi tiết lỗi");
                            }
                        }
                        return; // Dừng
                    }

                    // C.2 CONVERSION THƯỜNG (Gây lỗi)
                    else if (kịchBan.Contains("Conversion (Gây lỗi"))
                    {
                        p = new SqlParameter[] { new SqlParameter("@MaLoaiPhong", maLP), new SqlParameter("@MucGia", mucGia) };
                        MessageBox.Show("CONVERSION THƯỜNG: Đọc -> Chờ Ghi (Treo 10s).", "Demo");
                        using (SqlConnection con = db.GetConnection())
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("sp_Deadlock_Conversion", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddRange(p);

                            cmd.CommandTimeout = 60;

                            try
                            {
                                // ExecuteScalar vì SP trả về SELECT 1
                                object res = cmd.ExecuteScalar();
                                result = (res != null) ? Convert.ToInt32(res) : 0;
                            }
                            catch (SqlException ex)
                            {
                                // Nếu là nạn nhân (Victim) thì sẽ nhảy vào đây
                                if (ex.Number == 1205)
                                {
                                    MessageBox.Show("Lỗi Deadlock (Máy này là nạn nhân)!", "Deadlock Victim");
                                    return;
                                }
                                throw; // Lỗi khác thì ném tiếp
                            }
                        }
                    }

                    // C.3 WOUND-WAIT
                    else if (kịchBan.Contains("Wound-Wait"))
                    {
                        p = new SqlParameter[] { new SqlParameter("@MaLoaiPhong", maLP), new SqlParameter("@MucGia", mucGia) };

                        if (kịchBan.Contains("High"))
                        {
                            MessageBox.Show("MÁY 1 (SẾP): Vào xử lý... (Sẽ giết máy kia).", "Wound-Wait");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_Deadlock_Conversion_WoundWait_High", p);
                            MessageBox.Show("MÁY 1 (SẾP): THÀNH CÔNG!", "Winner");
                        }
                        else
                        {
                            MessageBox.Show("MÁY 2 (LÍNH): Vào xử lý... (Sẽ bị giết).", "Wound-Wait");
                            result = db.ExecuteStoredProcedureWithReturnValue("sp_Deadlock_Conversion_WoundWait_Low", p);
                            MessageBox.Show("MÁY 2: May mắn sống sót.", "Lucky");
                        }
                        LoadData();
                        return;
                    }

                    // --- KẾT QUẢ CHUNG ---
                    if (result == 1) { MessageBox.Show("Giao dịch THÀNH CÔNG!", "Thông báo"); LoadData(); }
                    else if (result == -1) { MessageBox.Show("Giao dịch THẤT BẠI (Bị Wound)!", "Warning"); }
                    else { MessageBox.Show("Giao dịch bị HỦY (Rollback/Deadlock)!", "Stop"); }

                    return;
                }

                // 3. LƯU BÌNH THƯỜNG (Giữ nguyên code cũ của bạn)
                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();
                    // ... (Code lưu bình thường giữ nguyên như cũ) ...
                    string sql = @"
                IF NOT EXISTS (SELECT 1 FROM LOAIPHONG WHERE MaLoaiPhong = @MaLP)
                    INSERT INTO LOAIPHONG (MaLoaiPhong, HinhThuc, Hang, MucGia) VALUES (@MaLP, @HT, @H, @G);
                ELSE
                    UPDATE LOAIPHONG SET HinhThuc=@HT, Hang=@H, MucGia=@G WHERE MaLoaiPhong=@MaLP;

                IF NOT EXISTS (SELECT 1 FROM PHONG WHERE MaPhong = @MaP)
                    INSERT INTO PHONG (MaPhong, Tang, MaLoaiPhong, TrangThai) VALUES (@MaP, @T, @MaLP, @TT);
                ELSE
                    UPDATE PHONG SET Tang=@T, MaLoaiPhong=@MaLP, TrangThai=@TT WHERE MaPhong=@MaP;";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaP", maPhong);
                    cmd.Parameters.AddWithValue("@MaLP", maLP);
                    cmd.Parameters.AddWithValue("@T", tang);
                    cmd.Parameters.AddWithValue("@H", hang);
                    cmd.Parameters.AddWithValue("@HT", hinhThuc);
                    cmd.Parameters.AddWithValue("@TT", trangThai);
                    cmd.Parameters.AddWithValue("@G", mucGia);

                    cmd.CommandTimeout = 120; // Tăng timeout lên 120s để test UPDLOCK
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Lưu thành công!");
                    LoadData();
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlEx)
                {
                    if (sqlEx.Number == 1205)
                    {
                        MessageBox.Show("LỖI DEADLOCK! (Giao dịch bị hủy).", "Deadlock Victim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void checkBox_TD_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TD_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QL_QLPhong_Load(object sender, EventArgs e)
        {
            cbBox_TD_DemoGiaiQuyet.Items.Clear();
            cbBox_TD_DemoGiaiQuyet.Items.Add("Demo TH1 (T1 - Gây lỗi Giá)");
            cbBox_TD_DemoGiaiQuyet.Items.Add("Demo TH1 (T2 - Chen ngang)");
            cbBox_TD_DemoGiaiQuyet.Items.Add("Giải quyết: TH1 (Giá - Repeatable Read)");

            cbBox_TD_DemoGiaiQuyet.Items.Add("Demo TH5 (T1 - Gây lỗi Status)");
            cbBox_TD_DemoGiaiQuyet.Items.Add("Giải quyết: TH5 (Status - XLOCK)");

            cbBox_TD_DemoGiaiQuyet.Items.Add("Deadlock Cyclic (Máy 1: Giữ P -> Cần LP)");
            cbBox_TD_DemoGiaiQuyet.Items.Add("Deadlock Cyclic (Máy 2: Giữ LP -> Cần P)");
            cbBox_TD_DemoGiaiQuyet.Items.Add("Fix: Deadlock Cyclic (Tuân thủ thứ tự)");


            cbBox_TD_DemoGiaiQuyet.Items.Add("Deadlock Conversion (Gây lỗi thường)");

            cbBox_TD_DemoGiaiQuyet.Items.Add("Wound-Wait (Conversion): Máy 1 (Sếp - High)");
            cbBox_TD_DemoGiaiQuyet.Items.Add("Wound-Wait (Conversion): Máy 2 (Lính - Low)");

            cbBox_TD_DemoGiaiQuyet.Items.Add("Fix: Conversion (Dùng UPDLOCK - Xếp hàng)");

            cbBox_TD_DemoGiaiQuyet.SelectedIndex = 0;
        }
    }
}
