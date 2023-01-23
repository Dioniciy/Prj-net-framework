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

namespace WinForm
{
    public partial class Form1 : Form
    {
        WorkClass workProgram = new WorkClass();
        public Form1()
        {
            
            InitializeComponent();
            Init();
        }
        void Init()
        {
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
                workProgram.InitArray(arrayNums, dataGridView.Rows.Count - 1, dataGridView.Columns.Count);
            }
            else
            {
                workProgram.StartInitMethod(InitFromList.SelectedIndex);
            }
            

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
        }
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void addColumnBt_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("name" , "x");
        }

        private void addRowBt_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
        }

        private void userInitBT_Click(object sender, EventArgs e)
        {
            

        }

        private void deleteTableBt_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
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
    }
}
