namespace WinForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.InitFromList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.initBt = new System.Windows.Forms.Button();
            this.startSortBT = new System.Windows.Forms.Button();
            this.labelSort = new System.Windows.Forms.Label();
            this.sortersListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pushDBButton = new System.Windows.Forms.Button();
            this.addColumnBt = new System.Windows.Forms.Button();
            this.addRowBt = new System.Windows.Forms.Button();
            this.deleteTableBt = new System.Windows.Forms.Button();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.моваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem2 = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Exit_bt = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // InitFromList
            // 
            this.InitFromList.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.InitFromList, "InitFromList");
            this.InitFromList.FormattingEnabled = true;
            this.InitFromList.Items.AddRange(new object[] {
            resources.GetString("InitFromList.Items"),
            resources.GetString("InitFromList.Items1"),
            resources.GetString("InitFromList.Items2"),
            resources.GetString("InitFromList.Items3")});
            this.InitFromList.Name = "InitFromList";
            this.InitFromList.SelectedIndexChanged += new System.EventHandler(this.InitFromList_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // initBt
            // 
            this.initBt.BackColor = System.Drawing.Color.DimGray;
            this.initBt.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.initBt, "initBt");
            this.initBt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.initBt.Name = "initBt";
            this.initBt.UseVisualStyleBackColor = false;
            this.initBt.Click += new System.EventHandler(this.initBt_Click);
            // 
            // startSortBT
            // 
            this.startSortBT.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.startSortBT, "startSortBT");
            this.startSortBT.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.startSortBT.Name = "startSortBT";
            this.startSortBT.UseVisualStyleBackColor = false;
            this.startSortBT.Click += new System.EventHandler(this.startSortBT_Click);
            // 
            // labelSort
            // 
            resources.ApplyResources(this.labelSort, "labelSort");
            this.labelSort.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelSort.Name = "labelSort";
            // 
            // sortersListBox
            // 
            this.sortersListBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.sortersListBox, "sortersListBox");
            this.sortersListBox.FormattingEnabled = true;
            this.sortersListBox.Name = "sortersListBox";
            this.sortersListBox.SelectedIndexChanged += new System.EventHandler(this.sortersListBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // pushDBButton
            // 
            this.pushDBButton.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.pushDBButton, "pushDBButton");
            this.pushDBButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pushDBButton.Name = "pushDBButton";
            this.pushDBButton.UseVisualStyleBackColor = false;
            this.pushDBButton.Click += new System.EventHandler(this.pushDBButton_Click);
            // 
            // addColumnBt
            // 
            this.addColumnBt.BackColor = System.Drawing.Color.DimGray;
            this.addColumnBt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.addColumnBt, "addColumnBt");
            this.addColumnBt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addColumnBt.Name = "addColumnBt";
            this.addColumnBt.UseVisualStyleBackColor = false;
            this.addColumnBt.Click += new System.EventHandler(this.addColumnBt_Click);
            // 
            // addRowBt
            // 
            this.addRowBt.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.addRowBt, "addRowBt");
            this.addRowBt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addRowBt.Name = "addRowBt";
            this.addRowBt.UseVisualStyleBackColor = false;
            this.addRowBt.Click += new System.EventHandler(this.addRowBt_Click);
            // 
            // deleteTableBt
            // 
            this.deleteTableBt.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.deleteTableBt, "deleteTableBt");
            this.deleteTableBt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteTableBt.Name = "deleteTableBt";
            this.deleteTableBt.UseVisualStyleBackColor = false;
            this.deleteTableBt.Click += new System.EventHandler(this.deleteTableBt_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // languageToolStripMenuItem1
            // 
            this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
            resources.ApplyResources(this.languageToolStripMenuItem1, "languageToolStripMenuItem1");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.openToolStripMenuItem1,
            this.toolStripSeparator6,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            resources.ApplyResources(this.fileToolStripMenuItem1, "fileToolStripMenuItem1");
            // 
            // newToolStripMenuItem1
            // 
            resources.ApplyResources(this.newToolStripMenuItem1, "newToolStripMenuItem1");
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            // 
            // openToolStripMenuItem1
            // 
            resources.ApplyResources(this.openToolStripMenuItem1, "openToolStripMenuItem1");
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem1,
            this.optionsToolStripMenuItem1});
            this.toolsToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            resources.ApplyResources(this.toolsToolStripMenuItem1, "toolsToolStripMenuItem1");
            // 
            // customizeToolStripMenuItem1
            // 
            this.customizeToolStripMenuItem1.Name = "customizeToolStripMenuItem1";
            resources.ApplyResources(this.customizeToolStripMenuItem1, "customizeToolStripMenuItem1");
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.моваToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            resources.ApplyResources(this.optionsToolStripMenuItem1, "optionsToolStripMenuItem1");
            // 
            // моваToolStripMenuItem
            // 
            this.моваToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.моваToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.моваToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem2});
            this.моваToolStripMenuItem.Name = "моваToolStripMenuItem";
            resources.ApplyResources(this.моваToolStripMenuItem, "моваToolStripMenuItem");
            this.моваToolStripMenuItem.Click += new System.EventHandler(this.моваToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem2
            // 
            resources.ApplyResources(this.languageToolStripMenuItem2, "languageToolStripMenuItem2");
            this.languageToolStripMenuItem2.Items.AddRange(new object[] {
            resources.GetString("languageToolStripMenuItem2.Items"),
            resources.GetString("languageToolStripMenuItem2.Items1")});
            this.languageToolStripMenuItem2.Name = "languageToolStripMenuItem2";
            this.languageToolStripMenuItem2.Tag = "";
            this.languageToolStripMenuItem2.SelectedIndexChanged += new System.EventHandler(this.languageToolStripMenuItem2_SelectedItemChanged);
            this.languageToolStripMenuItem2.Click += new System.EventHandler(this.languageToolStripMenuItem2_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator11,
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoToolStripMenuItem,
            this.fileToolStripMenuItem1,
            this.toolsToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // logoToolStripMenuItem
            // 
            this.logoToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.logoToolStripMenuItem, "logoToolStripMenuItem");
            this.logoToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.logoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.logoToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.logoToolStripMenuItem.Name = "logoToolStripMenuItem";
            this.logoToolStripMenuItem.Click += new System.EventHandler(this.лроToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.statusStrip1.BackColor = System.Drawing.Color.Black;
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked_1);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.Goldenrod;
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(500, 3, 1, 3);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.LargeChange = 10;
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolTip1.ForeColor = System.Drawing.Color.DimGray;
            // 
            // Exit_bt
            // 
            resources.ApplyResources(this.Exit_bt, "Exit_bt");
            this.Exit_bt.BackColor = System.Drawing.Color.Transparent;
            this.Exit_bt.BackgroundImage = global::WinForm.Resource1.exit;
            this.Exit_bt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit_bt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Exit_bt.FlatAppearance.BorderSize = 0;
            this.Exit_bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkViolet;
            this.Exit_bt.ForeColor = System.Drawing.Color.Transparent;
            this.Exit_bt.Name = "Exit_bt";
            this.Exit_bt.UseVisualStyleBackColor = true;
            this.Exit_bt.Click += new System.EventHandler(this.Exit_bt_Click_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btStop
            // 
            this.btStop.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.btStop, "btStop");
            this.btStop.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btStop.Name = "btStop";
            this.btStop.UseVisualStyleBackColor = false;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Exit_bt);
            this.Controls.Add(this.deleteTableBt);
            this.Controls.Add(this.addRowBt);
            this.Controls.Add(this.addColumnBt);
            this.Controls.Add(this.pushDBButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startSortBT);
            this.Controls.Add(this.labelSort);
            this.Controls.Add(this.sortersListBox);
            this.Controls.Add(this.initBt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InitFromList);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TransparencyKey = System.Drawing.Color.DarkMagenta;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox InitFromList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button initBt;
        private System.Windows.Forms.Button startSortBT;
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.ListBox sortersListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button pushDBButton;
        private System.Windows.Forms.Button addColumnBt;
        private System.Windows.Forms.Button addRowBt;
        private System.Windows.Forms.Button deleteTableBt;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Button Exit_bt;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem моваToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox languageToolStripMenuItem2;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btStop;
    }
}

