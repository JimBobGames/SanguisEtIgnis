using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// What is the role of this divsion? (aka squardron / flotilla)
    /// </summary>
    public enum SquadronRole
    {
        LineOfBattle,
        Escort,
        Scout,
        Survey,
        Transport,
        Tanker
    }

    public class Squadron : NamedObject
    {
        public int SquadronId { get; set; }
        /// <summary>
        /// What task force this ship belongs to
        /// </summary>
        public TaskForce? TaskForce { get; set; }


        /// <summary>
        /// The ships in this division
        /// /// </summary>
        public ObservableCollection<Ship> Ships { get { return shipsList; } }

        public ObservableCollection<Ship> shipsList = new ObservableCollection<Ship>();

    }
}
