using SanguisEtIgnis.Core.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Ship : NamedObject, IMapCounter
    {
        public int ShipId { get; set; }
        /// <summary>
        /// What division this ship belongs to
        /// </summary>
        public Division? Division { get; set; }

        /// <summary>
        /// What design
        /// </summary>
        public Design? Design { get; set; }

        public string DetailedName { get { return "FF " + Name; } }

        public HexFacing HexFacing { get; set; }

        public Module Shield
        {
            get { return Design.Shield; }
        }
        public int NumberOfShieldGenerators
        {
            get { return Design.NumberOfShieldGenerators; }
        }
        public int MaximumShieldPoints
        {
            get { return Design.MaximumShieldPoints; }
        }
        public int CurrentShieldPoints { get; set; }

        public Armour Armour
        {
            get { return Design.Armour; }
        }
        public int NumberOfArmourLayers
        {
            get { return Design.NumberOfArmourLayers; }
        }
        public int MaximumArmourPoints
        {
            get { return Design.MaximumArmourPoints; }
        }

        public int CurrentArmourPoints { get; set; }

        public Engine Engine
        {
            get { return Design.Engine; }
        }
        public int NumberOfEngines
        {
            get { return Design.NumberOfEngines; }
        }
        public int MaximumEnginePoints
        {
            get { return Design.MaximumEnginePoints; }
        }
        public int CurrentEnginePoints { get; set; }
    }
}
