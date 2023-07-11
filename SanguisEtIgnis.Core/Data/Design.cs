using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public enum DesignSize
    {
        NoSize = 0,
        Escort = 1, // escorts SMALL
        Cruiser = 2, // cruisers MEDIUM
        Battleship = 3, // battleships LARGE
        Dreadnought = 4, // dreadnoughts HUGE
        Starbase = 5, // starbase
    }

    public enum HullSize
    {
        NoSize = 0,

        // Escorts
        Escort = 1,
        Corvette = 2,
        Frigate = 3,
        Destroyer = 4,
        LargeDestroyer = 5,

        // cruisers
        LightCruiser = 6,
        ScoutCruiser = 7,
        HeavyCruiser = 8,
        BattleCruiser = 9,

        // battleships


        // dreadnoughts
    }

    public class Design : NamedObject
    {
        public int DesignId { get; set; }
        public Hull Hull { get; set; }
        /// <summary>
        /// Indicates the parent design if this is a refit
        /// </summary>
        public Design RefitFrom { get; set; }

        public DesignSize DesignSize { get; set; }
        public int SurveySpeed
        {
            get
            {
                // temp number
                return 4;
            }
        }

        // each design can have one type of shields
        public Shield? Shield { get; set; }
        public int NumberOfShieldGenerators { get; set; }
        public int MaximumShieldPoints { get; set; }

        // each design can have one type of armour
        public Armour? Armour { get; set; }
        public int NumberOfArmourLayers { get; set; }
        public int MaximumArmourPoints { get; set; }

        // each design can have one type of engine
        public Engine? Engine { get; set; }
        public int NumberOfEngines { get; set; }
        public int MaximumEnginePoints { get; set; }

    }
}
