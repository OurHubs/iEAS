using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace iEAS.Repository
{
    public class EntityMapping<TEntity>:EntityTypeConfiguration<TEntity> where TEntity:BaseEntity
    {
        public EntityMapping()
        {
            this.HasKey(m => m.ID);
            this.Property(m=>m.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.Guid).HasColumnName("GUID").IsRequired();
            this.Property(m => m.Version).HasColumnName("VERSION").IsConcurrencyToken();
        }

        public PrimitivePropertyConfiguration Property(Expression<Func<TEntity, string>> propertyExpression, string columnName, int? maxLength = 50, bool requried = false)
        {
            var prop = this.Property(propertyExpression).HasColumnName(columnName).HasColumnType("nvarchar");
            if (maxLength != null)
            {
                prop = prop.HasMaxLength(maxLength);
            }
            else
            {
                prop = prop.IsMaxLength();
            }
            if(requried)
            {
                prop.IsRequired();
            }
            else
            {
                prop.IsOptional();
            }
            return prop;

        }

        public PrimitivePropertyConfiguration Property(Expression<Func<TEntity, decimal>> propertyExpression, string columnName,byte precision=8, byte scale=2, bool requried = false)
        {
            var prop = this.Property(propertyExpression).HasColumnName(columnName).HasPrecision(precision, scale).IsRequired();
            return prop;
        }
        public PrimitivePropertyConfiguration Property(Expression<Func<TEntity, decimal?>> propertyExpression, string columnName, byte precision = 8, byte scale = 2, bool requried = false)
        {
            var prop = this.Property(propertyExpression).HasColumnName(columnName).HasPrecision(precision, scale).IsOptional();
            return prop;
        }


        public PrimitivePropertyConfiguration Property(Expression<Func<TEntity, DateTime?>> propertyExpression, string columnName, byte precision = 8, bool requried = false)
        {
            var prop = this.Property(propertyExpression).HasColumnName(columnName).HasPrecision(precision).IsOptional();
            return prop;
        }

        public PrimitivePropertyConfiguration Property(Expression<Func<TEntity, DateTime>> propertyExpression, string columnName, byte precision = 8, bool requried = false)
        {
            var prop = this.Property(propertyExpression).HasColumnName(columnName).HasPrecision(precision).IsOptional();
            return prop;
        }


        public PrimitivePropertyConfiguration Property<TKey>(Expression<Func<TEntity, TKey>> propertyExpression, string columnName)
            where TKey:struct
        {
            var prop = this.Property(propertyExpression).HasColumnName(columnName).IsRequired();
            return prop;
        }
        public PrimitivePropertyConfiguration Property<TKey>(Expression<Func<TEntity, TKey?>> propertyExpression, string columnName)
            where TKey : struct
        {
            var prop = this.Property(propertyExpression).HasColumnName(columnName).IsOptional();
            return prop;
        }
    }
}
