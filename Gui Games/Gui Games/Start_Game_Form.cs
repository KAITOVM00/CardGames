using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiGames;

namespace Gui_Games
{
    public partial class Start_Game_Form : Form
    {
        public Start_Game_Form()
        {
            InitializeComponent();
        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (GameSelect.SelectedIndex == 0)
            {

            }
            else if (GameSelect.SelectedIndex == 1)
            {
                new CEForm().Show();
            }
            else
            {
                MessageBox.Show("Sorry an Error has Occured");
            }
        }

        private void GameSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartBtn.Enabled = true;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
