using Microsoft.VisualBasic;
using QL_HolyBird.QuanTriVien.UC_con;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HolyBird
{
    public partial class UC_QTV_PhanQuyen : UserControl, ILocalizable
    {
        ServiceDAL logic = new ServiceDAL();

        public UC_QTV_PhanQuyen()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.UC_QTV_PhanQuyen_Load);
            pic_icon_QTV_Add.Click += btnThemQuyen_Click;
        }


        // Sự kiện khi UserControl được tải lên
        private void UC_QTV_PhanQuyen_Load(object sender, EventArgs e)
        {
            HienThiDSVaiTro();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            // Kiểm tra xem ngôn ngữ hiện tại có tồn tại không, nếu không thì fallback về Tiếng Việt
            if (!LanguageManager.Languages.ContainsKey(LanguageManager.CurrentLang))
                LanguageManager.CurrentLang = "Tiếng Việt";

            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];

            // Hàm con giúp lấy từ vựng an toàn (Nếu thiếu key thì hiện chính cái key đó ra để dễ sửa)
            string Get(string key) => lang.ContainsKey(key) ? lang[key] : $"[{key}]";

            // Gán dữ liệu an toàn
            lbPhanQuyen.Text = Get("PhanQuyen");
            lbVaiTro.Text = Get("DsVaiTro");
            btnThemQuyen.Text = Get("ThemVaiTro");

            // Dịch tiêu đề cột DataGridView (Cần kiểm tra cột có tồn tại không để tránh lỗi null)
            if (dgv_QTV_DSVaiTro.Columns["VaiTro"] != null)
                dgv_QTV_DSVaiTro.Columns["VaiTro"].HeaderText = Get("VaiTro");

            if (dgv_QTV_DSVaiTro.Columns["ChinhSua"] != null)
                dgv_QTV_DSVaiTro.Columns["ChinhSua"].HeaderText = Get("ChinhSua");

            if (dgv_QTV_DSVaiTro.Columns["Xoa"] != null)
                dgv_QTV_DSVaiTro.Columns["Xoa"].HeaderText = Get("Xoa");
        }

        // Hàm hiển thị dữ liệu lên DataGridView
        private void HienThiDSVaiTro()
        {
            try
            {
                dgv_QTV_DSVaiTro.AutoGenerateColumns = false;
                DataTable dt = logic.LayDSVaiTro();
                dgv_QTV_DSVaiTro.DataSource = dt;
                dgv_QTV_DSVaiTro.Columns["VaiTro"].DataPropertyName = "VaiTro";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện khi nhấn nút Thêm
        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            var lang = LanguageManager.Languages[LanguageManager.CurrentLang];

            string vaiTroMoi = Interaction.InputBox(lang["NhapTenVaiTro"], lang["ThemVaiTro"], "");

            if (!string.IsNullOrEmpty(vaiTroMoi.Trim()))
            {
                if (logic.ThemVaiTro(vaiTroMoi))
                {
                    // GỌI HÀM GHI LOG
                    logic.GhiNhatKy("Phân quyền", "Thêm vai trò: " + vaiTroMoi, "Thành công");

                    MessageBox.Show($"Đã tạo vai trò '{vaiTroMoi}' thành công bằng tài khoản mặc định!", "Thông báo");
                    HienThiDSVaiTro();
                }
                else
                {
                    MessageBox.Show("Không thể tạo vai trò. Có thể tên này đã tồn tại.");
                }
            }
        }

        // Xử lý các nút nhấn (Sửa/Xóa) trong DataGridView
        private void dgv_QTV_DSVaiTro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy tên vai trò ở dòng hiện tại (Cột có tên là 'VaiTro' hoặc index tương ứng)
            string tenVT = dgv_QTV_DSVaiTro.Rows[e.RowIndex].Cells["VaiTro"].Value.ToString();

            // 1. Nếu nhấn vào cột Xóa
            if (dgv_QTV_DSVaiTro.Columns[e.ColumnIndex].Name == "Xoa")
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa vai trò '{tenVT}'? \nLưu ý: Tất cả tài khoản thuộc vai trò này sẽ bị xóa!",
                                                      "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (logic.XoaVaiTro(tenVT))
                        {
                            // GỌI HÀM GHI LOG
                            logic.GhiNhatKy("Phân quyền", "Xóa vai trò: " + tenVT, "Thành công");

                            MessageBox.Show("Đã xóa vai trò!", "Thông báo");
                            HienThiDSVaiTro();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy vai trò để xóa hoặc vai trò đang có ràng buộc dữ liệu khác.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi hệ thống");
                    }
                }
            }

            // 2. Nếu nhấn vào cột Chỉnh sửa
            if (dgv_QTV_DSVaiTro.Columns[e.ColumnIndex].Name == "ChinhSua")
            {
                UC_QTV_ChiTietPhanQuyen ucChiTiet = new UC_QTV_ChiTietPhanQuyen(tenVT);

                Control parent = this.Parent;
                if (parent is Panel pnl)
                {
                    pnl.Controls.Clear();
                    ucChiTiet.Anchor = AnchorStyles.None;
                    ucChiTiet.Dock = DockStyle.Fill;
                    ucChiTiet.Left = (pnlContent.Width - ucChiTiet.Width) / 2;
                    ucChiTiet.Top = (pnlContent.Height - ucChiTiet.Height) / 2;
                    pnl.Controls.Add(ucChiTiet);
                }
            }
        }

    }
}
