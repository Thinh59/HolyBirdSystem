namespace QL_HolyBird
{
    partial class QL_DSHD
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb_QL_DSHD_Ma = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lab_QL_DSHD_MD = new System.Windows.Forms.Label();
            this.lab_QL_DSHD_Ngay = new System.Windows.Forms.Label();
            this.dat_QL_DSHD = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT_QL_HD_NL = new System.Windows.Forms.DateTimePicker();
            this.lab_QL_DSNV = new System.Windows.Forms.Label();
            this.btn_QL_DSHD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_QL_DSHD = new System.Windows.Forms.Panel();
            this.combo_QL_HD_TT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_QL_DM = new System.Windows.Forms.CheckBox();
            this.cbBox_QL_DemoGiaiQuyet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_DSHD)).BeginInit();
            this.pnl_QL_DSHD.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_QL_DSHD_Ma
            // 
            this.tb_QL_DSHD_Ma.Location = new System.Drawing.Point(408, 28);
            this.tb_QL_DSHD_Ma.Margin = new System.Windows.Forms.Padding(2);
            this.tb_QL_DSHD_Ma.Name = "tb_QL_DSHD_Ma";
            this.tb_QL_DSHD_Ma.Size = new System.Drawing.Size(203, 22);
            this.tb_QL_DSHD_Ma.TabIndex = 1;
            this.tb_QL_DSHD_Ma.TextChanged += new System.EventHandler(this.tb_QL_DSHD_Ma_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lab_QL_DSHD_MD
            // 
            this.lab_QL_DSHD_MD.AutoSize = true;
            this.lab_QL_DSHD_MD.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSHD_MD.Location = new System.Drawing.Point(69, 22);
            this.lab_QL_DSHD_MD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSHD_MD.Name = "lab_QL_DSHD_MD";
            this.lab_QL_DSHD_MD.Size = new System.Drawing.Size(301, 25);
            this.lab_QL_DSHD_MD.TabIndex = 5;
            this.lab_QL_DSHD_MD.Text = "Mã hóa đơn/Mã đoàn/Nhân viên:";
            this.lab_QL_DSHD_MD.Click += new System.EventHandler(this.lab_QL_DSHD_MD_Click);
            // 
            // lab_QL_DSHD_Ngay
            // 
            this.lab_QL_DSHD_Ngay.AutoSize = true;
            this.lab_QL_DSHD_Ngay.BackColor = System.Drawing.Color.PowderBlue;
            this.lab_QL_DSHD_Ngay.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSHD_Ngay.Location = new System.Drawing.Point(69, 75);
            this.lab_QL_DSHD_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSHD_Ngay.Name = "lab_QL_DSHD_Ngay";
            this.lab_QL_DSHD_Ngay.Size = new System.Drawing.Size(104, 25);
            this.lab_QL_DSHD_Ngay.TabIndex = 7;
            this.lab_QL_DSHD_Ngay.Text = "Ngày Lập:";
            // 
            // dat_QL_DSHD
            // 
            this.dat_QL_DSHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dat_QL_DSHD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dat_QL_DSHD.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dat_QL_DSHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dat_QL_DSHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dat_QL_DSHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaDoan,
            this.NgayLap,
            this.HoTenNV,
            this.TrangThaiHD,
            this.TongTien});
            this.dat_QL_DSHD.EnableHeadersVisualStyles = false;
            this.dat_QL_DSHD.Location = new System.Drawing.Point(39, 382);
            this.dat_QL_DSHD.Margin = new System.Windows.Forms.Padding(2);
            this.dat_QL_DSHD.Name = "dat_QL_DSHD";
            this.dat_QL_DSHD.RowHeadersWidth = 82;
            this.dat_QL_DSHD.RowTemplate.Height = 33;
            this.dat_QL_DSHD.Size = new System.Drawing.Size(1138, 352);
            this.dat_QL_DSHD.TabIndex = 13;
            this.dat_QL_DSHD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_QL_DSHD_CellContentClick);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "Mã Hóa Đơn";
            this.MaHD.MinimumWidth = 10;
            this.MaHD.Name = "MaHD";
            // 
            // MaDoan
            // 
            this.MaDoan.DataPropertyName = "MaDoan";
            this.MaDoan.HeaderText = "Mã Đoàn";
            this.MaDoan.MinimumWidth = 10;
            this.MaDoan.Name = "MaDoan";
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày Lập HĐ";
            this.NgayLap.MinimumWidth = 10;
            this.NgayLap.Name = "NgayLap";
            // 
            // HoTenNV
            // 
            this.HoTenNV.DataPropertyName = "HoTenNV";
            this.HoTenNV.HeaderText = "Nhân Viên";
            this.HoTenNV.MinimumWidth = 10;
            this.HoTenNV.Name = "HoTenNV";
            // 
            // TrangThaiHD
            // 
            this.TrangThaiHD.DataPropertyName = "TrangThaiHD";
            this.TrangThaiHD.HeaderText = "Trạng Thái";
            this.TrangThaiHD.MinimumWidth = 10;
            this.TrangThaiHD.Name = "TrangThaiHD";
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.MinimumWidth = 10;
            this.TongTien.Name = "TongTien";
            // 
            // DT_QL_HD_NL
            // 
            this.DT_QL_HD_NL.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_QL_HD_NL.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DT_QL_HD_NL.Location = new System.Drawing.Point(213, 71);
            this.DT_QL_HD_NL.Margin = new System.Windows.Forms.Padding(2);
            this.DT_QL_HD_NL.Name = "DT_QL_HD_NL";
            this.DT_QL_HD_NL.Size = new System.Drawing.Size(143, 33);
            this.DT_QL_HD_NL.TabIndex = 14;
            this.DT_QL_HD_NL.ValueChanged += new System.EventHandler(this.DT_QL_HD_NL_ValueChanged);
            // 
            // lab_QL_DSNV
            // 
            this.lab_QL_DSNV.AutoSize = true;
            this.lab_QL_DSNV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_QL_DSNV.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSNV.ForeColor = System.Drawing.Color.Teal;
            this.lab_QL_DSNV.Location = new System.Drawing.Point(407, 54);
            this.lab_QL_DSNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSNV.Name = "lab_QL_DSNV";
            this.lab_QL_DSNV.Size = new System.Drawing.Size(436, 47);
            this.lab_QL_DSNV.TabIndex = 17;
            this.lab_QL_DSNV.Text = "DANH SÁCH HÓA ĐƠN";
            // 
            // btn_QL_DSHD
            // 
            this.btn_QL_DSHD.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_DSHD.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_DSHD.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_DSHD.Location = new System.Drawing.Point(314, 128);
            this.btn_QL_DSHD.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_DSHD.Name = "btn_QL_DSHD";
            this.btn_QL_DSHD.Size = new System.Drawing.Size(132, 43);
            this.btn_QL_DSHD.TabIndex = 25;
            this.btn_QL_DSHD.Text = "Tìm Kiếm";
            this.btn_QL_DSHD.UseVisualStyleBackColor = false;
            this.btn_QL_DSHD.Click += new System.EventHandler(this.btn_QL_DSHD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 26;
            // 
            // pnl_QL_DSHD
            // 
            this.pnl_QL_DSHD.BackColor = System.Drawing.Color.PowderBlue;
            this.pnl_QL_DSHD.Controls.Add(this.combo_QL_HD_TT);
            this.pnl_QL_DSHD.Controls.Add(this.label2);
            this.pnl_QL_DSHD.Controls.Add(this.btn_QL_DSHD);
            this.pnl_QL_DSHD.Controls.Add(this.lab_QL_DSHD_MD);
            this.pnl_QL_DSHD.Controls.Add(this.tb_QL_DSHD_Ma);
            this.pnl_QL_DSHD.Controls.Add(this.DT_QL_HD_NL);
            this.pnl_QL_DSHD.Controls.Add(this.lab_QL_DSHD_Ngay);
            this.pnl_QL_DSHD.Location = new System.Drawing.Point(234, 165);
            this.pnl_QL_DSHD.Name = "pnl_QL_DSHD";
            this.pnl_QL_DSHD.Size = new System.Drawing.Size(765, 183);
            this.pnl_QL_DSHD.TabIndex = 27;
            // 
            // combo_QL_HD_TT
            // 
            this.combo_QL_HD_TT.FormattingEnabled = true;
            this.combo_QL_HD_TT.Items.AddRange(new object[] {
            "---Tất cả---",
            "Chưa thanh toán",
            "Đã thanh toán"});
            this.combo_QL_HD_TT.Location = new System.Drawing.Point(547, 76);
            this.combo_QL_HD_TT.Margin = new System.Windows.Forms.Padding(2);
            this.combo_QL_HD_TT.Name = "combo_QL_HD_TT";
            this.combo_QL_HD_TT.Size = new System.Drawing.Size(107, 24);
            this.combo_QL_HD_TT.TabIndex = 28;
            this.combo_QL_HD_TT.SelectedIndexChanged += new System.EventHandler(this.combo_QL_HD_TT_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PowderBlue;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Trạng Thái:";
            // 
            // checkBox_QL_DM
            // 
            this.checkBox_QL_DM.AutoSize = true;
            this.checkBox_QL_DM.Location = new System.Drawing.Point(28, 25);
            this.checkBox_QL_DM.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_QL_DM.Name = "checkBox_QL_DM";
            this.checkBox_QL_DM.Size = new System.Drawing.Size(107, 20);
            this.checkBox_QL_DM.TabIndex = 96;
            this.checkBox_QL_DM.Text = "Check Demo";
            this.checkBox_QL_DM.UseVisualStyleBackColor = true;
            this.checkBox_QL_DM.CheckedChanged += new System.EventHandler(this.checkBox_QL_DM_CheckedChanged);
            // 
            // cbBox_QL_DemoGiaiQuyet
            // 
            this.cbBox_QL_DemoGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBox_QL_DemoGiaiQuyet.FormattingEnabled = true;
            this.cbBox_QL_DemoGiaiQuyet.Items.AddRange(new object[] {
            "Normal ",
            "Demo",
            "Giải quyết"});
            this.cbBox_QL_DemoGiaiQuyet.Location = new System.Drawing.Point(143, 24);
            this.cbBox_QL_DemoGiaiQuyet.Margin = new System.Windows.Forms.Padding(2);
            this.cbBox_QL_DemoGiaiQuyet.Name = "cbBox_QL_DemoGiaiQuyet";
            this.cbBox_QL_DemoGiaiQuyet.Size = new System.Drawing.Size(146, 23);
            this.cbBox_QL_DemoGiaiQuyet.TabIndex = 95;
            this.cbBox_QL_DemoGiaiQuyet.SelectedIndexChanged += new System.EventHandler(this.cbBox_QL_DemoGiaiQuyet_SelectedIndexChanged);
            // 
            // QL_DSHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.checkBox_QL_DM);
            this.Controls.Add(this.cbBox_QL_DemoGiaiQuyet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_QL_DSNV);
            this.Controls.Add(this.dat_QL_DSHD);
            this.Controls.Add(this.pnl_QL_DSHD);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QL_DSHD";
            this.Size = new System.Drawing.Size(1216, 753);
            this.Load += new System.EventHandler(this.QL_DSHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_DSHD)).EndInit();
            this.pnl_QL_DSHD.ResumeLayout(false);
            this.pnl_QL_DSHD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_QL_DSHD_Ma;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lab_QL_DSHD_MD;
        private System.Windows.Forms.Label lab_QL_DSHD_Ngay;
        private System.Windows.Forms.DataGridView dat_QL_DSHD;
        private System.Windows.Forms.DateTimePicker DT_QL_HD_NL;
        private System.Windows.Forms.Label lab_QL_DSNV;
        private System.Windows.Forms.Button btn_QL_DSHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_QL_DSHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_QL_HD_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.CheckBox checkBox_QL_DM;
        private System.Windows.Forms.ComboBox cbBox_QL_DemoGiaiQuyet;
    }
}
