using SanguisEtIgnis.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class Nation : NamedObject
    {
        public int NationId { get; set; }
        public int Bank { get; set; }
        public int Income { get; set; }

        public StratgicPriorities? StratgicPriorities { get; set; }

        private SortedObservableCollection<Fleet> fleets = new SortedObservableCollection<Fleet>();

        public SortedObservableCollection<Fleet> Fleets
        {
            get
            {
                return fleets;
            }
        }

        private SortedObservableCollection<SolarSystem> knownSolarSystemsList = new SortedObservableCollection<SolarSystem>();

        public SortedObservableCollection<SolarSystem> KnownSolarSystems
        {
            get
            {
                return knownSolarSystemsList;
            }
        }

        private SortedObservableCollection<SolarSystem> unknownSolarSystemsList = new SortedObservableCollection<SolarSystem>();

        public SortedObservableCollection<SolarSystem> UnknownSolarSystemsList
        {
            get
            {
                return unknownSolarSystemsList;
            }
        }
    }
}