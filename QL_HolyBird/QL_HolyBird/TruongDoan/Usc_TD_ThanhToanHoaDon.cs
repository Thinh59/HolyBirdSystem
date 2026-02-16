using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_HolyBird
{
    public partial class Usc_TD_ThanhToanHoaDon : UserControl
    {
        ServiceDAL dal = new ServiceDAL();
        string currentMaDoan = "";

        public Usc_TD_ThanhToanHoaDon()
        {
            InitializeComponent();
            this.Load += Usc_TD_ThanhToanHoaDon_Load;
        }

        private void Usc_TD_ThanhToanHoaDon_Load(object sender, EventArgs e)
        {
            DisableAllTextBoxes();

            // Nạp danh sách lựa chọn Demo
            cbBox_TD_DemoGiaiQuyet.Items.Clear();
            // Không cần "Normal" vì bỏ tích CheckBox là Normal rồi
            cbBox_TD_DemoGiaiQuyet.Items.Add("Demo TH3");        // Lỗi Rollback
            cbBox_TD_DemoGiaiQuyet.Items.Add("Demo TH8");        // Lỗi Sai tiền (Dirty Read)
            cbBox_TD_DemoGiaiQuyet.Items.Add("TH8 Giải quyết");  // Chờ Commit (Read Committed)

            cbBox_TD_DemoGiaiQuyet.SelectedIndex = 0; // Chọn mặc định cái đầu

            LoadThongTinHoaDonDoan();
        }

        private void DisableAllTextBoxes()
        {
            txtBox_TD_MaHD.Enabled = false;
            txtBox_TD_MaDoanHD.Enabled = false;
            txtBox_TD_NVLap.Enabled = false;
            txtBox_TD_NgayLap.Enabled = false;
            txtBox_TD_TongTien.Enabled = false;
            txb_TD_MaDoan.Enabled = false;
        }

        private void LoadThongTinHoaDonDoan()
        {
            MessageBox.Show("User đang login: " + Session.TenDangNhap);
            try
            {
                // Lấy MaDoan từ Session (Tài khoản đang đăng nhập gắn với GIAODICH)
                // Giả sử SessionData.TenDangNhap chứa mã định danh tài khoản đoàn
                string queryMaDoan = "SELECT MaDoan FROM GIAODICH WHERE TenDangNhap = @User";
                DataTable dtDoan = dal.GetDataTable(queryMaDoan, new[] { new SqlParameter("@User", Session.TenDangNhap) });

                if (dtDoan.Rows.Count > 0)
                {
                    currentMaDoan = dtDoan.Rows[0]["MaDoan"].ToString();
                    txb_TD_MaDoan.Text = currentMaDoan;

                    // Lấy thông tin hóa đơn "Chờ thanh toán" của đoàn này
                    string sqlHD = "SELECT * FROM HOADON WHERE MaDoan = @MaDoan AND TrangThaiHD = N'Chờ thanh toán'";
                    DataTable dtHD = dal.GetDataTable(sqlHD, new[] { new SqlParameter("@MaDoan", currentMaDoan) });

                    if (dtHD.Rows.Count > 0)
                    {
                        DataRow r = dtHD.Rows[0];
                        txtBox_TD_MaHD.Text = r["MaHD"].ToString();
                        txtBox_TD_MaDoanHD.Text = r["MaDoan"].ToString();
                        txtBox_TD_NVLap.Text = r["NVLap"].ToString();
                        txtBox_TD_NgayLap.Text = Convert.ToDateTime(r["NgayLap"]).ToString("dd/MM/yyyy");
                        txtBox_TD_TongTien.Text = Convert.ToDecimal(r["TongTien"]).ToString("N0") + " VND";

                        // Load chi tiết các phòng lên Grid
                        SqlParameter[] pGrid = { new SqlParameter("@MaDoan", currentMaDoan) };
                        dgv_TD_HoaDon.DataSource = dal.ExecuteStoredProcedure("sp_TT6_GetFullInvoiceData", pGrid);

                        btn_TD_ThanhToan.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Đoàn hiện không có hóa đơn nào chờ thanh toán.", "Thông báo");
                        btn_TD_ThanhToan.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void btn_TD_ThanhToan_Click(object sender, EventArgs e)
        {
            string maHD = txtBox_TD_MaHD.Text;
            if (string.IsNullOrEmpty(maHD)) return;

            if (checkBox_TD_DM.Checked)
            {
                string luaChon = cbBox_TD_DemoGiaiQuyet.Text;

                if (luaChon == "Demo TH3")
                {
                    MessageBox.Show("DEMO TH3: Hệ thống cập nhật trạng thái 'Đã thanh toán' (Chưa Commit) rồi Rollback.\n(Treo 15s)...", "Thông báo Demo");

                    SqlParameter[] p = { new SqlParameter("@MaHD", maHD) };

                    int res = dal.ExecuteStoredProcedureWithReturnValue("sp_TH3_T1_ThanhToan_TranhChap", p);

                    if (res == 2)
                    {
                        MessageBox.Show("Hệ thống phát hiện lỗi logic ngày tháng!\nĐã ROLLBACK trạng thái về 'Chờ thanh toán'.", "Kết quả TH3");
                        LoadThongTinHoaDonDoan();
                    }
                    return; 
                }

                else if (luaChon == "Demo TH8" || luaChon == "TH8 Giải quyết")
                {
                    int isFix = (luaChon == "TH8 Giải quyết") ? 1 : 0;

                    if (isFix == 1)
                        MessageBox.Show("TH8 GIẢI QUYẾT: Hệ thống sẽ TREO MÁY để chờ Quản lý nhập xong giá.", "Thông báo Fix");
                    else
                        MessageBox.Show("DEMO TH8 (LỖI): Hệ thống đọc ngay dữ liệu bẩn (kể cả chưa Commit).", "Thông báo Lỗi");

                    SqlParameter[] pCheck = {
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@IsFix", isFix)
            };

                    DataTable dt = dal.ExecuteStoredProcedure("sp_TH8_T1_XemHoaDon_TranhChap", pCheck);

                    decimal currentTotal = 0;
                    if (dt.Rows.Count > 0)
                        currentTotal = Convert.ToDecimal(dt.Rows[0]["TongTienThanhToan"]);

                    string msg = $"Tổng tiền hệ thống ghi nhận: {currentTotal:N0} VNĐ.\n\nBạn có chắc chắn muốn thanh toán?";
                    DialogResult dr = MessageBox.Show(msg, "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                   
                }
            }

            if (!checkBox_TD_DM.Checked)
            {
                if (MessageBox.Show("Xác nhận thanh toán hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            SqlParameter[] pPay = {
        new SqlParameter("@MaHD", maHD),
        new SqlParameter("@MaDoan", currentMaDoan)
    };

            if (dal.ExecuteSPNonQuery("sp_TD_ThanhToanHoaDon", pPay))
            {
                MessageBox.Show("Thanh toán thành công!", "Thành công");
                txtBox_TD_MaHD.Clear();
                txtBox_TD_TongTien.Clear();
                dgv_TD_HoaDon.DataSource = null;
                btn_TD_ThanhToan.Enabled = false;
                LoadThongTinHoaDonDoan(); 
            }
        }

        private void btn_TD_CTPPS_Click(object sender, EventArgs e)
        {
            if (dgv_TD_HoaDon.CurrentRow == null) return;

            string maCTGD = dgv_TD_HoaDon.CurrentRow.Cells["MaCTGD"].Value.ToString();
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT6_GetChiTietPPS", new[] { new SqlParameter("@MaCTGD", maCTGD) });

            if (dt.Rows.Count > 0)
            {
                string msg = $"CHI TIẾT PHÍ PHÁT SINH PHÒNG {maCTGD}:\n\n";
                foreach (DataRow r in dt.Rows)
                    msg += $"- {r["TenPPS"]}: {r["SoLuong"]} cái | {Convert.ToDecimal(r["ThanhTienPPS"]):N0} VND\n";
                MessageBox.Show(msg, "Chi Tiết Phí");
            }
            else MessageBox.Show("Phòng này không có phí phát sinh (hư hại/dịch vụ).", "Thông báo");
        }

        private void cbBox_TD_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_TD_DM_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}