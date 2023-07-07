using SanguisEtIgnis.Core.Data;
//using SanguisEtIgnis.Core.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Network
{
    public static class ListHelper
    {
        ///
        /// Shuffles the specified list into a random order.
        ///
        /// The type of the list items
        /// The list of items.
        /// A randomised list of the items.
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            Random rnd = new Random();
            return source.OrderBy<T, int>((item) => rnd.Next());
        }
    }

    public class SanguisEtIgnisGame : ISanguisEtIgnisGame
    {
        private Dictionary<int, Player> players = new Dictionary<int, Player>();
        private Dictionary<int, Nation> nations = new Dictionary<int, Nation>();
        private Dictionary<int, SolarSystem> solarSystems = new Dictionary<int, SolarSystem>();
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
        public Dictionary<int, Nation> Nations
        {
            get
            {
                return nations;
            }
        }

        public Dictionary<int, SolarSystem> SolarSystems
        {
            get
            {
                return solarSystems;
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


        internal SolarSystem AddSolarSystem(SolarSystem n)
        {
            solarSystems[n.SolarSystemId] = n;

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

        public IReadOnlyList<Nation> NationsListUnsorted => nations.Values.ToList();
        public IReadOnlyList<Nation> NationsListAlphabetical => new List<Nation>(nations.Values.ToList()).OrderBy(o => o.Name).ToList();
        public IReadOnlyList<Nation> NationsListRandom => new List<Nation>(ListHelper.Randomize(nations.Values.ToList()));
        public Nation GetNation(int id)
        {
            Nations.TryGetValue(id, out Nation value);
            return value;
        }

        public IReadOnlyList<SolarSystem> SolarSystemsListUnsorted => solarSystems.Values.ToList();
        public IReadOnlyList<SolarSystem> SolarSystemsListAlphabetical => new List<SolarSystem>(solarSystems.Values.ToList()).OrderBy(o => o.Name).ToList();
        public IReadOnlyList<SolarSystem> SolarSystemsListRandom => new List<SolarSystem>(ListHelper.Randomize(solarSystems.Values.ToList()));
        public SolarSystem GetSolarSystem(int id)
        {
            SolarSystems.TryGetValue(id, out SolarSystem value);
            return value;
        }
    }
}
