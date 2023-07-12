using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Player : NamedObject
    {
        public int PlayerId { get; set; }
        public Nation Nation { get; set; }
    }
}
