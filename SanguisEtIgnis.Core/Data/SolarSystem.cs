using SanguisEtIgnis.Core.Data;
using SanguisEtIgnis.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public enum StarType { BlueGiant, White, Yellow, Orange, Red, RedDwarf, WhiteDwarf, RedGiant }

    public class SolarSystem : NamedObject
    {
        public int SolarSystemId { get; set; }
        public Point Location { get; set; }

        public StarType StarType { get; set; }

        /// <summary>
        /// The survey points for a nation
        /// </summary>
        private Dictionary<int, int> surveyPointsByNation = new Dictionary<int, int>();

        public SortedObservableCollection<SolarSystemObject> SolarSystemObjects { get { return solarSystemObjectList; } }

        public SortedObservableCollection<SolarSystemObject> solarSystemObjectList = new SortedObservableCollection<SolarSystemObject>();
        public bool IsExplored(Nation n)
        {
            // has this been surveyed ?
            if (surveyPointsByNation.ContainsKey(n.NationId))
            {
                // get the survey points
                int surveyPoints = surveyPointsByNation[n.NationId];

                // has this met the criteria
                if (surveyPoints >= SolarSystem.GetSurveyPointsRequired())
                {
                    return true;
                }
            }
            return false;
        }

        private static int GetSurveyPointsRequired()
        {
            // by default 100 - could vary in future by type of sun/ binary system etc
            return 100;
        }
    }
}
