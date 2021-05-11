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
        Random rand = new Random();
        Board board = new Board();
        Scoreboard scoreboard;
        Player player;
        Ghost red_ghost, green_ghost;
        List<Door> doors = new List<Door>();
        public Game()
        {
            InitializeComponent();
            InitializeScoreboard();
            InitializeBoard();
            red_ghost.Start(5000);
            green_ghost.Start(5000);
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
                            scoreboard.AddCoin();
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
                            Door d = new Door(x, y);
                            doors.Add(d);
                            BoardPanel.Controls.Add(d);
                            break;
                        case 12:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, false, false));
                            break;
                        case 14:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, false, false, true));
                            break;
                        case 15:
                            red_ghost = new Ghost(x, y, 'r');
                            BoardPanel.Controls.Add(red_ghost);
                            red_ghost.BringToFront();
                            break;
                        case 16:
                            green_ghost = new Ghost(x, y, 'g');
                            BoardPanel.Controls.Add(green_ghost);
                            green_ghost.BringToFront();
                            break;
                        case 23:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, false, true, true, false));
                            break;
                        case 34:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, false, false, true, true));
                            break;
                        case 123:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, true, false));
                            break;
                        case 124:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, false, true));
                            break;
                        case 134:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, false, true, true));
                            break;
                        case 234:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, false, true, true, true));
                            break;
                        case 1234:
                            BoardPanel.Controls.Add(new Coin(x, y));
                            scoreboard.AddCoin();
                            BoardPanel.Controls.Add(new TurningPoint(x, y, true, true, true, true));
                            break;
                    }
                }
            }
        }
        private void InitializeScoreboard ()
        {
            this.scoreboard = new Scoreboard(Score);
        }
        private void CheckWinCondition ()
        {
            if (scoreboard.AllCoinsCollected()) 
            {
                MessageBox.Show("Level completed!");
                MainGameTimer.Enabled = false;
            }
        }
        private void PlayerEvents ()
        {
            foreach (PictureBox obj in BoardPanel.Controls)
            {
                if (player.Bounds.IntersectsWith(obj.Bounds))
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
                            player.ResetNewdirection();
                            break;

                        case Door:
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
                            player.ResetNewdirection();
                            break;


                        case Coin:
                            if (obj.Visible)
                            {
                                obj.Visible = false;
                                scoreboard.IncrementScore();
                            }
                            break;

                        case Powerup:
                            if (obj.Visible)
                            {
                                obj.Visible = false;
                                player.Tag = 2;
                                player.RemovePowerup();
                            }
                            break;

                        case Ghost:
                            if (obj.Visible)
                            {
                                PlayerGhostCollision();
                            }
                            break;
                    }
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

        private void GhostEvents ()
        {
            foreach(PictureBox obj in BoardPanel.Controls)
            {
                switch (obj)
                {
                    case TurningPoint:

                        TurningPoint point = obj as TurningPoint;

                        if (red_ghost.Location == point.Location)
                            red_ghost.RandomMovement(point);

                        if (green_ghost.Location == point.Location)
                            green_ghost.RightLeftMovement(point);
                        break;

                    case Wall:

                        if (red_ghost.Bounds.IntersectsWith(obj.Bounds) && red_ghost.initialmove)
                        {
                            int rnum = rand.Next(10);
                            if (rnum <= 4)
                                red_ghost.direction = 3;
                            else if (rnum > 4)
                                red_ghost.direction = 1;
                            red_ghost.Top = obj.Top + 16;
                            red_ghost.initialmove = false;

                        }
                        if (green_ghost.Bounds.IntersectsWith(obj.Bounds) && green_ghost.initialmove)
                        {
                            int rnum = rand.Next(10);
                            if (rnum <= 4)
                                green_ghost.direction = 3;
                            else if (rnum > 4)
                                green_ghost.direction = 1;
                            green_ghost.Top = obj.Top + 16;
                            green_ghost.initialmove = false;
                        }
                        break;
                }
            }

            if (red_ghost.Left < -8)
                red_ghost.Left = 440;
            else if (red_ghost.Left + 8 > 448)
                red_ghost.Left = -8;

            if (green_ghost.Left < -8)
                green_ghost.Left = 440;
            else if (green_ghost.Left + 8 > 448)
                green_ghost.Left = -8;
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
        private void CheckPlayerLives ()
        {
            if (player.lives == 2)
                live1.Visible = false;
            else if (player.lives == 1)
                live2.Visible = false;
            else if (player.lives == 0)
                live3.Visible = false;
            else if (player.lives == -1)
            {
                live1.Visible = true;
                live2.Visible = true;
                live3.Visible = true;
            }

        }
        private async void PlayerGhostCollision ()
        {
            //if (player.powerup)
            //do smthing
            if ((int)player.Tag == 0)
            {
                player.Tag = 1;
                player.lives -= 1;
                await Task.Delay(2000);
                player.Tag = 0;
            }    
        }
        private void MainGameTick(object sender, EventArgs e)
        {
            player.UpdatePlayerPosition();
            red_ghost.UpdateGhostPosition();
            green_ghost.UpdateGhostPosition();
            PlayerEvents();
            GhostEvents();
            CheckPlayerLives();
            //CheckWinCondition();
        }
    }
    //TODO: Implement ghost moving + search algo
    //TODO: Implement transitions between stages (Ready - Playing - Ended)
}
