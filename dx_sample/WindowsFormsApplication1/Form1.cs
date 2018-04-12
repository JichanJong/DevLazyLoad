using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            searchLookUpEdit1View.ColumnFilterChanged += searchLookUpEdit1View_ColumnFilterChanged;
        }

        void searchLookUpEdit1View_ColumnFilterChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer t = sender as Timer;
            t.Stop();
            searchLookUpEdit1.ClosePopup();
        }
    }
}
