using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    public class TaskForce : NamedObject
    {
        public int TaskForceId { get; set; }
        /// <summary>
        /// What fleet this ship belongs to
        /// </summary>
        public Fleet? Fleet { get; set; }

        /// <summary>
        /// The divisions in this task force
        /// /// </summary>
        public ObservableCollection<Squadron> Squadrons { get { return squadronList; } }

        public ObservableCollection<Squadron> squadronList = new ObservableCollection<Squadron>();
    }
}
