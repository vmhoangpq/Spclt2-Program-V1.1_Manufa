namespace WindowsFormsApp2
{
    partial class FormNhapKho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhapKho));
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtQRcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewNk = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.ckbID = new System.Windows.Forms.CheckBox();
            this.radDefault = new System.Windows.Forms.RadioButton();
            this.radAuto = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNk)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Số Nhân Viên";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(195, 34);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(438, 26);
            this.txtID.TabIndex = 1;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtQRcode
            // 
            this.txtQRcode.Enabled = false;
            this.txtQRcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQRcode.Location = new System.Drawing.Point(195, 90);
            this.txtQRcode.Name = "txtQRcode";
            this.txtQRcode.Size = new System.Drawing.Size(438, 26);
            this.txtQRcode.TabIndex = 3;
            this.txtQRcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQRcode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scan QRcode";
            // 
            // dataGridViewNk
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNk.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewNk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNk.Location = new System.Drawing.Point(12, 153);
            this.dataGridViewNk.Name = "dataGridViewNk";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNk.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewNk.Size = new System.Drawing.Size(977, 285);
            this.dataGridViewNk.TabIndex = 4;
            this.dataGridViewNk.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewNk_RowHeaderMouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(763, 53);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 46);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SAVE DATA";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ckbID
            // 
            this.ckbID.AutoSize = true;
            this.ckbID.Location = new System.Drawing.Point(640, 39);
            this.ckbID.Name = "ckbID";
            this.ckbID.Size = new System.Drawing.Size(15, 14);
            this.ckbID.TabIndex = 6;
            this.ckbID.UseVisualStyleBackColor = true;
            this.ckbID.CheckedChanged += new System.EventHandler(this.ckbID_CheckedChanged);
            // 
            // radDefault
            // 
            this.radDefault.AutoSize = true;
            this.radDefault.Checked = true;
            this.radDefault.Location = new System.Drawing.Point(195, 66);
            this.radDefault.Name = "radDefault";
            this.radDefault.Size = new System.Drawing.Size(59, 17);
            this.radDefault.TabIndex = 7;
            this.radDefault.TabStop = true;
            this.radDefault.Text = "Default";
            this.radDefault.UseVisualStyleBackColor = true;
            // 
            // radAuto
            // 
            this.radAuto.AutoSize = true;
            this.radAuto.Location = new System.Drawing.Point(271, 66);
            this.radAuto.Name = "radAuto";
            this.radAuto.Size = new System.Drawing.Size(47, 17);
            this.radAuto.TabIndex = 8;
            this.radAuto.Text = "Auto";
            this.radAuto.UseVisualStyleBackColor = true;
            // 
            // FormNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 450);
            this.Controls.Add(this.radAuto);
            this.Controls.Add(this.radDefault);
            this.Controls.Add(this.ckbID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridViewNk);
            this.Controls.Add(this.txtQRcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spclt2_Program_V1.1 - 87";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNhapKho_FormClosing);
            this.Load += new System.EventHandler(this.FormNhapKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtQRcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewNk;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox ckbID;
        private System.Windows.Forms.RadioButton radDefault;
        private System.Windows.Forms.RadioButton radAuto;
    }
}