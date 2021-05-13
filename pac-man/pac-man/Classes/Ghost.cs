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
        public int speed;
        public bool initialmove;
        bool movedright = false;
        Point initlocation;
        Random Rand = new Random();
        public Ghost(int x, int y, char colour)
        {
            this.Size = new Size(16, 16);
            this.initlocation = new Point(16 * x, 16 * y);
            this.Location = this.initlocation;
            this.direction = 0;
            this.speed = 2;
            this.Tag = 0; // 0 -- normal; 1 -- eaten by player; 2 -- running from player
            this.initialmove = false;

            if (colour == 'r')
                this.Image = Properties.Resources.r_ghost2;
            else if (colour == 'o')
                this.Image = Properties.Resources.o_ghost2;
            else if (colour == 'b')
                this.Image = Properties.Resources.b_ghost2;
            else if (colour == 'p')
                this.Image = Properties.Resources.p_ghost2;
        }

        public async void Start (int timetowait)
        {
            this.ResetPosition();
            await Task.Delay(timetowait);
            this.direction = 2;
            this.initialmove = true;
        }
        public void ResetPosition ()
        {
            this.Location = this.initlocation;
            this.direction = 0;
        }
        public void Weakened ()
        {
            switch (this.direction)
            {
                case 1:
                    this.Image = Properties.Resources.weak_ghost1;
                    break;
                case 2:
                    this.Image = Properties.Resources.weak_ghost2;
                    break;
                case 3:
                    this.Image = Properties.Resources.weak_ghost3;
                    break;
                case 4:
                    this.Image = Properties.Resources.weak_ghost4;
                    break;
            }
        }
        public void Dead ()
        {
            switch (this.direction)
            {
                case 1:
                    this.Image = Properties.Resources.dead_ghost_1;
                    break;
                case 2:
                    this.Image = Properties.Resources.dead_ghost_2;
                    break;
                case 3:
                    this.Image = Properties.Resources.dead_ghost_3;
                    break;
                case 4:
                    this.Image = Properties.Resources.dead_ghost_4;
                    break;
            }
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

            if (this.Left < -8)
                this.Left = 440;
            else if (this.Left > 440)
                this.Left = -8;
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

        public void PlayerPositionBasedMovement (Player player, TurningPoint point)
        {
            int rnum = Rand.Next(10);
            switch (point.paths)
            {
                case 2:
                    switch (this.direction)
                    {
                        case 1:
                            if (point.up)
                                this.direction = 2;
                            else if (point.down)
                                this.direction = 4;
                            break;
                        case 2:
                            if (point.right)
                                this.direction = 1;
                            else if (point.left)
                                this.direction = 3;
                            break;
                        case 3:
                            if (point.down)
                                this.direction = 4;
                            else if (point.up)
                                this.direction = 2;
                            break;
                        case 4:
                            if (point.left)
                                this.direction = 3;
                            else if (point.right)
                                this.direction = 1;
                            break;
                    }
                    break;
                case 3:
                    if (!point.right)
                    {
                        if (player.Location.Y < this.Location.Y)
                            this.direction = 2;
                        else if (player.Location.Y > this.Location.Y)
                            this.direction = 4;
                        else
                        {
                            if (rnum <= 4)
                                this.direction = 2;
                            else this.direction = 4;
                        }
                    }
                    else if (!point.left)
                    {
                        if (player.Location.Y < this.Location.Y)
                            this.direction = 2;
                        else if (player.Location.Y > this.Location.Y)
                            this.direction = 4;
                        else
                        {
                            if (rnum <= 4)
                                this.direction = 2;
                            else this.direction = 4;
                        }
                    }
                    else if (!point.up)
                    {
                        if (player.Location.X < this.Location.X)
                            this.direction = 3;
                        else if (player.Location.X > this.Location.X)
                            this.direction = 1;
                        else
                        {
                            if (rnum <= 4)
                                this.direction = 3;
                            else this.direction = 1;
                        }
                    }
                    else if (!point.down)
                    {
                        if (player.Location.X < this.Location.X)
                            this.direction = 3;
                        else if (player.Location.X > this.Location.X)
                            this.direction = 1;
                        else
                        {
                            if (rnum <= 4)
                                this.direction = 3;
                            else this.direction = 1;
                        }
                    }
                    break;
                case 4:
                    if (player.Location.Y < this.Location.Y)
                        this.direction = 2;
                    else if (player.Location.Y > this.Location.Y)
                        this.direction = 4;
                    else if (player.Location.X < this.Location.X)
                        this.direction = 3;
                    else if (player.Location.X > this.Location.X)
                        this.direction = 1;
                    break;
            }
        }

        public void RunningAway (Player player, TurningPoint point)
        {
            switch (point.paths)
            {
                case 2:
                    switch (this.direction)
                    {
                        case 1:
                            if (point.up)
                                this.direction = 2;
                            else if (point.down)
                                this.direction = 4;
                            break;
                        case 2:
                            if (point.right)
                                this.direction = 1;
                            else if (point.left)
                                this.direction = 3;
                            break;
                        case 3:
                            if (point.down)
                                this.direction = 4;
                            else if (point.up)
                                this.direction = 2;
                            break;
                        case 4:
                            if (point.left)
                                this.direction = 3;
                            else if (point.right)
                                this.direction = 1;
                            break;
                    }
                    break;
                case 3:
                    if (!point.right)
                    {
                        if (player.Location.Y < this.Location.Y)
                            this.direction = 4;
                        else if (player.Location.Y > this.Location.Y)
                            this.direction = 2;
                        else
                            this.direction = 3;
                    }
                    else if (!point.left)
                    {
                        if (player.Location.Y < this.Location.Y)
                            this.direction = 4;
                        else if (player.Location.Y > this.Location.Y)
                            this.direction = 2;
                        else
                            this.direction = 1;
                    }
                    else if (!point.up)
                    {
                        if (player.Location.X < this.Location.X)
                            this.direction = 1;
                        else if (player.Location.X > this.Location.X)
                            this.direction = 3;
                        else
                            this.direction = 4;
                    }
                    else if (!point.down)
                    {
                        if (player.Location.X < this.Location.X)
                            this.direction = 1;
                        else if (player.Location.X > this.Location.X)
                            this.direction = 3;
                        else
                            this.direction = 2;
                    }
                    break;
                case 4:
                    if (player.Location.Y < this.Location.Y)
                        this.direction = 4;
                    else if (player.Location.Y > this.Location.Y)
                        this.direction = 2;
                    else if (player.Location.X < this.Location.X)
                        this.direction = 1;
                    else if (player.Location.X > this.Location.X)
                        this.direction = 3;
                    break;
            }
        }
    }
}
