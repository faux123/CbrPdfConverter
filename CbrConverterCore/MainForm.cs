﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace CbzConverterCore
{
    public partial class MainForm : Form
    {
        bool _fileSelected = false;
        bool _outputFolderSelected = false;

        public MainForm()
        {
            InitializeComponent();

            // Add Context Menu to ListView
            listViewLog.ContextMenuStrip = new ContextMenuStrip();
            listViewLog.ContextMenuStrip.Items.Add("Copy", null, CopyLogItem_Click); // Add the "Copy" option
            listViewLog.MouseClick += ListViewLog_MouseClick; // Attach MouseClick event

            // Set up ListView columns (important for horizontal scrolling)
            listViewLog.View = View.Details; // Ensure it's in Details view
            listViewLog.Columns.Add("ID", 30); // Example ID column
            listViewLog.Columns.Add("Log Message", 500); // Wider Log Message column
            listViewLog.Columns.Add("Extra Info", 200); // Another column
            listViewLog.Scrollable = true;

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(this.btn_showlog, "Show/Hide Logs");

            // Enable Drag and Drop
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(MainForm_DragEnter);
            this.DragDrop += new DragEventHandler(MainForm_DragDrop);
        }

        // New method to handle the MouseClick event on the ListView
        private void ListViewLog_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Check if it's a right-click
            {
                // Get the item that was right-clicked
                ListViewHitTestInfo hitTestInfo = listViewLog.HitTest(e.Location);
                if (hitTestInfo.Item != null)
                {
                    listViewLog.SelectedItems.Clear(); // Clear previous selections
                    hitTestInfo.Item.Selected = true;   // Select the item that was right-clicked
                }
            }
        }

        // New method to handle the "Copy" click event
        private void CopyLogItem_Click(object sender, EventArgs e)
        {
            if (listViewLog.SelectedItems.Count > 0)
            {
                // Copy the text of the first subitem (the log message) to the clipboard
                Clipboard.SetText(listViewLog.SelectedItems[0].SubItems[1].Text); //Subitem[1] is the log message
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                // Assuming you want to process only the first file/folder dropped
                string droppedPath = files[0];
                ProcessDroppedPath(droppedPath);
            }
        }

        private void ProcessDroppedPath(string path)
        {
            DataAccess.Instance.g_WorkingDir = path;
            tbox_SourceFile.Text = path;

            //check if file or folder
            if (File.Exists(DataAccess.Instance.g_WorkingDir)) //is a file
            {
                //check the extension
                var ext = Path.GetExtension(path).ToLower();
                if (ext == ".pdf")
                {
                    chk_cbr2pdf.Checked = false;
                    chk_cbr2pdf.Enabled = false;
                    chk_pdf2cbr.Checked = true;
                    chk_pdf2cbr.Enabled = true;
                    chk_JoinImages.Enabled = true;

                }
                else if (ext == ".cbr" || ext == ".cbz")
                {
                    chk_cbr2pdf.Checked = true;
                    chk_cbr2pdf.Enabled = true;
                    chk_pdf2cbr.Checked = false;
                    chk_pdf2cbr.Enabled = false;
                    chk_JoinImages.Enabled = false;
                }
            }
            else //is a folder
            {
                chk_cbr2pdf.Checked = true;
                chk_cbr2pdf.Enabled = true;
                chk_pdf2cbr.Checked = true;
                chk_pdf2cbr.Enabled = true;
            }

            _fileSelected = true;

            if (this.chk_SourceFolder.Checked)
            {
                _outputFolderSelected = true;
                DataAccess.Instance.g_Output_dir = Path.GetDirectoryName(path);
                this.tbox_OuputFolder.Text = this.tbox_SourceFile.Text;
            }
        }

        private void btn_StartStop_Click(object sender, EventArgs e)
        {

            if (DataAccess.Instance.g_Processing)
            {
                DataAccess.Instance.g_Processing = false;
                btn_StartStop.Text = "START";
                lbl_ProcessingFile.Text = string.Empty;
            }
            else
            {
                if (((chk_cbr2pdf.Checked) || (chk_pdf2cbr.Checked)) && (_fileSelected))
                {
                    btn_StartStop.Text = "STOP";
                    DataAccess.Instance.g_ReduceSize = chk_ReduceSize.Checked;
                    DataAccess.Instance.g_Processing = true;
                    Extract ex = new Extract();
                    this.Subscribe(ex);
                    ex.BeginExtraction(chk_cbr2pdf.Checked, chk_pdf2cbr.Checked, chk_ReduceSize.Checked, chk_NbPages.Checked, chk_JoinImages.Checked, chk_NbPages.Checked);
                }
            }
        }

        public void Subscribe(Extract m)
        {
            m.evnt_UpdateCurBar += new Extract.UpdateCurrentBar(UpdateCurrBar);
            m.evnt_UpdatTotBar += new Extract.UpdateTotalBar(UpdateTotaBar);
            m.evnt_UpdateFileName += new Extract.UpdateFileName(UpdateFileName);
            m.evnt_ErrorNotify += new Extract.ErrorNotify(ErrorShowPopup);
            PdfFunctions.evnt_UpdateCurBar += new PdfFunctions.UpdateCurrentBar(UpdateCurrBar);
        }
        private void UpdateCurrBar()
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (DataAccess.Instance.g_curProgress > 100)
                    DataAccess.Instance.g_curProgress = 100;
                pbar_ActualFile.Value = (int)DataAccess.Instance.g_curProgress;
            });
        }

        private void UpdateFileName(Extract m, EventArgs e)
        {

            this.Invoke((MethodInvoker)delegate
            {
                lbl_ProcessingFile.Text = Path.GetFileName(DataAccess.Instance.g_WorkingFile);
                if (lbl_ProcessingFile.Text == string.Empty)//finished
                {
                    btn_StartStop.Text = "START";

                }
            });
        }

        private void UpdateTotaBar(Extract m, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (DataAccess.Instance.g_totProgress > 100)
                    DataAccess.Instance.g_totProgress = 100;
                pbar_TotalProgress.Value = (int)DataAccess.Instance.g_totProgress;
            });
        }

        private void ErrorShowPopup(Extract m, string e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ListViewItem item = new ListViewItem((listViewLog.Items.Count + 1).ToString());
                item.SubItems.Add(e);
                listViewLog.Items.Add(item);
                ShowLog();
            });
        }

        /// <summary>
        /// User clicked on textbox, opendialog to select file or folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbox_SourceFile_Click(object sender, EventArgs e)
        {
            var SelectFolderDlg = new FolderBrowserDialogEx();
            SelectFolderDlg.Description = "Select a file or folder:"; //message
            SelectFolderDlg.ShowNewFolderButton = true;
            SelectFolderDlg.ShowEditBox = false;                     //editbox
            SelectFolderDlg.ShowBothFilesAndFolders = true;          //show files and folders
            SelectFolderDlg.RootFolder = System.Environment.SpecialFolder.MyComputer; //start from computer

            DialogResult result = SelectFolderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                DataAccess.Instance.g_WorkingDir = SelectFolderDlg.SelectedPath;
                tbox_SourceFile.Text = SelectFolderDlg.SelectedPath;

                //check if file or folder
                if (File.Exists(DataAccess.Instance.g_WorkingDir)) //is a file
                {
                    //check the extension
                    var ext = Path.GetExtension(SelectFolderDlg.SelectedPath).ToLower();
                    if (ext == ".pdf")
                    {
                        chk_cbr2pdf.Checked = false;
                        chk_cbr2pdf.Enabled = false;
                        chk_pdf2cbr.Checked = true;
                        chk_pdf2cbr.Enabled = true;
                        chk_JoinImages.Enabled = true;

                    }
                    else if (ext == ".cbr" || ext == ".cbz")
                    {
                        chk_cbr2pdf.Checked = true;
                        chk_cbr2pdf.Enabled = true;
                        chk_pdf2cbr.Checked = false;
                        chk_pdf2cbr.Enabled = false;
                        chk_JoinImages.Enabled = false;
                    }
                }
                else //is a folder
                {
                    chk_cbr2pdf.Checked = true;
                    chk_cbr2pdf.Enabled = true;
                    chk_pdf2cbr.Checked = true;
                    chk_pdf2cbr.Enabled = true;
                }

                _fileSelected = true;

                if (this.chk_SourceFolder.Checked)
                {
                    _outputFolderSelected = true;
                    DataAccess.Instance.g_Output_dir = Path.GetDirectoryName(SelectFolderDlg.SelectedPath);
                    this.tbox_OuputFolder.Text = this.tbox_SourceFile.Text;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbox_SourceFile.SelectionStart = 0;
        }

        private void lbl_about_Click(object sender, EventArgs e)
        {
            AboutorForm aboutform = new AboutorForm();
            aboutform.ShowDialog();
        }
        private int LogTopPosition
        {
            get
            {
                Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
                int titleHeight = screenRectangle.Top - this.Top;
                return this.listViewLog.Top + titleHeight - 1;
            }
        }
        private int LogBottomPosition
        {
            get
            {
                Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
                int titleHeight = screenRectangle.Top - this.Top;
                return this.listViewLog.Bottom + titleHeight + 10;
            }
        }

        private void btn_showlog_Click(object sender, EventArgs e)
        {
            ToggleLog();
        }

        private void ToggleLog()
        {
            if (this.Height >= this.LogBottomPosition)
            {
                HideLog();
            }
            else
            {
                ShowLog();
            }
        }

        private void ShowLog()
        {
            var timerSlide = new System.Windows.Forms.Timer();
            timerSlide.Interval = 3;
            timerSlide.Tick += delegate (object sender, EventArgs e)
            {
                var timer = (System.Windows.Forms.Timer)sender;
                if (this.Height >= this.LogBottomPosition)
                {
                    timer.Enabled = false;
                    this.Height = this.LogBottomPosition;
                    //this.btn_showlog.Image = global::CbzConverterCore.Properties.Resources.arrow_double_up;
                }
                else
                {
                    this.Height = this.Size.Height + 10;
                }

            };
            timerSlide.Start();
        }

        private void HideLog()
        {
            // just a slide effect
            var timerSlide = new System.Windows.Forms.Timer();
            timerSlide.Interval = 3;
            timerSlide.Tick += delegate (object sender, EventArgs e)
            {
                var timer = (System.Windows.Forms.Timer)sender;
                if (this.Height <= this.LogTopPosition)
                {
                    timer.Enabled = false;
                    this.Height = this.LogTopPosition;
                    //this.btn_showlog.Image = global::CbzConverterCore.Properties.Resources.arrow_double_down;
                }
                else
                {
                    this.Height = this.Height - 10;
                }

            };
            timerSlide.Start();
        }

        private void tbox_OuputFolder_Click(object sender, EventArgs e)
        {
            var SelectFolderDlg = new FolderBrowserDialogEx();
            SelectFolderDlg.Description = "Select a folder:"; //message
            SelectFolderDlg.ShowNewFolderButton = true;
            SelectFolderDlg.ShowEditBox = false;                     //editbox
            SelectFolderDlg.ShowBothFilesAndFolders = false;          //show files and folders
            SelectFolderDlg.RootFolder = System.Environment.SpecialFolder.MyComputer; //start from computer

            DialogResult result = SelectFolderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                DataAccess.Instance.g_Output_dir = SelectFolderDlg.SelectedPath;
                tbox_OuputFolder.Text = SelectFolderDlg.SelectedPath;

                _outputFolderSelected = true;

                if (this.chk_SourceFolder.Checked)
                {
                    this.tbox_OuputFolder.Text = this.tbox_SourceFile.Text;
                }
            }
        }

        private void chk_SourceFolder_CheckedChanged(object sender, EventArgs e)
        {
            this.tbox_OuputFolder.Enabled = !this.chk_SourceFolder.Checked;
            if (this.chk_SourceFolder.Checked)
            {
                DataAccess.Instance.g_Output_dir = Path.GetDirectoryName(DataAccess.Instance.g_WorkingDir);
                this.tbox_OuputFolder.Text = DataAccess.Instance.g_Output_dir;
            }
        }

        private void tbox_SourceFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
