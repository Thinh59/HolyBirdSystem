namespace QL_HolyBird.QuanTriVien.UC_con
{
    partial class UC_QTV_ChiTietPhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QTV_ChiTietPhanQuyen));
            this.lbVaiTro = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgv_QTV_DSChucNang = new System.Windows.Forms.DataGridView();
            this.ChucNang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sua = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pic_icon_QTV_Luu = new System.Windows.Forms.PictureBox();
            this.pic_icon_QTV_Add = new System.Windows.Forms.PictureBox();
            this.btnThemQuyen = new System.Windows.Forms.Button();
            this.pic_icon_QTV_PhanQuyen = new System.Windows.Forms.PictureBox();
            this.lbPhanQuyen = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QTV_DSChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Luu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_PhanQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // lbVaiTro
            // 
            this.lbVaiTro.AutoSize = true;
            this.lbVaiTro.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbVaiTro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbVaiTro.ForeColor = System.Drawing.Color.Black;
            this.lbVaiTro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbVaiTro.Location = new System.Drawing.Point(66, 156);
            this.lbVaiTro.Name = "lbVaiTro";
            this.lbVaiTro.Size = new System.Drawing.Size(78, 25);
            this.lbVaiTro.TabIndex = 17;
            this.lbVaiTro.Text = "Quản lý";
            this.lbVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlContent.AutoSize = true;
            this.pnlContent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlContent.Controls.Add(this.dgv_QTV_DSChucNang);
            this.pnlContent.Controls.Add(this.btnHuy);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_Luu);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_Add);
            this.pnlContent.Controls.Add(this.btnThemQuyen);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_PhanQuyen);
            this.pnlContent.Controls.Add(this.lbPhanQuyen);
            this.pnlContent.Controls.Add(this.btnLuu);
            this.pnlContent.Controls.Add(this.lbVaiTro);
            this.pnlContent.Location = new System.Drawing.Point(7, 6);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.TabIndex = 8;
            // 
            // dgv_QTV_DSChucNang
            // 
            this.dgv_QTV_DSChucNang.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_QTV_DSChucNang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_QTV_DSChucNang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_QTV_DSChucNang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_QTV_DSChucNang.ColumnHeadersHeight = 35;
            this.dgv_QTV_DSChucNang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChucNang,
            this.Xem,
            this.Sua,
            this.Xoa});
            this.dgv_QTV_DSChucNang.GridColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_QTV_DSChucNang.Location = new System.Drawing.Point(66, 201);
            this.dgv_QTV_DSChucNang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_QTV_DSChucNang.Name = "dgv_QTV_DSChucNang";
            this.dgv_QTV_DSChucNang.RowHeadersVisible = false;
            this.dgv_QTV_DSChucNang.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_QTV_DSChucNang.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_QTV_DSChucNang.RowTemplate.Height = 28;
            this.dgv_QTV_DSChucNang.Size = new System.Drawing.Size(881, 195);
            this.dgv_QTV_DSChucNang.TabIndex = 46;
            // 
            // ChucNang
            // 
            this.ChucNang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChucNang.HeaderText = "Chức năng";
            this.ChucNang.MinimumWidth = 8;
            this.ChucNang.Name = "ChucNang";
            this.ChucNang.Width = 107;
            // 
            // Xem
            // 
            this.Xem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Xem.HeaderText = "Xem";
            this.Xem.MinimumWidth = 8;
            this.Xem.Name = "Xem";
            this.Xem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Xem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Xem.Width = 67;
            // 
            // Sua
            // 
            this.Sua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sua.HeaderText = "Sửa";
            this.Sua.MinimumWidth = 8;
            this.Sua.Name = "Sua";
            this.Sua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Sua.Width = 61;
            // 
            // Xoa
            // 
            this.Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.MinimumWidth = 8;
            this.Xoa.Name = "Xoa";
            this.Xoa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Xoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Xoa.Width = 62;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkOrange;
            this.btnHuy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(710, 486);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(71, 40);
            this.btnHuy.TabIndex = 39;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // pic_icon_QTV_Luu
            // 
            this.pic_icon_QTV_Luu.BackColor = System.Drawing.Color.NavajoWhite;
            this.pic_icon_QTV_Luu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_icon_QTV_Luu.BackgroundImage")));
            this.pic_icon_QTV_Luu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_icon_QTV_Luu.Location = new System.Drawing.Point(788, 490);
            this.pic_icon_QTV_Luu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_icon_QTV_Luu.Name = "pic_icon_QTV_Luu";
            this.pic_icon_QTV_Luu.Size = new System.Drawing.Size(36, 32);
            this.pic_icon_QTV_Luu.TabIndex = 38;
            this.pic_icon_QTV_Luu.TabStop = false;
            // 
            // pic_icon_QTV_Add
            // 
            this.pic_icon_QTV_Add.BackColor = System.Drawing.Color.NavajoWhite;
            this.pic_icon_QTV_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_icon_QTV_Add.BackgroundImage")));
            this.pic_icon_QTV_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_icon_QTV_Add.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_icon_QTV_Add.Location = new System.Drawing.Point(858, 148);
            this.pic_icon_QTV_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_icon_QTV_Add.Name = "pic_icon_QTV_Add";
            this.pic_icon_QTV_Add.Size = new System.Drawing.Size(33, 30);
            this.pic_icon_QTV_Add.TabIndex = 37;
            this.pic_icon_QTV_Add.TabStop = false;
            // 
            // btnThemQuyen
            // 
            this.btnThemQuyen.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnThemQuyen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemQuyen.ForeColor = System.Drawing.Color.Black;
            this.btnThemQuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemQuyen.Location = new System.Drawing.Point(858, 148);
            this.btnThemQuyen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemQuyen.Name = "btnThemQuyen";
            this.btnThemQuyen.Size = new System.Drawing.Size(89, 32);
            this.btnThemQuyen.TabIndex = 34;
            this.btnThemQuyen.Text = "Thêm";
            this.btnThemQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemQuyen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemQuyen.UseVisualStyleBackColor = false;
            this.btnThemQuyen.Click += new System.EventHandler(this.btnThemQuyen_Click);
            // 
            // pic_icon_QTV_PhanQuyen
            // 
            this.pic_icon_QTV_PhanQuyen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_icon_QTV_PhanQuyen.BackgroundImage")));
            this.pic_icon_QTV_PhanQuyen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_icon_QTV_PhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_icon_QTV_PhanQuyen.Location = new System.Drawing.Point(70, 48);
            this.pic_icon_QTV_PhanQuyen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_icon_QTV_PhanQuyen.Name = "pic_icon_QTV_PhanQuyen";
            this.pic_icon_QTV_PhanQuyen.Size = new System.Drawing.Size(54, 49);
            this.pic_icon_QTV_PhanQuyen.TabIndex = 33;
            this.pic_icon_QTV_PhanQuyen.TabStop = false;
            // 
            // lbPhanQuyen
            // 
            this.lbPhanQuyen.AutoSize = true;
            this.lbPhanQuyen.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbPhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbPhanQuyen.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.lbPhanQuyen.ForeColor = System.Drawing.Color.Teal;
            this.lbPhanQuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbPhanQuyen.Location = new System.Drawing.Point(133, 48);
            this.lbPhanQuyen.Name = "lbPhanQuyen";
            this.lbPhanQuyen.Size = new System.Drawing.Size(451, 47);
            this.lbPhanQuyen.TabIndex = 32;
            this.lbPhanQuyen.Text = "CHI TIẾT PHÂN QUYỀN";
            this.lbPhanQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnLuu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Black;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(787, 486);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(160, 40);
            this.btnLuu.TabIndex = 19;
            this.btnLuu.Text = "Lưu thay đổi";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // UC_QTV_ChiTietPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlContent);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_QTV_ChiTietPhanQuyen";
            this.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QTV_DSChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Luu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_PhanQuyen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVaiTro;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.PictureBox pic_icon_QTV_Luu;
        private System.Windows.Forms.PictureBox pic_icon_QTV_Add;
        private System.Windows.Forms.Button btnThemQuyen;
        private System.Windows.Forms.PictureBox pic_icon_QTV_PhanQuyen;
        private System.Windows.Forms.Label lbPhanQuyen;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgv_QTV_DSChucNang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucNang;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Xem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sua;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Xoa;
    }
}
