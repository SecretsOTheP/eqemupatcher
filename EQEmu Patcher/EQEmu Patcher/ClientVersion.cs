using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQEmu_Patcher
{    
    public enum VersionTypes
    {
        Unknown,
        Quarm
    }

    class ClientVersion
    {
        public string FullName;
        public string ShortName;

        public ClientVersion(string fName, string sName)
        {
            FullName = fName;
            ShortName = sName;
        }
    }
}
