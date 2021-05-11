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
        bool movedright = false;
        Random Rand = new Random();
        public Ghost(int x, int y, char colour)
        {
            this.Size = new Size(16, 16);
            this.Location = new Point(16 * x, 16 * y);
            this.direction = 1;
            this.speed = 4;

            if (colour == 'r')
                this.BackColor = Color.Red;
            else if (colour == 'g')
                this.BackColor = Color.Green;
            else if (colour == 'b')
                this.BackColor = Color.Blue;
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
                    switch (point.paths)
                    {
                        case 2:
                            if (point.up)
                                this.direction = 2;
                            else if (point.down)
                                this.direction = 4;
                            break;
                        case 3:
                            if (!point.right)
                            {
                                if (rnum <= 49)
                                    this.direction = 2;
                                else if (rnum > 49)
                                    this.direction = 4;
                            }
                            else if (!point.up)
                            {
                                if (rnum <= 49)
                                    this.direction = 4;
                                else if (rnum > 49)
                                    this.direction = 1;
                            }
                            else if (!point.down)
                            {
                                if (rnum <= 49)
                                    this.direction = 2;
                                else if (rnum > 49)
                                    this.direction = 1;
                            }
                            break;
                        case 4:
                            if (rnum <= 33)
                                this.direction = 1;
                            else if (rnum > 33 && rnum <= 66)
                                this.direction = 2;
                            else if (rnum > 66 && rnum <= 99)
                                this.direction = 4;
                            break;
                    }
                    break;
                case 2:
                    switch (point.paths)
                    {
                        case 2:
                            if (point.left)
                                this.direction = 3;
                            else if (point.right)
                                this.direction = 1;
                            break;
                        case 3:
                            if (!point.right)
                            {
                                if (rnum <= 49)
                                    this.direction = 3;
                                else if (rnum > 49)
                                    this.direction = 2;
                            }
                            else if (!point.up)
                            {
                                if (rnum <= 49)
                                    this.direction = 1;
                                else if (rnum > 49)
                                    this.direction = 3;
                            }
                            else if (!point.left)
                            {
                                if (rnum <= 49)
                                    this.direction = 2;
                                else if (rnum > 49)
                                    this.direction = 1;
                            }
                            break;
                        case 4:
                            if (rnum <= 33)
                                this.direction = 1;
                            else if (rnum > 33 && rnum <= 66)
                                this.direction = 2;
                            else if (rnum > 66 && rnum <= 99)
                                this.direction = 3;
                            break;
                    }
                    break;
                case 3:
                    switch (point.paths)
                    {
                        case 2:
                            if (point.up)
                                this.direction = 2;
                            else if (point.down)
                                this.direction = 4;
                            break;
                        case 3:
                            if (!point.left)
                            {
                                if (rnum <= 49)
                                    this.direction = 2;
                                else if (rnum > 49)
                                    this.direction = 4;
                            }
                            else if (!point.up)
                            {
                                if (rnum <= 49)
                                    this.direction = 4;
                                else if (rnum > 49)
                                    this.direction = 3;
                            }
                            else if (!point.down)
                            {
                                if (rnum <= 49)
                                    this.direction = 3;
                                else if (rnum > 49)
                                    this.direction = 2;
                            }
                            break;
                        case 4:
                            if (rnum <= 33)
                                this.direction = 3;
                            else if (rnum > 33 && rnum <= 66)
                                this.direction = 2;
                            else if (rnum > 66 && rnum <= 99)
                                this.direction = 4;
                            break;
                    }
                    break;
                case 4:
                    switch (point.paths)
                    {
                        case 2:
                            if (point.left)
                                this.direction = 3;
                            else if (point.right)
                                this.direction = 1;
                            break;
                        case 3:
                            if (!point.right)
                            {
                                if (rnum <= 49)
                                    this.direction = 3;
                                else if (rnum > 49)
                                    this.direction = 4;
                            }
                            else if (!point.left)
                            {
                                if (rnum <= 49)
                                    this.direction = 4;
                                else if (rnum > 49)
                                    this.direction = 1;
                            }
                            else if (!point.down)
                            {
                                if (rnum <= 49)
                                    this.direction = 1;
                                else if (rnum > 49)
                                    this.direction = 3;
                            }
                            break;
                        case 4:
                            if (rnum <= 33)
                                this.direction = 1;
                            else if (rnum > 33 && rnum <= 66)
                                this.direction = 3;
                            else if (rnum > 66 && rnum <= 99)
                                this.direction = 4;
                            break;
                    }
                    break;
            }
        }

        public void RightLeftMovement (TurningPoint point)
        {
            switch (this.direction)
            {
                case 1:
                    switch (point.paths)
                    {
                        case 2:
                            if (point.down)
                                this.direction = 4;
                            else if (point.up)
                                this.direction = 2;
                            break;
                        case 3:
                            if (point.down && !this.movedright)
                            {
                                this.direction = 4;
                                this.movedright = true;
                            }
                            else if (point.up && this.movedright)
                            {
                                this.direction = 2;
                                this.movedright = false;
                            }
                            else if (point.right)
                                this.direction = 1;
                            break;
                        case 4:
                            this.direction = 1;
                            break;
                    }
                    break;
                case 2:
                    switch (point.paths)
                    {
                        case 2:
                            if (point.right)
                                this.direction = 1;
                            else if (point.left)
                                this.direction = 3;
                            break;
                        case 3:
                            if (point.right && !this.movedright)
                            {
                                this.direction = 1;
                                this.movedright = true;
                            }
                            else if (point.left && this.movedright)
                            {
                                this.direction = 3;
                                this.movedright = false;
                            }
                            else if (point.up)
                                this.direction = 2;
                            break;
                        case 4:
                            this.direction = 2;
                            break;
                    }
                    break;
                case 3:
                    switch (point.paths)
                    {
                        case 2:
                            if (point.up)
                                this.direction = 2;
                            else if (point.down)
                                this.direction = 4;
                            break;
                        case 3:
                            if (point.up && !this.movedright)
                            {
                                this.direction = 2;
                                this.movedright = true;
                            }
                            else if (point.down && this.movedright)
                            {
                                this.direction = 4;
                                this.movedright = false;
                            }
                            else if (point.left)
                                this.direction = 3;
                            break;
                        case 4:
                            this.direction = 3;
                            break;
                    }
                    break;
                case 4:
                    switch (point.paths)
                    {
                        case 2:
                            if (point.left)
                                this.direction = 3;
                            else if (point.right)
                                this.direction = 1;
                            break;
                        case 3:
                            if (point.left && !this.movedright)
                            {
                                this.direction = 3;
                                this.movedright = true;
                            }
                            else if (point.right && this.movedright)
                            {
                                this.direction = 1;
                                this.movedright = false;
                            }
                            else if (point.down)
                                this.direction = 4;
                            break;
                        case 4:
                            this.direction = 4;
                            break;
                    }
                    break;
            }
        }
    }
}
