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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.initBt.Cursor = System.Windows.Forms.Cursors.Default;
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
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.OwnerItem = this.menuToolStripMenuItem;
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.openFileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.openFileToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            resources.ApplyResources(this.openFileToolStripMenuItem, "openFileToolStripMenuItem");
            this.openFileToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.menuToolStripMenuItem.DropDown = this.contextMenuStrip1;
            this.menuToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            resources.ApplyResources(this.menuToolStripMenuItem, "menuToolStripMenuItem");
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.toolsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem1});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // languageToolStripMenuItem1
            // 
            this.languageToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.languageToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
            resources.ApplyResources(this.languageToolStripMenuItem1, "languageToolStripMenuItem1");
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
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
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
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
    }
}

