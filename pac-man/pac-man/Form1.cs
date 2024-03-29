﻿using System;
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
        Ghost red_ghost, blue_ghost, orange_ghost, pink_ghost;
        List<Door> doors = new List<Door>();
        List<Fruit> fruits = new List<Fruit>();
        int level = 0;
        int gamestate;
        bool paused = false;
        public Game ()
        {
            InitializeComponent();
            InitializeScoreboard();
            DisplayLevelCounter();
            TopPanel.Visible = false;
            BottomPanel.Visible = false;
            this.gamestate = 0;
            InitializeBoard();
            StartPanel.BringToFront();
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
                        case 40:
                            BoardPanel.Controls.Add(new Wall(x, y, 40));
                            break;
                        case 41:
                            BoardPanel.Controls.Add(new Wall(x, y, 41));
                            break;
                        case 42:
                            BoardPanel.Controls.Add(new Wall(x, y, 42));
                            break;
                        case 43:
                            BoardPanel.Controls.Add(new Wall(x, y, 43));
                            break;
                        case 44:
                            BoardPanel.Controls.Add(new Wall(x, y, 44));
                            break;
                        case 45:
                            BoardPanel.Controls.Add(new Wall(x, y, 45));
                            break;
                        case 50:
                            BoardPanel.Controls.Add(new Wall(x, y, 50));
                            break;
                        case 51:
                            BoardPanel.Controls.Add(new Wall(x, y, 51));
                            break;
                        case 52:
                            BoardPanel.Controls.Add(new Wall(x, y, 52));
                            break;
                        case 53:
                            BoardPanel.Controls.Add(new Wall(x, y, 53));
                            break;
                        case 60:
                            BoardPanel.Controls.Add(new Wall(x, y, 60));
                            break;
                        case 61:
                            BoardPanel.Controls.Add(new Wall(x, y, 61));
                            break;
                        case 62:
                            BoardPanel.Controls.Add(new Wall(x, y, 62));
                            break;
                        case 63:
                            BoardPanel.Controls.Add(new Wall(x, y, 63));
                            break;
                        case 70:
                            BoardPanel.Controls.Add(new Wall(x, y, 70));
                            break;
                        case 71:
                            BoardPanel.Controls.Add(new Wall(x, y, 71));
                            break;
                        case 72:
                            BoardPanel.Controls.Add(new Wall(x, y, 72));
                            break;
                        case 73:
                            BoardPanel.Controls.Add(new Wall(x, y, 73));
                            break;
                        case 80:
                            BoardPanel.Controls.Add(new Wall(x, y, 80));
                            break;
                        case 81:
                            BoardPanel.Controls.Add(new Wall(x, y, 81));
                            break;
                        case 90:
                            BoardPanel.Controls.Add(new Wall(x, y, 90));
                            break;
                        case 91:
                            BoardPanel.Controls.Add(new Wall(x, y, 91));
                            break;
                        case 92:
                            BoardPanel.Controls.Add(new Wall(x, y, 92));
                            break;
                        case 93:
                            BoardPanel.Controls.Add(new Wall(x, y, 93));
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
                            blue_ghost = new Ghost(x, y, 'b');
                            BoardPanel.Controls.Add(blue_ghost);
                            blue_ghost.BringToFront();
                            break;
                        case 17:
                            pink_ghost = new Ghost(x, y, 'p');
                            BoardPanel.Controls.Add(pink_ghost);
                            pink_ghost.BringToFront();
                            break;
                        case 18:
                            orange_ghost = new Ghost(x, y, 'o');
                            BoardPanel.Controls.Add(orange_ghost);
                            orange_ghost.BringToFront();
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
        private void DisplayLevelCounter ()
        {
            this.level += 1;
            if (this.level > 99)
                this.Level.Text = "??";
            else this.Level.Text = this.level.ToString();
        }
        private async void CheckWinCondition ()
        {
            if (scoreboard.AllCoinsCollected()) 
            {
                await Task.Delay(1500);
                MainGameTimer.Stop();
                NextLevel();
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
                                SpawnFruit(obj);
                            }
                            break;

                        case Fruit:

                            if (obj.Visible)
                            {
                                obj.Visible = false;
                                if ((int)obj.Tag == 0)
                                    this.scoreboard.IncrementScoreByAmount(50);
                                else if ((int)obj.Tag == 1)
                                    this.scoreboard.IncrementScoreByAmount(100);
                                else if ((int)obj.Tag == 2)
                                    this.scoreboard.IncrementScoreByAmount(500);
                                BoardPanel.Controls.Remove(obj);
                                fruits.Remove(obj as Fruit);
                            }
                            break;

                        case Powerup:

                            if (obj.Visible)
                            {
                                obj.Visible = false;
                                player.Tag = 2;
                                if ((int)red_ghost.Tag == 0)
                                    red_ghost.Tag = 2;
                                if ((int)blue_ghost.Tag == 0)
                                    blue_ghost.Tag = 2;
                                if ((int)pink_ghost.Tag == 0)
                                    pink_ghost.Tag = 2;
                                if ((int)orange_ghost.Tag == 0)
                                    orange_ghost.Tag = 2;
                                RemovePowerup();
                            }
                            break;

                        case Ghost:

                            if (obj.Visible)
                            {
                                PlayerGhostCollision(obj);
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

            player.UpdateSprite();
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
                        {
                            if ((int)red_ghost.Tag == 0)
                                red_ghost.PlayerPositionBasedMovement(this.player, point);
                            else if ((int)red_ghost.Tag == 2)
                                red_ghost.RunningAway(this.player, point);
                            else if ((int)red_ghost.Tag == 1)
                                red_ghost.RandomMovement(point);
                        }

                        if (orange_ghost.Location == point.Location)
                        {
                            if ((int)orange_ghost.Tag == 0 && this.level < 2)
                                orange_ghost.RandomMovement(point);
                            else if ((int)orange_ghost.Tag == 0 && this.level >= 2)
                                orange_ghost.PlayerPositionBasedMovement(this.player, point);
                            else if ((int)orange_ghost.Tag == 2)
                                orange_ghost.RunningAway(this.player, point);
                            else if ((int)orange_ghost.Tag == 1)
                                orange_ghost.RandomMovement(point);
                        }

                        if (pink_ghost.Location == point.Location)
                        {
                            if ((int)pink_ghost.Tag == 0 && this.level < 4)
                                pink_ghost.RightLeftMovement(point);
                            if ((int)pink_ghost.Tag == 0 && this.level >= 4)
                                pink_ghost.PlayerPositionBasedMovement(this.player, point);
                            else if ((int)pink_ghost.Tag == 2)
                                pink_ghost.RunningAway(this.player, point);
                            else if ((int)pink_ghost.Tag == 1)
                                pink_ghost.RandomMovement(point);
                        }

                        if (blue_ghost.Location == point.Location)
                        {
                            if ((int)blue_ghost.Tag == 0)
                                blue_ghost.RightLeftMovement(point);
                            else if ((int)blue_ghost.Tag == 2)
                                blue_ghost.RunningAway(this.player, point);
                            else if ((int)blue_ghost.Tag == 1)
                                blue_ghost.RandomMovement(point);
                        }

                        break;

                    case Wall:

                        if (pink_ghost.Bounds.IntersectsWith(obj.Bounds) && pink_ghost.initialmove)
                        {
                            int rnum = rand.Next(10);
                            if (rnum <= 4)
                                pink_ghost.direction = 3;
                            else if (rnum > 4)
                                pink_ghost.direction = 1;
                            pink_ghost.Top = obj.Top + 16;
                            pink_ghost.initialmove = false;
                        }

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

                        if (orange_ghost.Bounds.IntersectsWith(obj.Bounds) && orange_ghost.initialmove)
                        {
                            int rnum = rand.Next(10);
                            if (rnum <= 4)
                                orange_ghost.direction = 3;
                            else if (rnum > 4)
                                orange_ghost.direction = 1;
                            orange_ghost.Top = obj.Top + 16;
                            orange_ghost.initialmove = false;
                        }

                        if (blue_ghost.Bounds.IntersectsWith(obj.Bounds) && blue_ghost.initialmove)
                        {
                            int rnum = rand.Next(10);
                            if (rnum <= 4)
                                blue_ghost.direction = 3;
                            else if (rnum > 4)
                                blue_ghost.direction = 1;
                            blue_ghost.Top = obj.Top + 16;
                            blue_ghost.initialmove = false;
                        }
                        break;
                }
            }
        }

        private void Key_Down (object sender, KeyEventArgs e)
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
                case Keys.Enter:
                    if (this.gamestate == 0)
                        StartGame();
                    else if (this.gamestate == 2)
                        RestartGame();
                    break;
                case Keys.P:
                    if (this.gamestate == 1 && this.paused)
                    {
                        MainGameTimer.Start();
                        this.paused = false;
                    }
                    else if (this.gamestate == 1 && !this.paused)
                    {
                        MainGameTimer.Stop();
                        this.paused = true;
                    }
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
            {
                live3.Visible = false;
                GameOver();
            }

        }
        private async void RemovePowerup ()
        {
            await Task.Delay(5000);
            if ((int)red_ghost.Tag == 2)
                red_ghost.Tag = 0;
            if ((int)blue_ghost.Tag == 2)
                blue_ghost.Tag = 0;
            if ((int)orange_ghost.Tag == 2)
                orange_ghost.Tag = 0;
            if ((int)pink_ghost.Tag == 2)
                pink_ghost.Tag = 0;
            player.Tag = 0;
            await Task.Delay(5000);
            if ((int)red_ghost.Tag == 1)
                red_ghost.Tag = 0;
            if ((int)blue_ghost.Tag == 1)
                blue_ghost.Tag = 0;
            if ((int)orange_ghost.Tag == 1)
                orange_ghost.Tag = 0;
            if ((int)pink_ghost.Tag == 1)
                pink_ghost.Tag = 0;
        }
        private async void PlayerGhostCollision (PictureBox ghost)
        {
            if ((int)player.Tag == 2)
            {
                ghost.Tag = 1;
            }
            else if ((int)player.Tag == 0)
            {
                player.lives -= 1;
                player.Tag = 1;
                await Task.Delay(3000);
                player.Tag = 0;
            }
        }
        private void UpdateGhostSprites ()
        {
            if ((int)red_ghost.Tag == 0)
            {
                switch (red_ghost.direction)
                {
                    case 1:
                        red_ghost.Image = Properties.Resources.r_ghost1;
                        break;
                    case 2:
                        red_ghost.Image = Properties.Resources.r_ghost2;
                        break;
                    case 3:
                        red_ghost.Image = Properties.Resources.r_ghost3;
                        break;
                    case 4:
                        red_ghost.Image = Properties.Resources.r_ghost4;
                        break;
                }
            }
            else if ((int)red_ghost.Tag == 2)
            {
                red_ghost.Weakened();
            }
            else if ((int)red_ghost.Tag == 1)
            {
                red_ghost.Dead();
            }

            if ((int)blue_ghost.Tag == 0)
            {
                switch (blue_ghost.direction)
                {
                    case 1:
                        blue_ghost.Image = Properties.Resources.b_ghost1;
                        break;
                    case 2:
                        blue_ghost.Image = Properties.Resources.b_ghost2;
                        break;
                    case 3:
                        blue_ghost.Image = Properties.Resources.b_ghost3;
                        break;
                    case 4:
                        blue_ghost.Image = Properties.Resources.b_ghost4;
                        break;
                }
            }
            else if ((int)blue_ghost.Tag == 2)
            {
                blue_ghost.Weakened();
            }
            else if ((int)blue_ghost.Tag == 1)
            {
                blue_ghost.Dead();
            }

            if ((int)pink_ghost.Tag == 0)
            {
                switch (pink_ghost.direction)
                {
                    case 1:
                        pink_ghost.Image = Properties.Resources.p_ghost1;
                        break;
                    case 2:
                        pink_ghost.Image = Properties.Resources.p_ghost2;
                        break;
                    case 3:
                        pink_ghost.Image = Properties.Resources.p_ghost3;
                        break;
                    case 4:
                        pink_ghost.Image = Properties.Resources.p_ghost4;
                        break;
                }
            }
            else if ((int)pink_ghost.Tag == 2)
            {
                pink_ghost.Weakened();
            }
            else if ((int)pink_ghost.Tag == 1)
            {
                pink_ghost.Dead();
            }

            if ((int)orange_ghost.Tag == 0)
            {
                switch (orange_ghost.direction)
                {
                    case 1:
                        orange_ghost.Image = Properties.Resources.o_ghost1;
                        break;
                    case 2:
                        orange_ghost.Image = Properties.Resources.o_ghost2;
                        break;
                    case 3:
                        orange_ghost.Image = Properties.Resources.o_ghost3;
                        break;
                    case 4:
                        orange_ghost.Image = Properties.Resources.o_ghost4;
                        break;
                }
            }
            else if ((int)orange_ghost.Tag == 2)
            {
                orange_ghost.Weakened();
            }
            else if ((int)orange_ghost.Tag == 1)
            {
                orange_ghost.Dead();
            }
        }
        private void MainGameTick (object sender, EventArgs e)
        {
            player.UpdatePlayerPosition();
            pink_ghost.UpdateGhostPosition();
            orange_ghost.UpdateGhostPosition();
            red_ghost.UpdateGhostPosition();
            blue_ghost.UpdateGhostPosition();
            PlayerEvents();
            GhostEvents();
            UpdateGhostSprites();
            CheckPlayerLives();
            CheckWinCondition();
        }
        private async void StartGame ()
        {
            StartPanel.Visible = false;
            BoardPanel.Controls.Remove(StartPanel);
            TopPanel.Visible = true;
            BottomPanel.Visible = true;
            await Task.Delay(3000);
            InitializeGhosts();
            this.gamestate = 1;
            MainGameTimer.Start();
        }
        private async void NextLevel ()
        {
            await Task.Delay(3000);
            DisplayLevelCounter();
            foreach (PictureBox p in BoardPanel.Controls)
            {
                if (p is Coin || p is Powerup)
                    p.Visible = true;
            }
            foreach (Fruit f in fruits)
            {
                BoardPanel.Controls.Remove(f);
            }
            player.ResetPosition();
            InitializeGhosts();
            MainGameTimer.Start();
        }
        private async void _InitializeGhost (Ghost ghost, int time)
        {
            ghost.Start(time);
            await Task.Delay(time);
            foreach (Door d in doors)
                d.Visible = false;
            await Task.Delay(1000);
            foreach (Door d in doors)
                d.Visible = true;
        }
        private void InitializeGhosts ()
        {
            _InitializeGhost(blue_ghost, 2000);
            _InitializeGhost(pink_ghost, 8000);
            _InitializeGhost(orange_ghost, 14000);
            _InitializeGhost(red_ghost, 20000);
        }
        private async void RestartGame ()
        {
            await Task.Delay(3000);
            BoardPanel.Controls.Clear();
            InitializeBoard();
            this.level = 1;
            this.player.lives = 3;
            this.scoreboard.ResetScore();
            player.ResetPosition();
            InitializeGhosts();
            this.gamestate = 1;
            this.LevelSign.Visible = true;
            this.Level.Text = this.level.ToString();
            ResetLives();
            this.Level.Visible = true;
            this.BottomPanel.Visible = true;
            MainGameTimer.Start();
        }
        private void GameOver ()
        {
            Panel p = new Panel();
            p.Size = new Size(448, 496);
            p.Location = new Point(-5, 10);
            p.BackgroundImage = Properties.Resources.EndMenu;
            
            MainGameTimer.Stop();
            this.red_ghost.Visible = false;
            this.blue_ghost.Visible = false;
            this.orange_ghost.Visible = false;
            this.pink_ghost.Visible = false;
            this.LevelSign.Visible = false;
            this.Level.Visible = false;
            this.BottomPanel.Visible = false;
            BoardPanel.Controls.Clear();
            BoardPanel.Controls.Add(p);
            p.BringToFront();
            this.gamestate = 2;
        }
        private async void SpawnFruit (PictureBox obj)
        {
            await Task.Delay(6000);
            int rnum = rand.Next(100);
            if (rnum <= 1)
            {
                Fruit f = new Fruit(obj.Location);
                BoardPanel.Controls.Add(f);
                fruits.Add(f);
            }

        }
        private void ResetLives ()
        {
            this.live1.Visible = true;
            this.live2.Visible = true;
            this.live3.Visible = true;
        }
    }
}
