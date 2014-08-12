namespace ESPA
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUnion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUnionID = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtScenario = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblerr = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbThana = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDist = new System.Windows.Forms.ComboBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.lblEquation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(795, 500);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Folder Select";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 437);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            // 
            // cmbUnion
            // 
            this.cmbUnion.FormattingEnabled = true;
            this.cmbUnion.Location = new System.Drawing.Point(75, 90);
            this.cmbUnion.Name = "cmbUnion";
            this.cmbUnion.Size = new System.Drawing.Size(121, 21);
            this.cmbUnion.TabIndex = 3;
            this.cmbUnion.SelectedIndexChanged += new System.EventHandler(this.cmbUnion_changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Union";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "UnionID";
            // 
            // cmbUnionID
            // 
            this.cmbUnionID.FormattingEnabled = true;
            this.cmbUnionID.Location = new System.Drawing.Point(75, 119);
            this.cmbUnionID.Name = "cmbUnionID";
            this.cmbUnionID.Size = new System.Drawing.Size(121, 21);
            this.cmbUnionID.TabIndex = 6;
            this.cmbUnionID.SelectedIndexChanged += new System.EventHandler(this.cmbUnionID_changed);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(696, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Generate graph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // chart1
            // 
            this.chart1.Location = new System.Drawing.Point(268, 12);
            this.chart1.Name = "chart1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(614, 469);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_mousemove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Year";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(75, 146);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 21);
            this.cmbYear.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Scenario";
            // 
            // txtScenario
            // 
            this.txtScenario.Location = new System.Drawing.Point(75, 173);
            this.txtScenario.Name = "txtScenario";
            this.txtScenario.Size = new System.Drawing.Size(121, 20);
            this.txtScenario.TabIndex = 12;
            // 
            // lblerr
            // 
            this.lblerr.AutoSize = true;
            this.lblerr.Location = new System.Drawing.Point(13, 304);
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(0, 13);
            this.lblerr.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Thana";
            // 
            // cmbThana
            // 
            this.cmbThana.FormattingEnabled = true;
            this.cmbThana.Location = new System.Drawing.Point(75, 63);
            this.cmbThana.Name = "cmbThana";
            this.cmbThana.Size = new System.Drawing.Size(121, 21);
            this.cmbThana.TabIndex = 14;
            this.cmbThana.SelectionChangeCommitted += new System.EventHandler(this.cmbThanaChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "District";
            // 
            // cmbDist
            // 
            this.cmbDist.FormattingEnabled = true;
            this.cmbDist.Location = new System.Drawing.Point(75, 36);
            this.cmbDist.Name = "cmbDist";
            this.cmbDist.Size = new System.Drawing.Size(121, 21);
            this.cmbDist.TabIndex = 16;
            this.cmbDist.SelectionChangeCommitted += new System.EventHandler(this.cmbDistChanged);
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(615, 500);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(75, 23);
            this.cmdExport.TabIndex = 18;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_click);
            // 
            // lblEquation
            // 
            this.lblEquation.AutoSize = true;
            this.lblEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquation.Location = new System.Drawing.Point(11, 503);
            this.lblEquation.Name = "lblEquation";
            this.lblEquation.Size = new System.Drawing.Size(0, 20);
            this.lblEquation.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(891, 535);
            this.Controls.Add(this.lblEquation);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDist);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbThana);
            this.Controls.Add(this.lblerr);
            this.Controls.Add(this.txtScenario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbUnionID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUnion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "ESPA WP5";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUnion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUnionID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtScenario;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblerr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbThana;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDist;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Label lblEquation;
    }
}

