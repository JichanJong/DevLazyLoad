using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevDelayLoadDemo
{
    [Persistent("Setting")]
    public class Setting : XPLiteObject
    {
        public Setting(Session session):base(session)
        {

        }
        [Key, DevExpress.Xpo.DisplayName("Id")]
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        [DisplayName("Name")]
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        [DisplayName("Value")]
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }

    }
}
