using SanguisEtIgnis.Core.Data;
using SanguisEtIgnis.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanguisEtIgnis.UI
{
    /// <summary>
    /// Class to handle UI updates
    /// </summary>
    public class Controller
    {
        public SanguisEtIgnisGame Game { get; set; }

        public void OnClickBattalion(Battalion b)
        {
            if (b != null)
            {
                // something has been clicked
                Console.WriteLine(b.Name);

            }

            UpdateSelection(b);
        }

        private void UpdateBrigade(Brigade b)
        {
            Game.SelectedBattalion = null;
            Game.SelectedBrigade = b;
        }

        private void UpdateSelection(Battalion b)
        {
            Game.SelectedBattalion = b;
        }
    }
}
