using SanguisEtIgnis.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Engines
{
    public class TurnResolutionEngine : AbstractEngine
    {
        private SurveyAndExplorationEngine SurveyAndExplorationEngine { get; set; }

        public void ResolveTurn()
        {
            // ensure the helper engine classes are availaibe
            SurveyAndExplorationEngine = new SurveyAndExplorationEngine() { Game = Game };

            // update the turn number
            Game.TurnNumber = Game.TurnNumber++;
            Game.GameEventLog.AddEvent(Game.TurnNumber, GameEventCategory.DebugEvent, GameEventType.TurnUpdateEvent, Game.TurnNumber);

            foreach (Nation n in Game.NationsListRandom)
            {
                ResolveTurnForRace(n);
            }
        }
        public void ResolveTurnForRace(Nation n)
        {
            // resolving turn for race
            Game.GameEventLog.AddEvent(Game.TurnNumber, GameEventCategory.DebugEvent, GameEventType.RacialUpdateEvent, n.NationId);

            // Strategic update - changing priorities
            IReadOnlyList<StratgicPriorities> stratgicPriorities = UpdateStratgicPriorities(Game.TurnNumber, n);

            // handle each budget area going from lowest to highest
            foreach (StratgicPriorities sp in stratgicPriorities)
            {
                switch (sp.BudgetAreas)
                {
                    case BudgetAreas.Defensive: ResolveDefensiveSpending(n, sp); break;
                    case BudgetAreas.Diplomacy: ResolveDiplomaticSpending(n, sp); break;
                    case BudgetAreas.Economic: ResolveEconomicSpending(n, sp); break;
                    case BudgetAreas.Offensive: ResolveOffensiveSpending(n, sp); break;
                    case BudgetAreas.ResearchAndDevelopment: ResolveResearchAndDevelopmentSpending(n, sp); break;
                    case BudgetAreas.Reserve: ResolveReserveSpending(n, sp); break;
                    case BudgetAreas.SurveyAndExploration: SurveyAndExplorationEngine.ResolveSurveyAndExplorationSpending(n, sp); break;
                }
            }


            // Budget allocation

            // Pay fixed expenses

            // Diplomacy

            // Movement

            // Combat

            // Survey and exploration

            // Defensive (starbases, antipiracy)

            // Offensive (planning offensive missions)

            // Economic spending


        }

        internal void ResolveDefensiveSpending(Nation n, StratgicPriorities sp)
        {
        }

        internal void ResolveDiplomaticSpending(Nation n, StratgicPriorities sp)
        {
        }

        internal void ResolveEconomicSpending(Nation n, StratgicPriorities sp)
        {
        }

        internal void ResolveOffensiveSpending(Nation n, StratgicPriorities sp)
        {
        }

        internal void ResolveResearchAndDevelopmentSpending(Nation n, StratgicPriorities sp)
        {
        }

        internal void ResolveReserveSpending(Nation n, StratgicPriorities sp)
        {
        }



        /// <summary>
        /// Updates the allocation of funds to each area
        /// 
        /// Total must be 100
        /// 
        /// Number between 0 and 100
        /// </summary>
        /// <param name="turnNumber"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private IReadOnlyList<StratgicPriorities> UpdateStratgicPriorities(int turnNumber, Nation n)
        {
            // update the priorities for each budget area if the has been a change,
            // otherwise use existing one
            List<StratgicPriorities> sp = new List<StratgicPriorities>();
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Defensive, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Diplomacy, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Economic, Value = 35 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.ResearchAndDevelopment, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.SurveyAndExploration, Value = 10 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Offensive, Value = 20 });
            sp.Add(new StratgicPriorities() { BudgetAreas = BudgetAreas.Reserve, Value = 5 });

            // sort lowest to highest
            return sp.OrderBy(o => o.Value).ToList();
        }
    }
}

