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
        public Game()
        {
            InitializeComponent();
        }

        private void InitializeBoard ()
        {
            for (int y = 0; y < board.height; y++)
            {
                for (int x = 0; x < board.width; x++)
                {
                    if (board.layout[y, x] == 10)
                        BoardPanel.Controls.Add(new Wall(x, y));
                }
            }
        }
    }
}
