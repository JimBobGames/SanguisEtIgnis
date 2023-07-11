using SanguisEtIgnis.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Starbase : SolarSystemObject
    {
        public Operation StartPoint { get; set; }

        /// <summary>
        /// The fleets based at this base
        /// </summary>
        public SortedObservableCollection<Fleet> Fleets { get { return fleetsList; } }

        public SortedObservableCollection<Fleet> fleetsList = new SortedObservableCollection<Fleet>();
    }
}
