using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace iEAS.Repository
{
    public class EntityMapping<TEntity>:EntityTypeConfiguration<TEntity> where TEntity:BaseEntity
    {
        public EntityMapping()
        {
            this.HasKey(m => m.ID);
            this.Property(m=>m.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Guid).IsRequired();
            this.Property(m => m.Version).IsConcurrencyToken();
        }
    }
}
