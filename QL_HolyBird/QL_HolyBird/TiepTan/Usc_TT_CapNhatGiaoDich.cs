using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_HolyBird.TiepTan
{
    public partial class Usc_TT_CapNhatGiaoDich : UserControl
    {
        // Đảm bảo ServiceDAL của bạn đã có các hàm ExecuteStoredProcedure và GetDataTable
        ServiceDAL dal = new ServiceDAL();

        public Usc_TT_CapNhatGiaoDich()
        {
            InitializeComponent();
            // 1. Phải gọi cái này đầu tiên để tạo cột
            SetupGrid();
            this.Load += Usc_TT_CapNhatGiaoDich_Load;
        }

        private void Usc_TT_CapNhatGiaoDich_Load(object sender, EventArgs e)
        {
            // 2. Nạp dữ liệu khi form mở lên
            LoadDataGrid();
            LoadComboMaDoan();
            SetEditMode(true);
        }

        private void SetupGrid()
        {
            dgv_TT8_DSGiaoDich.AutoGenerateColumns = false;
            dgv_TT8_DSGiaoDich.Columns.Clear();

            // Cột Checkbox
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Chọn";
            chk.Name = "chkSelect";
            chk.Width = 50;
            dgv_TT8_DSGiaoDich.Columns.Add(chk);

            // Các cột dữ liệu - DataPropertyName PHẢI KHỚP TÊN CỘT TRONG SQL
            dgv_TT8_DSGiaoDich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDoan", HeaderText = "Mã Đoàn", Name = "MaDoan", Width = 90 });
            dgv_TT8_DSGiaoDich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DaiDienDoan", HeaderText = "Đại Diện", Name = "DaiDienDoan", Width = 110 });
            dgv_TT8_DSGiaoDich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoNguoi", HeaderText = "Số Người", Name = "SoNguoi", Width = 80 });
            dgv_TT8_DSGiaoDich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoPhong", HeaderText = "Số Phòng", Name = "SoPhong", Width = 80 });
            dgv_TT8_DSGiaoDich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayBD", HeaderText = "Ngày Bắt Đầu", Name = "NgayBD", Width = 120 });
            dgv_TT8_DSGiaoDich.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayKT", HeaderText = "Ngày Kết Thúc", Name = "NgayKT", Width = 120 });
        }

        private void LoadDataGrid(string maDoan = null)
        {
            try
            {
                // Lấy tất cả hoặc theo mã đoàn
                string sql = "SELECT MaDoan, DaiDienDoan, SoNguoi, SoPhong, NgayBD, NgayKT FROM GIAODICH";
                if (!string.IsNullOrEmpty(maDoan))
                {
                    sql += " WHERE MaDoan = '" + maDoan + "'";
                }

                DataTable dt = dal.GetDataTable(sql);
                dgv_TT8_DSGiaoDich.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("SQL trả về 0 dòng dữ liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp Grid: " + ex.Message);
            }
        }

        private void LoadComboMaDoan()
        {
            try
            {
                DataTable dt = dal.GetDataTable("SELECT DISTINCT MaDoan FROM GIAODICH");
                cmb_TT8_MaDoan.DataSource = dt;
                cmb_TT8_MaDoan.DisplayMember = "MaDoan";
                cmb_TT8_MaDoan.ValueMember = "MaDoan";
                cmb_TT8_MaDoan.SelectedIndex = -1; // Để trống ban đầu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp ComboBox: " + ex.Message);
            }
        }

        private void cmb_TT8_MaDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi chọn mã đoàn trong cmb thì grid nhảy theo
            if (cmb_TT8_MaDoan.SelectedValue != null && cmb_TT8_MaDoan.Focused)
            {
                LoadDataGrid(cmb_TT8_MaDoan.SelectedValue.ToString());
            }
        }

        private void SetEditMode(bool editing)
        {
            btn_TT8_XacNhan.Enabled = editing;
            btn_TT8_Huy.Enabled = editing;
            btn_TT8_Sua.Enabled = !editing;
            btn_TT8_Xoa.Enabled = !editing;
            dgv_TT8_DSGiaoDich.ReadOnly = !editing;
        }

        // --- Các nút bấm giữ nguyên logic của bạn ---
        private void btn_TT8_Sua_Click(object sender, EventArgs e) { SetEditMode(true); }
        private void btn_TT8_Huy_Click(object sender, EventArgs e) { SetEditMode(false); LoadDataGrid(); }
        private void btn_TT8_XacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_TT8_DSGiaoDich.EndEdit();

                // ---------------------------------------------------------
                // PHẦN DEMO TRANH CHẤP (T2 - Chen ngang)
                // ---------------------------------------------------------
                if (checkBox_TT8_DM.Checked) // Nếu tích Demo
                {
                    // Lấy dòng đầu tiên được chọn để Demo
                    foreach (DataGridViewRow row in dgv_TT8_DSGiaoDich.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["chkSelect"].Value) == true)
                        {
                            string maDoan = row.Cells["MaDoan"].Value.ToString();
                            int soNguoiMoi = Convert.ToInt32(row.Cells["SoNguoi"].Value); // Lấy số người mới nhập trên grid

                            MessageBox.Show($"DEMO T2: Tiếp tân đang cập nhật số người của đoàn {maDoan} thành {soNguoiMoi}...", "Thông báo Demo");

                            SqlParameter[] p = {
                        new SqlParameter("@MaDoan", maDoan),
                        new SqlParameter("@SoNguoiMoi", soNguoiMoi)
                    };

                            if (dal.ExecuteSPNonQuery("sp_TH7_T2_UpdateSoNguoi", p))
                            {
                                MessageBox.Show("Cập nhật thành công! (Gây lỗi Unrepeatable Read cho máy bên kia)");
                            }
                            return; // Chỉ demo 1 dòng rồi thoát
                        }
                    }
                    MessageBox.Show("Vui lòng chọn 1 dòng để Demo!");
                    return;
                }
                // BƯỚC 1: Quan trọng! Ép Grid kết thúc chế độ chỉnh sửa để lấy dữ liệu mới nhất từ các ô

                int countSuccess = 0;

                // BƯỚC 2: Duyệt qua từng dòng trong Grid
                foreach (DataGridViewRow row in dgv_TT8_DSGiaoDich.Rows)
                {
                    // Kiểm tra xem dòng đó có được tích chọn (Checkbox) hay không
                    // Giả sử cột checkbox của bạn tên là "chkSelect"
                    if (row.Cells["chkSelect"].Value != null && (bool)row.Cells["chkSelect"].Value == true)
                    {
                        // Lấy các giá trị đã sửa từ các ô trên Grid
                        string maDoan = row.Cells["MaDoan"].Value.ToString();
                        string daiDien = row.Cells["DaiDienDoan"].Value.ToString();
                        int soNguoi = Convert.ToInt32(row.Cells["SoNguoi"].Value);
                        int soPhong = Convert.ToInt32(row.Cells["SoPhong"].Value);
                        DateTime ngayBD = Convert.ToDateTime(row.Cells["NgayBD"].Value);
                        DateTime ngayKT = Convert.ToDateTime(row.Cells["NgayKT"].Value);

                        // BƯỚC 3: Gọi Store Procedure để cập nhật vào Database
                        SqlParameter[] p = {
                    new SqlParameter("@MaDoan", maDoan),
                    new SqlParameter("@DaiDienDoan", daiDien),
                    new SqlParameter("@SoNguoi", soNguoi),
                    new SqlParameter("@SoPhong", soPhong),
                    new SqlParameter("@NgayBD", ngayBD),
                    new SqlParameter("@NgayKT", ngayKT)
                };

                        // Chạy lệnh Update (Giả sử hàm ExecuteSPNonQuery trả về số dòng bị ảnh hưởng)
                        dal.ExecuteSPNonQuery("sp_TT8_UpdateGiaoDich", p);
                        countSuccess++;
                    }
                }

                if (countSuccess > 0)
                {
                    MessageBox.Show($"Đã cập nhật thành công {countSuccess} giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // BƯỚC 4: Tắt chế độ sửa và nạp lại dữ liệu mới nhất từ SQL để đồng bộ
                    SetEditMode(false);
                    LoadDataGrid();
                }
                else
                {
                    MessageBox.Show("Vui lòng tích chọn ít nhất một giao dịch để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_TT8_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TT8_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}