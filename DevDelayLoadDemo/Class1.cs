using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevDelayLoadDemo
{
    using System.Windows.Forms;
    using DevExpress.Xpo;
    using DevExpress.Xpo.DB;
    using DevExpress.Xpo.Metadata;
    using DevExpress.XtraGrid;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Generate the connection string to the AdventureWorks database on local SQL Server. 
            XpoDefault.ConnectionString =
            MSSqlConnectionProvider.GetConnectionString("(local)", "AdventureWorks");
            // Create a Session object. 
            Session session1 = new Session();
            // Create an XPClassInfo object corresponding to the Person_Contact class. 
            XPClassInfo classInfo = session1.GetClassInfo(typeof(Person_Contact));
            // Create an XPServerCollectionSource object. 
            XPServerCollectionSource xpServerCollectionSource1 =
            new XPServerCollectionSource(session1, classInfo);
            // Create a grid control. 
            GridControl gridControl1 = new GridControl();
            gridControl1.Dock = DockStyle.Fill;
            this.Controls.Add(gridControl1);
            // Enable server mode. 
            gridControl1.ServerMode = true;
            // Bind the grid control to the data source. 
            gridControl1.DataSource = xpServerCollectionSource1;
        }
    }
    [Persistent("Person.Contact")]
    public class Person_Contact : XPLiteObject
    {
        public Person_Contact(Session session) : base(session) { }
        [Key, DevExpress.Xpo.DisplayName("ID")]
        public System.Int32 ContactID;
        public string Title;
        [DevExpress.Xpo.DisplayName("First Name")]
        public string FirstName;
        [DevExpress.Xpo.DisplayName("Middle Name")]
        public string MiddleName;
        [DevExpress.Xpo.DisplayName("Last Name")]
        public string LastName;
        [DevExpress.Xpo.DisplayName("E-mail")]
        public string EmailAddress;
        public string Phone;
    }
}
