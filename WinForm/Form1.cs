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

namespace WinForm
{
    public partial class Form1 : Form, IObserver
    {

        WorkClass workProgram = WorkClass.GetInstance();
       
        public void Update(ISubject subject)
        {
            if ((subject as WorkClass).arraySizeEntered)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event.");
            }
        }
        //public event EventHandler ResizeBegin;
        public Form1()
        {
            
            InitializeComponent();
            Init();

            //this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            //this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle((System.Windows.Forms.ControlStyles)0x10, true);
            dataGridView.AutoSize = true;
            //this.SetStyle(ControlStyles.FixedHeight, false);

        }
        private void Form1_ResizeBegin(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the Form.ResizeBegin event.");
        }
        private void Form1_ResizeEnd(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the Form.ResizeEnd event.");
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

        private void userInitBT_Click(object sender, EventArgs e)
        {
            

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

        private void startSortBT_Click(object sender, EventArgs e)
        {
            workProgram.SelectSortMethod(sortersListBox.SelectedIndex);
            ShowArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void лроToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void languageToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Exit_bt_Click(object sender, EventArgs e)
        {

        }

        private void Exit_bt_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void toolStripContainer3_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }

        private void toolTip1_Popup_2(object sender, PopupEventArgs e)
        {

        }
    }
}
