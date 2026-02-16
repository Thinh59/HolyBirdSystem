using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_HolyBird
{
    public partial class TT_DK_GiaoDich : UserControl
    {
        ServiceDAL dal = new ServiceDAL();

        public TT_DK_GiaoDich()
        {
            InitializeComponent();
        }

        private void TT_DK_GiaoDich_Load(object sender, EventArgs e)
        {
            // 1. Thiết lập ngày mặc định
            dtp_TT1_NgayBD.Value = DateTime.Now;
            dtp_TT1_NgayKT.Value = DateTime.Now.AddDays(1);

            // Nếu chưa có user (chạy test), tự động gán là "nv_tieptan"
            if (string.IsNullOrEmpty(Session.Username))
            {
                Session.Username = "nv_tieptan";
            }
        }

        private void btn_TT1_XN_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập (Bỏ qua kiểm tra null cho ngày tháng vì DTP luôn có dữ liệu)
            if (string.IsNullOrWhiteSpace(txtBox_TT1_HoTen.Text) ||
                string.IsNullOrWhiteSpace(txtBox_TT1_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txtBox_TT1_SoNguoi.Text) ||
                string.IsNullOrWhiteSpace(txtBox_TT1_SoPhong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            // 2. Validate số liệu
            if (!int.TryParse(txtBox_TT1_SoNguoi.Text, out int soNguoi) || soNguoi <= 0)
            {
                MessageBox.Show("Số người phải là số nguyên dương!");
                return;
            }

            if (!int.TryParse(txtBox_TT1_SoPhong.Text, out int soPhong) || soPhong <= 0)
            {
                MessageBox.Show("Số phòng phải là số nguyên dương!");
                return;
            }

            // 3. Lấy dữ liệu ngày tháng từ DateTimePicker
            DateTime ngayBD = dtp_TT1_NgayBD.Value;
            DateTime ngayKT = dtp_TT1_NgayKT.Value;

            // Kiểm tra logic ngày: Ngày đi phải sau ngày đến
            // So sánh Date để bỏ qua phần giờ phút giây nếu cần thiết
            if (ngayKT.Date <= ngayBD.Date)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu ít nhất 1 ngày!");
                return;
            }

            // 4. Kiểm tra đăng nhập
            if (string.IsNullOrEmpty(Session.Username))
            {
                MessageBox.Show("Vui lòng đăng nhập (nhân viên) trước khi thực hiện!");
                return;
            }

            // ---------------------------------------------------------
            // PHẦN DEMO TRANH CHẤP (T2 - THÊM MỚI CHEN NGANG)
            // ---------------------------------------------------------
            if (checkBox_TT1_DM.Checked)
            {
                // Tạo dữ liệu giả lập
                string timeStr = DateTime.Now.ToString("HHmmss");
                string maDoan = "D" + timeStr.Substring(timeStr.Length - 5);
                string daiDien = txtBox_TT1_CCCD.Text.Trim();
                string userMoi = maDoan + daiDien;
                string hoTen = txtBox_TT1_HoTen.Text.Trim(); // Lấy họ tên để insert khách

                // Các thông tin mặc định
                string maNV = "NV01";
                string maDaiLy = "DL01";

                // --- SỬA LỖI TẠI ĐÂY: Insert Khách hàng trước ---
                // Phải gom tham số vào mảng new SqlParameter[] { ... }
                string sqlKhach = "IF NOT EXISTS (SELECT 1 FROM KHACHHANG WHERE CMND=@C) INSERT INTO KHACHHANG(CMND, HoTenKH) VALUES (@C, @HT)";

                SqlParameter[] pKhach = new SqlParameter[] {
            new SqlParameter("@C", daiDien),
            new SqlParameter("@HT", hoTen)
        };
                dal.ExecuteNonQuery(sqlKhach, pKhach); // <- Đã sửa: Truyền mảng tham số

                // --- Chuẩn bị tham số cho Procedure T2 ---
                MessageBox.Show($"DEMO T2: Tiếp tân đang thêm mới giao dịch đoàn {maDoan}...", "Thông báo Demo");

                SqlParameter[] p = {
            new SqlParameter("@MaDoan", maDoan),
            new SqlParameter("@DaiDienDoan", daiDien),
            new SqlParameter("@SoNguoi", int.Parse(txtBox_TT1_SoNguoi.Text)),
            new SqlParameter("@SoPhong", int.Parse(txtBox_TT1_SoPhong.Text)),
            new SqlParameter("@NgayBD", dtp_TT1_NgayBD.Value),
            new SqlParameter("@NgayKT", dtp_TT1_NgayKT.Value),
            new SqlParameter("@MaNV", maNV),
            new SqlParameter("@MaDaiLy", maDaiLy),
            new SqlParameter("@TenDangNhap", userMoi)
        };

                if (dal.ExecuteSPNonQuery("sp_TH10_T2_DangKyGiaoDich_TranhChap", p))
                {
                    MessageBox.Show("Thêm mới thành công! (Gây lỗi Phantom Read cho máy bên kia)");
                    ClearFields();
                }
                return;
            }

            // 5. Gọi ServiceDAL
            string ketQua = dal.TT1_TaoGiaoDich(
                Session.Username,
                txtBox_TT1_HoTen.Text.Trim(),
                txtBox_TT1_CCCD.Text.Trim(),
                soNguoi,
                soPhong,
                ngayBD,
                ngayKT
            );

            // 6. Xử lý kết quả
            if (ketQua.StartsWith("Thành công"))
            {
                MessageBox.Show(ketQua, "Đăng ký thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_TT1_Huy_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtBox_TT1_HoTen.Clear();
            txtBox_TT1_CCCD.Clear();
            txtBox_TT1_SoNguoi.Clear();
            txtBox_TT1_SoPhong.Clear();

            // Reset ngày tháng về hiện tại
            dtp_TT1_NgayBD.Value = DateTime.Now;
            dtp_TT1_NgayKT.Value = DateTime.Now.AddDays(1);
        }

        // --- CÁC SỰ KIỆN KHÔNG DÙNG TỚI HOẶC ĐỂ TRỐNG ---
        private void dtp_TT1_NgayBD_ValueChanged(object sender, EventArgs e) { }
        private void dtp_TT1_NgayKT_ValueChanged(object sender, EventArgs e) { }

        // Các sự kiện cũ (Nếu bạn đã xóa TextBox khỏi giao diện thiết kế thì có thể xóa các dòng dưới này)
        // Nếu chưa xóa event trong Design thì giữ lại để tránh lỗi
        private void lbl_TT1_SoPhong_Click(object sender, EventArgs e) { }
        private void lbl_CCCD_Click(object sender, EventArgs e) { }
        private void lbl_TT1_SoNguoi_Click(object sender, EventArgs e) { }
        private void lbl_TT1_HoTen_Click(object sender, EventArgs e) { }
        private void lbl_TT1_NgayBD_Click(object sender, EventArgs e) { }
        private void txtBox_TT1_CCCD_TextChanged(object sender, EventArgs e) { }
        private void txtBox_TT1_SoNguoi_TextChanged(object sender, EventArgs e) { }
        private void txtBox_TT1_HoTen_TextChanged(object sender, EventArgs e) { }
        private void txtBox_TT1_SoPhong_TextChanged(object sender, EventArgs e) { }

        // Hai cái textchanged cũ của ngày tháng (có thể xóa nếu đã xóa textbox)
        private void txtBox_TT1_NgayBD_TextChanged(object sender, EventArgs e) { }
        private void txtBox_TT1_NgayKT_TextChanged(object sender, EventArgs e) { }

        private void checkBox_TT1_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TT1_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}