namespace QL_HolyBird.Common
{
    partial class ALL_Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLab_ALL_LI_QMK = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ALL_LI = new System.Windows.Forms.Button();
            this.tbox_ALL_LI_MK = new System.Windows.Forms.TextBox();
            this.lab_ALL_TDN = new System.Windows.Forms.Label();
            this.tbox_ALL_LI_TDN = new System.Windows.Forms.TextBox();
            this.lab_ALL_MK = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pic_BG = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BG)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.linkLab_ALL_LI_QMK);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(515, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 462);
            this.panel2.TabIndex = 52;
            // 
            // linkLab_ALL_LI_QMK
            // 
            this.linkLab_ALL_LI_QMK.AutoSize = true;
            this.linkLab_ALL_LI_QMK.Location = new System.Drawing.Point(152, 358);
            this.linkLab_ALL_LI_QMK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLab_ALL_LI_QMK.Name = "linkLab_ALL_LI_QMK";
            this.linkLab_ALL_LI_QMK.Size = new System.Drawing.Size(104, 16);
            this.linkLab_ALL_LI_QMK.TabIndex = 51;
            this.linkLab_ALL_LI_QMK.TabStop = true;
            this.linkLab_ALL_LI_QMK.Text = "Quên Mật Khẩu?";
            this.linkLab_ALL_LI_QMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLab_ALL_LI_QMK_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.btn_ALL_LI);
            this.panel1.Controls.Add(this.tbox_ALL_LI_MK);
            this.panel1.Controls.Add(this.lab_ALL_TDN);
            this.panel1.Controls.Add(this.tbox_ALL_LI_TDN);
            this.panel1.Controls.Add(this.lab_ALL_MK);
            this.panel1.Location = new System.Drawing.Point(59, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 263);
            this.panel1.TabIndex = 48;
            // 
            // btn_ALL_LI
            // 
            this.btn_ALL_LI.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_ALL_LI.Location = new System.Drawing.Point(102, 199);
            this.btn_ALL_LI.Name = "btn_ALL_LI";
            this.btn_ALL_LI.Size = new System.Drawing.Size(108, 37);
            this.btn_ALL_LI.TabIndex = 41;
            this.btn_ALL_LI.Text = "Đăng Nhập";
            this.btn_ALL_LI.UseVisualStyleBackColor = false;
            this.btn_ALL_LI.Click += new System.EventHandler(this.btn_ALL_LI_Click);
            // 
            // tbox_ALL_LI_MK
            // 
            this.tbox_ALL_LI_MK.Location = new System.Drawing.Point(34, 155);
            this.tbox_ALL_LI_MK.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_ALL_LI_MK.Name = "tbox_ALL_LI_MK";
            this.tbox_ALL_LI_MK.PasswordChar = '*';
            this.tbox_ALL_LI_MK.Size = new System.Drawing.Size(219, 22);
            this.tbox_ALL_LI_MK.TabIndex = 47;
            // 
            // lab_ALL_TDN
            // 
            this.lab_ALL_TDN.AutoSize = true;
            this.lab_ALL_TDN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_ALL_TDN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ALL_TDN.Location = new System.Drawing.Point(25, 46);
            this.lab_ALL_TDN.Name = "lab_ALL_TDN";
            this.lab_ALL_TDN.Size = new System.Drawing.Size(149, 25);
            this.lab_ALL_TDN.TabIndex = 44;
            this.lab_ALL_TDN.Text = "Tên Đăng Nhập:";
            // 
            // tbox_ALL_LI_TDN
            // 
            this.tbox_ALL_LI_TDN.Location = new System.Drawing.Point(34, 82);
            this.tbox_ALL_LI_TDN.Margin = new System.Windows.Forms.Padding(2);
            this.tbox_ALL_LI_TDN.Name = "tbox_ALL_LI_TDN";
            this.tbox_ALL_LI_TDN.Size = new System.Drawing.Size(219, 22);
            this.tbox_ALL_LI_TDN.TabIndex = 45;
            // 
            // lab_ALL_MK
            // 
            this.lab_ALL_MK.AutoSize = true;
            this.lab_ALL_MK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_ALL_MK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_ALL_MK.Location = new System.Drawing.Point(25, 118);
            this.lab_ALL_MK.Name = "lab_ALL_MK";
            this.lab_ALL_MK.Size = new System.Drawing.Size(103, 25);
            this.lab_ALL_MK.TabIndex = 46;
            this.lab_ALL_MK.Text = "Mật Khẩu:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.pic_BG);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1482, 753);
            this.panel3.TabIndex = 53;
            // 
            // pic_BG
            // 
            this.pic_BG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_BG.Image = global::QL_HolyBird.Properties.Resources.BG_HLB;
            this.pic_BG.Location = new System.Drawing.Point(0, 0);
            this.pic_BG.Name = "pic_BG";
            this.pic_BG.Size = new System.Drawing.Size(1482, 753);
            this.pic_BG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_BG.TabIndex = 53;
            this.pic_BG.TabStop = false;
            // 
            // ALL_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::QL_HolyBird.Properties.Resources.BG_HLB;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.panel3);
            this.Name = "ALL_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALL_Login";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_BG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLab_ALL_LI_QMK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ALL_LI;
        private System.Windows.Forms.TextBox tbox_ALL_LI_MK;
        private System.Windows.Forms.Label lab_ALL_TDN;
        private System.Windows.Forms.TextBox tbox_ALL_LI_TDN;
        private System.Windows.Forms.Label lab_ALL_MK;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pic_BG;
    }
}