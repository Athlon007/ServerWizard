namespace ServerWizard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStatus = new Label();
            lblStatusText = new Label();
            btnStart = new Button();
            btnOff = new Button();
            prbLoading = new ProgressBar();
            groupBox1 = new GroupBox();
            lstServices = new ListView();
            name = new ColumnHeader();
            active = new ColumnHeader();
            groupBox2 = new GroupBox();
            prbCPU = new ProgressBar();
            lblSwap = new Label();
            lblRam = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblCPU = new Label();
            panel1 = new Panel();
            prbRam = new ProgressBar();
            prbSwap = new ProgressBar();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(15, 19);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(55, 21);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // lblStatusText
            // 
            lblStatusText.AutoSize = true;
            lblStatusText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatusText.Location = new Point(76, 19);
            lblStatusText.Name = "lblStatusText";
            lblStatusText.Size = new Size(151, 21);
            lblStatusText.TabIndex = 1;
            lblStatusText.Text = "NOT RESPONDING";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(15, 62);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Power On";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnOff
            // 
            btnOff.Location = new Point(152, 62);
            btnOff.Name = "btnOff";
            btnOff.Size = new Size(75, 23);
            btnOff.TabIndex = 3;
            btnOff.Text = "Power Off";
            btnOff.UseVisualStyleBackColor = true;
            btnOff.Click += btnOff_Click;
            // 
            // prbLoading
            // 
            prbLoading.Location = new Point(15, 91);
            prbLoading.Name = "prbLoading";
            prbLoading.Size = new Size(212, 23);
            prbLoading.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(prbLoading);
            groupBox1.Controls.Add(lblStatusText);
            groupBox1.Controls.Add(btnOff);
            groupBox1.Controls.Add(btnStart);
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(239, 143);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Power";
            // 
            // lstServices
            // 
            lstServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstServices.Columns.AddRange(new ColumnHeader[] { name, active });
            lstServices.Font = new Font("Segoe UI", 12F);
            lstServices.FullRowSelect = true;
            lstServices.Location = new Point(0, 149);
            lstServices.Name = "lstServices";
            lstServices.Size = new Size(800, 301);
            lstServices.TabIndex = 6;
            lstServices.UseCompatibleStateImageBehavior = false;
            lstServices.View = View.Details;
            lstServices.DoubleClick += lstServices_DoubleClick;
            // 
            // name
            // 
            name.Text = "Name";
            name.Width = 240;
            // 
            // active
            // 
            active.Text = "Active";
            active.Width = 120;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(prbSwap);
            groupBox2.Controls.Add(prbRam);
            groupBox2.Controls.Add(prbCPU);
            groupBox2.Controls.Add(lblSwap);
            groupBox2.Controls.Add(lblRam);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(lblCPU);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(239, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(561, 143);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Monitor";
            // 
            // prbCPU
            // 
            prbCPU.Location = new Point(274, 22);
            prbCPU.Name = "prbCPU";
            prbCPU.Size = new Size(260, 23);
            prbCPU.TabIndex = 6;
            // 
            // lblSwap
            // 
            lblSwap.AutoSize = true;
            lblSwap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSwap.Location = new Point(64, 107);
            lblSwap.Name = "lblSwap";
            lblSwap.Size = new Size(180, 21);
            lblSwap.TabIndex = 5;
            lblSwap.Text = "0000,00/000000,00 MB";
            // 
            // lblRam
            // 
            lblRam.AutoSize = true;
            lblRam.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRam.Location = new Point(64, 64);
            lblRam.Name = "lblRam";
            lblRam.Size = new Size(180, 21);
            lblRam.TabIndex = 4;
            lblRam.Text = "0000,00/000000,00 MB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(15, 107);
            label3.Name = "label3";
            label3.Size = new Size(51, 21);
            label3.TabIndex = 3;
            label3.Text = "Swap:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(15, 61);
            label2.Name = "label2";
            label2.Size = new Size(47, 21);
            label2.TabIndex = 2;
            label2.Text = "RAM:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(15, 19);
            label1.Name = "label1";
            label1.Size = new Size(43, 21);
            label1.TabIndex = 0;
            label1.Text = "CPU:";
            // 
            // lblCPU
            // 
            lblCPU.AutoSize = true;
            lblCPU.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCPU.Location = new Point(64, 19);
            lblCPU.Name = "lblCPU";
            lblCPU.Size = new Size(33, 21);
            lblCPU.TabIndex = 1;
            lblCPU.Text = "0%";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 143);
            panel1.TabIndex = 8;
            // 
            // prbRam
            // 
            prbRam.Location = new Point(274, 60);
            prbRam.Name = "prbRam";
            prbRam.Size = new Size(260, 25);
            prbRam.TabIndex = 7;
            // 
            // prbSwap
            // 
            prbSwap.Location = new Point(274, 107);
            prbSwap.Name = "prbSwap";
            prbSwap.Size = new Size(260, 25);
            prbSwap.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(lstServices);
            Name = "Form1";
            Text = "Server Wizard";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblStatus;
        private Label lblStatusText;
        private Button btnStart;
        private Button btnOff;
        private ProgressBar prbLoading;
        private GroupBox groupBox1;
        private ListView lstServices;
        private ColumnHeader name;
        private ColumnHeader active;
        private GroupBox groupBox2;
        private Label label1;
        private Label lblCPU;
        private Panel panel1;
        private Label lblSwap;
        private Label lblRam;
        private Label label3;
        private Label label2;
        private ProgressBar prbCPU;
        private ProgressBar prbSwap;
        private ProgressBar prbRam;
    }
}
