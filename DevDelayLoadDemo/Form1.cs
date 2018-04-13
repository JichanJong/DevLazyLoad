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
    public partial class Form1 : Form
    {
        //private WcfRepositoryItemSearchLookUpEdit obj;
        private List<Person> lstData = new List<Person>();
        protected int PageCount { get; set; } = 1;
        protected int PageSize { get; } = 10;
        private List<Person> lstBindData = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lst = lstData.Take(100).ToList();
            searchLookUpEdit1.Properties.DataSource = lst;
            gridControl1.DataSource = lst; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 1000; i++)
            {
                lstData.Add(new Person() { Id = i, Name = ((char)i).ToString(), Age = i });
            }
            lstBindData = lstData.Take(20).ToList();

            //searchLookUpEdit1.Properties.DisplayMember = "Name";
            //searchLookUpEdit1.Properties.ValueMember = "Id";
            DataTable dt = new DataTable();
            //dt.Columns.Add("Id", Type.GetType("System.Int32"));
            //dt.Columns.Add("Name", Type.GetType("System.String"));
            //DataRow dr = dt.NewRow();
            //dr["Id"] = 1;
            //dr["Name"] = "张三";
            //dt.Rows.Add(dr);
            //searchLookUpEdit1.Properties.DataSource = dt;//.AsEnumerable().ToList();

            //searchLookUpEdit1.Properties.DataSource = lstBindData;            
            searchLookUpEdit1.BindData<Person>("Name", "Id", 1,20, (string filterText,int pageIndex,int pageSize,out int count) =>
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    count = lstData.Count;
                    return lstData.Skip((pageIndex -1) * pageSize).Take(pageSize).ToList();
                }
                var result = lstData.Where(p => p.Name.Contains(filterText) || p.Age.ToString().Contains(filterText) || p.Id.ToString().Contains(filterText));
                count = result.Count();
                return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            });



            //PageCount = 10;

            //searchLookUpEdit1.Properties.DataSource = lstData.Take(20).ToList();
            //searchLookUpEdit1.Properties.View.ApplyFindFilter
            //searchLookUpEdit1.QueryProcessKey
            //gridView1.TopRowChanged += GridView1_TopRowChanged;
            //searchLookUpEdit1.
            //gridView1.change

            //searchLookUpEdit1View.ColumnFilterChanged += SearchLookUpEdit1View_ColumnFilterChanged;
        }

        private void SearchLookUpEdit1View_ColumnFilterChanged(object sender, EventArgs e)
        {
            string filterText = searchLookUpEdit1View.FindFilterText;
            lstBindData.Clear();
            lstBindData.AddRange(lstData.Where(p => p.Name.Contains(filterText) || p.Age.ToString().Contains(filterText) || p.Id.ToString().Contains(filterText)));
            searchLookUpEdit1View.RefreshData();
            searchLookUpEdit1View.ApplyFindFilter(filterText);
        }

        private void GridView1_TopRowChanged(object sender, EventArgs e)
        {
            if (gridView1.TopRowIndex > gridView1.RowCount - PageSize )
            {

            }
            Console.WriteLine(gridView1.TopRowIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(gridView1.LinkCount.ToString());
            MessageBox.Show(gridView1.DataRowCount.ToString());
            MessageBox.Show(gridView1.RowCount.ToString());
            MessageBox.Show(gridView1.ScrollStyle.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lstBindData.Clear();
            lstBindData.AddRange(lstData.Skip(100).Take(50));
            searchLookUpEdit1View.RefreshData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            DataTable dtSchema = new DataTable();
            dtSchema.Columns.Add("Id");
            dtSchema.Columns.Add("Name");

            DataRow dr = dtSchema.NewRow();
            dr["Id"] = "1";
            dr["Name"] = "张三";
            dtSchema.Rows.Add(dr);

            dt = dtSchema.Clone(); 
                dt.ImportRow(dr);
            dt.AcceptChanges();
            MessageBox.Show("ok");
        }
    }

    
}
