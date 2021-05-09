using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pac_Man
{
    internal class Ghost : PictureBox
    {
        public Ghost(int x, int y)
        {
            this.Size = new Size(16, 16);
            this.Location = new Point(16 * x, 16 * y);
            this.BackColor = Color.Red;
        }

        public async void Start (int timetowait)
        {
            await Task.Delay(timetowait);
            this.Location = new Point(this.Location.X, this.Location.Y - 48);
        }
        private void InitialMove ()
        {
            
        }
    }
}
