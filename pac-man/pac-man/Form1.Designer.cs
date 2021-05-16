
namespace Pac_Man
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.StartPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Level = new System.Windows.Forms.Label();
            this.LevelSign = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.ScoreSign = new System.Windows.Forms.Label();
            this.MainGameTimer = new System.Windows.Forms.Timer(this.components);
            this.Lives = new System.Windows.Forms.Label();
            this.live1 = new System.Windows.Forms.PictureBox();
            this.live2 = new System.Windows.Forms.PictureBox();
            this.live3 = new System.Windows.Forms.PictureBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.BoardPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.live1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.live2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.live3)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.Controls.Add(this.StartPanel);
            this.BoardPanel.Location = new System.Drawing.Point(0, 29);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(448, 496);
            this.BoardPanel.TabIndex = 0;
            // 
            // StartPanel
            // 
            this.StartPanel.BackgroundImage = global::Pac_Man.Properties.Resources.StartMenu;
            this.StartPanel.Location = new System.Drawing.Point(-5, 1);
            this.StartPanel.Name = "StartPanel";
            this.StartPanel.Size = new System.Drawing.Size(453, 495);
            this.StartPanel.TabIndex = 0;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.Level);
            this.TopPanel.Controls.Add(this.LevelSign);
            this.TopPanel.Controls.Add(this.Score);
            this.TopPanel.Controls.Add(this.ScoreSign);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(448, 30);
            this.TopPanel.TabIndex = 1;
            // 
            // Level
            // 
            this.Level.Font = new System.Drawing.Font("Zig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Level.ForeColor = System.Drawing.Color.Green;
            this.Level.Location = new System.Drawing.Point(402, 3);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(38, 23);
            this.Level.TabIndex = 3;
            this.Level.Text = "1";
            this.Level.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LevelSign
            // 
            this.LevelSign.Font = new System.Drawing.Font("Zig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LevelSign.ForeColor = System.Drawing.SystemColors.Control;
            this.LevelSign.Location = new System.Drawing.Point(314, 3);
            this.LevelSign.Name = "LevelSign";
            this.LevelSign.Size = new System.Drawing.Size(82, 23);
            this.LevelSign.TabIndex = 2;
            this.LevelSign.Text = "level";
            this.LevelSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Score
            // 
            this.Score.Font = new System.Drawing.Font("Zig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Score.ForeColor = System.Drawing.Color.Gold;
            this.Score.Location = new System.Drawing.Point(85, 1);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(82, 26);
            this.Score.TabIndex = 1;
            this.Score.Text = "0";
            this.Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScoreSign
            // 
            this.ScoreSign.Font = new System.Drawing.Font("Zig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreSign.ForeColor = System.Drawing.SystemColors.Control;
            this.ScoreSign.Location = new System.Drawing.Point(0, 1);
            this.ScoreSign.Name = "ScoreSign";
            this.ScoreSign.Size = new System.Drawing.Size(84, 26);
            this.ScoreSign.TabIndex = 0;
            this.ScoreSign.Text = "score";
            this.ScoreSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainGameTimer
            // 
            this.MainGameTimer.Interval = 20;
            this.MainGameTimer.Tick += new System.EventHandler(this.MainGameTick);
            // 
            // Lives
            // 
            this.Lives.Font = new System.Drawing.Font("Zig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Lives.ForeColor = System.Drawing.SystemColors.Control;
            this.Lives.Location = new System.Drawing.Point(292, 3);
            this.Lives.Name = "Lives";
            this.Lives.Size = new System.Drawing.Size(82, 23);
            this.Lives.TabIndex = 2;
            this.Lives.Text = "lives";
            this.Lives.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // live1
            // 
            this.live1.BackgroundImage = global::Pac_Man.Properties.Resources.live;
            this.live1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.live1.Location = new System.Drawing.Point(380, 6);
            this.live1.Name = "live1";
            this.live1.Size = new System.Drawing.Size(16, 16);
            this.live1.TabIndex = 3;
            this.live1.TabStop = false;
            // 
            // live2
            // 
            this.live2.BackgroundImage = global::Pac_Man.Properties.Resources.live;
            this.live2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.live2.Location = new System.Drawing.Point(402, 6);
            this.live2.Name = "live2";
            this.live2.Size = new System.Drawing.Size(16, 16);
            this.live2.TabIndex = 4;
            this.live2.TabStop = false;
            // 
            // live3
            // 
            this.live3.BackgroundImage = global::Pac_Man.Properties.Resources.live;
            this.live3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.live3.Location = new System.Drawing.Point(424, 6);
            this.live3.Name = "live3";
            this.live3.Size = new System.Drawing.Size(16, 16);
            this.live3.TabIndex = 5;
            this.live3.TabStop = false;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.live1);
            this.BottomPanel.Controls.Add(this.live2);
            this.BottomPanel.Controls.Add(this.live3);
            this.BottomPanel.Controls.Add(this.Lives);
            this.BottomPanel.Location = new System.Drawing.Point(0, 525);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(448, 27);
            this.BottomPanel.TabIndex = 2;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(448, 553);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.BoardPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Pac-Man";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            this.BoardPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.live1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.live2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.live3)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label ScoreSign;
        private System.Windows.Forms.Timer MainGameTimer;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label Lives;
        private System.Windows.Forms.PictureBox live1;
        private System.Windows.Forms.PictureBox live2;
        private System.Windows.Forms.PictureBox live3;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel StartPanel;
        private System.Windows.Forms.Label Level;
        private System.Windows.Forms.Label LevelSign;
    }
}

