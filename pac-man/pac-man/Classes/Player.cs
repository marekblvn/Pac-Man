using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pac_Man
{
    internal class Player : PictureBox
    {
        public int direction;
        int speed;
        public Player (int x, int y)
        {
            this.BackColor = Color.LightGoldenrodYellow;
            this.Image = Pac_Man.Properties.Resources.test;
            this.Visible = true;
            this.Size = new Size(16, 16);
            this.Location = new Point(16 * x, 16 * y);
            this.direction = 0;
            this.speed = 4;
        }

        public void MovePlayer ()
        {
            switch (direction)
            {
                case 1:
                    this.Left -= this.speed;
                    break;
                case 2:
                    this.Top -= this.speed;
                    break;
                case 3:
                    this.Left += this.speed;
                    break;
                case 4:
                    this.Top += this.speed;
                    break;
                default:
                    break;
            }
        }
    }
}
