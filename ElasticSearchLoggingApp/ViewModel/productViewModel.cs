using ElasticSearchLoggingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearchLoggingApp.ViewModel
{
    public class productViewModel
    {
        public IEnumerable<categories> category { get; set; }
        public products product { get; set; }
    }
}