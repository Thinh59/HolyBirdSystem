namespace QL_HolyBird
{
    partial class UC_QTV_CauHinhHeThong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QTV_CauHinhHeThong));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dtp_CheckOut = new System.Windows.Forms.DateTimePicker();
            this.lbGioCheckout = new System.Windows.Forms.Label();
            this.dtp_CheckIn = new System.Windows.Forms.DateTimePicker();
            this.nud_TiGia = new System.Windows.Forms.NumericUpDown();
            this.nud_VAT = new System.Windows.Forms.NumericUpDown();
            this.lbTiGia = new System.Windows.Forms.Label();
            this.lbGioCheckin = new System.Windows.Forms.Label();
            this.lbThueVAT = new System.Windows.Forms.Label();
            this.comboBox_NgonNgu = new System.Windows.Forms.ComboBox();
            this.lbNgonNgu = new System.Windows.Forms.Label();
            this.comboBox_TienTe = new System.Windows.Forms.ComboBox();
            this.comboBox_NgayGio = new System.Windows.Forms.ComboBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.pic_icon_QTV_Luu = new System.Windows.Forms.PictureBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lbDonViTT = new System.Windows.Forms.Label();
            this.lbDinhDang = new System.Windows.Forms.Label();
            this.pic_icon_QTV_CauHinh = new System.Windows.Forms.PictureBox();
            this.lbCauHinh = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TiGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_VAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Luu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_CauHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.pnlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContent.Controls.Add(this.dtp_CheckOut);
            this.pnlContent.Controls.Add(this.lbGioCheckout);
            this.pnlContent.Controls.Add(this.dtp_CheckIn);
            this.pnlContent.Controls.Add(this.nud_TiGia);
            this.pnlContent.Controls.Add(this.nud_VAT);
            this.pnlContent.Controls.Add(this.lbTiGia);
            this.pnlContent.Controls.Add(this.lbGioCheckin);
            this.pnlContent.Controls.Add(this.lbThueVAT);
            this.pnlContent.Controls.Add(this.comboBox_NgonNgu);
            this.pnlContent.Controls.Add(this.lbNgonNgu);
            this.pnlContent.Controls.Add(this.comboBox_TienTe);
            this.pnlContent.Controls.Add(this.comboBox_NgayGio);
            this.pnlContent.Controls.Add(this.btnHuy);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_Luu);
            this.pnlContent.Controls.Add(this.btnLuu);
            this.pnlContent.Controls.Add(this.lbDonViTT);
            this.pnlContent.Controls.Add(this.lbDinhDang);
            this.pnlContent.Controls.Add(this.pic_icon_QTV_CauHinh);
            this.pnlContent.Controls.Add(this.lbCauHinh);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.TabIndex = 9;
            // 
            // dtp_CheckOut
            // 
            this.dtp_CheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_CheckOut.Location = new System.Drawing.Point(588, 400);
            this.dtp_CheckOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_CheckOut.Name = "dtp_CheckOut";
            this.dtp_CheckOut.ShowUpDown = true;
            this.dtp_CheckOut.Size = new System.Drawing.Size(160, 22);
            this.dtp_CheckOut.TabIndex = 57;
            // 
            // lbGioCheckout
            // 
            this.lbGioCheckout.AutoSize = true;
            this.lbGioCheckout.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbGioCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbGioCheckout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbGioCheckout.Location = new System.Drawing.Point(160, 400);
            this.lbGioCheckout.Name = "lbGioCheckout";
            this.lbGioCheckout.Size = new System.Drawing.Size(144, 25);
            this.lbGioCheckout.TabIndex = 56;
            this.lbGioCheckout.Text = "Giờ Check-out:";
            this.lbGioCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtp_CheckIn
            // 
            this.dtp_CheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_CheckIn.Location = new System.Drawing.Point(588, 352);
            this.dtp_CheckIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_CheckIn.Name = "dtp_CheckIn";
            this.dtp_CheckIn.ShowUpDown = true;
            this.dtp_CheckIn.Size = new System.Drawing.Size(160, 22);
            this.dtp_CheckIn.TabIndex = 55;
            // 
            // nud_TiGia
            // 
            this.nud_TiGia.Location = new System.Drawing.Point(588, 450);
            this.nud_TiGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_TiGia.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_TiGia.Name = "nud_TiGia";
            this.nud_TiGia.Size = new System.Drawing.Size(160, 22);
            this.nud_TiGia.TabIndex = 54;
            // 
            // nud_VAT
            // 
            this.nud_VAT.Location = new System.Drawing.Point(588, 306);
            this.nud_VAT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nud_VAT.Name = "nud_VAT";
            this.nud_VAT.Size = new System.Drawing.Size(160, 22);
            this.nud_VAT.TabIndex = 53;
            // 
            // lbTiGia
            // 
            this.lbTiGia.AutoSize = true;
            this.lbTiGia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbTiGia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbTiGia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTiGia.Location = new System.Drawing.Point(160, 448);
            this.lbTiGia.Name = "lbTiGia";
            this.lbTiGia.Size = new System.Drawing.Size(67, 25);
            this.lbTiGia.TabIndex = 51;
            this.lbTiGia.Text = "Tỉ giá:";
            this.lbTiGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbGioCheckin
            // 
            this.lbGioCheckin.AutoSize = true;
            this.lbGioCheckin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbGioCheckin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbGioCheckin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbGioCheckin.Location = new System.Drawing.Point(160, 352);
            this.lbGioCheckin.Name = "lbGioCheckin";
            this.lbGioCheckin.Size = new System.Drawing.Size(132, 25);
            this.lbGioCheckin.TabIndex = 48;
            this.lbGioCheckin.Text = "Giờ Check-in:";
            this.lbGioCheckin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbThueVAT
            // 
            this.lbThueVAT.AutoSize = true;
            this.lbThueVAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbThueVAT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbThueVAT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbThueVAT.Location = new System.Drawing.Point(160, 304);
            this.lbThueVAT.Name = "lbThueVAT";
            this.lbThueVAT.Size = new System.Drawing.Size(141, 25);
            this.lbThueVAT.TabIndex = 47;
            this.lbThueVAT.Text = "Thuế VAT (%):";
            this.lbThueVAT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_NgonNgu
            // 
            this.comboBox_NgonNgu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_NgonNgu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox_NgonNgu.FormattingEnabled = true;
            this.comboBox_NgonNgu.Location = new System.Drawing.Point(588, 256);
            this.comboBox_NgonNgu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_NgonNgu.Name = "comboBox_NgonNgu";
            this.comboBox_NgonNgu.Size = new System.Drawing.Size(160, 25);
            this.comboBox_NgonNgu.TabIndex = 46;
            // 
            // lbNgonNgu
            // 
            this.lbNgonNgu.AutoSize = true;
            this.lbNgonNgu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbNgonNgu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbNgonNgu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNgonNgu.Location = new System.Drawing.Point(160, 256);
            this.lbNgonNgu.Name = "lbNgonNgu";
            this.lbNgonNgu.Size = new System.Drawing.Size(100, 25);
            this.lbNgonNgu.TabIndex = 45;
            this.lbNgonNgu.Text = "Ngôn ngữ:";
            this.lbNgonNgu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_TienTe
            // 
            this.comboBox_TienTe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_TienTe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox_TienTe.FormattingEnabled = true;
            this.comboBox_TienTe.Location = new System.Drawing.Point(588, 208);
            this.comboBox_TienTe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_TienTe.Name = "comboBox_TienTe";
            this.comboBox_TienTe.Size = new System.Drawing.Size(160, 25);
            this.comboBox_TienTe.TabIndex = 44;
            // 
            // comboBox_NgayGio
            // 
            this.comboBox_NgayGio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_NgayGio.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBox_NgayGio.FormattingEnabled = true;
            this.comboBox_NgayGio.Location = new System.Drawing.Point(588, 160);
            this.comboBox_NgayGio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_NgayGio.Name = "comboBox_NgayGio";
            this.comboBox_NgayGio.Size = new System.Drawing.Size(160, 25);
            this.comboBox_NgayGio.TabIndex = 43;
            this.comboBox_NgayGio.SelectedIndexChanged += new System.EventHandler(this.comboBox_NgayGio_SelectedIndexChanged);
            // 
            // btnHuy
            // 
            this.btnHuy.AutoSize = true;
            this.btnHuy.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnHuy.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Black;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(556, 505);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(71, 40);
            this.btnHuy.TabIndex = 42;
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
            this.pic_icon_QTV_Luu.Location = new System.Drawing.Point(645, 509);
            this.pic_icon_QTV_Luu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_icon_QTV_Luu.Name = "pic_icon_QTV_Luu";
            this.pic_icon_QTV_Luu.Size = new System.Drawing.Size(36, 32);
            this.pic_icon_QTV_Luu.TabIndex = 41;
            this.pic_icon_QTV_Luu.TabStop = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnLuu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.Black;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(645, 505);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(160, 40);
            this.btnLuu.TabIndex = 40;
            this.btnLuu.Text = "Lưu thay đổi";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lbDonViTT
            // 
            this.lbDonViTT.AutoSize = true;
            this.lbDonViTT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDonViTT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbDonViTT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDonViTT.Location = new System.Drawing.Point(160, 208);
            this.lbDonViTT.Name = "lbDonViTT";
            this.lbDonViTT.Size = new System.Drawing.Size(133, 25);
            this.lbDonViTT.TabIndex = 35;
            this.lbDonViTT.Text = "Đơn vị tiền tệ:";
            this.lbDonViTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDinhDang
            // 
            this.lbDinhDang.AutoSize = true;
            this.lbDinhDang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDinhDang.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbDinhDang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbDinhDang.Location = new System.Drawing.Point(160, 160);
            this.lbDinhDang.Name = "lbDinhDang";
            this.lbDinhDang.Size = new System.Drawing.Size(179, 25);
            this.lbDinhDang.TabIndex = 34;
            this.lbDinhDang.Text = "Định dạng ngày giờ:";
            this.lbDinhDang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pic_icon_QTV_CauHinh
            // 
            this.pic_icon_QTV_CauHinh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_icon_QTV_CauHinh.BackgroundImage")));
            this.pic_icon_QTV_CauHinh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_icon_QTV_CauHinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pic_icon_QTV_CauHinh.Location = new System.Drawing.Point(160, 64);
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
            this.lbCauHinh.Location = new System.Drawing.Point(222, 64);
            this.lbCauHinh.Name = "lbCauHinh";
            this.lbCauHinh.Size = new System.Drawing.Size(361, 47);
            this.lbCauHinh.TabIndex = 31;
            this.lbCauHinh.Text = "CẤU HÌNH CHUNG";
            this.lbCauHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_QTV_CauHinhHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlContent);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_QTV_CauHinhHeThong";
            this.Size = new System.Drawing.Size(1047, 595);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TiGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_VAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_Luu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_icon_QTV_CauHinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ComboBox comboBox_TienTe;
        private System.Windows.Forms.ComboBox comboBox_NgayGio;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.PictureBox pic_icon_QTV_Luu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lbDonViTT;
        private System.Windows.Forms.Label lbDinhDang;
        private System.Windows.Forms.PictureBox pic_icon_QTV_CauHinh;
        private System.Windows.Forms.Label lbCauHinh;
        private System.Windows.Forms.ComboBox comboBox_NgonNgu;
        private System.Windows.Forms.Label lbNgonNgu;
        private System.Windows.Forms.Label lbTiGia;
        private System.Windows.Forms.Label lbGioCheckin;
        private System.Windows.Forms.Label lbThueVAT;
        private System.Windows.Forms.NumericUpDown nud_TiGia;
        private System.Windows.Forms.NumericUpDown nud_VAT;
        private System.Windows.Forms.DateTimePicker dtp_CheckOut;
        private System.Windows.Forms.Label lbGioCheckout;
        private System.Windows.Forms.DateTimePicker dtp_CheckIn;
    }
}
