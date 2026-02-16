using System;
using System.Data;
using System.Windows.Forms;

namespace QL_HolyBird
{
    public partial class Usc_TT_XNTraPhong : UserControl
    {
        ServiceDAL dal = new ServiceDAL();

        public Usc_TT_XNTraPhong()
        {
            InitializeComponent();
            LoadMaDoan();
        }

        private void LoadMaDoan()
        {
            cmb_TT8_MaDoan.DataSource = dal.TT8_GetDoanDangSuDung();
            cmb_TT8_MaDoan.DisplayMember = "HienThi";
            cmb_TT8_MaDoan.ValueMember = "MaDoan";
            cmb_TT8_MaDoan.SelectedIndex = -1;
        }

        private void cmb_TT8_MaDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TT8_MaDoan.SelectedValue != null)
            {
                string maDoan = cmb_TT8_MaDoan.SelectedValue.ToString();
                dgv_TT8_TraPhongCTGD.DataSource = dal.TT8_GetChiTietTraPhong(maDoan);

                // Đảm bảo cột Checkbox có thể nhấn được
                if (dgv_TT8_TraPhongCTGD.Columns["TraPhong"] != null)
                    dgv_TT8_TraPhongCTGD.Columns["TraPhong"].ReadOnly = false;
            }
        }

        private void btn_TT8_XacNhan_Click(object sender, EventArgs e)
        {
            if (dgv_TT8_TraPhongCTGD.Rows.Count == 0) return;

            bool hasSelection = false;
            int successCount = 0;

            foreach (DataGridViewRow row in dgv_TT8_TraPhongCTGD.Rows)
            {
                // Kiểm tra xem checkbox "TraPhong" có được tích hay không
                if (Convert.ToBoolean(row.Cells["TraPhong"].Value) == true)
                {
                    hasSelection = true;
                    string maCTGD = row.Cells["MaCTGD"].Value.ToString();

                    if (dal.TT8_XacNhanTraPhong(maCTGD))
                    {
                        successCount++;
                    }
                }
            }

            if (!hasSelection)
            {
                MessageBox.Show("Vui lòng tích chọn ít nhất một phòng để trả!", "Thông báo");
                return;
            }

            MessageBox.Show($"Đã xác nhận trả {successCount} phòng. Trạng thái hiện tại: Chờ kiểm tra phòng.", "Thành công");

            // Refresh lại danh sách
            cmb_TT8_MaDoan_SelectedIndexChanged(null, null);
            LoadMaDoan(); // Load lại combobox vì có thể đoàn đã trả hết phòng
        }
    }
}