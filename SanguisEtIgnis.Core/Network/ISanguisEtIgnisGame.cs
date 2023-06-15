using SanguisEtIgnis.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Network
{
    public interface ISanguisEtIgnisGame
    {
        Dictionary<int, Army> Armies
        {
            get;
        }
        Battalion SelectedBattalion { get; set; }

        Battalion GetBattalion(int battalionId);
    }
}