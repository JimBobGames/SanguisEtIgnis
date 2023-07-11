using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SanguisEtIgnis.Core.Data.Battle;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// Represents an engagement fought at the battalion/regiment level.
    /// 
    /// These will take a short time (in the scale of the battle)
    /// </summary>
    public class Engagement
    {
        public enum EngagementResult { Engaged, AttackerWin, DefenderWins, Draw };

        private List<Battalion> defenders = new List<Battalion>();
        public Battalion? Attacker { get; set; }
        public List<Battalion> Defenders
        {
            get
            {
                return defenders;
            }
        }

        /// <summary>
        /// The distance in yards between the forces
        /// </summary>
        public int Distance { get; set; }

        public bool FirstVolleyFired { get; set; }
        /// <summary>
        /// The distance in yards between the forces
        /// </summary>
        public Weather Weather { get; set; }

        public Terrain Terrain { get; set; }

        public int Duration { get; set; }
    }

}
