using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public enum OperationType
    {
        NoOperation = 0,
        Sweep = 1,
        Raid = 2,
        Invasion = 3,
        Construction = 4,// build expand starbase
        Rebase = 5, // move fleet to new base

    }
    /// <summary>
    /// A military operation to attack the enemy
    /// 
    /// Can be carried out by a task force OR a fleet 
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// The launching starbase
        /// </summary>
        public Starbase Starbase { get; set; }

        /// <summary>
        /// The fleet id
        /// </summary>
        public Fleet Fleet { get; set; }

        /// <summary>
        /// The task force id
        /// </summary>
        public TaskForce TaskForce { get; set; }

        /// <summary>
        /// The target object
        /// </summary>
        public SolarSystemObject TargetSolarSystemObject { get; set; }
    }
}