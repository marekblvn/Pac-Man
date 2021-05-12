using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Man
{
    internal class Scoreboard
    {
        int score;
        private Label display;
        public int totalcoins;
        int allcoins;

        public Scoreboard (Label display)
        {
            this.score = 0;
            this.totalcoins = 0;
            this.display = display;
        }
        public void IncrementScore ()
        {
            this.score += 1;
            this.totalcoins -= 1;
            if (this.score > 99999)
                this.display.Text = "∞";
            else this.display.Text = score.ToString();
        }
        public void ResetScore ()
        {
            this.score = 0;
            this.display.Text = score.ToString();
        }
        public void AddCoin ()
        {
            this.totalcoins += 1;
            this.allcoins += 1;
        }
        public bool AllCoinsCollected ()
        {
            if (this.totalcoins == 0)
            {
                this.totalcoins = allcoins;
                return true;
            }
            return false;
        }
    }
}
