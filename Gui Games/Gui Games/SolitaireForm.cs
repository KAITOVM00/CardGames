using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared_Game_Class_Library;
using Game_Class_Library;
using GuiGames;

namespace Gui_Games
{
    public partial class SolitaireForm : Form
    {
        public SolitaireForm()
        {
            InitializeComponent();
        }
        private void UpdatePlayPiles()
        {
            int[] revealed = Solitaire.GetRevealed();

        }
    }
}
