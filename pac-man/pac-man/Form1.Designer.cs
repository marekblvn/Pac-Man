
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
            this.BoardPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScoreSign = new System.Windows.Forms.Label();
            this.MainGameTimer = new System.Windows.Forms.Timer(this.components);
            this.Score = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.Location = new System.Drawing.Point(0, 29);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(448, 496);
            this.BoardPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Score);
            this.panel1.Controls.Add(this.ScoreSign);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 30);
            this.panel1.TabIndex = 1;
            // 
            // ScoreSign
            // 
            this.ScoreSign.Font = new System.Drawing.Font("Zig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreSign.ForeColor = System.Drawing.SystemColors.Control;
            this.ScoreSign.Location = new System.Drawing.Point(0, 0);
            this.ScoreSign.Name = "ScoreSign";
            this.ScoreSign.Size = new System.Drawing.Size(84, 30);
            this.ScoreSign.TabIndex = 0;
            this.ScoreSign.Text = "score";
            this.ScoreSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainGameTimer
            // 
            this.MainGameTimer.Enabled = true;
            this.MainGameTimer.Interval = 20;
            this.MainGameTimer.Tick += new System.EventHandler(this.MainGameTick);
            // 
            // Score
            // 
            this.Score.Font = new System.Drawing.Font("Zig", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Score.ForeColor = System.Drawing.Color.Gold;
            this.Score.Location = new System.Drawing.Point(85, 0);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(67, 30);
            this.Score.TabIndex = 1;
            this.Score.Text = "0";
            this.Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(448, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BoardPanel);
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Pac-Man";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_Down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Key_Up);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BoardPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ScoreSign;
        private System.Windows.Forms.Timer MainGameTimer;
        private System.Windows.Forms.Label Score;
    }
}

