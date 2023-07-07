using SanguisEtIgnis.Core.Data;
using SanguisEtIgnis.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class SolarSystem : NamedObject
    {
        public int SolarSystemId { get; set; }

        /// <summary>
        /// The survey points for a nation
        /// </summary>
        private Dictionary<int, int> surveyPointsByNation = new Dictionary<int, int>();

        public SortedObservableCollection<SolarSystemObject> SolarSystemObjects { get { return solarSystemObjectList; } }

        public SortedObservableCollection<SolarSystemObject> solarSystemObjectList = new SortedObservableCollection<SolarSystemObject>();
    }
}
