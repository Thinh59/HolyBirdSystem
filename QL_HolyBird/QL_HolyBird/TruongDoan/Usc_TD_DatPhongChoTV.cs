using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QL_HolyBird
{
    public partial class Usc_TD_DatPhongChoTV : UserControl
    {
        ServiceDAL dal = new ServiceDAL();
        DataTable dtChiTietTam = new DataTable();

        public Usc_TD_DatPhongChoTV()
        {
            InitializeComponent();
            InitTableTam();
            this.Load += Usc_TD_DatPhongChoTV_Load;
        }

        private void Usc_TD_DatPhongChoTV_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session.MaDoan))
            {
                TD_DP_MaDoan.Text = Session.MaDoan;
                TD_DP_MaDoan.Enabled = false;

                // Load thông tin từ Database
                DataTable dtGD = dal.TD_GetThongTinGiaoDich(Session.MaDoan);
                if (dtGD.Rows.Count > 0)
                {
                    lbl_SoNguoi.Text = dtGD.Rows[0]["SoNguoi"].ToString();
                    lbl_SoPhong.Text = dtGD.Rows[0]["SoPhong"].ToString();

                    // Set ngày mặc định theo GIAODICH
                    DateTime ngayBD = Convert.ToDateTime(dtGD.Rows[0]["NgayBD"]);
                    DateTime ngayKT = Convert.ToDateTime(dtGD.Rows[0]["NgayKT"]);

                    dtp_TT4_NgayCapThe.Value = ngayBD;
                    dtp_TT4_NgayHetHan.Value = ngayKT;

                    // Ràng buộc giới hạn lịch không cho chọn ngoài khoảng của đoàn
                    dtp_TT4_NgayCapThe.MinDate = ngayBD;
                    dtp_TT4_NgayCapThe.MaxDate = ngayKT;
                    dtp_TT4_NgayHetHan.MinDate = ngayBD;
                    dtp_TT4_NgayHetHan.MaxDate = ngayKT;
                }
            }
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Load Tầng
                cmb_DP_Tang.DataSource = dal.LayDS_Tang();
                cmb_DP_Tang.DisplayMember = "Tang";
                cmb_DP_Tang.ValueMember = "Tang";
                cmb_DP_Tang.SelectedIndex = -1; // Mặc định chưa chọn gì

                // Load Hạng
                cmb_DP_HangPhong.DataSource = dal.LayDS_Hang();
                cmb_DP_HangPhong.DisplayMember = "Hang";
                cmb_DP_HangPhong.ValueMember = "Hang";
                cmb_DP_HangPhong.SelectedIndex = -1;

                // Load Hình Thức
                cmb_DP_HinhThuc.DataSource = dal.LayDS_HinhThuc();
                cmb_DP_HinhThuc.DisplayMember = "HinhThuc";
                cmb_DP_HinhThuc.ValueMember = "HinhThuc";
                cmb_DP_HinhThuc.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi nạp danh mục: " + ex.Message); }
        }

        private void InitTableTam()
        {
            dtChiTietTam.Columns.Add("MaPhong", typeof(int));
            dtChiTietTam.Columns.Add("CMND", typeof(string));
            dtChiTietTam.Columns.Add("CaNhan", typeof(string)); // Cột mới lưu Họ tên
            dtChiTietTam.Columns.Add("Hang", typeof(string));
            dtChiTietTam.Columns.Add("Gia", typeof(decimal));
            dgv_DP_CTGDDaThem.DataSource = dtChiTietTam;
        }

        // 4. Nút XÁC NHẬN: Kiểm tra ràng buộc và lưu chính thức
        private void btn_TD_DP_XacNhan_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra bảng tạm có dữ liệu không
            if (dtChiTietTam.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm thành viên và phòng vào danh sách trước khi xác nhận!");
                return;
            }

            // -----------------------------------------------------------
            // PHẦN DEMO TRANH CHẤP (PHANTOM READ)
            // -----------------------------------------------------------
            if (checkBox_TD_DM.Checked)
            {
                // Lấy dữ liệu THẬT từ dòng đầu tiên trong danh sách bạn vừa thêm
                DataRow r = dtChiTietTam.Rows[0];

                // Tạo mã CTGD xịn như bình thường
                string newMaCTGD = "CT" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                string maDoan = TD_DP_MaDoan.Text;

                MessageBox.Show($"DEMO T2: Đang thực hiện đặt phòng {r["MaPhong"]} cho khách {r["CaNhan"]}...", "Thông báo Demo");

                SqlParameter[] p = {
            new SqlParameter("@MaCTGD", newMaCTGD),
            new SqlParameter("@MaDoan", maDoan),
            new SqlParameter("@MaPhong", r["MaPhong"]),
            new SqlParameter("@CMND", r["CMND"]),
            new SqlParameter("@HoTen", r["CaNhan"]),
            new SqlParameter("@NgayBD", dtp_TT4_NgayCapThe.Value),
            new SqlParameter("@NgayKT", dtp_TT4_NgayHetHan.Value),
            new SqlParameter("@Gia", r["Gia"])
        };

                // Gọi Procedure T2 (Vừa Insert giao dịch, vừa Update trạng thái phòng)
                if (dal.ExecuteSPNonQuery("sp_TH4_T2_DatPhong_TranhChap", p))
                {
                    MessageBox.Show("Đã đặt phòng thành công (Gây lỗi Phantom Read cho máy bên kia)!", "Kết quả Demo");
                    dtChiTietTam.Clear();
                }
                return; // Kết thúc, không chạy xuống phần code thường
            }

            // -----------------------------------------------------------
            // PHẦN LƯU BÌNH THƯỜNG (Logic cũ của bạn)
            // -----------------------------------------------------------
            string maDoanNormal = TD_DP_MaDoan.Text;

            // Kiểm tra ràng buộc
            HashSet<int> dsPhongMoi = new HashSet<int>();
            foreach (DataRow r in dtChiTietTam.Rows) { dsPhongMoi.Add((int)r["MaPhong"]); }

            // Lấy thời gian từ giao diện
            DateTime ngayBD = dtp_TT4_NgayCapThe.Value;
            DateTime ngayKT = dtp_TT4_NgayHetHan.Value;

            // Gọi hàm kiểm tra với ĐẦY ĐỦ 5 THAM SỐ
            // Lưu ý: maDoanNormal phải có giá trị (lấy từ TextBox TD_DP_MaDoan.Text)
            string checkRes = dal.TD_KiemTraRangBuoc(maDoanNormal, dsPhongMoi.Count, dtChiTietTam.Rows.Count, ngayBD, ngayKT);

            if (checkRes != "OK")
            {
                MessageBox.Show(checkRes, "Ràng buộc không thỏa");
                return;
            }

            try
            {
                foreach (DataRow r in dtChiTietTam.Rows)
                {
                    string newMaCTGD = "CT" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                    // Câu lệnh SQL gốc của bạn (Chỉ Insert, chưa Update trạng thái phòng ở đây -> Đây là lý do bình thường nó ko update phòng)
                    // LƯU Ý: Ở chế độ thường, bạn cũng nên Update trạng thái phòng thành 'Đang đặt trước' để đồng bộ.
                    string sqlLuu = @"
                INSERT INTO CT_GIAODICH (MaCTGD, MaDoan, MaPhong, CMND, CaNhan, NgayBD, NgayKT, ThanhTien, TrangThaiGD) 
                VALUES (@MaCTGD, @MaDoan, @MaP, @CMND, @HoTen, @BD, @KT, @Gia, N'Chưa nhận phòng');
                
                UPDATE PHONG SET TrangThai = N'Đang đặt trước' WHERE MaPhong = @MaP; -- Thêm dòng này để chế độ thường cũng đúng logic
            ";

                    SqlParameter[] p = {
                new SqlParameter("@MaCTGD", newMaCTGD),
                new SqlParameter("@MaDoan", maDoanNormal),
                new SqlParameter("@MaP", r["MaPhong"]),
                new SqlParameter("@CMND", r["CMND"]),
                new SqlParameter("@HoTen", r["CaNhan"]),
                new SqlParameter("@BD", dtp_TT4_NgayCapThe.Value),
                new SqlParameter("@KT", dtp_TT4_NgayHetHan.Value),
                new SqlParameter("@Gia", r["Gia"])
            };
                    dal.ExecuteNonQuery(sqlLuu, p);
                }

                MessageBox.Show("Đặt phòng chính thức thành công!", "Thông báo");
                dtChiTietTam.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lưu: " + ex.Message, "Thông báo lỗi");
            }
        }

        private void btn_DP_Tim_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cmb_DP_Tang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Tầng!");
                return;
            }

            // Gọi hàm lấy DS phòng trống của Đoàn dựa trên Mã đoàn trong Session
            dgv_DP_DSPhongThoa.DataSource = dal.TD_LayDSPhongTrong(
                Session.MaDoan, // Truyền Mã đoàn từ Session
                cmb_DP_HangPhong.Text,
                cmb_DP_HinhThuc.Text,
                cmb_DP_Tang.Text
            );
        }

        private void btn_DP_Them_Click(object sender, EventArgs e)
        {
            if (dgv_DP_DSPhongThoa.CurrentRow == null) return;

            string cmnd = txtBox_TT1_SoNguoi.Text.Trim();
            string hoTen = txb_TD_HoTen.Text.Trim();

            // 1. Ràng buộc CMND 12 số
            if (cmnd.Length != 12 || !long.TryParse(cmnd, out _))
            {
                MessageBox.Show("Số CMND/CCCD không hợp lệ! Vui lòng nhập đúng 12 chữ số.", "Lỗi");
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ tên thành viên!");
                return;
            }

            // 2. Lấy thông tin phòng đang chọn từ lưới tìm kiếm
            int maPhong = (int)dgv_DP_DSPhongThoa.CurrentRow.Cells["MaPhong"].Value;
            int sucChuaToiDa = (int)dgv_DP_DSPhongThoa.CurrentRow.Cells["SucChuaToiDa"].Value;

            // 3. Kiểm tra trùng CMND trong danh sách tạm
            foreach (DataRow r in dtChiTietTam.Rows)
            {
                if (r["CMND"].ToString() == cmnd)
                {
                    MessageBox.Show("Thành viên này đã có trong danh sách!");
                    return;
                }
            }

            // 4. KIỂM TRA SỨC CHỨA: Đếm xem mã phòng này đã xuất hiện bao nhiêu lần trong bảng tạm
            int soNguoiDaThemVaoPhongNay = 0;
            foreach (DataRow r in dtChiTietTam.Rows)
            {
                if ((int)r["MaPhong"] == maPhong) soNguoiDaThemVaoPhongNay++;
            }

            if (soNguoiDaThemVaoPhongNay >= sucChuaToiDa)
            {
                MessageBox.Show($"Phòng {maPhong} chỉ chứa tối đa {sucChuaToiDa} người!", "Hết chỗ");
                return;
            }

            // 5. Thêm vào bảng tạm
            DataRow newRow = dtChiTietTam.NewRow();
            newRow["MaPhong"] = maPhong;
            newRow["CMND"] = cmnd;
            newRow["CaNhan"] = hoTen;
            newRow["Hang"] = dgv_DP_DSPhongThoa.CurrentRow.Cells["Hang"].Value;
            newRow["Gia"] = dgv_DP_DSPhongThoa.CurrentRow.Cells["MucGia"].Value;
            dtChiTietTam.Rows.Add(newRow);

            txtBox_TT1_SoNguoi.Clear();
            txb_TD_HoTen.Clear();
        }

        private void btn_DP_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_DP_CTGDDaThem.CurrentRow != null)
            {
                dgv_DP_CTGDDaThem.Rows.Remove(dgv_DP_CTGDDaThem.CurrentRow);
            }
        }

        private void btn_TT1_Huy_Click(object sender, EventArgs e)
        {
            dtChiTietTam.Clear();
        }

        private void TD_DP_MaDoan_Click(object sender, EventArgs e)
        {

        }

        private void txb_TD_HoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_SoNguoi_Click(object sender, EventArgs e)
        {

        }

        private void lbl_SoPhong_Click(object sender, EventArgs e)
        {

        }

        private void dtp_TT4_NgayCapThe_ValueChanged(object sender, EventArgs e)
        {
            // Đảm bảo ngày kết thúc không nhỏ hơn ngày bắt đầu khi người dùng sửa
            if (dtp_TT4_NgayHetHan.Value < dtp_TT4_NgayCapThe.Value)
            {
                dtp_TT4_NgayHetHan.Value = dtp_TT4_NgayCapThe.Value;
            }
        }

        private void dtp_TT4_NgayHetHan_ValueChanged(object sender, EventArgs e)
        {
            // Tự động tìm lại phòng khi khách thay đổi thời gian thuê
            if (cmb_DP_Tang.SelectedIndex != -1)
            {
                btn_DP_Tim_Click(null, null);
            }
        }

        private void checkBox_TD_DM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_TD_DemoGiaiQuyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}