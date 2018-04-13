using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevDelayLoadDemo
{
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
