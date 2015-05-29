using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Repository
{
    public class IdentityEntityMapping<TEntity> : EntityMapping<TEntity> where TEntity : IdentityEntity
    {
        public IdentityEntityMapping()
            :base()
        {
            this.Property(m => m.Creator).HasColumnName("CREATOR").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            this.Property(m => m.CreateTime).HasColumnName("CREATE_TIME").IsOptional();
            this.Property(m => m.Updator).HasColumnName("UPDATOR").HasColumnType("nvarchar").HasMaxLength(50).IsOptional();
            this.Property(m => m.UpdateTime).HasColumnName("UPDATE_TIME").IsOptional();
            this.Property(m => m.Status).HasColumnName("STATUS").IsRequired();
        }
    }
}
