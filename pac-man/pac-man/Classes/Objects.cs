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
        public Wall (int x, int y, int tag)
        {
            this.Tag = tag;
            this.Visible = true;
            this.Size = new Size(16, 16);
            this.Location = new Point(16 * x, 16 * y);

            switch (tag)
            {
                case 40:
                    this.Image = Properties.Resources.wall_40;
                    break;
                case 41:
                    this.Image = Properties.Resources.wall_41;
                    break;
                case 42:
                    this.Image = Properties.Resources.wall_42;
                    break;
                case 43:
                    this.Image = Properties.Resources.wall_43;
                    break;
                case 44:
                    this.Image = Properties.Resources.wall_44;
                    break;
                case 45:
                    this.Image = Properties.Resources.wall_45;
                    break;
                case 50:
                    this.Image = Properties.Resources.wall_50;
                    break;
                case 51:
                    this.Image = Properties.Resources.wall_51;
                    break;
                case 52:
                    this.Image = Properties.Resources.wall_52;
                    break;
                case 53:
                    this.Image = Properties.Resources.wall_53;
                    break;
                case 60:
                    this.Image = Properties.Resources.wall_60;
                    break;
                case 61:
                    this.Image = Properties.Resources.wall_61;
                    break;
                case 62:
                    this.Image = Properties.Resources.wall_62;
                    break;
                case 63:
                    this.Image = Properties.Resources.wall_63;
                    break;
                case 70:
                    this.Image = Properties.Resources.wall_70;
                    break;
                case 71:
                    this.Image = Properties.Resources.wall_71;
                    break;
                case 72:
                    this.Image = Properties.Resources.wall_72;
                    break;
                case 73:
                    this.Image = Properties.Resources.wall_73;
                    break;
                case 80:
                    this.Image = Properties.Resources.wall_80;
                    break;
                case 81:
                    this.Image = Properties.Resources.wall_81;
                    break;
                case 90:
                    this.Image = Properties.Resources.wall_90;
                    break;
                case 91:
                    this.Image = Properties.Resources.wall_91;
                    break;
                case 92:
                    this.Image = Properties.Resources.wall_92;
                    break;
                case 93:
                    this.Image = Properties.Resources.wall_93;
                    break;
            }
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
            this.Image = Properties.Resources.coin;
            this.Visible = true;
            this.Size = new Size(4, 4);
            this.Location = new Point(16 * x + 6, 16 * y + 6);
        }
    }
    //TODO: Implement fruit
    internal class Fruit : PictureBox // 0 -- Banana; 1 -- Strawberry; 2 -- Cherry
    {
        Random Rand = new Random();
        public Fruit (Point location)
        {
            this.Visible = true;
            this.Size = new Size(15, 15);
            this.Location = new Point(location.X - 5, location.Y - 5);
            int rnum = Rand.Next(9);
            if (rnum <= 2)
            {
                this.Image = Properties.Resources.banana;
                this.Tag = 0;
            }
            else if (rnum > 2 && rnum <= 5)
            {
                this.Image = Properties.Resources.strawberry;
                this.Tag = 1;
            }
            else if (rnum > 5 && rnum < 9)
            {
                this.Image = Properties.Resources.cherry;
                this.Tag = 2;
            }
        }
    }
    internal class Powerup : PictureBox
    {
        public Powerup (int x, int y)
        {
            this.Image = Properties.Resources.powerup;
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
