using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Core.Entities
{
    public class AppEmail : BaseEntity
    {
        public int App_id { get; set; }
        public int AppName { get; set; }
        public int? ConnectionID { get; set; }
        public int ProcedureName { get; set; }
    }
}
