using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Man
{
    public partial class Game : Form
    {
        Board board = new Board();
        Scoreboard scoreboard;
        Player player;
        public Game()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard ()
        {
            for (int y = 0; y < board.height; y++)
            {
                for (int x = 0; x < board.width; x++)
                {
                    switch (board.layout[y, x])
                    {
                        case 01:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            break;
                        case 02:
                            BoardPanel.Controls.Add(new Powerup(x, y));
                            break;
                        case 03:
                            player = new Player(x, y);
                            BoardPanel.Controls.Add(player);
                            break;
                        case 10:
                            BoardPanel.Controls.Add(new Wall(x, y));
                            break;
                        case 11:
                            BoardPanel.Controls.Add(new Door(x, y));
                            break;
                        case 12:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, false, false));
                            break;
                        case 14:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, false, false, true));
                            break;
                        case 23:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, false, true, true, false));
                            break;
                        case 34:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, false, false, true, true));
                            break;
                        case 123:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, true, false));
                            break;
                        case 124:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, false, true));
                            break;
                        case 134:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, false, true, true));
                            break;
                        case 234:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, false, true, true, true));
                            break;
                        case 1234:
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, true, true));
                            break;
                    }
                }
            }

            scoreboard = new Scoreboard(Score);
        }
        private void PlayerEvents ()
        {
            foreach (PictureBox obj in BoardPanel.Controls)
            {
                switch (obj)
                {
                    case TurningPoint:
                        TurningPoint point = obj as TurningPoint;
                        if (player.Location == point.Location)
                        {
                            switch (player.newdirection)
                            {
                                case 0:
                                    switch (player.direction)
                                    {
                                        case 1:
                                            if (!point.right)
                                                player.direction = 0;
                                            break;
                                        case 2:
                                            if (!point.up)
                                                player.direction = 0;
                                            break;
                                        case 3:
                                            if (!point.left)
                                                player.direction = 0;
                                            break;
                                        case 4:
                                            if (!point.down)
                                                player.direction = 0;
                                            break;
                                    }
                                    break;
                                case 1:
                                    if (point.right)
                                    {
                                        player.direction = player.newdirection;
                                        player.newdirection = 0;
                                    }
                                    break;
                                case 2:
                                    if (point.up)
                                    {
                                        player.direction = player.newdirection;
                                        player.newdirection = 0;
                                    }
                                    break;
                                case 3:
                                    if (point.left)
                                    {
                                        player.direction = player.newdirection;
                                        player.newdirection = 0;
                                    }
                                    break;
                                case 4:
                                    if (point.down)
                                    {
                                        player.direction = player.newdirection;
                                        player.newdirection = 0;
                                    }
                                    break;
                            }
                        }
                        break;

                    case Wall:
                        if (player.Bounds.IntersectsWith(obj.Bounds))
                        {
                            if (player.direction == 1 && obj.Left < player.Left + 16)
                            {
                                player.Left = obj.Left - 16;
                                player.newdirection = player.direction;
                                player.direction = player.backupdirection;
                            }
                            else if (player.direction == 2 && player.Top < obj.Top + 16)
                            {
                                player.Top = obj.Top + 16;
                                player.newdirection = player.direction;
                                player.direction = player.backupdirection;
                            }
                            else if (player.direction == 3 && obj.Left > player.Left - 16)
                            {
                                player.Left = obj.Left + 16;
                                player.newdirection = player.direction;
                                player.direction = player.backupdirection;
                            }
                            else if (player.direction == 4 && player.Top > obj.Top - 16)
                            {
                                player.Top = obj.Top - 16;
                                player.newdirection = player.direction;
                                player.direction = player.backupdirection;
                            }
                        }
                        break;

                    case Coin:
                        if (player.Bounds.IntersectsWith(obj.Bounds) && obj.Visible)
                        {
                            obj.Visible = false;
                            scoreboard.IncrementScore();
                        }
                        break;

                    case Powerup:
                        break;
                }
            }

            // Out of bounds movement
            if (player.Left < -8)
            {
                player.Left = 440;
            }
            else if (player.Left + 8 > 448)
            {
                player.Left = -8;
            }
        }
        private void Key_Down(object sender, KeyEventArgs e)
        {
            player.backupdirection = player.direction;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    player.direction = 1;
                    break;
                case Keys.Up:
                    player.direction = 2;
                    break;
                case Keys.Left:
                    player.direction = 3;
                    break;
                case Keys.Down:
                    player.direction = 4;
                    break;
            }
            player.speed = 4;
        }
        private void Key_Up(object sender, KeyEventArgs e)
        {

        }
        private void MainGameTick(object sender, EventArgs e)
        {
            player.UpdatePlayerDisplay();
            PlayerEvents();
        }
    }
}
