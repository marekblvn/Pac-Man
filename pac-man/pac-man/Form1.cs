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
        Player player = new Player(0,0);
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
                    if (board.layout[y, x] == 10)
                        BoardPanel.Controls.Add(new Wall(x, y));
                    else if (board.layout[y, x] == 11)
                        BoardPanel.Controls.Add(new Door(x, y));
                    else if (board.layout[y, x] == 01)
                        BoardPanel.Controls.Add(new Coin(x, y));
                    else if (board.layout[y, x] == 02)
                        BoardPanel.Controls.Add(new Powerup(x, y));
                    else if (board.layout[y, x] == 03)
                    {
                        player.Location = new Point(16 * x, 16 * y);
                        BoardPanel.Controls.Add(player);
                    }
                }
            }
        }
        private void CheckCollision ()
        {
            foreach (PictureBox obj in BoardPanel.Controls)
            {
                if (player.Bounds.IntersectsWith(obj.Bounds))
                {
                    if (obj is Wall || obj is Door)
                    {
                        if ((player.direction == 2) && (player.Top < obj.Top + 16)) // Collision from the top
                        {
                            player.Top = obj.Top + 16;
                            player.direction = 0;
                            return;
                        }
                        else if ((player.direction == 4) && (obj.Top < player.Top + 16)) // Collision from the bottom
                        {
                            player.Top = obj.Top - 16;
                            player.direction = 0;
                            return;

                        }
                        else if ((player.direction == 1) && (obj.Left < player.Left + 16)) // Collision from the right
                        {
                            player.Left = obj.Left + 16;
                            player.direction = 0;
                            return;
                        }
                        else if ((player.direction == 3) && (player.Left < obj.Left + 16)) // Collision from the left
                        {
                            player.Left = obj.Left - 16;
                            player.direction = 0;
                            return;
                        }
                    }
                }
            }
        }
        private void Key_Down(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.direction = 1;
                    break;
                case Keys.Up:
                    player.direction = 2;
                    break;
                case Keys.Right:
                    player.direction = 3;
                    break;
                case Keys.Down:
                    player.direction = 4;
                    break;
            }
        }
        private void Key_Up(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                    player.direction = 0;
                    break;
            }
        }
        private void MainGameTick(object sender, EventArgs e)
        {
            player.MovePlayer();
            CheckCollision();
        }
    }
}
