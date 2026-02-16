namespace QL_HolyBird
{
    partial class QL_QLPhong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dat_QL_QLP = new System.Windows.Forms.DataGridView();
            this.QL_QLP_Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MucGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab_QL_QLP = new System.Windows.Forms.Label();
            this.btn_QL_QLP_Them = new System.Windows.Forms.Button();
            this.btn_QL_QLP_Sua = new System.Windows.Forms.Button();
            this.btn_QL_QLP_Xoa = new System.Windows.Forms.Button();
            this.txt_QL_QLP_MP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_QL_QLP_MLP = new System.Windows.Forms.TextBox();
            this.combo_QL_QLP_Hang = new System.Windows.Forms.ComboBox();
            this.combo_QL_QLP_HT = new System.Windows.Forms.ComboBox();
            this.txt_QL_QLP_Tang = new System.Windows.Forms.TextBox();
            this.txt_QL_QLP_Gia = new System.Windows.Forms.TextBox();
            this.combo_QL_QLP_TT = new System.Windows.Forms.ComboBox();
            this.btn_QL_QLP_Luu = new System.Windows.Forms.Button();
            this.checkBox_TD_DM = new System.Windows.Forms.CheckBox();
            this.cbBox_TD_DemoGiaiQuyet = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_QLP)).BeginInit();
            this.SuspendLayout();
            // 
            // dat_QL_QLP
            // 
            this.dat_QL_QLP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dat_QL_QLP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dat_QL_QLP.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dat_QL_QLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dat_QL_QLP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dat_QL_QLP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dat_QL_QLP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QL_QLP_Chon,
            this.MaPhong,
            this.MaLoaiPhong,
            this.Tang,
            this.Hang,
            this.HinhThuc,
            this.TrangThai,
            this.MucGia});
            this.dat_QL_QLP.EnableHeadersVisualStyles = false;
            this.dat_QL_QLP.Location = new System.Drawing.Point(136, 109);
            this.dat_QL_QLP.Margin = new System.Windows.Forms.Padding(2);
            this.dat_QL_QLP.Name = "dat_QL_QLP";
            this.dat_QL_QLP.RowHeadersWidth = 82;
            this.dat_QL_QLP.RowTemplate.Height = 33;
            this.dat_QL_QLP.Size = new System.Drawing.Size(951, 376);
            this.dat_QL_QLP.TabIndex = 0;
            this.dat_QL_QLP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_QL_QLP_CellClick);
            this.dat_QL_QLP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_QL_QLP_CellContentClick);
            // 
            // QL_QLP_Chon
            // 
            this.QL_QLP_Chon.HeaderText = "Chọn";
            this.QL_QLP_Chon.MinimumWidth = 10;
            this.QL_QLP_Chon.Name = "QL_QLP_Chon";
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã Phòng";
            this.MaPhong.MinimumWidth = 10;
            this.MaPhong.Name = "MaPhong";
            // 
            // MaLoaiPhong
            // 
            this.MaLoaiPhong.DataPropertyName = "MaLoaiPhong";
            this.MaLoaiPhong.HeaderText = "Mã Loại";
            this.MaLoaiPhong.MinimumWidth = 10;
            this.MaLoaiPhong.Name = "MaLoaiPhong";
            // 
            // Tang
            // 
            this.Tang.DataPropertyName = "Tang";
            this.Tang.HeaderText = "Tầng";
            this.Tang.MinimumWidth = 10;
            this.Tang.Name = "Tang";
            // 
            // Hang
            // 
            this.Hang.DataPropertyName = "Hang";
            this.Hang.HeaderText = "Hạng";
            this.Hang.MinimumWidth = 10;
            this.Hang.Name = "Hang";
            // 
            // HinhThuc
            // 
            this.HinhThuc.DataPropertyName = "HinhThuc";
            this.HinhThuc.HeaderText = "Hình Thức";
            this.HinhThuc.MinimumWidth = 10;
            this.HinhThuc.Name = "HinhThuc";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 10;
            this.TrangThai.Name = "TrangThai";
            // 
            // MucGia
            // 
            this.MucGia.DataPropertyName = "MucGia";
            this.MucGia.HeaderText = "Giá";
            this.MucGia.MinimumWidth = 10;
            this.MucGia.Name = "MucGia";
            // 
            // lab_QL_QLP
            // 
            this.lab_QL_QLP.AutoSize = true;
            this.lab_QL_QLP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_QL_QLP.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_QLP.ForeColor = System.Drawing.Color.Teal;
            this.lab_QL_QLP.Location = new System.Drawing.Point(431, 38);
            this.lab_QL_QLP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_QLP.Name = "lab_QL_QLP";
            this.lab_QL_QLP.Size = new System.Drawing.Size(336, 47);
            this.lab_QL_QLP.TabIndex = 14;
            this.lab_QL_QLP.Text = "QUẢN LÝ PHÒNG";
            // 
            // btn_QL_QLP_Them
            // 
            this.btn_QL_QLP_Them.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLP_Them.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLP_Them.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLP_Them.Location = new System.Drawing.Point(230, 632);
            this.btn_QL_QLP_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLP_Them.Name = "btn_QL_QLP_Them";
            this.btn_QL_QLP_Them.Size = new System.Drawing.Size(104, 32);
            this.btn_QL_QLP_Them.TabIndex = 15;
            this.btn_QL_QLP_Them.Text = "Thêm";
            this.btn_QL_QLP_Them.UseVisualStyleBackColor = false;
            this.btn_QL_QLP_Them.Click += new System.EventHandler(this.btn_QL_QLP_Them_Click);
            // 
            // btn_QL_QLP_Sua
            // 
            this.btn_QL_QLP_Sua.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLP_Sua.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLP_Sua.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLP_Sua.Location = new System.Drawing.Point(673, 632);
            this.btn_QL_QLP_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLP_Sua.Name = "btn_QL_QLP_Sua";
            this.btn_QL_QLP_Sua.Size = new System.Drawing.Size(97, 32);
            this.btn_QL_QLP_Sua.TabIndex = 16;
            this.btn_QL_QLP_Sua.Text = "Sửa";
            this.btn_QL_QLP_Sua.UseVisualStyleBackColor = false;
            this.btn_QL_QLP_Sua.Click += new System.EventHandler(this.btn_QL_QLP_Sua_Click);
            // 
            // btn_QL_QLP_Xoa
            // 
            this.btn_QL_QLP_Xoa.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLP_Xoa.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLP_Xoa.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLP_Xoa.Location = new System.Drawing.Point(925, 632);
            this.btn_QL_QLP_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLP_Xoa.Name = "btn_QL_QLP_Xoa";
            this.btn_QL_QLP_Xoa.Size = new System.Drawing.Size(93, 32);
            this.btn_QL_QLP_Xoa.TabIndex = 17;
            this.btn_QL_QLP_Xoa.Text = "Xóa";
            this.btn_QL_QLP_Xoa.UseVisualStyleBackColor = false;
            this.btn_QL_QLP_Xoa.Click += new System.EventHandler(this.btn_QL_QLP_Xoa_Click);
            // 
            // txt_QL_QLP_MP
            // 
            this.txt_QL_QLP_MP.Location = new System.Drawing.Point(267, 519);
            this.txt_QL_QLP_MP.Margin = new System.Windows.Forms.Padding(2);
            this.txt_QL_QLP_MP.Name = "txt_QL_QLP_MP";
            this.txt_QL_QLP_MP.Size = new System.Drawing.Size(68, 22);
            this.txt_QL_QLP_MP.TabIndex = 18;
            this.txt_QL_QLP_MP.TextChanged += new System.EventHandler(this.txt_QL_QLP_MP_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 523);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã Phòng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(162, 564);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mã Loại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(462, 520);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tầng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(738, 520);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Trạng Thái:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(462, 564);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hạng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(738, 564);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Hình Thức:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(965, 523);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Giá:";
            // 
            // txt_QL_QLP_MLP
            // 
            this.txt_QL_QLP_MLP.Location = new System.Drawing.Point(267, 561);
            this.txt_QL_QLP_MLP.Margin = new System.Windows.Forms.Padding(2);
            this.txt_QL_QLP_MLP.Name = "txt_QL_QLP_MLP";
            this.txt_QL_QLP_MLP.Size = new System.Drawing.Size(68, 22);
            this.txt_QL_QLP_MLP.TabIndex = 26;
            this.txt_QL_QLP_MLP.TextChanged += new System.EventHandler(this.txt_QL_QLP_MLP_TextChanged);
            // 
            // combo_QL_QLP_Hang
            // 
            this.combo_QL_QLP_Hang.FormattingEnabled = true;
            this.combo_QL_QLP_Hang.Items.AddRange(new object[] {
            "Thường",
            "Trung bình",
            "Sang",
            "Rất sang",
            "VIP"});
            this.combo_QL_QLP_Hang.Location = new System.Drawing.Point(553, 559);
            this.combo_QL_QLP_Hang.Margin = new System.Windows.Forms.Padding(2);
            this.combo_QL_QLP_Hang.Name = "combo_QL_QLP_Hang";
            this.combo_QL_QLP_Hang.Size = new System.Drawing.Size(82, 24);
            this.combo_QL_QLP_Hang.TabIndex = 27;
            this.combo_QL_QLP_Hang.SelectedIndexChanged += new System.EventHandler(this.combo_QL_QLP_Hang_SelectedIndexChanged);
            // 
            // combo_QL_QLP_HT
            // 
            this.combo_QL_QLP_HT.FormattingEnabled = true;
            this.combo_QL_QLP_HT.Items.AddRange(new object[] {
            "1 giường đơn",
            "1 giường đôi",
            "2 giường đơn",
            "2 giường đôi"});
            this.combo_QL_QLP_HT.Location = new System.Drawing.Point(869, 559);
            this.combo_QL_QLP_HT.Margin = new System.Windows.Forms.Padding(2);
            this.combo_QL_QLP_HT.Name = "combo_QL_QLP_HT";
            this.combo_QL_QLP_HT.Size = new System.Drawing.Size(82, 24);
            this.combo_QL_QLP_HT.TabIndex = 28;
            this.combo_QL_QLP_HT.SelectedIndexChanged += new System.EventHandler(this.combo_QL_QLP_HT_SelectedIndexChanged);
            // 
            // txt_QL_QLP_Tang
            // 
            this.txt_QL_QLP_Tang.Location = new System.Drawing.Point(553, 516);
            this.txt_QL_QLP_Tang.Margin = new System.Windows.Forms.Padding(2);
            this.txt_QL_QLP_Tang.Name = "txt_QL_QLP_Tang";
            this.txt_QL_QLP_Tang.Size = new System.Drawing.Size(68, 22);
            this.txt_QL_QLP_Tang.TabIndex = 29;
            this.txt_QL_QLP_Tang.TextChanged += new System.EventHandler(this.txt_QL_QLP_Tang_TextChanged);
            // 
            // txt_QL_QLP_Gia
            // 
            this.txt_QL_QLP_Gia.Location = new System.Drawing.Point(1020, 522);
            this.txt_QL_QLP_Gia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_QL_QLP_Gia.Name = "txt_QL_QLP_Gia";
            this.txt_QL_QLP_Gia.Size = new System.Drawing.Size(68, 22);
            this.txt_QL_QLP_Gia.TabIndex = 31;
            this.txt_QL_QLP_Gia.TextChanged += new System.EventHandler(this.txt_QL_QLP_Gia_TextChanged);
            // 
            // combo_QL_QLP_TT
            // 
            this.combo_QL_QLP_TT.FormattingEnabled = true;
            this.combo_QL_QLP_TT.Items.AddRange(new object[] {
            "Đang trống",
            "Đang đặt trước",
            "Đang có khách"});
            this.combo_QL_QLP_TT.Location = new System.Drawing.Point(869, 515);
            this.combo_QL_QLP_TT.Margin = new System.Windows.Forms.Padding(2);
            this.combo_QL_QLP_TT.Name = "combo_QL_QLP_TT";
            this.combo_QL_QLP_TT.Size = new System.Drawing.Size(82, 24);
            this.combo_QL_QLP_TT.TabIndex = 32;
            this.combo_QL_QLP_TT.SelectedIndexChanged += new System.EventHandler(this.combo_QL_QLP_TT_SelectedIndexChanged);
            // 
            // btn_QL_QLP_Luu
            // 
            this.btn_QL_QLP_Luu.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_QLP_Luu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_QLP_Luu.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_QLP_Luu.Location = new System.Drawing.Point(465, 632);
            this.btn_QL_QLP_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.btn_QL_QLP_Luu.Name = "btn_QL_QLP_Luu";
            this.btn_QL_QLP_Luu.Size = new System.Drawing.Size(97, 32);
            this.btn_QL_QLP_Luu.TabIndex = 33;
            this.btn_QL_QLP_Luu.Text = "Lưu";
            this.btn_QL_QLP_Luu.UseVisualStyleBackColor = false;
            this.btn_QL_QLP_Luu.Click += new System.EventHandler(this.btn_QL_QLP_Luu_Click);
            // 
            // checkBox_TD_DM
            // 
            this.checkBox_TD_DM.AutoSize = true;
            this.checkBox_TD_DM.Location = new System.Drawing.Point(30, 25);
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
            "Demo TH1",
            "Demo TH5",
            "Giải quyết"});
            this.cbBox_TD_DemoGiaiQuyet.Location = new System.Drawing.Point(145, 24);
            this.cbBox_TD_DemoGiaiQuyet.Margin = new System.Windows.Forms.Padding(2);
            this.cbBox_TD_DemoGiaiQuyet.Name = "cbBox_TD_DemoGiaiQuyet";
            this.cbBox_TD_DemoGiaiQuyet.Size = new System.Drawing.Size(146, 23);
            this.cbBox_TD_DemoGiaiQuyet.TabIndex = 96;
            this.cbBox_TD_DemoGiaiQuyet.SelectedIndexChanged += new System.EventHandler(this.cbBox_TD_DemoGiaiQuyet_SelectedIndexChanged);
            // 
            // QL_QLPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.checkBox_TD_DM);
            this.Controls.Add(this.cbBox_TD_DemoGiaiQuyet);
            this.Controls.Add(this.btn_QL_QLP_Luu);
            this.Controls.Add(this.combo_QL_QLP_TT);
            this.Controls.Add(this.txt_QL_QLP_Gia);
            this.Controls.Add(this.txt_QL_QLP_Tang);
            this.Controls.Add(this.combo_QL_QLP_HT);
            this.Controls.Add(this.combo_QL_QLP_Hang);
            this.Controls.Add(this.txt_QL_QLP_MLP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_QL_QLP_MP);
            this.Controls.Add(this.btn_QL_QLP_Xoa);
            this.Controls.Add(this.btn_QL_QLP_Sua);
            this.Controls.Add(this.btn_QL_QLP_Them);
            this.Controls.Add(this.lab_QL_QLP);
            this.Controls.Add(this.dat_QL_QLP);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QL_QLPhong";
            this.Size = new System.Drawing.Size(1216, 753);
            this.Load += new System.EventHandler(this.QL_QLPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_QLP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dat_QL_QLP;
        private System.Windows.Forms.Label lab_QL_QLP;
        private System.Windows.Forms.Button btn_QL_QLP_Them;
        private System.Windows.Forms.Button btn_QL_QLP_Sua;
        private System.Windows.Forms.Button btn_QL_QLP_Xoa;
        private System.Windows.Forms.TextBox txt_QL_QLP_MP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_QL_QLP_MLP;
        private System.Windows.Forms.ComboBox combo_QL_QLP_Hang;
        private System.Windows.Forms.ComboBox combo_QL_QLP_HT;
        private System.Windows.Forms.TextBox txt_QL_QLP_Tang;
        private System.Windows.Forms.TextBox txt_QL_QLP_Gia;
        private System.Windows.Forms.ComboBox combo_QL_QLP_TT;
        private System.Windows.Forms.Button btn_QL_QLP_Luu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QL_QLP_Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hang;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MucGia;
        private System.Windows.Forms.CheckBox checkBox_TD_DM;
        private System.Windows.Forms.ComboBox cbBox_TD_DemoGiaiQuyet;
    }
}
