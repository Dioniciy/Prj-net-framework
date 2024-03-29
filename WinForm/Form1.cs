﻿using System;
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
using ISorterNS;

namespace WinForm
{
    
    public partial class Form1 : Form, IObserver
    {

        WorkClass workProgram = WorkClass.GetInstance();
        //bool flagUpdate = false;
        int progresWork = 0;
        
        indexses some = new indexses();
        public void Update(ISubject subject)
        {
            
            if ((subject as WorkClass).SortCompleted)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                if((subject as WorkClass).SwapActived)
                {
                    if(some.flagReadyBackup == false) { some.flagReadyBackup = true; }
                    else
                    {
                        some.SetBackup();
                    }
                    some.index1 = (subject as WorkClass).swapArgs.firstElement/workProgram.GetLengh() ;
                    some.index2 = (subject as WorkClass).swapArgs.firstElement - (workProgram.GetLengh() * some.index1);

                    some.index3 = (subject as WorkClass).swapArgs.secondElement / workProgram.GetLengh();
                    some.index4 = (subject as WorkClass).swapArgs.secondElement  -( workProgram.GetLengh()  * some.index3);
                    
                    
                }
                //flagUpdate = true;
                progresWork = (subject as WorkClass).progres;

                backgroundWorker1.ReportProgress(progresWork,some);
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

        private const int cGrip = 30;      
        private const int cCaption = 30;   

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
            {  
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2; 
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; 
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
                workProgram.InitArray(arrayNums, dataGridView.Rows.Count - 1, dataGridView.Columns.Count);
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
        
        int SortStart(int index)
        {
            workProgram.StartSortMethod(index);
            return 1;
        }
        private void startSortBT_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy)
            {
                some.Clear();
                backgroundWorker1.RunWorkerAsync(sortersListBox.SelectedIndex);
                initBt.Enabled= false;          
            }            
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
            if (SortStart((int)e.Argument) == 0 || worker.CancellationPending == true)
            {
               
            }        
            e.Cancel = true;   
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;

            //dataGridView[5,0].Selected = true;
            
            if((e.UserState as indexses).flagHaveBackup )
            {
                dataGridView[(e.UserState as indexses).BackIndex2, (e.UserState as indexses).BackIndex1].Selected = false;
                dataGridView[(e.UserState as indexses).BackIndex4, (e.UserState as indexses).BackIndex3].Selected = false;
            }
            dataGridView[(e.UserState as indexses).index2, (e.UserState as indexses).index1].Selected = true;
            dataGridView[(e.UserState as indexses).index4, (e.UserState as indexses).index3].Selected = true;
            
            //ShowArray();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowArray();
            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            initBt.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            workProgram.ChangeSpeedEvent(trackBar1.Value);
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            backgroundWorker1. CancelAsync();
        }
    }
    public class indexses
    {
        public int index1 = 0, index2 = 0, index3 = 0, index4 = 0;
        public bool flagReadyBackup = false;
        public bool flagHaveBackup = false;
        public int BackIndex1 = 0, BackIndex2 = 0, BackIndex3 = 0, BackIndex4 = 0;
        public void SetBackup() { BackIndex1 = index1; BackIndex2 = index2; BackIndex3 = index3; BackIndex4 = index4; flagHaveBackup = true; }
        public void Clear()
        {
            BackIndex1 = 0;
            BackIndex2 = 0;
            BackIndex3 = 0;
            BackIndex4 = 0;
            index1 = 0;
            index2 = 0;
            index3 = 0;
            index4 = 0;
            flagHaveBackup = false;
            flagReadyBackup = false;
        }
    }
}
