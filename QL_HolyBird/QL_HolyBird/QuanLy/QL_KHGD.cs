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
    public partial class QL_KHGD : UserControl
    {
        ServiceDAL db = new ServiceDAL();
        public QL_KHGD()
        {
            InitializeComponent();
            dat_QL_KHNP.AutoGenerateColumns = false;
        }

        private void QL_KHGD_Load(object sender, EventArgs e)
        {

        }

        private void dat_QL_KHNP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_QL_KHNP_TK_Click(object sender, EventArgs e)
        {
            string maDoan = tb_QL_KHNP_MD.Text.Trim();
            if (string.IsNullOrEmpty(maDoan)) return;

            SqlParameter[] p = { new SqlParameter("@MaDoan", maDoan) };
            DataTable dt = db.GetDataTable("EXEC sp_GetGiaoDichKichHoat @MaDoan", p);

            if (dt.Rows.Count > 0)
                dat_QL_KHNP.DataSource = dt;
            else
                MessageBox.Show("Không tìm thấy phòng nào chưa nhận của đoàn này!");
        }

        private void btn_QL_KHNP_XN_Click(object sender, EventArgs e)
        {
            int count = 0;
            try
            {
                using (SqlConnection con = db.GetConnection())
                {
                    con.Open();
                    foreach (DataGridViewRow row in dat_QL_KHNP.Rows)
                    {
                        bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                        if (isChecked)
                        {
                            string maCTGD = row.Cells["MaCTGD"].Value.ToString();
                            SqlCommand cmd = new SqlCommand("sp_KichHoatGiaoDich", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MaCTGD", maCTGD);
                            cmd.ExecuteNonQuery();
                            count++;
                        }
                    }
                }

                if (count > 0)
                {
                    MessageBox.Show($"Đã kích hoạt thành công {count} phòng!");
                    dat_QL_KHNP.DataSource = null;
                    btn_QL_KHNP_TK_Click(sender, e); 
                }
                else
                {
                    MessageBox.Show("Vui lòng tích chọn phòng muốn kích hoạt!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void tb_QL_KHNP_MD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
