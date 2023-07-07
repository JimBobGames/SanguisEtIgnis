using SanguisEtIgnis.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Network
{
    public class TinyGameCreator : GameCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public static void CreateGame(SanguisEtIgnisGame g)
        {
            // create the local player
            g.AddPlayer(new Player() { PlayerId = 1, Name = "Player" });

            // create the nations
            g.AddNation(new Nation() { NationId = NATION_USA, Name = "Union" });
            g.AddNation(new Nation() { NationId = NATION_CSA, Name = "Conferderacy" });

            // create the solar systems
            g.AddSolarSystem(new SolarSystem() { SolarSystemId = NATION_USA, Name = "Sol" });
            g.AddSolarSystem(new SolarSystem() { SolarSystemId = NATION_CSA, Name = "Orion" });

        }
    }
}
