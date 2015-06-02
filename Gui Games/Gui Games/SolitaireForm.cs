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
        PictureBox[] PlayPilesPB1;
        PictureBox[] PlayPilesPB2;
        PictureBox[] PlayPilesPB3;
        PictureBox[] PlayPilesPB4;
        PictureBox[] PlayPilesPB5;
        PictureBox[] PlayPilesPB6;
        PictureBox[] PlayPilesPB7;
        int maxNumberOfCards = 13;

        public SolitaireForm()
        {
            InitializeComponent();
            setupForm();
        }
        public void setupForm()
        {
            PlayPilesPB1 = new PictureBox[maxNumberOfCards];
            PlayPilesPB2 = new PictureBox[maxNumberOfCards];
            PlayPilesPB3 = new PictureBox[maxNumberOfCards];
            PlayPilesPB4 = new PictureBox[maxNumberOfCards];
            PlayPilesPB5 = new PictureBox[maxNumberOfCards];
            PlayPilesPB6 = new PictureBox[maxNumberOfCards];
            PlayPilesPB7 = new PictureBox[maxNumberOfCards];
            DeckPB.Image = Images.GetBackOfCardImage();
            Solitaire.SetupGame();
            CurrentPB.Image = Images.GetCardImage(Solitaire.GetCurrent().GetLastCardInPile());
            RefreshScreen();
        }
        private void RefreshScreen()
        {
            UpdatePlayPiles1();
            DisplayPlayPiles1();

            UpdatePlayPiles2();
            DisplayPlayPiles2();

            UpdatePlayPiles3();
            DisplayPlayPiles3();

            UpdatePlayPiles4();
            DisplayPlayPiles4();

            UpdatePlayPiles5();
            DisplayPlayPiles5();

            UpdatePlayPiles6();
            DisplayPlayPiles6();

            UpdatePlayPiles7();
            DisplayPlayPiles7();
        }

        /// <summary>
        /// Updates the Player board table 1 with a new set of picture
        /// boxes based on the hands taken from the solitaire class
        /// </summary>
        private void UpdatePlayPiles1()
        {
            int playPileIndex = 0;
            PictureBox pBox;
            int revealed = Solitaire.GetRevealed()[playPileIndex];
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = hand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                if(i<revealed)
                {
                    pBox.Image = Images.GetBackOfCardImage();
                }
                else
                {
                    pBox.Image = Images.GetCardImage(card);
                }
                PlayPilesPB1[i] = pBox;
                PlayPilesPB1[i].Click += new EventHandler(PlayPBox1_Click);
                PlayPilesPB1[i].Tag = Solitaire.GetPlayHand(playPileIndex).GetCard(i);
            }
        }

        /// <summary>
        /// Displays the images for the Player Board 1
        /// </summary>
        private void DisplayPlayPiles1()
        {
            int playPileIndex = 0;
            PlayBoard1.Controls.Clear();
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayBoard1.Controls.Add(PlayPilesPB1[i]);
            }
        }

        
        private void PlayPBox1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the Player board table 2 with a new set of picture
        /// boxes based on the hands taken from the solitaire class
        /// </summary>
        private void UpdatePlayPiles2()
        {
            int playPileIndex = 1;
            PictureBox pBox;
            int revealed = Solitaire.GetRevealed()[playPileIndex];
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = hand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                if (i < revealed)
                {
                    pBox.Image = Images.GetBackOfCardImage();
                }
                else
                {
                    pBox.Image = Images.GetCardImage(card);
                }
                PlayPilesPB2[i] = pBox;
                PlayPilesPB2[i].Click += new EventHandler(PlayPBox2_Click);
                PlayPilesPB2[i].Tag = Solitaire.GetPlayHand(playPileIndex).GetCard(i);
            }
        }

        /// <summary>
        /// Displays the images for the Player Board 2
        /// </summary>
        private void DisplayPlayPiles2()
        {
            int playPileIndex = 1;
            PlayBoard2.Controls.Clear();
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayBoard2.Controls.Add(PlayPilesPB2[i]);
            }
        }


        private void PlayPBox2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the Player board table 3 with a new set of picture
        /// boxes based on the hands taken from the solitaire class
        /// </summary>
        private void UpdatePlayPiles3()
        {
            int playPileIndex = 2;
            PictureBox pBox;
            int revealed = Solitaire.GetRevealed()[playPileIndex];
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = hand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                if (i < revealed)
                {
                    pBox.Image = Images.GetBackOfCardImage();
                }
                else
                {
                    pBox.Image = Images.GetCardImage(card);
                }
                PlayPilesPB3[i] = pBox;
                PlayPilesPB3[i].Click += new EventHandler(PlayPBox3_Click);
                PlayPilesPB3[i].Tag = Solitaire.GetPlayHand(playPileIndex).GetCard(i);
            }
        }

        /// <summary>
        /// Displays the images for the Player Board 3
        /// </summary>
        private void DisplayPlayPiles3()
        {
            int playPileIndex = 2;
            PlayBoard3.Controls.Clear();
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayBoard3.Controls.Add(PlayPilesPB3[i]);
            }
        }


        private void PlayPBox3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the Player board table 4 with a new set of picture
        /// boxes based on the hands taken from the solitaire class
        /// </summary>
        private void UpdatePlayPiles4()
        {
            int playPileIndex = 3;
            PictureBox pBox;
            int revealed = Solitaire.GetRevealed()[playPileIndex];
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = hand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                if (i < revealed)
                {
                    pBox.Image = Images.GetBackOfCardImage();
                }
                else
                {
                    pBox.Image = Images.GetCardImage(card);
                }
                PlayPilesPB4[i] = pBox;
                PlayPilesPB4[i].Click += new EventHandler(PlayPBox4_Click);
                PlayPilesPB4[i].Tag = Solitaire.GetPlayHand(playPileIndex).GetCard(i);
            }
        }

        /// <summary>
        /// Displays the images for the Player Board 4
        /// </summary>
        private void DisplayPlayPiles4()
        {
            int playPileIndex = 3;
            PlayBoard4.Controls.Clear();
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayBoard4.Controls.Add(PlayPilesPB4[i]);
            }
        }


        private void PlayPBox4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the Player board table 5 with a new set of picture
        /// boxes based on the hands taken from the solitaire class
        /// </summary>
        private void UpdatePlayPiles5()
        {
            int playPileIndex = 4;
            PictureBox pBox;
            int revealed = Solitaire.GetRevealed()[playPileIndex];
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = hand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                if (i < revealed)
                {
                    pBox.Image = Images.GetBackOfCardImage();
                }
                else
                {
                    pBox.Image = Images.GetCardImage(card);
                }
                PlayPilesPB5[i] = pBox;
                PlayPilesPB5[i].Click += new EventHandler(PlayPBox5_Click);
                PlayPilesPB5[i].Tag = Solitaire.GetPlayHand(playPileIndex).GetCard(i);
            }
        }

        /// <summary>
        /// Displays the images for the Player Board 5
        /// </summary>
        private void DisplayPlayPiles5()
        {
            int playPileIndex = 4;
            PlayBoard5.Controls.Clear();
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayBoard5.Controls.Add(PlayPilesPB5[i]);
            }
        }


        private void PlayPBox5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the Player board table 6 with a new set of picture
        /// boxes based on the hands taken from the solitaire class
        /// </summary>
        private void UpdatePlayPiles6()
        {
            int playPileIndex = 5;
            PictureBox pBox;
            int revealed = Solitaire.GetRevealed()[playPileIndex];
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = hand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                if (i < revealed)
                {
                    pBox.Image = Images.GetBackOfCardImage();
                }
                else
                {
                    pBox.Image = Images.GetCardImage(card);
                }
                PlayPilesPB6[i] = pBox;
                PlayPilesPB6[i].Click += new EventHandler(PlayPBox6_Click);
                PlayPilesPB6[i].Tag = Solitaire.GetPlayHand(playPileIndex).GetCard(i);
            }
        }

        /// <summary>
        /// Displays the images for the Player Board 6
        /// </summary>
        private void DisplayPlayPiles6()
        {
            int playPileIndex = 5;
            PlayBoard6.Controls.Clear();
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayBoard6.Controls.Add(PlayPilesPB6[i]);
            }
        }


        private void PlayPBox6_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the Player board table 7 with a new set of picture
        /// boxes based on the hands taken from the solitaire class
        /// </summary>
        private void UpdatePlayPiles7()
        {
            int playPileIndex = 6;
            PictureBox pBox;
            int revealed = Solitaire.GetRevealed()[playPileIndex];
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = hand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                if (i < revealed)
                {
                    pBox.Image = Images.GetBackOfCardImage();
                }
                else
                {
                    pBox.Image = Images.GetCardImage(card);
                }
                PlayPilesPB7[i] = pBox;
                PlayPilesPB7[i].Click += new EventHandler(PlayPBox7_Click);
                PlayPilesPB7[i].Tag = Solitaire.GetPlayHand(playPileIndex).GetCard(i);
            }
        }

        /// <summary>
        /// Displays the images for the Player Board 7
        /// </summary>
        private void DisplayPlayPiles7()
        {
            int playPileIndex = 6;
            PlayBoard7.Controls.Clear();
            Hand hand = Solitaire.GetPlayHand(playPileIndex);
            int handSize = hand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayBoard7.Controls.Add(PlayPilesPB1[i]);
            }
        }


        private void PlayPBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
