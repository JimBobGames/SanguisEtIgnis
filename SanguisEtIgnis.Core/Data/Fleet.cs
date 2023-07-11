using SanguisEtIgnis.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public enum FleetAllocation
    {
        Unallocated = 0,
        Survey,
        Defence,
        Offence,
        Trade
    }

    public class Fleet : NamedObject
    {
        private SortedObservableCollection<TaskForce> taskForcesList = new SortedObservableCollection<TaskForce>();

        /// <summary>
        /// The task forces in this division
        /// /// </summary>
        public SortedObservableCollection<TaskForce> TaskForces { get { return taskForcesList; } }

        public int FleetId { get; set; }

        public Starbase? HomeBase { get; set; }
        public Nation? Nation { get; set; }

        public FleetAllocation FleetAllocation { get; set; }
    }



}