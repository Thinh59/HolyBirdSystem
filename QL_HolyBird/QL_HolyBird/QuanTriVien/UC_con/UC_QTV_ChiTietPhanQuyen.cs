using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace QL_HolyBird.QuanTriVien.UC_con
{
    public partial class UC_QTV_ChiTietPhanQuyen : UserControl
    {
        ServiceDAL logic = new ServiceDAL();
        string vaiTroDangChon;

        // Constructor nhận tên vai trò
        public UC_QTV_ChiTietPhanQuyen(string tenVT)
        {
            InitializeComponent();
            this.vaiTroDangChon = tenVT;
            lbVaiTro.Text = tenVT;
            this.Load += new System.EventHandler(this.UC_QTV_ChiTietPhanQuyen_Load);
        }

        private void UC_QTV_ChiTietPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadQuyen();
        }

        private void LoadQuyen()
        {
            try
            {
                // 1. Lấy dữ liệu từ Logic
                var data = logic.LayQuyenTheoVaiTro(vaiTroDangChon);

                // 2. Kiểm tra nếu data null hoặc trống
                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu chức năng cho vai trò này.");
                    return;
                }

                // 3. Thiết lập GridView
                dgv_QTV_DSChucNang.AutoGenerateColumns = false; // Tắt tự tạo cột để dùng cột đã thiết kế
                dgv_QTV_DSChucNang.DataSource = null; // Reset
                dgv_QTV_DSChucNang.DataSource = data;

                // 4. Ánh xạ chính xác (Phải khớp 100% với tên thuộc tính trong class ChucNangQuyen)
                MappingColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message);
            }
        }

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            string tenCN = Interaction.InputBox("Nhập tên chức năng mới:", "Thêm chức năng", "");

            if (!string.IsNullOrWhiteSpace(tenCN))
            {
                var dsHienTai = dgv_QTV_DSChucNang.DataSource as List<ChucNangQuyen>;

                if (dsHienTai == null) dsHienTai = new List<ChucNangQuyen>();

                //if (dsHienTai != null)
                //{
                //    dsHienTai.Add(new ChucNangQuyen { ChucNang = tenCN, Xem = true, Sua = false, Xoa = false });

                //    dgv_QTV_DSChucNang.DataSource = null;
                //    dgv_QTV_DSChucNang.DataSource = dsHienTai;
                //    MessageBox.Show("Đã thêm chức năng: " + tenCN);
                //}

                dsHienTai.Add(new ChucNangQuyen { ChucNang = tenCN, Xem = true, Sua = false, Xoa = false });

                // Phải gán null trước khi gán lại để GridView nhận biết sự thay đổi
                dgv_QTV_DSChucNang.DataSource = null;
                dgv_QTV_DSChucNang.DataSource = dsHienTai;

                // Cập nhật lại thuộc tính hiển thị
                MappingColumns();
            }
        }

        private void MappingColumns()
        {
            if (dgv_QTV_DSChucNang.Columns.Count > 0)
            {
                dgv_QTV_DSChucNang.Columns["ChucNang"].DataPropertyName = "ChucNang";
                dgv_QTV_DSChucNang.Columns["Xem"].DataPropertyName = "Xem";
                dgv_QTV_DSChucNang.Columns["Sua"].DataPropertyName = "Sua";
                dgv_QTV_DSChucNang.Columns["Xoa"].DataPropertyName = "Xoa";
            }
        }

        // Xử lý nút Hủy - Quay lại danh sách vai trò
        private void btnHuy_Click(object sender, EventArgs e)
        {
            UC_QTV_PhanQuyen ucDanhSach = new UC_QTV_PhanQuyen();
            Control parent = this.Parent;
            if (parent is Panel pnl)
            {
                pnl.Controls.Clear();
                pnl.Controls.Add(ucDanhSach);
                ucDanhSach.Anchor = AnchorStyles.None;
                ucDanhSach.Dock = DockStyle.Fill;
                ucDanhSach.Left = (pnlContent.Width - ucDanhSach.Width) / 2;
                ucDanhSach.Top = (pnlContent.Height - ucDanhSach.Height) / 2;
            }
        }

        // Xử lý nút Lưu thay đổi
        private void btnLuu_Click(object sender, EventArgs e)
        {
            dgv_QTV_DSChucNang.EndEdit();

            List<ChucNangQuyen> dsSauChinhSua = (List<ChucNangQuyen>)dgv_QTV_DSChucNang.DataSource;

            logic.LuuThayDoiQuyen(this.vaiTroDangChon, dsSauChinhSua);

            MessageBox.Show("Lưu phân quyền thành công!");
        }
    }
}
