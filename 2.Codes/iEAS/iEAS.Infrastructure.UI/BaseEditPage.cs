using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Infrastructure.UI
{
    public class EditForm:System.Web.UI.Page
    {
        public Guid RecordID
        {
            get { return Request["rid"].ToGuid(Guid.Empty); }
        }
    }
}
