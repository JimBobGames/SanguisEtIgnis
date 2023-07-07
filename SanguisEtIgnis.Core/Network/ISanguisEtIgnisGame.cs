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
        Dictionary<int, Nation> Nations
        {
            get;
        }

        IReadOnlyList<Nation> NationsListUnsorted { get; }
        IReadOnlyList<Nation> NationsListAlphabetical { get; }
        Nation GetNation(int id);

        Dictionary<int, SolarSystem> SolarSystems
        {
            get;
        }

        IReadOnlyList<SolarSystem> SolarSystemsListUnsorted { get; }
        IReadOnlyList<SolarSystem> SolarSystemsListAlphabetical { get; }
        SolarSystem GetSolarSystem(int id);

        Battalion SelectedBattalion { get; set; }

        Battalion GetBattalion(int battalionId);
    }
}