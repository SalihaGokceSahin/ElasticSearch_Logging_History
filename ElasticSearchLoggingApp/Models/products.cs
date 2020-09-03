using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearchLoggingApp.Models
{
    public class products
    {
        public int id { get; set; }
        public int categories_id { get; set; }
        public string name { get; set; }
        public int MyProperty { get; set; }
        public double price { get; set; }
        public byte count { get; set; }
        public virtual categories categories { get; set; }
    }
}