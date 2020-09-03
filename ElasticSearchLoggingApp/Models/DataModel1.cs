using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ElasticSearchLoggingApp.Models
{
    public partial class DataModel1 : DbContext
    {
        public DataModel1()
            : base(@"data source=DESKTOP-SSC6LL8\SQLEXPRESS;initial catalog=ProductsDatabase;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<products> products { get; set; }

        public override int SaveChanges()
        {
            try
            {
                var ModifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
                var now = System.DateTime.UtcNow;
                foreach (var change in ModifiedEntities)
                {
                    var entityName = change.Entity.GetType().Name;
                    var PrimaryKey = change.OriginalValues.PropertyNames.FirstOrDefault();

                    foreach (var prop in change.OriginalValues.PropertyNames)
                    {
                        var originalValue = change.OriginalValues[prop].ToString();
                        var currentValue = change.CurrentValues[prop].ToString();
                        if (originalValue != currentValue)
                        {
                            ChangeLogs logs = new ChangeLogs()
                            {
                                EntityName = entityName,
                                PrimaryKeyValue = int.Parse(change.OriginalValues[PrimaryKey].ToString()),
                                PropertyName = prop,
                                OldValue = originalValue,
                                NewValue = currentValue,
                                DateChange = now,
                                State = enumState.Update
                            };
                            ElasticSearch.ElasticSearch.CheckExistsAndInsert(logs);
                        }
                    }
                }
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return 0;
            }


        }


    }
}
