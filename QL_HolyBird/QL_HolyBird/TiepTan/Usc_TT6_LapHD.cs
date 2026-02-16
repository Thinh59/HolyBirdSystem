using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_HolyBird
{
    public partial class Usc_TT6_LapHD : UserControl
    {
        ServiceDAL dal = new ServiceDAL();
        decimal tongTienHĐ = 0;

        public Usc_TT6_LapHD()
        {
            InitializeComponent();
        }

        private void Usc_TT6_LapHD_Load(object sender, EventArgs e)
        {
            LoadCmbDoan();
            txtBox_TT6_NgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Lấy mã nhân viên từ Session đã lưu lúc đăng nhập
            if (!string.IsNullOrEmpty(Session.MaNV))
            {
                txtBox_TT6_NVLap.Text = Session.MaNV;
            }
            else
            {
                txtBox_TT6_NVLap.Text = "NV01"; // Hoặc bắt buộc đăng nhập lại
            }
        }

        private void LoadCmbDoan()
        {
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT6_GetDoanChoLapHD");
            cmb_TT6_MaDoan.DataSource = dt;
            cmb_TT6_MaDoan.DisplayMember = "HienThi";
            cmb_TT6_MaDoan.ValueMember = "MaDoan";
            cmb_TT6_MaDoan.SelectedIndex = -1;
        }

        private void cmb_TT6_MaDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TT6_MaDoan.SelectedValue != null && cmb_TT6_MaDoan.Focused)
            {
                string maDoan = cmb_TT6_MaDoan.SelectedValue.ToString();
                txtBox_TT6_MaDoanHD.Text = maDoan;

                try
                {
                    // --- 1. LẤY DỮ LIỆU GRID (Gồm CCCD từ CT_GIAODICH) ---
                    SqlParameter[] p1 = { new SqlParameter("@MaDoan", maDoan) };
                    DataTable dtGrid = dal.ExecuteStoredProcedure("sp_TT6_GetFullInvoiceData", p1);
                    dgv_TT6_HoaDon.DataSource = dtGrid;

                    // Tính tổng tiền
                    tongTienHĐ = 0;
                    foreach (DataRow row in dtGrid.Rows)
                    {
                        tongTienHĐ += Convert.ToDecimal(row["ThanhTien"]);
                    }
                    txtBox_TT6_TongTien.Text = tongTienHĐ.ToString("N0");

                    // --- 2. LẤY SDT KHÁCH HÀNG ---
                    SqlParameter[] p2 = { new SqlParameter("@MaDoan", maDoan) };
                    // Sửa SQL này dùng đúng tên cột SDT_KH và CMND của bạn
                    string sqlSDT = "SELECT k.SDT_KH FROM GIAODICH g JOIN KHACHHANG k ON g.DaiDienDoan = k.CMND WHERE g.MaDoan = @MaDoan";
                    DataTable dtSDT = dal.GetDataTable(sqlSDT, p2);

                    txtBox_TT6_MaHD.Text = "HD" + DateTime.Now.ToString("mmss");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị: " + ex.Message);
                }
            }
        }

        private void btn_TT6_CTPPS_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có đang chọn dòng nào trên Grid không
            if (dgv_TT6_HoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phòng trên danh sách!");
                return;
            }

            // Lấy MaCTGD của dòng đang chọn
            string maCTGD = dgv_TT6_HoaDon.CurrentRow.Cells["MaCTGD"].Value.ToString();
            SqlParameter[] p = { new SqlParameter("@MaCTGD", maCTGD) };

            // Gọi SP lấy chi tiết phí
            DataTable dt = dal.ExecuteStoredProcedure("sp_TT6_GetChiTietPPS", p);

            if (dt.Rows.Count > 0)
            {
                string msg = $"CHI TIẾT PHÍ PHÁT SINH PHÒNG {maCTGD}:\n\n";
                foreach (DataRow r in dt.Rows)
                {
                    msg += $"- {r["TenPPS"]}: {r["SoLuong"]} cái | Thành tiền: {Convert.ToDecimal(r["ThanhTienPPS"]):N0} VND\n";
                }
                MessageBox.Show(msg, "Chi Tiết Phí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Phòng này không có phí phát sinh nào.", "Thông báo");
            }
        }

        private void txtBox_TT6_SDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_TT6_TimMaHD_Click(object sender, EventArgs e)
        {
            // Lấy thông tin cơ bản
            string maHD = txtBox_TT6_MaHD.Text;
            string maDoan = cmb_TT6_MaDoan.SelectedValue.ToString();
            string maNV = txtBox_TT6_NVLap.Text;
            decimal tongTien = tongTienHĐ;

            try
            {
                // KIỂM TRA NẾU NGƯỜI DÙNG CHỌN CHẾ ĐỘ DEMO LỖI
                if (checkBox_TT6_DM.Checked && cbBox_TT6_DemoGiaiQuyet.Text == "Demo")
                {
                    // Truyền ngày ở tương lai (năm 2031) để chắc chắn gây lỗi logic và bị Rollback
                    DateTime ngayLoi = DateTime.Now.AddYears(5);

                    SqlParameter[] p = {
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@MaDoan", maDoan),
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@TongTien", tongTien),
                new SqlParameter("@NgayLapLoi", ngayLoi)
            };

                    MessageBox.Show("Đang chạy DEMO LỖI (T1). Hệ thống sẽ dừng 15 giây...", "Thông báo Demo");

                    // Gọi Procedure gây lỗi Dirty Read
                    // Sửa dòng này:
                    int result = Convert.ToInt32(dal.ExecuteStoredProcedureWithReturnValue("sp_TH9_T1_GayLoiDirtyRead", p));
                    if (result == 2)
                        MessageBox.Show("Giao tác đã bị ROLLBACK do ngày không hợp lệ. Kết thúc Demo!", "Thông báo hệ thống");
                }
                else
                {
                    // CHẠY CHỨC NĂNG LẬP HÓA ĐƠN BÌNH THƯỜNG (Code nãy giờ bạn dùng)
                    SqlParameter[] pNormal = {
                new SqlParameter("@MaHD", maHD),
                new SqlParameter("@MaDoan", maDoan),
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@TongTien", tongTien)
            };

                    if (dal.ExecuteSPNonQuery("sp_TT6_XacNhanLapHD", pNormal))
                    {
                        MessageBox.Show("Lập hóa đơn thành công (Chế độ bình thường)!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message);
            }
        }

        private void cbBox_TT6_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}