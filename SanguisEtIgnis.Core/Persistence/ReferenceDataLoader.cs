using SanguisEtIgnis.Core.Data;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SICD = SanguisEtIgnis.Core.Data;

namespace SanguisEtIgnis.Core.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public class ReferenceDataLoader
    {
        public static void LoadReferenceData(SanguisEtIgnis.Core.Network.SanguisEtIgnisGame game)
        {
            // move this to seperate JSON files later

            // loads hulls
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_ESCORT, Name = "Escort", HullSize = HullSize.Escort, DesignSize = DesignSize.Escort, MinSize = 8, MaxSize = 12 });
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_CORVETTE, Name = "Escort", HullSize = HullSize.Corvette, DesignSize = DesignSize.Escort, MinSize = 13, MaxSize = 16 });
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_FRIGATE, Name = "Escort", HullSize = HullSize.Frigate, DesignSize = DesignSize.Escort, MinSize = 17, MaxSize = 20 });
            game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_DESTROYER, Name = "Escort", HullSize = HullSize.Destroyer, DesignSize = DesignSize.Escort, MinSize = 21, MaxSize = 30 });
            //game.AddHull(new Hull() { HullId = GameStandardIds.ID_HULL_LIGHT_CRUISER, Name = "Escort", HullSize = HullSize.LightCruiser, DesignSize = DesignSize.Escort });



            // load engines
            /// the module size represents an engine room so essentially the number of engine rooms per ship
            ///
            game.AddEngine(new Engine() { ModuleId = GameStandardIds.ID_NO_ENGINE, Name = "No Engine", ModuleSize = ModuleSize.NoModule });
            game.AddEngine(new Engine() { ModuleId = GameStandardIds.ID_ENGINE_BASIC_MILITARY_SMALL, Name = "Small Basic Military Engine", ModuleSize = ModuleSize.Small });
            game.AddEngine(new Engine() { ModuleId = GameStandardIds.ID_ENGINE_BASIC_CIVILLIAN_SMALL, Name = "Small Basic Military Engine", ModuleSize = ModuleSize.Medium });

            // load weapons


            // load defences
            game.AddShield(new Shield() { ModuleId = GameStandardIds.ID_NO_SHIELD, Name = "No Shields", ModuleSize = ModuleSize.NoModule, Cost = 0 });
            game.AddShield(new Shield() { ModuleId = GameStandardIds.ID_BASIC_SHIELD, Name = "Basic Shields", ModuleSize = ModuleSize.NoModule, Cost = 20 });

            game.AddArmour(new Armour() { ModuleId = GameStandardIds.ID_NO_ARMOUR, Name = "No Armor", ModuleSize = ModuleSize.NoModule, Cost = 0 });
            game.AddArmour(new Armour() { ModuleId = GameStandardIds.ID_BASIC_ARMOUR, Name = "Basic Armor", ModuleSize = ModuleSize.NoModule, Cost = 10 });

        }

        private static void CreateDesigns(SanguisEtIgnis.Core.Network.SanguisEtIgnisGame game)
        {
            Hull corvetteHull = game.GetHull(GameStandardIds.ID_HULL_CORVETTE);
            Hull escortHull = game.GetHull(GameStandardIds.ID_HULL_ESCORT);
            Hull destroyerHull = game.GetHull(GameStandardIds.ID_HULL_DESTROYER);
            Hull frigateHull = game.GetHull(GameStandardIds.ID_HULL_FRIGATE);
            Engine militaryEngine = game.GetEngine(GameStandardIds.ID_ENGINE_BASIC_MILITARY_SMALL);
            Shield basicShield = game.GetShield(GameStandardIds.ID_BASIC_SHIELD);
            Armour basicArmour = game.GetArmour(GameStandardIds.ID_BASIC_ARMOUR);

            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_CORVETTE_DESIGNID, "Terran Corvette", corvetteHull, militaryEngine, 1));
            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_ESCORT_DESIGNID, "Terran Escort", escortHull, militaryEngine, 1));
            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_FRIGATE_DESIGNID, "Terran Frigate", frigateHull, militaryEngine, 1));
            game.AddDesign(CreateDesign(GameStandardIds.TERRAN_DESTROYER_DESIGNID, "Terran Destoyer", destroyerHull, militaryEngine, 1));
        }

        private static Design CreateDesign(int id, string name, Hull h, Engine e, int numEngines)
        {
            Design d = new Design();
            d.Name = name;
            d.DesignId = id;
            d.Hull = h;
            d.Engine = e;
            d.NumberOfEngines = numEngines;


            return d;

        }
    }
}