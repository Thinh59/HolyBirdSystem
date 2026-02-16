using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_HolyBird.TiepTan
{
    public partial class Usc_TT_CapTheTu : UserControl
    {
        ServiceDAL dal = new ServiceDAL();
        private string selectedMaCTGD = "";

        public Usc_TT_CapTheTu()
        {
            InitializeComponent();
        }

        private void Usc_TT_CapTheTu_Load(object sender, EventArgs e)
        {
            SetupGridColumns(); // Tạo cột trước khi nạp data
            LoadCmbMaDoan();
            LoadComboBoxTheTrong();
            dtp_TT4_NgayCapThe.Value = DateTime.Now;
        }

        private void SetupGridColumns()
        {
            dgv_TT4_DSCapThe.AutoGenerateColumns = false;
            dgv_TT4_DSCapThe.Columns.Clear();

            dgv_TT4_DSCapThe.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaCTGD", HeaderText = "Mã CTGD", Name = "MaCTGD", Width = 80 });
            dgv_TT4_DSCapThe.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaPhong", HeaderText = "Phòng", Name = "MaPhong", Width = 60 });
            dgv_TT4_DSCapThe.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoTen", HeaderText = "Khách hàng", Name = "HoTen", Width = 150 });
            dgv_TT4_DSCapThe.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaThe", HeaderText = "Mã Thẻ", Name = "MaThe", Width = 80 });
            dgv_TT4_DSCapThe.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThaiHienThi", HeaderText = "Trạng Thái", Name = "TrangThaiHienThi", Width = 120 });
        }

        private void LoadCmbMaDoan()
        {
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT4_GetMaDoanChoCapThe");
            cmb_TT4_MaDoan.DataSource = dt;
            cmb_TT4_MaDoan.DisplayMember = "HienThi";
            cmb_TT4_MaDoan.ValueMember = "MaDoan";
            cmb_TT4_MaDoan.SelectedIndex = -1;
        }

        private void LoadComboBoxTheTrong()
        {
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT4_GetTheTrong");
            cmb_TT4_MaThe.DataSource = dt;
            cmb_TT4_MaThe.DisplayMember = "MaThe";
            cmb_TT4_MaThe.ValueMember = "MaThe";
            cmb_TT4_MaThe.SelectedIndex = -1;
        }

        private void cmb_TT4_MaDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TT4_MaDoan.SelectedValue != null && cmb_TT4_MaDoan.Focused)
            {
                string maDoan = cmb_TT4_MaDoan.SelectedValue.ToString();

                // 1. Load ComboBox CTGD
                SqlParameter[] p1 = { new SqlParameter("@MaDoan", maDoan) };
                DataTable dtCmb = dal.ExecuteStoredProcedure("sp_TT4_GetCTGDChuaCapByMaDoan", p1);
                cmb_TT4_CTGD.DataSource = dtCmb;
                cmb_TT4_CTGD.DisplayMember = "HienThi";
                cmb_TT4_CTGD.ValueMember = "MaCTGD";
                cmb_TT4_CTGD.SelectedIndex = -1;

                // 2. Load Grid
                LoadGridMacDinh(maDoan);
            }
        }

        private void LoadGridMacDinh(string maDoan)
        {
            SqlParameter[] p = { new SqlParameter("@MaDoan", maDoan) };
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT4_GetTatCaCTGDByMaDoan", p);

            if (!dt.Columns.Contains("TrangThaiHienThi"))
                dt.Columns.Add("TrangThaiHienThi", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                row["TrangThaiHienThi"] = string.IsNullOrEmpty(row["MaThe"].ToString()) ? "Chờ cấp thẻ" : "Đã cấp thẻ";
            }
            dgv_TT4_DSCapThe.DataSource = dt;
        }

        private void cmb_TT4_CTGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TT4_CTGD.SelectedValue != null && cmb_TT4_CTGD.Focused)
            {
                selectedMaCTGD = cmb_TT4_CTGD.SelectedValue.ToString();
                DataRowView row = (DataRowView)cmb_TT4_CTGD.SelectedItem;
                if (row["NgayKT"] != DBNull.Value)
                    dtp_TT4_NgayHetHan.Value = Convert.ToDateTime(row["NgayKT"]);
            }
        }

        private void btn_TT4_CapThe_Click(object sender, EventArgs e)
        {
            if (cmb_TT4_MaThe.SelectedValue == null || string.IsNullOrEmpty(selectedMaCTGD))
            {
                MessageBox.Show("Vui lòng chọn Mã Thẻ trống và Chi tiết phòng cần cấp!");
                return;
            }

            string maThe = cmb_TT4_MaThe.SelectedValue.ToString();

            try
            {
                SqlParameter[] p = {
                    new SqlParameter("@MaThe", maThe),
                    new SqlParameter("@MaCTGD", selectedMaCTGD),
                    new SqlParameter("@NgayCap", dtp_TT4_NgayCapThe.Value),
                    new SqlParameter("@NgayHetHan", dtp_TT4_NgayHetHan.Value)
                };

                if (dal.ExecuteSPNonQuery("sp_TT4_XacNhanCapThe", p))
                {
                    MessageBox.Show($"Cấp thẻ {maThe} thành công!");
                    LoadComboBoxTheTrong();
                    string maDoan = cmb_TT4_MaDoan.SelectedValue.ToString();

                    SqlParameter[] p2 = { new SqlParameter("@MaDoan", maDoan) };
                    cmb_TT4_CTGD.DataSource = dal.ExecuteStoredProcedure("sp_TT4_GetCTGDChuaCapByMaDoan", p2);
                    LoadGridMacDinh(maDoan);
                    selectedMaCTGD = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void cmb_TT4_MaThe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}