using SanguisEtIgnis.Core.Data;
//using SanguisEtIgnis.Core.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Network
{
    public class SanguisEtIgnisGame : ISanguisEtIgnisGame
    {
        private Dictionary<int, Player> players = new Dictionary<int, Player>();
        private Dictionary<int, Nation> nations = new Dictionary<int, Nation>();
        private Dictionary<int, Army> armies = new Dictionary<int, Army>();
        private Dictionary<int, Battalion> battalions = new Dictionary<int, Battalion>();

        public Battalion? SelectedBattalion { get; set; }
        public Brigade? SelectedBrigade { get; set; }

        /// <summary>
        /// Runs in background thread CANNOT change visuals
        /// </summary>
        public void UpdateGameStates(UIChanges changes, double deltaTimeMS)
        {
            // update the regiments if required
            foreach (Army a in Armies.Values)
            {
                foreach (Corps c in a.Corps)
                {
                    foreach (Division d in c.Divisions)
                    {

                        foreach (Brigade b in d.Brigades)
                        {
                            UpdatePosition(b, changes, deltaTimeMS);

                            foreach (Battalion bn in b.Battalions)
                            {
                                bn.FacingInDegrees += 1;
                            }
                        }
                    }

                }
            }

            //// Hack 1 regiment changes
            changes.BattalionIds.Add(1);
        }

        public void UpdatePosition(Brigade b, UIChanges changes, double deltaTimeMS)
        {
        }

        public Dictionary<int, Army> Armies
        {
            get
            {
                return armies;
            }
        }

        internal Player AddPlayer(Player p)
        {
            players[p.PlayerId] = p;

            return p;
        }

        internal Nation AddNation(Nation n)
        {
            nations[n.NationId] = n;

            return n;
        }

        internal Army AddArmy(Army a)
        {
            armies[a.ArmyId] = a;

            return a;
        }

        internal Battalion AddBattalion(Brigade b, Battalion r)
        {
            b.AddBattalion(r);
            battalions[r.BattalionId] = r;
            return r;
        }

        public Battalion GetBattalion(int battalionId)
        {
            Battalion r;
            battalions.TryGetValue(battalionId, out r);
            return r;
        }

    }
}
