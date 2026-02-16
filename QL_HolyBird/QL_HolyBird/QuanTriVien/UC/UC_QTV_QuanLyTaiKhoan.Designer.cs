namespace QL_HolyBird
{
    partial class UC_QTV_QuanLyTaiKhoan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QTV_QuanLyTaiKhoan));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgv_QTV_DSVaiTro = new System.Windows.Forms.DataGridView();
            this.TenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatLaiMatKhau = new System.Windows.Forms.DataGridViewButtonColumn();
            this.KhoaTaiKhoan = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.textBox_TimKiem = new System.Windows.Forms.TextBox();
            this.btnThemTK = new System.Windows.Forms.Button();
            this.pic_icon_QTV_TaiKhoanHeThong = new System.Windows.Forms.PictureBox();
            this.lbTKHT = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QTV_DSVaiTro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_TaiKhoanHeThong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlContent.Controls.Add(this.dgv_QTV_DSVaiTro);
            this.pnlContent.Controls.Add(this.btn_TimKiem);
            this.pnlContent.Controls.Add(this.textBox_TimKiem);
            this.pnlContent.Controls.Add(this.btnThemTK);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_TaiKhoanHeThong);
            this.pnlContent.Controls.Add(this.lbTKHT);
            this.pnlContent.Controls.Add(this.btnLuu);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.TabIndex = 8;
            // 
            // dgv_QTV_DSVaiTro
            // 
            this.dgv_QTV_DSVaiTro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_QTV_DSVaiTro.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_QTV_DSVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_QTV_DSVaiTro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_QTV_DSVaiTro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_QTV_DSVaiTro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_QTV_DSVaiTro.ColumnHeadersHeight = 35;
            this.dgv_QTV_DSVaiTro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenDangNhap,
            this.LoaiTK,
            this.NgayTao,
            this.TrangThai,
            this.DatLaiMatKhau,
            this.KhoaTaiKhoan});
            this.dgv_QTV_DSVaiTro.GridColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_QTV_DSVaiTro.Location = new System.Drawing.Point(70, 170);
            this.dgv_QTV_DSVaiTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_QTV_DSVaiTro.Name = "dgv_QTV_DSVaiTro";
            this.dgv_QTV_DSVaiTro.RowHeadersVisible = false;
            this.dgv_QTV_DSVaiTro.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_QTV_DSVaiTro.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_QTV_DSVaiTro.RowTemplate.Height = 28;
            this.dgv_QTV_DSVaiTro.Size = new System.Drawing.Size(881, 357);
            this.dgv_QTV_DSVaiTro.TabIndex = 46;
            this.dgv_QTV_DSVaiTro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QTV_DSVaiTro_CellContentClick);
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenDangNhap.HeaderText = "Tên đăng nhập";
            this.TenDangNhap.MinimumWidth = 8;
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.Width = 133;
            // 
            // LoaiTK
            // 
            this.LoaiTK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LoaiTK.HeaderText = "Loại tài khoản";
            this.LoaiTK.MinimumWidth = 8;
            this.LoaiTK.Name = "LoaiTK";
            this.LoaiTK.Width = 130;
            // 
            // NgayTao
            // 
            this.NgayTao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.MinimumWidth = 8;
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Width = 94;
            // 
            // TrangThai
            // 
            this.TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 8;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 103;
            // 
            // DatLaiMatKhau
            // 
            this.DatLaiMatKhau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DatLaiMatKhau.HeaderText = "Đặt lại mật khẩu";
            this.DatLaiMatKhau.MinimumWidth = 8;
            this.DatLaiMatKhau.Name = "DatLaiMatKhau";
            this.DatLaiMatKhau.Width = 120;
            // 
            // KhoaTaiKhoan
            // 
            this.KhoaTaiKhoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KhoaTaiKhoan.HeaderText = "Khóa tài khoản";
            this.KhoaTaiKhoan.MinimumWidth = 8;
            this.KhoaTaiKhoan.Name = "KhoaTaiKhoan";
            this.KhoaTaiKhoan.Width = 113;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TimKiem.BackgroundImage")));
            this.btn_TimKiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_TimKiem.Location = new System.Drawing.Point(247, 131);
            this.btn_TimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(27, 24);
            this.btn_TimKiem.TabIndex = 41;
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // textBox_TimKiem
            // 
            this.textBox_TimKiem.Location = new System.Drawing.Point(70, 133);
            this.textBox_TimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_TimKiem.Name = "textBox_TimKiem";
            this.textBox_TimKiem.Size = new System.Drawing.Size(172, 22);
            this.textBox_TimKiem.TabIndex = 40;
            // 
            // btnThemTK
            // 
            this.btnThemTK.AutoSize = true;
            this.btnThemTK.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnThemTK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTK.ForeColor = System.Drawing.Color.Black;
            this.btnThemTK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemTK.Location = new System.Drawing.Point(889, 123);
            this.btnThemTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemTK.Name = "btnThemTK";
            this.btnThemTK.Size = new System.Drawing.Size(58, 32);
            this.btnThemTK.TabIndex = 34;
            this.btnThemTK.Text = "Thêm";
            this.btnThemTK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemTK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemTK.UseVisualStyleBackColor = false;
            this.btnThemTK.Click += new System.EventHandler(this.btnThemTK_Click);
            // 
            // pic_icon_QTV_TaiKhoanHeThong
            // 
            this.pic_icon_QTV_TaiKhoanHeThong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_icon_QTV_TaiKhoanHeThong.BackgroundImage")));
            this.pic_icon_QTV_TaiKhoanHeThong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_icon_QTV_TaiKhoanHeThong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_icon_QTV_TaiKhoanHeThong.Location = new System.Drawing.Point(70, 48);
            this.pic_icon_QTV_TaiKhoanHeThong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_icon_QTV_TaiKhoanHeThong.Name = "pic_icon_QTV_TaiKhoanHeThong";
            this.pic_icon_QTV_TaiKhoanHeThong.Size = new System.Drawing.Size(54, 49);
            this.pic_icon_QTV_TaiKhoanHeThong.TabIndex = 33;
            this.pic_icon_QTV_TaiKhoanHeThong.TabStop = false;
            // 
            // lbTKHT
            // 
            this.lbTKHT.AutoSize = true;
            this.lbTKHT.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbTKHT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTKHT.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.lbTKHT.ForeColor = System.Drawing.Color.Teal;
            this.lbTKHT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTKHT.Location = new System.Drawing.Point(133, 48);
            this.lbTKHT.Name = "lbTKHT";
            this.lbTKHT.Size = new System.Drawing.Size(412, 47);
            this.lbTKHT.TabIndex = 32;
            this.lbTKHT.Text = "QUẢN LÝ TÀI KHOẢN";
            this.lbTKHT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLuu
            // 
            this.btnLuu.AutoSize = true;
            this.btnLuu.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnLuu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Black;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(829, 532);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(117, 40);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu thay đổi";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // UC_QTV_QuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlContent);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_QTV_QuanLyTaiKhoan";
            this.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QTV_DSVaiTro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_TaiKhoanHeThong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnThemTK;
        private System.Windows.Forms.PictureBox pic_icon_QTV_TaiKhoanHeThong;
        private System.Windows.Forms.Label lbTKHT;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.TextBox textBox_TimKiem;
        private System.Windows.Forms.DataGridView dgv_QTV_DSVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewButtonColumn DatLaiMatKhau;
        private System.Windows.Forms.DataGridViewButtonColumn KhoaTaiKhoan;
    }
}
