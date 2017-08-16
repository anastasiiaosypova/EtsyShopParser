namespace EtsyParser
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
            this.btnParse = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.btnDownloadImg = new System.Windows.Forms.Button();
            this.btnExportXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(256, 29);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(105, 23);
            this.btnParse.TabIndex = 0;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 95);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(435, 225);
            this.textBox1.TabIndex = 1;
            // 
            // txtInput1
            // 
            this.txtInput1.Location = new System.Drawing.Point(33, 31);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(217, 20);
            this.txtInput1.TabIndex = 2;
            // 
            // btnDownloadImg
            // 
            this.btnDownloadImg.Enabled = false;
            this.btnDownloadImg.Location = new System.Drawing.Point(256, 58);
            this.btnDownloadImg.Name = "btnDownloadImg";
            this.btnDownloadImg.Size = new System.Drawing.Size(101, 23);
            this.btnDownloadImg.TabIndex = 4;
            this.btnDownloadImg.Text = "Download images";
            this.btnDownloadImg.UseVisualStyleBackColor = true;
            this.btnDownloadImg.Click += new System.EventHandler(this.btnDownloadImg_Click);
            // 
            // btnExportXML
            // 
            this.btnExportXML.Enabled = false;
            this.btnExportXML.Location = new System.Drawing.Point(367, 29);
            this.btnExportXML.Name = "btnExportXML";
            this.btnExportXML.Size = new System.Drawing.Size(101, 23);
            this.btnExportXML.TabIndex = 5;
            this.btnExportXML.Text = "Export XML";
            this.btnExportXML.UseVisualStyleBackColor = true;
            this.btnExportXML.Click += new System.EventHandler(this.btnExportXML_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 342);
            this.Controls.Add(this.btnExportXML);
            this.Controls.Add(this.btnDownloadImg);
            this.Controls.Add(this.txtInput1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnParse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.Button btnDownloadImg;
        private System.Windows.Forms.Button btnExportXML;
    }
}

