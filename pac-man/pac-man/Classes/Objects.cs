using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pac_Man
{
    internal class Wall : PictureBox
    {
        public Wall (int x, int y)
        {
            this.BackColor = Color.Blue;
            this.Visible = true;
            this.Size = new Size(16, 16);
            this.Location = new Point(16 * x, 16 * y);
        }
    }
    internal class Door : PictureBox
    {
        public Door (int x, int y)
        {
            this.BackColor = Color.LightBlue;
            this.Visible = true;
            this.Size = new Size(16, 6);
            this.Location = new Point(16 * x, 16 * y);
        }
    }
    internal class Coin : PictureBox
    {
        public Coin (int x, int y)
        {
            this.BackColor = Color.FloralWhite;
            this.Visible = true;
            this.Size = new Size(4, 4);
            this.Location = new Point(16 * x + 6, 16 * y + 6);
        }
    }
    //TODO: Implement fruit
    internal class Fruit : PictureBox
    {

    }
    internal class Powerup : PictureBox
    {
        public Powerup (int x, int y)
        {
            this.BackColor = Color.Yellow;
            this.Visible = true;
            this.Size = new Size(6, 6);
            this.Location = new Point(16 * x + 5, 16 * y + 5);
        }
    }
    internal class TurningPoint : PictureBox
    {
        public bool right, up, left, down;
        public int paths = 0;
        public TurningPoint(int x, int y, bool a, bool b, bool c, bool d)
        {
            this.right = a;
            this.up = b;
            this.left = c;
            this.down = d;
            this.Location = new Point(16 * x, 16 * y);
            this.Size = new Size(16, 16);
            this.Visible = false;
            if (this.right)
                this.paths += 1;
            if (this.up)
                this.paths += 1;
            if (this.left)
                this.paths += 1;
            if (this.down)
                this.paths += 1;
        }
    }
}
