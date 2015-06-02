using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Module
{
    public class Feature:IdentityEntity
    {
        private List<Feature> _Children = new List<Feature>();

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ModuleInfo Module { get; set; }

        public int ModuleID { get; set; }

        public virtual Feature Parent { get; set; }

        public int? ParentID { get; set; }

        public virtual List<Feature> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
    }
}
