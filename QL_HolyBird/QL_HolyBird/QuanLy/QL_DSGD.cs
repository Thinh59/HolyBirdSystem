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
    public partial class QL_DSGD : UserControl
    {
        ServiceDAL db = new ServiceDAL();
        public QL_DSGD()
        {
            InitializeComponent();
            dat_QL_DSGD.AutoGenerateColumns = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void QL_DSGD_Load(object sender, EventArgs e)
        {
            cbB_QL_QLGD_TT.SelectedIndex = 0;

            DT_QL_QLGD_NBD.ShowCheckBox = true;
            DT_QL_QLGD_NBD.Checked = false;

            LoadGiaoDich();
        }

        private void LoadGiaoDich()
        {
            try
            {
                string maDoan = tb_QL_QLGD_MD.Text.Trim();
                string trangThai = (cbB_QL_QLGD_TT.Text == "---Tất cả---") ? null : cbB_QL_QLGD_TT.Text;

                object ngayBD = DBNull.Value;
                if (DT_QL_QLGD_NBD.Checked) ngayBD = DT_QL_QLGD_NBD.Value.Date;

                using (SqlConnection con = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_LocGiaoDich", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaDoan", string.IsNullOrEmpty(maDoan) ? (object)DBNull.Value : maDoan);
                    cmd.Parameters.AddWithValue("@NgayBD", ngayBD);
                    cmd.Parameters.AddWithValue("@TrangThai", (object)trangThai ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dat_QL_DSGD.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void tb_QL_QLGD_MD_TextChanged(object sender, EventArgs e)
        {
            LoadGiaoDich();
        }

        private void cbB_QL_QLGD_TT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGiaoDich();
        }

        private void DT_QL_QLGD_NBD_ValueChanged(object sender, EventArgs e)
        {
            LoadGiaoDich();
        }

        private void btn_QL_DSGD_Click(object sender, EventArgs e)
        {
            // ---------------------------------------------------------
            // KỊCH BẢN TH10: PHANTOM READ (Thống kê số lượng giao dịch)
            // ---------------------------------------------------------
            if (checkBox_TD_DM.Checked)
            {
                int isFix = (cbBox_TD_DemoGiaiQuyet.Text == "Giải quyết") ? 1 : 0;
                SqlParameter[] p = { new SqlParameter("@IsFix", isFix) };

                MessageBox.Show("DEMO T1 (TH10): Đang đếm số lượng giao dịch lần 1. Hệ thống sẽ giữ giao dịch trong 10s để chờ Tiếp tân thêm mới...", "Thông báo Demo");

                // Gọi Procedure T1 (Đếm 2 lần)
                DataSet ds = db.ExecuteStoredProcedure_DataSet("sp_TH10_T1_KiemTraGiaoDich_TranhChap", p);

                if (ds.Tables.Count >= 2 && ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    int sl1 = Convert.ToInt32(ds.Tables[0].Rows[0]["SoLuong"]);
                    int sl2 = Convert.ToInt32(ds.Tables[1].Rows[0]["SoLuong"]);

                    string msg = $"Kết quả thống kê:\n- Lần 1: {sl1} giao dịch\n- Lần 2: {sl2} giao dịch";

                    if (sl1 != sl2)
                        MessageBox.Show(msg + "\n\n=> LỖI PHANTOM READ: Xuất hiện giao dịch 'ma' mới được thêm vào!", "Kết quả Demo");
                    else
                        MessageBox.Show(msg + "\n\n=> THÀNH CÔNG: Dữ liệu nhất quán (Serializable Range Lock).", "Kết quả Demo");

                    // Load lại lưới sau khi xong
                    LoadGiaoDich();
                }
                return; // Kết thúc demo
            }

            // --- CHẠY LỌC BÌNH THƯỜNG ---
            LoadGiaoDich();
        }

        private void dat_QL_DSGD_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
