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
            this.Property(m => m.Creator).IsOptional();
            this.Property(m => m.CreateTime).IsOptional();
            this.Property(m => m.Updator).IsOptional();
            this.Property(m => m.UpdateTime).IsOptional();
            this.Property(m => m.Status).IsRequired();
        }
    }
}
