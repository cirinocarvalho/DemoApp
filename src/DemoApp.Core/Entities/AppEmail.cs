using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoApp.Core.Entities
{
    public class AppEmail 
    {
        [Key]
        public int App_id { get; set; }
        public string AppName { get; set; }
        public int? ConnectionID { get; set; }
        public string ProcedureName { get; set; }
    }
}
