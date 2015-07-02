using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iEAS
{
    public interface ICloneable<T>:System.ICloneable
    {
        T Clone();
    }
}
