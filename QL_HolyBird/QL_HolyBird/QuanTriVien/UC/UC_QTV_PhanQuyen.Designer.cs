namespace QL_HolyBird
{
    partial class UC_QTV_PhanQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QTV_PhanQuyen));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgv_QTV_DSVaiTro = new System.Windows.Forms.DataGridView();
            this.VaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChinhSua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pic_icon_QTV_Add = new System.Windows.Forms.PictureBox();
            this.btnThemQuyen = new System.Windows.Forms.Button();
            this.pic_icon_QTV_PhanQuyen = new System.Windows.Forms.PictureBox();
            this.lbPhanQuyen = new System.Windows.Forms.Label();
            this.lbVaiTro = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QTV_DSVaiTro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_PhanQuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlContent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlContent.Controls.Add(this.dgv_QTV_DSVaiTro);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_Add);
            this.pnlContent.Controls.Add(this.btnThemQuyen);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_PhanQuyen);
            this.pnlContent.Controls.Add(this.lbPhanQuyen);
            this.pnlContent.Controls.Add(this.lbVaiTro);
            this.pnlContent.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.TabIndex = 5;
            // 
            // dgv_QTV_DSVaiTro
            // 
            this.dgv_QTV_DSVaiTro.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_QTV_DSVaiTro.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_QTV_DSVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_QTV_DSVaiTro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_QTV_DSVaiTro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_QTV_DSVaiTro.ColumnHeadersHeight = 35;
            this.dgv_QTV_DSVaiTro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VaiTro,
            this.ChinhSua,
            this.Xoa});
            this.dgv_QTV_DSVaiTro.GridColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_QTV_DSVaiTro.Location = new System.Drawing.Point(66, 197);
            this.dgv_QTV_DSVaiTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_QTV_DSVaiTro.Name = "dgv_QTV_DSVaiTro";
            this.dgv_QTV_DSVaiTro.RowHeadersVisible = false;
            this.dgv_QTV_DSVaiTro.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_QTV_DSVaiTro.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_QTV_DSVaiTro.RowTemplate.Height = 28;
            this.dgv_QTV_DSVaiTro.Size = new System.Drawing.Size(881, 357);
            this.dgv_QTV_DSVaiTro.TabIndex = 45;
            this.dgv_QTV_DSVaiTro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QTV_DSVaiTro_CellContentClick);
            // 
            // VaiTro
            // 
            this.VaiTro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VaiTro.HeaderText = "Vai trò";
            this.VaiTro.MinimumWidth = 8;
            this.VaiTro.Name = "VaiTro";
            this.VaiTro.Width = 76;
            // 
            // ChinhSua
            // 
            this.ChinhSua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ChinhSua.HeaderText = "Chỉnh sửa";
            this.ChinhSua.MinimumWidth = 8;
            this.ChinhSua.Name = "ChinhSua";
            this.ChinhSua.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ChinhSua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ChinhSua.Text = "Sửa";
            this.ChinhSua.Width = 96;
            // 
            // Xoa
            // 
            this.Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.MinimumWidth = 8;
            this.Xoa.Name = "Xoa";
            this.Xoa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Xoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Xoa.Text = "Xóa";
            this.Xoa.Width = 61;
            // 
            // pic_icon_QTV_Add
            // 
            this.pic_icon_QTV_Add.BackColor = System.Drawing.Color.NavajoWhite;
            this.pic_icon_QTV_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_icon_QTV_Add.BackgroundImage")));
            this.pic_icon_QTV_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_icon_QTV_Add.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_icon_QTV_Add.Location = new System.Drawing.Point(851, 148);
            this.pic_icon_QTV_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_icon_QTV_Add.Name = "pic_icon_QTV_Add";
            this.pic_icon_QTV_Add.Size = new System.Drawing.Size(33, 30);
            this.pic_icon_QTV_Add.TabIndex = 42;
            this.pic_icon_QTV_Add.TabStop = false;
            // 
            // btnThemQuyen
            // 
            this.btnThemQuyen.AutoSize = true;
            this.btnThemQuyen.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnThemQuyen.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemQuyen.ForeColor = System.Drawing.Color.Black;
            this.btnThemQuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemQuyen.Location = new System.Drawing.Point(889, 148);
            this.btnThemQuyen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemQuyen.Name = "btnThemQuyen";
            this.btnThemQuyen.Size = new System.Drawing.Size(58, 32);
            this.btnThemQuyen.TabIndex = 41;
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
            this.pic_icon_QTV_PhanQuyen.TabIndex = 40;
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
            this.lbPhanQuyen.Size = new System.Drawing.Size(466, 47);
            this.lbPhanQuyen.TabIndex = 39;
            this.lbPhanQuyen.Text = "PHÂN QUYỀN - VAI TRÒ";
            this.lbPhanQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbVaiTro
            // 
            this.lbVaiTro.BackColor = System.Drawing.Color.NavajoWhite;
            this.lbVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbVaiTro.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbVaiTro.ForeColor = System.Drawing.Color.Black;
            this.lbVaiTro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbVaiTro.Location = new System.Drawing.Point(66, 156);
            this.lbVaiTro.Name = "lbVaiTro";
            this.lbVaiTro.Size = new System.Drawing.Size(296, 24);
            this.lbVaiTro.TabIndex = 38;
            this.lbVaiTro.Text = "Danh sách các vai trò hiện có";
            this.lbVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_QTV_PhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlContent);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_QTV_PhanQuyen";
            this.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QTV_DSVaiTro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_PhanQuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox pic_icon_QTV_Add;
        private System.Windows.Forms.Button btnThemQuyen;
        private System.Windows.Forms.PictureBox pic_icon_QTV_PhanQuyen;
        private System.Windows.Forms.Label lbPhanQuyen;
        private System.Windows.Forms.Label lbVaiTro;
        private System.Windows.Forms.DataGridView dgv_QTV_DSVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn VaiTro;
        private System.Windows.Forms.DataGridViewButtonColumn ChinhSua;
        private System.Windows.Forms.DataGridViewButtonColumn Xoa;
    }
}
