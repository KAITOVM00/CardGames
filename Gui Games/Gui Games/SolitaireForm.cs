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
        PictureBox[][] PlayPilesPB;

        public SolitaireForm()
        {
            InitializeComponent();
            setupForm();
        }
        public void setupForm()
        {
            DeckPB.Image = Images.GetBackOfCardImage();
            Solitaire.SetupGame();
            CurrentPB.Image = Images.GetCardImage(Solitaire.GetCurrent().GetLastCardInPile());
        }
        private void UpdatePlayPiles()
        {
            PictureBox pBox;
            int[] revealed = Solitaire.GetRevealed();
            int numPiles = revealed.Length;
            List<Hand> piles = Solitaire.GetAllPlayHands();
            for (int i = 0; i < numPiles; i++)
            {
                int pileLength = piles[i].GetCount();
                int index = revealed[i];
                for (int j = 0; j < pileLength; j++)
                {
                    pBox = new PictureBox();
                    pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    pBox.Dock = DockStyle.Fill;
                    if (j < index)
                    {
                        pBox.Image = Images.GetBackOfCardImage();
                    }
                    else
                    {
                        Card card = piles[i].GetCard(j);
                        pBox.Image = Images.GetCardImage(card);
                        PlayPilesPB[i][j] = pBox;
                        PlayPilesPB[i][j].Click += new EventHandler(PlayPBox1_Click);
                        PlayPilesPB[i][j].Tag = Solitaire.GetAllPlayHands()[i].GetCard(j);//Crazy_Eights_Game.GetPlayerHand().GetCard(i);
                    }
                }
            }
        }
        static void PlayPBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
