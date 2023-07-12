using Microsoft.VisualStudio.TestTools.UnitTesting;
using SanguisEtIgnis.Core.Engines;
using SanguisEtIgnis.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Test
{
    [TestClass]
    public class TurnResolutionTest
    {
        [TestMethod]
        public void TestSingleTurnResolution()
        {
            SanguisEtIgnisGame game = TinyGameCreator.CreateGame();
            TurnResolutionEngine turnEngine = new TurnResolutionEngine
            {
                Game = game
            };

            // run one turn 
            turnEngine.ResolveTurn();

            game.GameEventLog.DisplayEvents(game);
        }
    }
}