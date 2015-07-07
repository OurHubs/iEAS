using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    public class ChannelService : IdentityDomainService<Channel, iEAS.Repository.iEASRepository>, IChannelService
    {
        public override void Create(Channel entity)
        {
            IChannelService channelService = ObjectContainer.GetService<IChannelService>();
            using(var req=channelService.BeginContext())
            {
                req.Create(entity);
                entity.FullName = "/" + entity.Name + "/";
                entity.FullPath = "/" + entity.ID + "/";
                entity.ParentName = "/";
                entity.ParentPath = "/";                
                if(entity.ParentID!=null)
                {
                    
                    var parent=channelService.GetByID(entity.ParentID.Value);
                    do
                    {
                        entity.FullName = "/"+parent.Name + entity.FullName;
                        entity.FullPath = "/"+parent.ID +entity.FullPath;
                        entity.ParentName = "/" + parent.Name + entity.ParentName;
                        entity.ParentPath = "/" + parent.ID + entity.ParentPath;

                        parent = parent.Parent;
                    }
                    while (parent!=null);
                }
                req.Commit();
            }
        }

        public override void Update(Channel entity)
        {
            IChannelService channelService = ObjectContainer.GetService<IChannelService>();
            using (var req = channelService.BeginContext())
            {
                entity.FullName = "/" + entity.Name + "/";
                entity.FullPath = "/" + entity.ID + "/";
                entity.ParentName = "/";
                entity.ParentPath = "/";
                if (entity.ParentID != null)
                {                   
                    var parent = channelService.GetByID(entity.ParentID.Value);
                    do
                    {
                        entity.FullName = "/" + parent.Name + entity.FullName;
                        entity.FullPath = "/" + parent.ID + entity.FullPath;
                        entity.ParentName = "/" + parent.Name + entity.ParentName;
                        entity.ParentPath = "/" + parent.ID + entity.ParentPath;

                        parent = parent.Parent;
                    }
                    while (parent != null);
                }
                req.Update(entity);
                req.Commit();
            }
        }

        public override void DeleteByID(int id)
        {
            var channelService = ObjectContainer.GetService<IChannelService>();
            using (var ctx = channelService.BeginContext())
            {
                var channelList = channelService.Query(m => m.Status == 1);
                var channel=channelList.FirstOrDefault(m=>m.ID==id);
                DeleteChannel(channel, channelList);
                ctx.Commit();
            }
        }
        
        private void DeleteChannel(Channel channel,IEnumerable<Channel> channels)
        {
            if(channel!=null)
            {
                channel.Deleted();
                var children = channels.Where(m => m.ParentID == channel.ID);
                foreach(var child in children)
                {
                    DeleteChannel(child, channels);
                }
            }
        }
    }
}
