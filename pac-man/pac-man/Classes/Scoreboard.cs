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
        public int score;
        private Label display;

        public Scoreboard (Label display)
        {
            this.score = 0;
            this.display = display;
        }

        public void IncrementScore ()
        {
            this.score += 1;
            this.display.Text = score.ToString();
        }
        public void ResetScore ()
        {
            this.score = 0;
            this.display.Text = score.ToString();
        }
    }
}
