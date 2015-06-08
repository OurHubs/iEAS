using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS.Model.Data
{
    public class RecordCollection:IEnumerable<Record>
    {
        private readonly List<Record> innerRecords=new List<Record>();
        private readonly Record owner;
        public RecordCollection(Record owner)
        {
            this.owner = owner;
        }
        public void Add(Record record)
        {
            record.OwnerID = owner.RecordID;
            innerRecords.Add(record);
        }

        public void Clear()
        {
            innerRecords.Clear();
        }

        public IEnumerator<Record> GetEnumerator()
        {
            return innerRecords.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerRecords.GetEnumerator();
        }
    }
}
