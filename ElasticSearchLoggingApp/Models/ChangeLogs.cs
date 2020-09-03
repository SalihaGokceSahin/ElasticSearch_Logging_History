using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearchLoggingApp.Models
{
        public enum enumState
        {
            Update = 1,
            Delete = 2,
            Added = 3
        }

        public class ChangeLogs
        {
            public string EntityName { get; set; }
            public string PropertyName { get; set; }
            public int PrimaryKeyValue { get; set; }
            public string OldValue { get; set; }
            public string NewValue { get; set; }
            public System.DateTime DateChange { get; set; }
            public enumState State { get; set; }
        }
    }
