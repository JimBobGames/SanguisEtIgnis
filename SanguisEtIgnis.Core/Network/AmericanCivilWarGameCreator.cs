﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanguisEtIgnis.Core.Data;

namespace SanguisEtIgnis.Core.Network
{
    public class GameCreator
    {
        public const int NATION_UK = 10;
        public const int NATION_FRANCE = 11;
        public const int NATION_RUSSIA = 12;
        public const int NATION_ITALY = 13;
        public const int NATION_GERMANY = 14;
        public const int NATION_AUSTRIA_HUNGARY = 15;
        public const int NATION_BULGARIA = 16;
        public const int NATION_SPAIN = 17;
        public const int NATION_USA = 18;
        public const int NATION_ROMANIA = 19;
        public const int NATION_SERBIA = 20;
        public const int NATION_CSA = 21;

        public const int ARMY_USA_POTOMAC = 1;
    }

    public class AmericanCivilWarGameCreator : GameCreator
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

            // create an army
            Army armyOfThePotomac = g.AddArmy(new Army() { ArmyId = ARMY_USA_POTOMAC, Name = "Army Of The Potomac" });

            Corps firstCorps = armyOfThePotomac.AddCorps(new Corps() { CorpId = 1, Name = "First Corps" });

            Division firstDivision = firstCorps.AddDivision(new Division() { DivisionId = 1, Name = "1st Division" });

            Brigade brigade1 = firstDivision.AddBrigade(new Brigade() { BrigadeId = 1, Name = "Iron Brigade", ShortName = "Iron", MapX = 400, MapY = 400, FacingInDegrees = 0 });

            Battalion r1 = g.AddBattalion(brigade1,
                new Battalion() { BattalionId = 1, Name = "1st New York", ShortName = "1st NY", RegimentFormation = RegimentFormation.Line2, FacingInDegrees = 45, MapX = 100, MapY = 100 });
            Battalion r2 = g.AddBattalion(brigade1,
                new Battalion() { BattalionId = 1, Name = "2nd New York", ShortName = "2nd NY", RegimentFormation = RegimentFormation.Line2, FacingInDegrees = 90, MapX = 200, MapY = 150 });
            Battalion r3 = g.AddBattalion(brigade1,
                new Battalion() { BattalionId = 1, Name = "3rd New York", ShortName = "3rd NY", RegimentFormation = RegimentFormation.Line2, FacingInDegrees = 120, MapX = 300, MapY = 200 });
            Battalion r4 = g.AddBattalion(brigade1,
                new Battalion() { BattalionId = 1, Name = "4th New York", ShortName = "4th NY", RegimentFormation = RegimentFormation.Line2, FacingInDegrees = 270, MapX = 400, MapY = 230 });


        }
    }

}
