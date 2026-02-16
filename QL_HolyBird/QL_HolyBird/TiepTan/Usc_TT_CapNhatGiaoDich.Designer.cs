namespace QL_HolyBird.TiepTan
{
    partial class Usc_TT_CapNhatGiaoDich
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
            this.dgv_TT8_DSGiaoDich = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaiDien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNguoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiGD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_TT2_TaoTKKH = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_TT8_MaDoan = new System.Windows.Forms.ComboBox();
            this.lbl_TT2_UserName = new System.Windows.Forms.Label();
            this.btn_TT8_XacNhan = new System.Windows.Forms.Button();
            this.btn_TT8_Xoa = new System.Windows.Forms.Button();
            this.btn_TT8_Sua = new System.Windows.Forms.Button();
            this.btn_TT8_Huy = new System.Windows.Forms.Button();
            this.checkBox_TT8_DM = new System.Windows.Forms.CheckBox();
            this.cbBox_TT8_DemoGiaiQuyet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TT8_DSGiaoDich)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_TT8_DSGiaoDich
            // 
            this.dgv_TT8_DSGiaoDich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TT8_DSGiaoDich.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_TT8_DSGiaoDich.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_TT8_DSGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TT8_DSGiaoDich.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.MaDoan,
            this.DaiDien,
            this.SoNguoi,
            this.SoPhong,
            this.BatDau,
            this.KetThuc,
            this.TrangThaiGD});
            this.dgv_TT8_DSGiaoDich.EnableHeadersVisualStyles = false;
            this.dgv_TT8_DSGiaoDich.Location = new System.Drawing.Point(313, 183);
            this.dgv_TT8_DSGiaoDich.Name = "dgv_TT8_DSGiaoDich";
            this.dgv_TT8_DSGiaoDich.RowHeadersWidth = 51;
            this.dgv_TT8_DSGiaoDich.RowTemplate.Height = 24;
            this.dgv_TT8_DSGiaoDich.Size = new System.Drawing.Size(887, 385);
            this.dgv_TT8_DSGiaoDich.TabIndex = 41;
            // 
            // Chon
            // 
            this.Chon.HeaderText = "Chọn";
            this.Chon.MinimumWidth = 6;
            this.Chon.Name = "Chon";
            // 
            // MaDoan
            // 
            this.MaDoan.HeaderText = "Mã Đoàn";
            this.MaDoan.MinimumWidth = 6;
            this.MaDoan.Name = "MaDoan";
            this.MaDoan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaDoan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DaiDien
            // 
            this.DaiDien.HeaderText = "Đại Diện";
            this.DaiDien.MinimumWidth = 6;
            this.DaiDien.Name = "DaiDien";
            // 
            // SoNguoi
            // 
            this.SoNguoi.HeaderText = "Số Người";
            this.SoNguoi.MinimumWidth = 6;
            this.SoNguoi.Name = "SoNguoi";
            // 
            // SoPhong
            // 
            this.SoPhong.HeaderText = "Số Phòng";
            this.SoPhong.MinimumWidth = 6;
            this.SoPhong.Name = "SoPhong";
            // 
            // BatDau
            // 
            this.BatDau.HeaderText = "Ngày Bắt Đầu";
            this.BatDau.MinimumWidth = 6;
            this.BatDau.Name = "BatDau";
            // 
            // KetThuc
            // 
            this.KetThuc.HeaderText = "Ngày Kết Thúc";
            this.KetThuc.MinimumWidth = 6;
            this.KetThuc.Name = "KetThuc";
            // 
            // TrangThaiGD
            // 
            this.TrangThaiGD.HeaderText = "Trạng Thái GD";
            this.TrangThaiGD.MinimumWidth = 6;
            this.TrangThaiGD.Name = "TrangThaiGD";
            // 
            // lbl_TT2_TaoTKKH
            // 
            this.lbl_TT2_TaoTKKH.AutoSize = true;
            this.lbl_TT2_TaoTKKH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_TT2_TaoTKKH.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_TT2_TaoTKKH.ForeColor = System.Drawing.Color.Teal;
            this.lbl_TT2_TaoTKKH.Location = new System.Drawing.Point(500, 94);
            this.lbl_TT2_TaoTKKH.Name = "lbl_TT2_TaoTKKH";
            this.lbl_TT2_TaoTKKH.Size = new System.Drawing.Size(432, 47);
            this.lbl_TT2_TaoTKKH.TabIndex = 40;
            this.lbl_TT2_TaoTKKH.Text = "CẬP NHẬT GIAO DỊCH";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.cmb_TT8_MaDoan);
            this.panel1.Controls.Add(this.lbl_TT2_UserName);
            this.panel1.Location = new System.Drawing.Point(49, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 309);
            this.panel1.TabIndex = 42;
            // 
            // cmb_TT8_MaDoan
            // 
            this.cmb_TT8_MaDoan.FormattingEnabled = true;
            this.cmb_TT8_MaDoan.Location = new System.Drawing.Point(15, 109);
            this.cmb_TT8_MaDoan.Name = "cmb_TT8_MaDoan";
            this.cmb_TT8_MaDoan.Size = new System.Drawing.Size(227, 24);
            this.cmb_TT8_MaDoan.TabIndex = 59;
            this.cmb_TT8_MaDoan.SelectedIndexChanged += new System.EventHandler(this.cmb_TT8_MaDoan_SelectedIndexChanged);
            // 
            // lbl_TT2_UserName
            // 
            this.lbl_TT2_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_TT2_UserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_TT2_UserName.Location = new System.Drawing.Point(15, 45);
            this.lbl_TT2_UserName.Name = "lbl_TT2_UserName";
            this.lbl_TT2_UserName.Size = new System.Drawing.Size(104, 39);
            this.lbl_TT2_UserName.TabIndex = 36;
            this.lbl_TT2_UserName.Text = "Mã đoàn:";
            this.lbl_TT2_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_TT8_XacNhan
            // 
            this.btn_TT8_XacNhan.BackColor = System.Drawing.Color.Teal;
            this.btn_TT8_XacNhan.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TT8_XacNhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_TT8_XacNhan.Location = new System.Drawing.Point(1057, 94);
            this.btn_TT8_XacNhan.Name = "btn_TT8_XacNhan";
            this.btn_TT8_XacNhan.Size = new System.Drawing.Size(143, 40);
            this.btn_TT8_XacNhan.TabIndex = 43;
            this.btn_TT8_XacNhan.Text = "Xác nhận";
            this.btn_TT8_XacNhan.UseVisualStyleBackColor = false;
            this.btn_TT8_XacNhan.Click += new System.EventHandler(this.btn_TT8_XacNhan_Click);
            // 
            // btn_TT8_Xoa
            // 
            this.btn_TT8_Xoa.BackColor = System.Drawing.Color.Teal;
            this.btn_TT8_Xoa.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TT8_Xoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_TT8_Xoa.Location = new System.Drawing.Point(762, 610);
            this.btn_TT8_Xoa.Name = "btn_TT8_Xoa";
            this.btn_TT8_Xoa.Size = new System.Drawing.Size(143, 40);
            this.btn_TT8_Xoa.TabIndex = 44;
            this.btn_TT8_Xoa.Text = "Xóa";
            this.btn_TT8_Xoa.UseVisualStyleBackColor = false;
            // 
            // btn_TT8_Sua
            // 
            this.btn_TT8_Sua.BackColor = System.Drawing.Color.Teal;
            this.btn_TT8_Sua.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TT8_Sua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_TT8_Sua.Location = new System.Drawing.Point(599, 610);
            this.btn_TT8_Sua.Name = "btn_TT8_Sua";
            this.btn_TT8_Sua.Size = new System.Drawing.Size(143, 40);
            this.btn_TT8_Sua.TabIndex = 45;
            this.btn_TT8_Sua.Text = "Sửa";
            this.btn_TT8_Sua.UseVisualStyleBackColor = false;
            this.btn_TT8_Sua.Click += new System.EventHandler(this.btn_TT8_Sua_Click);
            // 
            // btn_TT8_Huy
            // 
            this.btn_TT8_Huy.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_TT8_Huy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_TT8_Huy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_TT8_Huy.Location = new System.Drawing.Point(1080, 140);
            this.btn_TT8_Huy.Name = "btn_TT8_Huy";
            this.btn_TT8_Huy.Size = new System.Drawing.Size(98, 36);
            this.btn_TT8_Huy.TabIndex = 46;
            this.btn_TT8_Huy.Text = "Hủy";
            this.btn_TT8_Huy.UseVisualStyleBackColor = false;
            this.btn_TT8_Huy.Click += new System.EventHandler(this.btn_TT8_Huy_Click);
            // 
            // checkBox_TT8_DM
            // 
            this.checkBox_TT8_DM.AutoSize = true;
            this.checkBox_TT8_DM.Location = new System.Drawing.Point(17, 20);
            this.checkBox_TT8_DM.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_TT8_DM.Name = "checkBox_TT8_DM";
            this.checkBox_TT8_DM.Size = new System.Drawing.Size(107, 20);
            this.checkBox_TT8_DM.TabIndex = 92;
            this.checkBox_TT8_DM.Text = "Check Demo";
            this.checkBox_TT8_DM.UseVisualStyleBackColor = true;
            this.checkBox_TT8_DM.CheckedChanged += new System.EventHandler(this.checkBox_TT8_DM_CheckedChanged);
            // 
            // cbBox_TT8_DemoGiaiQuyet
            // 
            this.cbBox_TT8_DemoGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBox_TT8_DemoGiaiQuyet.FormattingEnabled = true;
            this.cbBox_TT8_DemoGiaiQuyet.Items.AddRange(new object[] {
            "Normal",
            "Demo",
            "Giải quyết"});
            this.cbBox_TT8_DemoGiaiQuyet.Location = new System.Drawing.Point(132, 19);
            this.cbBox_TT8_DemoGiaiQuyet.Margin = new System.Windows.Forms.Padding(2);
            this.cbBox_TT8_DemoGiaiQuyet.Name = "cbBox_TT8_DemoGiaiQuyet";
            this.cbBox_TT8_DemoGiaiQuyet.Size = new System.Drawing.Size(146, 23);
            this.cbBox_TT8_DemoGiaiQuyet.TabIndex = 91;
            this.cbBox_TT8_DemoGiaiQuyet.SelectedIndexChanged += new System.EventHandler(this.cbBox_TT8_DemoGiaiQuyet_SelectedIndexChanged);
            // 
            // Usc_TT_CapNhatGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.checkBox_TT8_DM);
            this.Controls.Add(this.cbBox_TT8_DemoGiaiQuyet);
            this.Controls.Add(this.btn_TT8_Huy);
            this.Controls.Add(this.btn_TT8_Sua);
            this.Controls.Add(this.btn_TT8_Xoa);
            this.Controls.Add(this.dgv_TT8_DSGiaoDich);
            this.Controls.Add(this.lbl_TT2_TaoTKKH);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_TT8_XacNhan);
            this.Name = "Usc_TT_CapNhatGiaoDich";
            this.Size = new System.Drawing.Size(1249, 828);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TT8_DSGiaoDich)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_TT8_DSGiaoDich;
        private System.Windows.Forms.Label lbl_TT2_TaoTKKH;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_TT8_MaDoan;
        private System.Windows.Forms.Label lbl_TT2_UserName;
        private System.Windows.Forms.Button btn_TT8_XacNhan;
        private System.Windows.Forms.Button btn_TT8_Xoa;
        private System.Windows.Forms.Button btn_TT8_Sua;
        private System.Windows.Forms.Button btn_TT8_Huy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaiDien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNguoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn KetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiGD;
        private System.Windows.Forms.CheckBox checkBox_TT8_DM;
        private System.Windows.Forms.ComboBox cbBox_TT8_DemoGiaiQuyet;
    }
}
