using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FS.Core;
using FS.Interfaces;
using FS.Interfaces.Models;

namespace FS
{
    public partial class FileSearcherForm : Form
    {
        private IFileSearcher _fileSearcher;
        private Timer _timer;
        

        public FileSearcherForm()
        {
            InitializeComponent();
            prbSearchingProgress.Minimum = 0;
            prbSearchingProgress.Maximum = 100;
            prbSearchingProgress.Visible = false;
            btnStop.Enabled = false;
            lblResult.Text = string.Empty;
            SetContextMenu();
            _fileSearcher = new FileSearcher();
            _timer = new Timer();
            _timer.Interval = 500;
            _timer.Tick += _timer_Tick;
        }

        void SetContextMenu()
        {
            var contextMenu = new ContextMenu();
            var showInFolderMenuItem = new MenuItem("Show in folder \tDbl Click", ShowInFolder_clicked);
            var copyPathMenuItem = new MenuItem("Copy path", CopyPath_clicked,Shortcut.CtrlC);
            contextMenu.MenuItems.Add(showInFolderMenuItem);
            contextMenu.MenuItems.Add(copyPathMenuItem);
            lblResult.ContextMenu = contextMenu;
        }
                      

        private async void btnSearch_Click(object sender, EventArgs e)
        {                     
            var directory = txbDirectory.Text.Trim();
            var searchString = txbSearchString.Text;
            if (string.IsNullOrEmpty(directory))
            {
                MessageBox.Show("Please, specify directory");
                return;
            }
            if (string.IsNullOrEmpty(searchString))
            {
                MessageBox.Show("Please, specify search string");
                return;
            }
            lblResult.Text = string.Empty;
            lbxResult.Items.Clear();  
            btnStop.Enabled = true;
            btnSearch.Enabled = false;
            prbSearchingProgress.Value = 0;
            prbSearchingProgress.Visible = true;             
            _timer.Start();
            var fileSearchResult = await Task.Factory.StartNew(() =>_fileSearcher.SearchFiles(new FileSearcherQuery { TargetDirectory = directory, SearchString = searchString }));
            _timer.Stop();
            lblResult.Text = string.Format("Found {0} files \n", fileSearchResult.Files.Count());
            prbSearchingProgress.Visible = false;
            WriteResult(fileSearchResult);
            
            btnSearch.Enabled = true;
            btnStop.Enabled = false;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_fileSearcher != null)
            {
                prbSearchingProgress.Value = _fileSearcher.Progress;
                WriteResult(_fileSearcher.GetTemporaryResult());
            }
        }

        private void WriteResult(SearchFileResult searchFileResult)
        {
            foreach (var file in searchFileResult.Files)
            {
                if (!lbxResult.Items.Contains(file.FullName))
                    lbxResult.Items.Add(file.FullName);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            txbDirectory.Text = dialog.SelectedPath;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_fileSearcher != null)
            {
                _fileSearcher.Stop();
                btnSearch.Enabled = true;
            }
        }

        private void lbxResult_MouseUp(object sender, MouseEventArgs e)
        {
            if (lbxResult.Items.Count == 0 || lbxResult.SelectedItem==null)
                return;
            if (e.Button == MouseButtons.Right)
            {
                lblResult.ContextMenu.Show(lblResult, e.Location);
            }
        }

        private void lbxResult_DoubleClick(object sender, EventArgs e)
        {
            ShowFileInFolder(sender);
        }

        private void ShowInFolder_clicked(object sender, EventArgs e)
        {
            ShowFileInFolder(sender);
        }

        private void CopyPath_clicked(object sender, EventArgs e)
        {
            CopyPathToClipboard();
        }

        private void CopyPathToClipboard()
        {
            var filePath = GetSelectedFilePath(lbxResult);
            if (string.IsNullOrEmpty(filePath))
                return;
            Clipboard.SetText(filePath);
        }

        private void ShowFileInFolder(object sender)
        {
            var filePath = GetSelectedFilePath(lbxResult);
            if(string.IsNullOrEmpty(filePath))
                return;
            if (!File.Exists(filePath))
                return;
            var argument = @"/select, " + filePath;
            Process.Start("explorer.exe", argument);        
        }

        private string GetSelectedFilePath(ListBox listBox)
        {            
            if (listBox == null || listBox.Items.Count == 0)
                return null;
            return listBox.SelectedItem as string;
        }

        private void lbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 3)
            {
                CopyPathToClipboard();
            }
        }


        
    }
}
