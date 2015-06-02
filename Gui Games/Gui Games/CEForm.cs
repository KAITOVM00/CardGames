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
using GuiGames;
using Game_Class_Library;

namespace Gui_Games
{
    public partial class CEForm : Form
    {
        PictureBox[] playerPBox;
        PictureBox[] computerPBox;
        string yourTurnText = "Your turn. Click to place\n a card";
        string dealText = "Click Deal to start the game \n ";
        string wrongCard = "Please select a Legal move to \n play";
        public CEForm()
        {
            InitializeComponent();
            playerPBox = new PictureBox[13];
            computerPBox = new PictureBox[13];
            SetupDeck();
            InstructionText.Text = dealText;


        }
        private void SetupDeck()
        {

            DeckPB.Image = Images.GetBackOfCardImage();
        }
        private void Refresh()
        {
            UpdatePHand();
            DisplayPHand();
            UpdateCHand();
            DisplayCHand();
            UpdateDeck();
            UpdateDiscard();
        }
        private void UpdatePHand()
        {
            PictureBox pBox;
            Hand pHand = Crazy_Eights_Game.GetPlayerHand();
            int handSize = pHand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = pHand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                pBox.Image = Images.GetCardImage(card);
                playerPBox[i] = pBox;
                playerPBox[i].Click += new EventHandler(PlayerPBox_Click);
                playerPBox[i].Tag = Crazy_Eights_Game.GetPlayerHand().GetCard(i);
            }

        }
        private void UpdateCHand()
        {
            PictureBox pBox;
            Hand cHand = Crazy_Eights_Game.GetComputerHand();
            int handSize = cHand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                Card card = cHand.GetCard(i);
                pBox = new PictureBox();
                pBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pBox.Dock = DockStyle.Fill;
                pBox.Image = Images.GetCardImage(card);
                computerPBox[i] = pBox;
            }
        }
        private void DisplayCHand()
        {
            CompPanel.Controls.Clear();
            Hand cHand = Crazy_Eights_Game.GetComputerHand();
            int handSize = cHand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                CompPanel.Controls.Add(computerPBox[i]);
            }
        }
        private void DisplayPHand()
        {
            PlayerPanel.Controls.Clear();
            Hand pHand = Crazy_Eights_Game.GetPlayerHand();
            int handSize = pHand.GetCount();
            for (int i = 0; i < handSize; i++)
            {
                PlayerPanel.Controls.Add(playerPBox[i]);
            }
        }
        private void PlayerPBox_Click(object sender, EventArgs e)
        {
            int whichCard;
            PictureBox whichClicked = (PictureBox)sender;
            whichCard = Crazy_Eights_Game.WhichCard((Card)whichClicked.Tag);
            Card Selected = Crazy_Eights_Game.GetPlayerHand().GetCard(whichCard);
            if (Crazy_Eights_Game.IsEight(Selected))
            {
                SuitSelection suitSelection = new SuitSelection();
                DialogResult result = suitSelection.ShowDialog();
                Card card = new Card();
                if (result == DialogResult.OK)
                {
                    card = suitSelection.GetSelection();
                }
                Crazy_Eights_Game.PlayerTurn(Selected,card);
                Refresh();
            }
            else
            {
                bool check = Crazy_Eights_Game.PlayerTurn(Selected);
                if (check)
                {

                    Crazy_Eights_Game.ComputerTurn();
                    InstructionText.Text = yourTurnText;
                    Refresh();
                }
                else
                {
                    InstructionText.Text = wrongCard;
                }
            }
        }
        private void UpdateDiscard()
        {
            Card card = Crazy_Eights_Game.GetTopOfDiscard();
            DiscardPB.Image = Images.GetCardImage(card);
            //check current top of discard pile and set picturebox to that card
        }
        private void UpdateDeck()
        {
            Crazy_Eights_Game.DeckDiscardSwap();
        }



        private void CEForm_Load(object sender, EventArgs e)
        {

        }

        private void DealBtn_Click(object sender, EventArgs e)
        {
            Crazy_Eights_Game.SetupGame();
            DealBtn.Enabled = false;
            SortBtn.Enabled = true;
            Refresh();
            InstructionText.Text = yourTurnText;
        }

        private void SortBtn_Click(object sender, EventArgs e)
        {
            Crazy_Eights_Game.SortPlayerHand();
            Refresh();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}