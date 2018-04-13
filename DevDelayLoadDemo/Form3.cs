using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

namespace DevDelayLoadDemo
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            // Generate the connection string to the AdventureWorks database on local SQL Server. 
            XpoDefault.ConnectionString =
            MSSqlConnectionProvider.GetConnectionString("(local)", "EFDb");
            // Create a Session object. 
            Session session1 = new Session();
            // Create an XPClassInfo object corresponding to the Person_Contact class. 
            XPClassInfo classInfo = session1.GetClassInfo(typeof(Setting));
            // Create an XPServerCollectionSource object. 
            XPServerCollectionSource xpServerCollectionSource1 =
            new XPServerCollectionSource(session1, classInfo);
            //xpServerCollectionSource1.
            //xpServerCollectionSource1.ObjectClassInfo

            // gridControl1.ServerMode = true; ;

            gridControl1.DataSource = xpServerCollectionSource1 ;
        }
    }
}
