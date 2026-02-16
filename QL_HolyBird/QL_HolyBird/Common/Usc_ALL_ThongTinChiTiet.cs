using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HolyBird
{
    public partial class Usc_ALL_ThongTinChiTiet : UserControl
    {
        // Gọi ServiceDAL thay vì AccountDAL hay DataConnection
        ServiceDAL dal = new ServiceDAL();

        public Usc_ALL_ThongTinChiTiet()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form Load
        private void Usc_ALL_ThongTinChiTiet_Load(object sender, EventArgs e)
        {
            // --- PHẦN GIẢ LẬP ĐĂNG NHẬP (Dùng để test khi chưa có form Login) ---
            // Sau này làm xong Login thì comment hoặc xóa dòng dưới này đi
            if (string.IsNullOrEmpty(Session.Username))
            {
                Session.Username = "nv_tieptan"; // Giả bộ đang đăng nhập là Tiếp tân Lê
                                                     // SessionData.Username = "kh_nguyena"; // Mở dòng này nếu muốn test là Khách hàng A
            }
            // ---------------------------------------------------------------------

            if (string.IsNullOrEmpty(Session.Username))
            {
                MessageBox.Show("Chưa có thông tin đăng nhập!");
                return;
            }

            LoadData();
            SetEditMode(false);
        }

        private void LoadData()
        {
            // Gọi hàm đã viết sẵn trong ServiceDAL
            DataTable dt = dal.GetThongTinCaNhan(Session.Username);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txb_ALL3_Username.Text = row["TenDangNhap"].ToString();
                txtBox_HoTen.Text = row["HoTen"].ToString();
                txtBox_Email.Text = row["Email"].ToString();
                txtBox_SDT.Text = row["SDT"].ToString();

                if (row["NgaySinh"] != DBNull.Value)
                    txtBox_NgaySinh.Text = Convert.ToDateTime(row["NgaySinh"]).ToString("dd/MM/yyyy");
                else
                    txtBox_NgaySinh.Text = "";
            }
        }

        // Hàm bật tắt chế độ sửa
        private void SetEditMode(bool isEditing)
        {
            txb_ALL3_Username.ReadOnly = true; // Luôn chặn sửa username

            txtBox_HoTen.ReadOnly = !isEditing;
            txtBox_Email.ReadOnly = !isEditing;
            txtBox_NgaySinh.ReadOnly = !isEditing;
            txtBox_SDT.ReadOnly = !isEditing;

            btn_SuaThongTin.Visible = !isEditing;
            btn_ALL3_XacNhan.Visible = isEditing;
            btn_ALL3_Huy.Visible = isEditing;
        }

        private void btn_SuaThongTin_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
            txtBox_HoTen.Focus();
        }

        private void btn_ALL3_Huy_Click(object sender, EventArgs e)
        {
            LoadData(); // Load lại dữ liệu cũ
            SetEditMode(false);
        }

        private void btn_ALL3_XacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBox_HoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!");
                return;
            }

            DateTime ngaySinh;
            if (!DateTime.TryParse(txtBox_NgaySinh.Text, out ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ! (Định dạng: dd/MM/yyyy)");
                return;
            }

            // Gọi hàm Update trong ServiceDAL
            bool ketQua = dal.UpdateThongTinCaNhan(
                Session.Username,
                txtBox_HoTen.Text.Trim(),
                ngaySinh,
                txtBox_SDT.Text.Trim(),
                txtBox_Email.Text.Trim()
            );

            if (ketQua)
            {
                MessageBox.Show("Cập nhật thành công!");
                SetEditMode(false);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        // Gắn sự kiện Load vào OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Usc_ALL_ThongTinChiTiet_Load(this, e);
        }

        // Các sự kiện thừa
        private void txtBox_HoTen_TextChanged(object sender, EventArgs e) { }
        private void txtBox_Email_TextChanged(object sender, EventArgs e) { }
        private void txtBox_NgaySinh_TextChanged(object sender, EventArgs e) { }
        private void txtBox_SDT_TextChanged(object sender, EventArgs e) { }
        private void pnl_ALL_Dashboard_Paint(object sender, PaintEventArgs e) { }
        private void txb_ALL3_Username_TextChanged(object sender, EventArgs e) { }
    }
}