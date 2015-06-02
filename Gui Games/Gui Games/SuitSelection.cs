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

namespace Gui_Games
{
    public partial class SuitSelection : Form
    {
        Card card;
        bool isDone = false;
        public SuitSelection()
        {
            InitializeComponent();
        }
        public bool getIsDone()
        {
            return isDone;
        }

        private void SpadesBtn_CheckedChanged(object sender, EventArgs e)
        {
            card = new Card(FaceValue.Eight,Suit.Spades);
        }

        private void HeartsBtn_CheckedChanged(object sender, EventArgs e)
        {
            card = new Card(FaceValue.Eight, Suit.Hearts);
        }

        private void DiamondsBtn_CheckedChanged(object sender, EventArgs e)
        {
            card = new Card(FaceValue.Eight, Suit.Diamonds);
        }

        private void ClubsBtn_CheckedChanged(object sender, EventArgs e)
        {
            card = new Card(FaceValue.Eight, Suit.Clubs);
        }
        public Card GetSelection()
        {
            return card;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            isDone = true;
            this.Close();
        }
    }
}
