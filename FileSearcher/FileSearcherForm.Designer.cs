namespace FS
{
    partial class FileSearcherForm
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
            this.lblDirectory = new System.Windows.Forms.Label();
            this.txbDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSearchString = new System.Windows.Forms.Label();
            this.txbSearchString = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.prbSearchingProgress = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.lbxResult = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(12, 9);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(168, 13);
            this.lblDirectory.TabIndex = 0;
            this.lblDirectory.Text = "Specify directory for file searching:";
            // 
            // txbDirectory
            // 
            this.txbDirectory.Location = new System.Drawing.Point(15, 25);
            this.txbDirectory.Name = "txbDirectory";
            this.txbDirectory.Size = new System.Drawing.Size(522, 20);
            this.txbDirectory.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(543, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblSearchString
            // 
            this.lblSearchString.AutoSize = true;
            this.lblSearchString.Location = new System.Drawing.Point(12, 64);
            this.lblSearchString.Name = "lblSearchString";
            this.lblSearchString.Size = new System.Drawing.Size(95, 13);
            this.lblSearchString.TabIndex = 0;
            this.lblSearchString.Text = "Enter search string";
            // 
            // txbSearchString
            // 
            this.txbSearchString.Location = new System.Drawing.Point(15, 80);
            this.txbSearchString.Name = "txbSearchString";
            this.txbSearchString.Size = new System.Drawing.Size(522, 20);
            this.txbSearchString.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(105, 115);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(29, 182);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(31, 13);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Files:";
            // 
            // prbSearchingProgress
            // 
            this.prbSearchingProgress.Location = new System.Drawing.Point(32, 154);
            this.prbSearchingProgress.Name = "prbSearchingProgress";
            this.prbSearchingProgress.Size = new System.Drawing.Size(506, 23);
            this.prbSearchingProgress.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(343, 115);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lbxResult
            // 
            this.lbxResult.FormattingEnabled = true;
            this.lbxResult.Location = new System.Drawing.Point(32, 199);
            this.lbxResult.Name = "lbxResult";
            this.lbxResult.Size = new System.Drawing.Size(506, 238);
            this.lbxResult.TabIndex = 6;
            this.lbxResult.DoubleClick += new System.EventHandler(this.lbxResult_DoubleClick);
            this.lbxResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbx_KeyPress);
            this.lbxResult.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbxResult_MouseUp);
            // 
            // FileSearcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 448);
            this.Controls.Add(this.lbxResult);
            this.Controls.Add(this.prbSearchingProgress);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txbSearchString);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblSearchString);
            this.Controls.Add(this.txbDirectory);
            this.Controls.Add(this.lblDirectory);
            this.Name = "FileSearcherForm";
            this.Text = "File Searcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.TextBox txbDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblSearchString;
        private System.Windows.Forms.TextBox txbSearchString;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ProgressBar prbSearchingProgress;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox lbxResult;
    }
}

