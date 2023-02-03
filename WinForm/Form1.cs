using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WorkClassNS;
using System.Xml.Linq;
using System.Globalization;
using System.Threading;

namespace WinForm
{
    public partial class Form1 : Form, IObserver
    {

        WorkClass workProgram = WorkClass.GetInstance();
        bool flagUpdate = false;
        int progresWork = 0;
        public void Update(ISubject subject)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            if ((subject as WorkClass).SortCompleted)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                flagUpdate = true;
                progresWork = (subject as WorkClass).progres;
                
                //this.Refresh();
            }
            
        }       
        public Form1()
        {
            //CultureInfo.CurrentUICulture = new CultureInfo(CultureInfo.InstalledUICulture.Name);
            CultureInfo.CurrentUICulture = new CultureInfo(InputLanguage.CurrentInputLanguage.Culture.Name);
            InitializeComponent();
            Init();

            //this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";
            
            this.DoubleBuffered = true;
            this.SetStyle((System.Windows.Forms.ControlStyles)0x10, true);
            dataGridView.AutoSize = true;       
        }
        void Init()
        {
            //languageToolStripMenuItem2.SelectedIndex = 1; 
            //worker = new BackgroundWorker1;
            workProgram.Attach(this);
            sortersListBox.Items.Add("Start all");
            string[] names = workProgram.GetNamesMethods();
            foreach (string name in names)
            {
                sortersListBox.Items.Add(name);
            }
            sortersListBox.SelectedIndex = 0;

            InitFromList.SelectedIndex = 0;

        }
        private void ChangeLanguage(string lang)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            foreach (Control c in this.Controls)
            {

                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
        }

        private const int cGrip = 30;      // Grip size
        private const int cCaption = 30;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc;//= new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
                         // ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);

            e.Graphics.FillRectangle(Brushes.Transparent, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void initBt_Click(object sender, EventArgs e)
        {
            if(InitFromList.SelectedIndex == 0)
            {
                string[,] arrayNums = new string[dataGridView.Rows.Count, dataGridView.Columns.Count];
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        try 
                        { 
                            arrayNums[i, j] = dataGridView[j, i].Value.ToString();
                        }
                        catch(Exception) { arrayNums[i, j] = "0"; }
                    }
                }
                workProgram.init.InitArray(arrayNums, dataGridView.Rows.Count - 1, dataGridView.Columns.Count);
            }          
            workProgram.StartInitMethod(InitFromList.SelectedIndex);
            ShowArray();
        }

        private void sortersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitFromList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowArray();
        }
        void ShowArray()
        {
            if (!workProgram.arrayInited) { return; }
            string[,] arrayNums = workProgram.GetDataAsStringArray();
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();           
            for (int i = 0; i < workProgram.GetLengh(); i++)
            {
                dataGridView.Columns.Add("name" + i, i.ToString());
            }
            dataGridView.Rows.Add(workProgram.GetHeight());
           
            for (int i = 0; i < workProgram.GetHeight(); i++)
            {
                for (int j = 0; j < workProgram.GetLengh(); j++)
                {
                    dataGridView[j, i].Value = (object)arrayNums[i, j];
                }
            }
            ResizeWindow(true);
        }

        void ResizeWindow(bool upDown) 
        {
            switch(upDown)
            {
                case true:
                    if (dataGridView.Width + 20 > this.Width)
                    {
                        this.Width = dataGridView.Width + 50;
                    }
                    if (dataGridView.Height + dataGridView.Location.Y + 50 > this.Height)
                    {
                        this.Height = dataGridView.Height + dataGridView.Location.Y + 50;
                    }
                    
                    break;
                case false:
                    if (dataGridView.Width + 20 < this.Width && dataGridView.Width + 20 < this.MinimumSize.Width)
                    {
                        this.Width = this.MinimumSize.Width;
                    }
                    if (dataGridView.Width + dataGridView.Location.Y+50 < this.Height && dataGridView.Height + dataGridView.Location.Y +50< this.MinimumSize.Height)
                    {
                        this.Height = this.MinimumSize.Height;
                    }
                    break;

            }  
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void addColumnBt_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("name" , $"{dataGridView.Columns.Count}");
            ResizeWindow(true);
        }

        private void addRowBt_Click(object sender, EventArgs e)
        {
            if(dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("name", $"{dataGridView.Columns.Count}");
            }
            dataGridView.Rows.Add();
            ResizeWindow(true);
        }

        private void deleteTableBt_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            ResizeWindow(false);
        }

        private void pushDBButton_Click(object sender, EventArgs e)
        {
            if(workProgram.arrayInited)
            {
                workProgram.SaveToDB();
            }
            
        }
        Thread sortTrhread;
        void SortStart(object obj)
        {

            //sortTrhread.Start(sortersListBox.SelectedIndex);
            workProgram.StartSortMethod((int)obj);
        }
        private void startSortBT_Click(object sender, EventArgs e)
        {
            //workProgram.StartSortMethod(sortersListBox.SelectedIndex);
            
             
            sortTrhread = new Thread(new ParameterizedThreadStart(SortStart));
            sortTrhread.Start(sortersListBox.SelectedIndex);
            //Thread sortTrhread;
            //sortTrhread  = new Thread(new ParameterizedThreadStart(StartSort));
            //sortTrhread.Start(sortersListBox.SelectedIndex);
            //workProgram.SelectSortMethod(sortersListBox.SelectedIndex);

            //ShowArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void лроToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Exit_bt_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void statusStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void languageToolStripMenuItem2_SelectedItemChanged(object sender, EventArgs e)
        {
            
            if (languageToolStripMenuItem2.SelectedItem.ToString() == "English")
            {
                ChangeLanguage("en");
            }
            else if (languageToolStripMenuItem2.SelectedItem.ToString() == "Українська")
            {
                ChangeLanguage("uk-UA");
            }
            else
            {
                ChangeLanguage("fr-FR");
            }
        }

        private void languageToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void моваToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //SortStart( worker,  e);
            //SortStart(worker);

            //SortStart();
            while (true)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                if (flagUpdate)
                {
                    flagUpdate = false;
                    backgroundWorker1.ReportProgress(progresWork);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            //ShowArray();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //backgroundWorker1.Dispose();
            ShowArray();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            workProgram.ChangeSpeedEvent(trackBar1.Value);
        }
    }
}
