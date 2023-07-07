using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SanguisEtIgnis.Core.Data
{

    /// <summary>
    /// something in a solar system
    /// </summary>
    public class SolarSystemObject : NamedObject, IComparable<NamedObject>
    {
        public int SolarSystemObjectId { get; set; }

        public SolarSystem? SolarSystem { get; set; }

        /// <summary>
        /// Location in system 
        /// </summary>
        public Point Location { get; set; }


        /// <summary>
        /// The objects in a solar system are sorted as follows
        /// 
        /// Planets
        /// Bases
        /// Warp Lines
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public new int CompareTo(NamedObject other)
        {
            // are the two obects the same type ?
            if (this.GetType().Equals(other.GetType()))
            {
                return Name.CompareTo(other.Name);
            }
            else
            {
                return this.GetType().Name.CompareTo(other.GetType().Name);
            }
        }
    }
}
