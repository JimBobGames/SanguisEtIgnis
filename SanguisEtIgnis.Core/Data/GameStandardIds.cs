using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public static class GameStandardIds
    {
        public const int RACEID_TERRANS = 1;
        public const int RACEID_ORION = 2;

        public const int TERRAN_DESTROYER_DESIGNID = 100;
        public const int TERRAN_ESCORT_DESIGNID = 101;
        public const int TERRAN_CORVETTE_DESIGNID = 102;
        public const int TERRAN_FRIGATE_DESIGNID = 103;

        public const int ORION_DESTROYER_DESIGNID = 110;

        public const int SOL_SOLARSYSTEMID = 1;
        public const int SOL_EARTHID = 1;
        public const int SOL_MARSID = 1;
        public const int SOL_TERRANSHIPYARDID = 1;

        // small ships (odule size 1)
        public const int ID_HULL_ESCORT = 1;
        public const int ID_HULL_CORVETTE = 2;
        public const int ID_HULL_FRIGATE = 3;
        public const int ID_HULL_DESTROYER = 4;
        // medium ships (module size 2)
        public const int ID_HULL_LIGHT_CRUISER = 10;
        public const int ID_HULL_ARMOURED_CRUISER = 11;
        public const int ID_HULL_HEAVY_CRUISER = 12;
        // large ships (module size 4)
        public const int ID_HULL_BATTLECRUISER = 20;
        public const int ID_HULL_BATTLESHIP = 21;



        public const int ID_NO_ENGINE = 0;
        public const int ID_ENGINE_BASIC_MILITARY_SMALL = 1;
        public const int ID_ENGINE_BASIC_CIVILLIAN_SMALL = 13;

        public const int ID_NO_SHIELD = 0;
        public const int ID_BASIC_SHIELD = 1;

        public const int ID_NO_ARMOUR = 0;
        public const int ID_BASIC_ARMOUR = 1;

        public const int ID_NO_WEAPON = 0;
    }
}