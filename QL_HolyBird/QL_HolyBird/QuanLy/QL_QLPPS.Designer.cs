namespace QL_HolyBird
{
    partial class QL_QLPPS
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
            this.dat_QL_QLPPS = new System.Windows.Forms.DataGridView();
            this.QL_QLPPS_Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaPPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab_QL_QLPPS = new System.Windows.Forms.Label();
            this.btn_QL_QLPPS_Xoa = new System.Windows.Forms.Button();
            this.btn_QL_QLPPS_Sua = new System.Windows.Forms.Button();
            this.btn_QL_QLPPS_Them = new System.Windows.Forms.Button();
            this.txt_QL_QLPPS_TenPPS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_QL_QLPPS_MPPS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_QL_QLPPS_DG = new System.Windows.Forms.TextBox();
            this.btn_QL_QLPPS_Luu = new System.Windows.Forms.Button();
            this.checkBox_QL_DM = new System.Windows.Forms.CheckBox();
            this.cbBox_QL_DemoGiaiQuyet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_QLPPS)).BeginInit();
            this.SuspendLayout();
            // 
            // dat_QL_QLPPS
            // 
            this.dat_QL_QLPPS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dat_QL_QLPPS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dat_QL_QLPPS.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dat_QL_QLPPS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dat_QL_QLPPS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dat_QL_QLPPS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QL_QLPPS_Chon,
            this.MaPPS,
            this.TenPPS,
            this.GiaPhi});
            this.dat_QL_QLPPS.EnableHeadersVisualStyles = false;
            this.dat_QL_QLPPS.Location = new System.Drawing.Point(208, 218);
            this.dat_QL_QLPPS.Margin = new System.Windows.Forms.Padding(2);
            this.dat_QL_QLPPS.Name = "dat_QL_QLPPS";
            this.dat_QL_QLPPS.RowHeadersWidth = 82;
            this.dat_QL_QLPPS.RowTemplate.Height = 33;
            this.dat_QL_QLPPS.Size = new System.Drawing.Size(791, 313);
            this.dat_QL_QLPPS.TabIndex = 7;
            this.dat_QL_QLPPS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_QL_PPS_CellClick);
            this.dat_QL_QLPPS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_QL_QLPPS_CellContentClick);
            // 
            // QL_QLPPS_Chon
            // 
            this.QL_QLPPS_Chon.HeaderText = "Chọn";
            this.QL_QLPPS_Chon.MinimumWidth = 10;
            this.QL_QLPPS_Chon.Name = "QL_QLPPS_Chon";
            // 
            // MaPPS
            // 
            this.MaPPS.DataPropertyName = "MaPPS";
            this.MaPPS.HeaderText = "Mã Phí Phát Sinh";
            this.MaPPS.MinimumWidth = 10;
            this.MaPPS.Name = "MaPPS";
            // 
            // TenPPS
            // 
            this.TenPPS.DataPropertyName = "TenPPS";
            this.TenPPS.HeaderText = "Tên Phí Phát Sinh";
            this.TenPPS.MinimumWidth = 10;
            this.TenPPS.Name = "TenPPS";
            // 
            // GiaPhi
            // 
            this.GiaPhi.DataPropertyName = "GiaPhi";
            this.GiaPhi.HeaderText = "Đơn Giá";
            this.GiaPhi.MinimumWidth = 10;
            this.GiaPhi.Name = "GiaPhi";
            // 
            // lab_QL_QLPPS
            // 
            this.lab_QL_QLPPS.AutoSize = true;
            this.lab_QL_QLPPS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_QL_QLPPS.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_QLPPS.ForeColor = System.Drawing.Color.Teal;
            this.lab_QL_QLPPS.Location = new System.Drawing.Point(352, 86);
            this.lab_QL_QLPPS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_QLPPS.Name = "lab_QL_QLPPS";
            this.lab_QL_QLPPS.Size = new System.Drawing.Size(489, 47);
            this.lab_QL_QLPPS.TabIndex = 15;
            this.lab_QL_QLPPS.Text = "QUẢN LÝ PHÍ PHÁT SINH";
            // 
            // btn_QL_QLPPS_Xoa
            // 
            this.btn_QL_QLPPS_Xoa.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLPPS_Xoa.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLPPS_Xoa.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLPPS_Xoa.Location = new System.Drawing.Point(829, 662);
            this.btn_QL_QLPPS_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLPPS_Xoa.Name = "btn_QL_QLPPS_Xoa";
            this.btn_QL_QLPPS_Xoa.Size = new System.Drawing.Size(92, 32);
            this.btn_QL_QLPPS_Xoa.TabIndex = 20;
            this.btn_QL_QLPPS_Xoa.Text = "Xóa";
            this.btn_QL_QLPPS_Xoa.UseVisualStyleBackColor = false;
            this.btn_QL_QLPPS_Xoa.Click += new System.EventHandler(this.btn_QL_QLP_Xoa_Click);
            // 
            // btn_QL_QLPPS_Sua
            // 
            this.btn_QL_QLPPS_Sua.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLPPS_Sua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLPPS_Sua.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLPPS_Sua.Location = new System.Drawing.Point(639, 662);
            this.btn_QL_QLPPS_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLPPS_Sua.Name = "btn_QL_QLPPS_Sua";
            this.btn_QL_QLPPS_Sua.Size = new System.Drawing.Size(96, 32);
            this.btn_QL_QLPPS_Sua.TabIndex = 19;
            this.btn_QL_QLPPS_Sua.Text = "Sửa";
            this.btn_QL_QLPPS_Sua.UseVisualStyleBackColor = false;
            this.btn_QL_QLPPS_Sua.Click += new System.EventHandler(this.btn_QL_QLP_Sua_Click);
            // 
            // btn_QL_QLPPS_Them
            // 
            this.btn_QL_QLPPS_Them.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLPPS_Them.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLPPS_Them.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLPPS_Them.Location = new System.Drawing.Point(250, 662);
            this.btn_QL_QLPPS_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLPPS_Them.Name = "btn_QL_QLPPS_Them";
            this.btn_QL_QLPPS_Them.Size = new System.Drawing.Size(97, 32);
            this.btn_QL_QLPPS_Them.TabIndex = 18;
            this.btn_QL_QLPPS_Them.Text = "Thêm";
            this.btn_QL_QLPPS_Them.UseVisualStyleBackColor = false;
            this.btn_QL_QLPPS_Them.Click += new System.EventHandler(this.btn_QL_QLP_Them_Click);
            // 
            // txt_QL_QLPPS_TenPPS
            // 
            this.txt_QL_QLPPS_TenPPS.Location = new System.Drawing.Point(607, 586);
            this.txt_QL_QLPPS_TenPPS.Margin = new System.Windows.Forms.Padding(2);
            this.txt_QL_QLPPS_TenPPS.Name = "txt_QL_QLPPS_TenPPS";
            this.txt_QL_QLPPS_TenPPS.Size = new System.Drawing.Size(68, 22);
            this.txt_QL_QLPPS_TenPPS.TabIndex = 33;
            this.txt_QL_QLPPS_TenPPS.TextChanged += new System.EventHandler(this.txt_QL_QLPPS_TenPPS_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(509, 590);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tên PPS:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 593);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Mã PPS:";
            // 
            // txt_QL_QLPPS_MPPS
            // 
            this.txt_QL_QLPPS_MPPS.Location = new System.Drawing.Point(325, 586);
            this.txt_QL_QLPPS_MPPS.Margin = new System.Windows.Forms.Padding(2);
            this.txt_QL_QLPPS_MPPS.Name = "txt_QL_QLPPS_MPPS";
            this.txt_QL_QLPPS_MPPS.Size = new System.Drawing.Size(68, 22);
            this.txt_QL_QLPPS_MPPS.TabIndex = 30;
            this.txt_QL_QLPPS_MPPS.TextChanged += new System.EventHandler(this.txt_QL_QLPPS_MPPS_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(797, 590);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Đơn Giá:";
            // 
            // txt_QL_QLPPS_DG
            // 
            this.txt_QL_QLPPS_DG.Location = new System.Drawing.Point(911, 586);
            this.txt_QL_QLPPS_DG.Margin = new System.Windows.Forms.Padding(2);
            this.txt_QL_QLPPS_DG.Name = "txt_QL_QLPPS_DG";
            this.txt_QL_QLPPS_DG.Size = new System.Drawing.Size(68, 22);
            this.txt_QL_QLPPS_DG.TabIndex = 35;
            // 
            // btn_QL_QLPPS_Luu
            // 
            this.btn_QL_QLPPS_Luu.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLPPS_Luu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLPPS_Luu.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLPPS_Luu.Location = new System.Drawing.Point(444, 662);
            this.btn_QL_QLPPS_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLPPS_Luu.Name = "btn_QL_QLPPS_Luu";
            this.btn_QL_QLPPS_Luu.Size = new System.Drawing.Size(96, 32);
            this.btn_QL_QLPPS_Luu.TabIndex = 36;
            this.btn_QL_QLPPS_Luu.Text = "Lưu";
            this.btn_QL_QLPPS_Luu.UseVisualStyleBackColor = false;
            this.btn_QL_QLPPS_Luu.Click += new System.EventHandler(this.btn_QL_QLPPS_Luu_Click);
            // 
            // checkBox_QL_DM
            // 
            this.checkBox_QL_DM.AutoSize = true;
            this.checkBox_QL_DM.Location = new System.Drawing.Point(20, 26);
            this.checkBox_QL_DM.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_QL_DM.Name = "checkBox_QL_DM";
            this.checkBox_QL_DM.Size = new System.Drawing.Size(107, 20);
            this.checkBox_QL_DM.TabIndex = 98;
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
            "Demo TH2",
            "Demo TH8",
            "Giải quyết"});
            this.cbBox_QL_DemoGiaiQuyet.Location = new System.Drawing.Point(135, 25);
            this.cbBox_QL_DemoGiaiQuyet.Margin = new System.Windows.Forms.Padding(2);
            this.cbBox_QL_DemoGiaiQuyet.Name = "cbBox_QL_DemoGiaiQuyet";
            this.cbBox_QL_DemoGiaiQuyet.Size = new System.Drawing.Size(146, 23);
            this.cbBox_QL_DemoGiaiQuyet.TabIndex = 97;
            this.cbBox_QL_DemoGiaiQuyet.SelectedIndexChanged += new System.EventHandler(this.cbBox_QL_DemoGiaiQuyet_SelectedIndexChanged);
            // 
            // QL_QLPPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.checkBox_QL_DM);
            this.Controls.Add(this.cbBox_QL_DemoGiaiQuyet);
            this.Controls.Add(this.btn_QL_QLPPS_Luu);
            this.Controls.Add(this.txt_QL_QLPPS_DG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_QL_QLPPS_TenPPS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_QL_QLPPS_MPPS);
            this.Controls.Add(this.btn_QL_QLPPS_Xoa);
            this.Controls.Add(this.btn_QL_QLPPS_Sua);
            this.Controls.Add(this.btn_QL_QLPPS_Them);
            this.Controls.Add(this.lab_QL_QLPPS);
            this.Controls.Add(this.dat_QL_QLPPS);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QL_QLPPS";
            this.Size = new System.Drawing.Size(1216, 753);
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_QLPPS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dat_QL_QLPPS;
        private System.Windows.Forms.Label lab_QL_QLPPS;
        private System.Windows.Forms.Button btn_QL_QLPPS_Xoa;
        private System.Windows.Forms.Button btn_QL_QLPPS_Sua;
        private System.Windows.Forms.Button btn_QL_QLPPS_Them;
        private System.Windows.Forms.TextBox txt_QL_QLPPS_TenPPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_QL_QLPPS_MPPS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_QL_QLPPS_DG;
        private System.Windows.Forms.Button btn_QL_QLPPS_Luu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QL_QLPPS_Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaPhi;
        private System.Windows.Forms.CheckBox checkBox_QL_DM;
        private System.Windows.Forms.ComboBox cbBox_QL_DemoGiaiQuyet;
    }
}
