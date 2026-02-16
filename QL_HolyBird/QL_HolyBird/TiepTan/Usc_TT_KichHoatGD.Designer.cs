namespace QL_HolyBird.TiepTan
{
    partial class Usc_TT_KichHoatGD
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
            this.lbl_TT2_TaoTKKH = new System.Windows.Forms.Label();
            this.dgv_TT3_NhanPhongCTGD = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_TT3_MaDoan = new System.Windows.Forms.ComboBox();
            this.lbl_TT2_UserName = new System.Windows.Forms.Label();
            this.btn_TT3_XacNhan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TT3_NhanPhongCTGD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_TT2_TaoTKKH
            // 
            this.lbl_TT2_TaoTKKH.AutoSize = true;
            this.lbl_TT2_TaoTKKH.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_TT2_TaoTKKH.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_TT2_TaoTKKH.ForeColor = System.Drawing.Color.Teal;
            this.lbl_TT2_TaoTKKH.Location = new System.Drawing.Point(389, 64);
            this.lbl_TT2_TaoTKKH.Name = "lbl_TT2_TaoTKKH";
            this.lbl_TT2_TaoTKKH.Size = new System.Drawing.Size(501, 47);
            this.lbl_TT2_TaoTKKH.TabIndex = 29;
            this.lbl_TT2_TaoTKKH.Text = "GIAO DỊCH NHẬN PHÒNG";
            // 
            // dgv_TT3_NhanPhongCTGD
            // 
            this.dgv_TT3_NhanPhongCTGD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_TT3_NhanPhongCTGD.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_TT3_NhanPhongCTGD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_TT3_NhanPhongCTGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TT3_NhanPhongCTGD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgv_TT3_NhanPhongCTGD.EnableHeadersVisualStyles = false;
            this.dgv_TT3_NhanPhongCTGD.Location = new System.Drawing.Point(267, 153);
            this.dgv_TT3_NhanPhongCTGD.Name = "dgv_TT3_NhanPhongCTGD";
            this.dgv_TT3_NhanPhongCTGD.RowHeadersWidth = 51;
            this.dgv_TT3_NhanPhongCTGD.RowTemplate.Height = 24;
            this.dgv_TT3_NhanPhongCTGD.Size = new System.Drawing.Size(887, 551);
            this.dgv_TT3_NhanPhongCTGD.TabIndex = 36;
            this.dgv_TT3_NhanPhongCTGD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TT3_NhanPhongCTGD_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Đã Đến Nhận";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mã CTGD";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CCCD";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Mã Phòng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Ngày Bắt Đầu";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Ngày Kết Thúc";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.cmb_TT3_MaDoan);
            this.panel1.Controls.Add(this.lbl_TT2_UserName);
            this.panel1.Location = new System.Drawing.Point(3, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 309);
            this.panel1.TabIndex = 37;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmb_TT3_MaDoan
            // 
            this.cmb_TT3_MaDoan.FormattingEnabled = true;
            this.cmb_TT3_MaDoan.Location = new System.Drawing.Point(15, 109);
            this.cmb_TT3_MaDoan.Name = "cmb_TT3_MaDoan";
            this.cmb_TT3_MaDoan.Size = new System.Drawing.Size(227, 24);
            this.cmb_TT3_MaDoan.TabIndex = 59;
            this.cmb_TT3_MaDoan.SelectedIndexChanged += new System.EventHandler(this.cmb_TT3_MaDoan_SelectedIndexChanged);
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
            // btn_TT3_XacNhan
            // 
            this.btn_TT3_XacNhan.BackColor = System.Drawing.Color.Teal;
            this.btn_TT3_XacNhan.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TT3_XacNhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_TT3_XacNhan.Location = new System.Drawing.Point(102, 647);
            this.btn_TT3_XacNhan.Name = "btn_TT3_XacNhan";
            this.btn_TT3_XacNhan.Size = new System.Drawing.Size(143, 57);
            this.btn_TT3_XacNhan.TabIndex = 39;
            this.btn_TT3_XacNhan.Text = "Xác nhận";
            this.btn_TT3_XacNhan.UseVisualStyleBackColor = false;
            this.btn_TT3_XacNhan.Click += new System.EventHandler(this.btn_TT3_XacNhan_Click);
            // 
            // Usc_TT_KichHoatGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btn_TT3_XacNhan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_TT3_NhanPhongCTGD);
            this.Controls.Add(this.lbl_TT2_TaoTKKH);
            this.Name = "Usc_TT_KichHoatGD";
            this.Size = new System.Drawing.Size(1249, 828);
            this.Load += new System.EventHandler(this.Usc_TT_KichHoatGD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TT3_NhanPhongCTGD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_TT2_TaoTKKH;
        private System.Windows.Forms.DataGridView dgv_TT3_NhanPhongCTGD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_TT2_UserName;
        private System.Windows.Forms.Button btn_TT3_XacNhan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.ComboBox cmb_TT3_MaDoan;
    }
}
