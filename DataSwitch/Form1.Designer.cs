namespace DataSwitch
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
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.point = new System.Windows.Forms.RadioButton();
            this.polyline = new System.Windows.Forms.RadioButton();
            this.polygon = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tbxPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOutput = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(21, 362);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // point
            // 
            this.point.AutoSize = true;
            this.point.Location = new System.Drawing.Point(8, 6);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(37, 18);
            this.point.TabIndex = 2;
            this.point.TabStop = true;
            this.point.Text = "点";
            this.point.UseVisualStyleBackColor = true;
            this.point.CheckedChanged += new System.EventHandler(this.point_CheckedChanged);
            // 
            // polyline
            // 
            this.polyline.AutoSize = true;
            this.polyline.Location = new System.Drawing.Point(8, 30);
            this.polyline.Name = "polyline";
            this.polyline.Size = new System.Drawing.Size(37, 18);
            this.polyline.TabIndex = 3;
            this.polyline.TabStop = true;
            this.polyline.Text = "线";
            this.polyline.UseVisualStyleBackColor = true;
            this.polyline.CheckedChanged += new System.EventHandler(this.polyline_CheckedChanged);
            // 
            // polygon
            // 
            this.polygon.AutoSize = true;
            this.polygon.Location = new System.Drawing.Point(8, 54);
            this.polygon.Name = "polygon";
            this.polygon.Size = new System.Drawing.Size(37, 18);
            this.polygon.TabIndex = 4;
            this.polygon.TabStop = true;
            this.polygon.Text = "面";
            this.polygon.UseVisualStyleBackColor = true;
            this.polygon.CheckedChanged += new System.EventHandler(this.polygon_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(8, 78);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(49, 18);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "注记";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(85, 9);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(305, 106);
            this.checkedListBox1.TabIndex = 6;
            // 
            // tbxPath
            // 
            this.tbxPath.Location = new System.Drawing.Point(85, 137);
            this.tbxPath.Name = "tbxPath";
            this.tbxPath.Size = new System.Drawing.Size(257, 22);
            this.tbxPath.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "输出路径：";
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(315, 176);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 10;
            this.btnOutput.Text = "确定";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.polygon);
            this.panel1.Controls.Add(this.point);
            this.panel1.Controls.Add(this.polyline);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 100);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 211);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxPath);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.axLicenseControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.RadioButton point;
        private System.Windows.Forms.RadioButton polyline;
        private System.Windows.Forms.RadioButton polygon;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox tbxPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Panel panel1;
    }
}

