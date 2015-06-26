using iEAS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Repository.Mapping.Module
{
    public class ChannelMapping : IdentityEntityMapping<Channel>
    {
        public ChannelMapping()
        {
            this.ToTable("CHANNEL");

            this.Property(m => m.Name, "NAME", 50);
            this.Property(m => m.Code, "CODE", 50);
            this.Property(m => m.Desc, "DESC", 200);
            this.Property(m => m.ParentID, "PARENT_ID");
            this.Property(m => m.ChannelType, "CHANNEL_TYPE",50);
            this.Property(m => m.Model, "MODEL", 50);
            this.Property(m => m.ModelChannel, "MODEL_CHANNEL", 50);
            this.Property(m => m.Url, "URL", 500);
            this.Property(m => m.Template, "TEMPLATE", 500);
            this.Property(m => m.Sort, "SORT");

            this.HasOptional(m => m.Parent).WithMany(m => m.Children).HasForeignKey(m => m.ParentID);
        }
    }
}
