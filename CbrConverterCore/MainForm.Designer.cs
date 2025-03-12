namespace CbrConverter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new System.Windows.Forms.GroupBox();
            chk_SourceFolder = new System.Windows.Forms.CheckBox();
            tbox_OuputFolder = new System.Windows.Forms.TextBox();
            lbl_about = new System.Windows.Forms.Label();
            tbox_SourceFile = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btn_StartStop = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            chk_JoinImages = new System.Windows.Forms.CheckBox();
            chk_NbPages = new System.Windows.Forms.CheckBox();
            chk_pdf2cbr = new System.Windows.Forms.CheckBox();
            chk_cbr2pdf = new System.Windows.Forms.CheckBox();
            chk_ReduceSize = new System.Windows.Forms.CheckBox();
            pbar_TotalProgress = new System.Windows.Forms.ProgressBar();
            label4 = new System.Windows.Forms.Label();
            lbl_ProcessingFile = new System.Windows.Forms.Label();
            pbar_ActualFile = new System.Windows.Forms.ProgressBar();
            label2 = new System.Windows.Forms.Label();
            btn_showlog = new System.Windows.Forms.Button();
            listViewLog = new System.Windows.Forms.ListView();
            columnHeaderNb = new System.Windows.Forms.ColumnHeader();
            columnHeaderInfo = new System.Windows.Forms.ColumnHeader();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chk_SourceFolder);
            groupBox1.Controls.Add(tbox_OuputFolder);
            groupBox1.Controls.Add(lbl_about);
            groupBox1.Controls.Add(tbox_SourceFile);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(17, 18);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox1.Size = new System.Drawing.Size(811, 192);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // chk_SourceFolder
            // 
            chk_SourceFolder.AutoSize = true;
            chk_SourceFolder.Checked = true;
            chk_SourceFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_SourceFolder.Location = new System.Drawing.Point(13, 106);
            chk_SourceFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            chk_SourceFolder.Name = "chk_SourceFolder";
            chk_SourceFolder.Size = new System.Drawing.Size(211, 29);
            chk_SourceFolder.TabIndex = 7;
            chk_SourceFolder.Text = "Copy to source folder";
            chk_SourceFolder.UseVisualStyleBackColor = true;
            chk_SourceFolder.CheckedChanged += chk_SourceFolder_CheckedChanged;
            // 
            // tbox_OuputFolder
            // 
            tbox_OuputFolder.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            tbox_OuputFolder.Enabled = false;
            tbox_OuputFolder.Location = new System.Drawing.Point(9, 142);
            tbox_OuputFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbox_OuputFolder.Name = "tbox_OuputFolder";
            tbox_OuputFolder.ReadOnly = true;
            tbox_OuputFolder.Size = new System.Drawing.Size(788, 31);
            tbox_OuputFolder.TabIndex = 6;
            tbox_OuputFolder.Text = "Click here to select an ouput folder";
            tbox_OuputFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            tbox_OuputFolder.Click += tbox_OuputFolder_Click;
            // 
            // lbl_about
            // 
            lbl_about.AutoSize = true;
            lbl_about.Cursor = System.Windows.Forms.Cursors.Hand;
            lbl_about.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            lbl_about.ForeColor = System.Drawing.SystemColors.HotTrack;
            lbl_about.Location = new System.Drawing.Point(743, 31);
            lbl_about.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_about.Name = "lbl_about";
            lbl_about.Size = new System.Drawing.Size(52, 20);
            lbl_about.TabIndex = 5;
            lbl_about.Text = "About";
            lbl_about.Click += lbl_about_Click;
            // 
            // tbox_SourceFile
            // 
            tbox_SourceFile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            tbox_SourceFile.Location = new System.Drawing.Point(10, 61);
            tbox_SourceFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            tbox_SourceFile.Name = "tbox_SourceFile";
            tbox_SourceFile.ReadOnly = true;
            tbox_SourceFile.Size = new System.Drawing.Size(788, 31);
            tbox_SourceFile.TabIndex = 5;
            tbox_SourceFile.Text = "Click or Drag file here to select a file or folder";
            tbox_SourceFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            tbox_SourceFile.Click += tbox_SourceFile_Click;
            tbox_SourceFile.TextChanged += tbox_SourceFile_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 31);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(420, 25);
            label1.TabIndex = 1;
            label1.Text = "Select File or Folder (files will be process recursively)";
            // 
            // btn_StartStop
            // 
            btn_StartStop.Location = new System.Drawing.Point(9, 32);
            btn_StartStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btn_StartStop.Name = "btn_StartStop";
            btn_StartStop.Size = new System.Drawing.Size(111, 221);
            btn_StartStop.TabIndex = 2;
            btn_StartStop.Text = "START";
            btn_StartStop.UseVisualStyleBackColor = true;
            btn_StartStop.Click += btn_StartStop_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chk_JoinImages);
            groupBox2.Controls.Add(chk_NbPages);
            groupBox2.Controls.Add(chk_pdf2cbr);
            groupBox2.Controls.Add(chk_cbr2pdf);
            groupBox2.Controls.Add(chk_ReduceSize);
            groupBox2.Controls.Add(pbar_TotalProgress);
            groupBox2.Controls.Add(btn_StartStop);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(lbl_ProcessingFile);
            groupBox2.Controls.Add(pbar_ActualFile);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new System.Drawing.Point(17, 221);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            groupBox2.Size = new System.Drawing.Size(810, 268);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // chk_JoinImages
            // 
            chk_JoinImages.AutoSize = true;
            chk_JoinImages.Checked = true;
            chk_JoinImages.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_JoinImages.Location = new System.Drawing.Point(338, 78);
            chk_JoinImages.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            chk_JoinImages.Name = "chk_JoinImages";
            chk_JoinImages.Size = new System.Drawing.Size(318, 29);
            chk_JoinImages.TabIndex = 9;
            chk_JoinImages.Text = "Merge images from same Pdf page";
            chk_JoinImages.UseVisualStyleBackColor = true;
            // 
            // chk_NbPages
            // 
            chk_NbPages.AutoSize = true;
            chk_NbPages.Checked = true;
            chk_NbPages.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_NbPages.Location = new System.Drawing.Point(709, 32);
            chk_NbPages.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            chk_NbPages.Name = "chk_NbPages";
            chk_NbPages.Size = new System.Drawing.Size(87, 29);
            chk_NbPages.TabIndex = 8;
            chk_NbPages.Text = "P/Img";
            chk_NbPages.UseVisualStyleBackColor = true;
            chk_NbPages.Visible = false;
            // 
            // chk_pdf2cbr
            // 
            chk_pdf2cbr.AutoSize = true;
            chk_pdf2cbr.Checked = true;
            chk_pdf2cbr.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_pdf2cbr.Location = new System.Drawing.Point(130, 72);
            chk_pdf2cbr.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            chk_pdf2cbr.Name = "chk_pdf2cbr";
            chk_pdf2cbr.Size = new System.Drawing.Size(127, 29);
            chk_pdf2cbr.TabIndex = 7;
            chk_pdf2cbr.Text = "PDF to Cbz";
            chk_pdf2cbr.UseVisualStyleBackColor = true;
            // 
            // chk_cbr2pdf
            // 
            chk_cbr2pdf.AutoSize = true;
            chk_cbr2pdf.Checked = true;
            chk_cbr2pdf.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_cbr2pdf.Location = new System.Drawing.Point(130, 32);
            chk_cbr2pdf.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            chk_cbr2pdf.Name = "chk_cbr2pdf";
            chk_cbr2pdf.Size = new System.Drawing.Size(162, 29);
            chk_cbr2pdf.TabIndex = 6;
            chk_cbr2pdf.Text = "Cbr/Cbz to PDF";
            chk_cbr2pdf.UseVisualStyleBackColor = true;
            // 
            // chk_ReduceSize
            // 
            chk_ReduceSize.AutoSize = true;
            chk_ReduceSize.Location = new System.Drawing.Point(338, 32);
            chk_ReduceSize.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            chk_ReduceSize.Name = "chk_ReduceSize";
            chk_ReduceSize.Size = new System.Drawing.Size(322, 29);
            chk_ReduceSize.TabIndex = 5;
            chk_ReduceSize.Text = "Compress images to reduce file size";
            chk_ReduceSize.UseVisualStyleBackColor = true;
            // 
            // pbar_TotalProgress
            // 
            pbar_TotalProgress.Location = new System.Drawing.Point(130, 225);
            pbar_TotalProgress.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pbar_TotalProgress.Name = "pbar_TotalProgress";
            pbar_TotalProgress.Size = new System.Drawing.Size(670, 31);
            pbar_TotalProgress.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(124, 194);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(53, 25);
            label4.TabIndex = 3;
            label4.Text = "Total:";
            // 
            // lbl_ProcessingFile
            // 
            lbl_ProcessingFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_ProcessingFile.Location = new System.Drawing.Point(238, 129);
            lbl_ProcessingFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ProcessingFile.Name = "lbl_ProcessingFile";
            lbl_ProcessingFile.Size = new System.Drawing.Size(562, 25);
            lbl_ProcessingFile.TabIndex = 2;
            // 
            // pbar_ActualFile
            // 
            pbar_ActualFile.Location = new System.Drawing.Point(130, 160);
            pbar_ActualFile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            pbar_ActualFile.Name = "pbar_ActualFile";
            pbar_ActualFile.Size = new System.Drawing.Size(670, 29);
            pbar_ActualFile.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(124, 129);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 25);
            label2.TabIndex = 0;
            label2.Text = "Processing:";
            // 
            // btn_showlog
            // 
            btn_showlog.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            btn_showlog.FlatAppearance.BorderSize = 0;
            btn_showlog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_showlog.Location = new System.Drawing.Point(391, 500);
            btn_showlog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btn_showlog.Name = "btn_showlog";
            btn_showlog.Size = new System.Drawing.Size(64, 54);
            btn_showlog.TabIndex = 6;
            btn_showlog.UseVisualStyleBackColor = true;
            btn_showlog.Click += btn_showlog_Click;
            // 
            // listViewLog
            // 
            listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeaderNb, columnHeaderInfo });
            listViewLog.FullRowSelect = true;
            listViewLog.GridLines = true;
            listViewLog.Location = new System.Drawing.Point(4, 556);
            listViewLog.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            listViewLog.Name = "listViewLog";
            listViewLog.Size = new System.Drawing.Size(835, 615);
            listViewLog.TabIndex = 7;
            listViewLog.UseCompatibleStateImageBehavior = false;
            listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNb
            // 
            columnHeaderNb.Text = "n°";
            columnHeaderNb.Width = 33;
            // 
            // columnHeaderInfo
            // 
            columnHeaderInfo.Text = "Informations";
            columnHeaderInfo.Width = 460;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(849, 552);
            Controls.Add(listViewLog);
            Controls.Add(btn_showlog);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CBR/Z to PDF Converter";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbox_SourceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_StartStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar pbar_TotalProgress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_ProcessingFile;
        private System.Windows.Forms.ProgressBar pbar_ActualFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_ReduceSize;
        private System.Windows.Forms.Label lbl_about;
        private System.Windows.Forms.CheckBox chk_NbPages;
        private System.Windows.Forms.CheckBox chk_pdf2cbr;
        private System.Windows.Forms.CheckBox chk_cbr2pdf;
        private System.Windows.Forms.CheckBox chk_JoinImages;
        private System.Windows.Forms.Button btn_showlog;
        private System.Windows.Forms.CheckBox chk_SourceFolder;
        private System.Windows.Forms.TextBox tbox_OuputFolder;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeaderNb;
        private System.Windows.Forms.ColumnHeader columnHeaderInfo;
    }
}

