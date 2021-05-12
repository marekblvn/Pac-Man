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
        public int direction, backupdirection;
        public int newdirection = 0;
        public int speed;
        public int lives;
        public Player (int x, int y)
        {
            this.Visible = true;
            this.Tag = 0; // 0 -- normal; 1 -- hit by ghost and recovering; 2 -- powered up
            this.Image = Properties.Resources.pacman1;
            this.Size = new Size(16, 16);
            this.Location = new Point(16 * x, 16 * y);
            this.direction = 1;
            this.speed = 4;
            this.lives = 3;
        }
        public void UpdatePlayerPosition ()
        {
            switch (direction)
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
            }
        }
        public void UpdateSprite ()
        {
            switch (direction)
            {
                case 1:
                    this.Image = Properties.Resources.pacman1;
                    break;
                case 2:
                    this.Image = Properties.Resources.pacman2;
                    break;
                case 3:
                    this.Image = Properties.Resources.pacman3;
                    break;
                case 4:
                    this.Image = Properties.Resources.pacman4;
                    break;
            }
        }
        public async void ResetNewdirection ()
        {
            await Task.Delay(200);
            this.newdirection = 0;
        }
    }
}
