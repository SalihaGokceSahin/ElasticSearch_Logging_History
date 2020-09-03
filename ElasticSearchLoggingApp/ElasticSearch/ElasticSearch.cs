using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;
using ElasticSearchLoggingApp.Models;

namespace ElasticSearchLoggingApp.ElasticSearch
{
    public class ElasticSearch
    {
        private static readonly ConnectionSettings conSettings =
            new ConnectionSettings(new Uri("http://localhost:9200/")).DefaultIndex("change_history").MapDefaultTypeIndices(m => m.Add(typeof(ChangeLogs), "change_history"));

        private static readonly ElasticClient elasticClient = new ElasticClient(conSettings);

        public static void CheckExistsAndInsert(ChangeLogs logs)
        {
            if (!elasticClient.IndexExists("change_log").Exists)
            {
                var indexSettings = new IndexSettings();
                indexSettings.NumberOfReplicas = 1;
                indexSettings.NumberOfShards = 3;

                var CreateIndexDescriptor = new CreateIndexDescriptor("change_history").
                    Mappings(ms => ms.Map<ChangeLogs>(m => m.AutoMap())).
                    InitializeUsing(new IndexState() { Settings = indexSettings }).
                    Aliases(a => a.Alias("change_log"));
                var Response = elasticClient.CreateIndex(CreateIndexDescriptor);
            }
            elasticClient.Index<ChangeLogs>(logs, idx => idx.Index("change_history"));
        }
    }
}