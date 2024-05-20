namespace WindowsFormsApp2
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtScan = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewds = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ckbID = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLOT_no = new System.Windows.Forms.TextBox();
            this.cbSPC_no = new System.Windows.Forms.CheckBox();
            this.cbLOT_no = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewds)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "SCAN: SPC_NO";
            // 
            // txtScan
            // 
            this.txtScan.Enabled = false;
            this.txtScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScan.ForeColor = System.Drawing.Color.Purple;
            this.txtScan.Location = new System.Drawing.Point(160, 78);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(450, 22);
            this.txtScan.TabIndex = 1;
            this.txtScan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScan_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewds);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 264);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Information";
            // 
            // dataGridViewds
            // 
            this.dataGridViewds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewds.Location = new System.Drawing.Point(6, 21);
            this.dataGridViewds.Name = "dataGridViewds";
            this.dataGridViewds.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewds.RowTemplate.Height = 30;
            this.dataGridViewds.Size = new System.Drawing.Size(868, 237);
            this.dataGridViewds.TabIndex = 0;
            this.dataGridViewds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewds_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(683, 51);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Location = new System.Drawing.Point(787, 51);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 29);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ckbID
            // 
            this.ckbID.AutoSize = true;
            this.ckbID.Location = new System.Drawing.Point(617, 29);
            this.ckbID.Name = "ckbID";
            this.ckbID.Size = new System.Drawing.Size(15, 14);
            this.ckbID.TabIndex = 7;
            this.ckbID.UseVisualStyleBackColor = true;
            this.ckbID.CheckedChanged += new System.EventHandler(this.ckbID_CheckedChanged);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(160, 25);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(450, 22);
            this.txtID.TabIndex = 0;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã Số Nhân Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "SCAN: LOT_NO";
            // 
            // txtLOT_no
            // 
            this.txtLOT_no.Enabled = false;
            this.txtLOT_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLOT_no.ForeColor = System.Drawing.Color.Purple;
            this.txtLOT_no.Location = new System.Drawing.Point(160, 124);
            this.txtLOT_no.Name = "txtLOT_no";
            this.txtLOT_no.Size = new System.Drawing.Size(450, 22);
            this.txtLOT_no.TabIndex = 1;
            this.txtLOT_no.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLOT_no_KeyPress);
            // 
            // cbSPC_no
            // 
            this.cbSPC_no.AutoSize = true;
            this.cbSPC_no.Enabled = false;
            this.cbSPC_no.Location = new System.Drawing.Point(616, 83);
            this.cbSPC_no.Name = "cbSPC_no";
            this.cbSPC_no.Size = new System.Drawing.Size(15, 14);
            this.cbSPC_no.TabIndex = 7;
            this.cbSPC_no.UseVisualStyleBackColor = true;
            this.cbSPC_no.CheckedChanged += new System.EventHandler(this.cbSPC_no_CheckedChanged);
            // 
            // cbLOT_no
            // 
            this.cbLOT_no.AutoSize = true;
            this.cbLOT_no.Enabled = false;
            this.cbLOT_no.Location = new System.Drawing.Point(616, 129);
            this.cbLOT_no.Name = "cbLOT_no";
            this.cbLOT_no.Size = new System.Drawing.Size(15, 14);
            this.cbLOT_no.TabIndex = 7;
            this.cbLOT_no.UseVisualStyleBackColor = true;
            this.cbLOT_no.CheckedChanged += new System.EventHandler(this.cbLOT_no_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 442);
            this.Controls.Add(this.cbLOT_no);
            this.Controls.Add(this.cbSPC_no);
            this.Controls.Add(this.ckbID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLOT_no);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtScan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spclt2_Program_V1.1 - 87*";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewds;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.CheckBox ckbID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLOT_no;
        private System.Windows.Forms.CheckBox cbSPC_no;
        private System.Windows.Forms.CheckBox cbLOT_no;
    }
}

