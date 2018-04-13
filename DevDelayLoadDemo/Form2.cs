using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevDelayLoadDemo
{
    public partial class Form2 : Form
    {
        private int pageIndex = 1;
        private int pageSize = 20;
        List<Person> lstPerson = new List<Person>();
        List<Person> lstBindData = new List<Person>();
        private int currentCount = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                lstPerson.Add(new Person { Id = i, Name = ((char)i).ToString(), Age = i });
            }
            lstBindData = lstPerson.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            currentCount = lstBindData.Count;
            gridControl1.DataSource = lstBindData;

        }

        private void gridView1_TopRowChanged(object sender, EventArgs e)
        {
            GridView gv = sender as GridView;
            //if (gv.IsRowVisible(currentCount - pageSize) == RowVisibleState.Visible)
            //{

            //}
            if (currentCount >=  lstPerson.Count)
            {
                //gridView1.TopRowChanged -= gridView1_TopRowChanged;
                return;
            }
            //if (gv.TopRowIndex > currentCount - pageSize  )
            if(gv.IsRowVisible(currentCount - pageSize + 1) == RowVisibleState.Visible)
            {
                pageIndex++;
                lstBindData.AddRange(lstPerson.Skip((pageIndex - 1) * pageSize).Take(pageSize));
                currentCount = lstBindData.Count;
                gridView1.RefreshData();
            }
        }
    }
}
