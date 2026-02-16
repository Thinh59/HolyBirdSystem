using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_HolyBird.TiepTan
{
    public partial class Usc_TT_KichHoatGD : UserControl
    {
        ServiceDAL dal = new ServiceDAL();

        public Usc_TT_KichHoatGD()
        {
            InitializeComponent();
        }

        private void Usc_TT_KichHoatGD_Load(object sender, EventArgs e)
        {
            LoadComboBoxDoan();
            SetupDataGridView();
        }

        private void LoadComboBoxDoan()
        {
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT3_GetDoanHienThi");
            cmb_TT3_MaDoan.DataSource = dt;
            cmb_TT3_MaDoan.DisplayMember = "HienThi";
            cmb_TT3_MaDoan.ValueMember = "MaDoan";
            cmb_TT3_MaDoan.SelectedIndex = -1;
        }

        // Khi chọn đoàn từ ComboBox
        private void cmb_TT3_MaDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TT3_MaDoan.SelectedValue != null && cmb_TT3_MaDoan.Focused)
            {
                string maDoan = cmb_TT3_MaDoan.SelectedValue.ToString();
                LoadGridByMaDoan(maDoan);
            }
        }

        private void btn_TT3_TimMaDoan_Click(object sender, EventArgs e)
        {
            string maDoan = cmb_TT3_MaDoan.Text.Trim();
            if (string.IsNullOrEmpty(maDoan))
            {
                MessageBox.Show("Vui lòng nhập Mã đoàn cần tìm!");
                return;
            }
            LoadGridByMaDoan(maDoan);
        }

        private void SetupDataGridView()
        {
            dgv_TT3_NhanPhongCTGD.AutoGenerateColumns = false;
            dgv_TT3_NhanPhongCTGD.Columns.Clear(); // Xóa sạch để tạo mới cho chuẩn

            // 1. Cột Checkbox
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "chkChon";
            colCheck.HeaderText = "Chọn Nhận";
            dgv_TT3_NhanPhongCTGD.Columns.Add(colCheck);

            // 2. Cột Mã CTGD
            dgv_TT3_NhanPhongCTGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaCTGD",
                HeaderText = "Mã CTGD",
                Name = "MaCTGD"
            });

            // 3. Cột CCCD (từ cột CaNhan trong SQL)
            dgv_TT3_NhanPhongCTGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CCCD",
                HeaderText = "CCCD Khách",
                Name = "CCCD"
            });

            // 4. Cột Họ Tên (Lấy từ SQL JOIN)
            dgv_TT3_NhanPhongCTGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ Tên",
                Name = "HoTen",
                Width = 150
            });

            // 5. Cột Mã Phòng
            dgv_TT3_NhanPhongCTGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaPhong",
                HeaderText = "Phòng",
                Name = "MaPhong"
            });

            // 6. Cột Trạng thái
            dgv_TT3_NhanPhongCTGD.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThaiGD",
                HeaderText = "Trạng Thái",
                Name = "TrangThaiGD"
            });
        }

        private void LoadGridByMaDoan(string maDoan)
        {
            SqlParameter[] p = { new SqlParameter("@MaDoan", maDoan) };
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT3_GetChiTietDoan", p);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgv_TT3_NhanPhongCTGD.DataSource = dt;
            }
            else
            {
                dgv_TT3_NhanPhongCTGD.DataSource = null;
                MessageBox.Show("Không tìm thấy thông tin phòng chưa nhận!");
            }
        }

        // Nút XÁC NHẬN NHẬN PHÒNG
        private void btn_TT3_XacNhan_Click(object sender, EventArgs e)
        {
            if (dgv_TT3_NhanPhongCTGD.Rows.Count == 0) return;

            dgv_TT3_NhanPhongCTGD.EndEdit();
            string maDoan = "";

            // 1. Lấy mã đoàn đang xử lý (từ ComboBox hoặc dòng đầu tiên của Grid)
            if (cmb_TT3_MaDoan.SelectedValue != null)
                maDoan = cmb_TT3_MaDoan.SelectedValue.ToString();

            // 2. Kiểm tra thời gian trễ của đoàn này trước khi cho phép kích hoạt
            // Truy vấn lấy NgayBD của GIAODICH
            string sqlCheckTime = "SELECT NgayBD FROM GIAODICH WHERE MaDoan = @MaDoan";
            DataTable dtTime = dal.GetDataTable(sqlCheckTime, new SqlParameter[] { new SqlParameter("@MaDoan", maDoan) });

            if (dtTime.Rows.Count > 0)
            {
                DateTime ngayBD = Convert.ToDateTime(dtTime.Rows[0]["NgayBD"]);
                DateTime gioHienTai = DateTime.Now;

                // Tính số phút chênh lệch
                double minutesLate = (gioHienTai - ngayBD).TotalMinutes;

                if (minutesLate > 120)
                {
                    MessageBox.Show($"Giao dịch này đã quá hạn nhận phòng ({Math.Round(minutesLate)} phút trễ). \nKhông thể kích hoạt nhận phòng!",
                                    "Cảnh báo quá hạn", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Tùy chọn: Tự động cập nhật trạng thái hủy luôn nếu bạn muốn
                    // string sqlHuy = "UPDATE CT_GIAODICH SET TrangThaiGD = N'Đã hủy (Trễ)' WHERE MaDoan = @MaDoan AND TrangThaiGD != N'Đã nhận phòng'";
                    // dal.ExecuteNonQuery(sqlHuy, new SqlParameter[] { new SqlParameter("@MaDoan", maDoan) });

                    return; // Dừng xử lý, không cho Update thành 'Đã nhận phòng'
                }
            }

            // 3. Nếu không trễ (hoặc trễ dưới 120p) thì tiến hành kích hoạt những dòng được chọn
            int successCount = 0;
            foreach (DataGridViewRow row in dgv_TT3_NhanPhongCTGD.Rows)
            {
                if (Convert.ToBoolean(row.Cells["chkChon"].Value) == true)
                {
                    string maCTGD = row.Cells["MaCTGD"].Value.ToString();
                    SqlParameter[] p = { new SqlParameter("@MaCTGD", maCTGD) };

                    if (dal.ExecuteSPNonQuery("sp_TT3_XacNhanNhanPhong", p))
                    {
                        successCount++;
                    }
                }
            }

            if (successCount > 0)
            {
                MessageBox.Show($"Đã xác nhận nhận phòng thành công cho {successCount} thành viên.", "Thành công");
                LoadGridByMaDoan(maDoan); // Refresh lại grid
                LoadComboBoxDoan(); // Refresh lại danh sách đoàn
            }
        }

        private void txtBox_TT3_MaDoan_TextChanged(object sender, EventArgs e) { }
        private void dgv_TT3_NhanPhongCTGD_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}