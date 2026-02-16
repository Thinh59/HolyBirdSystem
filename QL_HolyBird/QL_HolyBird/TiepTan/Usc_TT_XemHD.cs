using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_HolyBird.TiepTan
{
    public partial class Usc_TT_XemHD : UserControl
    {
        ServiceDAL dal = new ServiceDAL();

        public Usc_TT_XemHD()
        {
            InitializeComponent();
            SetupGrid();
        }

        private void Usc_TT_XemHD_Load(object sender, EventArgs e)
        {
            // 1. Lấy mã nhân viên (Ưu tiên Session, nếu không có thì dùng NV01)
            string maNV = !string.IsNullOrEmpty(Session.MaNV) ? Session.MaNV : "NV01";
            txtBox_TT7_NVLap.Text = maNV;

            // 2. Nạp danh sách vào 2 cái ComboBox bị trống
            LoadCombos(maNV);

            // 3. Tải dữ liệu vào Grid
            LoadDataGrid(maNV);
        }

        private void SetupGrid()
        {
            dgv_TT7_DSHD.AutoGenerateColumns = false;
            dgv_TT7_DSHD.Columns.Clear();

            // Mã HĐ
            dgv_TT7_DSHD.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHD", HeaderText = "Mã HĐ", Name = "MaHD", Width = 80 });

            // Mã Đoàn
            dgv_TT7_DSHD.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDoan", HeaderText = "Mã Đoàn", Name = "MaDoan", Width = 80 });

            // SỬA LỖI TẠI ĐÂY: Phải là DataGridViewTextBoxColumn chứ không được dùng DataPropertyName khơi khơi
            dgv_TT7_DSHD.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayLap", HeaderText = "Ngày Lập", Name = "NgayLap", Width = 100 });

            // Tổng Tiền
            dgv_TT7_DSHD.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongTien", HeaderText = "Tổng Tiền", Name = "TongTien", Width = 100 });

            // Trạng Thái
            dgv_TT7_DSHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThaiHD",
                HeaderText = "Trạng Thái",
                Name = "TrangThaiHD",
                Width = 120
            });
        }

        private void LoadCombos(string maNV)
        {
            try
            {
                // Vì ServiceDAL của bạn thường trả về DataTable, ta sẽ gọi lệnh SQL trực tiếp cho nhanh
                SqlParameter[] p1 = { new SqlParameter("@MaNV", maNV) };
                DataTable dtMaHD = dal.GetDataTable("SELECT DISTINCT MaHD FROM HOADON WHERE NVLap = @MaNV", p1);
                cmb_TT7_MaHD.DataSource = dtMaHD;
                cmb_TT7_MaHD.DisplayMember = "MaHD";
                cmb_TT7_MaHD.ValueMember = "MaHD";
                cmb_TT7_MaHD.SelectedIndex = -1; // Để trống lúc đầu

                SqlParameter[] p2 = { new SqlParameter("@MaNV", maNV) };
                DataTable dtMaDoan = dal.GetDataTable("SELECT DISTINCT MaDoan FROM HOADON WHERE NVLap = @MaNV", p2);
                cmb_TT7_MaDoan.DataSource = dtMaDoan;
                cmb_TT7_MaDoan.DisplayMember = "MaDoan";
                cmb_TT7_MaDoan.ValueMember = "MaDoan";
                cmb_TT7_MaDoan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách chọn: " + ex.Message);
            }
        }

        private void LoadDataGrid(string maNV)
        {
            SqlParameter[] p = { new SqlParameter("@MaNV", maNV) };
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT7_TimKiemHoaDon", p);
            dgv_TT7_DSHD.DataSource = dt;
        }

        private void btn_TT6_TimMaHD_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtBox_TT7_NVLap.Text;
                // Lấy MaHD từ ComboBox bạn vừa chọn
                string maHD = cmb_TT7_MaHD.SelectedValue?.ToString();

                if (checkBox_TT7_DM.Checked)
                {
                    int isFix = (cbBox_TT7_DemoGiaiQuyet.Text == "Giải quyết") ? 1 : 0;

                    // Truyền thêm MaHD vào để lọc đúng cái đang Demo
                    SqlParameter[] p = {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@MaHD", (object)maHD ?? DBNull.Value),
                new SqlParameter("@IsFix", isFix)
            };

                    DataTable dt = dal.ExecuteStoredProcedure("sp_TH9_T2_XemHoaDon_TranhChap", p);
                    dgv_TT7_DSHD.DataSource = dt;
                }
                else
                {
                    // CHẾ ĐỘ THƯỜNG: Phải truyền MaHD thì SQL mới lọc được
                    SqlParameter[] pNormal = {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@MaHD", (object)maHD ?? DBNull.Value)
            };

                    DataTable dtNormal = dal.ExecuteStoredProcedure("sp_TT7_TimKiemHoaDon", pNormal);
                    dgv_TT7_DSHD.DataSource = dtNormal;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_TT7_InHD_Click(object sender, EventArgs e)
        {
            if (dgv_TT7_DSHD.CurrentRow != null)
            {
                string maHD = dgv_TT7_DSHD.CurrentRow.Cells["MaHD"].Value.ToString();
                MessageBox.Show("Đang in lại hóa đơn: " + maHD);
            }
        }

        private void checkBox_TT7_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TT7_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}