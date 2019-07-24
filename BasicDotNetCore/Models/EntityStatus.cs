using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDotNetCore.Models
{
    public class EntityStatus
    {
        public static int Deleted { get { return -404; } }
        public static int Inactive { get { return -1; } }
        public static int Active { get { return 0; } }
    }
}
