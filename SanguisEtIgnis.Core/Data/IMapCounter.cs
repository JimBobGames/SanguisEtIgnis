using SanguisEtIgnis.Core.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public interface IMapCounter
    {
        string DetailedName { get; }

        HexFacing HexFacing { get; set; }
    }
}
