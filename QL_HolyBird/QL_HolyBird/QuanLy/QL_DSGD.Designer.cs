namespace QL_HolyBird
{
    partial class QL_DSGD
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
            this.dat_QL_DSGD = new System.Windows.Forms.DataGridView();
            this.QL_DSGD_MD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSGD_TrDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSGD_SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSGD_SP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSGD_Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSGD_NgKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSGD_MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSGD_MaDL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_QL_DSGD = new System.Windows.Forms.Button();
            this.DT_QL_QLGD_NBD = new System.Windows.Forms.DateTimePicker();
            this.cbB_QL_QLGD_TT = new System.Windows.Forms.ComboBox();
            this.lab_QL_DSGD_TT = new System.Windows.Forms.Label();
            this.lab_QL_DSGD_Ngay = new System.Windows.Forms.Label();
            this.lab_QL_DSGD_MD = new System.Windows.Forms.Label();
            this.tb_QL_QLGD_MD = new System.Windows.Forms.TextBox();
            this.lab_QL_DSGD = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_TD_DM = new System.Windows.Forms.CheckBox();
            this.cbBox_TD_DemoGiaiQuyet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_DSGD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dat_QL_DSGD
            // 
            this.dat_QL_DSGD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dat_QL_DSGD.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dat_QL_DSGD.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dat_QL_DSGD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dat_QL_DSGD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dat_QL_DSGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dat_QL_DSGD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QL_DSGD_MD,
            this.QL_DSGD_TrDoan,
            this.QL_DSGD_SN,
            this.QL_DSGD_SP,
            this.QL_DSGD_Ngay,
            this.QL_DSGD_NgKT,
            this.QL_DSGD_MaNV,
            this.QL_DSGD_MaDL});
            this.dat_QL_DSGD.EnableHeadersVisualStyles = false;
            this.dat_QL_DSGD.Location = new System.Drawing.Point(43, 374);
            this.dat_QL_DSGD.Margin = new System.Windows.Forms.Padding(2);
            this.dat_QL_DSGD.Name = "dat_QL_DSGD";
            this.dat_QL_DSGD.RowHeadersWidth = 82;
            this.dat_QL_DSGD.RowTemplate.Height = 33;
            this.dat_QL_DSGD.Size = new System.Drawing.Size(1115, 353);
            this.dat_QL_DSGD.TabIndex = 1;
            this.dat_QL_DSGD.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_QL_DSGD_CellContentClick);
            // 
            // QL_DSGD_MD
            // 
            this.QL_DSGD_MD.DataPropertyName = "Mã Đoàn";
            this.QL_DSGD_MD.HeaderText = "Mã Đoàn";
            this.QL_DSGD_MD.MinimumWidth = 10;
            this.QL_DSGD_MD.Name = "QL_DSGD_MD";
            // 
            // QL_DSGD_TrDoan
            // 
            this.QL_DSGD_TrDoan.DataPropertyName = "Đại Diện";
            this.QL_DSGD_TrDoan.HeaderText = "Đại Diện Đoàn";
            this.QL_DSGD_TrDoan.MinimumWidth = 10;
            this.QL_DSGD_TrDoan.Name = "QL_DSGD_TrDoan";
            // 
            // QL_DSGD_SN
            // 
            this.QL_DSGD_SN.DataPropertyName = "Số Người";
            this.QL_DSGD_SN.HeaderText = "Số Người";
            this.QL_DSGD_SN.MinimumWidth = 10;
            this.QL_DSGD_SN.Name = "QL_DSGD_SN";
            // 
            // QL_DSGD_SP
            // 
            this.QL_DSGD_SP.DataPropertyName = "Số Phòng";
            this.QL_DSGD_SP.HeaderText = "Số Phòng";
            this.QL_DSGD_SP.MinimumWidth = 10;
            this.QL_DSGD_SP.Name = "QL_DSGD_SP";
            // 
            // QL_DSGD_Ngay
            // 
            this.QL_DSGD_Ngay.DataPropertyName = "Ngày Bắt Đầu";
            this.QL_DSGD_Ngay.HeaderText = "Ngày Bắt Đầu";
            this.QL_DSGD_Ngay.MinimumWidth = 10;
            this.QL_DSGD_Ngay.Name = "QL_DSGD_Ngay";
            // 
            // QL_DSGD_NgKT
            // 
            this.QL_DSGD_NgKT.DataPropertyName = "Ngày Kết Thúc";
            this.QL_DSGD_NgKT.HeaderText = "Ngày Kết Thúc";
            this.QL_DSGD_NgKT.MinimumWidth = 10;
            this.QL_DSGD_NgKT.Name = "QL_DSGD_NgKT";
            // 
            // QL_DSGD_MaNV
            // 
            this.QL_DSGD_MaNV.DataPropertyName = "NV Thực Hiện";
            this.QL_DSGD_MaNV.HeaderText = "Mã Nhân Viên";
            this.QL_DSGD_MaNV.MinimumWidth = 10;
            this.QL_DSGD_MaNV.Name = "QL_DSGD_MaNV";
            // 
            // QL_DSGD_MaDL
            // 
            this.QL_DSGD_MaDL.DataPropertyName = "Mã Đại Lý";
            this.QL_DSGD_MaDL.HeaderText = "Mã Đại Lý";
            this.QL_DSGD_MaDL.MinimumWidth = 10;
            this.QL_DSGD_MaDL.Name = "QL_DSGD_MaDL";
            // 
            // btn_QL_DSGD
            // 
            this.btn_QL_DSGD.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_DSGD.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_DSGD.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_DSGD.Location = new System.Drawing.Point(360, 181);
            this.btn_QL_DSGD.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_DSGD.Name = "btn_QL_DSGD";
            this.btn_QL_DSGD.Size = new System.Drawing.Size(139, 32);
            this.btn_QL_DSGD.TabIndex = 6;
            this.btn_QL_DSGD.Text = "Tìm Kiếm";
            this.btn_QL_DSGD.UseVisualStyleBackColor = false;
            this.btn_QL_DSGD.Click += new System.EventHandler(this.btn_QL_DSGD_Click);
            // 
            // DT_QL_QLGD_NBD
            // 
            this.DT_QL_QLGD_NBD.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DT_QL_QLGD_NBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DT_QL_QLGD_NBD.Location = new System.Drawing.Point(591, 265);
            this.DT_QL_QLGD_NBD.Margin = new System.Windows.Forms.Padding(2);
            this.DT_QL_QLGD_NBD.Name = "DT_QL_QLGD_NBD";
            this.DT_QL_QLGD_NBD.Size = new System.Drawing.Size(226, 33);
            this.DT_QL_QLGD_NBD.TabIndex = 5;
            this.DT_QL_QLGD_NBD.ValueChanged += new System.EventHandler(this.DT_QL_QLGD_NBD_ValueChanged);
            // 
            // cbB_QL_QLGD_TT
            // 
            this.cbB_QL_QLGD_TT.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbB_QL_QLGD_TT.FormattingEnabled = true;
            this.cbB_QL_QLGD_TT.Items.AddRange(new object[] {
            "---Tất cả---",
            "Chưa nhận phòng",
            "Đã nhận phòng"});
            this.cbB_QL_QLGD_TT.Location = new System.Drawing.Point(591, 213);
            this.cbB_QL_QLGD_TT.Margin = new System.Windows.Forms.Padding(2);
            this.cbB_QL_QLGD_TT.Name = "cbB_QL_QLGD_TT";
            this.cbB_QL_QLGD_TT.Size = new System.Drawing.Size(226, 23);
            this.cbB_QL_QLGD_TT.TabIndex = 4;
            this.cbB_QL_QLGD_TT.SelectedIndexChanged += new System.EventHandler(this.cbB_QL_QLGD_TT_SelectedIndexChanged);
            // 
            // lab_QL_DSGD_TT
            // 
            this.lab_QL_DSGD_TT.AutoSize = true;
            this.lab_QL_DSGD_TT.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSGD_TT.Location = new System.Drawing.Point(140, 77);
            this.lab_QL_DSGD_TT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSGD_TT.Name = "lab_QL_DSGD_TT";
            this.lab_QL_DSGD_TT.Size = new System.Drawing.Size(114, 25);
            this.lab_QL_DSGD_TT.TabIndex = 3;
            this.lab_QL_DSGD_TT.Text = "Trạng Thái:";
            this.lab_QL_DSGD_TT.Click += new System.EventHandler(this.label4_Click);
            // 
            // lab_QL_DSGD_Ngay
            // 
            this.lab_QL_DSGD_Ngay.AutoSize = true;
            this.lab_QL_DSGD_Ngay.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSGD_Ngay.Location = new System.Drawing.Point(140, 140);
            this.lab_QL_DSGD_Ngay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSGD_Ngay.Name = "lab_QL_DSGD_Ngay";
            this.lab_QL_DSGD_Ngay.Size = new System.Drawing.Size(144, 25);
            this.lab_QL_DSGD_Ngay.TabIndex = 2;
            this.lab_QL_DSGD_Ngay.Text = "Ngày Bắt Đầu:";
            // 
            // lab_QL_DSGD_MD
            // 
            this.lab_QL_DSGD_MD.AutoSize = true;
            this.lab_QL_DSGD_MD.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSGD_MD.Location = new System.Drawing.Point(140, 25);
            this.lab_QL_DSGD_MD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSGD_MD.Name = "lab_QL_DSGD_MD";
            this.lab_QL_DSGD_MD.Size = new System.Drawing.Size(100, 25);
            this.lab_QL_DSGD_MD.TabIndex = 1;
            this.lab_QL_DSGD_MD.Text = "Mã Đoàn:";
            // 
            // tb_QL_QLGD_MD
            // 
            this.tb_QL_QLGD_MD.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_QL_QLGD_MD.Location = new System.Drawing.Point(591, 161);
            this.tb_QL_QLGD_MD.Margin = new System.Windows.Forms.Padding(2);
            this.tb_QL_QLGD_MD.Name = "tb_QL_QLGD_MD";
            this.tb_QL_QLGD_MD.Size = new System.Drawing.Size(226, 22);
            this.tb_QL_QLGD_MD.TabIndex = 0;
            this.tb_QL_QLGD_MD.TextChanged += new System.EventHandler(this.tb_QL_QLGD_MD_TextChanged);
            // 
            // lab_QL_DSGD
            // 
            this.lab_QL_DSGD.AutoSize = true;
            this.lab_QL_DSGD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_QL_DSGD.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSGD.ForeColor = System.Drawing.Color.Teal;
            this.lab_QL_DSGD.Location = new System.Drawing.Point(353, 59);
            this.lab_QL_DSGD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSGD.Name = "lab_QL_DSGD";
            this.lab_QL_DSGD.Size = new System.Drawing.Size(464, 47);
            this.lab_QL_DSGD.TabIndex = 4;
            this.lab_QL_DSGD.Text = "DANH SÁCH GIAO DỊCH";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.lab_QL_DSGD_MD);
            this.panel1.Controls.Add(this.btn_QL_DSGD);
            this.panel1.Controls.Add(this.lab_QL_DSGD_TT);
            this.panel1.Controls.Add(this.lab_QL_DSGD_Ngay);
            this.panel1.Location = new System.Drawing.Point(231, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 225);
            this.panel1.TabIndex = 7;
            // 
            // checkBox_TD_DM
            // 
            this.checkBox_TD_DM.AutoSize = true;
            this.checkBox_TD_DM.Location = new System.Drawing.Point(17, 30);
            this.checkBox_TD_DM.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_TD_DM.Name = "checkBox_TD_DM";
            this.checkBox_TD_DM.Size = new System.Drawing.Size(107, 20);
            this.checkBox_TD_DM.TabIndex = 97;
            this.checkBox_TD_DM.Text = "Check Demo";
            this.checkBox_TD_DM.UseVisualStyleBackColor = true;
            this.checkBox_TD_DM.CheckedChanged += new System.EventHandler(this.checkBox_TD_DM_CheckedChanged);
            // 
            // cbBox_TD_DemoGiaiQuyet
            // 
            this.cbBox_TD_DemoGiaiQuyet.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBox_TD_DemoGiaiQuyet.FormattingEnabled = true;
            this.cbBox_TD_DemoGiaiQuyet.Items.AddRange(new object[] {
            "Normal",
            "Demo",
            "Giải quyết"});
            this.cbBox_TD_DemoGiaiQuyet.Location = new System.Drawing.Point(132, 29);
            this.cbBox_TD_DemoGiaiQuyet.Margin = new System.Windows.Forms.Padding(2);
            this.cbBox_TD_DemoGiaiQuyet.Name = "cbBox_TD_DemoGiaiQuyet";
            this.cbBox_TD_DemoGiaiQuyet.Size = new System.Drawing.Size(146, 23);
            this.cbBox_TD_DemoGiaiQuyet.TabIndex = 96;
            this.cbBox_TD_DemoGiaiQuyet.SelectedIndexChanged += new System.EventHandler(this.cbBox_TD_DemoGiaiQuyet_SelectedIndexChanged);
            // 
            // QL_DSGD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.checkBox_TD_DM);
            this.Controls.Add(this.cbBox_TD_DemoGiaiQuyet);
            this.Controls.Add(this.tb_QL_QLGD_MD);
            this.Controls.Add(this.lab_QL_DSGD);
            this.Controls.Add(this.cbB_QL_QLGD_TT);
            this.Controls.Add(this.DT_QL_QLGD_NBD);
            this.Controls.Add(this.dat_QL_DSGD);
            this.Controls.Add(this.panel1);
            this.Name = "QL_DSGD";
            this.Size = new System.Drawing.Size(1218, 753);
            this.Load += new System.EventHandler(this.QL_DSGD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_DSGD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dat_QL_DSGD;
        private System.Windows.Forms.Button btn_QL_DSGD;
        private System.Windows.Forms.DateTimePicker DT_QL_QLGD_NBD;
        private System.Windows.Forms.ComboBox cbB_QL_QLGD_TT;
        private System.Windows.Forms.Label lab_QL_DSGD_TT;
        private System.Windows.Forms.Label lab_QL_DSGD_Ngay;
        private System.Windows.Forms.Label lab_QL_DSGD_MD;
        private System.Windows.Forms.TextBox tb_QL_QLGD_MD;
        private System.Windows.Forms.Label lab_QL_DSGD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_MD;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_TrDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_SP;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_NgKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSGD_MaDL;
        private System.Windows.Forms.CheckBox checkBox_TD_DM;
        private System.Windows.Forms.ComboBox cbBox_TD_DemoGiaiQuyet;
    }
}
