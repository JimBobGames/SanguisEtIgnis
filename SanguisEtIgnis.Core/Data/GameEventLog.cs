using SanguisEtIgnis.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.Core.Data
{
    /// <summary>
    /// Game event log - holding track of decisions made.
    /// 
    /// This list is persistent.
    /// </summary>
    public class GameEventLog
    {
        /// <summary>
        /// Events storage is a list of events for each turn
        /// </summary>
        private readonly Dictionary<int, List<GameEvent>> events = new Dictionary<int, List<GameEvent>>();

        /// <summary>
        /// Get the event list for a turn
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        public List<GameEvent> GetEventsForTurn(int turn)
        {
            if (!events.TryGetValue(turn, out List<GameEvent> eventList))
            {
                // create the event list
                eventList = new List<GameEvent>();
                events[turn] = eventList;
            }
            return eventList;
        }

        public void AddEvent(int turn, GameEvent gameEvent)
        {
            GetEventsForTurn(turn).Add(gameEvent);
        }

        internal void AddEvent(int turn, GameEventCategory eventCategory, GameEventType eventType)
        {
            AddEvent(turn, new GameEvent() { GameEventCategory = eventCategory, GameEventType = eventType });
        }
        internal void AddEvent(int turn, GameEventCategory eventCategory, GameEventType eventType, int param1)
        {
            AddEvent(turn, new GameEvent() { GameEventCategory = eventCategory, GameEventType = eventType, Parameter1 = param1 });
        }
        internal void AddEvent(int turn, GameEventCategory eventCategory, GameEventType eventType, int param1, int param2)
        {
            AddEvent(turn, new GameEvent() { GameEventCategory = eventCategory, GameEventType = eventType, Parameter1 = param1, Parameter2 = param2 });
        }
        internal void AddEvent(int turn, GameEventCategory eventCategory, GameEventType eventType, int param1, int param2, int param3)
        {
            AddEvent(turn, new GameEvent() { GameEventCategory = eventCategory, GameEventType = eventType, Parameter1 = param1, Parameter2 = param2, Parameter3 = param3 });
        }

        public void DisplayEvents(SanguisEtIgnisGame game)
        {
            foreach (int turn in events.Keys)
            {
                List<GameEvent> eventList = GetEventsForTurn(turn);
                foreach (GameEvent e in eventList)
                {
                    DisplayEvent(game, e);
                }
            }
        }

        private void DisplayEvent(SanguisEtIgnisGame game, GameEvent e)
        {
            switch (e.GameEventType)
            {
                case GameEventType.TurnUpdateEvent: Console.WriteLine("Turn Update - {0}", e.Parameter1); break;
                case GameEventType.RacialUpdateEvent: Console.WriteLine(" Race Update - {0}", game.GetNation(e.Parameter1).Name); break;
                case GameEventType.SurveyExplorationUpdateEvent: Console.WriteLine("  Survey Update - {0}, {1}% {2} MCr", game.GetNation(e.Parameter1).Name, e.Parameter2, e.Parameter3); break;
                default: Console.WriteLine(e.GameEventType); break;

            }
        }
    }
}