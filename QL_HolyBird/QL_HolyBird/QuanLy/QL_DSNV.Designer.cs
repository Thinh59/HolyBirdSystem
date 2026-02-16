namespace QL_HolyBird
{
    partial class QL_DSNV
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
            this.tb_QL_DSNV_Ma = new System.Windows.Forms.TextBox();
            this.dat_QL_DSNV = new System.Windows.Forms.DataGridView();
            this.QL_DSNV_MNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSNV_HT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSNV_NS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSNV_SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSNV_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSNV_CVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QL_DSNV_ĐL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lab_QL_DSNV = new System.Windows.Forms.Label();
            this.lab_QL_DSNV_Ma = new System.Windows.Forms.Label();
            this.btn_QL_DSNV = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.combo_QL_NV_CV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_DSNV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_QL_DSNV_Ma
            // 
            this.tb_QL_DSNV_Ma.Location = new System.Drawing.Point(474, 29);
            this.tb_QL_DSNV_Ma.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_QL_DSNV_Ma.Name = "tb_QL_DSNV_Ma";
            this.tb_QL_DSNV_Ma.Size = new System.Drawing.Size(222, 22);
            this.tb_QL_DSNV_Ma.TabIndex = 7;
            this.tb_QL_DSNV_Ma.TextChanged += new System.EventHandler(this.tb_QL_DSNV_Ma_TextChanged);
            // 
            // dat_QL_DSNV
            // 
            this.dat_QL_DSNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dat_QL_DSNV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dat_QL_DSNV.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dat_QL_DSNV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dat_QL_DSNV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dat_QL_DSNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dat_QL_DSNV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QL_DSNV_MNV,
            this.QL_DSNV_HT,
            this.QL_DSNV_NS,
            this.QL_DSNV_SDT,
            this.QL_DSNV_Email,
            this.QL_DSNV_CVu,
            this.QL_DSNV_ĐL});
            this.dat_QL_DSNV.EnableHeadersVisualStyles = false;
            this.dat_QL_DSNV.Location = new System.Drawing.Point(66, 390);
            this.dat_QL_DSNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dat_QL_DSNV.Name = "dat_QL_DSNV";
            this.dat_QL_DSNV.RowHeadersWidth = 82;
            this.dat_QL_DSNV.RowTemplate.Height = 33;
            this.dat_QL_DSNV.Size = new System.Drawing.Size(1069, 361);
            this.dat_QL_DSNV.TabIndex = 15;
            this.dat_QL_DSNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dat_QL_DSNV_CellContentClick);
            // 
            // QL_DSNV_MNV
            // 
            this.QL_DSNV_MNV.DataPropertyName = "Mã Nhân Viên";
            this.QL_DSNV_MNV.HeaderText = "Mã Nhân Viên";
            this.QL_DSNV_MNV.MinimumWidth = 10;
            this.QL_DSNV_MNV.Name = "QL_DSNV_MNV";
            // 
            // QL_DSNV_HT
            // 
            this.QL_DSNV_HT.DataPropertyName = "Họ Và Tên";
            this.QL_DSNV_HT.HeaderText = "Họ Và Tên";
            this.QL_DSNV_HT.MinimumWidth = 10;
            this.QL_DSNV_HT.Name = "QL_DSNV_HT";
            // 
            // QL_DSNV_NS
            // 
            this.QL_DSNV_NS.DataPropertyName = "Ngày Sinh";
            this.QL_DSNV_NS.HeaderText = "Ngày Sinh";
            this.QL_DSNV_NS.MinimumWidth = 10;
            this.QL_DSNV_NS.Name = "QL_DSNV_NS";
            // 
            // QL_DSNV_SDT
            // 
            this.QL_DSNV_SDT.DataPropertyName = "SĐT";
            this.QL_DSNV_SDT.HeaderText = "SĐT";
            this.QL_DSNV_SDT.MinimumWidth = 10;
            this.QL_DSNV_SDT.Name = "QL_DSNV_SDT";
            // 
            // QL_DSNV_Email
            // 
            this.QL_DSNV_Email.DataPropertyName = "Email";
            this.QL_DSNV_Email.HeaderText = "Email";
            this.QL_DSNV_Email.MinimumWidth = 10;
            this.QL_DSNV_Email.Name = "QL_DSNV_Email";
            // 
            // QL_DSNV_CVu
            // 
            this.QL_DSNV_CVu.DataPropertyName = "Chức Vụ";
            this.QL_DSNV_CVu.HeaderText = "Chức Vụ";
            this.QL_DSNV_CVu.MinimumWidth = 10;
            this.QL_DSNV_CVu.Name = "QL_DSNV_CVu";
            // 
            // QL_DSNV_ĐL
            // 
            this.QL_DSNV_ĐL.DataPropertyName = "Mã Đại Lý";
            this.QL_DSNV_ĐL.HeaderText = "Mã Đại Lý";
            this.QL_DSNV_ĐL.MinimumWidth = 10;
            this.QL_DSNV_ĐL.Name = "QL_DSNV_ĐL";
            // 
            // lab_QL_DSNV
            // 
            this.lab_QL_DSNV.AutoSize = true;
            this.lab_QL_DSNV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_QL_DSNV.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSNV.ForeColor = System.Drawing.Color.Teal;
            this.lab_QL_DSNV.Location = new System.Drawing.Point(370, 55);
            this.lab_QL_DSNV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSNV.Name = "lab_QL_DSNV";
            this.lab_QL_DSNV.Size = new System.Drawing.Size(472, 47);
            this.lab_QL_DSNV.TabIndex = 16;
            this.lab_QL_DSNV.Text = "DANH SÁCH NHÂN VIÊN";
            // 
            // lab_QL_DSNV_Ma
            // 
            this.lab_QL_DSNV_Ma.AutoSize = true;
            this.lab_QL_DSNV_Ma.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_QL_DSNV_Ma.Location = new System.Drawing.Point(69, 22);
            this.lab_QL_DSNV_Ma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_QL_DSNV_Ma.Name = "lab_QL_DSNV_Ma";
            this.lab_QL_DSNV_Ma.Size = new System.Drawing.Size(332, 25);
            this.lab_QL_DSNV_Ma.TabIndex = 17;
            this.lab_QL_DSNV_Ma.Text = "Mã nhân viên/ Tên nhân viên/Đại lý:";
            this.lab_QL_DSNV_Ma.Click += new System.EventHandler(this.lab_QL_DSNV_Ma_Click);
            // 
            // btn_QL_DSNV
            // 
            this.btn_QL_DSNV.BackColor = System.Drawing.Color.Teal;
            this.btn_QL_DSNV.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QL_DSNV.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_QL_DSNV.Location = new System.Drawing.Point(313, 138);
            this.btn_QL_DSNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_QL_DSNV.Name = "btn_QL_DSNV";
            this.btn_QL_DSNV.Size = new System.Drawing.Size(148, 32);
            this.btn_QL_DSNV.TabIndex = 24;
            this.btn_QL_DSNV.Text = "Tìm Kiếm";
            this.btn_QL_DSNV.UseVisualStyleBackColor = false;
            this.btn_QL_DSNV.Click += new System.EventHandler(this.btn_QL_DSNV_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.combo_QL_NV_CV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_QL_DSNV);
            this.panel1.Controls.Add(this.lab_QL_DSNV_Ma);
            this.panel1.Controls.Add(this.tb_QL_DSNV_Ma);
            this.panel1.Location = new System.Drawing.Point(249, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 246);
            this.panel1.TabIndex = 25;
            // 
            // combo_QL_NV_CV
            // 
            this.combo_QL_NV_CV.FormattingEnabled = true;
            this.combo_QL_NV_CV.Items.AddRange(new object[] {
            "---Tất cả---",
            "Tiếp tân",
            "Quản lý",
            "Quản trị viên"});
            this.combo_QL_NV_CV.Location = new System.Drawing.Point(474, 71);
            this.combo_QL_NV_CV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.combo_QL_NV_CV.Name = "combo_QL_NV_CV";
            this.combo_QL_NV_CV.Size = new System.Drawing.Size(159, 24);
            this.combo_QL_NV_CV.TabIndex = 29;
            this.combo_QL_NV_CV.SelectedIndexChanged += new System.EventHandler(this.combo_QL_NV_CV_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Chức vụ:";
            // 
            // QL_DSNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Controls.Add(this.lab_QL_DSNV);
            this.Controls.Add(this.dat_QL_DSNV);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QL_DSNV";
            this.Size = new System.Drawing.Size(1216, 753);
            this.Load += new System.EventHandler(this.QL_DSNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dat_QL_DSNV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_QL_DSNV_Ma;
        private System.Windows.Forms.DataGridView dat_QL_DSNV;
        private System.Windows.Forms.Label lab_QL_DSNV;
        private System.Windows.Forms.Label lab_QL_DSNV_Ma;
        private System.Windows.Forms.Button btn_QL_DSNV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_QL_NV_CV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSNV_MNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSNV_HT;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSNV_NS;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSNV_SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSNV_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSNV_CVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn QL_DSNV_ĐL;
    }
}
