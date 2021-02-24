
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Real.Datos.Modelo
{
    public class AuditDbContext
    {

        private readonly ObjectContext _objectContext;
        public AuditDbContext(ObjectContext objectContext)
        {
            _objectContext = objectContext;
        }

        internal EntityAudit[] Records(object changeTracker)
        {
            throw new NotImplementedException();
        }

        public EntityAudit[] Records(DbChangeTracker tracker)
        {
            return tracker.Entries().Where(p => p.State == EntityState.Deleted || p.State == EntityState.Modified).Select(x => GetRecordsForChange(x)).ToArray();
        }

        private void Column(XElement detail, string propertyName, string originalvalue, string newvalue)
        {
            var c = new XElement("C");
            c.Add(new XElement("N", propertyName));
            c.Add(new XElement("OV", originalvalue ?? ""));
            c.Add(new XElement("NV", newvalue ?? ""));
            detail.Add(c);
        }

        private EntityAudit GetRecordsForChange(DbEntityEntry dbEntry)
        {
            var metadata = SchemaTableKey(dbEntry);

            var entityAudit = new EntityAudit { EventDate = DateTime.Now, TableName = metadata.SchemaTableName };

            var detail = new XElement("D");

            switch (dbEntry.State)
            {
                case EntityState.Added:

                    foreach (string propertyName in dbEntry.CurrentValues.PropertyNames)
                    {
                        var newvalue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString();
                        Column(detail, propertyName, null, newvalue);
                    }
                    entityAudit.ActionType = ActionTypeAudit.Added;
                    entityAudit.RecordId = string.IsNullOrEmpty(metadata.KeyName) ? "" : dbEntry.CurrentValues.GetValue<object>(metadata.KeyName).ToString();
                    break;

                case EntityState.Deleted:
                    foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                    {
                        var originalvalue = dbEntry.GetDatabaseValues().GetValue<object>(propertyName) == null ? null : dbEntry.GetDatabaseValues().GetValue<object>(propertyName).ToString();
                        Column(detail, propertyName, originalvalue, null);
                    }

                    entityAudit.ActionType = ActionTypeAudit.Deleted;
                    entityAudit.RecordId = string.IsNullOrEmpty(metadata.KeyName) ? "" : dbEntry.GetDatabaseValues().GetValue<object>(metadata.KeyName).ToString();

                    break;

                case EntityState.Modified:
                    entityAudit.ActionType = ActionTypeAudit.Modified;

                    foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                    {
                        if (!object.Equals(dbEntry.GetDatabaseValues().GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
                        {
                            var originalvalue = dbEntry.GetDatabaseValues().GetValue<object>(propertyName) == null ? null : dbEntry.GetDatabaseValues().GetValue<object>(propertyName).ToString();
                            var newvalue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString();

                            Column(detail, propertyName, originalvalue, newvalue);
                            if (propertyName == "BORRADO" && newvalue == "True") //Eliminó
                            {
                                entityAudit.ActionType = ActionTypeAudit.Deleted;
                            }
                        }
                    }
                    entityAudit.RecordId = string.IsNullOrEmpty(metadata.KeyName) ? "" : dbEntry.GetDatabaseValues().GetValue<object>(metadata.KeyName).ToString();

                    break;
            }
            entityAudit.Detail = detail;
            return entityAudit;
        }

        private MetaDataEntity SchemaTableKey(DbEntityEntry dbEntry)
        {
            Type entityType = dbEntry.Entity.GetType();
            if (entityType.BaseType != null && entityType.Namespace == "System.Data.Entity.DynamicProxies")
                entityType = entityType.BaseType;

            string entityTypeName = entityType.Name;
            var entityMeta = _objectContext.MetadataWorkspace.GetItems<EntityContainer>(DataSpace.SSpace)
                .First().BaseEntitySets.First(meta => meta.ElementType.Name == entityTypeName);

            //Un PK x Tabla
            string keyName = entityMeta.ElementType.KeyMembers.Select(k => k.Name).FirstOrDefault();

            return new MetaDataEntity
            {
                SchemaTableName = string.Format("{0}.{1}", entityMeta.Schema, entityTypeName),
                KeyName = keyName
            };
        }

        private class MetaDataEntity
        {
            public string KeyName { get; set; }

            public string Schema { get; set; }

            public string SchemaTableName { get; set; }

            public string TableName { get; set; }
        }
    }
}
