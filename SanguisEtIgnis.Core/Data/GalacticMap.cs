using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// Rectangular map of the galaxy
    /// </summary>
    public class GalacticMap
    {
        /// <summary>
        /// The store of solar systems
        /// </summary>
        private readonly Dictionary<int, SolarSystem> solarSystems = new Dictionary<int, SolarSystem>();

        /// <summary>
        /// The store of solar systems objects
        /// </summary>
        private readonly Dictionary<int, SolarSystemObject> solarSystemObjects = new Dictionary<int, SolarSystemObject>();

        /// <summary>
        /// The store of starbases
        /// </summary>
        private readonly Dictionary<int, Starbase> starbases = new Dictionary<int, Starbase>();

        public GalacticMap(int size)
        {

        }

        public Dictionary<int, SolarSystem> SolarSystems
        {
            get
            {
                return solarSystems;
            }
        }
        public Dictionary<int, SolarSystemObject> SolarSystemObjects
        {
            get
            {
                return solarSystemObjects;
            }
        }
        public Dictionary<int, Starbase> Starbases
        {
            get
            {
                return starbases;
            }
        }

        public IReadOnlyList<SolarSystem> SolarSystemsListUnsorted => solarSystems.Values.ToList();
        public IReadOnlyList<SolarSystemObject> SolarSystemObjectsListUnsorted => solarSystemObjects.Values.ToList();
        public IReadOnlyList<SolarSystemObject> StarbasesListUnsorted => starbases.Values.ToList();
        public SolarSystem GetSolarSystem(int id)
        {
            solarSystems.TryGetValue(id, out SolarSystem value);
            return value;
        }

        public Starbase GetStarbase(int id)
        {
            starbases.TryGetValue(id, out Starbase value);
            return value;
        }

        public SolarSystemObject GetSolarSystemObject(int id)
        {
            solarSystemObjects.TryGetValue(id, out SolarSystemObject value);
            return value;
        }
    }
}