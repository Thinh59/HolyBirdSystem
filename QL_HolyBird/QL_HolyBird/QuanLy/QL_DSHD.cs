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
    public partial class QL_DSHD : UserControl
    {
        ServiceDAL db = new ServiceDAL();
        public QL_DSHD()
        {
            InitializeComponent();
            dat_QL_DSHD.AutoGenerateColumns = false;
        }

        private void tb_QL_DSHD_Ma_TextChanged(object sender, EventArgs e)
        {
            LocDuLieuHoaDon();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void QL_DSHD_Load(object sender, EventArgs e)
        {
            combo_QL_HD_TT.SelectedIndex = 0;

            DT_QL_HD_NL.ShowCheckBox = true;
            DT_QL_HD_NL.Checked = false;
            LocDuLieuHoaDon();
        }

        private void LocDuLieuHoaDon()
        {
            try
            {
                string keyword = tb_QL_DSHD_Ma.Text.Trim();

                string trangThai = null;
                if (combo_QL_HD_TT.SelectedIndex > 0)
                {
                    trangThai = combo_QL_HD_TT.SelectedItem.ToString();
                }

                object ngayLap = DBNull.Value;
                if (DT_QL_HD_NL.Checked)
                {
                    ngayLap = DT_QL_HD_NL.Value.Date;
                }

                using (SqlConnection con = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_LocHoaDon_DaNang", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SearchKeyword", string.IsNullOrEmpty(keyword) ? (object)DBNull.Value : keyword);
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai ?? (object)DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dat_QL_DSHD.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message);
            }
        }

        private void DT_QL_HD_NL_ValueChanged(object sender, EventArgs e)
        {
            if (DT_QL_HD_NL.Checked)
            {
                LocDuLieuHoaDon();
            }
        }

        private void lab_QL_DSHD_MD_Click(object sender, EventArgs e)
        {

        }

        private void combo_QL_HD_TT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocDuLieuHoaDon();
        }

        private void btn_QL_DSHD_Click(object sender, EventArgs e)
        {
            LocDuLieuHoaDon();
        }

        private void dat_QL_DSHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox_QL_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_QL_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
