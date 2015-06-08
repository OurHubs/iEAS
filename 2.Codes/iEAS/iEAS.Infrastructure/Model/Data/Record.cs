using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    [Serializable]
    public class Record
    {
        private readonly DataItemCollection _Items = new DataItemCollection();
        private readonly RecordCollection _Records;

        public Record()
        {
            _Records = new RecordCollection(this);
        }

        public string Table { get; set; }

        public Guid RecordID { get; set; }

        public Guid? OwnerID { get; set; }

        public RecordStatus Status { get; set; }

        public DataItemCollection Items
        {
            get { return _Items; }
        }

        public RecordCollection Records
        {
            get { return _Records; }
        }
    }
}