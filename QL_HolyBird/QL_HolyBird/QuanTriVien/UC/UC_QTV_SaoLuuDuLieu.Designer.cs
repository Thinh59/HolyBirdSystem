namespace QL_HolyBird
{
    partial class UC_QTV_SaoLuuDuLieu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QTV_SaoLuuDuLieu));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnTaoSaoLuu = new System.Windows.Forms.Button();
            this.lbDanhSachSaoLuu = new System.Windows.Forms.Label();
            this.dgv_NhatKy = new System.Windows.Forms.DataGridView();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiThucHien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DungLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pic_icon_QTV_CauHinh = new System.Windows.Forms.PictureBox();
            this.lbCauHinh = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhatKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_CauHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContent.Controls.Add(this.btnTaoSaoLuu);
            this.pnlContent.Controls.Add(this.lbDanhSachSaoLuu);
            this.pnlContent.Controls.Add(this.dgv_NhatKy);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_CauHinh);
            this.pnlContent.Controls.Add(this.lbCauHinh);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.TabIndex = 13;
            // 
            // btnTaoSaoLuu
            // 
            this.btnTaoSaoLuu.AutoSize = true;
            this.btnTaoSaoLuu.BackColor = System.Drawing.Color.Orange;
            this.btnTaoSaoLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaoSaoLuu.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaoSaoLuu.Location = new System.Drawing.Point(71, 136);
            this.btnTaoSaoLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTaoSaoLuu.Name = "btnTaoSaoLuu";
            this.btnTaoSaoLuu.Size = new System.Drawing.Size(140, 29);
            this.btnTaoSaoLuu.TabIndex = 51;
            this.btnTaoSaoLuu.Text = "Tạo bản sao lưu";
            this.btnTaoSaoLuu.UseVisualStyleBackColor = false;
            this.btnTaoSaoLuu.Click += new System.EventHandler(this.btnTaoSaoLuu_Click);
            // 
            // lbDanhSachSaoLuu
            // 
            this.lbDanhSachSaoLuu.AutoSize = true;
            this.lbDanhSachSaoLuu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDanhSachSaoLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbDanhSachSaoLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDanhSachSaoLuu.Location = new System.Drawing.Point(71, 208);
            this.lbDanhSachSaoLuu.Name = "lbDanhSachSaoLuu";
            this.lbDanhSachSaoLuu.Size = new System.Drawing.Size(308, 25);
            this.lbDanhSachSaoLuu.TabIndex = 50;
            this.lbDanhSachSaoLuu.Text = "Danh sách các bản sao lưu gần nhất";
            // 
            // dgv_NhatKy
            // 
            this.dgv_NhatKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_NhatKy.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgv_NhatKy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_NhatKy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NhatKy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_NhatKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhatKy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ThoiGian,
            this.TenTep,
            this.NguoiThucHien,
            this.DungLuong});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NhatKy.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_NhatKy.EnableHeadersVisualStyles = false;
            this.dgv_NhatKy.GridColor = System.Drawing.Color.Tan;
            this.dgv_NhatKy.Location = new System.Drawing.Point(71, 240);
            this.dgv_NhatKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_NhatKy.Name = "dgv_NhatKy";
            this.dgv_NhatKy.RowHeadersVisible = false;
            this.dgv_NhatKy.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_NhatKy.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_NhatKy.RowTemplate.Height = 28;
            this.dgv_NhatKy.Size = new System.Drawing.Size(729, 228);
            this.dgv_NhatKy.TabIndex = 48;
            // 
            // ThoiGian
            // 
            this.ThoiGian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ThoiGian.DefaultCellStyle = dataGridViewCellStyle2;
            this.ThoiGian.HeaderText = "Thời gian";
            this.ThoiGian.MinimumWidth = 8;
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.Width = 97;
            // 
            // TenTep
            // 
            this.TenTep.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenTep.HeaderText = "Tên tệp";
            this.TenTep.MinimumWidth = 8;
            this.TenTep.Name = "TenTep";
            this.TenTep.Width = 87;
            // 
            // NguoiThucHien
            // 
            this.NguoiThucHien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NguoiThucHien.DefaultCellStyle = dataGridViewCellStyle3;
            this.NguoiThucHien.HeaderText = "Người thực hiện";
            this.NguoiThucHien.MinimumWidth = 8;
            this.NguoiThucHien.Name = "NguoiThucHien";
            this.NguoiThucHien.Width = 141;
            // 
            // DungLuong
            // 
            this.DungLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DungLuong.HeaderText = "Dung lượng";
            this.DungLuong.MinimumWidth = 8;
            this.DungLuong.Name = "DungLuong";
            this.DungLuong.Width = 112;
            // 
            // pic_icon_QTV_CauHinh
            // 
            this.pic_icon_QTV_CauHinh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_icon_QTV_CauHinh.BackgroundImage")));
            this.pic_icon_QTV_CauHinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_icon_QTV_CauHinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_icon_QTV_CauHinh.Location = new System.Drawing.Point(71, 48);
            this.pic_icon_QTV_CauHinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_icon_QTV_CauHinh.Name = "pic_icon_QTV_CauHinh";
            this.pic_icon_QTV_CauHinh.Size = new System.Drawing.Size(54, 49);
            this.pic_icon_QTV_CauHinh.TabIndex = 32;
            this.pic_icon_QTV_CauHinh.TabStop = false;
            // 
            // lbCauHinh
            // 
            this.lbCauHinh.AutoSize = true;
            this.lbCauHinh.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lbCauHinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCauHinh.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbCauHinh.ForeColor = System.Drawing.Color.Teal;
            this.lbCauHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbCauHinh.Location = new System.Drawing.Point(133, 48);
            this.lbCauHinh.Name = "lbCauHinh";
            this.lbCauHinh.Size = new System.Drawing.Size(354, 47);
            this.lbCauHinh.TabIndex = 31;
            this.lbCauHinh.Text = "SAO LƯU DỮ LIỆU";
            this.lbCauHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_QTV_SaoLuuDuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlContent);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_QTV_SaoLuuDuLieu";
            this.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhatKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_CauHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnTaoSaoLuu;
        private System.Windows.Forms.Label lbDanhSachSaoLuu;
        private System.Windows.Forms.DataGridView dgv_NhatKy;
        private System.Windows.Forms.PictureBox pic_icon_QTV_CauHinh;
        private System.Windows.Forms.Label lbCauHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTep;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiThucHien;
        private System.Windows.Forms.DataGridViewTextBoxColumn DungLuong;
    }
}
