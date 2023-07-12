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
        private readonly GameEventLog eventLog = new GameEventLog();

        public int TurnNumber { get; set; }

        public Player? Player { get; set; }

        /// <summary>
        /// The galactic map
        /// </summary>
        private GalacticMap map = null;

        private Dictionary<int, Player> players = new Dictionary<int, Player>();
        private Dictionary<int, Nation> nations = new Dictionary<int, Nation>();
        private Dictionary<int, SolarSystem> solarSystems = new Dictionary<int, SolarSystem>();
        private Dictionary<int, Army> armies = new Dictionary<int, Army>();
        private Dictionary<int, Battalion> battalions = new Dictionary<int, Battalion>();

        /// <summary>
        /// The store of fleets
        /// </summary>
        private readonly Dictionary<int, Fleet> fleets = new Dictionary<int, Fleet>();

        /// <summary>
        /// The store of task forces
        /// </summary>
        private readonly Dictionary<int, TaskForce> taskForces = new Dictionary<int, TaskForce>();

        /// <summary>
        /// The store of hulls
        /// </summary>
        private readonly Dictionary<int, Hull> hulls = new Dictionary<int, Hull>();

        public Battalion? SelectedBattalion { get; set; }
        public Brigade? SelectedBrigade { get; set; }
        public GameEventLog GameEventLog
        {
            get
            {
                return eventLog;
            }
        }

        public GalacticMap GalacticMap
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }

        public IReadOnlyList<Fleet> FleetListUnsorted => fleets.Values.ToList();
        public Dictionary<int, Fleet> Fleets
        {
            get
            {
                return fleets;
            }
        }

        public Dictionary<int, TaskForce> TaskForces
        {
            get
            {
                return taskForces;
            }
        }









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

        /// <summary>
        /// Get a list of task forces, typically one of the fleet id OR the task force id will be 0 (invalid)
        /// </summary>
        /// <param name="fleetId"></param>
        /// <param name="taskForceId"></param>
        /// <returns></returns>
        public List<TaskForce> GetTaskForceList(Fleet fleet, TaskForce taskForce)
        {
            List<TaskForce> taskForces = new List<TaskForce>();

            if (fleet != null)
            {
                IEnumerable<TaskForce> l = fleet.TaskForces;
                foreach (TaskForce tf in l)
                {
                    taskForces.Add(tf);
                }
            }

            if (taskForce != null)
            {
                taskForces.Add(taskForce);
            }
            return taskForces;
        }

        public Fleet GetFleet(int id)
        {
            Fleets.TryGetValue(id, out Fleet value);
            return value;
        }

        public Fleet AddFleet(Fleet fleet)
        {
            if (fleet != null && fleet.Nation != null || fleet.HomeBase != null)
            {
                fleets[fleet.FleetId] = fleet;
                fleet.Nation.Fleets.Add(fleet);
                fleet.HomeBase.Fleets.Add(fleet);
            }

            return fleet;
        }

        public TaskForce AddTaskForce(TaskForce taskForce)
        {
            if (taskForce != null && taskForce.Fleet != null)
            {
                taskForces[taskForce.TaskForceId] = taskForce;
                taskForce.Fleet.TaskForces.Add(taskForce);
            }

            return taskForce;
        }

        public SolarSystem AddSolarSystem(SolarSystem solarSystem)
        {
            if (solarSystem != null)
            {
                map.SolarSystems[solarSystem.SolarSystemId] = solarSystem;
            }

            return solarSystem;
        }

        public SolarSystemObject AddSolarSystemObject(SolarSystemObject obj)
        {
            if (obj != null || obj.SolarSystem != null)
            {
                map.SolarSystemObjects[obj.SolarSystemObjectId] = obj;
                obj.SolarSystem.SolarSystemObjects.Add(obj);
            }

            return obj;
        }

        public Dictionary<int, Hull> Hulls
        {
            get
            {
                return hulls;
            }
        }

        public IReadOnlyList<Hull> HullsListUnsorted => hulls.Values.ToList();
        public IReadOnlyList<Hull> HullsListAlphabetical => new List<Hull>(hulls.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Hull GetHull(int id)
        {
            Hulls.TryGetValue(id, out Hull value);
            return value;
        }

        public IReadOnlyList<Engine> EnginesListUnsorted => engines.Values.ToList();
        public IReadOnlyList<Engine> EnginesListAlphabetical => new List<Engine>(engines.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Engine GetEngine(int id)
        {
            Engines.TryGetValue(id, out Engine value);
            return value;
        }

        public IReadOnlyList<Shield> ShieldsListUnsorted => shields.Values.ToList();
        public IReadOnlyList<Shield> ShieldsListAlphabetical => new List<Shield>(shields.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Shield GetShield(int id)
        {
            Shields.TryGetValue(id, out Shield value);
            return value;
        }

        public IReadOnlyList<Armour> ArmourListUnsorted => armour.Values.ToList();
        public IReadOnlyList<Armour> ArmourListAlphabetical => new List<Armour>(armour.Values.ToList()).OrderBy(o => o.Name).ToList();
        public Armour GetArmour(int id)
        {
            Armour.TryGetValue(id, out Armour value);
            return value;
        }

        /// <summary>
        /// The store of engines
        /// </summary>
        private readonly Dictionary<int, Engine> engines = new Dictionary<int, Engine>();

        /// <summary>
        /// The store of shields
        /// </summary>
        private readonly Dictionary<int, Shield> shields = new Dictionary<int, Shield>();

        /// <summary>
        /// The store of armour
        /// </summary>
        private readonly Dictionary<int, Armour> armour = new Dictionary<int, Armour>();

        public Dictionary<int, Engine> Engines
        {
            get
            {
                return engines;
            }
        }
        public Dictionary<int, Shield> Shields
        {
            get
            {
                return shields;
            }
        }
        public Dictionary<int, Armour> Armour
        {
            get
            {
                return armour;
            }
        }

        /// <summary>
        /// The store of ships
        /// </summary>
        private readonly Dictionary<int, Ship> ships = new Dictionary<int, Ship>();

        internal void AddDesign(Design design)
        {
            Designs[design.DesignId] = design;
        }

        internal void AddEngine(Engine engine)
        {
            Engines[engine.ModuleId] = engine;
        }

        /// <summary>
        /// The store of designs
        /// </summary>
        private readonly Dictionary<int, Design> designs = new Dictionary<int, Design>();
        public Dictionary<int, Ship> Ships
        {
            get
            {
                return ships;
            }
        }

        public Dictionary<int, Design> Designs
        {
            get
            {
                return designs;
            }
        }
    }

}
