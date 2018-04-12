using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Xpo;

namespace T217478 {
    public partial class Form1 : Form {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                DataItem item = new DataItem();
                item.Customer = i;
                dataItemBindingSource.Add(item);
            }
        }
    }

    public class DataItem
    {

        private int fCustomer;

        public int Customer
        {
            get { return fCustomer; }
            set
            {
                fCustomer = value;
            }
        }
        
        public DataItem()
        {
            
        }
    }

    public class Customer : XPObject {
        public Customer(Session session)
            : base(session) {
        }

        private string fName;
        private int fID;
        public int ID {
            get { return fID; }
            set { SetPropertyValue("ID", ref fID, value); }
        }

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Name {
            get { return fName; }
            set { SetPropertyValue("Name", ref fName, value); }
        }
    }
}
