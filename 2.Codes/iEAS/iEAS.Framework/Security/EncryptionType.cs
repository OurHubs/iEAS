using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iEAS.Security
{
    public enum EncryptionType:byte
    {
        None=0,
        MD5,
        DES,
        RSA,
        AES
    }
}
