namespace BarcodeLibTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.barcode = new System.Windows.Forms.PictureBox();
            this.txtEncoded = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslEncodedType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Print = new System.Windows.Forms.Button();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkGenerateLabel = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.btnForeColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.cbEncodeType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barcode
            // 
            this.barcode.BackColor = System.Drawing.Color.Transparent;
            this.barcode.Location = new System.Drawing.Point(12, 18);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(417, 150);
            this.barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.barcode.TabIndex = 13;
            this.barcode.TabStop = false;
            // 
            // txtEncoded
            // 
            this.txtEncoded.Location = new System.Drawing.Point(16, 143);
            this.txtEncoded.Multiline = true;
            this.txtEncoded.Name = "txtEncoded";
            this.txtEncoded.ReadOnly = true;
            this.txtEncoded.Size = new System.Drawing.Size(187, 89);
            this.txtEncoded.TabIndex = 14;
            this.txtEncoded.TabStop = false;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(15, 38);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(188, 21);
            this.txtData.TabIndex = 1;
            this.txtData.Text = "LGWEF3A55AB044928";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "Value to Encode";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslEncodedType,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(674, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 30;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslEncodedType
            // 
            this.tsslEncodedType.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslEncodedType.Name = "tsslEncodedType";
            this.tsslEncodedType.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(655, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Written by: Brad Barnhill";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "Encoded Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Print);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkGenerateLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBackColor);
            this.groupBox1.Controls.Add(this.btnForeColor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnEncode);
            this.groupBox1.Controls.Add(this.cbEncodeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEncoded);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 344);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(176, 100);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(53, 23);
            this.Print.TabIndex = 45;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(114, 300);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(91, 21);
            this.txtHeight.TabIndex = 44;
            this.txtHeight.Text = "150";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(16, 300);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(90, 21);
            this.txtWidth.TabIndex = 43;
            this.txtWidth.Text = "300";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 42;
            this.label6.Text = "Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 41;
            this.label7.Text = "Width";
            // 
            // chkGenerateLabel
            // 
            this.chkGenerateLabel.AutoSize = true;
            this.chkGenerateLabel.Location = new System.Drawing.Point(115, 20);
            this.chkGenerateLabel.Name = "chkGenerateLabel";
            this.chkGenerateLabel.Size = new System.Drawing.Size(108, 16);
            this.chkGenerateLabel.TabIndex = 40;
            this.chkGenerateLabel.Text = "Generate label";
            this.chkGenerateLabel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "Background Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "Foreground Color";
            // 
            // btnBackColor
            // 
            this.btnBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackColor.Location = new System.Drawing.Point(114, 256);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(91, 21);
            this.btnBackColor.TabIndex = 37;
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // btnForeColor
            // 
            this.btnForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForeColor.Location = new System.Drawing.Point(17, 256);
            this.btnForeColor.Name = "btnForeColor";
            this.btnForeColor.Size = new System.Drawing.Size(91, 21);
            this.btnForeColor.TabIndex = 36;
            this.btnForeColor.UseVisualStyleBackColor = true;
            this.btnForeColor.Click += new System.EventHandler(this.btnForeColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 35;
            this.label3.Text = "Encoding";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(96, 101);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save As";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(15, 101);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 21);
            this.btnEncode.TabIndex = 3;
            this.btnEncode.Text = "&Encode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // cbEncodeType
            // 
            this.cbEncodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncodeType.FormattingEnabled = true;
            this.cbEncodeType.ItemHeight = 12;
            this.cbEncodeType.Items.AddRange(new object[] {
            "UPC-A",
            "UPC-E",
            "UPC 2 Digit Ext.",
            "UPC 5 Digit Ext.",
            "EAN-13",
            "JAN-13",
            "EAN-8",
            "ITF-14",
            "Interleaved 2 of 5",
            "Standard 2 of 5",
            "Codabar",
            "PostNet",
            "Bookland/ISBN",
            "Code 11",
            "Code 39",
            "Code 39 Extended",
            "Code 93",
            "Code 128",
            "Code 128-A",
            "Code 128-B",
            "Code 128-C",
            "LOGMARS",
            "MSI"});
            this.cbEncodeType.Location = new System.Drawing.Point(16, 76);
            this.cbEncodeType.Name = "cbEncodeType";
            this.cbEncodeType.Size = new System.Drawing.Size(121, 20);
            this.cbEncodeType.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.barcode);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 344);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode Image";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(674, 344);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 37;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 366);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Encoder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox barcode;
        private System.Windows.Forms.TextBox txtEncoded;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslEncodedType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbEncodeType;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnForeColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkGenerateLabel;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button Print;
    }
}

