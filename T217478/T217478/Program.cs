using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T217478
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionString = MSSqlConnectionProvider.GetConnectionString(@"(local)", "Customers");
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateTable();
            Application.Run(new Form1());
        }
        private static void CreateTable()
        {
            UnitOfWork uow = new UnitOfWork();
            XPCollection<Customer> col = new XPCollection<Customer>(uow);
            if (col.Count != 0)
                return;
            for (int i = 0; i < 50; i++)
            {
                Customer customer = new Customer(uow);
                customer.ID = i;
                customer.Name = "Name" + i;
                col.Add(customer);
            }
            uow.CommitChanges();
        }
    }
}
