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
    public partial class QL_DSNV : UserControl
    {
        ServiceDAL db = new ServiceDAL();
        public QL_DSNV()
        {
            InitializeComponent();
            dat_QL_DSNV.AutoGenerateColumns = false;
        }

        private void QL_DSNV_Load(object sender, EventArgs e)
        {
            combo_QL_NV_CV.SelectedIndex = 0;

            LoadNhanVien();
        }

        private void LoadNhanVien()
        {
            try
            {
                string keyword = tb_QL_DSNV_Ma.Text.Trim();
                string chucVu = (combo_QL_NV_CV.Text == "---Tất cả---") ? null : combo_QL_NV_CV.Text;

                using (SqlConnection con = db.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_LocNhanVien", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(keyword) ? (object)DBNull.Value : keyword);
                    cmd.Parameters.AddWithValue("@ChucVu", (object)chucVu ?? DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dat_QL_DSNV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message);
            }
        }

        private void dat_QL_DSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lab_QL_DSNV_Ma_Click(object sender, EventArgs e)
        {

        }

        private void tb_QL_DSNV_Ma_TextChanged(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btn_QL_DSNV_Click(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void combo_QL_NV_CV_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNhanVien();
        }
    }
}
