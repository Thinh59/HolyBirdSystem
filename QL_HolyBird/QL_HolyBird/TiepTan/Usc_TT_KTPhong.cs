using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_HolyBird
{
    public partial class Usc_TT_KTPhong : UserControl
    {
        ServiceDAL dal = new ServiceDAL();

        public Usc_TT_KTPhong()
        {
            InitializeComponent();
        }

        private void Usc_TT_KTPhong_Load(object sender, EventArgs e)
        {
            SetupGridColumns();
            LoadCmbDoanChoKT();
            LoadCmbPhiPhatSinh();
        }

        private void SetupGridColumns()
        {
            dgv_TT5_DSPPS.AutoGenerateColumns = false;
            dgv_TT5_DSPPS.Columns.Clear();
            dgv_TT5_DSPPS.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaCTGD", HeaderText = "Mã CTGD", Name = "MaCTGD", Width = 90 });
            dgv_TT5_DSPPS.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaPPS", HeaderText = "Mã PPS", Name = "MaPPS", Width = 80 });
            dgv_TT5_DSPPS.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenPPS", HeaderText = "Tên Phí", Name = "TenPPS", Width = 150 });
            dgv_TT5_DSPPS.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuong", HeaderText = "S.Lượng", Name = "SoLuong", Width = 70 });
            dgv_TT5_DSPPS.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhTienPPS", HeaderText = "Thành Tiền", Name = "ThanhTienPPS", Width = 100 });
        }

        private void LoadCmbDoanChoKT()
        {
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT5_GetDoanChoKT");
            cmb_TT5_MaDoan.DataSource = dt;
            cmb_TT5_MaDoan.DisplayMember = "HienThi";
            cmb_TT5_MaDoan.ValueMember = "MaDoan";
            cmb_TT5_MaDoan.SelectedIndex = -1;
        }

        private void LoadCmbPhiPhatSinh()
        {
            DataTable dt = dal.GetDataTable("SELECT MaPPS, (MaPPS + ' - ' + TenPPS) as HienThi FROM PHIPHATSINH");
            cmb_TT5_MaPPS.DataSource = dt;
            cmb_TT5_MaPPS.DisplayMember = "HienThi";
            cmb_TT5_MaPPS.ValueMember = "MaPPS";
            cmb_TT5_MaPPS.SelectedIndex = -1;
        }

        private void cmb_TT5_MaDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TT5_MaDoan.SelectedValue != null && cmb_TT5_MaDoan.Focused)
            {
                string maDoan = cmb_TT5_MaDoan.SelectedValue.ToString();
                SqlParameter[] p = { new SqlParameter("@MaDoan", maDoan) };
                DataTable dtCT = dal.ExecuteStoredProcedure("sp_TT5_GetCTGDByMaDoan", p);
                cmb_TT5_CTGD.DataSource = dtCT;
                cmb_TT5_CTGD.DisplayMember = "HienThi";
                cmb_TT5_CTGD.ValueMember = "MaCTGD";
                cmb_TT5_CTGD.SelectedIndex = -1;
                LoadGridPPS(maDoan);
            }
        }

        private void LoadGridPPS(string maDoan)
        {
            string sql = @"SELECT cp.MaCTGD, cp.MaPPS, pps.TenPPS, cp.SoLuong, cp.ThanhTienPPS 
                           FROM CT_PHIPS cp 
                           JOIN PHIPHATSINH pps ON cp.MaPPS = pps.MaPPS 
                           WHERE cp.MaDoan = @MaDoan";
            SqlParameter[] p = { new SqlParameter("@MaDoan", maDoan) };
            dgv_TT5_DSPPS.DataSource = dal.GetDataTable(sql, p);
        }

        // NÚT XÓA PHÍ (Xóa dòng đang chọn trên Grid)
        private void btn_TT5_XoaPhi_Click(object sender, EventArgs e)
        {
            if (dgv_TT5_DSPPS.CurrentRow == null) return;

            string maCTGD = dgv_TT5_DSPPS.CurrentRow.Cells["MaCTGD"].Value.ToString();
            string maPPS = dgv_TT5_DSPPS.CurrentRow.Cells["MaPPS"].Value.ToString();

            if (MessageBox.Show("Xóa phí này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "DELETE FROM CT_PHIPS WHERE MaCTGD = @ct AND MaPPS = @pps";
                SqlParameter[] p = { new SqlParameter("@ct", maCTGD), new SqlParameter("@pps", maPPS) };

                // SỬA TẠI ĐÂY: Vì hàm trả về bool nên viết trực tiếp trong if
                if (dal.ExecuteNonQuery(sql, p))
                {
                    MessageBox.Show("Đã xóa dòng phí!");
                    LoadGridPPS(cmb_TT5_MaDoan.SelectedValue.ToString());
                }
            }
        }

        // NÚT XÁC NHẬN (Bây giờ đóng vai trò HOÀN TẤT KIỂM TRA PHÒNG)
        private void btn_TT5_XacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn Đoàn chưa
            if (cmb_TT5_MaDoan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Đoàn cần hoàn tất kiểm tra!");
                return;
            }

            string maDoan = cmb_TT5_MaDoan.SelectedValue.ToString();

            // Hỏi xác nhận cho chắc chắn
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xác nhận HOÀN TẤT KIỂM TRA cho TẤT CẢ các phòng còn lại của đoàn này không?\n\n" +
                "Lưu ý: Các phòng này sẽ được coi là không có phát sinh phí mới (trừ các phí đã nhập).",
                "Xác nhận duyệt nhanh",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] p = { new SqlParameter("@MaDoan", maDoan) };

                    // Gọi Procedure duyệt nhanh
                    if (dal.ExecuteSPNonQuery("sp_TT5_HoanTatKiemTraTatCa", p))
                    {
                        MessageBox.Show("Đã hoàn tất kiểm tra cho cả đoàn!");

                        // Refresh lại dữ liệu
                        LoadCmbDoanChoKT();

                        // Clear các grid và combo chi tiết
                        cmb_TT5_CTGD.DataSource = null;
                        dgv_TT5_DSPPS.DataSource = null;
                        txtBox_TT5_SL.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btn_TT9_DSPhiPhatSinh_Click(object sender, EventArgs e)
        {
            DataTable dt = dal.GetDataTable("SELECT * FROM PHIPHATSINH");
            Form f = new Form { Text = "Danh sách Phí", Width = 400, Height = 300, StartPosition = FormStartPosition.CenterScreen };
            f.Controls.Add(new DataGridView { DataSource = dt, Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill });
            f.ShowDialog();
        }

        private void btn_TT5_ThemPhi_Click_1(object sender, EventArgs e)
        {
            if (cmb_TT5_MaPPS.SelectedValue == null) return;
            string maPPS = cmb_TT5_MaPPS.SelectedValue.ToString();

            if (checkBox_TT5_KTPhong_DM.Checked)
            {
                int isFix = (cbBox_TT5_DemoGiaiQuyet.Text == "Giải quyết") ? 1 : 0;
                SqlParameter[] p = {
            new SqlParameter("@MaPPS", maPPS),
            new SqlParameter("@IsFix", isFix)
        };

                MessageBox.Show("Đang xem giá PPS lần 1. Hệ thống sẽ đợi 10s để Quản lý đổi giá...", "Thông báo Demo");

                // Gọi Procedure Xem (Sử dụng DataSet vì SP trả về 2 kết quả SELECT)
                DataSet ds = dal.ExecuteStoredProcedure_DataSet("sp_TH2_T1_XemGiaPPS_TranhChap", p);

                if (ds.Tables.Count >= 2)
                {
                    decimal gia1 = Convert.ToDecimal(ds.Tables[0].Rows[0]["GiaPhi"]);
                    decimal gia2 = Convert.ToDecimal(ds.Tables[1].Rows[0]["GiaPhi"]);

                    string msg = $"Lần 1 đọc giá: {gia1:N0}\nLần 2 đọc giá: {gia2:N0}";
                    if (gia1 != gia2)
                        MessageBox.Show(msg + "\n=> LỖI: Unrepeatable Read (Giá đã bị thay đổi!)", "Kết quả");
                    else
                        MessageBox.Show(msg + "\n=> THÀNH CÔNG: Dữ liệu nhất quán.", "Kết quả");
                }
                return;
            }
            if (cmb_TT5_CTGD.SelectedValue == null || cmb_TT5_MaPPS.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Phòng và Loại phí!");
                return;
            }

            if (!int.TryParse(txtBox_TT5_SL.Text, out int sl) || sl <= 0)
            {
                MessageBox.Show("Số lượng phải là số dương!");
                return;
            }

            try
            {
                SqlParameter[] p = {
                    new SqlParameter("@MaCTGD", cmb_TT5_CTGD.SelectedValue.ToString()),
                    new SqlParameter("@MaDoan", cmb_TT5_MaDoan.SelectedValue.ToString()),
                    new SqlParameter("@MaPPS", cmb_TT5_MaPPS.SelectedValue.ToString()),
                    new SqlParameter("@SoLuong", sl)
                };

                if (dal.ExecuteSPNonQuery("sp_TT5_ThemPhiPhatSinh", p))
                {
                    LoadGridPPS(cmb_TT5_MaDoan.SelectedValue.ToString());
                    txtBox_TT5_SL.Clear();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void checkBox_TT5_KTPhong_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TT5_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}