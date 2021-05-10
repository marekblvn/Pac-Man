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
        public int direction;
        int speed;
        public bool started;
        public int lastmove;
        Random Rand = new Random();
        public Ghost(int x, int y)
        {
            this.Size = new Size(16, 16);
            this.Location = new Point(16 * x, 16 * y);
            this.BackColor = Color.Red;
            this.direction = 1;
            this.lastmove = 2;
            this.speed = 2;
        }

        public async void Start (int timetowait)
        {
            await Task.Delay(timetowait);
        }
        public void UpdateGhostPosition ()
        {
            switch (this.direction)
            {
                case 1:
                    this.Left += this.speed;
                    break;
                case 2:
                    this.Top -= this.speed;
                    break;
                case 3:
                    this.Left -= this.speed;
                    break;
                case 4:
                    this.Top += this.speed;
                    break;
                default:
                    break;
            }
        }
        public void RandomMovement (TurningPoint point)
        {
            int rnum = Rand.Next(100);

            switch (this.direction)
            {
                case 1:
                    if (rnum <= 33 && point.up)
                        this.direction = 2;
                    else if (rnum > 33 && rnum <= 66 && point.down)
                        this.direction = 4;
                    else if (rnum > 66 && rnum <= 99 && point.right)
                        this.direction = 1;
                    else
                    {
                        if (point.right)
                            this.direction = 1;
                        else if (point.up)
                            this.direction = 2;
                        else if (point.left)
                            this.direction = 3;
                        else if (point.down)
                            this.direction = 4;
                    }
                    break;
                case 2:
                    if (rnum <= 33 && point.right)
                        this.direction = 1;
                    else if (rnum > 33 && rnum <= 66 && point.left)
                        this.direction = 3;
                    else if (rnum > 66 && rnum <= 99 && point.up)
                        this.direction = 2;
                    else
                    {
                        if (point.up)
                            this.direction = 2;
                        else if (point.left)
                            this.direction = 3;
                        else if (point.down)
                            this.direction = 4;
                        else if (point.right)
                            this.direction = 1;
                    }
                    break;
                case 3:
                    if (rnum <= 33 && point.down)
                        this.direction = 4;
                    else if (rnum > 33 && rnum <= 66 && point.up)
                        this.direction = 2;
                    else if (rnum > 66 && rnum <= 99 && point.left)
                        this.direction = 3;
                    else
                    {
                        if (point.left)
                            this.direction = 3;
                        else if (point.down)
                            this.direction = 4;
                        else if (point.right)
                            this.direction = 1;
                        else if (point.up)
                            this.direction = 2;
                    }
                    break;
                case 4:
                    if (rnum <= 33 && point.left)
                        this.direction = 3;
                    else if (rnum > 33 && rnum <= 66 && point.right)
                        this.direction = 1;
                    else if (rnum > 66 && rnum <= 99 && point.down)
                        this.direction = 4;
                    else
                    {
                        if (point.down)
                            this.direction = 4;
                        else if (point.right)
                            this.direction = 1;
                        else if (point.up)
                            this.direction = 2;
                        else if (point.left)
                            this.direction = 3;
                    }
                    break;
            }
        }
    }
}
